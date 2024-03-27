using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.domain.account;
using TESTAPP.domain.account.sub;

namespace TESTAPP
{

    public partial class ViewVirtualLog : Form
    {

        #region "속성"

        private Account account; //계좌 하나만 세팅해둘 예정
        private AccountService service;
        public VirtualDto VirtualDto { get; set; }
        public List<VirtualLog> virtualLog { get; set; } = new List<VirtualLog>();

        public List<AfterPlan> afterPlans { get; set; } = new List<AfterPlan>();
        public List<VirtualLogConditionaly> virtualLogsConditionaly { get; set; } = new List<VirtualLogConditionaly>();
        public Period period { get; set; }

        #endregion

        #region "생성자"
        public ViewVirtualLog()
        {
            InitializeComponent();
        }

        #endregion

        #region "OnLoad"
        private void ViewCounditionLog_Load(object sender, EventArgs e)
        {
            ServiceInit();
            
            CopyLog();

            GetVirualLogResult();

            DataTable dt = new DataTable();
            if (period == Period.내역)
            {
            VirtualLogTableInit(dt);
            SetVirtualLogResult(dt);
            }
            else 
            {
            VirtualLogTableConditionInit(dt);
            SetVirtualLogResultConditionaly(dt);
            }

            CombineResult();

        }

        #endregion

        #region "서비스 세팅"
        private void ServiceInit()
        {
            service = new AccountService();

            this.account = service.SelectAccountById(VirtualDto.UserCode, VirtualDto.AccountId);
        }

        #endregion

        #region "버추얼 클래스로 값복사"
        private void CopyLog()
        {
            account.Log.ForEach(log =>
            {
                {
                    virtualLog.Add(new VirtualLog()
                    {
                        Id = log.Id,
                        AccountLogType = log.AccountLogType,
                        Amount = log.Amount,
                        DateTime = log.DateTime,
                        Total = log.Total,
                        Description = log.Description
                    });
                }
            });
        }

        #endregion

        #region "원본 내역 가져오기"
        private void GetVirualLogResult()
        {


            DateTime now = VirtualDto.Now;
            DateTime from = VirtualDto.From;
            DateTime until = VirtualDto.Until;

            // 이 작업을 서비스에 정의 ? 아니면 ..
            //날짜 갭 차이에 대한 원금 변화 반영, 근데 이것도 비즈니스 로직으로 본다면.. 내부로 옮기고 서비스를 타는게 나을듯

            // dto 로 만들어서 보내기.

            var dto = new AccountVirtuallogDto()
            {
                AccountId = account.AccountId,
                UserCode = 1L,
                AfterPlans = afterPlans,
                Amount = account.Amount,
                Log = virtualLog,
                Insert = false,
                ResultAmount = 0,
                loopInterest = 0
            };

            try
            {
                if (from.CompareTo(now) > 0) //현재 이 기능은 잠시 수정이 필요함
                {
                    // 결국 dto로 관리해야함 .. 

                    decimal vResultInterest = 0;
                    decimal vResultAmount = 0;

                    account.GetResult(dto,now,from);
                }
                account.GetResult(dto,from,until);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        #endregion

        #region "테이블 세팅"
        private void VirtualLogTableInit(DataTable dt)
        {
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("날짜", typeof(DateTime));
            dt.Columns.Add("입/출금", typeof(AccountLogType));
            dt.Columns.Add("금액", typeof(string));
            dt.Columns.Add("거래후잔액", typeof(string));
            dt.Columns.Add("비고", typeof(string));

            dgv_virtualView.DataSource = dt;
            
            dgv_virtualView.DataBindingComplete += (sender, o) =>
            {
                dgv_virtualView.Columns["금액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["거래후잔액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv_virtualView.Columns["금액"].Width = 100;
                dgv_virtualView.Columns["거래후잔액"].Width = 100;
                dgv_virtualView.Columns["입/출금"].Width = 70;
                dgv_virtualView.Columns["날짜"].Width = 140;
                dgv_virtualView.Columns["id"].Width = 60;

            };
        }

        private void VirtualLogTableConditionInit(DataTable dt)
        {

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("From", typeof(DateTime));
            dt.Columns.Add("To", typeof(DateTime));
            dt.Columns.Add("거래 구분", typeof(string));
            dt.Columns.Add("거래 금액", typeof(string));
            dt.Columns.Add("입금 액", typeof(string));
            dt.Columns.Add("출금 액", typeof(string));
            dt.Columns.Add("거래후잔액", typeof(string));
            dt.Columns.Add("비고", typeof(string));

            dgv_virtualView.DataSource = dt;
            
            dgv_virtualView.DataBindingComplete += (sender, o) =>
            {
                dgv_virtualView.Columns["입금 액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["출금 액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["거래 금액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["거래후잔액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            };
            
        }

        #endregion

        #region "조건에 맞는 검색"
        private void SetVirtualLogResultConditionaly(DataTable dt)
        {
            Calculate(VirtualDto.From, VirtualDto.From, VirtualDto.Until, period);

            SetData(dt);
        }

        private void Calculate(DateTime standard, DateTime start, DateTime end, Period period)
        {

            DateTime until = start;

            decimal? total = 0;


            while (until.CompareTo(end) <= 0)
            {
                decimal? totalTransation = 0;
                DateTime loopStart = until;
                until = AddDate(until, period);

                GetResult(loopStart, until, out decimal income, out decimal withdraw, out decimal interest);

                bool IsExistence = false;
                if (income > 0)
                {

                    total += income;
                    totalTransation += income;
                    virtualLogsConditionaly.Add(
                        new VirtualLogConditionaly()
                        {
                            Start = loopStart,
                            End = until,
                            accountLogType = AccountLogType.입금,
                            TotalTransaction = income,
                            Deposit = income,
                            Total = total,
                            Withdraw = 0,
                            Description="일반 입금"
                                                        
                        }
                    );
                    IsExistence = true;
                }

                if (withdraw > 0)
                {
                    total -= withdraw;
                    totalTransation += withdraw;

                    virtualLogsConditionaly.Add(
                        new VirtualLogConditionaly()
                        {
                            Start = loopStart,
                            End = until,
                            accountLogType = AccountLogType.출금,
                            TotalTransaction = withdraw,
                            Deposit = 0,
                            Total = total,
                            Withdraw = withdraw,
                            Description = "일반 출금"

                        }
                    );
                    IsExistence = true;
                }

                if (interest > 0)
                {
                    total += interest;
                    totalTransation += interest;

                    virtualLogsConditionaly.Add(
                        new VirtualLogConditionaly()
                        {
                            Start = loopStart,
                            End = until,
                            accountLogType = AccountLogType.입금,
                            TotalTransaction = interest,
                            Deposit = interest,
                            Total = total,
                            Withdraw = 0,
                            Description = "결산 이자"

                        }
                    );
                    IsExistence = true;
                }

                if (IsExistence)
                {
                    virtualLogsConditionaly.Add(
                            new VirtualLogConditionaly()
                            {

                                TotalTransaction = totalTransation,
                                Deposit = interest + income,
                                Withdraw = withdraw,
                                Description = "소계"

                            });
                }

                
                until = until.AddDays(1); //(period == Period.일단위 ? until : until.AddDays(1));

                if (until.CompareTo(end) > 0) break;
                
            }
        }


        private void GetResult(DateTime start, DateTime until, out decimal income, out decimal withdraw, out decimal interest)
        {
            var table = virtualLog
                            .Where((log) => start.CompareTo(log.DateTime.Date) <= 0 && log.DateTime.Date.CompareTo(until) <= 0);


            var value = table.Where((log) => !log.Description.Equals("이자"));


            income = value.Where((log) => log.AccountLogType == AccountLogType.입금)
                    .Select((log) => log.Amount).Sum();

            withdraw = value.Where((log) => log.AccountLogType == AccountLogType.출금)
                    .Select((log) => log.Amount).Sum();

            interest = table.Where((log) => log.Description.Equals("이자"))
                 .Select(log => log.Amount).Sum();

        }

        private DateTime AddDate(DateTime start, Period period)
        {

            if (period == Period.월단위)
            {

                DateTime dt = start.AddMonths(1);
                DateTime lastTime = start.AddMonths(1).AddDays(-dt.Day);

                return lastTime;

            }
            else
            {
                DateTime dt = new DateTime(start.Year, 12, 31);
                return dt;

            }
        }


        private void SetData(DataTable dt)
        {
            foreach (var item in virtualLogsConditionaly)
            {
                dt.Rows.Add(
                    item.Id,
                    item.Start,
                    item.End,
                    item.accountLogType,
                    PrettyValue(item.TotalTransaction),
                    PrettyValue(item.Deposit),
                    PrettyValue(item.Withdraw),
                    PrettyValue(item.Total),
                    item.Description);
            }

            foreach (DataGridViewRow row in dgv_virtualView.Rows)
            {
                if (row.Cells["비고"].Value != null && row.Cells["비고"].Value.ToString() == "소계")
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow; // 특정 데이터가 들어있는 행의 배경색을 노란색으로 변경
                }
            }
        }

        #endregion

        #region "가상 내역 세팅"
        private void SetVirtualLogResult(DataTable dt)
        {
            foreach (var item in virtualLog.OrderBy(log => log.DateTime))
            {
                dt.Rows.Add("sample", item.DateTime, item.AccountLogType, PrettyValue(item.Amount), PrettyValue(item.Total), item.Description);
            }

        }
        #endregion

        #region "최종 결과값 세팅"
        private void CombineResult()
        {// 근데 이 작업은 로그를 첨 더할때 하면되긴함 .. 굳이 이렇게 하면 성능이 떨어지는데 고민임
            // 근데 역할을 구분하는것도 맞긴함.
            var Get = virtualLog.Where((data) => data.AccountLogType.Equals(AccountLogType.입금));

            decimal? TotalInterest = Get.Where((data) => data.Description == "이자").Select((data) => data.Amount).Sum();
            decimal? TotalIncome = Get.Where((data) => data.Description != "이자").Select((data) => data.Amount).Sum();
            decimal? TotalWithdraw = virtualLog.Where((data) => data.AccountLogType.Equals(AccountLogType.출금)).Select((data) => data.Amount).Sum();
            decimal? TotalAmount = virtualLog.Last().Total;

            txt_View_Amount.Text = PrettyValue(TotalAmount);
            txt_View_income.Text = PrettyValue(TotalIncome);
            txt_View_interest.Text = PrettyValue(TotalInterest);
            txt_View_withdraw.Text = PrettyValue(TotalWithdraw);

        }

        #endregion

        #region "금액 이쁘게, 그리고 소숫점 올림"
        private string PrettyValue(decimal? value)
        {

            if (value == null) return null;
            return string.Format("{0:#,##0}", Math.Round((decimal)value, 0));
        }

        #endregion

        #region "확인"
        private void bt_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}

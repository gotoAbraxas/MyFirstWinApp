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
        private Account account; //계좌 하나만 세팅해둘 예정
        private AccountService service;
        public VirtualDto VirtualDto { get; set; }
        public List<VirtualLog> virtualLog { get; set; } = new List<VirtualLog>();

        public List<AfterPlan> afterPlans { get; set; } = new List<AfterPlan>();
        public List<VirtualLogConditionaly> virtualLogsConditionaly { get; set; } = new List<VirtualLogConditionaly>();

        public List<VirtualLogformally> VirtualLogsformally { get; set; } = new List<VirtualLogformally>();
        public Period period { get; set; }
        public ViewVirtualLog()
        {
            InitializeComponent();
        }

        private void ViewCounditionLog_Load(object sender, EventArgs e)
        {
            ServiceInit();
            
            CopyLog();

            AfterInit();

            DataTable dt = new DataTable();
            if (period == Period.내역)
            {
            AccountLogInit(dt);
            GetResult(dt);
            }
            else 
            {
            //AccountLogformallyInit(dt);

            AccountLogConditionInit(dt);
            GetResultConditionaly(dt);
            }

            CombineResult();

        }

        private void CombineResult()
        {// 근데 이 작업은 로그를 첨 더할때 하면되긴함 .. 굳이 이렇게 하면 성능이 떨어지는데 고민임

            var Get = virtualLog.Where((data) => data.AccountLogType.Equals(AccountLogType.입금));

            decimal? TotalInterest =  Get.Where((data) => data.Description =="이자").Select((data) => data.Amount).Sum();
            decimal? TotalIncome = Get.Where((data) => data.Description != "이자").Select((data) => data.Amount).Sum();
            decimal? TotalWithdraw = virtualLog.Where((data) => data.AccountLogType.Equals(AccountLogType.출금)).Select((data) => data.Amount).Sum();
            decimal? TotalAmount = virtualLog.Last().Total;

            txt_View_Amount.Text = PrettyValue(TotalAmount);
            txt_View_income.Text = PrettyValue(TotalIncome);
            txt_View_interest.Text = PrettyValue(TotalInterest);
            txt_View_withdraw.Text = PrettyValue(TotalWithdraw);
            
        }

        #region "서비스 세팅"
        private void ServiceInit()
        {
            service = new AccountService();

            this.account = service.SelectAccountById(VirtualDto.UserCode, VirtualDto.AccountId);
        }

        #endregion

        #region "금액 이쁘게, 그리고 소숫점 올림"
        private string PrettyValue(decimal? value)
        {

            if (value == null) return null;
            return string.Format("{0:#,##0}", Math.Round((decimal)value, 0));
        }

        #endregion

        #region "원본 내역 가져오기"
        private void AfterInit()
        {


            DateTime now = VirtualDto.Now;
            DateTime from = VirtualDto.From;
            DateTime until = VirtualDto.Until;


            decimal amount = account.Amount;
            decimal resultinterest = 0;
            decimal resultAmount = 0;
            decimal vResultInterest = 0;
            // 이 작업을 서비스에 정의 ? 아니면 ..
            //날짜 갭 차이에 대한 원금 변화 반영, 근데 이것도 비즈니스 로직으로 본다면.. 내부로 옮기고 서비스를 타는게 나을듯


            try
            {
                if (from.CompareTo(now) > 0)
                {
                    decimal vResultAmount = 0;

                    account.GetResult(ref amount, ref vResultInterest, ref vResultAmount, now, in from, virtualLog, afterPlans);
                }

                account.GetResult(ref amount, ref resultinterest, ref resultAmount, from, in until, virtualLog, afterPlans);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
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

        #region "가상 내역 세팅"
        private void GetResult(DataTable dt)
        {
            foreach (var item in virtualLog.OrderBy(log => log.DateTime))
            {
                dt.Rows.Add("sample", item.DateTime, item.AccountLogType, PrettyValue(item.Amount),PrettyValue(item.Total) ,item.Description);
            }

        }
        #endregion

        #region "조건에 맞는 검색"
        private void GetResultConditionaly(DataTable dt)
        {
            Calculate(VirtualDto.From, VirtualDto.From, VirtualDto.Until, period);

            SetData(dt);
        }

        private void Calculate(DateTime standard, DateTime start, DateTime end, Period period)
        {
            DateTime until = AddDate(start, period);

            decimal income = 0;
            decimal withdraw = 0;
            decimal interest = 0;
            decimal? total = null;
            GetResult(start, until, out income, out withdraw, out interest, out total);


            bool IsExistence = false;
            if (income > 0)
            {          
                VirtualLogsformally.Add(
                    new VirtualLogformally()
                    {
                        Start =start.ToShortDateString(),
                        End = until.ToShortDateString(),
                        Amount = income,
                        Description = "입금"
                    }
                );  
                IsExistence = true;
            }

            if (withdraw > 0)
            {         
                VirtualLogsformally.Add(
                    new VirtualLogformally()
                    {
                    Start = IsExistence ? "": start.ToShortDateString(),
                    End = IsExistence ? "": until.ToShortDateString(),
                    Amount = withdraw,
                    Description = "출금"
                    }
                );
                IsExistence = true;
            }

            if (interest > 0)
            {
                VirtualLogsformally.Add(
                   new VirtualLogformally()
                   {
                       Start = IsExistence ?"": start.ToShortDateString(),
                       End = IsExistence ? "":until.ToShortDateString(),
                       Amount = interest,
                       Description = "이자"
                   }
               );
                IsExistence = true;
            }

            virtualLogsConditionaly.Add(
                new VirtualLogConditionaly()
                {
                    Start = start,
                    End = until,
                    interest = interest,
                    Deposit = income,
                    Total = total,
                    Withdraw = withdraw
                }
            );

            if (IsExistence) 
            { 
            var last = VirtualLogsformally.Last();
            last.Total = total;
            }

            if (until.CompareTo(end) > 0) return;

            if(period == Period.일단위) // 아 이거 맘에 안든다.
            {
                Calculate(standard, until, end, period);
            }
            else
            {
                Calculate(standard, until.AddDays(1), end, period);

            }
        }

        private void GetResult(DateTime start, DateTime until, out decimal income, out decimal withdraw, out decimal interest, out decimal? total)
        {
            var table = virtualLog
                            .Where((log) => start.CompareTo(log.DateTime.Date) <= 0 && log.DateTime.Date.CompareTo(until) < 0);


            var value = table.Where((log) => !log.Description.Equals("이자"));


            income = value.Where((log) => log.AccountLogType == AccountLogType.입금)
                    .Select((log) => log.Amount).Sum();

            withdraw = value.Where((log) => log.AccountLogType == AccountLogType.출금)
                    .Select((log) => log.Amount).Sum();

            interest = table.Where((log) => log.Description.Equals("이자"))
                 .Select(log => log.Amount).Sum();
            // 여기서 에러 생길수도
            total = virtualLog
                .Where((log) => log.DateTime.Date.CompareTo(until) < 0)
                .OrderBy((log) => log.DateTime)
                .Select((log) => log.Total)
                .LastOrDefault();
        }

        private DateTime AddDate(DateTime start, Period period)
        {
            if (period == Period.일단위)
            {
                return start.AddDays(1);
            }
            else if (period == Period.월단위)
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
                    "sample",
                    item.Start,
                    item.End,
                    PrettyValue(item.Deposit),
                    PrettyValue(item.Withdraw),
                    PrettyValue(item.interest),
                    PrettyValue(item.Total),
                    item.Description);
            }
        }

        private void SetDataFormally(DataTable dt)
        {
            foreach (var item in VirtualLogsformally)
            {
                dt.Rows.Add(
                    "sample",
                    item.Start,
                    item.End,
                    PrettyValue(item.Amount),
                    PrettyValue(item.Total),
                    item.Description);
            }
        }

        #endregion


        #region "테이블 세팅"
        private void AccountLogInit(DataTable dt)
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

        private void AccountLogConditionInit(DataTable dt)
        {

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("From", typeof(DateTime));
            dt.Columns.Add("To", typeof(DateTime));
            dt.Columns.Add("입금 총액", typeof(string));
            dt.Columns.Add("출금 총액", typeof(string));
            dt.Columns.Add("이자 총액", typeof(string));
            dt.Columns.Add("거래후잔액", typeof(string));
            dt.Columns.Add("비고", typeof(string));

            dgv_virtualView.DataSource = dt;
            
            dgv_virtualView.DataBindingComplete += (sender, o) =>
            {
                dgv_virtualView.Columns["입금 총액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["출금 총액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["이자 총액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["거래후잔액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            };
            
        }

        private void AccountLogformallyInit(DataTable dt)
        {
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("From", typeof(string));
            dt.Columns.Add("To", typeof(string));
            dt.Columns.Add("금액", typeof(string));
            dt.Columns.Add("잔액", typeof(string));
            dt.Columns.Add("비고", typeof(string));

            dgv_virtualView.DataSource = dt;

            dgv_virtualView.DataBindingComplete += (sender, o) =>
            {
                dgv_virtualView.Columns["금액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["잔액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgv_virtualView.Columns["금액"].Width = 100;
                dgv_virtualView.Columns["잔액"].Width = 100;
                dgv_virtualView.Columns["id"].Width = 60;

            };
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewVirtualLog_Enter(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public List<VirtualLogConditionaly> virtualLogConditionalies { get; set; } = new List<VirtualLogConditionaly>();
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
            AccountLogConditionInit(dt);
            GetResultConditionaly(dt);
            }

            

        }

        #region "조건에 맞는 검색"
        private void GetResultConditionaly(DataTable dt)
        {
            Calculate(VirtualDto.From, VirtualDto.From,VirtualDto.Until,period);

            SetData(dt);
        }

        private void Calculate(DateTime standard,DateTime start,DateTime end,Period period)
        {
           DateTime until =  AddDate(start, period);

            decimal income = 0;
                
            income = virtualLog
                .Where((log) => start.CompareTo(log.DateTime.Date) <= 0 && log.DateTime.Date.CompareTo(until) < 0 && !log.Description.Equals("이자"))
                .Select((log) => log.Amount).Sum();


            decimal interest = 0;

           interest =  virtualLog
                .Where((log) => start.CompareTo(log.DateTime.Date) <= 0 && log.DateTime.Date.CompareTo(until) < 0 && log.Description.Equals("이자"))
                .Select(log => log.Amount).Sum();

            decimal total = virtualLog
                .Where((log) => (standard.CompareTo(log.DateTime.Date) <= 0) && (log.DateTime.Date.CompareTo(until) < 0))
                .OrderBy((log) => log.DateTime)
                .Select((log) => log.Total)
                .LastOrDefault();

            virtualLogConditionalies.Add(
                    new VirtualLogConditionaly()
                    {
                        Start = start,
                        End = until,
                        interest = interest,
                        Deposit = income,
                        Total = total,
                        Withdraw = 0
                    }
                );

            if (until.CompareTo(end) > 0) return;


            Calculate(standard, until, end, period);
        }

        private DateTime AddDate(DateTime start, Period period)
        {
            if (period == Period.일단위)
            {
                return start.AddDays(1);
            }
            else if (period == Period.월단위)
            {
                return start.AddMonths(1);
            }
            else
            {
                return start.AddYears(1);
            }
        }


        private void SetData(DataTable dt)
        {
            foreach (var item in virtualLogConditionalies)
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

        #endregion

        #region "금액 이쁘게, 그리고 소숫점 올림"
        private string PrettyValue(decimal value)
        {
            return string.Format("{0:#,##0}", Math.Round(value, 0));
        }

        #endregion

        #region "가상 내역 세팅"
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


        private void GetResult(DataTable dt)
        {
            foreach (var item in virtualLog.OrderBy(log => log.DateTime))
            {
                dt.Rows.Add("sample", item.DateTime, item.AccountLogType, PrettyValue(item.Amount),PrettyValue(item.Total) ,item.Description);
            }

        }

        private void ServiceInit()
        {
            service = new AccountService();

            this.account = service.SelectAccountById(VirtualDto.UserCode, VirtualDto.AccountId);
        }
        private void AccountLogConditionInit(DataTable dt)
        {

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("From", typeof(DateTime));
            dt.Columns.Add("To", typeof(DateTime));
            dt.Columns.Add("입금 총액", typeof(string));
            dt.Columns.Add("출금 총액", typeof(string));
            dt.Columns.Add("이자 총액", typeof(string));
            dt.Columns.Add("잔액", typeof(string));
            dt.Columns.Add("비고", typeof(string));

            dgv_virtualView.DataSource = dt;
            
            dgv_virtualView.DataBindingComplete += (sender, o) =>
            {
                dgv_virtualView.Columns["입금 총액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["출금 총액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["이자 총액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv_virtualView.Columns["잔액"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //dgv_virtualView.Columns["금액"].Width = 100;
                //dgv_virtualView.Columns["잔액"].Width = 100;
                //dgv_virtualView.Columns["입/출금"].Width = 70;
                //dgv_virtualView.Columns["날짜"].Width = 140;
                //dgv_virtualView.Columns["id"].Width = 60;
            };
            
        }

        private void AccountLogInit(DataTable dt)
        {
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("날짜", typeof(DateTime));
            dt.Columns.Add("입/출금", typeof(AccountLogType));
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
                dgv_virtualView.Columns["입/출금"].Width = 70;
                dgv_virtualView.Columns["날짜"].Width = 140;
                dgv_virtualView.Columns["id"].Width = 60;

            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewVirtualLog_Enter(object sender, EventArgs e)
        {

        }
    }
}

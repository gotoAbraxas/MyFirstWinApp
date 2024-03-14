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
        public Period period { get; set; }
        public ViewVirtualLog()
        {
            InitializeComponent();
        }

        private void ViewCounditionLog_Load(object sender, EventArgs e)
        {
            ServiceInit();

            DataTable dt = AccountLogInit();

            CopyLog();

            AfterInit();

            GetResult(dt);
        }

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
                    });
                }
            });
        }

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

            if (from.CompareTo(now) > 0)
            {
                decimal vResultAmount = 0;

                account.GetResult(ref amount, ref vResultInterest, ref vResultAmount, now, in from, virtualLog);
            }

            account.GetResult(ref amount, ref resultinterest, ref resultAmount, from, in until, virtualLog);

        }


        private void GetResult(DataTable dt)
        {
            foreach (var item in virtualLog.OrderBy(log => log.DateTime))
            {
                dt.Rows.Add("sample", item.DateTime, item.AccountLogType, string.Format("{0:#,##0}", item.Amount),string.Format("{0:#,##0}", item.Total) ,item.Description);
            }

        }

        private void ServiceInit()
        {
            service = new AccountService();

            this.account = service.SelectAccountById(VirtualDto.UserCode, VirtualDto.AccountId);
        }

        private DataTable AccountLogInit()
        {
            DataTable dt = new DataTable();

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

            return dt;
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

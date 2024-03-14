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
        public List<VirtualLog> virtualLog { get; set; }
        public Period period { get; set; }
        public ViewVirtualLog()
        {
            InitializeComponent();
        }

        private void ViewCounditionLog_Load(object sender, EventArgs e)
        {
            ServiceInit();

            AccountLogInit();

            AfterInit();
            GetResult();
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

                account.GetResult(ref amount, ref vResultInterest, ref vResultAmount, now, in from);
            }

            account.GetResult(ref amount, ref resultinterest, ref resultAmount, from, in until);

            MessageBox.Show(
                $"쌓인 이자 {Math.Round(resultinterest, 0)} " +
                $"\n선택 기간 외 쌓였던 이자 {Math.Round(vResultInterest, 0)}" +
                $"\n최종 금액 {Math.Round(resultAmount + vResultInterest, 0)}");

        }








        private void GetResult()
        {
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
            dt.Columns.Add("금액", typeof(decimal));
            dt.Columns.Add("비고", typeof(string));



            dgv_virtualView.DataSource = dt;

            return dt;
        }
    }
}

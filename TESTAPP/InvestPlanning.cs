using System;
using System.Collections.Concurrent;
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

namespace TESTAPP
{
    public partial class InvestPlanning : Form
    {

        private AccountService accountService;
        private List<Account> accounts;

        private List<DateTime> InterestDays = new List<DateTime>();
        public decimal Amounts { get; set; }
        public int Period { get; set; }
        public List<long> AccountIds { get; set; }
        public InvestPlanning()
        {

            InitializeComponent();
        }

        private void InvestPlanning_Load(object sender, EventArgs e)
        {
            ServiceInit();
            GetAccountList(); // 계산할 리스트 가져오기
            GetBeginningInterestDays(); // 이자가 나오는 초기 날짜
            DesideInvestPlan();         // 여기서 처음에 어디에 투자할지가 나와야함.
                                        // 여기선 이후 동적 계획법.
                                        // 테이블 세팅
                                        // 인쇄.
        }

        private void ServiceInit()
        {
            accountService = new AccountService();

        }

        private void GetAccountList()
        {
            accounts = accountService.GetAccountByIds(1L, AccountIds);
            // 일단 여까진 옴 ... 
        }

        // 돌리기
        private void Test(DateTime from,DateTime end)
        {
            DateTime until = from;
            DateTime start;
            do
            {
                start = until;
                until = until.AddDays(1);

                // 금액 변화 살펴보기

                // 변화가 있다면(이자를 받았다면)

                //

            }
            while (until.CompareTo(end) > 0);
        }



        private void DesideInvestPlan()
        {

        }

        // 이자가 나오는 초기 날짜를 미리 계산해서 가져온다.
        private void GetBeginningInterestDays()
        {
            List<Task> tasks = new List<Task>();

            DateTime now = DateTime.Now.Date;
            DateTime until = now.AddMonths(Period);
            
            foreach (Account item in accounts)
            {

                Account currentItem = item;
                DateTime itemNow = now;
                DateTime itemUntil = until;
                var task = new Task(() => ExtractInterestDays(currentItem, itemNow, itemUntil));

                tasks.Add(task);
                task.Start();
            }
            
            Task.WaitAll(tasks.ToArray());

            InterestDays = InterestDays.OrderBy((item)=>item).ToList();

            // 일단 여기까지 한 것 . 금액이 변동되는 날짜를 가져왔음
            // 이게 1차적인 루프가 될 예정임.

        }

        private void ExtractInterestDays(Account account, DateTime start, DateTime end)
        {
            DateTime loop = start;

            while (loop.CompareTo(end) <= 0)
            {
                loop = account.GetNextInterestDate(loop);
                DateTime result = VoidWeekend(loop);

                if (InterestDays.Contains(result)) continue;

                lock(this) // 근데 이렇게 할 바에야 ... 그냥 돌려버리는게 ....???????
                {
                    InterestDays.Add(result);
                }
            }
        }

        private DateTime VoidWeekend(DateTime time)
        {
            if (time.DayOfWeek == DayOfWeek.Sunday) return time.AddDays(1);
            if (time.DayOfWeek == DayOfWeek.Saturday) return time.AddDays(2);
            return time;

        }


    }
}

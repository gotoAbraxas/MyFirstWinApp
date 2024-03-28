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
using TESTAPP.domain.account.sub;

namespace TESTAPP
{
    public struct AccountDetailData
    {  
        public long AccountId { get; set; }
        public int AmountConditionNumber { get; set; }
        public int PeriodConditionNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal Score { get; set; }

    }

    // 쓰레기 코드 .. 유지보수 너무 힘들거같음.
    // 내 생각엔 account 의 속성에 절대 의존하면 안됨.
    // 지금 이거 약간 맘에 안듬.. 전반적으로 재구성하고싶은 욕심이 생기는데 .../
    // 가장 먼저 해야할일은 비즈니스 코드를 한곳에 몰아 넣고 그것을 외부로 어떻게 빼줄지에 대한 고민임.
    // 지금은 너무 구체적인 모델에 의존하고 있음.
    // 이렇게 구성하면 어카운트에 뭘 추가하고 싶어도 할 수 가 없음 ..

    public partial class InvestPlanning : Form
    {
        private Dictionary<long, List<AccountDetailData>> AccountDataDictionary = new Dictionary<long, List<AccountDetailData>>();

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

            MessageBox.Show("1");
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
            accounts.ForEach(account => SetAccountScores(account));
        }


        private void SetAccountScores(Account account)
        {
            account.AmountConditions = account.AmountConditions.OrderBy((item)=>item.StartValue).ToList();
            account.PeriodConditions = account.PeriodConditions.OrderBy((item) => item.StartValue* Multiply(item.StartDateType)).ToList();

            int amountCount = account.AmountConditions.Count;
            int PeriodCount = account.PeriodConditions.Count;

           
            for (int amountCondition = -1; amountCondition < amountCount; amountCondition++)
            {
                for (int periodCondition = -1; periodCondition < PeriodCount; periodCondition++)
                {
                    SetScores(account, amountCondition, periodCondition,Amounts,Period);

                }
            }
           
        }

        
        private int Multiply(SettlePeriodType startDateType)
        {
            switch (startDateType)
            {
                case SettlePeriodType.일: return 1;
                case SettlePeriodType.개월: return 30;
                case SettlePeriodType.년: return 365;
                default: return 30;
            }
        }

        private void SetScores(Account account, int amountCondition, int peridCondition, decimal restAmount, int restDate)
        {
            AccountDetailData data = CalulateScore(account, amountCondition, peridCondition,restAmount,restDate);
            
            InsertScore(account, data);

        }


        private AccountDetailData CalulateScore(Account account, int amountCondition, int peridCondition,decimal restAmount,int restDate)
        {
            decimal score = account.Interest;
            if (amountCondition != -1)
            {
                var condition  = account.AmountConditions.ElementAt(amountCondition);

                if(condition.StartValue < restAmount)
                {
                    score += account.AmountConditions.ElementAt(amountCondition).ChangedValue;
                }
            };

            if (peridCondition != -1)
            {   int total = (restDate * Multiply(SettlePeriodType.개월));
                int section = account.SettlePeriod * Multiply(account.SettlePeriodType);

                var condition = account.PeriodConditions.ElementAt(peridCondition);
               
                if (section < total)
                {
                    int count = section / total;

                    score  += condition.ChangedValue * (total - condition.StartValue * Multiply(condition.StartDateType)) / total;
                }
            }

            // 여기까진 포멀한 조건이었음 . 이제는 정말 얘가 이자를 몇번 받을 수 있는지를 알아야함.


            var data = new AccountDetailData()
            {
                AccountId = account.AccountId,
                AmountConditionNumber = amountCondition,
                PeriodConditionNumber = peridCondition,
                Score = score
            };
            return data;
        }

        private void InsertScore(Account account, AccountDetailData data)
        {
            if (AccountDataDictionary.TryGetValue(account.AccountId, out List<AccountDetailData> date))
            {
                date.Add(data);
            }
            else
            {
                var tmp = new List<AccountDetailData>
                {
                    data
                };
                AccountDataDictionary.Add(account.AccountId, tmp);
            }
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
            List<DateTime> tmp = new List<DateTime>();
            while (loop.CompareTo(end) <= 0)
            { 
                loop = account.GetNextInterestDate(loop);
                DateTime result = VoidWeekend(loop);
                tmp.Add(result);
            }
            lock(this)
            {
                foreach (DateTime item in tmp)
                {
                    if (InterestDays.Contains(item)) continue;
                    InterestDays.Add(item);
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

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

        private Dictionary<long,List<VirtualLog>> Accountslog = new Dictionary<long, List<VirtualLog>>();

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
            var accounts = GetAccountList(AccountIds); // 계산할 리스트 가져오기

            SetAccountslog(accounts);
            GetBeginningInterestDays(accounts); // 이자가 나오는 초기 날짜
            InitAccountScores(accounts);         // 여기서 처음에 어디에 투자할지가 나와야함.
            Invest(accounts);                    // 여기선 이후 동적 계획법.
                                            // 테이블 세팅
                                         // 인쇄.
        }

        private void SetAccountslog(List<Account> accounts)
        {
            accounts.ForEach(item => Accountslog.Add(item.AccountId, new List<VirtualLog>()));
        }

        private void ServiceInit()
        {
            accountService = new AccountService();

        }

        private List<Account> GetAccountList(List<long> AccountIds)
        {
            return accountService.GetAccountByIds(1L, AccountIds);
            // 일단 여까진 옴 ... 
        }

        private void Invest(List<Account> accounts)
        {

            decimal restAmount = Amounts;

            DateTime now = DateTime.Now.Date;
            List<AccountDetailData> accountsDetailData = GetAccountsByPriority();

            long nowAccount = 0;

            foreach (AccountDetailData data in accountsDetailData)
            {
                DateTime until = now.AddMonths(Period);

                if (nowAccount == data.AccountId || restAmount <= 0) continue;
                nowAccount = data.AccountId;

                Account ac = accounts.Where(account => account.AccountId == data.AccountId).First();

                decimal consume = ApplyAmountCondition(restAmount, data, ac);

                until = ApplyPeriodCondition(data,until, ac);

                Accountslog.TryGetValue(data.AccountId, out List<VirtualLog> value);

                value.Add(new VirtualLog()
                {
                    AccountLogType = AccountLogType.입금,
                    Amount = consume,
                    DateTime = now,
                    Total = consume,
                    Description = "입금"
                });



                //accountService.Deposit(1L, item.AccountId, consume, log);
                // 이건 좀 고민해보자...

                var datas = new AccountVirtuallogDto()
                {
                    AccountId = data.AccountId,
                    UserCode = 1L,
                    Amount = consume,
                    AfterPlans = new List<AfterPlan>(),
                    loopInterest = 0,
                    ResultAmount = 0,
                    Log = value
                };

                ac.GetResult(datas, now, until);
                restAmount = restAmount - consume;
            }

            MessageBox.Show("1");

        }

        private DateTime ApplyPeriodCondition(AccountDetailData data, DateTime until, Account ac)
        {
            if (data.PeriodConditionNumber == -1) return until;

            var periodCondition = ac.PeriodConditions.ElementAt(data.PeriodConditionNumber);

            DateTime currentDate = DateTime.Now.Date;
            DateTime expiredTime = ac.GetNextPeriodDate(currentDate, periodCondition.EndDateType, periodCondition.EndValue).Date;

            while (expiredTime >= currentDate)
            {
                currentDate = ac.GetNextPeriodDate(currentDate, ac.SettlePeriodType, ac.SettlePeriod).Date;
            }
            DateTime end = currentDate.AddDays(1);

            return until.CompareTo(end) >= 0 ? end : until.AddDays(1);
        }

        private decimal ApplyAmountCondition(decimal amount, AccountDetailData item, Account ac)
        {
            if (item.AmountConditionNumber != -1)
            {
                decimal limitAmount = ac.AmountConditions.ElementAtOrDefault(item.AmountConditionNumber).EndValue;
                return Math.Min(limitAmount, amount);
            }

            return amount;
        }

        private List<AccountDetailData> GetAccountsByPriority()
        {
            List<AccountDetailData> tmp = new List<AccountDetailData>();

            foreach (var item in AccountDataDictionary.Values)
            {

                item.ForEach(x => tmp.Add(x));

            }
            tmp = tmp.OrderByDescending(x => x.Score)
                .ThenBy(x => x.AmountConditionNumber)
                .ThenBy(x => x.PeriodConditionNumber)
                .ToList();
            return tmp;
        }

        private void InitAccountScores(List<Account> accounts)
        {
            accounts.ForEach(account => SetAccountScores(account));
        }


        private void SetAccountScores(Account account)
        {
            account.AmountConditions = account.AmountConditions.OrderBy((item)=>item.StartValue).ToList();
            account.PeriodConditions = account.PeriodConditions.OrderBy((item) => item.StartValue* ConvertDate(item.StartDateType)).ToList();

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

        private int ConvertDate(SettlePeriodType startDateType)
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
            decimal score = 0;

            DateTime now = DateTime.Now.Date;
            DateTime after = now.AddDays(restDate);

            int dd = (after - now).Days;

            int total = (restDate * ConvertDate(SettlePeriodType.개월));
            int section = account.SettlePeriod * ConvertDate(account.SettlePeriodType);

            if (section <= total)
            {
                score = account.Interest;
                int count = total /section;
                double unit = (double)section / ConvertDate(SettlePeriodType.년);
                if (amountCondition != -1)
                {
                    var condition  = account.AmountConditions.ElementAt(amountCondition);

                    if(condition.StartValue <= restAmount)
                    {
                        score += account.AmountConditions.ElementAt(amountCondition).ChangedValue;
                    }
                };

                if (peridCondition != -1)
                {
                    var condition = account.PeriodConditions.ElementAt(peridCondition);  
                    score  += condition.ChangedValue * (total - condition.StartValue * ConvertDate(condition.StartDateType)) / total;
                }

                score *= (decimal)(count * unit);
            }

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
        private void GetBeginningInterestDays(List<Account> accounts)
        {
            List<Task> tasks = new List<Task>();

            DateTime now = DateTime.Now.Date;
            DateTime until = now.AddMonths(Period);
            
            foreach (Account item in accounts)
            {

                Account currentItem = item;
                DateTime itemNow = now;
                DateTime itemUntil = until;
                var task = new Task(() =>
                {
                    var result = ExtractInterestDays(currentItem, itemNow, itemUntil);
                    InsertInterestDays(result);
                });

                tasks.Add(task);
                task.Start();
            }
            
            Task.WaitAll(tasks.ToArray());

            InterestDays = InterestDays.OrderBy((item)=>item).ToList();

            // 일단 여기까지 한 것 . 금액이 변동되는 날짜를 가져왔음
            // 이게 1차적인 루프가 될 예정임.

        }

        private void InsertInterestDays(List<DateTime> result)
        {
            lock (this)
            {
                foreach (DateTime item in result)
                {
                    if (InterestDays.Contains(item)) continue;
                    InterestDays.Add(item);
                }
            }
        }

        private List<DateTime> ExtractInterestDays(Account account, DateTime start, DateTime end)
        {
            DateTime loop = start;
            List<DateTime> tmp = new List<DateTime>();
            while (loop.CompareTo(end) <= 0)
            { 
                loop = account.GetNextPeriodDate(loop,account.SettlePeriodType,account.SettlePeriod);
                DateTime result = VoidWeekend(loop);
                tmp.Add(result);
            }

            return tmp;
        }

        private DateTime VoidWeekend(DateTime time)
        {
            if (time.DayOfWeek == DayOfWeek.Sunday) return time.AddDays(1);
            if (time.DayOfWeek == DayOfWeek.Saturday) return time.AddDays(2);
            return time;

        }


    }
}

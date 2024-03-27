using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TESTAPP.domain.account.iFace;
using TESTAPP.domain.account.sub;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static TESTAPP.common.component.Dynamic;

namespace TESTAPP.domain.account
{
    // 이건 나중에 써볼 수 있을듯
    delegate void InterestCalculater(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount,  List<VirtualLog> log, List<AfterPlan> afterPlans, DateTime start, DateTime end);
    enum SettleType
    {
        단리,
        복리
    }

    enum SettlePeriodType
    {
        일,
        개월,
        년
    }
    public class AccountVirtuallogDto // 나중에 쓰자...
    {

        public bool Insert {  get; set; }
        public decimal Amount { get; set; }
        public decimal ResultInterest { get; set; }
        public decimal ResultAmount { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<VirtualLog> Log { get; set; }
        public List<AfterPlan> AfterPlans { get; set; }
    }


    internal class Account : IAccount
    {
        #region "생성자"
        
        public Account() { }

        #endregion

        #region "속성"
        public long AccountId { get; set; } // 나중에 guid

        public long UserCode { get; set; } // 유저 코드 식별자
        public string Name { get; set; } // 계좌 이름
        public string Name_AccountId { get; set; } // 최종 식별 코드 // 아 이거 좀 번거롭네.. 
        public decimal Interest {  get; set; } // 이율
        public decimal Amount { get; set; } = 0; // 통장잔액
        public List<AccountLog> Log { get; set; } = new List<AccountLog>(); // 거래 기록

        public List<AmountConditionOfInterest> AmountConditions { get; set; } // 
        public List<PeriodConditionOfInterest> PeriodConditions { get; set; }
        public SettleType SettleType { get; set; } // 정산 타입
        public int SettlePeriod { get; set; } // 정산 주기

        
        public SettlePeriodType SettlePeriodType { get; set; } // 정산 단위

        public bool CheckUpperLimitWellInterest { get; set; } // 
        public decimal UpperLimitWellInterest { get; set; } // 우대금리 최대 금액 기본 null
        public bool ProtectAccount { get; set; }

        #endregion

        #region "메서드"

        public void AddLog(AccountLog log)
        {
            this.Log.Insert(log.Id, log);
        }


        public void GetResult(ref decimal amount,ref decimal resultInterest,ref decimal resultAmount,DateTime start,in DateTime end,List<VirtualLog> log,in List<AfterPlan> afterPlans)
        {

            InterestCalculater loof;

            switch (SettleType)
            {
                case SettleType.단리:
                    loof = SimpleLoof;
                    break;
                case SettleType.복리:
                    loof = CompoundLoof;
                    break;
                default:
                    loof = SimpleLoof;
                    break;
            }

            CalculateInterest(ref amount, ref resultInterest, ref resultAmount, start, end, log, afterPlans, loof);
        }

        private void CompoundInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start, DateTime end, List<VirtualLog> log, List<AfterPlan> afterPlans)
        {
            DateTime until = start;

            decimal result = amount;
            resultAmount = amount;
            while (until.CompareTo(end) < 0)
            {

                DateTime loopStart = until;
                until = GetNextDate(until);

                if (until.CompareTo(end) >= 0)
                {
                    ReflectAfterPlan(amount, loopStart, end, log, afterPlans, resultInterest);
                    break; // 루프 종료
                }

                CompoundLoof(ref result, ref resultInterest, ref resultAmount, log, afterPlans, loopStart, until);

                if(resultInterest > 0)
                {
                    log.Add(new VirtualLog()
                    {
                        AccountLogType = AccountLogType.입금,
                        DateTime = VoidWeekend(until),
                        Description = "이자",
                        Amount = resultInterest,
                        Total = resultAmount
                    });
                }
            }
        }


        private void CompoundLoof(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, List<VirtualLog> log, List<AfterPlan> afterPlans, DateTime loopStart, DateTime until)
        {
            resultInterest = 0;
            DateTime start = loopStart;
            // 초기화
            do
            {
                DateTime standard = loopStart;

                loopStart = loopStart.AddDays(1);
   
                decimal changedInterest = Interest;

                // amount = 실제 금액, virtualAmount = 기간이 반영된 상태
                amount = ReflectAfterPlan(amount, standard, loopStart, log, afterPlans, resultInterest);

                if (standard.DayOfWeek == DayOfWeek.Sunday || standard.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (loopStart.CompareTo(until) >= 0)
                    {
                        amount += resultInterest;
                    }
                    continue;
                }

                changedInterest += GetResultAmountCondition(amount); // 조건에 맞게 추가할 이자
                changedInterest += GetResultPeriodCondition(standard); // 조건에 맞게 추가할 이자. 계산을 시작한 시점부터 얼마나 떨어졌는가.

                const int weekdayOfyear = 260 ;
                int day = GetWeekday(start, until);
                decimal convertValue = ConvertInterest(SettleType, changedInterest.ToString(), (double)day, weekdayOfyear) / day;
                decimal thisTimeInterest = GetResultInterestAmount(amount, convertValue);
                resultInterest += thisTimeInterest;

                resultAmount  += thisTimeInterest;

                if (loopStart.CompareTo(until) >= 0)
                {
                    amount += resultInterest;
                    break;
                }

            } while (loopStart.CompareTo(until) < 0);

        }

        private void SimpleInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start, DateTime end, List<VirtualLog> log, List<AfterPlan> afterPlans)
        {
            DateTime until = start;

            decimal result = amount;
            resultAmount = amount;

            while (until.CompareTo(end) < 0)
            {

                DateTime loopStart = until;
                until = GetNextDate(until);

                if (until.CompareTo(end) >= 0)
                {
                    ReflectAfterPlan(amount, loopStart, end, log, afterPlans, resultInterest);
                    break; // 루프 종료
                }

                // 이걸 만약에 db로 옮긴다면 ?? 쉽지 않을듯
                SimpleLoof(ref result, ref resultInterest, ref resultAmount, log, afterPlans, loopStart, until);

                if (resultInterest > 0)
                {
                    log.Add(new VirtualLog()
                    {
                        AccountLogType = AccountLogType.입금,
                        DateTime = VoidWeekend(until),
                        Description = "이자",
                        Amount = resultInterest,
                        Total = resultAmount
                    });
                }
            }
        }

        private void SimpleLoof(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, List<VirtualLog> log, List<AfterPlan> afterPlans, DateTime loopStart, DateTime until)
        {
            resultInterest = 0;
            DateTime start = loopStart;
            // 초기화
            do
            {
                DateTime standard = loopStart;

                loopStart = loopStart.AddDays(1);

                decimal changedInterest = Interest;

                amount = ReflectAfterPlan(amount, standard, loopStart, log, afterPlans, resultInterest);

                if (standard.DayOfWeek == DayOfWeek.Sunday || standard.DayOfWeek == DayOfWeek.Saturday)
                {
                    continue;
                }

                changedInterest += GetResultAmountCondition(amount); // 조건에 맞게 추가할 이자
                changedInterest += GetResultPeriodCondition(standard); // 조건에 맞게 추가할 이자. 계산을 시작한 시점부터 얼마나 떨어졌는가.

                const int weekdayOfyear = 260;
                int day = GetWeekday(start, until);
                decimal convertValue = ConvertInterest(SettleType, changedInterest.ToString(), (double)day, weekdayOfyear) / day;

                decimal thisTimeInterest = GetResultInterestAmount(amount, convertValue);

                resultInterest += thisTimeInterest;

                resultAmount += thisTimeInterest;

                if (loopStart.CompareTo(until) >= 0)
                {
                    break;
                }

            } while (loopStart.CompareTo(until) < 0);

        }

        private void CalculateInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start, DateTime end, List<VirtualLog> log, List<AfterPlan> afterPlans, InterestCalculater GetInterestResult)
        {
            DateTime until = start;

            decimal result = amount;
            resultAmount = amount;

            // 이게 각 회차별 루프
            while (until.CompareTo(end) < 0)
            {
                DateTime loopStart = until;
                until = GetNextDate(until);

                if (until.CompareTo(end) >= 0)
                {
                    ReflectAfterPlan(amount, loopStart, end, log, afterPlans, resultInterest);
                    break; // 루프 종료
                }
                // 이건 각 기간을 평일 기준으로 이자 쌓는 로직
                GetInterestResult(ref result, ref resultInterest, ref resultAmount, log, afterPlans, loopStart, until);

                if (resultInterest > 0)
                {
                    log.Add(new VirtualLog()
                    {
                        AccountLogType = AccountLogType.입금,
                        DateTime = VoidWeekend(until),
                        Description = "이자",
                        Amount = resultInterest,
                        Total = resultAmount
                    });
                }
            }
        }

        private DateTime VoidWeekend(DateTime time)
        {
            if (time.DayOfWeek == DayOfWeek.Sunday) return time.AddDays(1);
            if (time.DayOfWeek == DayOfWeek.Saturday) return time.AddDays(2);
            return time;

        }

        private int GetWeekday(DateTime start, DateTime until)
        {

            int totalDays = (until - start).Days; // 전체 요일
            int days = (totalDays / 7) * 5; //평일  
            int remainingDays = totalDays % 7; // 남은 요일

            // 나머지가 1부터 5까지인 경우 평일로 간주하여 카운트
            // 여기서 만약 주말이 껴있는 경우는 오차로 넘김
            int weekdays = remainingDays <= 5 ? remainingDays : 5;
            return days + weekdays;
        }

        private DateTime GetNextDate(DateTime dt)
        {

            if (SettlePeriodType == SettlePeriodType.일)
            {
                return dt.AddDays(SettlePeriod);
            }
            else if (SettlePeriodType == SettlePeriodType.개월)
            {
                return dt.AddMonths(SettlePeriod);
            }
            else if (SettlePeriodType == SettlePeriodType.년)
            {
                return dt.AddYears(SettlePeriod);
            }
            return dt;
        }
        private decimal ReflectAfterPlan(decimal amount, DateTime start, DateTime end, List<VirtualLog> log, List<AfterPlan> afterPlans,decimal resultInterest)
        {
            var ac = afterPlans
                .Where((item) => (start.CompareTo(item.DateTime) <= 0) && (item.DateTime.CompareTo(end) < 0))
                .OrderBy((item)=>item.DateTime).ToList();

            foreach (var afterPlan in ac)
            {
                decimal amountChange;
                if (afterPlan.AccountLogType == AccountLogType.입금)
                {
                    amountChange = afterPlan.Amount;
                }
                else if (afterPlan.AccountLogType == AccountLogType.출금)
                {
                    amountChange = -afterPlan.Amount;
                }
                else
                {
                    throw new ArgumentException("Unexpected AccountLogType");
                }

                amount += amountChange;

                if (amount < 0)
                {
                    throw new Exception("잔액이 0 이하로 되는 경우가 존재합니다.");
                }

                log.Add(new VirtualLog
                {
                    AccountLogType = afterPlan.AccountLogType,
                    DateTime = afterPlan.DateTime,
                    Description = afterPlan.Description,
                    Amount = afterPlan.Amount,
                    Total = amount + resultInterest
                });
            }
            return amount;
        }


        private decimal GetResultPeriodCondition(DateTime start)
        {
            DateTime now = DateTime.Now.Date;
            decimal result = 0;
            List<decimal> resultPeriodConditions = PeriodConditions
                                    .Where((condition) => condition.CompareDateEnter(start,now) &&condition.CompareDatePass(start,now)  && condition.Applyed)
                                    .Select((condition) => condition.ChangedValue).ToList();

            foreach (decimal item in resultPeriodConditions)
            {
                result += item;
            }

            return result;
        }

        private decimal GetResultAmountCondition(decimal tmp)
        {
            decimal result = 0;

            List<decimal> resultAmountConditions = AmountConditions
                         .Where((condition) => condition.StartValue <= tmp&& tmp < condition.EndValue && condition.Applyed)
                         .Select((condition) => condition.ChangedValue).ToList();

            foreach (decimal item in resultAmountConditions)
            {
                result += item;
            } // 지금 적용될 이윤

            return result;
        }
        private decimal GetResultInterestAmount(decimal amount, decimal changedInterest)
        {
            decimal resultInterest;

            if (CheckUpperLimitWellInterest && amount > UpperLimitWellInterest)
            {

                decimal rest = amount - UpperLimitWellInterest;
                decimal standardInterest = (UpperLimitWellInterest * changedInterest);
                decimal restInterest = rest * Interest;

                resultInterest = (standardInterest + restInterest);
            }
            else
            {
                resultInterest = (amount * changedInterest);
            }

            return resultInterest;
        }

        #endregion


    }
}

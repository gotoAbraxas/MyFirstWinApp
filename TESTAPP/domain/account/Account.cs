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
    delegate void InterestCalculater(AccountVirtuallogDto dto, DateTime start, DateTime end);
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
    public class AccountVirtuallogDto
    {
        public long AccountId { get; set; }

        public long UserCode { get; set; }
        public bool Insert {  get; set; }
        public decimal Amount { get; set; }
        public decimal loopInterest { get; set; }
        public decimal ResultAmount { get; set; }
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
        public decimal UpperLimitWellInterest { get; set; } // 우대금리 최대 금액
        public bool ProtectAccount { get; set; }

        #endregion

        #region "메서드"

        public void AddLog(AccountLog log)
        {
            this.Log.Insert(log.Id, log);
        }


        public void GetResult(AccountVirtuallogDto dto,DateTime start,DateTime end)
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

            CalculateInterest(dto, start, end, loof);
        }

        private void CompoundLoof(AccountVirtuallogDto dto, DateTime loopStart, DateTime until)
        {
            dto.loopInterest = 0;
            DateTime start = loopStart;
            do
            {
                DateTime standard = loopStart;

                loopStart = loopStart.AddDays(1);
   
                decimal changedInterest = Interest;

                // amount = 실제 금액, virtualAmount = 기간이 반영된 상태
                dto.Amount = ReflectAfterPlan(dto.Amount, standard, loopStart, dto.Log, dto.AfterPlans, dto.loopInterest);

                if (standard.DayOfWeek == DayOfWeek.Sunday || standard.DayOfWeek == DayOfWeek.Saturday)
                {
                    if (loopStart.CompareTo(until) >= 0)
                    {
                        dto.Amount += dto.loopInterest;
                    }
                    continue;
                }

                changedInterest += GetResultAmountCondition(dto.Amount); // 조건에 맞게 추가할 이자
                changedInterest += GetResultPeriodCondition(standard); // 조건에 맞게 추가할 이자. 계산을 시작한 시점부터 얼마나 떨어졌는가.

                const int weekdayOfyear = 260 ;
                 //int day = GetWeekday(start, until); // 이건 잠시 보류. 안쓰게될듯.
                decimal convertChangedInterest = ConvertInterest(SettleType, changedInterest.ToString(), (double)1.0, weekdayOfyear);
                decimal convertInterest = ConvertInterest(SettleType, Interest.ToString(), (double)1.0, weekdayOfyear);
                decimal thisTimeInterest = GetResultInterestAmount(dto.Amount, convertChangedInterest, convertInterest);
                dto.loopInterest += thisTimeInterest;

                dto.ResultAmount  += thisTimeInterest;

                if (loopStart.CompareTo(until) >= 0)
                {
                    dto.Amount += dto.loopInterest;
                    break;
                }

            } while (loopStart.CompareTo(until) < 0);

        }


        private void SimpleLoof(AccountVirtuallogDto dto, DateTime loopStart, DateTime until)
        {
            dto.loopInterest = 0;
            DateTime start = loopStart;
            // 초기화
            do
            {
                DateTime standard = loopStart;

                loopStart = loopStart.AddDays(1);

                decimal changedInterest = Interest;

                dto.Amount = ReflectAfterPlan(dto.Amount, standard, loopStart, dto.Log, dto.AfterPlans, dto.loopInterest);

                if (standard.DayOfWeek == DayOfWeek.Sunday || standard.DayOfWeek == DayOfWeek.Saturday)
                {
                    continue;
                }

                changedInterest += GetResultAmountCondition(dto.Amount); // 조건에 맞게 추가할 이자
                changedInterest += GetResultPeriodCondition(standard); // 조건에 맞게 추가할 이자. 계산을 시작한 시점부터 얼마나 떨어졌는가.

                const int weekdayOfyear = 260;
                int day = GetWeekday(start, until);
                decimal convertChangedInterest = ConvertInterest(SettleType, changedInterest.ToString(), (double)day, weekdayOfyear) / day;
                decimal convertInterest = ConvertInterest(SettleType, Interest.ToString(), (double)1.0, weekdayOfyear);
                decimal thisTimeInterest = GetResultInterestAmount(dto.Amount, convertChangedInterest, convertInterest);

                dto.loopInterest += thisTimeInterest;

                dto.ResultAmount += thisTimeInterest;

                if (loopStart.CompareTo(until) >= 0)
                {
                    break;
                }

            } while (loopStart.CompareTo(until) < 0);

        }

        private void CalculateInterest(AccountVirtuallogDto dto ,DateTime start,DateTime end, InterestCalculater GetInterestResult)
        {
            DateTime until = start;

            decimal result = dto.Amount;
            dto.ResultAmount = dto.Amount;

            // 이게 각 회차별 루프
            while (until.CompareTo(end) < 0)
            {
                DateTime loopStart = until;
                until = GetNextPeriodDate(until,SettlePeriodType,SettlePeriod);

                if (until.CompareTo(end) >= 0)
                {
                    ReflectAfterPlan(dto.Amount, loopStart, end, dto.Log, dto.AfterPlans, dto.loopInterest);
                    break; // 루프 종료
                }
                // 이건 각 기간을 평일 기준으로 이자 쌓는 로직
                GetInterestResult(dto, loopStart, until);

                if (dto.loopInterest > 0)
                {
                    dto.Log.Add(new VirtualLog()
                    {
                        AccountLogType = AccountLogType.입금,
                        DateTime = VoidWeekend(until),
                        Description = "이자",
                        Amount = dto.loopInterest,
                        Total = dto.ResultAmount
                    });
                }
            }
        }

        private DateTime VoidWeekend(DateTime time)
        {
            if (time.DayOfWeek == DayOfWeek.Sunday) return time.AddDays(1);
            if (time.DayOfWeek == DayOfWeek.Saturday) return time.AddDays(2);
            return time;

        } // 얘는 여기 있을애가 아닌긴 한데.....

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

        public DateTime GetNextPeriodDate(DateTime dt,SettlePeriodType type,int settlePeriod)
        {

            if (type == SettlePeriodType.일)
            {
                return dt.AddDays(settlePeriod);
            }
            else if (type == SettlePeriodType.개월)
            {
                return dt.AddMonths(settlePeriod);
            }
            else if (type == SettlePeriodType.년)
            {
                return dt.AddYears(settlePeriod);
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
                         .Where((condition) => condition.StartValue <= tmp && tmp < condition.EndValue && condition.Applyed)
                         .Select((condition) => condition.ChangedValue).ToList();

            foreach (decimal item in resultAmountConditions)
            {
                result += item;
            } // 지금 적용될 이윤

            return result;
        }
        private decimal GetResultInterestAmount(decimal amount, decimal changedInterest,decimal interest)
        {
            decimal resultInterest;

            if (CheckUpperLimitWellInterest && amount > UpperLimitWellInterest)
            {

                decimal rest = amount - UpperLimitWellInterest;
                decimal standardInterest = (UpperLimitWellInterest * changedInterest);
                decimal restInterest = rest * interest;

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

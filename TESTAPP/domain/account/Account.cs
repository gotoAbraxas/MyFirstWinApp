using System;
using System.Collections.Generic;
using System.Linq;
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
    delegate void CalulatorInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start, DateTime end);

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
    internal class Account : IAccount
    {
        #region "생성자"
        
        public Account() { }

        #endregion

        #region "속성"
        public long AccountId { get; set; } // 나중에 guid

        public long UserCode { get; set; } // 유저 코드 식별자
        public string Name { get; set; } // 계좌 이름
        public string Name_AccountId { get; set; } // 최종 식별 코드
        public decimal Interest {  get; set; } // 이율
        public decimal UnitPeriodInterest { get; set; } // 단위 기간 이율 
        public decimal Amount { get; set; } = 0; // 통장잔액
        public List<AccountLog> Log { get; set; } = new List<AccountLog>(); // 거래 기록

        public List<AmountConditionOfInterest> amountConditions { get; set; } // 
        public List<PeriodConditionOfInterest> periodConditions { get; set; }
        public SettleType SettleType { get; set; } // 정산 타입
        public int SettlePeriod { get; set; } // 정산 주기

        
        public SettlePeriodType SettlePeriodType { get; set; } // 정산 단위

        public bool checkUpperLimitWellInterest { get; set; } // 
        public decimal UpperLimitWellInterest { get; set; } // 우대금리 최대 금액 기본 null

        #endregion

        #region "메서드"

        public void AddLog(AccountLog log)
        {
            this.Log.Insert(log.Id, log);
        }


        public void GetResult(ref decimal amount,ref decimal resultInterest,ref decimal resultAmount,DateTime start,in DateTime end,List<VirtualLog> log,in List<AfterPlan> afterPlans)
        {
            switch (SettleType)
            {
                case SettleType.단리:
                    SimpleInterest(ref amount, ref resultInterest, ref resultAmount, start, in end, log, in afterPlans);
                    break;
                case SettleType.복리:
                    CompoundInterest(ref amount, ref resultInterest, ref resultAmount, start, in end, log, in afterPlans);
                    break;
                default:
                    break;
            }
        }

        // 매우 유사하지만 분리해두는 것이 이후에 편하다.
        // 단리
        private void SimpleInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start,in DateTime end,List<VirtualLog> log,in List<AfterPlan> afterPlans)
        {
            DateTime until = GetNextDate(start);

            decimal virtualAmount = amount * GetAmountRatio(start, start, end); // 현재는 이 결과를 쓰지 않음.

            if (until.CompareTo(end) > 0)
            {
                ReflectAfterPlan(amount, ref virtualAmount , start, end, log, afterPlans, resultInterest);
                return; // 재귀 종료
            }


            amount = ReflectAfterPlan(amount,ref virtualAmount, start, until, log, afterPlans, resultInterest);

            decimal changedInterest = Interest;

            changedInterest += GetResultAmountCondion(amount); // 조건에 맞게 추가할 이자
            changedInterest += GetResultPeriodCondion(start); // 조건에 맞게 추가할 이자.

            int date = ConvertSettlePeriodDate(SettlePeriodType);
            decimal convertValue = ConvertInterest(SettleType, changedInterest.ToString(), (double)SettlePeriod, date);


            // 지금 적용될 이윤
            // 몇가지는 조금 엇나가는 계산이 있긴한데 .. 일단 ..  

            decimal thisTimeInterest = GetResultInterestAmount(amount, convertValue); // 이번 타임 이자
            resultInterest += thisTimeInterest;

            resultAmount = amount + resultInterest;


            log.Add(new VirtualLog()
            {
                AccountLogType = AccountLogType.입금,
                DateTime = until,
                Description = "이자",
                Amount = thisTimeInterest,
                Total = resultAmount
            });

            SimpleInterest(ref amount, ref resultInterest, ref resultAmount, until, in end, log, afterPlans);
        }



        // 복리
        private void CompoundInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start,in DateTime end,List<VirtualLog> log, in List<AfterPlan> afterPlans)
        {

            DateTime until = GetNextDate(start);

            decimal virtualAmount = amount * GetAmountRatio(start, start, end); // 이게 좀 대대적인 ..

            if (until.CompareTo(end) > 0)
            {
                ReflectAfterPlan(amount, ref virtualAmount, until, end, log, afterPlans, resultInterest);
                return; // 재귀 종료
            }

            decimal changedInterest = Interest;

            // amount = 실제 금액, virtualAmount = 기간이 반영된 상태
            amount = ReflectAfterPlan(amount, ref virtualAmount, start, until, log, afterPlans, resultInterest);

            changedInterest += GetResultAmountCondion(amount); // 조건에 맞게 추가할 이자
            changedInterest += GetResultPeriodCondion(start); // 조건에 맞게 추가할 이자. 계산을 시작한 시점부터 얼마나 떨어졌는가.

            int date = ConvertSettlePeriodDate(SettlePeriodType);

            decimal convertValue = ConvertInterest(SettleType, changedInterest.ToString(), (double)SettlePeriod, date);

            decimal thisTimeInterest = GetResultInterestAmount(amount, convertValue); // 이번 타임 이자 <- 이게 바뀌어야함.
            /*
             * 이번 타임 이자 이걸 어떻게 바꿀 꺼냐면, 총 세가지를 더한 값을 넣어줄거임.
             * 1. 시작기간부터 잘 반영된 금액
             * 2. 도중에 입금된 금액(이건 비율을 가져오려면 조금 신경써야할 부분이 있음)
             * 3. 도중에 출금된 금액(이것도 입금 기간부터 끝 기간까지가 역으로 환산되는 금액임)
             * 
             */

            resultInterest += thisTimeInterest;

            resultAmount = amount + thisTimeInterest;
            amount += thisTimeInterest;

            log.Add(new VirtualLog()
            {
                AccountLogType = AccountLogType.입금,
                DateTime = until,
                Description = "이자",
                Amount = thisTimeInterest,
                Total = resultAmount
            });


            CompoundInterest(ref amount, ref resultInterest, ref resultAmount, until, in end, log, afterPlans);

        }

        private decimal GetAmountRatio(DateTime start, DateTime standard, DateTime end)
        {
            const int closingHour = 17; // 이건 나중에 계좌 정산 시간으로 넘겨도 되겠다.
            const int today = 1;
            // 이거 전부 분리할까.
            
            if (SettlePeriodType == SettlePeriodType.일 && standard.Hour > closingHour) return 0;
            else if (SettlePeriodType == SettlePeriodType.일) return 1;

            DateTime monthStart = new DateTime(start.Year, start.Month, 1);
            if (SettlePeriodType == SettlePeriodType.개월 && standard.Hour > closingHour)
            {
                return (decimal)(standard.DayOfYear - monthStart.DayOfYear) / (end.DayOfYear - start.DayOfYear + 1);
            }
            else if(SettlePeriodType == SettlePeriodType.개월)
            {
                return (decimal)(standard.DayOfYear - monthStart.DayOfYear + today) / (end.DayOfYear - start.DayOfYear + 1);
            }

            DateTime lasttime = new DateTime(standard.Year, 12, 31);

            // 이건 조금 손봐야하는 개념이다 .
            if (SettlePeriodType == SettlePeriodType.년 && standard.Hour > closingHour)
            {
                return (decimal)(lasttime.DayOfYear - standard.DayOfYear) / end.DayOfYear;
            }
            else if (SettlePeriodType == SettlePeriodType.년)
            {
                return (decimal)(lasttime.DayOfYear - standard.DayOfYear + today) / end.DayOfYear;
            }

            return 0;
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
        private decimal ReflectAfterPlan(decimal amount,ref decimal virtualAmount, DateTime start, DateTime end, List<VirtualLog> log, List<AfterPlan> afterPlans,decimal resultInterest)
        {
            var ac = afterPlans
                .Where((item) => (start.CompareTo(item.DateTime) < 0) && (item.DateTime.CompareTo(end) <= 0))
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
                virtualAmount += amountChange * GetAmountRatio(start,afterPlan.DateTime,end);
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


        private decimal GetResultPeriodCondion(DateTime start)
        {
            DateTime now = DateTime.Now.Date;
            decimal result = 0;
            List<decimal> resultPeriodConditions = periodConditions
                                    .Where((condition) => condition.CompareDateEnter(start,now) &&condition.CompareDatePass(start,now)  && condition.Applyed)
                                    .Select((condition) => condition.ChangedValue).ToList();

            foreach (decimal item in resultPeriodConditions)
            {
                result += item;
            }

            return result;
        }

        private decimal GetResultAmountCondion(decimal tmp)
        {
            decimal result = 0;

            List<decimal> resultAmountConditions = amountConditions
                         .Where((condition) => condition.StartValue < tmp&& tmp <= condition.EndValue && condition.Applyed)
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

            if (checkUpperLimitWellInterest && amount > UpperLimitWellInterest)
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

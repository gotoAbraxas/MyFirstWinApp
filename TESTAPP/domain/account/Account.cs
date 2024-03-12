using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.domain.account.iFace;
using TESTAPP.domain.account.sub;

namespace TESTAPP.domain.account
{

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
        public decimal Amount { get; set; } = 0; // 통장잔액
        public List<AccountLog> Log { get; set; } = new List<AccountLog>(); // 거래 기록

        public List<AmountCondition> amountConditions { get; set; }
        public List<PeriodCondition> periodConditions { get; set; }
        public SettleType SettleType { get; set; } // 정산 타입
        public int SettlePeriod { get; set; } // 정산 주기

        
        public SettlePeriodType SettlePeriodType { get; set; } // 정산 단위

        public bool checkUpperLimitWellInterest { get; set; } // 
        public decimal UpperLimitWellInterest { get; set; } // 우대금리 최대 금액 기본 null

        #endregion


        public void AddLog(AccountLog log)
        {
            this.Log.Insert(log.Id, log);
        }


        public void GetResult(ref decimal amount,ref decimal resultInterest,ref decimal resultAmount, DateTime start, DateTime end)
        {
            if (SettleType == SettleType.단리)
            {
                SimpleInterest(ref amount, ref resultInterest, ref resultAmount, start,end);
            }
            else if(SettleType == SettleType.복리)
            {
                CompoundInterest(ref amount, ref resultInterest, ref resultAmount, start,end);
            }
        }

        private void SimpleInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start,DateTime end)
        {
            // 이후에 입/출금 계획 받아서 적용할 예정

            DateTime until = GetNextDate(start);
            if (until.CompareTo(end) > 0) return; // 재귀 종료

            decimal changedInterest = Interest;

            DateTime now = DateTime.Now;


            changedInterest += GetResultAmountCondion(amount); // 조건에 맞게 추가할 이자
            changedInterest += GetResultPeriodCondion(start, now); // 조건에 맞게 추가할 이자.

            // 지금 적용될 이윤

            // 이건 좀 빡세다 .. 사실 현재 금액이 얼마나 예치되어있었냐를 계산해야하는데... 흑..
            // 이건 보통 예치금에서나 볼 법한 방식인데 일단 적용

            resultInterest = GetResultInterest(amount, resultInterest, changedInterest);
            
            resultAmount = amount + resultInterest;

            SimpleInterest(ref amount, ref resultInterest, ref resultAmount, until, end);
        }



        private DateTime GetNextDate(DateTime time)
        {
            if (SettlePeriodType == SettlePeriodType.일)
            {
                return time.AddDays(SettlePeriod);
            }
            else if (SettlePeriodType == SettlePeriodType.개월)
            {
                return time.AddMonths(SettlePeriod);
            }
            else if (SettlePeriodType == SettlePeriodType.년)
            {
                return time.AddYears(SettlePeriod);
            }
            return time;
        }

        private decimal GetResultPeriodCondion(DateTime start,DateTime now)
        {

            decimal result = 0;
            List<decimal> resultPeriodConditions = periodConditions
                                    .Where((condition) => start.CompareTo(now.AddMonths(condition.StartValue)) > 0)
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
                         .Where((condition) => condition.StartValue < tmp)
                         .Select((condition) => condition.ChangedValue).ToList();

            foreach (decimal item in resultAmountConditions)
            {
                result += item;
            } // 지금 적용될 이윤

            return result;
        }
        private decimal GetResultInterest(decimal amount, decimal resultInterest, decimal changedInterest)
        {
            if (checkUpperLimitWellInterest && amount > UpperLimitWellInterest)
            {

                decimal rest = amount - UpperLimitWellInterest;
                decimal standardInterest = UpperLimitWellInterest * changedInterest;
                decimal restInterest = rest * Interest;

                resultInterest += standardInterest + restInterest;
            }
            else
            {
                resultInterest += amount * changedInterest;
            }

            return resultInterest;
        }

        private void CompoundInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start, DateTime end)
        {
            DateTime until = GetNextDate(start);
            resultInterest = 1;
            resultAmount = 1;
        }






        public decimal GetProfit() // 그냥 현재 기준으로 이자 구하기
        {
            return GetProfitLogic(this.Log, DateTime.Now);
        }

        public decimal GetProfitWithCondition(List<AccountLog> logs, DateTime timeCondion) // 특정 
        {
            if (true) // 밸리데이션 조건을 충족할 시. 
                      // 근데 잘 생각해보면 그냥 이 앞단에서 막는게 나을거같음 이러면 책임분리가 잘 안됨.
            {
                return GetProfitLogic(logs, timeCondion);
            }
            /*
            else
            {
                MessageBox.Show("계좌에 존재하는 금액보다 더 많은 금액을 출금하려고함");
            }
            */

        }

        public decimal GetProfitLogic(List<AccountLog> logs, DateTime timeCondition)
        {
            decimal profit = 0;
            logs.ForEach(log =>
            {
                // 여기서 각 로그마다 어떠한 판단을 해서 계산하기 ?
                mm(log.AccountLogType);
                //
                profit += calculate();
            });


            return profit;

        }

        public decimal calculate()
        {
            return 1;
        }

        public decimal mm(AccountLogType type) {
            switch (type)
            {
                case AccountLogType.입금:
                    return 1;
                default:
                    return 0;

            }
        }

    }
}

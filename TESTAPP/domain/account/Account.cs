﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TESTAPP.domain.account.iFace;
using TESTAPP.domain.account.sub;
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


        public void AddLog(AccountLog log)
        {
            this.Log.Insert(log.Id, log);
        }


        public void GetResult(ref decimal amount,ref decimal resultInterest,ref decimal resultAmount,DateTime start,in DateTime end,List<VirtualLog> log,in List<AfterPlan> afterPlans)
        {

            if (SettleType == SettleType.단리)
            {

                SimpleInterest(ref amount, ref resultInterest, ref resultAmount, start,in end, log, in afterPlans);
            }
            else if(SettleType == SettleType.복리)
            {
                CompoundInterest(ref amount, ref resultInterest, ref resultAmount, start,in end, log,in afterPlans);
            }

        }

        // 두개가 매우 유사해서 합칠 수 있을거같은데 ...
        // 단리
        private void SimpleInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start,in DateTime end,List<VirtualLog> log,in List<AfterPlan> afterPlans)
        {
            // 이후에 입/출금 계획 받아서 적용할 예정
            DateTime until = GetNextDate(start);
            if (until.CompareTo(end) > 0)
            {
                ReflectAfterPlan(amount, start, end, log, afterPlans, resultInterest);
                return; // 재귀 종료
            }


            amount = ReflectAfterPlan(amount, start, until, log, afterPlans, resultInterest);

            decimal changedInterest = Interest;

            changedInterest += GetResultAmountCondion(amount); // 조건에 맞게 추가할 이자
            changedInterest += GetResultPeriodCondion(start); // 조건에 맞게 추가할 이자.

            int date = ConvertSettlePeriodDate(SettlePeriodType);
            decimal convertValue = ConvertInterest(SettleType, changedInterest.ToString(), (double)SettlePeriod, date);


            // 지금 적용될 이윤
            // 몇가지는 조금 엇나가는 계산이 있긴한데 .. 일단 ..  

            decimal nowInterest = GetResultInterestAmount(amount, convertValue); // 이번 타임 이자
            resultInterest += nowInterest;

            resultAmount = amount + resultInterest;


            log.Add(new VirtualLog()
            {
                AccountLogType = AccountLogType.입금,
                DateTime = until,
                Description = "이자",
                Amount = nowInterest,
                Total = resultAmount
            });

            SimpleInterest(ref amount, ref resultInterest, ref resultAmount, until, in end, log, afterPlans);
        }



        // 복리
        private void CompoundInterest(ref decimal amount, ref decimal resultInterest, ref decimal resultAmount, DateTime start,in DateTime end,List<VirtualLog> log, in List<AfterPlan> afterPlans)
        {

            DateTime until = GetNextDate(start);

            if (until.CompareTo(end) > 0)
            {
                ReflectAfterPlan(amount, until, end, log, afterPlans, resultInterest);
                return; // 재귀 종료
            }

            decimal changedInterest = Interest;

            amount = ReflectAfterPlan(amount, start, until, log, afterPlans, resultInterest);

            changedInterest += GetResultAmountCondion(amount); // 조건에 맞게 추가할 이자
            changedInterest += GetResultPeriodCondion(start); // 조건에 맞게 추가할 이자. 계산을 시작한 시점부터 얼마나 떨어졌는가.

            int date = ConvertSettlePeriodDate(SettlePeriodType);

            decimal convertValue = ConvertInterest(SettleType, changedInterest.ToString(), (double)SettlePeriod, date);

            decimal nowInterest = GetResultInterestAmount(amount, convertValue); // 이번 타임 이자

            resultInterest += nowInterest;

            resultAmount = amount + nowInterest;

            amount += nowInterest;  // 딱 이거 하나 다르면 그냥 .. if 해도? 근데 또 책임분리 면에선...


            log.Add(new VirtualLog()
            {
                AccountLogType = AccountLogType.입금,
                DateTime = until,
                Description = "이자",
                Amount = nowInterest,
                Total = resultAmount
            });


            CompoundInterest(ref amount, ref resultInterest, ref resultAmount, until,in end, log, afterPlans);

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
                                    .Where((condition) => start.CompareTo(now.AddMonths(condition.StartValue)) > 0 && condition.Applyed)
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
            decimal resultInterest = 0;
            
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




    }
}

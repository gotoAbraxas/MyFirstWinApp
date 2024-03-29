﻿using System;
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
    internal abstract class Account : IAccount
    {
        public int Id { get; set; } // 나중에 guid
        public decimal Interest {  get; set; } // 이율
        public List<AccountLog> Log { get; set; } = new List<AccountLog>(); // 거래 기록
        public SettleType SettleType { get; set; } // 정산 타입
        public int SettlePeriod { get; set; } // 정산 주기
        public SettlePeriodType SettlePeriodType { get; set; } // 정산 단위

        public decimal? UpperLimitWellInterest { get; set; } = null; // 우대금리 최대 금액 기본 null


        public Account() { }

        public void AddLog(AccountLog log)
        {
            this.Log.Insert(log.Id, log);
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
            else
            {
                MessageBox.Show("계좌에 존재하는 금액보다 더 많은 금액을 출금하려고함");
            }

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

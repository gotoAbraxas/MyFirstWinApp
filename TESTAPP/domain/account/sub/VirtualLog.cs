using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP.domain.account.sub
{
    public enum Period
    {
        일단위,
        월단위,
        년단위,
        내역
    }

    public struct VirtualDto
    {
        public DateTime Now { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public long UserCode { get; set; }
        public long AccountId { get; set; }

    }

    public struct VirtualLog
    {
        public int Id { get; set; }
        public AccountLogType AccountLogType { get; set; }

        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }

        public decimal Total { get; set; }
    }

    public struct AfterPlan
    {
        public int Id { get; set; }
        public AccountLogType AccountLogType { get; set; }

        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }

    }

    public struct VirtualLogConditionaly
    {
        public int Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public decimal Deposit { get; set; }
        public decimal Withdraw { get; set; }
        public decimal interest { get; set; }
        public string Description { get; set; }

        public decimal? Total { get; set; }
    }

    public class VirtualLogformally
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }

        public decimal? Total { get; set; }
    }
}

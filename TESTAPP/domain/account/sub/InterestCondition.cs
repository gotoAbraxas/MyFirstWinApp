using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP.domain.account.sub
{
     // 미사용
    enum ConditionType
    { 금액,
      기간,
      기타
    }
    internal class InterestCondition<T>
    {

        public ConditionType ConditionType { get; set; }

        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }
        public decimal ChangedValue { get; set; }
        public bool isAlwaysApplyed { get; set; }

        public string Description { get; set; }
        public InterestCondition()
        {
        }
    }
}

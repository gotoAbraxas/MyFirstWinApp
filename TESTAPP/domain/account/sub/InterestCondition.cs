using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP.domain.account.sub
{
     // 미사용

    // 사용안하는 이유 => 금액과 기간을 완전 분리해서 사용하기로 함.


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

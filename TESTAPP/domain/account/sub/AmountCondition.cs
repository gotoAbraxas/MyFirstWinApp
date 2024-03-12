using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP.domain.account.sub
{
    internal class AmountCondition
    {
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }
        public decimal ChangedValue { get; set; }
        public bool isAlwaysApplyed { get; set; }

        public string Description { get; set; }
    }
}

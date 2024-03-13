using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP.domain.account.sub
{
    internal class PeriodCondition
    {

        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public decimal ChangedValue { get; set; }
        public bool Applyed { get; set; } = true;

        public string Description { get; set; }
    }
}

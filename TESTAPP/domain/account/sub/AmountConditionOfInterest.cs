using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP.domain.account.sub
{

    internal struct AmountConditionOfInterestDto
    {
        public string Start;
        public string End;
        public string Interest;
        public int Sign;

    }
    internal class AmountConditionOfInterest
    {
        public decimal StartValue { get; set; }
        public decimal EndValue { get; set; }
        public decimal ChangedValue { get; set; }
        public bool Applyed { get; set; } = true;

        public string Description { get; set; }
    }
}

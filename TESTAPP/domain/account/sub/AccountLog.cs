using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP.domain.account.sub
{

    enum AccountLogType
    {
        입금,
        출금,
        //이율변경
    }
    internal class AccountLog
    {
       public int Id { get; set; }
    
       public AccountLogType AccountLogType { get; set; }

       public decimal Amount { get; set; }
       public DateTime DateTime { get; set; }
       public  string Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TESTAPP.domain.account;

namespace TESTAPP.database.iFace
{
    internal interface IAccountRepository
    {


        Account GetAccountById(long userCode, long AccountCode);
        Dictionary<long, Account> GetAllAccountsById(long userCode);

        void SaveAccount(Account account); 
   
    }
}

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


        Account GetAccount(Guid userCode, Guid AccountCode);
        Dictionary<Guid,Account> GetAllAccounts(Guid userCode);

        void SaveAccount(Account account); 
   
    }
}

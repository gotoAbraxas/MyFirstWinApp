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
        Dictionary<long, Account> GetAllAccountsByIdWithCondition(long userCode, SearchCondition condition);
        void SaveAccount(Account account); 
   
    }
}

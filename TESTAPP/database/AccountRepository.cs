using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.database.iFace;
using TESTAPP.domain.account;
using TESTAPP.domain.account.sub;

namespace TESTAPP.database
{
    internal class AccountRepository : IAccountRepository
    {

        #region "생성자, 싱글톤 구현"
        private AccountRepository() { }

        private AccountRepository Repository { get; set; }

        private static class SingletonHelper
        {
            internal static AccountRepository INSTANCE { get; } = new AccountRepository();
        }

        public static AccountRepository GetInstance()
        {
            return SingletonHelper.INSTANCE;
        }
        #endregion

        #region "속성"
        public static Dictionary<long, Account> Accounts = new Dictionary<long, Account>();
        #endregion

        #region "메서드"
        public Account GetAccountById(long userCode, long accountCode)
        {
            try
            {
                return Accounts.Where(account => account.Value.UserCode == userCode && account.Value.AccountId == accountCode).Single().Value;
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("유저코드와 계좌코드가 전달이 안되었을 때.");
                return new Account();
            }
        }

        public Dictionary<long, Account> GetAllAccountsById(long userCode)
        {

            try 
            { 
                return Accounts
                .Where(account => account.Value.UserCode == userCode)
                .ToDictionary(account => account.Value.AccountId, account => account.Value);
    
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("유저코드가 전달이 안되었을 때.");
                return new Dictionary<long, Account>();
            }
        }

        public void SaveAccount(Account account)
        {
            lock (this)
            {
                Accounts.Add(account.AccountId, account);
            }
        }

        #endregion
    }
}

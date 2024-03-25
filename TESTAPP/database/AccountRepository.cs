using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.database.iFace;
using TESTAPP.domain.account;
using TESTAPP.domain.account.sub;

namespace TESTAPP.database
{
    internal struct SearchCondition
    {
        public string Name {  get; set; }
        public decimal? LowerInterest { get; set; }
        public bool AmountCondition { get; set; }
        public bool PeriodCondition { get; set; }
    }

    internal class AccountRepository : IAccountRepository
    {

        #region "생성자, 싱글톤 구현"
        private AccountRepository() 
        {
           TestInit();
        }

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


        private void TestInit()
        {
            string json = File.ReadAllText("test.json");
            // JSON 문자열을 C# 객체의 리스트로 역직렬화
            List<Account> accounts = JsonConvert.DeserializeObject<List<Account>>(json);

            foreach (Account item in accounts)
            {
                SaveAccount(item);
            }
        }

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

        public Dictionary<long, Account> GetAllAccountsByIdWithCondition(long userCode, SearchCondition condition)
        {
            try
            {
                return Accounts
                .Where(account => account.Value.UserCode == userCode)
                .Where(account => condition.LowerInterest is null?  true : account.Value.Interest > condition.LowerInterest)
                .Where(account => condition.PeriodCondition ? account.Value.PeriodConditions.Count > 0 :true)
                .Where(account => condition.AmountCondition ? account.Value.AmountConditions.Count > 0 : true)
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

                Accounts.Add(account.AccountId, account);
        }



        #endregion
    }
}

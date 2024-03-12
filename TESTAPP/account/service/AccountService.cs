using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using TESTAPP.database;
using TESTAPP.database.iFace;
using TESTAPP.domain.account;
using TESTAPP.domain.account.sub;

namespace TESTAPP.account.service
{
    internal class AccountService // 이게 마치 전자지갑이 되는것
    {
        #region "생성자"
        public AccountService()
        {
            repository = AccountRepository.GetInstance();
        }

        #endregion

        #region "속성"
        public Account SelectedAccount { get; set; }
        private IAccountRepository repository;

        #endregion

        #region "메서드"
        public Account SelectAccountById(long userCode, long accountCode) // 해당키를 갖고 계좌를 넣어버리기.
        {

            try { 
            SelectedAccount = repository.GetAccountById(userCode, accountCode);
            }
            catch(Exception ex)
            {
                MessageBox.Show("해당 계좌가 존재하지 않습니다.");
            }
            return SelectedAccount;
        }
       
        public void AddAcount(Account account) // 이건 완전 다른걸 넣어야할 수 있음.
        {
            repository.SaveAccount(account);
        }

        public Dictionary<long, Account> GetAcountsById(long userCode)
        { 
            return repository.GetAllAccountsById(userCode);
        }

        public void Deposit(long userCode, long accountCode,decimal amount,AccountLog log)
        {
            Account tmp = SelectAccountById(userCode, accountCode);

            tmp.AddLog(log);
            tmp.Amount += amount;

        }

        public void Withdraw(long userCode, long accountCode, decimal amount, AccountLog log)
        {
            Account tmp = SelectAccountById(userCode, accountCode);

            if(tmp.Amount > amount) 
            {
                tmp.AddLog(log);
                tmp.Amount -= amount;

            }
            else
            {
                MessageBox.Show("잔액이 부족합니다.");
            }

            
        }

        internal void GetResult(Account account, DateTime until)
        {
            throw new NotImplementedException();
        }

        // 시작 금액/ 시작 이윤, 변경될 이윤 (금액, 기간) 단위 기간 /최종 기간, 

        #endregion
    }
}

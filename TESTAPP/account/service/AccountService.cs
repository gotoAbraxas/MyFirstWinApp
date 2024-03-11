using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TESTAPP.database;
using TESTAPP.database.iFace;
using TESTAPP.domain.account;

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
        public IAccountRepository repository;

        #endregion

        #region "메서드"
        public void SelectAccount(Guid userCode, Guid accountCode) // 해당키를 갖고 계좌를 넣어버리기.
        {
            SelectedAccount = repository.GetAccount(userCode, accountCode);
        }
       
        public void AddAcount(Account account) // 이건 완전 다른걸 넣어야할 수 있음.
        {
            repository.SaveAccount(account);
        }

        #endregion
    }
}

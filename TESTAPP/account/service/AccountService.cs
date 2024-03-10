using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TESTAPP.domain.account;

namespace TESTAPP.account.service
{
    internal class AccountService // 이게 마치 전자지갑이 되는것
    {


        private AccountService Service { get; set; }
        public Account SelectedAccount { get; set; }
        public Dictionary<int, Account> Accounts { get; set; } = new Dictionary<int, Account>();

        public AccountService() { }




        public void SelectAccount(int key) // 해당키를 갖고 계좌를 넣어버리기.
        {

            if(Accounts.TryGetValue(key, out Account account) && account != null)
            {
                SelectedAccount = account;
            }
        }
        public void AddAcount(Account account) // 이건 완전 다른걸 넣어야할 수 있음.
        {
            Accounts.Add(account.Id,account);
        }
    }
}

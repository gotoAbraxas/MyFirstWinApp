using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.domain.account.sub;
using static TESTAPP.common.component.Dynamic;

namespace TESTAPP
{
    public partial class AddAccountLog : Form
    {
        #region "속성"

        private AccountService account;

        public long Usercode { get; set; }
        public long AccountId { get; set; }

        #endregion

        #region "생성자
        public AddAccountLog()
        {
            InitializeComponent();
        }

        #endregion

        #region "폼 생성시 초기 작업"
        private void AddAccountLog_Load(object sender, EventArgs e)
        {
            init();
        }


        private void init()
        {
            SetAccountLogCombo();
            SetAccountService();
        }


        private void SetAccountLogCombo()
        {
            SetEnumToCombo<AccountLogType>(cb_AccountLog);
        }

        private void SetAccountService()
        {
            this.account = new AccountService();
        }

        #endregion

        #region "Amount 천단위 찍어주기"
        private void txt_AccountLog_TextChanged(object sender, EventArgs e)
        {
            TextBox tmp = sender as TextBox;

            SetTxtAmountPretty(this, tmp.Name);
        }
        #endregion

        #region "입/출금 저장 관련"
        private void bt_AddLogAccept_Click(object sender, EventArgs e)
        {
            ValidationValue();

            SaveAccountLog();

            this.Close();

        }

        private void ValidationValue()
        {
            if (cb_AccountLog.SelectedIndex == -1)
            {
                MessageBox.Show("입/출금을 선택하세요.");
                return;
            }
            if (decimal.TryParse(GetTxtAmountPretty(this, txt_AccountLog.Name), out decimal result) && result < 0)
            {
                MessageBox.Show("올바른 금액을 선택하세요.");
                return;
            }
        }

        private void SaveAccountLog()
        {
            string type = cb_AccountLog.SelectedItem as string;

            decimal.TryParse(GetTxtAmountPretty(this, txt_AccountLog.Name),out decimal amount); 
            // 이게 밸리데이트인데 .. 위에서 또 해야하나.

            AccountLog log = new AccountLog()
            {
                Amount = amount,
                DateTime = DateTime.Now,

            };
            if (type == AccountLogType.입금.ToString())
            {
                Deposit(amount, log);
            }
            else if(type == AccountLogType.출금.ToString())
            {
                Withdraw(amount, log);
            }
        }
        private void Deposit(decimal amount, AccountLog log)
        {
            log.AccountLogType = AccountLogType.입금;

            account.Deposit(Usercode, AccountId, amount, log);
        }
        private void Withdraw(decimal amount, AccountLog log)
        {
            log.AccountLogType = AccountLogType.출금;
            account.Withdraw(Usercode, AccountId, amount, log);
        }

        #endregion

        #region "창닫기"
        private void bt_AddLogCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}

using System;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.domain.account;
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
            cb_AccountLog.SelectedIndex = 0;
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

            // 이런거 직접 이벤트를 만들어서 폼 만들때 동적으로 이벤트 추가해주는게 안낫나? 
        }
        #endregion

        #region "입/출금 저장 관련"
        private void bt_AddLogAccept_Click(object sender, EventArgs e)
        {

            try
            {

                ValidationValue();
                SaveAccountLog();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ValidationValue()
        {
            if (IsComboBoxItemSelected(cb_AccountLog))
            {
                throw new Exception("입/출금을 선택하세요.");
            }
            if (decimal.TryParse(GetTxtAmountPretty(this, txt_AccountLog.Name), out decimal result) && result < 0)
            {
                throw new Exception("올바른 금액을 선택하세요.");
            }
        }

        public bool IsComboBoxItemSelected(ComboBox comboBox)
        {
            return comboBox.SelectedItem == null;
        }

        private void SaveAccountLog()
        {
            AccountLogType type = (AccountLogType)cb_AccountLog.SelectedItem;

            decimal.TryParse(GetTxtAmountPretty(this, txt_AccountLog.Name), out decimal amount);
            // 이게 밸리데이트인데 .. 위에서 또 해야하나.

            AccountLog log = new AccountLog()
            {
                Amount = amount,
                DateTime = DateTime.Now,
                Description = ""


            };
            if (type == AccountLogType.입금)
            {
                Deposit(amount, log);
            }
            else if (type == AccountLogType.출금)
            {
                Withdraw(amount, log);
            }
        }
        private void Deposit(decimal amount, AccountLog log)
        {
            log.AccountLogType = AccountLogType.입금;

            Account ac = account.Deposit(Usercode, AccountId, amount, log);
            log.Total = ac.Amount;


        }
        private void Withdraw(decimal amount, AccountLog log)
        {
            log.AccountLogType = AccountLogType.출금;

            try
            {
                Account ac = account.Withdraw(Usercode, AccountId, amount, log);
                log.Total = ac.Amount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

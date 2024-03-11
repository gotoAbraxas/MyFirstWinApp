using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.domain.account;
using static TESTAPP.common.component.Dynamic;

namespace TESTAPP
{
    public partial class AddAcount : Form
    {

        private readonly string txt_Condition_st = "txt_Condition_st";
        private readonly string txt_Condition_ed = "txt_Condition_ed";
        private readonly string ch_Condition = "ch_Condition";
        private readonly string lb_Condition = "lb_Condition";
        private readonly string txt_Condition_interest = "txt_Condition_interest";

        List<Control> ConditionControler = new List<Control>();
        private AccountService accountService;
        public AddAcount()
        {


            InitializeComponent();

            SetSettleType();

            Init();
        }

        private enum AddConditionType
        {
            금액,
            기간,
            기타
        }

        public void Init()
        {
            cb_AccountType.Items.Add("사용할지 말지 안정함.");
            cb_AccountType.Items.Add("기타"); // 이걸 어떻게 사용할지는 의문. 만들때 정하냐 or 만들면서 정하냐

            SetAccountService();
            CheckingPreferent();
            SetInterestPeriod();
            IsSelected();
            SetAddCondition();
        }


        private void IsSelected()
        {
            
        }

        private void SetAccountService()
        { /// 계좌 서비스 세팅 좀 자원낭비같긴한데 일단 이렇게.
            accountService = new AccountService();
        }

        private void CheckingPreferent()
        {
            //우대이율 관련 보이기 / 안보이기
            PreferentVisable(false);
        }

        

        private void AddAcount_Load(object sender, EventArgs e)
        {

        }


        private void cb_AccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTxtAccountType();
        }

        private void ch_CheckPreferent_CheckedChanged(object sender, EventArgs e)
        {
            SetPreferentBox(sender);
        }

        #region "계좌정보 기타 설정"
        private void SetTxtAccountType()
        {
            if (cb_AccountType.SelectedIndex == cb_AccountType.Items.IndexOf("기타"))
            {
                txt_AccountType.Enabled = true;
                txt_AccountType.Visible = true;
            }
            else
            {

                txt_AccountType.Enabled = false;
                txt_AccountType.Visible = false;
            }
        }
        #endregion

        #region "이자 지급방식 설정"
        private void SetSettleType()
        {
            SetEnumToCombo<SettleType>(cb_SettleType);
        }
        #endregion

        #region "이자 주기 설정"
        private void SetInterestPeriod()
        {
            // 이자 주기 
            SetEnumToCombo<SettlePeriodType>(cb_SettlePeriod);
        }

        #endregion

        #region "우대 이자 제한 체크 설정"
        private void SetPreferentBox(object sender)
        {
            CheckBox box = (CheckBox)sender;

            if (box.Checked)
            {
                PreferentVisable(true);
            }
            else
            {
                PreferentVisable(false);

            }
        }

        #endregion

        #region "우대 이자 관련 항목 Viable"
        private void PreferentVisable(bool value)
        {
            lb_Preferent.Visible = value;
            lb_Preferent_limit.Visible = value;
            txt_Preferent.Visible = value;
        }

        #endregion

        #region "우대 이율 조건 설정
        private void SetAddCondition()
        {
            SetEnumToCombo<AddConditionType>(cb_AddCondition);
        }

        #endregion

        private void bt_AddCondition_Click(object sender, EventArgs e)
        {
           AddConditionType type = (AddConditionType)cb_AddCondition.SelectedIndex;

            switch (type)
            {
                case AddConditionType.금액:
                    AddAmountCondition();
                    break;
                case AddConditionType.기간:
                    break;
                case AddConditionType.기타:
                    break;
                default:
                    MessageBox.Show("타입을 선택 바랍니다.");
                    break;
            }
        }


        private void AddAmountCondition()
        {
            FlowLayoutPanel layout = new FlowLayoutPanel();

            DynamicInsert<FlowLayoutPanel>(this, layout, flp_Condition, width: flp_Condition.Width - 10, height: 40);

            DynamicLabelInsert(this, new Label(), layout, "", $"{ConditionControler.Count}", 20, 30);
            DynamicAmountInsert(this, new TextBox(), layout, $"{txt_Condition_st}{ConditionControler.Count}", "", 130, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "~", 10, 30);
            DynamicAmountInsert(this, new TextBox(), layout, $"{txt_Condition_ed}{ConditionControler.Count}", "", 130, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "원 ", 30, 30);
            DynamicInsert<TextBox>(this, new TextBox(), layout, $"{txt_Condition_interest}{ConditionControler.Count}","", 35, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "%", 10, 30);
            ConditionControler.Add(layout);
        }


        #region "창 닫기

        private void bt_AddAcount_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void bt_AddAcount_save_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateValueBeforeSave(out Account account);

                SaveAccount(account);

                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{exc.Message} 가 잘못되었습니다 다시 확인 바랍니다.");
            }
        }

        private void ValidateValueBeforeSave(out Account account)
        {
            account = new Account()
            {
                Name = txt_AccountName.Text,
                AccountId = long.Parse(txt_AccountNumber.Text),
                Interest = decimal.Parse(txt_Interest.Text),
                SettlePeriod = int.Parse(txt_SettlePeriod.Text),
                SettlePeriodType = GetEnumValue<SettlePeriodType>(cb_SettlePeriod.Text),
                SettleType = GetEnumValue<SettleType>(cb_SettleType.Text),
                UserCode = 1L, // 임시로 이렇게 할 예정,
                UpperLimitWellInterest = ch_CheckPreferent.Checked ? (decimal?)decimal.Parse(txt_Preferent.Text.Replace(",","")) : null,
            };

        }

        private void SaveAccount(Account myAccount)
        {
            accountService.AddAcount(myAccount);
        }

        private T GetEnumValue<T>(string value) where T : Enum
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (InvalidCastException)
            {
                // 변환 실패 시 처리
                return default(T);
            }
        }

        private void txt_Preferent_TextChanged(object sender, EventArgs e)
        {
            SetTxtAmountPretty(this,(sender as TextBox).Name);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Serialization;
using TESTAPP.account.service;
using TESTAPP.domain.account;
using TESTAPP.domain.account.sub;
using static TESTAPP.common.component.Dynamic;

namespace TESTAPP
{

    delegate void InterestDynamic(TextBox tb, double remain, double share, TextBox reflectbox);

    public partial class AddAcount : Form
    {

        #region "속성"

        private readonly string txt_Condition_st = "txt_Condition_st";
        private readonly string txt_Condition_ed = "txt_Condition_ed";
        private readonly string txt_Condition_interest = "txt_Condition_interest";
        private readonly string bt_Condition_interest = "bt_Condition_interest";
        Dictionary<string,Control> ConditionControler = new Dictionary<string,Control>();
        private AccountService accountService;

        private enum AddConditionType
        {
            금액,
            기간,
            기타
        }

        

        #endregion

        #region "생성자"
        public AddAcount()
        {
            InitializeComponent();

        }

        #endregion

        #region "OnLoad"

        private void AddAcount_Load(object sender, EventArgs e)
        {
            // 생성자 이후 실행되는 공간, 생성자에 넣어도 되지만, 순서가 확실히 구분되는 공간.
            Init();
        }

        public void Init()
        {
            tTip_Settle.SetToolTip(cb_SettleType, "복리의 경우, \n이자가 투자금액에 재투자 되는 경우를 의미하기도 합니다.");
            
            SetAccountType();
            SetSettleType();
            SetAccountService();
            CheckingPreferent();
            SetInterestPeriod();
            SetAddCondition();
        }


        private void SetAccountService()
        { /// 계좌 서비스 세팅 좀 자원낭비같긴한데 일단 이렇게.
            accountService = new AccountService();
        }

        #endregion

        #region "계좌정보 기타 설정"

        private void cb_AccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTxtAccountType();
        }
        private void SetTxtAccountType()
        {
            if (cb_AccountType.SelectedIndex == cb_AccountType.Items.IndexOf("직접입력"))
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

        #region "계좌 유형 설정"
        private void SetAccountType()
        {
            SetEnumToCombo<AccountType>(cb_AccountType);
            //cb_AccountType.SelectedIndex = 5;
            cb_AccountType.SelectedItem = AccountType.직접입력;
        }

        #endregion

        #region "이자 지급방식 설정"
        private void SetSettleType()
        {
            SetEnumToCombo<SettleType>(cb_SettleType);
            cb_SettleType.SelectedItem = SettleType.단리;
        }
        #endregion

        #region "이자 주기 설정"
        private void SetInterestPeriod()
        {
            // 이자 주기 
            SetEnumToCombo<SettlePeriodType>(cb_SettlePeriod);
            cb_SettlePeriod.SelectedItem = SettlePeriodType.일;
        }

        #endregion

        #region "이율 추산, 역추산"

        // 합칠 수 있지만 굳이 싶은 부분.
        private void CalculateFomalInterest(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (double.TryParse(txt_SettlePeriod.Text, out double period)
                && decimal.TryParse(tb.Text, out _))
            {
                int share = ConvertSettlePeriodDate((SettlePeriodType)cb_SettlePeriod.SelectedItem);

                SetInterestDynamic(tb, share, period, txt_Interest);

            }
        }
        private void CalculateStandardInterest(object sender, KeyEventArgs e)
        {

            TextBox tb = sender as TextBox;

            if (double.TryParse(txt_SettlePeriod.Text, out double period)
                && decimal.TryParse(tb.Text, out _))
            {
                int share = ConvertSettlePeriodDate((SettlePeriodType)cb_SettlePeriod.SelectedItem);

                SetInterestDynamic(tb, period, share, txt_standardInterest);

            }
        }

        private void ReflectRelatedValue(object sender, EventArgs e)
        {
            if (!double.TryParse(txt_SettlePeriod.Text, out double period)) return;
            int share = ConvertSettlePeriodDate((SettlePeriodType)cb_SettlePeriod.SelectedItem);

            if (decimal.TryParse(txt_Interest.Text, out _))
            {
                SetInterestDynamic(txt_Interest, period, share, txt_standardInterest);
            }
            else if (decimal.TryParse(txt_standardInterest.Text, out _))
            {
                SetInterestDynamic(txt_standardInterest, share, period, txt_Interest);
            }
        }

        private void SetInterestDynamic(TextBox tb, double remain, double share, TextBox reflectbox)
        {
            // 연단위 이자를 일,월 등의 이자로 쪼개거나 /반대로 일,월 등의 이자를 연단위로 합쳐주는 메소드
            decimal approximation = ConvertInterest((SettleType)cb_SettleType.SelectedItem, tb.Text, remain, share);
            reflectbox.Text = approximation.ToString();
        }

        #endregion

        #region "우대 이자 제한 체크 설정"
        private void ch_CheckPreferent_CheckedChanged(object sender, EventArgs e)
        {
            SetPreferentBox(sender);
        }
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
        private void CheckingPreferent()
        {
            //우대이율 관련 보이기 / 안보이기
            PreferentVisable(false);
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

        #region "우대 이자 금액 Pretty"
        private void txt_Preferent_TextChanged(object sender, EventArgs e)
        {
            SetTxtAmountPretty(this, (sender as TextBox).Name);
        }
        #endregion

        #region "우대 이율 콤보박스 설정
        private void SetAddCondition()
        {
            SetEnumToCombo<AddConditionType>(cb_AddCondition);
            cb_AddCondition.SelectedItem = AddConditionType.금액;
        }

        #endregion

        #region "조건 동적 추가"
        private void bt_AddCondition_Click(object sender, EventArgs e)
        {
            AddConditionType type = (AddConditionType)cb_AddCondition.SelectedItem;

            switch (type)
            {
                case AddConditionType.금액:
                    AddAmountCondition();
                    break;
                case AddConditionType.기간:
                    AddPeriodCondion();
                    break;
                case AddConditionType.기타:
                    break;
                default:
                    MessageBox.Show("금액 및 기간 타입을 선택 바랍니다.");
                    break;
            }
        }

        private void AddAmountCondition()
        {

            FlowLayoutPanel layout = new FlowLayoutPanel();

            string id = Guid.NewGuid().ToString();
            Button cancel = DeleteCondition(id);
            Button bt = PlusMinusBt();
            DynamicInsert<FlowLayoutPanel>(this, layout, flp_Condition, width: flp_Condition.Width - 10, name: id, height: 35);

            DynamicLabelInsert(this, new Label(), layout, $"{AddConditionType.금액}{ConditionControler.Count}", AddConditionType.금액.ToString(), 30, 30);
            DynamicAmountInsert(this, new TextBox(), layout, $"{txt_Condition_st}{ConditionControler.Count}", 130, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "~", 10, 30);
            DynamicAmountInsert(this, new TextBox(), layout, $"{txt_Condition_ed}{ConditionControler.Count}", 130, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "원", 20, 30);
            DynamicInsert<Button>(this, bt, layout, $"{bt_Condition_interest}{ConditionControler.Count}", 20, 20);
            DynamicInsert<TextBox>(this, new TextBox(), layout, $"{txt_Condition_interest}{ConditionControler.Count}", 35, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "%", 15, 30);
            DynamicInsert<Button>(this, cancel, layout, id, width: 40, height: 20);

            ConditionControler.Add(id, layout);

        }

        private void AddPeriodCondion()
        {
            FlowLayoutPanel layout = new FlowLayoutPanel();

            string id = Guid.NewGuid().ToString();
            Button cancel = DeleteCondition(id);
            Button bt = PlusMinusBt();
            DynamicInsert<FlowLayoutPanel>(this, layout, flp_Condition, width: flp_Condition.Width - 10, height: 35);

            DynamicLabelInsert(this, new Label(), layout, $"{AddConditionType.기간}{ConditionControler.Count}", AddConditionType.기간.ToString(), 30, 30);
            DynamicInsert<TextBox>(this, new TextBox(), layout, $"{txt_Condition_st}{ConditionControler.Count}", 35, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "개월", 30, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "~", 20, 30);
            DynamicInsert<TextBox>(this, new TextBox(), layout, $"{txt_Condition_ed}{ConditionControler.Count}", 35, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "개월", 30, 30);
            DynamicInsert<Button>(this, bt, layout, $"{bt_Condition_interest}{ConditionControler.Count}", 20, 20);
            DynamicInsert<TextBox>(this, new TextBox(), layout, $"{txt_Condition_interest}{ConditionControler.Count}", 35, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "%", 15, 30);
            DynamicInsert<Button>(this, cancel, layout, id, width: 40, height: 20);

            ConditionControler.Add(id, layout);
        }
        private Button PlusMinusBt()
        {
            Button bt = new Button
            {
                Text = "+"
            };
            bt.Click += (sender, o) =>
            {
                if (bt.Text.Equals("+"))
                {
                    bt.Text = "-";
                }
                else
                {
                    bt.Text = "+";
                }
            };
            return bt;
        }

        private Button DeleteCondition(string id)
        {
            Button cancel = new Button();
            cancel.Text = "삭제";
            cancel.Click += (sender, o) =>
            {
                ConditionControler.TryGetValue(id, out Control value);
                this.Controls.Remove(value);  
                foreach (Control ct in value.Controls)
                {
                    ct.Dispose();
                }
                value.Dispose();
                ConditionControler.Remove(id);

            };
            return cancel;
        }


        #endregion

        #region "동적 조건 삭제/리셋"
        private void bt_Reset_Click(object sender, EventArgs e)
        {
            ResetCondition();
        }

        private void ResetCondition()
        {
            foreach (Control control in ConditionControler.Values)
            {
                DiposeControl(control);
            }
            ConditionControler.Clear();
        }

        private void DiposeControl(Control control)
        {
            foreach (Control ct in control.Controls)
            {
                ct.Dispose();
            }
            this.Controls.Remove(control);
            control.Dispose();
        }

        #endregion

        #region "계좌 저장"
        private void bt_AddAcount_save_Click(object sender, EventArgs e)
        {
            try
            {

                //만약 이 모듈이 외부에서 필요하다고 하면 어떻게 분리해서 제공해야 좋을까?
                // 내 생각엔 이 자리에서 AccountDto 를 제작한 뒤에 넘겨서 검증을 하고, 완성된 Account를 넘겨주고, 이 기능이 service 에 있으면 어떨까 싶음

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

            List<AmountConditionOfInterest> amountConditions = new List<AmountConditionOfInterest>();
            List<PeriodConditionOfInterest> periodConditions = new List<PeriodConditionOfInterest>();

            SetConditionValues(ref periodConditions, ref amountConditions);


            //여기는 나중에 개선 한번 해야할듯 .. 
            account = new Account()
            {
                Name = txt_AccountName.Text,
                AccountId = long.Parse(txt_AccountNumber.Text),
                Name_AccountId = $"{txt_AccountName.Text}_{txt_AccountNumber.Text}",
                Interest = decimal.Parse(txt_Interest.Text) / 100,
                SettlePeriod = int.Parse(txt_SettlePeriod.Text),
                SettlePeriodType = (SettlePeriodType)cb_SettlePeriod.SelectedItem,
                SettleType = (SettleType)cb_SettleType.SelectedItem,
                UserCode = 1L, // 임시로 이렇게 할 예정,
                checkUpperLimitWellInterest = ch_CheckPreferent.Checked && decimal.Parse(txt_Preferent.Text.Replace(",", "")) > 0,
                UpperLimitWellInterest = ch_CheckPreferent.Checked ? decimal.Parse(txt_Preferent.Text.Replace(",", "")) : 0,
                amountConditions = amountConditions,
                periodConditions = periodConditions, // 이 둘은 나중에 또 따로 관리
            };

        }

        // 이것도 서비스로 옮긴다 하면 저장되어있는 밑단에 있는 SetPeriodConditions, SetAmountConditions 이 두개를 옮기는게 나을듯.
        private void SetConditionValues(ref List<PeriodConditionOfInterest> periodConditions, ref List<AmountConditionOfInterest> amountConditions)
        {

            for (int i = 0; i < ConditionControler.Count; i++)
            {
                if (GetControlValue<Label>(this, $"{AddConditionType.기간}{i}") == AddConditionType.기간.ToString())
                {
                    GetConditionValues(i, out string start, out string end, out string interest, out int sign);

                    SetPeriodConditions(periodConditions, start, end, interest,sign);

                }
                else if (GetControlValue<Label>(this, $"{AddConditionType.금액}{i}") == AddConditionType.금액.ToString())
                {
                    GetConditionValues(i, out string start, out string end, out string interest,out int sign);

                    SetAmountConditions(amountConditions, start, end, interest, sign);
                }
            }
        }
        private void GetConditionValues(int i, out string start, out string end, out string interest,out int sign)
        {
            start = GetControlValue<TextBox>(this, $"{txt_Condition_st}{i}");
            end = GetControlValue<TextBox>(this, $"{txt_Condition_ed}{i}");
            interest = GetControlValue<TextBox>(this, $"{txt_Condition_interest}{i}");
            sign = GetControl<Button>(this, $"{bt_Condition_interest}{i}").Text.Equals("+") ? 1 : -1;
        }


        // 이거 두개 잘하면 합침 .. 
        private void SetPeriodConditions(List<PeriodConditionOfInterest> periodConditions, string start, string end, string interest, int sign)
        {

            // 조건 식은 따로 메소드로 빼는 것도 괜찮아보임
            if (int.TryParse(start, out int startValue)
                && int.TryParse(end, out int endValue)
                && decimal.TryParse(interest, out decimal interestValue)
                && startValue < endValue)
            {
                PeriodConditionOfInterest condition = new PeriodConditionOfInterest()
                {
                    StartValue = startValue,
                    EndValue = endValue,
                    ChangedValue = (interestValue / 100) * sign,
                };
                periodConditions.Add(condition);
            }
            else
            {
                throw new Exception("우대 금리 조건에 잘못된 값이 있습니다. 확인 바랍니다.");
            }
        }

        private void SetAmountConditions(List<AmountConditionOfInterest> amountConditions, string start, string end, string interest,int sign)
        {
            if (decimal.TryParse(start, out decimal startValue) 
                && decimal.TryParse(end, out decimal endValue) 
                && decimal.TryParse(interest, out decimal interestValue)
                && startValue < endValue)
            {
                AmountConditionOfInterest condition = new AmountConditionOfInterest()
                {
                    StartValue = startValue,
                    EndValue = endValue,
                    ChangedValue = (interestValue / 100) * sign,
                };
                amountConditions.Add(condition);
            }
            else
            {
                throw new Exception("우대 금리 조건에 잘못된 값이 있습니다. 확인 바랍니다.");
            }
        }

        private void SaveAccount(Account myAccount)
        {
            accountService.AddAcount(myAccount);
        }

        #endregion

        #region "창 닫기

        private void bt_AddAcount_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion
  
    }
}

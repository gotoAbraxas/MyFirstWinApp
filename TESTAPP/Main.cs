using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.domain.account;
using TESTAPP.domain.account.sub;
using static TESTAPP.common.component.Dynamic;

namespace TESTAPP
{
    public partial class Main : Form
    {

        #region "속성

        private AccountService accountService;

        List<Control> ConditionControler = new List<Control>();

        private readonly string txt_Condition = "txt_Condition";
        private readonly string ch_Condition = "ch_Condition";
        private readonly string bt_Condition = "bt_Condition";
        private readonly string dtp_Condition = "dtp_Condition";
        private readonly string lb_Condition = "lb_Condition";
        private readonly string cb_Condition = "cb_Condition";
        #endregion

        #region "생성자"
        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            accountService = new AccountService(); // 나중에 di로 설정 가능하려나.
            SetCalProfitTabPeriod();
            InitDate();

        }

        private void InitDate()
        {
            dt_From.MinDate = DateTime.Now;
            dt_To.MinDate = DateTime.Now.AddDays(1);
        }

        #endregion

        #region "계좌 선택 항목"
        private void SelectAccounts()
        {
            cb_SelectAccount.Items.Clear();

            Dictionary<long, Account> accounts = accountService.GetAcountsById(1L);

            cb_SelectAccount.DisplayMember = "Name_AccountId";

            foreach (Account account in accounts.Values)
            {
                // cb_SelectAccount.Items.Add($"{account.Name}_{account.AccountId}");
                cb_SelectAccount.Items.Add(account);
            }
        }

        #endregion

        #region "콤보박스 선택된 인덱스 변경시"

        private void cb_SelectAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account ac = GetSelectedAccount();
            if (ac is null) return;

            AccountLogSetting(ac);
            SetCalProfitTabValue(ac);


            foreach (Control control in ConditionControler)
            {
                this.Controls.Remove(control);
                control.Dispose();
            }
            ConditionControler.Clear();
        }

        #endregion

        #region "이자 계산시 단위 설정"
        private void SetCalProfitTabPeriod()
        {
            SetEnumToCombo<Period>(cb_CalProfitTab_Period);
            cb_CalProfitTab_Period.SelectedIndex = 0;
        }
        #endregion

        #region "현재 콤보박스에 선택된 계좌 들고오기"

        private Account GetSelectedAccount()
        {

            Account name = cb_SelectAccount.SelectedItem as Account;

            if (name != null)
            {
                accountService.SelectAccountById(1L, name.AccountId);
                // 굳이 이 과정이 필요한가 싶긴함.. 나중에 수정 필요
            }
            return name;
        }

        #endregion

        #region "혹시 모를 리프레쉬 버튼"
        private void bt_Refresh_Click(object sender, EventArgs e)
        {
            SelectAccounts();
            AccountLogSetting();
        }
        private void bt_Refresh_log_Click(object sender, EventArgs e)
        {
            Account ac = GetSelectedAccount();

            if (ac is null) return;

            AccountLogSetting(ac);
        }

        #endregion

        #region "각 탭을 누를때 마다 초기화 후 값 세팅"
        private void tranHis_Onclick(object sender, EventArgs e)
        {
            Account ac = GetSelectedAccount();

            if (ac is null) return;
            AccountLogSetting(ac); // 데이터를 세팅

        }

        private void calProfitTab_Enter(object sender, EventArgs e)
        {
            Account ac = GetSelectedAccount();

            if (ac is null) return;

            SetCalProfitTabValue(ac);

        }

        #endregion

        #region "동적 조건 추가"

        private void bt_addCondition_Click(object sender, EventArgs e)
        {
            AddCondition();

        }

        private void AddCondition()
        {
            FlowLayoutPanel layout = new FlowLayoutPanel();

            DateTime standard = DateTime.Now.Date.AddDays(1);
            DateTimePicker dtp = new DateTimePicker();
            dtp.MinDate = standard;

            ComboBox cb = new ComboBox();
            SetEnumToCombo<AccountLogType>(cb);
            cb.SelectedIndex = 0;
            cb.DropDownStyle = ComboBoxStyle.DropDownList; // 나중엔 콤보박스도 따로 만들면 좋긴할듯 .?

            DynamicInsert<FlowLayoutPanel>(this, layout, flowLayoutPanel, width: flowLayoutPanel.Width-10, height: 40);

            DynamicInsert<DateTimePicker>(this, dtp, layout, $"{dtp_Condition}{ConditionControler.Count}", "", 110, 30);
            DynamicAmountInsert(this, new TextBox(), layout, $"{txt_Condition}{ConditionControler.Count}", "", 120, 30);
            DynamicLabelInsert(this, new Label(), layout, $"{lb_Condition}{ConditionControler.Count}", "원", 25, 30);
            DynamicInsert<ComboBox>(this, cb, layout, $"{cb_Condition}{ConditionControler.Count}", "", 50, 30);
            ConditionControler.Add(layout);
        }


        #endregion

        #region "계좌 추가 폼 관련"
        private void bt_AddAcount_Click(object sender, EventArgs e)
        {
            AddAcount addAcount = new AddAcount();

            addAcount.FormClosed += WhenAddAcountClosed;
            OpenNewForm<AddAcount>(addAcount);
        }

        private void WhenAddAcountClosed(object sender, EventArgs e)
        {
            SelectAccounts();

            Account ac = GetSelectedAccount();

            AccountLogSetting();
            InitCalProfitTabValue();

        }

        #endregion

        #region "로그 폼 관련"
        private void bt_AddAccountLog_Click(object sender, EventArgs e)
        {

            Account account = GetSelectedAccount();

            if (account != null)
            {
                AddAccountLog tmp = new AddAccountLog();
                tmp.FormClosed += WhenAddAccountLogClosed;
                tmp.Usercode = 1L;
                tmp.AccountId = account.AccountId;

                OpenNewForm<AddAccountLog>(tmp);

            }
            else
            {
                MessageBox.Show("계좌를 우선 선택 바랍니다.");
            }
        }
        private void WhenAddAccountLogClosed(object sender, EventArgs e)
        {
            Account ac = GetSelectedAccount();
            AccountLogSetting(ac);
            SetCalProfitTabValue(ac);
        }

        #endregion

        #region "거래내역 세팅 메소드"

        private void AccountLogSetting()
        {
            DataTable dt = AccountLogInit();
            grid_accountLog.DataSource = dt;
        }
        private void AccountLogSetting(Account account)
        {
            DataTable dt = AccountLogInit();

            txt_Amount.Text = string.Format("{0:#,##0}", account.Amount);

            var sortedLogs = account.Log.OrderBy(log => log.DateTime).ToList(); // 정렬

            foreach (AccountLog item in sortedLogs)
            {
                dt.Rows.Add("sample", item.DateTime, item.AccountLogType, string.Format("{0:#,##0}", item.Amount), string.Format("{0:#,##0}", item.Total), item.Description);
            }

            grid_accountLog.DataSource = dt;


        }
        private DataTable AccountLogInit()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("날짜", typeof(DateTime));
            dt.Columns.Add("입/출금", typeof(AccountLogType));
            dt.Columns.Add("금액", typeof(string));
            dt.Columns.Add("잔액", typeof(string));
            dt.Columns.Add("비고", typeof(string));

            grid_accountLog.DataSource = dt;

           

            return dt;
        }

        #endregion

        #region "이자 계산 정보 초기화 및 세팅"
        private void InitCalProfitTabValue()
        {
            txt_CalProfitTab_Interest.Text = "";
            txt_CalProfitTab_InterestType.Text = "";
            txt_CalProfitTab_InterestPeriod.Text = "";
            txt_CalProfitTab_Amount.Text = "";
            txt_CalProfitTab_UpperLimit.Text = "";
            txt_CalProfitTab_Available.Text = "";
        }

        private void SetCalProfitTabValue(Account account)
        {
            txt_CalProfitTab_Interest.Text = $"{(account.Interest * 100)}%";
            txt_CalProfitTab_InterestType.Text = $"{account.SettleType}";
            txt_CalProfitTab_InterestPeriod.Text = $"{account.SettlePeriod}{account.SettlePeriodType}";
            txt_CalProfitTab_Amount.Text = $"{string.Format("{0:#,##0}", account.Amount)} 원";
            txt_CalProfitTab_UpperLimit.Text = account.checkUpperLimitWellInterest ? $"{string.Format("{0:#,##0}", account.UpperLimitWellInterest)} 원" : "없음";
            txt_CalProfitTab_Available.Text = $"{(MaxInterest(account) + account.Interest) * 100}%";
        }

        private decimal MaxInterest(Account account)
        {

            decimal pc = account.periodConditions
                 .Where((condition) => condition.Applyed)
                 .Select((condition) => condition.ChangedValue)
                 .Sum();
            decimal ac = account.amountConditions
                 .Where((condition) => condition.Applyed)
                 .Select((condition) => condition.ChangedValue)
                 .Sum();

            return pc + ac;
        }
        #endregion

        #region "우대 이율 조건 보기"
        private void bt_CalProfitTab_Available_Click(object sender, EventArgs e)
        {
            Account ac = GetSelectedAccount();

            if (ac is null)
            {
                MessageBox.Show("계좌를 먼저 선택해 주십시오");
                return;
            }

            AccountCondition accountCondition = new AccountCondition();

            accountCondition.FormClosed += WhenAccountConditionClosed;
            accountCondition.Usercode = 1L;
            accountCondition.AccountId = ac.AccountId;

            OpenNewForm<AccountCondition>(accountCondition);
        }

        private void WhenAccountConditionClosed(object sender, EventArgs e)
        {
            // 새로고침 그런거 ..
        }
        #endregion

        #region "이자 계산, 동적계획 및 검증"

        #region "계산"
        private void bt_Calculate_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now.Date;
            DateTime from = dt_From.Value.Date;
            DateTime until = dt_To.Value.Date;
            Account account = GetSelectedAccount();
            if (account is null)
            {
                MessageBox.Show("계좌를 먼저 선택해주세요.");
                return;
            }
            else if (account.Amount <= 0)
            {
                MessageBox.Show($"통장에 돈이 없습니다.");
                return;
            }

            ViewVirtualLog form = new ViewVirtualLog();
            form.StartPosition = FormStartPosition.CenterScreen;

            form.VirtualDto = new VirtualDto
            {
                Now = now,
                From = from,
                Until = until,
                AccountId = account.AccountId,
                UserCode = account.UserCode,

            };

            form.afterPlans = GetAferPlan();
            form.period = (Period)cb_CalProfitTab_Period.SelectedItem;

            form.Show();
        }

        #endregion

        #region "입출금 계획 동적 세팅"
        private List<AfterPlan> GetAferPlan()
        {
            List<AfterPlan> aps = new List<AfterPlan>();

            for(int i = 0; i < ConditionControler.Count; i++)
            {
                aps.Add(new AfterPlan()
                {
                    AccountLogType = (AccountLogType) GetControl<ComboBox>(this, $"{cb_Condition}{i}").SelectedItem,
                    Amount = decimal.Parse(GetTxtAmountPretty(this, $"{txt_Condition}{i}")),
                    DateTime = GetControl<DateTimePicker>(this, $"{dtp_Condition}{i}").Value.Date,
                    Description = "입/출금 계획"
                });
            }

            aps = aps.OrderBy((item)=> item.DateTime).ToList();

            return aps;
        }
        #endregion

        #region "검증"
        private void dt_From_ValueChanged(object sender, EventArgs e)
        {
            ValidateDateTime(sender);
        }

        private void dt_To_ValueChanged(object sender, EventArgs e)
        {
            ValidateDateTime(sender);
        }

        private void ValidateDateTime(object sender)
        {
            var dtp = sender as DateTimePicker;

            if (dt_From.Value.Date.CompareTo(dt_To.Value.Date) > 0)
            {
                MessageBox.Show("시작기간은 끝 기간을 넘어설 수 없습니다.");
                dtp.Value = DateTime.Now;
            }

            if (DateTime.Now.Date.CompareTo(dt_From.Value.Date) > 0)
            {
                MessageBox.Show("기간은 오늘 이후로만 선택 가능합니다.");
                dtp.Value = DateTime.Now;
            }
        }
        #endregion

        #endregion

    }
}

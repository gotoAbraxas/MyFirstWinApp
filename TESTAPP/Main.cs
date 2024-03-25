using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.domain.account;
using TESTAPP.domain.account.sub;
using static TESTAPP.common.component.Dynamic;
using TESTAPP.database;

namespace TESTAPP
{
    public partial class Main : Form
    {

        #region "속성

        private AccountService accountService;
        Dictionary<string,Control> ConditionControler = new Dictionary<string,Control>();
        List<Control> AccountList = new List<Control>();

        SearchCondition Condition = new SearchCondition();

        private readonly string txt_Condition = "txt_Condition";
        private readonly string dtp_Condition = "dtp_Condition";
        private readonly string lb_Condition = "lb_Condition";
        private readonly string cb_Condition = "cb_Condition";

        private bool Selected = false;
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

        #region "계좌 콤보박스 인덱스 변경시"

        private void cb_SelectAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account ac = GetSelectedAccount();
            if (ac is null) return;

            AccountLogSetting(ac);
            SetCalProfitTabValue(ac);

            ResetCondition();
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

        #region "현재 콤보박스에 선택된 계좌 들고오기"

        private Account GetSelectedAccount()
        {
            Account name = cb_SelectAccount.SelectedItem as Account;

            if (name != null)
            {
                // 굳이 이 과정이 필요한가 싶긴함.. 나중에 수정 필요
                accountService.SelectAccountById(1L, name.AccountId);
            }
            return name;
        }

        #endregion

        #region "거래내역 세팅 메소드"

        private void AccountLogSetting()
        {
            DataTable dt = AccountLogInit();

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

        #region "이자 계산시 단위 콤보박스 설정"
        private void SetCalProfitTabPeriod()
        {
            SetEnumToCombo<Period>(cb_CalProfitTab_Period);
            cb_CalProfitTab_Period.SelectedItem = Period.내역;
        }
        #endregion

        #region "혹시 모를 리프레쉬 버튼"
        private void bt_Refresh_Click(object sender, EventArgs e)
        {
            SelectAccounts();
            AccountLogSetting();
            InitCalProfitTabValue();

        }
        private void bt_Refresh_log_Click(object sender, EventArgs e)
        {
            Account ac = GetSelectedAccount();

            if (ac is null) return;
            AccountLogSetting(ac);
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
            string id = Guid.NewGuid().ToString();
            Button cancel = DeleteCondition(id);

            DateTime standard = DateTime.Now.Date.AddDays(1);
            DateTimePicker dtp = new DateTimePicker();
            dtp.MinDate = standard;
            dtp.Value = standard;

            ComboBox cb = new ComboBox();
            SetEnumToCombo<AccountLogType>(cb);
            cb.SelectedItem = AccountLogType.입금;
            cb.DropDownStyle = ComboBoxStyle.DropDownList; // 나중엔 콤보박스도 따로 만들면 좋긴할듯 .?
    
            DynamicInsert<FlowLayoutPanel>(this, layout, flowLayoutPanel, width: flowLayoutPanel.Width-10, height: 40);

            DynamicInsert<DateTimePicker>(this, dtp, layout, $"{dtp_Condition}{ConditionControler.Count}", 110, 30);
            DynamicAmountInsert(this, new TextBox(), layout, $"{txt_Condition}{ConditionControler.Count}", 120, 30);
            DynamicLabelInsert(this, new Label(), layout, $"{lb_Condition}{ConditionControler.Count}", "원", 25, 30);
            DynamicInsert<ComboBox>(this, cb, layout, $"{cb_Condition}{ConditionControler.Count}", 50, 30);
            DynamicInsert<Button>(this, cancel, layout, id, width: 40, height: 20);

            ConditionControler.Add(id,layout);
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

        #region "동적 조건 추가 삭제/리셋"

        private void bt_ResetCondition_Click(object sender, EventArgs e)
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

        #region "계좌 추가 폼 관련"
        private void bt_AddAcount_Click(object sender, EventArgs e)
        {

            var sat = new SelectAccountTypeDialog();
            sat.ShowDialog();

            if (sat.Result is null) return;
            
            AccountType type = (AccountType)sat.Result;

            switch (type)
            {
                case AccountType.자유입출금:
                    break;
                case AccountType.저축성예금:
                    break;
                case AccountType.직접입력:
                    AddAcount addAcount = new AddAcount();

                    addAcount.FormClosed += WhenAddAcountClosed;
                    OpenNewForm<AddAcount>(addAcount);
                    break;

            }
        }

        private void WhenAddAcountClosed(object sender, EventArgs e)
        {
            SelectAccounts();

            Account ac = GetSelectedAccount();

            AccountLogSetting();
            InitCalProfitTabValue();


            var acList = accountService.GetAcountsById(1L);
            GetList(acList);
        }

        private void GetList(Dictionary<long,Account> list)
        {
            flp_AccountList.Controls.Clear();

           
            foreach (var item in list)
            {
                Test(item.Value);
            }
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
            txt_CalProfitTab_UpperLimit.Text = account.CheckUpperLimitWellInterest ? $"{string.Format("{0:#,##0}", account.UpperLimitWellInterest)} 원" : "없음";
            txt_CalProfitTab_Available.Text = $"{(MaxInterest(account) + account.Interest) * 100}%";
        }

        private decimal MaxInterest(Account account)
        {

            decimal pc = account.PeriodConditions
                 .Where((condition) => condition.Applyed)
                 .Select((condition) => condition.ChangedValue)
                 .Sum();
            decimal ac = account.AmountConditions
                 .Where((condition) => condition.Applyed)
                 .Select((condition) => condition.ChangedValue)
                 .Sum();

            return pc + ac;
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

            if (dt_From.Value.Date.CompareTo(dt_To.Value.Date) >= 0)
            {
                MessageBox.Show("시작기간은 끝 기간을 넘어설 수 없습니다.");
                return;
            }

            ViewVirtualLog form = new ViewVirtualLog
            {
                StartPosition = FormStartPosition.CenterScreen,

                VirtualDto = new VirtualDto
                {
                    Now = now,
                    From = from,
                    Until = until,
                    AccountId = account.AccountId,
                    UserCode = account.UserCode,

                },

                afterPlans = GetAferPlan(),
                period = (Period)cb_CalProfitTab_Period.SelectedItem
            };

            form.ShowDialog();
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
                    Amount = decimal.TryParse(GetTxtAmountPretty(this, $"{txt_Condition}{i}"),out decimal result) ? result : 0,
                    DateTime = GetControl<DateTimePicker>(this, $"{dtp_Condition}{i}").Value.Date,
                    Description = "입/출금 계획"
                });
            }
            aps = aps.OrderBy((item)=> item.DateTime).ToList();

            return aps;
        }

        #endregion

        #endregion


        private void Test(Account account)
        {

            Panel pl = new Panel
            {
                Height = 100,
                Padding = new Padding(0, 10, 0, 0),
                BackColor = Color.White
            };
            //pl.Dock = DockStyle.Fill;
            Label lb = new Label
            {
                Location = new Point(0, 0),
                BackColor = Color.AliceBlue
            };

            Label lb2 = new Label
            {
                Location = new Point(200, 0),
                BackColor = Color.AliceBlue
            };
            Label lb3 = new Label
            {
                Location = new Point(300, 0),
                BackColor = Color.AliceBlue
            };
            DynamicInsert<Panel>(this, pl, flp_AccountList,width:flp_AccountList.Width-10);
            DynamicLabelInsert(this, lb, pl, name: "일단테스트", text: $"계좌 이름: {account.Name}", width: 140,height:30);
            DynamicLabelInsert(this, lb2, pl, name: "일단테스트", text: $"이율: {account.Interest *100} %", width: 100,height:20); ;
            DynamicLabelInsert(this, lb3, pl, name: "일단테스트", text: "우대이율: 4%", width: 100, height:20); ;


            CheckBox cb = new CheckBox()
            {
                Location = new Point(370, 30),
            };
            cb.Text = "적용";
            DynamicInsert<CheckBox>(this, cb, pl, width: 60, height: 20) ;

            AccountList.Add(pl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var acList = accountService.GetAcountsByIdWithCondition(1L, Condition);
            GetList(acList);
        }

        private void SearchCondition()
        {
            
           var acList = accountService.GetAcountsByIdWithCondition(1L, Condition) ;

            GetList(acList);
        }

        private void cb_accountTab_AccountCondition_CheckedChanged(object sender, EventArgs e)
        {
            SearchCondition();

        }

        private void cb_accountTab_PeriodCondition_CheckedChanged(object sender, EventArgs e)
        {
            SearchCondition();
        }

        private void bt_accountTab_AccountCondition_Click(object sender, EventArgs e)
        {
            if (Condition.AmountCondition)
            {
                Condition.AmountCondition = false;
                bt_accountTab_AccountCondition.ForeColor = Color.Black;
            }
            else
            {
                Condition.AmountCondition = true;
                bt_accountTab_AccountCondition.ForeColor = Color.Red;
            }
            SearchCondition();
        }

        private void bt_accountTab_PeriodCondition_Click(object sender, EventArgs e)
        {
            if (Condition.PeriodCondition)
            {
                Condition.PeriodCondition = false;
                bt_accountTab_PeriodCondition.ForeColor = Color.Black;
            }
            else
            {
                Condition.PeriodCondition = true;
                bt_accountTab_PeriodCondition.ForeColor = Color.Red;
            }
            SearchCondition();
        }
    }
}

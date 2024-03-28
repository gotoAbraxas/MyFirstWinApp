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
        private Dictionary<string,Control> ConditionControler = new Dictionary<string,Control>();
        private List<Control> AccountList = new List<Control>();
        private List<long> SelectedAccounts = new List<long>();

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
            SelectAccounts();
            SearchCondition();
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
    
            DynamicInsert<FlowLayoutPanel>(layout, flowLayoutPanel, width: flowLayoutPanel.Width-10, height: 40);

            DynamicInsert<DateTimePicker>(dtp, layout, $"{dtp_Condition}{ConditionControler.Count}", 110, 30);
            DynamicAmountInsert(new TextBox(), layout, $"{txt_Condition}{ConditionControler.Count}", 120, 30);
            DynamicLabelInsert(new Label(), layout, $"{lb_Condition}{ConditionControler.Count}", "원", 25, 30);
            DynamicInsert<ComboBox>(cb, layout, $"{cb_Condition}{ConditionControler.Count}", 50, 30);
            DynamicInsert<Button>(cancel, layout, id, width: 40, height: 20);

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


            SearchCondition();
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

        #region "검색 조건 설정 후 검색"
        private void SearchCondition()
        {
            var acList = accountService.GetAcountsByIdWithCondition(1L, Condition);
            SetList(acList);
        }

        private void bt_accountTab_AccountCondition_Click(object sender, EventArgs e)
        {
            if (Condition.AmountCondition)
            {
                Condition.AmountCondition = false;
                bt_accountTab_AccountCondition.ForeColor = Color.Black;
                bt_accountTab_AccountCondition.Font = new Font(this.Font, FontStyle.Regular);

            }
            else
            {
                Condition.AmountCondition = true;
                bt_accountTab_AccountCondition.ForeColor = Color.Green;
                bt_accountTab_AccountCondition.Font = new Font(this.Font, FontStyle.Bold);

            }
            SearchCondition();
        }

        private void bt_accountTab_PeriodCondition_Click(object sender, EventArgs e)
        {
            if (Condition.PeriodCondition)
            {
                Condition.PeriodCondition = false;
                bt_accountTab_PeriodCondition.ForeColor = Color.Black;
                bt_accountTab_PeriodCondition.Font = new Font(this.Font, FontStyle.Regular);

            }
            else
            {
                Condition.PeriodCondition = true;
                bt_accountTab_PeriodCondition.ForeColor = Color.Green;
                bt_accountTab_PeriodCondition.Font = new Font(this.Font, FontStyle.Bold);
            }
            SearchCondition();
        }


        #endregion

        #region "조건에 맞게 리스트 만들기"
        private void SetList(Dictionary<long, Account> list)
        {
            flp_AccountList.Controls.Clear();
            AccountList.Clear();


            foreach (var item in list)
            {
                DynamicAccountList(item.Value);
            }
        }

        #endregion

        #region "계좌 리스트 동적 생성"
        private void DynamicAccountList(Account account)
        {

            Panel panel = new Panel
            {
                Height = 100,
                Padding = new Padding(0, 10, 0, 0),
                BackColor = Color.White,
                //AutoSize = true,
                
            };
            //pl.Dock = DockStyle.Fill;
            Label accountName = new Label
            {
                Location = new Point(60, 0),
                Padding = new Padding(4,4,0,0),
                Font = new Font("Malgun Gothic", 14, FontStyle.Regular),
                AutoSize = true,
            };

            Label accountInterest = new Label
            {
                Location = new Point(300, 30),
                Font = new Font("Malgun Gothic", 9, FontStyle.Regular),
            };
            Label accountConditionInterest = new Label
            {
                Location = new Point(300, 0),
                ForeColor = Color.Green,
                Font = new Font("Malgun Gothic", 11,FontStyle.Bold),
                AutoSize = true
            };

            CheckBox selectbox = new CheckBox()
            {
                Padding = new Padding(4, 4, 0, 0),
                Location = new Point(0, 0),
                Text = "선택"
            };

            if(SelectedAccounts.Contains(account.AccountId)){
                selectbox.Checked = true;
            }
            
            selectbox.CheckedChanged += (sender, o) =>
            {
               var cbox =  sender as CheckBox;
                if (cbox.Checked && !SelectedAccounts.Contains(account.AccountId))
                {
                    MarkAccount(account.AccountId,account.Name);
                    SelectedAccounts.Add(account.AccountId);
                }
                else if(!cbox.Checked)
                {
                    DeleteAccount(account.AccountId);
                    SelectedAccounts.Remove(account.AccountId);
                }
            };
            decimal ConditionInterest = account.Interest;
            ConditionInterest += account.AmountConditions.Where((item) => item.ChangedValue > 0).Select((item) => item.ChangedValue).Sum();
            ConditionInterest += account.PeriodConditions.Where((item) => item.ChangedValue > 0).Select((item) => item.ChangedValue).Sum();

            DynamicInsert<Panel>(panel, flp_AccountList,name:$"{account.AccountId}",width:flp_AccountList.Width-30);
            DynamicLabelInsert(accountName, panel, name: "일단테스트", text: $"{account.Name}", width: 140,height:30);
            DynamicLabelInsert(accountInterest, panel, name: "일단테스트", text: $"기본: {account.Interest *100} %", width: 100,height:20); ;
            DynamicLabelInsert(accountConditionInterest, panel, name: "일단테스트", text: $"최고: {ConditionInterest * 100} %", width: 100, height:20); ;

            DynamicInsert<CheckBox>(selectbox, panel,name:$"cb_{account.AccountId}", width: 60, height: 20) ;

            AccountList.Add(panel);
        }

        private void MarkAccount(long accountid,string name)
        {
            Button bt = new Button
            {
                Text = $"{name} X",
                AutoSize = true
            };
            bt.Click += (sender, o) =>
            {
                GetControl<CheckBox>(flp_AccountList, $"cb_{accountid}").Checked = false;
                flp_SelectedAccounts.Controls.Remove(bt);
            };
            DynamicInsert<Button>(bt, flp_SelectedAccounts,name:$"{accountid}", width: 50, height: 25);
        }

        private void DeleteAccount(long accountid)
        {
            Button bt = GetControl<Button>(flp_SelectedAccounts, accountid.ToString());
            flp_SelectedAccounts.Controls.Remove(bt);
        }
        #endregion

        #region "전체 선택"

        private void AllSelect()
        {
            List<string> accountNames = AccountList.Select(item => item.Name).ToList();
            List<string> selectedAccountKeys = SelectedAccounts.Select(item => item.ToString()).ToList();

            int countMatchingNames = accountNames.Count(name => selectedAccountKeys.Contains(name));

            if (SelectedAccounts.Any()
                && accountNames.Count <= countMatchingNames)
            {
                AccountList.ForEach((item) =>
                {
                    CheckBox cb = GetControl<CheckBox>(item, $"cb_{item.Name}"); 
                    cb.Checked = false;  
                });
            }
            else
            {
                AccountList.ForEach((item) =>
                {
                   CheckBox cb =  GetControl<CheckBox>(item, $"cb_{item.Name}");
                        cb.Checked = true;
                }); 
            }
        }

        #endregion

        private void bt_accountTab_Refresh_Click(object sender, EventArgs e)
        {
            var acList = accountService.GetAcountsByIdWithCondition(1L, Condition);
            SetList(acList);
        }

        private void bt_accountTab_AllSelect_Click(object sender, EventArgs e)
        {
            AllSelect();
        }

        private void txt_accountTab_Amount_TextChanged(object sender, EventArgs e)
        {
            SetTxtAmountPretty(this, (sender as TextBox).Name);
        }

        private void bt_accountTab_MakePlan_Click(object sender, EventArgs e)
        {

            if(!decimal.TryParse(txt_accountTab_Amount.Text.Replace(",",""),out decimal Amountresult) && Amountresult <= 0)
            {
                MessageBox.Show("금액이 잘못되었습니다.");
                return;
            }
            if(!int.TryParse(txt_accountTab_Period.Text,out int PeriodResult)&& PeriodResult <= 0)
            {
                MessageBox.Show("기간이 잘못되었습니다.");
                return;
            }
            if (!SelectedAccounts.Any())
            {
                MessageBox.Show("선택된 상품이 없습니다.");
                return;
            }


            var fm = new InvestPlanning
            {
                Amounts = Amountresult,
                Period = PeriodResult,
                AccountIds = SelectedAccounts
            };

            OpenNewForm(fm);
        }

        private void ch_accountTab_AccountProtect_CheckedChanged(object sender, EventArgs e)
        {

            if (ch_accountTab_AccountProtect.Checked)
            {
                Condition.Protected = true;
            }
            else
            {
                Condition.Protected = false;
            }
            SearchCondition();
        }
    }
}

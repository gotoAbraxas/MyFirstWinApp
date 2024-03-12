using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.common.component;
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

        #endregion

        #region "생성자"
        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            accountService = new AccountService(); // 나중에 di로 설정 가능하려나.
        }

        #endregion

        #region "거래내역 세팅 메소드"
        private void AccountLogSetting()
        {
            DataTable dt = AccountLogInit();

            Account account = GetSelectedAccount();

            if (account != null)
            {
                txt_Amount.Text = string.Format("{0:#,##0}", account.Amount);

                var sortedLogs = account.Log.OrderBy(log => log.DateTime).ToList(); // 정렬

                foreach (AccountLog item in sortedLogs)
                {
                    dt.Rows.Add("sample", item.AccountLogType, item.Amount, item.DateTime);
                }
            }
            grid_accountLog.DataSource = dt;


        }
        private DataTable AccountLogInit()
        {


            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("입/출금", typeof(AccountLogType));
            dt.Columns.Add("금액", typeof(decimal));
            dt.Columns.Add("날짜", typeof(DateTime));

            grid_accountLog.DataSource = dt;

            return dt;
        }

        #endregion

        #region "계좌 선택 항목"
        private void SelectAccounts()
        { 
            cb_SelectAccount.Items.Clear();

            Dictionary<long,Account>  accounts = accountService.GetAcountsById(1L);

            cb_SelectAccount.DisplayMember = "Name_AccountId";

            foreach ( Account account in accounts.Values)
            {
               // cb_SelectAccount.Items.Add($"{account.Name}_{account.AccountId}");
                cb_SelectAccount.Items.Add(account);
            }
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
            AccountLogSetting();
        }

        #endregion

        // 일단 임시
        private void tranHis_Onclick(object sender, EventArgs e)
        {
            AccountLogSetting(); // 데이터를 세팅

        }
        private void accountTab_OnClick(object sender, EventArgs e)
        {
        }

        //

        #region "콤보박스 선택된 인덱스 변경시"

        private void cb_SelectAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccountLogSetting();
        }

        #endregion

        #region "현재 콤보박스에 선택된 계좌 들고오기"

        private Account GetSelectedAccount()
        {

            Account name = cb_SelectAccount.SelectedItem as Account;
            
            if (name != null) { 
            accountService.SelectAccountById(1L, name.AccountId);
            // 굳이 이 과정이 필요한가 싶긴함.. 나중에 수정 필요
            }
            return name;
        }

        #endregion

        #region "임시"
        // ------------------ 임시

        private void button1_Click(object sender, EventArgs e)
        {
            AddCondition();

        }

        private void AddCondition()
        {
            FlowLayoutPanel layout = new FlowLayoutPanel();

            DynamicInsert<FlowLayoutPanel>(this, layout, flowLayoutPanel, width: flowLayoutPanel.Width, height: 40);

            DynamicInsert<Button>(this, new Button(), layout, $"{bt_Condition}{ConditionControler.Count}", "버튼", 40, 30);
            DynamicInsert<TextBox>(this, new TextBox(), layout, $"{txt_Condition}{ConditionControler.Count}", "", 130, 30);
            DynamicInsert<CheckBox>(this, new CheckBox(), layout, $"{ch_Condition}{ConditionControler.Count}", "항상 적용", 100, 30);
            ConditionControler.Add(layout);
        }

        // ------------------ 임시

        #endregion

        #region "계좌 추가 폼 관련"
        private void bt_AddAcount_Click(object sender, EventArgs e)
        {
            AddAcount addAcount = new AddAcount();

            addAcount.FormClosed += WhenAddAcountClosed;
            // 이게 순서가 맞아야 하는 프로그래밍인데 맞나 싶음.
            OpenNewForm<AddAcount>(addAcount);
        }

        private void WhenAddAcountClosed(object sender, EventArgs e)
        {
            SelectAccounts();
            AccountLogSetting();
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
            AccountLogSetting();
        }

        #endregion

        private void bt_Calculate_Click(object sender, EventArgs e)
        {
            DateTime until = dateTimePicker1.Value;
            Account account = GetSelectedAccount();
            if(account is null) 
            {
                MessageBox.Show("계좌를 먼저 선택해주세요.");
                return;
            }

            decimal amount = account.Amount;
            decimal resultinterest = account.Interest;
            decimal resultAmount = 0;
            // 이 작업을 서비스에 정의 ? 아니면 ..
            account.GetResult(ref amount,ref  resultinterest,ref resultAmount, DateTime.Now, until);

            MessageBox.Show($"쌓인 이자 {resultinterest} 최종 금액 {resultAmount}");
        }
    }
}

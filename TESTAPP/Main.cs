using System;
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
using static TESTAPP.common.component.Dynamic;

namespace TESTAPP
{
    public partial class Main : Form
    {
        private AccountService accountService;

        List<Control> ConditionControler = new List<Control>();

        private readonly string txt_Condition = "txt_Condition";
        private readonly string ch_Condition = "ch_Condition";
        private readonly string bt_Condition = "bt_Condition";
        public Main()
        {
            InitializeComponent();

            accountService = new AccountService(); // 나중에 di로 설정 가능하려나.

        }

        private void Init()
        {


            JustTest();
        }

        private void JustTest()
        {
            //MessageBox.Show("초기화");
            var a = test();


            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("name", typeof(string));

            foreach (var b in a)
            {
                dt.Rows.Add(b.Key.ToString(), b.Value.ToString());
            }

            grid_accountLog.DataSource = dt;
        }

        #region "계좌 선택 항목"
        private void SelectAccounts()
        { // 이걸 계좌 추가하면 한번 더 실행하긴해야하는데, 그런 트리거가 있을지 의문
            cb_SelectAccount.Items.Clear();

            Dictionary<long,Account>  accounts = accountService.GetAcountsById(1L);

            foreach ( Account account in accounts.Values)
            {
                cb_SelectAccount.Items.Add(account.Name);
            }
            ViewAccount();
        }

        #endregion

        private Dictionary<int, string> test()
        {
            Dictionary<int, String> test = new Dictionary<int, String>();
            for (int i = 0; i < 10; i++)
            {
                test.Add(i, $"테스트{i}");
            }

            return test;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("name", typeof(string));


            dt.Rows.Add(1, "이태열");


            grid_accountLog.DataSource = dt;
        }




        private void bt_Refresh_Click(object sender, EventArgs e)
        {
            SelectAccounts();
        }

        private void tranHis_Onclick(object sender, EventArgs e)
        {


            Init(); // 데이터를 세팅할건데, 

        }

        private void accountTab_OnClick(object sender, EventArgs e)
        {
            ViewAccount();

        }

        private void ViewAccount()
        {
            if (cb_SelectAccount.Text.Equals(""))
            {
            }
            else
            {
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cb_SelectAccount.SelectedText;
     
                ViewAccount();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DynamicInsert();
            AddCondition();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string a = GetControlValue<TextBox>(this, txt_Condition + "1"); //

            MessageBox.Show(a);
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
        private void btAddAcount_Click(object sender, EventArgs e)
        {
            OpenNewForm<AddAcount>();
        }
        private void bt_AddAccountLog_Click(object sender, EventArgs e)
        {
            OpenNewForm<AddAccountLog>();
        }

    }
}

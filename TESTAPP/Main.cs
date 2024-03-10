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

        private Account account;

        private AccountService accountService;

        List<Control> ConditionControler = new List<Control>();

        private static string ch_Condition = "ch_Condition";
        private static string txt_Condition = "txt_Condition";
        private static string bt_Condition = "bt_Condition";
        public Main()
        {
            InitializeComponent();



            // 내 계좌 리스트를 알아야함.


            comboBox1.Items.Add("ddd");

        }

        private void Init()
        {
            MessageBox.Show("초기화");
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
        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void btAddAcount_Click(object sender, EventArgs e)
        {
            AddAcount a = new AddAcount();
            a.StartPosition = FormStartPosition.CenterScreen;
            a.ShowDialog();
        }

        private void tabPage_3_Onclick(object sender, EventArgs e)
        {


            Init(); // 데이터를 세팅할건데, 

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = comboBox1.SelectedIndex;

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

        // 이건 다이나믹 쪽에 두는게 나을듯.


    }
}

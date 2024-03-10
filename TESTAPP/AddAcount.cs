using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.domain.account;

namespace TESTAPP
{
    public partial class AddAcount : Form
    {
        public AddAcount()
        {


            InitializeComponent();
            cb_AccountType.Items.Add("어쩌구");
            cb_AccountType.Items.Add("기타"); // 이 정보값을 어떻게 세팅할것이냐 의 문제가 있음

            SetSettleType();
        }

        private void AddAcount_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_AddAcount_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_AccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTxtAccountType();
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
            string[] values = typeof(SettleType).GetEnumNames();

            foreach (string value in values)
            {
                cb_SettleType.Items.Add(value);
            }
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bt_AddCondition_Click(object sender, EventArgs e)
        {

        }


    }
}

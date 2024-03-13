using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TESTAPP.account.service;
using TESTAPP.domain.account;
using TESTAPP.domain.account.sub;
using static TESTAPP.common.component.Dynamic;

namespace TESTAPP
{
    public partial class AccountCondition : Form
    {

        private AccountService account;
        public long Usercode { get; set; }
        public long AccountId { get; set; }
        public AccountCondition()
        {
            InitializeComponent();
        }

        private void AccountCondition_Load(object sender, EventArgs e)
        {
            account = new AccountService();// IOC 컨테이너가 없으면 어떻게 관리해야하지.

            InitCondition();
        }

        private void InitCondition()
        {
            Account ac = account.SelectAccountById(Usercode, AccountId);

            
           foreach(AmountCondition amountCondition in ac.amountConditions)
            {
                string start = $"{amountCondition.StartValue}원";
                string end = $"{amountCondition.EndValue}원 ";
                string interest = $"{Math.Round(amountCondition.ChangedValue * 100,0)}";
                DynamicLabelInsert(this, new Label(), flp_Condition, "", "금액", 40, 30);
                DynamicLabelInsert(this, new Label(), flp_Condition, "", start, 120,30);
                DynamicLabelInsert(this, new Label(), flp_Condition, "", "~", 10, 30);
                DynamicLabelInsert(this, new Label(), flp_Condition, "", end, 120, 30);
                DynamicLabelInsert(this, new Label(), flp_Condition, "", "+", 10, 30);
                DynamicLabelInsert(this, new Label(), flp_Condition, "", interest, 20, 30);
                DynamicLabelInsert(this, new Label(), flp_Condition, "", "%", 15, 30);
                DynamicInsert<CheckBox>(this, new CheckBox(), flp_Condition, "테스트","",40,30);
            }

        }
    }
}

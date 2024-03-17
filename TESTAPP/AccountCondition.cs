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
                DrawAmountCondition(amountCondition);
            }
            foreach (PeriodCondition periodCondition in ac.periodConditions)
            {
                DrawPeriodCondition(periodCondition);
            }

        }

        private void DrawAmountCondition(AmountCondition amountCondition)
        {
            string start = $"{String.Format("{0:#,##0}", amountCondition.StartValue)}원";
            string end = $"{String.Format("{0:#,##0}", amountCondition.EndValue)}원";
            string interest = $"{Math.Round(amountCondition.ChangedValue * 100, 0)}";

            FlowLayoutPanel layout = new FlowLayoutPanel();
            DynamicInsert<FlowLayoutPanel>(this, layout, flp_Condition, "", flp_Condition.Width - 10, 35);

            DynamicLabelInsert(this, new Label(), layout, "", "금액", 35, 30);
            DynamicLabelInsert(this, new Label(), layout, "", start, 120, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "~", 10, 30);
            DynamicLabelInsert(this, new Label(), layout, "", end, 120, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "+", 10, 30);
            DynamicLabelInsert(this, new Label(), layout, "", interest, 15, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "%", 15, 30);
            DynamicCheckBox(this, new CheckBox(), layout, amountCondition.Applyed, "적용", 70, 30);
        }
        private void DrawPeriodCondition(PeriodCondition periodCondition)
        {
            string start = $"{periodCondition.StartValue}개월";
            string end = $"{periodCondition.EndValue}개월";
            string interest = $"{Math.Round(periodCondition.ChangedValue * 100, 0)}";

            FlowLayoutPanel layout = new FlowLayoutPanel();
            DynamicInsert<FlowLayoutPanel>(this, layout, flp_Condition, "", flp_Condition.Width - 10, 35);

            DynamicLabelInsert(this, new Label(), layout, "", "기간", 35, 30);
            DynamicLabelInsert(this, new Label(), layout, "", start, 120, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "~", 10, 30);
            DynamicLabelInsert(this, new Label(), layout, "", end, 120, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "+", 10, 30);
            DynamicLabelInsert(this, new Label(), layout, "", interest, 15, 30);
            DynamicLabelInsert(this, new Label(), layout, "", "%", 15, 30);
            DynamicCheckBox(this, new CheckBox(), layout, periodCondition.Applyed, "적용", 70, 30);
        }

        private void bt_AccountCondition_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

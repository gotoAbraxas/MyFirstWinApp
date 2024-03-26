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

            
           foreach(AmountConditionOfInterest amountCondition in ac.AmountConditions)
            {
                DrawAmountCondition(amountCondition);
            }
            foreach (PeriodConditionOfInterest periodCondition in ac.PeriodConditions)
            {
                DrawPeriodCondition(periodCondition);
            }

        }

        private void DrawAmountCondition(AmountConditionOfInterest amountCondition)
        {
            string start = $"{String.Format("{0:#,##0}", amountCondition.StartValue)}원";
            string end = $"{String.Format("{0:#,##0}", amountCondition.EndValue)}원";
            string interest = $"{Math.Abs(Math.Round(amountCondition.ChangedValue * 100, 0))}";

            Label lb = new Label();

            if(amountCondition.ChangedValue >= 0)
            {
                lb.Text = "+";
            }
            else
            {
                lb.Text = "-";
            }


            FlowLayoutPanel layout = new FlowLayoutPanel();
            DynamicInsert<FlowLayoutPanel>(layout, flp_Condition, "", flp_Condition.Width - 10, 35);

            DynamicLabelInsert(new Label(), layout, "", "금액", 35, 30);
            DynamicLabelInsert(new Label(), layout, "", start, 120, 30);
            DynamicLabelInsert(new Label(), layout, "", "~", 15, 30);
            DynamicLabelInsert(new Label(), layout, "", end, 120, 30);
            DynamicLabelInsert(lb, layout, "", lb.Text, 10, 30);
            DynamicLabelInsert(new Label(), layout, "", interest, 15, 30);
            DynamicLabelInsert(new Label(), layout, "", "%", 15, 30);
            //DynamicCheckBox(this, new CheckBox(), layout, amountCondition.Applyed, "적용", 70, 30);
        }
        private void DrawPeriodCondition(PeriodConditionOfInterest periodCondition)
        {
            string start = $"{periodCondition.StartValue}";
            string startPeriodType = $"{periodCondition.StartDateType }";
            string end = $"{periodCondition.EndValue}";
            string endPeriodType = $"{periodCondition.EndDateType}";
            string interest = $"{Math.Abs(Math.Round(periodCondition.ChangedValue * 100, 0))}";


            Label lb = new Label();

            if (periodCondition.ChangedValue >= 0)
            {
                lb.Text = "+";
            }
            else
            {
                lb.Text = "-";
            }

            FlowLayoutPanel layout = new FlowLayoutPanel();
            DynamicInsert<FlowLayoutPanel>(layout, flp_Condition, "", flp_Condition.Width - 10, 35);

            DynamicLabelInsert(new Label(), layout, "", "기간", 35, 30);
            DynamicLabelInsert(new Label(), layout, "", start, 120, 30);
            DynamicLabelInsert(new Label(), layout, "", startPeriodType, 35, 30);
            DynamicLabelInsert(new Label(), layout, "", "~", 15, 30);
            DynamicLabelInsert(new Label(), layout, "", end, 120, 30);
            DynamicLabelInsert(new Label(), layout, "", endPeriodType, 35, 30);
            DynamicLabelInsert(lb, layout, "", lb.Text, 10, 30);
            DynamicLabelInsert(new Label(), layout, "", interest, 15, 30);
            DynamicLabelInsert(new Label(), layout, "", "%", 15, 30);
           // DynamicCheckBox(this, new CheckBox(), layout, periodCondition.Applyed, "적용", 70, 30);
        }

        private void bt_AccountCondition_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

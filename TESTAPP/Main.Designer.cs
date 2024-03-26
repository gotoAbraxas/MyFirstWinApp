
using TESTAPP.domain.account;

namespace TESTAPP
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.accountTab = new System.Windows.Forms.TabControl();
            this.myAccountTab = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_accountTab_Period = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_accountTab_Amount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.flp_SelectedAccounts = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_accountTab_PeriodCondition = new System.Windows.Forms.Button();
            this.bt_accountTab_AccountCondition = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_accountTab_MakePlan = new System.Windows.Forms.Button();
            this.bt_accountTab_AllSelect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bt_accountTab_Refresh = new System.Windows.Forms.Button();
            this.flp_AccountList = new System.Windows.Forms.FlowLayoutPanel();
            this.calProfitTab = new System.Windows.Forms.TabPage();
            this.bt_Refresh = new System.Windows.Forms.Button();
            this.bt_ResetCondition = new System.Windows.Forms.Button();
            this.cb_SelectAccount = new System.Windows.Forms.ComboBox();
            this.lb_SelectAccount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_CalProfitTab_Period = new System.Windows.Forms.ComboBox();
            this.bt_CalProfitTab_Available = new System.Windows.Forms.Button();
            this.txt_CalProfitTab_Available = new System.Windows.Forms.TextBox();
            this.lb_CalProfitTab_Available = new System.Windows.Forms.Label();
            this.lb_CalProfitTab_UpperLimit = new System.Windows.Forms.Label();
            this.txt_CalProfitTab_UpperLimit = new System.Windows.Forms.TextBox();
            this.txt_CalProfitTab_InterestType = new System.Windows.Forms.TextBox();
            this.Ib_CalProfitTab_InterestType = new System.Windows.Forms.Label();
            this.txt_CalProfitTab_Interest = new System.Windows.Forms.TextBox();
            this.txt_CalProfitTab_Amount = new System.Windows.Forms.TextBox();
            this.txt_CalProfitTab_InterestPeriod = new System.Windows.Forms.TextBox();
            this.lb_accountTab_Interest = new System.Windows.Forms.Label();
            this.lb_CalProfitTab_InterestPeriod = new System.Windows.Forms.Label();
            this.lb_CalProfitTab_Amount = new System.Windows.Forms.Label();
            this.lb_tmp_02 = new System.Windows.Forms.Label();
            this.lb_tmp_01 = new System.Windows.Forms.Label();
            this.dt_From = new System.Windows.Forms.DateTimePicker();
            this.dt_To = new System.Windows.Forms.DateTimePicker();
            this.bt_Calculate = new System.Windows.Forms.Button();
            this.bt_addCondition = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tranHis = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Amount = new System.Windows.Forms.TextBox();
            this.lb_Amount = new System.Windows.Forms.Label();
            this.bt_Refresh_log = new System.Windows.Forms.Button();
            this.bt_AddAccountLog = new System.Windows.Forms.Button();
            this.grid_accountLog = new System.Windows.Forms.DataGridView();
            this.bt_AddAcount = new System.Windows.Forms.Button();
            this.accountTab.SuspendLayout();
            this.myAccountTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.calProfitTab.SuspendLayout();
            this.tranHis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_accountLog)).BeginInit();
            this.SuspendLayout();
            // 
            // accountTab
            // 
            this.accountTab.Controls.Add(this.myAccountTab);
            this.accountTab.Controls.Add(this.calProfitTab);
            this.accountTab.Controls.Add(this.tranHis);
            this.accountTab.Location = new System.Drawing.Point(36, 55);
            this.accountTab.Name = "accountTab";
            this.accountTab.SelectedIndex = 0;
            this.accountTab.Size = new System.Drawing.Size(916, 476);
            this.accountTab.TabIndex = 2;
            // 
            // myAccountTab
            // 
            this.myAccountTab.Controls.Add(this.label10);
            this.myAccountTab.Controls.Add(this.label9);
            this.myAccountTab.Controls.Add(this.label8);
            this.myAccountTab.Controls.Add(this.txt_accountTab_Period);
            this.myAccountTab.Controls.Add(this.label7);
            this.myAccountTab.Controls.Add(this.txt_accountTab_Amount);
            this.myAccountTab.Controls.Add(this.label6);
            this.myAccountTab.Controls.Add(this.flp_SelectedAccounts);
            this.myAccountTab.Controls.Add(this.label4);
            this.myAccountTab.Controls.Add(this.panel1);
            this.myAccountTab.Controls.Add(this.bt_accountTab_MakePlan);
            this.myAccountTab.Controls.Add(this.bt_accountTab_AllSelect);
            this.myAccountTab.Controls.Add(this.button2);
            this.myAccountTab.Controls.Add(this.bt_accountTab_Refresh);
            this.myAccountTab.Controls.Add(this.flp_AccountList);
            this.myAccountTab.Location = new System.Drawing.Point(4, 22);
            this.myAccountTab.Name = "myAccountTab";
            this.myAccountTab.Padding = new System.Windows.Forms.Padding(3);
            this.myAccountTab.Size = new System.Drawing.Size(908, 450);
            this.myAccountTab.TabIndex = 0;
            this.myAccountTab.Text = "내 계좌";
            this.myAccountTab.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 229);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "선택된 상품";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 416);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "최적 투자경로";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "개월";
            // 
            // txt_accountTab_Period
            // 
            this.txt_accountTab_Period.Location = new System.Drawing.Point(349, 411);
            this.txt_accountTab_Period.Name = "txt_accountTab_Period";
            this.txt_accountTab_Period.Size = new System.Drawing.Size(37, 21);
            this.txt_accountTab_Period.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(322, 416);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "원";
            // 
            // txt_accountTab_Amount
            // 
            this.txt_accountTab_Amount.Location = new System.Drawing.Point(191, 411);
            this.txt_accountTab_Amount.Name = "txt_accountTab_Amount";
            this.txt_accountTab_Amount.Size = new System.Drawing.Size(124, 21);
            this.txt_accountTab_Amount.TabIndex = 15;
            this.txt_accountTab_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_accountTab_Amount.TextChanged += new System.EventHandler(this.txt_accountTab_Amount_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 415);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "선택된 상품으로";
            // 
            // flp_SelectedAccounts
            // 
            this.flp_SelectedAccounts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flp_SelectedAccounts.Location = new System.Drawing.Point(29, 245);
            this.flp_SelectedAccounts.Name = "flp_SelectedAccounts";
            this.flp_SelectedAccounts.Size = new System.Drawing.Size(317, 118);
            this.flp_SelectedAccounts.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "검색 조건";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.bt_accountTab_PeriodCondition);
            this.panel1.Controls.Add(this.bt_accountTab_AccountCondition);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(29, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 169);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "나중에 더 넣기";
            // 
            // bt_accountTab_PeriodCondition
            // 
            this.bt_accountTab_PeriodCondition.Location = new System.Drawing.Point(208, 34);
            this.bt_accountTab_PeriodCondition.Name = "bt_accountTab_PeriodCondition";
            this.bt_accountTab_PeriodCondition.Size = new System.Drawing.Size(60, 24);
            this.bt_accountTab_PeriodCondition.TabIndex = 12;
            this.bt_accountTab_PeriodCondition.Text = "기간";
            this.bt_accountTab_PeriodCondition.UseVisualStyleBackColor = true;
            this.bt_accountTab_PeriodCondition.Click += new System.EventHandler(this.bt_accountTab_PeriodCondition_Click);
            // 
            // bt_accountTab_AccountCondition
            // 
            this.bt_accountTab_AccountCondition.Location = new System.Drawing.Point(131, 34);
            this.bt_accountTab_AccountCondition.Name = "bt_accountTab_AccountCondition";
            this.bt_accountTab_AccountCondition.Size = new System.Drawing.Size(60, 24);
            this.bt_accountTab_AccountCondition.TabIndex = 11;
            this.bt_accountTab_AccountCondition.Text = "금액";
            this.bt_accountTab_AccountCondition.UseVisualStyleBackColor = true;
            this.bt_accountTab_AccountCondition.Click += new System.EventHandler(this.bt_accountTab_AccountCondition_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "우대조건";
            // 
            // bt_accountTab_MakePlan
            // 
            this.bt_accountTab_MakePlan.Location = new System.Drawing.Point(522, 406);
            this.bt_accountTab_MakePlan.Name = "bt_accountTab_MakePlan";
            this.bt_accountTab_MakePlan.Size = new System.Drawing.Size(84, 29);
            this.bt_accountTab_MakePlan.TabIndex = 7;
            this.bt_accountTab_MakePlan.Text = "계산해보기";
            this.bt_accountTab_MakePlan.UseVisualStyleBackColor = true;
            this.bt_accountTab_MakePlan.Click += new System.EventHandler(this.bt_accountTab_MakePlan_Click);
            // 
            // bt_accountTab_AllSelect
            // 
            this.bt_accountTab_AllSelect.Location = new System.Drawing.Point(435, 8);
            this.bt_accountTab_AllSelect.Name = "bt_accountTab_AllSelect";
            this.bt_accountTab_AllSelect.Size = new System.Drawing.Size(70, 21);
            this.bt_accountTab_AllSelect.TabIndex = 6;
            this.bt_accountTab_AllSelect.Text = "전체선택";
            this.bt_accountTab_AllSelect.UseVisualStyleBackColor = true;
            this.bt_accountTab_AllSelect.Click += new System.EventHandler(this.bt_accountTab_AllSelect_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(842, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 22);
            this.button2.TabIndex = 5;
            this.button2.Text = "정렬";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // bt_accountTab_Refresh
            // 
            this.bt_accountTab_Refresh.Location = new System.Drawing.Point(522, 8);
            this.bt_accountTab_Refresh.Name = "bt_accountTab_Refresh";
            this.bt_accountTab_Refresh.Size = new System.Drawing.Size(22, 22);
            this.bt_accountTab_Refresh.TabIndex = 4;
            this.bt_accountTab_Refresh.Text = "R";
            this.bt_accountTab_Refresh.UseVisualStyleBackColor = true;
            this.bt_accountTab_Refresh.Click += new System.EventHandler(this.bt_accountTab_Refresh_Click);
            // 
            // flp_AccountList
            // 
            this.flp_AccountList.AutoScroll = true;
            this.flp_AccountList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flp_AccountList.Location = new System.Drawing.Point(426, 37);
            this.flp_AccountList.Name = "flp_AccountList";
            this.flp_AccountList.Size = new System.Drawing.Size(454, 326);
            this.flp_AccountList.TabIndex = 3;
            // 
            // calProfitTab
            // 
            this.calProfitTab.Controls.Add(this.bt_Refresh);
            this.calProfitTab.Controls.Add(this.bt_ResetCondition);
            this.calProfitTab.Controls.Add(this.cb_SelectAccount);
            this.calProfitTab.Controls.Add(this.lb_SelectAccount);
            this.calProfitTab.Controls.Add(this.label3);
            this.calProfitTab.Controls.Add(this.cb_CalProfitTab_Period);
            this.calProfitTab.Controls.Add(this.bt_CalProfitTab_Available);
            this.calProfitTab.Controls.Add(this.txt_CalProfitTab_Available);
            this.calProfitTab.Controls.Add(this.lb_CalProfitTab_Available);
            this.calProfitTab.Controls.Add(this.lb_CalProfitTab_UpperLimit);
            this.calProfitTab.Controls.Add(this.txt_CalProfitTab_UpperLimit);
            this.calProfitTab.Controls.Add(this.txt_CalProfitTab_InterestType);
            this.calProfitTab.Controls.Add(this.Ib_CalProfitTab_InterestType);
            this.calProfitTab.Controls.Add(this.txt_CalProfitTab_Interest);
            this.calProfitTab.Controls.Add(this.txt_CalProfitTab_Amount);
            this.calProfitTab.Controls.Add(this.txt_CalProfitTab_InterestPeriod);
            this.calProfitTab.Controls.Add(this.lb_accountTab_Interest);
            this.calProfitTab.Controls.Add(this.lb_CalProfitTab_InterestPeriod);
            this.calProfitTab.Controls.Add(this.lb_CalProfitTab_Amount);
            this.calProfitTab.Controls.Add(this.lb_tmp_02);
            this.calProfitTab.Controls.Add(this.lb_tmp_01);
            this.calProfitTab.Controls.Add(this.dt_From);
            this.calProfitTab.Controls.Add(this.dt_To);
            this.calProfitTab.Controls.Add(this.bt_Calculate);
            this.calProfitTab.Controls.Add(this.bt_addCondition);
            this.calProfitTab.Controls.Add(this.flowLayoutPanel);
            this.calProfitTab.Location = new System.Drawing.Point(4, 22);
            this.calProfitTab.Name = "calProfitTab";
            this.calProfitTab.Padding = new System.Windows.Forms.Padding(3);
            this.calProfitTab.Size = new System.Drawing.Size(908, 450);
            this.calProfitTab.TabIndex = 1;
            this.calProfitTab.Text = "이자 계산해보기";
            this.calProfitTab.UseVisualStyleBackColor = true;
            this.calProfitTab.Enter += new System.EventHandler(this.calProfitTab_Enter);
            // 
            // bt_Refresh
            // 
            this.bt_Refresh.Location = new System.Drawing.Point(351, 20);
            this.bt_Refresh.Name = "bt_Refresh";
            this.bt_Refresh.Size = new System.Drawing.Size(19, 18);
            this.bt_Refresh.TabIndex = 6;
            this.bt_Refresh.Text = "R";
            this.bt_Refresh.UseVisualStyleBackColor = true;
            this.bt_Refresh.Click += new System.EventHandler(this.bt_Refresh_Click);
            // 
            // bt_ResetCondition
            // 
            this.bt_ResetCondition.Location = new System.Drawing.Point(812, 22);
            this.bt_ResetCondition.Name = "bt_ResetCondition";
            this.bt_ResetCondition.Size = new System.Drawing.Size(28, 17);
            this.bt_ResetCondition.TabIndex = 32;
            this.bt_ResetCondition.Text = "R";
            this.bt_ResetCondition.UseVisualStyleBackColor = true;
            this.bt_ResetCondition.Click += new System.EventHandler(this.bt_ResetCondition_Click);
            // 
            // cb_SelectAccount
            // 
            this.cb_SelectAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectAccount.FormattingEnabled = true;
            this.cb_SelectAccount.Location = new System.Drawing.Point(119, 20);
            this.cb_SelectAccount.Name = "cb_SelectAccount";
            this.cb_SelectAccount.Size = new System.Drawing.Size(217, 20);
            this.cb_SelectAccount.TabIndex = 4;
            this.cb_SelectAccount.SelectedIndexChanged += new System.EventHandler(this.cb_SelectAccount_SelectedIndexChanged);
            // 
            // lb_SelectAccount
            // 
            this.lb_SelectAccount.AutoSize = true;
            this.lb_SelectAccount.Location = new System.Drawing.Point(15, 23);
            this.lb_SelectAccount.Name = "lb_SelectAccount";
            this.lb_SelectAccount.Size = new System.Drawing.Size(81, 12);
            this.lb_SelectAccount.TabIndex = 5;
            this.lb_SelectAccount.Text = "계좌 선택하기";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "(으)로 보기";
            // 
            // cb_CalProfitTab_Period
            // 
            this.cb_CalProfitTab_Period.FormattingEnabled = true;
            this.cb_CalProfitTab_Period.Location = new System.Drawing.Point(160, 386);
            this.cb_CalProfitTab_Period.Name = "cb_CalProfitTab_Period";
            this.cb_CalProfitTab_Period.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cb_CalProfitTab_Period.Size = new System.Drawing.Size(61, 20);
            this.cb_CalProfitTab_Period.TabIndex = 30;
            // 
            // bt_CalProfitTab_Available
            // 
            this.bt_CalProfitTab_Available.Location = new System.Drawing.Point(331, 164);
            this.bt_CalProfitTab_Available.Name = "bt_CalProfitTab_Available";
            this.bt_CalProfitTab_Available.Size = new System.Drawing.Size(89, 23);
            this.bt_CalProfitTab_Available.TabIndex = 28;
            this.bt_CalProfitTab_Available.Text = "리스트 확인";
            this.bt_CalProfitTab_Available.UseVisualStyleBackColor = true;
            this.bt_CalProfitTab_Available.Click += new System.EventHandler(this.bt_CalProfitTab_Available_Click);
            // 
            // txt_CalProfitTab_Available
            // 
            this.txt_CalProfitTab_Available.Location = new System.Drawing.Point(150, 166);
            this.txt_CalProfitTab_Available.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CalProfitTab_Available.Name = "txt_CalProfitTab_Available";
            this.txt_CalProfitTab_Available.ReadOnly = true;
            this.txt_CalProfitTab_Available.Size = new System.Drawing.Size(164, 21);
            this.txt_CalProfitTab_Available.TabIndex = 27;
            this.txt_CalProfitTab_Available.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_CalProfitTab_Available
            // 
            this.lb_CalProfitTab_Available.AutoSize = true;
            this.lb_CalProfitTab_Available.Location = new System.Drawing.Point(39, 166);
            this.lb_CalProfitTab_Available.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CalProfitTab_Available.Name = "lb_CalProfitTab_Available";
            this.lb_CalProfitTab_Available.Size = new System.Drawing.Size(73, 24);
            this.lb_CalProfitTab_Available.TabIndex = 26;
            this.lb_CalProfitTab_Available.Text = "적용 가능한 \r\n우대이율";
            this.lb_CalProfitTab_Available.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_CalProfitTab_UpperLimit
            // 
            this.lb_CalProfitTab_UpperLimit.AutoSize = true;
            this.lb_CalProfitTab_UpperLimit.Location = new System.Drawing.Point(39, 119);
            this.lb_CalProfitTab_UpperLimit.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CalProfitTab_UpperLimit.Name = "lb_CalProfitTab_UpperLimit";
            this.lb_CalProfitTab_UpperLimit.Size = new System.Drawing.Size(61, 24);
            this.lb_CalProfitTab_UpperLimit.TabIndex = 25;
            this.lb_CalProfitTab_UpperLimit.Text = "우대 이율 \r\n상한값";
            this.lb_CalProfitTab_UpperLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_CalProfitTab_UpperLimit
            // 
            this.txt_CalProfitTab_UpperLimit.Location = new System.Drawing.Point(150, 119);
            this.txt_CalProfitTab_UpperLimit.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CalProfitTab_UpperLimit.Name = "txt_CalProfitTab_UpperLimit";
            this.txt_CalProfitTab_UpperLimit.ReadOnly = true;
            this.txt_CalProfitTab_UpperLimit.Size = new System.Drawing.Size(164, 21);
            this.txt_CalProfitTab_UpperLimit.TabIndex = 24;
            this.txt_CalProfitTab_UpperLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_CalProfitTab_InterestType
            // 
            this.txt_CalProfitTab_InterestType.Location = new System.Drawing.Point(150, 207);
            this.txt_CalProfitTab_InterestType.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CalProfitTab_InterestType.Name = "txt_CalProfitTab_InterestType";
            this.txt_CalProfitTab_InterestType.ReadOnly = true;
            this.txt_CalProfitTab_InterestType.Size = new System.Drawing.Size(164, 21);
            this.txt_CalProfitTab_InterestType.TabIndex = 22;
            this.txt_CalProfitTab_InterestType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Ib_CalProfitTab_InterestType
            // 
            this.Ib_CalProfitTab_InterestType.AutoSize = true;
            this.Ib_CalProfitTab_InterestType.Location = new System.Drawing.Point(39, 209);
            this.Ib_CalProfitTab_InterestType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Ib_CalProfitTab_InterestType.Name = "Ib_CalProfitTab_InterestType";
            this.Ib_CalProfitTab_InterestType.Size = new System.Drawing.Size(57, 12);
            this.Ib_CalProfitTab_InterestType.TabIndex = 21;
            this.Ib_CalProfitTab_InterestType.Text = "적용 방식";
            this.Ib_CalProfitTab_InterestType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CalProfitTab_Interest
            // 
            this.txt_CalProfitTab_Interest.Location = new System.Drawing.Point(149, 75);
            this.txt_CalProfitTab_Interest.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CalProfitTab_Interest.Name = "txt_CalProfitTab_Interest";
            this.txt_CalProfitTab_Interest.ReadOnly = true;
            this.txt_CalProfitTab_Interest.Size = new System.Drawing.Size(164, 21);
            this.txt_CalProfitTab_Interest.TabIndex = 18;
            this.txt_CalProfitTab_Interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_CalProfitTab_Amount
            // 
            this.txt_CalProfitTab_Amount.Location = new System.Drawing.Point(150, 286);
            this.txt_CalProfitTab_Amount.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CalProfitTab_Amount.Name = "txt_CalProfitTab_Amount";
            this.txt_CalProfitTab_Amount.ReadOnly = true;
            this.txt_CalProfitTab_Amount.Size = new System.Drawing.Size(164, 21);
            this.txt_CalProfitTab_Amount.TabIndex = 16;
            this.txt_CalProfitTab_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_CalProfitTab_InterestPeriod
            // 
            this.txt_CalProfitTab_InterestPeriod.Location = new System.Drawing.Point(150, 245);
            this.txt_CalProfitTab_InterestPeriod.Margin = new System.Windows.Forms.Padding(2);
            this.txt_CalProfitTab_InterestPeriod.Name = "txt_CalProfitTab_InterestPeriod";
            this.txt_CalProfitTab_InterestPeriod.ReadOnly = true;
            this.txt_CalProfitTab_InterestPeriod.Size = new System.Drawing.Size(164, 21);
            this.txt_CalProfitTab_InterestPeriod.TabIndex = 15;
            this.txt_CalProfitTab_InterestPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_accountTab_Interest
            // 
            this.lb_accountTab_Interest.AutoSize = true;
            this.lb_accountTab_Interest.Location = new System.Drawing.Point(39, 78);
            this.lb_accountTab_Interest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_accountTab_Interest.Name = "lb_accountTab_Interest";
            this.lb_accountTab_Interest.Size = new System.Drawing.Size(63, 24);
            this.lb_accountTab_Interest.TabIndex = 14;
            this.lb_accountTab_Interest.Text = "기본 이율\r\n(연간이율)";
            this.lb_accountTab_Interest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CalProfitTab_InterestPeriod
            // 
            this.lb_CalProfitTab_InterestPeriod.AutoSize = true;
            this.lb_CalProfitTab_InterestPeriod.Location = new System.Drawing.Point(39, 249);
            this.lb_CalProfitTab_InterestPeriod.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CalProfitTab_InterestPeriod.Name = "lb_CalProfitTab_InterestPeriod";
            this.lb_CalProfitTab_InterestPeriod.Size = new System.Drawing.Size(85, 12);
            this.lb_CalProfitTab_InterestPeriod.TabIndex = 13;
            this.lb_CalProfitTab_InterestPeriod.Text = "이자 정산 주기";
            this.lb_CalProfitTab_InterestPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CalProfitTab_Amount
            // 
            this.lb_CalProfitTab_Amount.AutoSize = true;
            this.lb_CalProfitTab_Amount.Location = new System.Drawing.Point(39, 289);
            this.lb_CalProfitTab_Amount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_CalProfitTab_Amount.Name = "lb_CalProfitTab_Amount";
            this.lb_CalProfitTab_Amount.Size = new System.Drawing.Size(57, 12);
            this.lb_CalProfitTab_Amount.TabIndex = 12;
            this.lb_CalProfitTab_Amount.Text = "현재 잔액";
            this.lb_CalProfitTab_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_tmp_02
            // 
            this.lb_tmp_02.AutoSize = true;
            this.lb_tmp_02.Location = new System.Drawing.Point(390, 336);
            this.lb_tmp_02.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_tmp_02.Name = "lb_tmp_02";
            this.lb_tmp_02.Size = new System.Drawing.Size(29, 12);
            this.lb_tmp_02.TabIndex = 11;
            this.lb_tmp_02.Text = "까지";
            // 
            // lb_tmp_01
            // 
            this.lb_tmp_01.AutoSize = true;
            this.lb_tmp_01.Location = new System.Drawing.Point(197, 335);
            this.lb_tmp_01.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_tmp_01.Name = "lb_tmp_01";
            this.lb_tmp_01.Size = new System.Drawing.Size(29, 12);
            this.lb_tmp_01.TabIndex = 10;
            this.lb_tmp_01.Text = "부터";
            // 
            // dt_From
            // 
            this.dt_From.Location = new System.Drawing.Point(37, 331);
            this.dt_From.MinDate = new System.DateTime(2024, 3, 15, 0, 0, 0, 0);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(156, 21);
            this.dt_From.TabIndex = 9;
            this.dt_From.Value = new System.DateTime(2024, 3, 15, 14, 52, 47, 0);
            // 
            // dt_To
            // 
            this.dt_To.Location = new System.Drawing.Point(229, 331);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(153, 21);
            this.dt_To.TabIndex = 8;
            // 
            // bt_Calculate
            // 
            this.bt_Calculate.Location = new System.Drawing.Point(342, 378);
            this.bt_Calculate.Name = "bt_Calculate";
            this.bt_Calculate.Size = new System.Drawing.Size(101, 37);
            this.bt_Calculate.TabIndex = 7;
            this.bt_Calculate.Text = "계산 !";
            this.bt_Calculate.UseVisualStyleBackColor = true;
            this.bt_Calculate.Click += new System.EventHandler(this.bt_Calculate_Click);
            // 
            // bt_addCondition
            // 
            this.bt_addCondition.Location = new System.Drawing.Point(458, 19);
            this.bt_addCondition.Name = "bt_addCondition";
            this.bt_addCondition.Size = new System.Drawing.Size(96, 23);
            this.bt_addCondition.TabIndex = 6;
            this.bt_addCondition.Text = "조건 추가하기";
            this.bt_addCondition.UseVisualStyleBackColor = true;
            this.bt_addCondition.Click += new System.EventHandler(this.bt_addCondition_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(458, 62);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(422, 282);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // tranHis
            // 
            this.tranHis.Controls.Add(this.label1);
            this.tranHis.Controls.Add(this.txt_Amount);
            this.tranHis.Controls.Add(this.lb_Amount);
            this.tranHis.Controls.Add(this.bt_Refresh_log);
            this.tranHis.Controls.Add(this.bt_AddAccountLog);
            this.tranHis.Controls.Add(this.grid_accountLog);
            this.tranHis.Location = new System.Drawing.Point(4, 22);
            this.tranHis.Name = "tranHis";
            this.tranHis.Padding = new System.Windows.Forms.Padding(3);
            this.tranHis.Size = new System.Drawing.Size(908, 450);
            this.tranHis.TabIndex = 2;
            this.tranHis.Text = "거래내역";
            this.tranHis.UseVisualStyleBackColor = true;
            this.tranHis.Enter += new System.EventHandler(this.tranHis_Onclick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(839, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "원";
            // 
            // txt_Amount
            // 
            this.txt_Amount.Location = new System.Drawing.Point(697, 413);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.ReadOnly = true;
            this.txt_Amount.Size = new System.Drawing.Size(136, 21);
            this.txt_Amount.TabIndex = 9;
            this.txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_Amount
            // 
            this.lb_Amount.AutoSize = true;
            this.lb_Amount.Location = new System.Drawing.Point(617, 417);
            this.lb_Amount.Name = "lb_Amount";
            this.lb_Amount.Size = new System.Drawing.Size(57, 12);
            this.lb_Amount.TabIndex = 8;
            this.lb_Amount.Text = "현재 잔액";
            // 
            // bt_Refresh_log
            // 
            this.bt_Refresh_log.Location = new System.Drawing.Point(841, 23);
            this.bt_Refresh_log.Name = "bt_Refresh_log";
            this.bt_Refresh_log.Size = new System.Drawing.Size(19, 18);
            this.bt_Refresh_log.TabIndex = 7;
            this.bt_Refresh_log.Text = "R";
            this.bt_Refresh_log.UseVisualStyleBackColor = true;
            this.bt_Refresh_log.Click += new System.EventHandler(this.bt_Refresh_log_Click);
            // 
            // bt_AddAccountLog
            // 
            this.bt_AddAccountLog.Location = new System.Drawing.Point(729, 15);
            this.bt_AddAccountLog.Name = "bt_AddAccountLog";
            this.bt_AddAccountLog.Size = new System.Drawing.Size(103, 26);
            this.bt_AddAccountLog.TabIndex = 3;
            this.bt_AddAccountLog.Text = "내역 추가하기";
            this.bt_AddAccountLog.UseVisualStyleBackColor = true;
            this.bt_AddAccountLog.Click += new System.EventHandler(this.bt_AddAccountLog_Click);
            // 
            // grid_accountLog
            // 
            this.grid_accountLog.AllowUserToAddRows = false;
            this.grid_accountLog.AllowUserToDeleteRows = false;
            this.grid_accountLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_accountLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grid_accountLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_accountLog.Location = new System.Drawing.Point(26, 47);
            this.grid_accountLog.Name = "grid_accountLog";
            this.grid_accountLog.ReadOnly = true;
            this.grid_accountLog.RowHeadersWidth = 62;
            this.grid_accountLog.RowTemplate.Height = 23;
            this.grid_accountLog.Size = new System.Drawing.Size(854, 339);
            this.grid_accountLog.TabIndex = 2;
            // 
            // bt_AddAcount
            // 
            this.bt_AddAcount.Location = new System.Drawing.Point(820, 15);
            this.bt_AddAcount.Name = "bt_AddAcount";
            this.bt_AddAcount.Size = new System.Drawing.Size(100, 20);
            this.bt_AddAcount.TabIndex = 3;
            this.bt_AddAcount.Text = "계좌 추가하기";
            this.bt_AddAcount.UseVisualStyleBackColor = true;
            this.bt_AddAcount.Click += new System.EventHandler(this.bt_AddAcount_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 555);
            this.Controls.Add(this.bt_AddAcount);
            this.Controls.Add(this.accountTab);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.accountTab.ResumeLayout(false);
            this.myAccountTab.ResumeLayout(false);
            this.myAccountTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.calProfitTab.ResumeLayout(false);
            this.calProfitTab.PerformLayout();
            this.tranHis.ResumeLayout(false);
            this.tranHis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_accountLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl accountTab;
        private System.Windows.Forms.TabPage myAccountTab;
        private System.Windows.Forms.TabPage calProfitTab;
        private System.Windows.Forms.TabPage tranHis;
        private System.Windows.Forms.DataGridView grid_accountLog;
        private System.Windows.Forms.Button bt_AddAcount;
        private System.Windows.Forms.ComboBox cb_SelectAccount;
        private System.Windows.Forms.Label lb_SelectAccount;
        private System.Windows.Forms.Button bt_addCondition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button bt_Refresh;
        private System.Windows.Forms.Button bt_AddAccountLog;
        private System.Windows.Forms.Button bt_Refresh_log;
        private System.Windows.Forms.Label lb_Amount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Amount;
        private System.Windows.Forms.Button bt_Calculate;
        private System.Windows.Forms.DateTimePicker dt_To;
        private System.Windows.Forms.DateTimePicker dt_From;
        private System.Windows.Forms.Label lb_tmp_02;
        private System.Windows.Forms.Label lb_tmp_01;
        private System.Windows.Forms.Label lb_accountTab_Interest;
        private System.Windows.Forms.TextBox txt_CalProfitTab_Interest;
        private System.Windows.Forms.Label lb_CalProfitTab_Available;
        private System.Windows.Forms.Label lb_CalProfitTab_UpperLimit;
        private System.Windows.Forms.TextBox txt_CalProfitTab_UpperLimit;
        private System.Windows.Forms.Button bt_CalProfitTab_Available;
        private System.Windows.Forms.TextBox txt_CalProfitTab_Available;
        private System.Windows.Forms.TextBox txt_CalProfitTab_InterestType;
        private System.Windows.Forms.Label Ib_CalProfitTab_InterestType;
        private System.Windows.Forms.TextBox txt_CalProfitTab_Amount;
        private System.Windows.Forms.TextBox txt_CalProfitTab_InterestPeriod;
        private System.Windows.Forms.Label lb_CalProfitTab_InterestPeriod;
        private System.Windows.Forms.Label lb_CalProfitTab_Amount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_CalProfitTab_Period;
        private System.Windows.Forms.Button bt_ResetCondition;
        private System.Windows.Forms.FlowLayoutPanel flp_AccountList;
        private System.Windows.Forms.Button bt_accountTab_Refresh;
        private System.Windows.Forms.Button bt_accountTab_MakePlan;
        private System.Windows.Forms.Button bt_accountTab_AllSelect;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bt_accountTab_PeriodCondition;
        private System.Windows.Forms.Button bt_accountTab_AccountCondition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flp_SelectedAccounts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_accountTab_Amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_accountTab_Period;
    }
}


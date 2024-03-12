
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
            this.calProfitTab = new System.Windows.Forms.TabPage();
            this.txt_CalProfitTab_InterestType = new System.Windows.Forms.TextBox();
            this.Ib_CalProfitTab_InterestType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_CalProfitTab_Interest = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.cb_SelectAccount = new System.Windows.Forms.ComboBox();
            this.lb_SelectAccount = new System.Windows.Forms.Label();
            this.bt_Refresh = new System.Windows.Forms.Button();
            this.accountTab.SuspendLayout();
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
            this.accountTab.Location = new System.Drawing.Point(51, 82);
            this.accountTab.Margin = new System.Windows.Forms.Padding(4);
            this.accountTab.Name = "accountTab";
            this.accountTab.SelectedIndex = 0;
            this.accountTab.Size = new System.Drawing.Size(1269, 714);
            this.accountTab.TabIndex = 2;
            this.accountTab.Enter += new System.EventHandler(this.accountTab_Enter);
            // 
            // myAccountTab
            // 
            this.myAccountTab.Location = new System.Drawing.Point(4, 28);
            this.myAccountTab.Margin = new System.Windows.Forms.Padding(4);
            this.myAccountTab.Name = "myAccountTab";
            this.myAccountTab.Padding = new System.Windows.Forms.Padding(4);
            this.myAccountTab.Size = new System.Drawing.Size(1261, 682);
            this.myAccountTab.TabIndex = 0;
            this.myAccountTab.Text = "내 계좌";
            this.myAccountTab.UseVisualStyleBackColor = true;
            this.myAccountTab.Enter += new System.EventHandler(this.accountTab_OnClick);
            // 
            // calProfitTab
            // 
            this.calProfitTab.Controls.Add(this.txt_CalProfitTab_InterestType);
            this.calProfitTab.Controls.Add(this.Ib_CalProfitTab_InterestType);
            this.calProfitTab.Controls.Add(this.label5);
            this.calProfitTab.Controls.Add(this.txt_CalProfitTab_Interest);
            this.calProfitTab.Controls.Add(this.label2);
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
            this.calProfitTab.Location = new System.Drawing.Point(4, 28);
            this.calProfitTab.Margin = new System.Windows.Forms.Padding(4);
            this.calProfitTab.Name = "calProfitTab";
            this.calProfitTab.Padding = new System.Windows.Forms.Padding(4);
            this.calProfitTab.Size = new System.Drawing.Size(1261, 682);
            this.calProfitTab.TabIndex = 1;
            this.calProfitTab.Text = "이자 계산해보기";
            this.calProfitTab.UseVisualStyleBackColor = true;
            // 
            // txt_CalProfitTab_InterestType
            // 
            this.txt_CalProfitTab_InterestType.Location = new System.Drawing.Point(214, 148);
            this.txt_CalProfitTab_InterestType.Name = "txt_CalProfitTab_InterestType";
            this.txt_CalProfitTab_InterestType.ReadOnly = true;
            this.txt_CalProfitTab_InterestType.Size = new System.Drawing.Size(233, 28);
            this.txt_CalProfitTab_InterestType.TabIndex = 22;
            this.txt_CalProfitTab_InterestType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Ib_CalProfitTab_InterestType
            // 
            this.Ib_CalProfitTab_InterestType.AutoSize = true;
            this.Ib_CalProfitTab_InterestType.Location = new System.Drawing.Point(56, 152);
            this.Ib_CalProfitTab_InterestType.Name = "Ib_CalProfitTab_InterestType";
            this.Ib_CalProfitTab_InterestType.Size = new System.Drawing.Size(86, 18);
            this.Ib_CalProfitTab_InterestType.TabIndex = 21;
            this.Ib_CalProfitTab_InterestType.Text = "적용 방식";
            this.Ib_CalProfitTab_InterestType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(453, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "원";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CalProfitTab_Interest
            // 
            this.txt_CalProfitTab_Interest.Location = new System.Drawing.Point(213, 86);
            this.txt_CalProfitTab_Interest.Name = "txt_CalProfitTab_Interest";
            this.txt_CalProfitTab_Interest.ReadOnly = true;
            this.txt_CalProfitTab_Interest.Size = new System.Drawing.Size(233, 28);
            this.txt_CalProfitTab_Interest.TabIndex = 18;
            this.txt_CalProfitTab_Interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(460, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CalProfitTab_Amount
            // 
            this.txt_CalProfitTab_Amount.Location = new System.Drawing.Point(214, 264);
            this.txt_CalProfitTab_Amount.Name = "txt_CalProfitTab_Amount";
            this.txt_CalProfitTab_Amount.ReadOnly = true;
            this.txt_CalProfitTab_Amount.Size = new System.Drawing.Size(233, 28);
            this.txt_CalProfitTab_Amount.TabIndex = 16;
            this.txt_CalProfitTab_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_CalProfitTab_InterestPeriod
            // 
            this.txt_CalProfitTab_InterestPeriod.Location = new System.Drawing.Point(214, 202);
            this.txt_CalProfitTab_InterestPeriod.Name = "txt_CalProfitTab_InterestPeriod";
            this.txt_CalProfitTab_InterestPeriod.ReadOnly = true;
            this.txt_CalProfitTab_InterestPeriod.Size = new System.Drawing.Size(233, 28);
            this.txt_CalProfitTab_InterestPeriod.TabIndex = 15;
            this.txt_CalProfitTab_InterestPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_accountTab_Interest
            // 
            this.lb_accountTab_Interest.AutoSize = true;
            this.lb_accountTab_Interest.Location = new System.Drawing.Point(56, 93);
            this.lb_accountTab_Interest.Name = "lb_accountTab_Interest";
            this.lb_accountTab_Interest.Size = new System.Drawing.Size(86, 18);
            this.lb_accountTab_Interest.TabIndex = 14;
            this.lb_accountTab_Interest.Text = "기본 이율";
            this.lb_accountTab_Interest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CalProfitTab_InterestPeriod
            // 
            this.lb_CalProfitTab_InterestPeriod.AutoSize = true;
            this.lb_CalProfitTab_InterestPeriod.Location = new System.Drawing.Point(56, 209);
            this.lb_CalProfitTab_InterestPeriod.Name = "lb_CalProfitTab_InterestPeriod";
            this.lb_CalProfitTab_InterestPeriod.Size = new System.Drawing.Size(128, 18);
            this.lb_CalProfitTab_InterestPeriod.TabIndex = 13;
            this.lb_CalProfitTab_InterestPeriod.Text = "이자 정산 주기";
            this.lb_CalProfitTab_InterestPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_CalProfitTab_Amount
            // 
            this.lb_CalProfitTab_Amount.AutoSize = true;
            this.lb_CalProfitTab_Amount.Location = new System.Drawing.Point(56, 268);
            this.lb_CalProfitTab_Amount.Name = "lb_CalProfitTab_Amount";
            this.lb_CalProfitTab_Amount.Size = new System.Drawing.Size(86, 18);
            this.lb_CalProfitTab_Amount.TabIndex = 12;
            this.lb_CalProfitTab_Amount.Text = "현재 잔액";
            this.lb_CalProfitTab_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_tmp_02
            // 
            this.lb_tmp_02.AutoSize = true;
            this.lb_tmp_02.Location = new System.Drawing.Point(485, 369);
            this.lb_tmp_02.Name = "lb_tmp_02";
            this.lb_tmp_02.Size = new System.Drawing.Size(44, 18);
            this.lb_tmp_02.TabIndex = 11;
            this.lb_tmp_02.Text = "까지";
            // 
            // lb_tmp_01
            // 
            this.lb_tmp_01.AutoSize = true;
            this.lb_tmp_01.Location = new System.Drawing.Point(235, 369);
            this.lb_tmp_01.Name = "lb_tmp_01";
            this.lb_tmp_01.Size = new System.Drawing.Size(44, 18);
            this.lb_tmp_01.TabIndex = 10;
            this.lb_tmp_01.Text = "부터";
            // 
            // dt_From
            // 
            this.dt_From.Location = new System.Drawing.Point(53, 363);
            this.dt_From.Margin = new System.Windows.Forms.Padding(4);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(175, 28);
            this.dt_From.TabIndex = 9;
            this.dt_From.ValueChanged += new System.EventHandler(this.dt_From_ValueChanged);
            // 
            // dt_To
            // 
            this.dt_To.Location = new System.Drawing.Point(302, 363);
            this.dt_To.Margin = new System.Windows.Forms.Padding(4);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(176, 28);
            this.dt_To.TabIndex = 8;
            this.dt_To.ValueChanged += new System.EventHandler(this.dt_To_ValueChanged);
            // 
            // bt_Calculate
            // 
            this.bt_Calculate.Location = new System.Drawing.Point(488, 509);
            this.bt_Calculate.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Calculate.Name = "bt_Calculate";
            this.bt_Calculate.Size = new System.Drawing.Size(144, 56);
            this.bt_Calculate.TabIndex = 7;
            this.bt_Calculate.Text = "계산 !";
            this.bt_Calculate.UseVisualStyleBackColor = true;
            this.bt_Calculate.Click += new System.EventHandler(this.bt_Calculate_Click);
            // 
            // bt_addCondition
            // 
            this.bt_addCondition.Location = new System.Drawing.Point(727, 34);
            this.bt_addCondition.Margin = new System.Windows.Forms.Padding(4);
            this.bt_addCondition.Name = "bt_addCondition";
            this.bt_addCondition.Size = new System.Drawing.Size(137, 34);
            this.bt_addCondition.TabIndex = 6;
            this.bt_addCondition.Text = "조건 추가하기";
            this.bt_addCondition.UseVisualStyleBackColor = true;
            this.bt_addCondition.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(727, 93);
            this.flowLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(420, 370);
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
            this.tranHis.Location = new System.Drawing.Point(4, 28);
            this.tranHis.Margin = new System.Windows.Forms.Padding(4);
            this.tranHis.Name = "tranHis";
            this.tranHis.Padding = new System.Windows.Forms.Padding(4);
            this.tranHis.Size = new System.Drawing.Size(1261, 682);
            this.tranHis.TabIndex = 2;
            this.tranHis.Text = "거래내역";
            this.tranHis.UseVisualStyleBackColor = true;
            this.tranHis.Enter += new System.EventHandler(this.tranHis_Onclick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1139, 582);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "원";
            // 
            // txt_Amount
            // 
            this.txt_Amount.Location = new System.Drawing.Point(906, 574);
            this.txt_Amount.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.ReadOnly = true;
            this.txt_Amount.Size = new System.Drawing.Size(223, 28);
            this.txt_Amount.TabIndex = 9;
            this.txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_Amount
            // 
            this.lb_Amount.AutoSize = true;
            this.lb_Amount.Location = new System.Drawing.Point(933, 534);
            this.lb_Amount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Amount.Name = "lb_Amount";
            this.lb_Amount.Size = new System.Drawing.Size(86, 18);
            this.lb_Amount.TabIndex = 8;
            this.lb_Amount.Text = "현재 잔액";
            // 
            // bt_Refresh_log
            // 
            this.bt_Refresh_log.Location = new System.Drawing.Point(936, 106);
            this.bt_Refresh_log.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Refresh_log.Name = "bt_Refresh_log";
            this.bt_Refresh_log.Size = new System.Drawing.Size(27, 27);
            this.bt_Refresh_log.TabIndex = 7;
            this.bt_Refresh_log.Text = "R";
            this.bt_Refresh_log.UseVisualStyleBackColor = true;
            this.bt_Refresh_log.Click += new System.EventHandler(this.bt_Refresh_log_Click);
            // 
            // bt_AddAccountLog
            // 
            this.bt_AddAccountLog.Location = new System.Drawing.Point(936, 58);
            this.bt_AddAccountLog.Margin = new System.Windows.Forms.Padding(4);
            this.bt_AddAccountLog.Name = "bt_AddAccountLog";
            this.bt_AddAccountLog.Size = new System.Drawing.Size(147, 39);
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
            this.grid_accountLog.Location = new System.Drawing.Point(61, 50);
            this.grid_accountLog.Margin = new System.Windows.Forms.Padding(4);
            this.grid_accountLog.Name = "grid_accountLog";
            this.grid_accountLog.RowHeadersWidth = 62;
            this.grid_accountLog.RowTemplate.Height = 23;
            this.grid_accountLog.Size = new System.Drawing.Size(826, 573);
            this.grid_accountLog.TabIndex = 2;
            // 
            // bt_AddAcount
            // 
            this.bt_AddAcount.Location = new System.Drawing.Point(1171, 22);
            this.bt_AddAcount.Margin = new System.Windows.Forms.Padding(4);
            this.bt_AddAcount.Name = "bt_AddAcount";
            this.bt_AddAcount.Size = new System.Drawing.Size(143, 30);
            this.bt_AddAcount.TabIndex = 3;
            this.bt_AddAcount.Text = "계좌 추가하기";
            this.bt_AddAcount.UseVisualStyleBackColor = true;
            this.bt_AddAcount.Click += new System.EventHandler(this.bt_AddAcount_Click);
            // 
            // cb_SelectAccount
            // 
            this.cb_SelectAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectAccount.FormattingEnabled = true;
            this.cb_SelectAccount.Location = new System.Drawing.Point(144, 21);
            this.cb_SelectAccount.Margin = new System.Windows.Forms.Padding(4);
            this.cb_SelectAccount.Name = "cb_SelectAccount";
            this.cb_SelectAccount.Size = new System.Drawing.Size(308, 26);
            this.cb_SelectAccount.TabIndex = 4;
            this.cb_SelectAccount.SelectedIndexChanged += new System.EventHandler(this.cb_SelectAccount_SelectedIndexChanged);
            // 
            // lb_SelectAccount
            // 
            this.lb_SelectAccount.AutoSize = true;
            this.lb_SelectAccount.Location = new System.Drawing.Point(19, 28);
            this.lb_SelectAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_SelectAccount.Name = "lb_SelectAccount";
            this.lb_SelectAccount.Size = new System.Drawing.Size(122, 18);
            this.lb_SelectAccount.TabIndex = 5;
            this.lb_SelectAccount.Text = "계좌 선택하기";
            // 
            // bt_Refresh
            // 
            this.bt_Refresh.Location = new System.Drawing.Point(469, 22);
            this.bt_Refresh.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Refresh.Name = "bt_Refresh";
            this.bt_Refresh.Size = new System.Drawing.Size(27, 27);
            this.bt_Refresh.TabIndex = 6;
            this.bt_Refresh.Text = "R";
            this.bt_Refresh.UseVisualStyleBackColor = true;
            this.bt_Refresh.Click += new System.EventHandler(this.bt_Refresh_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 832);
            this.Controls.Add(this.bt_Refresh);
            this.Controls.Add(this.lb_SelectAccount);
            this.Controls.Add(this.cb_SelectAccount);
            this.Controls.Add(this.bt_AddAcount);
            this.Controls.Add(this.accountTab);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.accountTab.ResumeLayout(false);
            this.calProfitTab.ResumeLayout(false);
            this.calProfitTab.PerformLayout();
            this.tranHis.ResumeLayout(false);
            this.tranHis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_accountLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lb_CalProfitTab_InterestPeriod;
        private System.Windows.Forms.Label lb_CalProfitTab_Amount;
        private System.Windows.Forms.TextBox txt_CalProfitTab_InterestPeriod;
        private System.Windows.Forms.TextBox txt_CalProfitTab_Amount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_CalProfitTab_Interest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Ib_CalProfitTab_InterestType;
        private System.Windows.Forms.TextBox txt_CalProfitTab_InterestType;
    }
}


﻿
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
            this.dt_From = new System.Windows.Forms.DateTimePicker();
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
            this.accountTab.Location = new System.Drawing.Point(36, 55);
            this.accountTab.Name = "accountTab";
            this.accountTab.SelectedIndex = 0;
            this.accountTab.Size = new System.Drawing.Size(888, 476);
            this.accountTab.TabIndex = 2;
            // 
            // myAccountTab
            // 
            this.myAccountTab.Location = new System.Drawing.Point(4, 22);
            this.myAccountTab.Name = "myAccountTab";
            this.myAccountTab.Padding = new System.Windows.Forms.Padding(3);
            this.myAccountTab.Size = new System.Drawing.Size(880, 450);
            this.myAccountTab.TabIndex = 0;
            this.myAccountTab.Text = "내 계좌";
            this.myAccountTab.UseVisualStyleBackColor = true;
            this.myAccountTab.Enter += new System.EventHandler(this.accountTab_OnClick);
            // 
            // calProfitTab
            // 
            this.calProfitTab.Controls.Add(this.dt_From);
            this.calProfitTab.Controls.Add(this.dt_To);
            this.calProfitTab.Controls.Add(this.bt_Calculate);
            this.calProfitTab.Controls.Add(this.bt_addCondition);
            this.calProfitTab.Controls.Add(this.flowLayoutPanel);
            this.calProfitTab.Location = new System.Drawing.Point(4, 22);
            this.calProfitTab.Name = "calProfitTab";
            this.calProfitTab.Padding = new System.Windows.Forms.Padding(3);
            this.calProfitTab.Size = new System.Drawing.Size(880, 450);
            this.calProfitTab.TabIndex = 1;
            this.calProfitTab.Text = "이자 계산해보기";
            this.calProfitTab.UseVisualStyleBackColor = true;
            // 
            // dt_To
            // 
            this.dt_To.Location = new System.Drawing.Point(231, 161);
            this.dt_To.Name = "dt_To";
            this.dt_To.Size = new System.Drawing.Size(114, 21);
            this.dt_To.TabIndex = 8;
            // 
            // bt_Calculate
            // 
            this.bt_Calculate.Location = new System.Drawing.Point(349, 368);
            this.bt_Calculate.Name = "bt_Calculate";
            this.bt_Calculate.Size = new System.Drawing.Size(101, 37);
            this.bt_Calculate.TabIndex = 7;
            this.bt_Calculate.Text = "계산 !";
            this.bt_Calculate.UseVisualStyleBackColor = true;
            this.bt_Calculate.Click += new System.EventHandler(this.bt_Calculate_Click);
            // 
            // bt_addCondition
            // 
            this.bt_addCondition.Location = new System.Drawing.Point(509, 23);
            this.bt_addCondition.Name = "bt_addCondition";
            this.bt_addCondition.Size = new System.Drawing.Size(96, 23);
            this.bt_addCondition.TabIndex = 6;
            this.bt_addCondition.Text = "조건 추가하기";
            this.bt_addCondition.UseVisualStyleBackColor = true;
            this.bt_addCondition.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Location = new System.Drawing.Point(509, 62);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(294, 247);
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
            this.tranHis.Size = new System.Drawing.Size(880, 450);
            this.tranHis.TabIndex = 2;
            this.tranHis.Text = "거래내역";
            this.tranHis.UseVisualStyleBackColor = true;
            this.tranHis.Enter += new System.EventHandler(this.tranHis_Onclick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(797, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "원";
            // 
            // txt_Amount
            // 
            this.txt_Amount.Location = new System.Drawing.Point(634, 383);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.ReadOnly = true;
            this.txt_Amount.Size = new System.Drawing.Size(157, 21);
            this.txt_Amount.TabIndex = 9;
            this.txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_Amount
            // 
            this.lb_Amount.AutoSize = true;
            this.lb_Amount.Location = new System.Drawing.Point(653, 356);
            this.lb_Amount.Name = "lb_Amount";
            this.lb_Amount.Size = new System.Drawing.Size(57, 12);
            this.lb_Amount.TabIndex = 8;
            this.lb_Amount.Text = "현재 잔액";
            // 
            // bt_Refresh_log
            // 
            this.bt_Refresh_log.Location = new System.Drawing.Point(655, 71);
            this.bt_Refresh_log.Name = "bt_Refresh_log";
            this.bt_Refresh_log.Size = new System.Drawing.Size(19, 18);
            this.bt_Refresh_log.TabIndex = 7;
            this.bt_Refresh_log.Text = "R";
            this.bt_Refresh_log.UseVisualStyleBackColor = true;
            this.bt_Refresh_log.Click += new System.EventHandler(this.bt_Refresh_log_Click);
            // 
            // bt_AddAccountLog
            // 
            this.bt_AddAccountLog.Location = new System.Drawing.Point(655, 39);
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
            this.grid_accountLog.Location = new System.Drawing.Point(43, 33);
            this.grid_accountLog.Name = "grid_accountLog";
            this.grid_accountLog.RowHeadersWidth = 62;
            this.grid_accountLog.RowTemplate.Height = 23;
            this.grid_accountLog.Size = new System.Drawing.Size(578, 382);
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
            // cb_SelectAccount
            // 
            this.cb_SelectAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectAccount.FormattingEnabled = true;
            this.cb_SelectAccount.Location = new System.Drawing.Point(101, 14);
            this.cb_SelectAccount.Name = "cb_SelectAccount";
            this.cb_SelectAccount.Size = new System.Drawing.Size(217, 20);
            this.cb_SelectAccount.TabIndex = 4;
            this.cb_SelectAccount.SelectedIndexChanged += new System.EventHandler(this.cb_SelectAccount_SelectedIndexChanged);
            // 
            // lb_SelectAccount
            // 
            this.lb_SelectAccount.AutoSize = true;
            this.lb_SelectAccount.Location = new System.Drawing.Point(13, 19);
            this.lb_SelectAccount.Name = "lb_SelectAccount";
            this.lb_SelectAccount.Size = new System.Drawing.Size(81, 12);
            this.lb_SelectAccount.TabIndex = 5;
            this.lb_SelectAccount.Text = "계좌 선택하기";
            // 
            // bt_Refresh
            // 
            this.bt_Refresh.Location = new System.Drawing.Point(328, 15);
            this.bt_Refresh.Name = "bt_Refresh";
            this.bt_Refresh.Size = new System.Drawing.Size(19, 18);
            this.bt_Refresh.TabIndex = 6;
            this.bt_Refresh.Text = "R";
            this.bt_Refresh.UseVisualStyleBackColor = true;
            this.bt_Refresh.Click += new System.EventHandler(this.bt_Refresh_Click);
            // 
            // dt_From
            // 
            this.dt_From.Location = new System.Drawing.Point(32, 161);
            this.dt_From.Name = "dt_From";
            this.dt_From.Size = new System.Drawing.Size(114, 21);
            this.dt_From.TabIndex = 9;
            this.dt_From.ValueChanged += new System.EventHandler(this.dt_From_ValueChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 555);
            this.Controls.Add(this.bt_Refresh);
            this.Controls.Add(this.lb_SelectAccount);
            this.Controls.Add(this.cb_SelectAccount);
            this.Controls.Add(this.bt_AddAcount);
            this.Controls.Add(this.accountTab);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.accountTab.ResumeLayout(false);
            this.calProfitTab.ResumeLayout(false);
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
    }
}


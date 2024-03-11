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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountTab = new System.Windows.Forms.TabControl();
            this.myAccountTab = new System.Windows.Forms.TabPage();
            this.calProfitTab = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_addCondition = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tranHis = new System.Windows.Forms.TabPage();
            this.grid_accountLog = new System.Windows.Forms.DataGridView();
            this.btAddAcount = new System.Windows.Forms.Button();
            this.cb_SelectAccount = new System.Windows.Forms.ComboBox();
            this.lb_SelectAccount = new System.Windows.Forms.Label();
            this.bt_Refresh = new System.Windows.Forms.Button();
            this.accountTab.SuspendLayout();
            this.calProfitTab.SuspendLayout();
            this.tranHis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_accountLog)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
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
            this.calProfitTab.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // bt_addCondition
            // 
            this.bt_addCondition.Location = new System.Drawing.Point(374, 22);
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
            this.flowLayoutPanel.Location = new System.Drawing.Point(374, 61);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(294, 247);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // tranHis
            // 
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
            // grid_accountLog
            // 
            this.grid_accountLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid_accountLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grid_accountLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_accountLog.Location = new System.Drawing.Point(67, 17);
            this.grid_accountLog.Name = "grid_accountLog";
            this.grid_accountLog.RowHeadersWidth = 62;
            this.grid_accountLog.RowTemplate.Height = 23;
            this.grid_accountLog.Size = new System.Drawing.Size(578, 316);
            this.grid_accountLog.TabIndex = 2;
            // 
            // btAddAcount
            // 
            this.btAddAcount.Location = new System.Drawing.Point(261, 13);
            this.btAddAcount.Name = "btAddAcount";
            this.btAddAcount.Size = new System.Drawing.Size(100, 20);
            this.btAddAcount.TabIndex = 3;
            this.btAddAcount.Text = "계좌 추가하기";
            this.btAddAcount.UseVisualStyleBackColor = true;
            this.btAddAcount.Click += new System.EventHandler(this.btAddAcount_Click);
            // 
            // cb_SelectAccount
            // 
            this.cb_SelectAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectAccount.FormattingEnabled = true;
            this.cb_SelectAccount.Location = new System.Drawing.Point(101, 14);
            this.cb_SelectAccount.Name = "cb_SelectAccount";
            this.cb_SelectAccount.Size = new System.Drawing.Size(120, 20);
            this.cb_SelectAccount.TabIndex = 4;
            this.cb_SelectAccount.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
            this.bt_Refresh.Location = new System.Drawing.Point(228, 15);
            this.bt_Refresh.Name = "bt_Refresh";
            this.bt_Refresh.Size = new System.Drawing.Size(19, 18);
            this.bt_Refresh.TabIndex = 6;
            this.bt_Refresh.Text = "R";
            this.bt_Refresh.UseVisualStyleBackColor = true;
            this.bt_Refresh.Click += new System.EventHandler(this.bt_Refresh_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 555);
            this.Controls.Add(this.bt_Refresh);
            this.Controls.Add(this.lb_SelectAccount);
            this.Controls.Add(this.cb_SelectAccount);
            this.Controls.Add(this.btAddAcount);
            this.Controls.Add(this.accountTab);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.accountTab.ResumeLayout(false);
            this.calProfitTab.ResumeLayout(false);
            this.tranHis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_accountLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TabControl accountTab;
        private System.Windows.Forms.TabPage myAccountTab;
        private System.Windows.Forms.TabPage calProfitTab;
        private System.Windows.Forms.TabPage tranHis;
        private System.Windows.Forms.DataGridView grid_accountLog;
        private System.Windows.Forms.Button btAddAcount;
        private System.Windows.Forms.ComboBox cb_SelectAccount;
        private System.Windows.Forms.Label lb_SelectAccount;
        private System.Windows.Forms.Button bt_addCondition;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bt_Refresh;
    }
}


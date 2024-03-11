﻿namespace TESTAPP
{
    partial class AddAcount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_AddAcount_save = new System.Windows.Forms.Button();
            this.bt_AddAcount_cancel = new System.Windows.Forms.Button();
            this.cb_AccountType = new System.Windows.Forms.ComboBox();
            this.lb_AccountType = new System.Windows.Forms.Label();
            this.txt_AccountType = new System.Windows.Forms.TextBox();
            this.txt_AccountName = new System.Windows.Forms.TextBox();
            this.lb_AccountName = new System.Windows.Forms.Label();
            this.lb_AccountNumber = new System.Windows.Forms.Label();
            this.txt_AccountNumber = new System.Windows.Forms.TextBox();
            this.lb_Interest = new System.Windows.Forms.Label();
            this.txt_Interest = new System.Windows.Forms.TextBox();
            this.lb_SettleType = new System.Windows.Forms.Label();
            this.cb_SettleType = new System.Windows.Forms.ComboBox();
            this.lb_InterestCondition = new System.Windows.Forms.Label();
            this.flp_Condition = new System.Windows.Forms.FlowLayoutPanel();
            this.bt_AddCondition = new System.Windows.Forms.Button();
            this.ut_Interest = new System.Windows.Forms.Label();
            this.lb_Preferent = new System.Windows.Forms.Label();
            this.ch_CheckPreferent = new System.Windows.Forms.CheckBox();
            this.txt_Preferent = new System.Windows.Forms.TextBox();
            this.lb_Preferent_limit = new System.Windows.Forms.Label();
            this.lb_InterestPeriod = new System.Windows.Forms.Label();
            this.txt_InterestPeriod = new System.Windows.Forms.TextBox();
            this.cb_InterestPeriod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bt_AddAcount_save
            // 
            this.bt_AddAcount_save.Location = new System.Drawing.Point(402, 482);
            this.bt_AddAcount_save.Name = "bt_AddAcount_save";
            this.bt_AddAcount_save.Size = new System.Drawing.Size(64, 23);
            this.bt_AddAcount_save.TabIndex = 0;
            this.bt_AddAcount_save.Text = "저장하기";
            this.bt_AddAcount_save.UseVisualStyleBackColor = true;
            this.bt_AddAcount_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_AddAcount_cancel
            // 
            this.bt_AddAcount_cancel.Location = new System.Drawing.Point(492, 482);
            this.bt_AddAcount_cancel.Name = "bt_AddAcount_cancel";
            this.bt_AddAcount_cancel.Size = new System.Drawing.Size(64, 23);
            this.bt_AddAcount_cancel.TabIndex = 1;
            this.bt_AddAcount_cancel.Text = "취소";
            this.bt_AddAcount_cancel.UseVisualStyleBackColor = true;
            this.bt_AddAcount_cancel.Click += new System.EventHandler(this.bt_AddAcount_cancel_Click);
            // 
            // cb_AccountType
            // 
            this.cb_AccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AccountType.FormattingEnabled = true;
            this.cb_AccountType.Location = new System.Drawing.Point(100, 17);
            this.cb_AccountType.Name = "cb_AccountType";
            this.cb_AccountType.Size = new System.Drawing.Size(75, 20);
            this.cb_AccountType.TabIndex = 2;
            this.cb_AccountType.SelectedIndexChanged += new System.EventHandler(this.cb_AccountType_SelectedIndexChanged);
            // 
            // lb_AccountType
            // 
            this.lb_AccountType.AutoSize = true;
            this.lb_AccountType.Location = new System.Drawing.Point(11, 21);
            this.lb_AccountType.Name = "lb_AccountType";
            this.lb_AccountType.Size = new System.Drawing.Size(57, 12);
            this.lb_AccountType.TabIndex = 3;
            this.lb_AccountType.Text = "계좌 유형";
            // 
            // txt_AccountType
            // 
            this.txt_AccountType.Enabled = false;
            this.txt_AccountType.Location = new System.Drawing.Point(182, 16);
            this.txt_AccountType.Name = "txt_AccountType";
            this.txt_AccountType.Size = new System.Drawing.Size(76, 21);
            this.txt_AccountType.TabIndex = 4;
            this.txt_AccountType.Visible = false;
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.Location = new System.Drawing.Point(100, 53);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(99, 21);
            this.txt_AccountName.TabIndex = 5;
            // 
            // lb_AccountName
            // 
            this.lb_AccountName.AutoSize = true;
            this.lb_AccountName.Location = new System.Drawing.Point(12, 57);
            this.lb_AccountName.Name = "lb_AccountName";
            this.lb_AccountName.Size = new System.Drawing.Size(57, 12);
            this.lb_AccountName.TabIndex = 6;
            this.lb_AccountName.Text = "계좌 이름";
            // 
            // lb_AccountNumber
            // 
            this.lb_AccountNumber.AutoSize = true;
            this.lb_AccountNumber.Location = new System.Drawing.Point(12, 88);
            this.lb_AccountNumber.Name = "lb_AccountNumber";
            this.lb_AccountNumber.Size = new System.Drawing.Size(57, 12);
            this.lb_AccountNumber.TabIndex = 7;
            this.lb_AccountNumber.Text = "계좌 번호";
            // 
            // txt_AccountNumber
            // 
            this.txt_AccountNumber.Location = new System.Drawing.Point(100, 85);
            this.txt_AccountNumber.Name = "txt_AccountNumber";
            this.txt_AccountNumber.Size = new System.Drawing.Size(144, 21);
            this.txt_AccountNumber.TabIndex = 8;
            // 
            // lb_Interest
            // 
            this.lb_Interest.AutoSize = true;
            this.lb_Interest.Location = new System.Drawing.Point(11, 124);
            this.lb_Interest.Name = "lb_Interest";
            this.lb_Interest.Size = new System.Drawing.Size(57, 12);
            this.lb_Interest.TabIndex = 9;
            this.lb_Interest.Text = "기본 이율";
            // 
            // txt_Interest
            // 
            this.txt_Interest.Location = new System.Drawing.Point(101, 120);
            this.txt_Interest.Name = "txt_Interest";
            this.txt_Interest.Size = new System.Drawing.Size(144, 21);
            this.txt_Interest.TabIndex = 10;
            // 
            // lb_SettleType
            // 
            this.lb_SettleType.AutoSize = true;
            this.lb_SettleType.Location = new System.Drawing.Point(11, 151);
            this.lb_SettleType.Name = "lb_SettleType";
            this.lb_SettleType.Size = new System.Drawing.Size(57, 12);
            this.lb_SettleType.TabIndex = 11;
            this.lb_SettleType.Text = "적용 방식";
            this.lb_SettleType.Click += new System.EventHandler(this.label1_Click);
            // 
            // cb_SettleType
            // 
            this.cb_SettleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SettleType.FormattingEnabled = true;
            this.cb_SettleType.Location = new System.Drawing.Point(101, 147);
            this.cb_SettleType.Name = "cb_SettleType";
            this.cb_SettleType.Size = new System.Drawing.Size(75, 20);
            this.cb_SettleType.TabIndex = 12;
            // 
            // lb_InterestCondition
            // 
            this.lb_InterestCondition.AutoSize = true;
            this.lb_InterestCondition.Location = new System.Drawing.Point(574, 34);
            this.lb_InterestCondition.Name = "lb_InterestCondition";
            this.lb_InterestCondition.Size = new System.Drawing.Size(57, 12);
            this.lb_InterestCondition.TabIndex = 13;
            this.lb_InterestCondition.Text = "우대 조건";
            // 
            // flp_Condition
            // 
            this.flp_Condition.AutoScroll = true;
            this.flp_Condition.Location = new System.Drawing.Point(573, 56);
            this.flp_Condition.Name = "flp_Condition";
            this.flp_Condition.Size = new System.Drawing.Size(323, 330);
            this.flp_Condition.TabIndex = 14;
            // 
            // bt_AddCondition
            // 
            this.bt_AddCondition.Location = new System.Drawing.Point(642, 29);
            this.bt_AddCondition.Name = "bt_AddCondition";
            this.bt_AddCondition.Size = new System.Drawing.Size(43, 19);
            this.bt_AddCondition.TabIndex = 15;
            this.bt_AddCondition.Text = "추가";
            this.bt_AddCondition.UseVisualStyleBackColor = true;
            this.bt_AddCondition.Click += new System.EventHandler(this.bt_AddCondition_Click);
            // 
            // ut_Interest
            // 
            this.ut_Interest.AutoSize = true;
            this.ut_Interest.Location = new System.Drawing.Point(251, 125);
            this.ut_Interest.Name = "ut_Interest";
            this.ut_Interest.Size = new System.Drawing.Size(15, 12);
            this.ut_Interest.TabIndex = 16;
            this.ut_Interest.Text = "%";
            // 
            // lb_Preferent
            // 
            this.lb_Preferent.AutoSize = true;
            this.lb_Preferent.Location = new System.Drawing.Point(11, 257);
            this.lb_Preferent.Name = "lb_Preferent";
            this.lb_Preferent.Size = new System.Drawing.Size(29, 12);
            this.lb_Preferent.TabIndex = 17;
            this.lb_Preferent.Text = "금액";
            // 
            // ch_CheckPreferent
            // 
            this.ch_CheckPreferent.AutoSize = true;
            this.ch_CheckPreferent.Location = new System.Drawing.Point(14, 232);
            this.ch_CheckPreferent.Name = "ch_CheckPreferent";
            this.ch_CheckPreferent.Size = new System.Drawing.Size(132, 16);
            this.ch_CheckPreferent.TabIndex = 18;
            this.ch_CheckPreferent.Text = "우대 금리 한도 여부";
            this.ch_CheckPreferent.UseVisualStyleBackColor = true;
            this.ch_CheckPreferent.CheckedChanged += new System.EventHandler(this.ch_CheckPreferent_CheckedChanged);
            // 
            // txt_Preferent
            // 
            this.txt_Preferent.Location = new System.Drawing.Point(98, 253);
            this.txt_Preferent.Name = "txt_Preferent";
            this.txt_Preferent.Size = new System.Drawing.Size(144, 21);
            this.txt_Preferent.TabIndex = 19;
            // 
            // lb_Preferent_limit
            // 
            this.lb_Preferent_limit.AutoSize = true;
            this.lb_Preferent_limit.Location = new System.Drawing.Point(248, 256);
            this.lb_Preferent_limit.Name = "lb_Preferent_limit";
            this.lb_Preferent_limit.Size = new System.Drawing.Size(45, 12);
            this.lb_Preferent_limit.TabIndex = 20;
            this.lb_Preferent_limit.Text = "원 까지";
            // 
            // lb_InterestPeriod
            // 
            this.lb_InterestPeriod.AutoSize = true;
            this.lb_InterestPeriod.Location = new System.Drawing.Point(11, 200);
            this.lb_InterestPeriod.Name = "lb_InterestPeriod";
            this.lb_InterestPeriod.Size = new System.Drawing.Size(85, 12);
            this.lb_InterestPeriod.TabIndex = 21;
            this.lb_InterestPeriod.Text = "이자 정산 주기";
            // 
            // txt_InterestPeriod
            // 
            this.txt_InterestPeriod.Enabled = false;
            this.txt_InterestPeriod.Location = new System.Drawing.Point(98, 197);
            this.txt_InterestPeriod.Name = "txt_InterestPeriod";
            this.txt_InterestPeriod.Size = new System.Drawing.Size(77, 21);
            this.txt_InterestPeriod.TabIndex = 22;
            this.txt_InterestPeriod.Visible = false;
            // 
            // cb_InterestPeriod
            // 
            this.cb_InterestPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_InterestPeriod.FormattingEnabled = true;
            this.cb_InterestPeriod.Location = new System.Drawing.Point(183, 197);
            this.cb_InterestPeriod.Name = "cb_InterestPeriod";
            this.cb_InterestPeriod.Size = new System.Drawing.Size(59, 20);
            this.cb_InterestPeriod.TabIndex = 23;
            // 
            // AddAcount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 527);
            this.Controls.Add(this.cb_InterestPeriod);
            this.Controls.Add(this.txt_InterestPeriod);
            this.Controls.Add(this.lb_InterestPeriod);
            this.Controls.Add(this.lb_Preferent_limit);
            this.Controls.Add(this.txt_Preferent);
            this.Controls.Add(this.ch_CheckPreferent);
            this.Controls.Add(this.lb_Preferent);
            this.Controls.Add(this.ut_Interest);
            this.Controls.Add(this.bt_AddCondition);
            this.Controls.Add(this.flp_Condition);
            this.Controls.Add(this.lb_InterestCondition);
            this.Controls.Add(this.cb_SettleType);
            this.Controls.Add(this.lb_SettleType);
            this.Controls.Add(this.txt_Interest);
            this.Controls.Add(this.lb_Interest);
            this.Controls.Add(this.txt_AccountNumber);
            this.Controls.Add(this.lb_AccountNumber);
            this.Controls.Add(this.lb_AccountName);
            this.Controls.Add(this.txt_AccountName);
            this.Controls.Add(this.txt_AccountType);
            this.Controls.Add(this.lb_AccountType);
            this.Controls.Add(this.cb_AccountType);
            this.Controls.Add(this.bt_AddAcount_cancel);
            this.Controls.Add(this.bt_AddAcount_save);
            this.Name = "AddAcount";
            this.Text = "AddAcount";
            this.Load += new System.EventHandler(this.AddAcount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_AddAcount_save;
        private System.Windows.Forms.Button bt_AddAcount_cancel;
        private System.Windows.Forms.ComboBox cb_AccountType;
        private System.Windows.Forms.Label lb_AccountType;
        private System.Windows.Forms.TextBox txt_AccountType;
        private System.Windows.Forms.TextBox txt_AccountName;
        private System.Windows.Forms.Label lb_AccountName;
        private System.Windows.Forms.Label lb_AccountNumber;
        private System.Windows.Forms.TextBox txt_AccountNumber;
        private System.Windows.Forms.Label lb_Interest;
        private System.Windows.Forms.TextBox txt_Interest;
        private System.Windows.Forms.Label lb_SettleType;
        private System.Windows.Forms.ComboBox cb_SettleType;
        private System.Windows.Forms.Label lb_InterestCondition;
        private System.Windows.Forms.FlowLayoutPanel flp_Condition;
        private System.Windows.Forms.Button bt_AddCondition;
        private System.Windows.Forms.Label ut_Interest;
        private System.Windows.Forms.Label lb_Preferent;
        private System.Windows.Forms.CheckBox ch_CheckPreferent;
        private System.Windows.Forms.TextBox txt_Preferent;
        private System.Windows.Forms.Label lb_Preferent_limit;
        private System.Windows.Forms.Label lb_InterestPeriod;
        private System.Windows.Forms.TextBox txt_InterestPeriod;
        private System.Windows.Forms.ComboBox cb_InterestPeriod;
    }
}
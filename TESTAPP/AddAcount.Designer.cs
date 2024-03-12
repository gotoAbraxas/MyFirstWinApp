namespace TESTAPP
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
            this.lb_SettlePeriod = new System.Windows.Forms.Label();
            this.txt_SettlePeriod = new System.Windows.Forms.TextBox();
            this.cb_SettlePeriod = new System.Windows.Forms.ComboBox();
            this.cb_AddCondition = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // bt_AddAcount_save
            // 
            this.bt_AddAcount_save.Location = new System.Drawing.Point(574, 723);
            this.bt_AddAcount_save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_AddAcount_save.Name = "bt_AddAcount_save";
            this.bt_AddAcount_save.Size = new System.Drawing.Size(91, 34);
            this.bt_AddAcount_save.TabIndex = 0;
            this.bt_AddAcount_save.Text = "저장하기";
            this.bt_AddAcount_save.UseVisualStyleBackColor = true;
            this.bt_AddAcount_save.Click += new System.EventHandler(this.bt_AddAcount_save_Click);
            // 
            // bt_AddAcount_cancel
            // 
            this.bt_AddAcount_cancel.Location = new System.Drawing.Point(703, 723);
            this.bt_AddAcount_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_AddAcount_cancel.Name = "bt_AddAcount_cancel";
            this.bt_AddAcount_cancel.Size = new System.Drawing.Size(91, 34);
            this.bt_AddAcount_cancel.TabIndex = 1;
            this.bt_AddAcount_cancel.Text = "취소";
            this.bt_AddAcount_cancel.UseVisualStyleBackColor = true;
            this.bt_AddAcount_cancel.Click += new System.EventHandler(this.bt_AddAcount_cancel_Click);
            // 
            // cb_AccountType
            // 
            this.cb_AccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AccountType.FormattingEnabled = true;
            this.cb_AccountType.Location = new System.Drawing.Point(161, 26);
            this.cb_AccountType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_AccountType.Name = "cb_AccountType";
            this.cb_AccountType.Size = new System.Drawing.Size(105, 26);
            this.cb_AccountType.TabIndex = 2;
            this.cb_AccountType.SelectedIndexChanged += new System.EventHandler(this.cb_AccountType_SelectedIndexChanged);
            // 
            // lb_AccountType
            // 
            this.lb_AccountType.AutoSize = true;
            this.lb_AccountType.Location = new System.Drawing.Point(16, 32);
            this.lb_AccountType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_AccountType.Name = "lb_AccountType";
            this.lb_AccountType.Size = new System.Drawing.Size(86, 18);
            this.lb_AccountType.TabIndex = 3;
            this.lb_AccountType.Text = "계좌 유형";
            // 
            // txt_AccountType
            // 
            this.txt_AccountType.Enabled = false;
            this.txt_AccountType.Location = new System.Drawing.Point(279, 24);
            this.txt_AccountType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_AccountType.Name = "txt_AccountType";
            this.txt_AccountType.Size = new System.Drawing.Size(107, 28);
            this.txt_AccountType.TabIndex = 4;
            this.txt_AccountType.Visible = false;
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.Location = new System.Drawing.Point(161, 80);
            this.txt_AccountName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(140, 28);
            this.txt_AccountName.TabIndex = 5;
            // 
            // lb_AccountName
            // 
            this.lb_AccountName.AutoSize = true;
            this.lb_AccountName.Location = new System.Drawing.Point(17, 86);
            this.lb_AccountName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_AccountName.Name = "lb_AccountName";
            this.lb_AccountName.Size = new System.Drawing.Size(86, 18);
            this.lb_AccountName.TabIndex = 6;
            this.lb_AccountName.Text = "계좌 이름";
            // 
            // lb_AccountNumber
            // 
            this.lb_AccountNumber.AutoSize = true;
            this.lb_AccountNumber.Location = new System.Drawing.Point(17, 132);
            this.lb_AccountNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_AccountNumber.Name = "lb_AccountNumber";
            this.lb_AccountNumber.Size = new System.Drawing.Size(86, 18);
            this.lb_AccountNumber.TabIndex = 7;
            this.lb_AccountNumber.Text = "계좌 번호";
            // 
            // txt_AccountNumber
            // 
            this.txt_AccountNumber.Location = new System.Drawing.Point(161, 128);
            this.txt_AccountNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_AccountNumber.Name = "txt_AccountNumber";
            this.txt_AccountNumber.Size = new System.Drawing.Size(204, 28);
            this.txt_AccountNumber.TabIndex = 8;
            // 
            // lb_Interest
            // 
            this.lb_Interest.AutoSize = true;
            this.lb_Interest.Location = new System.Drawing.Point(16, 183);
            this.lb_Interest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Interest.Name = "lb_Interest";
            this.lb_Interest.Size = new System.Drawing.Size(122, 36);
            this.lb_Interest.TabIndex = 9;
            this.lb_Interest.Text = "기본 이율 \r\n( 기대 수익률)";
            // 
            // txt_Interest
            // 
            this.txt_Interest.Location = new System.Drawing.Point(163, 177);
            this.txt_Interest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Interest.Name = "txt_Interest";
            this.txt_Interest.Size = new System.Drawing.Size(105, 28);
            this.txt_Interest.TabIndex = 10;
            // 
            // lb_SettleType
            // 
            this.lb_SettleType.AutoSize = true;
            this.lb_SettleType.Location = new System.Drawing.Point(16, 236);
            this.lb_SettleType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_SettleType.Name = "lb_SettleType";
            this.lb_SettleType.Size = new System.Drawing.Size(86, 18);
            this.lb_SettleType.TabIndex = 11;
            this.lb_SettleType.Text = "적용 방식";
            // 
            // cb_SettleType
            // 
            this.cb_SettleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SettleType.FormattingEnabled = true;
            this.cb_SettleType.Location = new System.Drawing.Point(163, 230);
            this.cb_SettleType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_SettleType.Name = "cb_SettleType";
            this.cb_SettleType.Size = new System.Drawing.Size(105, 26);
            this.cb_SettleType.TabIndex = 12;
            // 
            // lb_InterestCondition
            // 
            this.lb_InterestCondition.AutoSize = true;
            this.lb_InterestCondition.Location = new System.Drawing.Point(786, 48);
            this.lb_InterestCondition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_InterestCondition.Name = "lb_InterestCondition";
            this.lb_InterestCondition.Size = new System.Drawing.Size(128, 18);
            this.lb_InterestCondition.TabIndex = 13;
            this.lb_InterestCondition.Text = "우대 금리 조건";
            // 
            // flp_Condition
            // 
            this.flp_Condition.AutoScroll = true;
            this.flp_Condition.Location = new System.Drawing.Point(606, 84);
            this.flp_Condition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flp_Condition.Name = "flp_Condition";
            this.flp_Condition.Size = new System.Drawing.Size(674, 495);
            this.flp_Condition.TabIndex = 14;
            // 
            // bt_AddCondition
            // 
            this.bt_AddCondition.Location = new System.Drawing.Point(1046, 44);
            this.bt_AddCondition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_AddCondition.Name = "bt_AddCondition";
            this.bt_AddCondition.Size = new System.Drawing.Size(61, 28);
            this.bt_AddCondition.TabIndex = 15;
            this.bt_AddCondition.Text = "추가";
            this.bt_AddCondition.UseVisualStyleBackColor = true;
            this.bt_AddCondition.Click += new System.EventHandler(this.bt_AddCondition_Click);
            // 
            // ut_Interest
            // 
            this.ut_Interest.AutoSize = true;
            this.ut_Interest.Location = new System.Drawing.Point(279, 184);
            this.ut_Interest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ut_Interest.Name = "ut_Interest";
            this.ut_Interest.Size = new System.Drawing.Size(22, 18);
            this.ut_Interest.TabIndex = 16;
            this.ut_Interest.Text = "%";
            // 
            // lb_Preferent
            // 
            this.lb_Preferent.AutoSize = true;
            this.lb_Preferent.Location = new System.Drawing.Point(16, 386);
            this.lb_Preferent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Preferent.Name = "lb_Preferent";
            this.lb_Preferent.Size = new System.Drawing.Size(44, 18);
            this.lb_Preferent.TabIndex = 17;
            this.lb_Preferent.Text = "금액";
            // 
            // ch_CheckPreferent
            // 
            this.ch_CheckPreferent.AutoSize = true;
            this.ch_CheckPreferent.Location = new System.Drawing.Point(20, 348);
            this.ch_CheckPreferent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ch_CheckPreferent.Name = "ch_CheckPreferent";
            this.ch_CheckPreferent.Size = new System.Drawing.Size(196, 22);
            this.ch_CheckPreferent.TabIndex = 18;
            this.ch_CheckPreferent.Text = "우대 금리 한도 여부";
            this.ch_CheckPreferent.UseVisualStyleBackColor = true;
            this.ch_CheckPreferent.CheckedChanged += new System.EventHandler(this.ch_CheckPreferent_CheckedChanged);
            // 
            // txt_Preferent
            // 
            this.txt_Preferent.Location = new System.Drawing.Point(159, 380);
            this.txt_Preferent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Preferent.Name = "txt_Preferent";
            this.txt_Preferent.Size = new System.Drawing.Size(204, 28);
            this.txt_Preferent.TabIndex = 19;
            this.txt_Preferent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Preferent.TextChanged += new System.EventHandler(this.txt_Preferent_TextChanged);
            // 
            // lb_Preferent_limit
            // 
            this.lb_Preferent_limit.AutoSize = true;
            this.lb_Preferent_limit.Location = new System.Drawing.Point(373, 384);
            this.lb_Preferent_limit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Preferent_limit.Name = "lb_Preferent_limit";
            this.lb_Preferent_limit.Size = new System.Drawing.Size(68, 18);
            this.lb_Preferent_limit.TabIndex = 20;
            this.lb_Preferent_limit.Text = "원 까지";
            // 
            // lb_SettlePeriod
            // 
            this.lb_SettlePeriod.AutoSize = true;
            this.lb_SettlePeriod.Location = new System.Drawing.Point(16, 300);
            this.lb_SettlePeriod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_SettlePeriod.Name = "lb_SettlePeriod";
            this.lb_SettlePeriod.Size = new System.Drawing.Size(128, 18);
            this.lb_SettlePeriod.TabIndex = 21;
            this.lb_SettlePeriod.Text = "이자 정산 주기";
            // 
            // txt_SettlePeriod
            // 
            this.txt_SettlePeriod.Location = new System.Drawing.Point(159, 296);
            this.txt_SettlePeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_SettlePeriod.Name = "txt_SettlePeriod";
            this.txt_SettlePeriod.Size = new System.Drawing.Size(108, 28);
            this.txt_SettlePeriod.TabIndex = 22;
            // 
            // cb_SettlePeriod
            // 
            this.cb_SettlePeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SettlePeriod.FormattingEnabled = true;
            this.cb_SettlePeriod.Location = new System.Drawing.Point(280, 296);
            this.cb_SettlePeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_SettlePeriod.Name = "cb_SettlePeriod";
            this.cb_SettlePeriod.Size = new System.Drawing.Size(83, 26);
            this.cb_SettlePeriod.TabIndex = 23;
            // 
            // cb_AddCondition
            // 
            this.cb_AddCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AddCondition.FormattingEnabled = true;
            this.cb_AddCondition.Location = new System.Drawing.Point(916, 44);
            this.cb_AddCondition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_AddCondition.Name = "cb_AddCondition";
            this.cb_AddCondition.Size = new System.Drawing.Size(105, 26);
            this.cb_AddCondition.TabIndex = 24;
            // 
            // AddAcount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 790);
            this.Controls.Add(this.cb_AddCondition);
            this.Controls.Add(this.cb_SettlePeriod);
            this.Controls.Add(this.txt_SettlePeriod);
            this.Controls.Add(this.lb_SettlePeriod);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Label lb_SettlePeriod;
        private System.Windows.Forms.TextBox txt_SettlePeriod;
        private System.Windows.Forms.ComboBox cb_SettlePeriod;
        private System.Windows.Forms.ComboBox cb_AddCondition;
    }
}
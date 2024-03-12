namespace TESTAPP
{
    partial class AddAccountLog
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
            this.bt_AddLogAccept = new System.Windows.Forms.Button();
            this.cb_AccountLog = new System.Windows.Forms.ComboBox();
            this.bt_AddLogCancel = new System.Windows.Forms.Button();
            this.txt_AccountLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_AddLogAccept
            // 
            this.bt_AddLogAccept.Location = new System.Drawing.Point(110, 81);
            this.bt_AddLogAccept.Name = "bt_AddLogAccept";
            this.bt_AddLogAccept.Size = new System.Drawing.Size(56, 20);
            this.bt_AddLogAccept.TabIndex = 0;
            this.bt_AddLogAccept.Text = "승인";
            this.bt_AddLogAccept.UseVisualStyleBackColor = true;
            this.bt_AddLogAccept.Click += new System.EventHandler(this.bt_AddLogAccept_Click);
            // 
            // cb_AccountLog
            // 
            this.cb_AccountLog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AccountLog.FormattingEnabled = true;
            this.cb_AccountLog.Location = new System.Drawing.Point(47, 36);
            this.cb_AccountLog.Name = "cb_AccountLog";
            this.cb_AccountLog.Size = new System.Drawing.Size(67, 20);
            this.cb_AccountLog.TabIndex = 1;
            // 
            // bt_AddLogCancel
            // 
            this.bt_AddLogCancel.Location = new System.Drawing.Point(186, 81);
            this.bt_AddLogCancel.Name = "bt_AddLogCancel";
            this.bt_AddLogCancel.Size = new System.Drawing.Size(56, 20);
            this.bt_AddLogCancel.TabIndex = 2;
            this.bt_AddLogCancel.Text = "취소";
            this.bt_AddLogCancel.UseVisualStyleBackColor = true;
            this.bt_AddLogCancel.Click += new System.EventHandler(this.bt_AddLogCancel_Click);
            // 
            // txt_AccountLog
            // 
            this.txt_AccountLog.Location = new System.Drawing.Point(137, 36);
            this.txt_AccountLog.Name = "txt_AccountLog";
            this.txt_AccountLog.Size = new System.Drawing.Size(210, 21);
            this.txt_AccountLog.TabIndex = 3;
            this.txt_AccountLog.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_AccountLog.TextChanged += new System.EventHandler(this.txt_AccountLog_TextChanged);
            // 
            // AddAccountLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 126);
            this.Controls.Add(this.txt_AccountLog);
            this.Controls.Add(this.bt_AddLogCancel);
            this.Controls.Add(this.cb_AccountLog);
            this.Controls.Add(this.bt_AddLogAccept);
            this.Name = "AddAccountLog";
            this.Text = "AddAccountLog";
            this.Load += new System.EventHandler(this.AddAccountLog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_AddLogAccept;
        private System.Windows.Forms.ComboBox cb_AccountLog;
        private System.Windows.Forms.Button bt_AddLogCancel;
        private System.Windows.Forms.TextBox txt_AccountLog;
    }
}
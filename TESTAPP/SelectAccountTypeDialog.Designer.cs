namespace TESTAPP
{
    partial class SelectAccountTypeDialog
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
            this.cb_AccountTypeList = new System.Windows.Forms.ComboBox();
            this.bt_AccountSelect = new System.Windows.Forms.Button();
            this.bt_AccountCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_AccountTypeList
            // 
            this.cb_AccountTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_AccountTypeList.FormattingEnabled = true;
            this.cb_AccountTypeList.Location = new System.Drawing.Point(42, 32);
            this.cb_AccountTypeList.Name = "cb_AccountTypeList";
            this.cb_AccountTypeList.Size = new System.Drawing.Size(202, 20);
            this.cb_AccountTypeList.TabIndex = 0;
            // 
            // bt_AccountSelect
            // 
            this.bt_AccountSelect.Location = new System.Drawing.Point(61, 65);
            this.bt_AccountSelect.Name = "bt_AccountSelect";
            this.bt_AccountSelect.Size = new System.Drawing.Size(71, 23);
            this.bt_AccountSelect.TabIndex = 1;
            this.bt_AccountSelect.Text = "확인";
            this.bt_AccountSelect.UseVisualStyleBackColor = true;
            this.bt_AccountSelect.Click += new System.EventHandler(this.bt_AccountSelect_Click);
            // 
            // bt_AccountCancel
            // 
            this.bt_AccountCancel.Location = new System.Drawing.Point(145, 65);
            this.bt_AccountCancel.Name = "bt_AccountCancel";
            this.bt_AccountCancel.Size = new System.Drawing.Size(71, 23);
            this.bt_AccountCancel.TabIndex = 2;
            this.bt_AccountCancel.Text = "취소";
            this.bt_AccountCancel.UseVisualStyleBackColor = true;
            this.bt_AccountCancel.Click += new System.EventHandler(this.bt_AccountCancel_Click);
            // 
            // SelectAccountTypeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 100);
            this.Controls.Add(this.bt_AccountCancel);
            this.Controls.Add(this.bt_AccountSelect);
            this.Controls.Add(this.cb_AccountTypeList);
            this.Name = "SelectAccountTypeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SelectAccountTypeDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_AccountTypeList;
        private System.Windows.Forms.Button bt_AccountSelect;
        private System.Windows.Forms.Button bt_AccountCancel;
    }
}
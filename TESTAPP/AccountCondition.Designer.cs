namespace TESTAPP
{
    partial class AccountCondition
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
            this.flp_Condition = new System.Windows.Forms.FlowLayoutPanel();
            this.bt_AccountCondition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flp_Condition
            // 
            this.flp_Condition.Location = new System.Drawing.Point(34, 8);
            this.flp_Condition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flp_Condition.Name = "flp_Condition";
            this.flp_Condition.Size = new System.Drawing.Size(488, 241);
            this.flp_Condition.TabIndex = 0;
            // 
            // bt_AccountCondition
            // 
            this.bt_AccountCondition.Location = new System.Drawing.Point(206, 270);
            this.bt_AccountCondition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bt_AccountCondition.Name = "bt_AccountCondition";
            this.bt_AccountCondition.Size = new System.Drawing.Size(114, 22);
            this.bt_AccountCondition.TabIndex = 1;
            this.bt_AccountCondition.Text = "확인";
            this.bt_AccountCondition.UseVisualStyleBackColor = true;
            this.bt_AccountCondition.Click += new System.EventHandler(this.bt_AccountCondition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "미구현";
            // 
            // AccountCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_AccountCondition);
            this.Controls.Add(this.flp_Condition);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AccountCondition";
            this.Text = "AccountCondition";
            this.Load += new System.EventHandler(this.AccountCondition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_Condition;
        private System.Windows.Forms.Button bt_AccountCondition;
        private System.Windows.Forms.Label label1;
    }
}
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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flp_Condition
            // 
            this.flp_Condition.Location = new System.Drawing.Point(48, 12);
            this.flp_Condition.Name = "flp_Condition";
            this.flp_Condition.Size = new System.Drawing.Size(673, 361);
            this.flp_Condition.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 405);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AccountCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flp_Condition);
            this.Name = "AccountCondition";
            this.Text = "AccountCondition";
            this.Load += new System.EventHandler(this.AccountCondition_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_Condition;
        private System.Windows.Forms.Button button1;
    }
}
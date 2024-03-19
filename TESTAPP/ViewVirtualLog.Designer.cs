namespace TESTAPP
{
    partial class ViewVirtualLog
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
            this.dgv_virtualView = new System.Windows.Forms.DataGridView();
            this.bt_Ok = new System.Windows.Forms.Button();
            this.lb_View_withdraw = new System.Windows.Forms.Label();
            this.lb_View_income = new System.Windows.Forms.Label();
            this.txt_View_income = new System.Windows.Forms.TextBox();
            this.txt_View_withdraw = new System.Windows.Forms.TextBox();
            this.lb_View_interest = new System.Windows.Forms.Label();
            this.txt_View_interest = new System.Windows.Forms.TextBox();
            this.lb_View_Amount = new System.Windows.Forms.Label();
            this.txt_View_Amount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_virtualView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_virtualView
            // 
            this.dgv_virtualView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_virtualView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_virtualView.Location = new System.Drawing.Point(35, 28);
            this.dgv_virtualView.Name = "dgv_virtualView";
            this.dgv_virtualView.ReadOnly = true;
            this.dgv_virtualView.RowHeadersWidth = 62;
            this.dgv_virtualView.RowTemplate.Height = 23;
            this.dgv_virtualView.Size = new System.Drawing.Size(705, 375);
            this.dgv_virtualView.TabIndex = 0;
            // 
            // bt_Ok
            // 
            this.bt_Ok.Location = new System.Drawing.Point(445, 419);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(72, 22);
            this.bt_Ok.TabIndex = 1;
            this.bt_Ok.Text = "확인";
            this.bt_Ok.UseVisualStyleBackColor = true;
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // lb_View_withdraw
            // 
            this.lb_View_withdraw.AutoSize = true;
            this.lb_View_withdraw.Location = new System.Drawing.Point(762, 134);
            this.lb_View_withdraw.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_View_withdraw.Name = "lb_View_withdraw";
            this.lb_View_withdraw.Size = new System.Drawing.Size(57, 12);
            this.lb_View_withdraw.TabIndex = 3;
            this.lb_View_withdraw.Text = "출금 총액";
            // 
            // lb_View_income
            // 
            this.lb_View_income.AutoSize = true;
            this.lb_View_income.Location = new System.Drawing.Point(762, 51);
            this.lb_View_income.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_View_income.Name = "lb_View_income";
            this.lb_View_income.Size = new System.Drawing.Size(57, 12);
            this.lb_View_income.TabIndex = 4;
            this.lb_View_income.Text = "입금 총액";
            // 
            // txt_View_income
            // 
            this.txt_View_income.Location = new System.Drawing.Point(760, 85);
            this.txt_View_income.Margin = new System.Windows.Forms.Padding(2);
            this.txt_View_income.Name = "txt_View_income";
            this.txt_View_income.ReadOnly = true;
            this.txt_View_income.Size = new System.Drawing.Size(196, 21);
            this.txt_View_income.TabIndex = 5;
            this.txt_View_income.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_View_withdraw
            // 
            this.txt_View_withdraw.Location = new System.Drawing.Point(760, 163);
            this.txt_View_withdraw.Margin = new System.Windows.Forms.Padding(2);
            this.txt_View_withdraw.Name = "txt_View_withdraw";
            this.txt_View_withdraw.ReadOnly = true;
            this.txt_View_withdraw.Size = new System.Drawing.Size(196, 21);
            this.txt_View_withdraw.TabIndex = 6;
            this.txt_View_withdraw.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_View_interest
            // 
            this.lb_View_interest.AutoSize = true;
            this.lb_View_interest.Location = new System.Drawing.Point(764, 211);
            this.lb_View_interest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_View_interest.Name = "lb_View_interest";
            this.lb_View_interest.Size = new System.Drawing.Size(57, 12);
            this.lb_View_interest.TabIndex = 7;
            this.lb_View_interest.Text = "이자 총액";
            // 
            // txt_View_interest
            // 
            this.txt_View_interest.Location = new System.Drawing.Point(760, 240);
            this.txt_View_interest.Margin = new System.Windows.Forms.Padding(2);
            this.txt_View_interest.Name = "txt_View_interest";
            this.txt_View_interest.ReadOnly = true;
            this.txt_View_interest.Size = new System.Drawing.Size(196, 21);
            this.txt_View_interest.TabIndex = 8;
            this.txt_View_interest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_View_Amount
            // 
            this.lb_View_Amount.AutoSize = true;
            this.lb_View_Amount.Location = new System.Drawing.Point(764, 285);
            this.lb_View_Amount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_View_Amount.Name = "lb_View_Amount";
            this.lb_View_Amount.Size = new System.Drawing.Size(29, 12);
            this.lb_View_Amount.TabIndex = 9;
            this.lb_View_Amount.Text = "잔액";
            // 
            // txt_View_Amount
            // 
            this.txt_View_Amount.Location = new System.Drawing.Point(760, 316);
            this.txt_View_Amount.Margin = new System.Windows.Forms.Padding(2);
            this.txt_View_Amount.Name = "txt_View_Amount";
            this.txt_View_Amount.ReadOnly = true;
            this.txt_View_Amount.Size = new System.Drawing.Size(196, 21);
            this.txt_View_Amount.TabIndex = 10;
            this.txt_View_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ViewVirtualLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 461);
            this.Controls.Add(this.txt_View_Amount);
            this.Controls.Add(this.lb_View_Amount);
            this.Controls.Add(this.txt_View_interest);
            this.Controls.Add(this.lb_View_interest);
            this.Controls.Add(this.txt_View_withdraw);
            this.Controls.Add(this.txt_View_income);
            this.Controls.Add(this.lb_View_income);
            this.Controls.Add(this.lb_View_withdraw);
            this.Controls.Add(this.bt_Ok);
            this.Controls.Add(this.dgv_virtualView);
            this.Name = "ViewVirtualLog";
            this.Text = "ViewCounditionLog";
            this.Load += new System.EventHandler(this.ViewCounditionLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_virtualView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_virtualView;
        private System.Windows.Forms.Button bt_Ok;
        private System.Windows.Forms.Label lb_View_withdraw;
        private System.Windows.Forms.TextBox txt_View_income;
        private System.Windows.Forms.TextBox txt_View_withdraw;
        private System.Windows.Forms.TextBox txt_View_interest;
        private System.Windows.Forms.Label lb_View_Amount;
        private System.Windows.Forms.TextBox txt_View_Amount;
        private System.Windows.Forms.Label lb_View_income;
        private System.Windows.Forms.Label lb_View_interest;
    }
}
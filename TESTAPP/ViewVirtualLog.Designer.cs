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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_virtualView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_virtualView
            // 
            this.dgv_virtualView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_virtualView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_virtualView.Location = new System.Drawing.Point(50, 42);
            this.dgv_virtualView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_virtualView.Name = "dgv_virtualView";
            this.dgv_virtualView.ReadOnly = true;
            this.dgv_virtualView.RowHeadersWidth = 62;
            this.dgv_virtualView.RowTemplate.Height = 23;
            this.dgv_virtualView.Size = new System.Drawing.Size(1007, 562);
            this.dgv_virtualView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(517, 624);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 33);
            this.button1.TabIndex = 1;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewVirtualLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 675);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_virtualView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ViewVirtualLog";
            this.Text = "ViewCounditionLog";
            this.Load += new System.EventHandler(this.ViewCounditionLog_Load);
            this.Enter += new System.EventHandler(this.ViewVirtualLog_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_virtualView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_virtualView;
        private System.Windows.Forms.Button button1;
    }
}
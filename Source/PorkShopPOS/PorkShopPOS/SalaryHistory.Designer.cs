namespace PorkShopPOS
{
    partial class SalaryHistory
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
            this.salHistoryDGV = new System.Windows.Forms.DataGridView();
            this.nameLab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.salHistoryDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // salHistoryDGV
            // 
            this.salHistoryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salHistoryDGV.Location = new System.Drawing.Point(12, 76);
            this.salHistoryDGV.Name = "salHistoryDGV";
            this.salHistoryDGV.RowTemplate.Height = 24;
            this.salHistoryDGV.Size = new System.Drawing.Size(575, 476);
            this.salHistoryDGV.TabIndex = 0;
            // 
            // nameLab
            // 
            this.nameLab.AutoSize = true;
            this.nameLab.Location = new System.Drawing.Point(235, 31);
            this.nameLab.Name = "nameLab";
            this.nameLab.Size = new System.Drawing.Size(46, 17);
            this.nameLab.TabIndex = 1;
            this.nameLab.Text = "label1";
            // 
            // SalaryHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 564);
            this.Controls.Add(this.nameLab);
            this.Controls.Add(this.salHistoryDGV);
            this.Name = "SalaryHistory";
            this.Text = "Salary History";
            this.Load += new System.EventHandler(this.SalaryHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salHistoryDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView salHistoryDGV;
        private System.Windows.Forms.Label nameLab;
    }
}
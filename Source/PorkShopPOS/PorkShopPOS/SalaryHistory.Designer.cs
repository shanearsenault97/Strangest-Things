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
            this.fromtoL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.salHistoryDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // salHistoryDGV
            // 
            this.salHistoryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salHistoryDGV.Location = new System.Drawing.Point(9, 62);
            this.salHistoryDGV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.salHistoryDGV.Name = "salHistoryDGV";
            this.salHistoryDGV.RowTemplate.Height = 24;
            this.salHistoryDGV.Size = new System.Drawing.Size(431, 387);
            this.salHistoryDGV.TabIndex = 0;
            // 
            // fromtoL
            // 
            this.fromtoL.AutoSize = true;
            this.fromtoL.Location = new System.Drawing.Point(176, 25);
            this.fromtoL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fromtoL.Name = "fromtoL";
            this.fromtoL.Size = new System.Drawing.Size(35, 13);
            this.fromtoL.TabIndex = 1;
            this.fromtoL.Text = "label1";
            // 
            // SalaryHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 458);
            this.Controls.Add(this.fromtoL);
            this.Controls.Add(this.salHistoryDGV);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SalaryHistory";
            this.Text = "Salary History";
            this.Load += new System.EventHandler(this.SalaryHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salHistoryDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView salHistoryDGV;
        private System.Windows.Forms.Label fromtoL;
    }
}
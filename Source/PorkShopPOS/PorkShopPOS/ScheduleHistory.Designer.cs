namespace PorkShopPOS
{
    partial class ScheduleHistory
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
            this.schHistoryDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.schHistoryDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // schHistoryDGV
            // 
            this.schHistoryDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.schHistoryDGV.Location = new System.Drawing.Point(78, 34);
            this.schHistoryDGV.Margin = new System.Windows.Forms.Padding(2);
            this.schHistoryDGV.Name = "schHistoryDGV";
            this.schHistoryDGV.RowTemplate.Height = 24;
            this.schHistoryDGV.Size = new System.Drawing.Size(431, 387);
            this.schHistoryDGV.TabIndex = 1;
            // 
            // ScheduleHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 432);
            this.Controls.Add(this.schHistoryDGV);
            this.Name = "ScheduleHistory";
            this.Text = "ScheduleHistory";
            this.Load += new System.EventHandler(this.ScheduleHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schHistoryDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView schHistoryDGV;
    }
}
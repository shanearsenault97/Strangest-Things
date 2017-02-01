namespace PorkShopPOS
{
    partial class PayrollShowAll
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
            this.payShowDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.payShowDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // payShowDGV
            // 
            this.payShowDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.payShowDGV.Location = new System.Drawing.Point(12, 12);
            this.payShowDGV.Name = "payShowDGV";
            this.payShowDGV.RowTemplate.Height = 24;
            this.payShowDGV.Size = new System.Drawing.Size(726, 790);
            this.payShowDGV.TabIndex = 0;
            // 
            // PayrollShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 807);
            this.Controls.Add(this.payShowDGV);
            this.Name = "PayrollShowAll";
            this.Text = "PayrollShowAll";
            this.Load += new System.EventHandler(this.PayrollShowAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.payShowDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView payShowDGV;
    }
}
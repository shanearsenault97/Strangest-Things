namespace PorkShopPOS
{
    partial class EmployeeShowAllForm
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
            this.empShowDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.empShowDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // empShowDGV
            // 
            this.empShowDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empShowDGV.Location = new System.Drawing.Point(12, 12);
            this.empShowDGV.Name = "empShowDGV";
            this.empShowDGV.RowTemplate.Height = 24;
            this.empShowDGV.Size = new System.Drawing.Size(1501, 747);
            this.empShowDGV.TabIndex = 0;
            // 
            // EmployeeShowAllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 771);
            this.Controls.Add(this.empShowDGV);
            this.Name = "EmployeeShowAllForm";
            this.Text = "Employees ";
            this.Load += new System.EventHandler(this.EmployeeShowAllForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.empShowDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView empShowDGV;
    }
}
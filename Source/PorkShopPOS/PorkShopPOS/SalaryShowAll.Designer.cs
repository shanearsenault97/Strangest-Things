namespace PorkShopPOS
{
    partial class SalaryShowAll
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
            this.salShowDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.salShowDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // salShowDGV
            // 
            this.salShowDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salShowDGV.Location = new System.Drawing.Point(12, 3);
            this.salShowDGV.Name = "salShowDGV";
            this.salShowDGV.RowTemplate.Height = 24;
            this.salShowDGV.Size = new System.Drawing.Size(670, 767);
            this.salShowDGV.TabIndex = 0;
            // 
            // SalaryShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 791);
            this.Controls.Add(this.salShowDGV);
            this.Name = "SalaryShowAll";
            this.Text = "Salaries";
            this.Load += new System.EventHandler(this.SalaryShowAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salShowDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView salShowDGV;
    }
}
namespace PorkShopPOS
{
    partial class MenuItemsShowAll
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
            this.menuShowDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.menuShowDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // menuShowDGV
            // 
            this.menuShowDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.menuShowDGV.Location = new System.Drawing.Point(13, 13);
            this.menuShowDGV.Name = "menuShowDGV";
            this.menuShowDGV.RowTemplate.Height = 24;
            this.menuShowDGV.Size = new System.Drawing.Size(449, 696);
            this.menuShowDGV.TabIndex = 0;
            // 
            // MenuItemsShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 721);
            this.Controls.Add(this.menuShowDGV);
            this.Name = "MenuItemsShowAll";
            this.Text = "Menu Items";
            this.Load += new System.EventHandler(this.MenuItemsShowAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.menuShowDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView menuShowDGV;
    }
}
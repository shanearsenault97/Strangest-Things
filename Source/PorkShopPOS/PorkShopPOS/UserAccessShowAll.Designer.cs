namespace PorkShopPOS
{
    partial class UserAccessShowAll
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
            this.userAccessDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.userAccessDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // userAccessDGV
            // 
            this.userAccessDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userAccessDGV.Location = new System.Drawing.Point(12, 12);
            this.userAccessDGV.Name = "userAccessDGV";
            this.userAccessDGV.RowTemplate.Height = 24;
            this.userAccessDGV.Size = new System.Drawing.Size(553, 622);
            this.userAccessDGV.TabIndex = 0;
            // 
            // UserAccessShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 646);
            this.Controls.Add(this.userAccessDGV);
            this.Name = "UserAccessShowAll";
            this.Text = "User Access Data";
            this.Load += new System.EventHandler(this.UserAccessShowAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userAccessDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView userAccessDGV;
    }
}
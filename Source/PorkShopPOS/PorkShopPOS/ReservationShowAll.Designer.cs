namespace PorkShopPOS
{
    partial class ReservationShowAll
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
            this.reservationDGV = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.reservationDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // reservationDGV
            // 
            this.reservationDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reservationDGV.Location = new System.Drawing.Point(13, 13);
            this.reservationDGV.Name = "reservationDGV";
            this.reservationDGV.Size = new System.Drawing.Size(259, 237);
            this.reservationDGV.TabIndex = 0;
            // 
            // ReservationShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.reservationDGV);
            this.Name = "ReservationShowAll";
            this.Text = "ReservationShowAll";
            this.Load += new System.EventHandler(this.ReservationShowAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reservationDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView reservationDGV;
    }
}
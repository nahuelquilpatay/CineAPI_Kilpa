namespace FrontEnd.Presentaciones
{
    partial class frmTicketsTipospago
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
            this.dgvTicketsTipos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketsTipos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTicketsTipos
            // 
            this.dgvTicketsTipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTicketsTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTicketsTipos.Location = new System.Drawing.Point(12, 12);
            this.dgvTicketsTipos.Name = "dgvTicketsTipos";
            this.dgvTicketsTipos.RowTemplate.Height = 25;
            this.dgvTicketsTipos.Size = new System.Drawing.Size(776, 169);
            this.dgvTicketsTipos.TabIndex = 0;
            // 
            // frmTicketsTipospago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 194);
            this.Controls.Add(this.dgvTicketsTipos);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmTicketsTipospago";
            this.Text = "TICKETS POR TIPO DE PAGO";
            this.Load += new System.EventHandler(this.frmTicketsTipospago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketsTipos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvTicketsTipos;
    }
}
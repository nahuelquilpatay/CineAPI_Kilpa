namespace FrontEnd.Presentaciones
{
    partial class frmPelisRecaudacion
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
            this.dgvPelisRec = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelisRec)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPelisRec
            // 
            this.dgvPelisRec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPelisRec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPelisRec.Location = new System.Drawing.Point(12, 12);
            this.dgvPelisRec.Name = "dgvPelisRec";
            this.dgvPelisRec.RowTemplate.Height = 25;
            this.dgvPelisRec.Size = new System.Drawing.Size(718, 285);
            this.dgvPelisRec.TabIndex = 0;
            // 
            // frmPelisRecaudacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(742, 309);
            this.Controls.Add(this.dgvPelisRec);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmPelisRecaudacion";
            this.Text = "PELÍCULAS Y SU RECAUDACIÓN";
            this.Load += new System.EventHandler(this.frmPelisRecaudacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPelisRec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvPelisRec;
    }
}
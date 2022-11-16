namespace FrontEnd.Presentaciones
{
    partial class frmFuncRecaudacion
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
            this.dgvReporte1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReporte1
            // 
            this.dgvReporte1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte1.Location = new System.Drawing.Point(12, 12);
            this.dgvReporte1.Name = "dgvReporte1";
            this.dgvReporte1.RowTemplate.Height = 25;
            this.dgvReporte1.Size = new System.Drawing.Size(776, 287);
            this.dgvReporte1.TabIndex = 0;
            // 
            // frmFuncRecaudacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 312);
            this.Controls.Add(this.dgvReporte1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmFuncRecaudacion";
            this.Text = "FUNCIONES Y RECAUDACIÓN";
            this.Load += new System.EventHandler(this.frmFuncRecaudacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvReporte1;
    }
}
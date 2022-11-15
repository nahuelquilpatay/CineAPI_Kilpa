namespace FrontEnd.Presentaciones
{
    partial class frmConsultarTickets
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
            this.dvgTickets = new System.Windows.Forms.DataGridView();
            this.btnAnular = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgTickets
            // 
            this.dvgTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnAnular});
            this.dvgTickets.Location = new System.Drawing.Point(12, 12);
            this.dvgTickets.Name = "dvgTickets";
            this.dvgTickets.RowTemplate.Height = 25;
            this.dvgTickets.Size = new System.Drawing.Size(776, 395);
            this.dvgTickets.TabIndex = 0;
            this.dvgTickets.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgTickets_CellContentClick);
            // 
            // btnAnular
            // 
            this.btnAnular.HeaderText = "Acciones";
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Text = "ANULAR";
            this.btnAnular.UseColumnTextForButtonValue = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(682, 415);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(106, 29);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmConsultarTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dvgTickets);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmConsultarTickets";
            this.Text = "CONSULTAR TICKETS";
            this.Load += new System.EventHandler(this.frmConsultarTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgTickets)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dvgTickets;
        private Button btnSalir;
        private DataGridViewButtonColumn btnAnular;
    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd.Presentaciones
{
    public partial class frmAtajos : Form
    {
        public frmAtajos()
        {
            InitializeComponent();
        }

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaTickets fr = new frmAltaTickets();
            fr.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAltaClientes cliente = new frmAltaClientes();
            cliente.ShowDialog();
        }

        private void funcionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AltaFuncion altaFuncion = new AltaFuncion();
            altaFuncion.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmAtajos_Load(object sender, EventArgs e)
        {
           
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void nosotrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNosotros n = new frmNosotros();
            n.ShowDialog();
        }

        private void rECAUDACIÓNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFuncRecaudacion frr = new frmFuncRecaudacion();
            frr.ShowDialog();
        }

        private void pORTIPOSDEPAGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTicketsTipospago ttt = new frmTicketsTipospago();
            ttt.ShowDialog();
        }

        private void rECAUDACIÓNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmPelisRecaudacion pre = new frmPelisRecaudacion();
            pre.ShowDialog();
        }
    }
}

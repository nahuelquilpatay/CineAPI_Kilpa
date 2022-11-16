using Backend.Servicios;
using Backend.Servicios.Interfaces;
using System;
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
    public partial class frmFuncRecaudacion : Form
    {
        private IServicio servicio1;

        public frmFuncRecaudacion()
        {
            InitializeComponent();
            servicio1 = new FabricaServiciosImp().CrearServicio();
        }

        private void frmFuncRecaudacion_Load(object sender, EventArgs e)
        {
            dgvReporte1.DataSource = servicio1.getConsultarReportes("funcRecaudacion");
        }
    }
}

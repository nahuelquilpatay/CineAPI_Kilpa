using Backend.Datos;
using Backend.Dominio;
using Backend.Servicios.Interfaces;
using Newtonsoft.Json;
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
    public partial class frmConsultarTickets : Form
    {
        public frmConsultarTickets()
        {
            InitializeComponent();
        }

        private IServicio servicio;
        private DetalleTicket detalle;
        private Ticket oTicket;
        private Cliente cliente;
        private static frmConsultarTickets instancia = null;

        private async void frmConsultarTickets_Load(object sender, EventArgs e)
        {
            await cargarTickets();
        }
        private async Task cargarTickets()
        {
            string url = "https://localhost:7066/consultaTickets"; 
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Ticket>>(data);
            dvgTickets.DataSource = lst;
        }
        private async Task<List<Cliente>?> cargarClientes2() // no lo usamos
        { 
            string url = "https://localhost:7066/consultarClientes"; //cambiar
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Cliente>>(data);
            return lst;
        }
        private async Task<List<DetalleTicket>?> cargarDetalle() // no lo usamos
        {
            string url = "https://localhost:7066/consultarClientes"; //cambiar
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<DetalleTicket>>(data);
            return lst;
        }
        private async Task anularTicket(int id)
        {
            var url = "https://localhost:7066/eliminarTicket?id=" + id;
            var result = await ClientSingleton.GetInstancia().DeleteAsync(url);
            if (result == "false")
            {
                MessageBox.Show("¡ERROR! ACCIÓN NO PERMITIDA EN ESTA FUNCIÓN");
            }
        }
        private async void dvgTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int entero;
            if (dvgTickets.CurrentCell.ColumnIndex == 0)
            {
                entero = Convert.ToInt32(dvgTickets.CurrentRow.Cells[1].Value);
                await anularTicket(entero);
            }
            await cargarTickets();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Volver?","VOLVIENDO",MessageBoxButtons.YesNo,MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}

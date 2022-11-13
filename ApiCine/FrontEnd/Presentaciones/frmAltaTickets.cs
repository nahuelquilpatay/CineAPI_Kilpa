﻿using Backend.Datos;
using Backend.Dominio;
using Backend.Servicios;
using Backend.Servicios.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrontEnd.Presentaciones
{
    public partial class frmAltaTickets : Form
    {
        private IServicio servicio;
        private DetalleTicket detalle;
        private Ticket oTicket;
        private Cliente cliente;
        private static frmAltaTickets instancia = null;

        public frmAltaTickets()
        {
            InitializeComponent();
            servicio = new FabricaServiciosImp().CrearServicio();
            oTicket = new Ticket();
            detalle = new DetalleTicket();
        }

        private async void frmAltaTickets_Load(object sender, EventArgs e)
        {
            await cargarFunciones();
            await cargarTipoPago();
            await cargarClientes();
            await textooTicket();
        }
        private async Task cargarFunciones()
        {
            string url = "https://localhost:7066/consultaFunciones";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Funcion>>(data);
            cboFuncion.DataSource = lst;
            cboFuncion.DisplayMember = "id_funcion";
            cboFuncion.ValueMember = "id_funcion";
            cboFuncion.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private async Task cargarTipoPago()
        {
            string url = "https://localhost:7066/consultaTipoPago";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<TipoPago>>(data);
            cboTipoPagos.DataSource = lst;
            cboTipoPagos.DisplayMember = "nombreTipo";
            cboTipoPagos.ValueMember = "idTipoPago";
            cboTipoPagos.DropDownStyle = ComboBoxStyle.DropDownList;  
        }
        private async Task cargarClientes()
        {
            string url = "https://localhost:7066/consultarClientes";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Cliente>>(data);
            cboClientes.DataSource = lst;
            cboClientes.DisplayMember ="Dni";
            cboClientes.ValueMember = "Id_Cliente";
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private async Task<List<Cliente>> cargarClientes2()
        {
            string url = "https://localhost:7066/consultarClientes";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Cliente>>(data);
            return lst;
        }
        private async Task<bool> insertarTicketAsync()
        {
            oTicket.Pago = cboTipoPagos.SelectedIndex + 1;
            oTicket.Cliente = cboClientes.SelectedIndex + 1;
        
            var bodyContent = JsonConvert.SerializeObject(oTicket);
            string url = "https://localhost:7066/Ticket22";
            var result = await ClientSingleton.GetInstancia().PostAsync(url, bodyContent);
            if (result.Equals("true"))
            {
                MessageBox.Show("INSERTADO CORRECTAMENTE");
                return true;
            }
            else
            {
                MessageBox.Show("ERROR INTERNO, CONTACTE UN ADMINISTRADOR");
                return false;
            } 
        }  
        private async Task insertarDetalles()
        {

        }
        private bool Validar()
        {
            bool ok = true;

            if (cboButaca.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione butaca");
                cboButaca.Focus();
                ok = false;
            }
            if (cboFuncion.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione función");
                cboFuncion.Focus();
                ok = false;
            }

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["id_butaca"].Value.ToString().Equals(cboButaca.Text) & row.Cells["id_funcion"].Value.ToString().Equals(cboFuncion.Text))
                {
                    MessageBox.Show("Butaca ya reservada");
                    ok = false;
                }
                
            }
            if (txtDescuento.Text == "")
            {
                MessageBox.Show("Seleccionar descuento");
                txtDescuento.Focus();
                ok = false;
            }
            else
            {
                try
                {
                    Convert.ToInt32(txtDescuento.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Solo números");
                    txtDescuento.Focus();
                    ok = false;
                }
            }
            return ok;
        }
        private void limpiar()
        {
            cboFuncion.SelectedValue = -1;
            cboButaca.SelectedIndex = -1;
            cboClientes.SelectedValue = -1;
            cboTipoPagos.SelectedValue = -1;
            txtDescuento.Text = Convert.ToString(0);
            txtCosto2.Text = Convert.ToString(0);
            txtCosto.Text = Convert.ToString(0);
            txtTotal.Text = Convert.ToString(0);
            dgvDetalles.Rows.Clear();
        }
        private async void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (Validar())
            {
                //TRACKEAR LAS PELICULAS Y FUNCIONES ASI PODEMOS CARGAR EN LA DATAGRIDVIEW LOS DATOS CORRESPONDIENTES PARA UNA MEJOR VISUALIZACION

                Cliente cliente2 = (Cliente)cboClientes.SelectedItem;
                cliente2.Id_Cliente = (int)cboClientes.SelectedValue;

                TipoPago tp = (TipoPago)cboTipoPagos.SelectedItem;

                int Butaca = (int)cboButaca.SelectedIndex + 1;
                double Descuento = Convert.ToDouble(txtDescuento.Text);
                double Costo = Convert.ToDouble(txtCosto2.Text);
                int Funcion = Convert.ToInt32(cboFuncion.SelectedValue);

                DetalleTicket dt = new DetalleTicket(Costo,Butaca,Funcion,Descuento);
                oTicket.AgregarDetalle(dt);
  
                dgvDetalles.Rows.Add(new object[] { tp.nombreTipo, dt.Butaca, dt.Funcion,dt.Costo,dt.Descuento, cliente2.Nombre, cliente2.Apellido});

                txtCosto.Text = Convert.ToString(oTicket.CalcularSubTotal());
                CalcularTotal();
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Dispose();
            }
        }
        private async Task textooTicket()
        {
            string url = "https://localhost:7066/proximoTicket";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            int lst = JsonConvert.DeserializeObject<int>(data);
            lblProximoTicket.Text = "TICKET Nº " + lst;
        }
        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 7)
            {
                oTicket.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                txtCosto.Text = Convert.ToString(oTicket.CalcularSubTotal());
                CalcularTotal();
            }
        }
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            await insertarTicketAsync();
            limpiar();
            
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea cancelar?", "CANCELANDO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limpiar();
            }
        }
        private void CalcularTotal()
        {
            double total = oTicket.CalcularSubTotal();

            if (txtDescuento.Text != "")
            {
                double dto = (total * Convert.ToDouble(txtDescuento.Text)) / 100;
                txtTotal.Text = (total - dto).ToString();
            }
        }
    }
}

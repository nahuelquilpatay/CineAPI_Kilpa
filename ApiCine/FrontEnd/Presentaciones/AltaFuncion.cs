using Backend.Dominio;
using Backend.Servicios.Implementaciones;
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
using Backend.Datos;
using Newtonsoft.Json;

namespace FrontEnd.Presentaciones
{
    public partial class AltaFuncion : Form
    {
        private IServicio servicio1;
        private Funcion funcion;
        private Pelicula peli;
        private static AltaFuncion instancia = null;

        public AltaFuncion()
        {
            InitializeComponent();
            funcion = new Funcion();
            peli = new Pelicula();
            servicio1 = new FabricaServiciosImp().CrearServicio();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private  void AltaFuncion_Load(object sender, EventArgs e)
        {
              comboPeliculas();
              cargarFunciones2();
        }

        public static AltaFuncion ObtenerInstancia()
        {
            if (instancia == null || instancia.IsDisposed)
            {
                instancia = new AltaFuncion();
            }
            return instancia;
        }
       
        private async Task comboPeliculas()
        {
            string url = "https://localhost:7066/peliculas";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Pelicula>>(data);
            cmbPelicula.DataSource = lst;
            cmbPelicula.DisplayMember = "titulo";
            cmbPelicula.ValueMember = "id_pelicula";
            cmbPelicula.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private async Task cargarFunciones()
        {
            string url = "https://localhost:7066/consultaFunciones";
            var data = await ClientSingleton.GetInstancia().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Funcion>>(data);
            dvgFunciones.DataSource = lst; 
        }
        private async Task cargarFunciones2()
        {
            dvgFunciones.DataSource = servicio1.getConsultarFunciones();
        }

        private async Task insertFuncionesAsync()
        {

            funcion.Precio = Convert.ToDouble(txtPrecio.Text);
            funcion.Fecha = (DateTime)dateTimePicker1.Value;
            funcion.Sala = (int)nudSala.Value;
            funcion.Pelicula = Convert.ToInt32(cmbPelicula.SelectedIndex+1);

            string bodyContent = JsonConvert.SerializeObject(funcion);
            string url = "https://localhost:7066/crearFuncion";
            var result = await ClientSingleton.GetInstancia().PostAsync(url, bodyContent);

            if (result.Equals("1"))
            {
                MessageBox.Show("Funcion registrado", 
                    "Informe", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);              
            }
            else
            {   
                MessageBox.Show("Funcion no registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validarFuncion())
            {
                await insertFuncionesAsync();
                limpiar();
                await cargarFunciones();
            }   
        }
        
        private bool validarFuncion()
        {
            bool ok = true;

            if(cmbPelicula.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccionar película.");
                cmbPelicula.Focus();
                ok = false;
            }
            if(txtPrecio.Text == "")
            {
                MessageBox.Show("Ingresar precio.");
                txtPrecio.Focus();
                ok = false;
            }
            else
            {
                try
                {
                    Convert.ToDouble(txtPrecio.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Ingrese un número válido");
                    txtPrecio.Clear();
                    ok = false;
                }
            }
            if(nudSala.Value == 0 || nudSala.Value > 9)
            {
                MessageBox.Show("Seleccionar sala");
                nudSala.Focus();
                ok = false;
            }
            foreach (DataGridViewRow row in dvgFunciones.Rows)
            {
                if (row.Cells["Sala"].Value.ToString().Equals(nudSala.Value.ToString()) & row.Cells["Fecha"].Value.ToString().Equals(dateTimePicker1.Value.ToString()))
                {
                    MessageBox.Show("Sala ya reservada para la fecha");
                    ok = false;
                }
            }
            if (dateTimePicker1.Value < DateTime.Today)
            {
                MessageBox.Show("Ingresar funciones posteriores a la fecha de hoy");
                ok = false;
            }

            return ok;
        }

        private void limpiar()
        {
            dateTimePicker1.Value = DateTime.Today;
            cmbPelicula.SelectedIndex = -1;
            txtPrecio.Text = "";
            nudSala.Value = 1;
        }
        private async void dvgFunciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int entero;
            if (dvgFunciones.CurrentCell.ColumnIndex == 0)
            {
                entero = Convert.ToInt32(dvgFunciones.CurrentRow.Cells[1].Value);
                await delFunciones(entero);

            }
            await cargarFunciones();

        }
        private async Task delFunciones(int id)
        {
            var url = "https://localhost:7066/borrarFuncion?id=" + id;
            var result = await ClientSingleton.GetInstancia().DeleteAsync(url);
            if(result == "false")
            {
                MessageBox.Show("¡ERROR! ACCIÓN NO PERMITIDA EN ESTA FUNCIÓN");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Dispose();                             
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea limpiar los campos?", "CANCELANDO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                limpiar();
            }
        }
    }
}

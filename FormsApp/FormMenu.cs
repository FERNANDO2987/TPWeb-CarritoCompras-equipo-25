using Business;
using Business.Models;
using Business.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class FormMenu : Form
    {

        private ArticulosModule _articuloModule;
        
        private AccesoDatos _accesoDatos;
        public FormMenu()
        {
            InitializeComponent();


            _accesoDatos = new AccesoDatos();

            // Crear una instancia de ArticulosModule
            _articuloModule = new ArticulosModule(_accesoDatos);

            // Llamar al método listarArticulos y almacenar el resultado en una variable
            List<DetalleProducto> listaDeArticulos = _articuloModule.ObtenerListaDeArticulos();

            // Hacer algo con la lista de artículos, como mostrarla en un DataGridView
            dataGridViewArticulos.DataSource = listaDeArticulos;

            // Ocultar columnas
            OcultarColumnas();

        }

        //Metodo para ocultar las columnas que No necesito
        private void OcultarColumnas()
        {
            // Asegurarse de que las columnas existen antes de intentar ocultarlas
            if (dataGridViewArticulos.Columns["Id"] != null)
            {
                dataGridViewArticulos.Columns["Id"].Visible = false;
            }

            if (dataGridViewArticulos.Columns["IdMarca"] != null)
            {
                dataGridViewArticulos.Columns["IdMarca"].Visible = false;
            }
            if (dataGridViewArticulos.Columns["IdCategoria"] != null)
            {
                dataGridViewArticulos.Columns["IdCategoria"].Visible = false;
            }
           
        }


    }
}

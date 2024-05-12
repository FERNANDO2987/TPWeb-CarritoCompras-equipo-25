using Business;
using Business.Interfaces;
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
    public partial class Form : System.Windows.Forms.Form
    {
        private ArticulosModule _articulosModule;
        private IAccesoDatos _accesoDatos;
        private MarcasModule _marcasModule;
        public Form()
        {
            InitializeComponent();
   

            _accesoDatos = new AccesoDatos();
            // Crear una instancia de ArticulosModule
            _articulosModule = new ArticulosModule(_accesoDatos);
            _marcasModule = new MarcasModule(_accesoDatos);
            ProbarAgregarMarca();
            // Llamar al método listarArticulos y almacenar el resultado en una variable
            List<Articulos> listaDeArticulos = _articulosModule.listarAarticulos();

            // Hacer algo con la lista de artículos, como mostrarla en un DataGridView
            dataGridView1.DataSource = listaDeArticulos;

        }

        private void ProbarAgregarMarca()
        {
            try
            {
                // Crear una instancia de la marca que deseas agregar
                Marcas nuevaMarca = new Marcas
                {
                    Descripcion = "Nueva Marca exitosa" // Reemplaza "Nueva Marca" con la descripción real que deseas agregar
                };

                // Llamar al método AgregarMarca para agregar la nueva marca
                Marcas marcaAgregada = _marcasModule.AgregarMarca(nuevaMarca);

                if (marcaAgregada != null)
                {
                    // Mostrar un mensaje de éxito si la marca se agregó correctamente
                    MessageBox.Show($"Se agregó la marca con ID: {marcaAgregada.Id} y descripción: {marcaAgregada.Descripcion}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Mostrar un mensaje de error si la marca no se agregó correctamente
                    MessageBox.Show("Error al agregar la marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la ejecución del método AgregarMarca
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

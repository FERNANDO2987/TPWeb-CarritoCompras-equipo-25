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
        public Form()
        {
            InitializeComponent();

            // Crear una instancia de ArticulosModule
            _articulosModule = new ArticulosModule();

            // Llamar al método listarArticulos y almacenar el resultado en una variable
            List<Articulos> listaDeArticulos = _articulosModule.listarAarticulos();

            // Hacer algo con la lista de artículos, como mostrarla en un DataGridView
            dataGridView1.DataSource = listaDeArticulos;

        }
    }
}

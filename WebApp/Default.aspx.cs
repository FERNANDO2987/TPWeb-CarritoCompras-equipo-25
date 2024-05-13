using Business.Interfaces;
using Business;
using Business.Models;
using Business.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCategorias(); // Llama al método para cargar las categorías cuando la página se carga por primera vez
            }

        }

        private void CargarCategorias()
        {
            
            CategoriasModule categoriasModule = new CategoriasModule(new AccesoDatos()); 

            try
            {
                // Llama al método listarCategorias() para obtener la lista de categorías
                List<Categorias> listaCategorias = categoriasModule.listarCategorias();

                // Procesa la lista de categorías y agrega las opciones al DropDownList
                foreach (Categorias categoria in listaCategorias)
                {
                    // Agrega una nueva ListItem al DropDownList con el ID de la categoría como valor y la descripción como texto
                    DropDownListCategorias.Items.Add(new ListItem(categoria.Descripcion, categoria.Id.ToString()));
                }
            }
            catch (Exception ex)
            {
                
            }
        }


    }
}
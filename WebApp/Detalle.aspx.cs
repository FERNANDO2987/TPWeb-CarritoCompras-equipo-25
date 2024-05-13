using Business.Interfaces;
using Business.Models;
using Business.Modules;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Detalle : System.Web.UI.Page
    {

        protected List<Imagenes> Imagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // Crear una instancia de AccesoDatos (o de alguna clase que implemente IAccesoDatos)
            IAccesoDatos accesoDatos = new AccesoDatos();

            // Crear una instancia de ImagenesModule, pasando el accesoDatos como argumento
            ImagenesModule moduloImagenes = new ImagenesModule(accesoDatos);

            // Llamar al método listarImagenes()
            Imagenes = moduloImagenes.listarImagenes();

        }
    }
}
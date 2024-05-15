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

        protected DetalleProducto detalleProducto { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string idParam = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idParam) && int.TryParse(idParam, out int productoId))
                {
                    // Crear una instancia de AccesoDatos (o de alguna clase que implemente IAccesoDatos)
                    IAccesoDatos accesoDatos = new AccesoDatos();

                    // Crear una instancia de DetalleModule, pasando accesoDatos como argumento
                    DetalleModule moduloDetalle = new DetalleModule(accesoDatos);

                    // Obtener los detalles del producto por ID
                    detalleProducto = moduloDetalle.ObtenerDetallePorId(productoId);

                    if (detalleProducto == null)
                    {
                        // Manejar el caso en que el producto no se encuentra
                        Response.Write("<p>Producto no encontrado.</p>");
                    }
                }
                else
                {
                    // Manejar el caso en que no se proporciona un ID válido
                    Response.Write("<p>ID de producto no especificado o inválido.</p>");
                }
            }

        }
    }
}
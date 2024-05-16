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
                    try
                    {
                        IAccesoDatos accesoDatos = new AccesoDatos();
                        DetalleModule moduloDetalle = new DetalleModule(accesoDatos);
                        detalleProducto = moduloDetalle.ObtenerDetallePorId(productoId);

                        if (detalleProducto != null)
                        {
                            lblProductName.Text = detalleProducto.Nombre;
                            lblProductDescription.Text = detalleProducto.Descripcion;

                            // Bind the repeater to display all images
                            rptImages.DataSource = detalleProducto.ImagenURLs;
                            rptImages.DataBind();

                            ProductDetailsPanel.Visible = true;
                        }
                        else
                        {
                            lblMessage.Text = "Producto no encontrado.";
                            lblMessage.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = "Ocurrió un error al obtener los detalles del producto. Inténtalo de nuevo más tarde.";
                        lblMessage.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "ID de producto no especificado o inválido.";
                    lblMessage.Visible = true;
                }
            }
        }

    }
}
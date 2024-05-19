using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Articulo
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string ImagenURL { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
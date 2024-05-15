using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class DetalleProducto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        public int IdMarca { get; set; }
        public string DescripcionMarca { get; set; }
        public int IdCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public decimal Precio { get; set; }
        public string ImagenURL { get; set; }
    }
}

using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IArticulosModule
    {
        List<Articulos> listarAarticulos();
        void AgregarArticulo(Articulos articulo);
        bool eliminarArticulo(int id);
        void ModificarArticulo(Articulos articulo);
    }
}

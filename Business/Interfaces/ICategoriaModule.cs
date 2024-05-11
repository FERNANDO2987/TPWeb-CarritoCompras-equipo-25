using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface ICategoriaModule
    {
        List<Categorias> listarCategorias();
        void AgregarCategoria(Categorias categorias);

        bool eliminarCategoria(int id);
        void ModificarCategoria(Categorias categorias);

    }
}

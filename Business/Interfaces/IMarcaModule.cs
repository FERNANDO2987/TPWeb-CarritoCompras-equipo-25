using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMarcaModule
    {
        List<Marcas> listarMarcas();
        void AgregarMarca(Marcas marcas);

        bool eliminarmarca(int id);
        void ModificarMarca(Marcas marcas);

    }
}

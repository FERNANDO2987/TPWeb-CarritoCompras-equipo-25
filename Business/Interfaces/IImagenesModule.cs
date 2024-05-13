using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IImagenesModule
    {
        List<Imagenes> listarImagenes();
        Imagenes AgregarImagenes(Imagenes imagenes);

        bool eliminarImagenes(int id);
        void ModificarImagen(Imagenes imagenes);

    }
}

using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class ImagenesModule : IImagenesModule
    {
        private readonly IAccesoDatos _accesoDatos;

        public ImagenesModule(IAccesoDatos accesoDatos) 
        {
          _accesoDatos = accesoDatos;
        }
        public Imagenes AgregarImagenes(Imagenes imagenes)
        {
            var error = "";
            var result = new Imagenes();

            try
            {
                _accesoDatos.setearConsulta("INSERT INTO IMAGENES (IdArticulo,ImagenUrl) VALUES (@IdArticulo,@ImagenUrl); SELECT SCOPE_IDENTITY();");

                _accesoDatos.setearParametro("@IdArticulo", imagenes.IdArticulo.ToString() ?? throw new ArgumentException("El IdAarticulo no puede ser nulo o vacía.", nameof(imagenes.IdArticulo)));
                _accesoDatos.setearParametro("@Descripcion", imagenes.ImagenURL ?? throw new ArgumentException("La imagen no puede ser nula o vacía.", nameof(imagenes.ImagenURL)));

                // Ejecutar la consulta y obtener el ID generado automáticamente
                _accesoDatos.ejecutarLectura();

                if (_accesoDatos.Lector.HasRows)
                {
                    while (_accesoDatos.Lector.Read())
                    {
                        result.Id = Convert.ToInt32(_accesoDatos.Lector[0]);
                        result.IdArticulo = imagenes.IdArticulo;
                        result.ImagenURL = imagenes.ImagenURL;
                    
                    }
                }
            }
            catch (Exception ex)
            {
                error = "Error de conexión de SQL " + ex.Message;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }

            return result;
        }

        public bool eliminarImagenes(int id)
        {
            try
            {
                _accesoDatos.setearConsulta("DELETE FROM IMAGENES WHERE Id = @Id");
                _accesoDatos.setearParametro("@Id", id.ToString()); // Convertir el ID a string
                _accesoDatos.ejecutarLectura(); // Ejecutar la acción de eliminación

                // Si llegamos aquí sin lanzar una excepción, asumimos que la eliminación fue exitosa
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                _accesoDatos.cerrarConexion(); // Asegurarnos de cerrar la conexión
            }
        }

        public List<Imagenes> listarImagenes()
        {
            var lista = new List<Imagenes>();

            try
            {

                _accesoDatos.setearConsulta("Select Id,IdArticulo,ImagenUrl From IMAGENES");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Imagenes aux = new Imagenes();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.IdArticulo = (int)_accesoDatos.Lector["IdArticulo"];
                    aux.ImagenURL = (string)_accesoDatos.Lector["ImagenUrl"];


                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error de conexion a SQL: " + ex.Message);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

        public void ModificarImagen(Imagenes imagenes)
        {
            string error = "";

            try
            {
                _accesoDatos.setearConsulta("UPDATE IMAGENES SET ImagenUrl= @ImagenUrl WHERE Id = @Id");
                _accesoDatos.setearParametro("@Id", imagenes.Id.ToString());
                _accesoDatos.setearParametro("@ImagenUrl", imagenes.ImagenURL);


                _accesoDatos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                error = "Error de conexion de SQL " + ex.Message;
                throw;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }

        }
    }
}

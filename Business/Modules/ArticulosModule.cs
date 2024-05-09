using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class ArticulosModule : IArticulosModule
    {

        //Listar articulos
        public List<Articulos> listarAarticulos()
        {
            var listar = new List<Articulos>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("Select Id,Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio  From ARTICULOS");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    listar.Add(aux);

                }

                return listar;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Agregar un articulo
        public void AgregarArticulo(Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");

                datos.setearParametro("@Codigo", articulo.Codigo ?? throw new ArgumentException("El código del artículo no puede ser nulo o vacío.", nameof(articulo.Codigo)));
                datos.setearParametro("@Nombre", articulo.Nombre ?? throw new ArgumentException("El nombre del artículo no puede ser nulo o vacío.", nameof(articulo.Nombre)));
                datos.setearParametro("@Descripcion", articulo.Descripcion ?? throw new ArgumentException("La descripción del artículo no puede ser nula o vacía.", nameof(articulo.Descripcion)));
                datos.setearParametro("@IdMarca", articulo.IdMarca.ToString());
                datos.setearParametro("@IdCategoria", articulo.IdCategoria.ToString());
                datos.setearParametro("@Precio", articulo.Precio.ToString() ?? throw new ArgumentException("El precio del artículo no puede ser nulo o vacía.", nameof(articulo.Precio)));

                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Eliminar articulo

        public bool eliminarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id.ToString()); // Convertir el ID a string
                datos.ejecutarLectura(); // Ejecutar la acción de eliminación

                // Si llegamos aquí sin lanzar una excepción, asumimos que la eliminación fue exitosa
                return true;
            }
            catch (Exception ex)
            {
                // Manejar la excepción como consideres apropiado, por ejemplo, puedes registrarla o lanzarla nuevamente
                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); // Asegurarnos de cerrar la conexión
            }
        }



        public void ModificarArticulo(Articulos articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                datos.setearParametro("@Codigo", articulo.Codigo);
                datos.setearParametro("@Nombre", articulo.Nombre);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.IdMarca.ToString());
                datos.setearParametro("@IdCategoria", articulo.IdCategoria.ToString());
                datos.setearParametro("@Precio", articulo.Precio.ToString());
                datos.setearParametro("@Id", articulo.Id.ToString());

                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }




    }
}

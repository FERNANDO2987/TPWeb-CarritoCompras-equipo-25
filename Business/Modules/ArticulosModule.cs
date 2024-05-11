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
        private readonly IAccesoDatos _accesoDatos;

        public ArticulosModule(IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }

        //Listar articulos
        public List<Articulos> listarAarticulos()
        {
            var listar = new List<Articulos>();
      

            try
            {

                _accesoDatos.setearConsulta("Select Id,Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio  From ARTICULOS");
                _accesoDatos.ejecutarLectura();

                while(_accesoDatos.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Codigo = (string)_accesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
                    aux.IdMarca = (int)_accesoDatos.Lector["IdMarca"];
                    aux.IdCategoria = (int)_accesoDatos.Lector["IdCategoria"];
                    aux.Precio = (decimal)_accesoDatos.Lector["Precio"];

                    listar.Add(aux);

                }

                return listar;
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

        //Agregar un articulo
        public void AgregarArticulo(Articulos articulo)
        {
            var error = "";
            

            try
            {
                _accesoDatos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio)");

                _accesoDatos.setearParametro("@Codigo", articulo.Codigo ?? throw new ArgumentException("El código del artículo no puede ser nulo o vacío.", nameof(articulo.Codigo)));
                _accesoDatos.setearParametro("@Nombre", articulo.Nombre ?? throw new ArgumentException("El nombre del artículo no puede ser nulo o vacío.", nameof(articulo.Nombre)));
                _accesoDatos.setearParametro("@Descripcion", articulo.Descripcion ?? throw new ArgumentException("La descripción del artículo no puede ser nula o vacía.", nameof(articulo.Descripcion)));
                _accesoDatos.setearParametro("@IdMarca", articulo.IdMarca.ToString());
                _accesoDatos.setearParametro("@IdCategoria", articulo.IdCategoria.ToString());
                _accesoDatos.setearParametro("@Precio", articulo.Precio.ToString() ?? throw new ArgumentException("El precio del artículo no puede ser nulo o vacía.", nameof(articulo.Precio)));

                _accesoDatos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                error = "Error de conexion de SQL " + ex.Message;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

        //Eliminar articulo

        public bool eliminarArticulo(int id)
        {
            var elimnar = false;
        

            try
            {
                _accesoDatos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
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



        public void ModificarArticulo(Articulos articulo)
        {
            string error = "";

            try
            {
                _accesoDatos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                _accesoDatos.setearParametro("@Id", articulo.Id.ToString());
                _accesoDatos.setearParametro("@Codigo", articulo.Codigo);
                _accesoDatos.setearParametro("@Nombre", articulo.Nombre);
                _accesoDatos.setearParametro("@Descripcion", articulo.Descripcion);
                _accesoDatos.setearParametro("@IdMarca", articulo.IdMarca.ToString());
                _accesoDatos.setearParametro("@IdCategoria", articulo.IdCategoria.ToString());
                _accesoDatos.setearParametro("@Precio", articulo.Precio.ToString());
                

                _accesoDatos.ejecutarLectura();
            }
            catch (Exception ex)
            {
               error = "Error de conexion de SQL " + ex.Message;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }




    }
}

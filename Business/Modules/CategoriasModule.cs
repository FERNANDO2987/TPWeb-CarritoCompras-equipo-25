using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class CategoriasModule : ICategoriaModule
    {
        private readonly IAccesoDatos _accesoDatos;

        public CategoriasModule(IAccesoDatos accesoDatos)
        {

            _accesoDatos = accesoDatos;
        }

        //Agregar Articulo
        public Categorias AgregarCategoria(Categorias categorias)
        {
            var error = "";
            var result = new Categorias();


            try
            {
                _accesoDatos.setearConsulta("INSERT INTO CATEGORIAS (Descripcion) VALUES (@Descripcion);  SELECT SCOPE_IDENTITY();");

                _accesoDatos.setearParametro("@Descripcion", categorias.Descripcion ?? throw new ArgumentException("El código del artículo no puede ser nulo o vacío.", nameof(categorias.Descripcion)));

                // Ejecutar la consulta y obtener el ID generado automáticamente
                _accesoDatos.ejecutarLectura();

                if (_accesoDatos.Lector.HasRows)
                {
                    while (_accesoDatos.Lector.Read())
                    {
                        result.Id = Convert.ToInt32(_accesoDatos.Lector[0]);
                        result.Descripcion = categorias.Descripcion;
                    }
                }

            }
            catch (Exception ex)
            {
                error = "Error de conexion de SQL " + ex.Message;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
            return result;
        }

        //Eliminar Categoria
        public bool eliminarCategoria(int id)
        {
          
            try
            {
                _accesoDatos.setearConsulta("DELETE FROM CATEGORIAS WHERE Id = @Id");
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

        public List<Categorias> listarCategorias()
        {
             var lista = new List<Categorias>();

            try
            {

                _accesoDatos.setearConsulta("Select Id,Descripcion From CATEGORIAS");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
                   

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

        public void ModificarCategoria(Categorias categorias)
        {
            string error = "";

            try
            {
                _accesoDatos.setearConsulta("UPDATE CATEGORIAS SET Descripcion = @Descripcion WHERE Id = @Id");
                _accesoDatos.setearParametro("@Id", categorias.Id.ToString());
                _accesoDatos.setearParametro("@Descripcion", categorias.Descripcion);
     

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

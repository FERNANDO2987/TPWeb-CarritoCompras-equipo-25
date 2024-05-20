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
        public Articulos AgregarArticulo(Articulos articulo)
        {
            var error = "";
            var result = new Articulos();
            

            try
            {
                _accesoDatos.setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @Precio);SELECT SCOPE_IDENTITY(); ");

                _accesoDatos.setearParametro("@Codigo", articulo.Codigo ?? throw new ArgumentException("El código del artículo no puede ser nulo o vacío.", nameof(articulo.Codigo)));
                _accesoDatos.setearParametro("@Nombre", articulo.Nombre ?? throw new ArgumentException("El nombre del artículo no puede ser nulo o vacío.", nameof(articulo.Nombre)));
                _accesoDatos.setearParametro("@Descripcion", articulo.Descripcion ?? throw new ArgumentException("La descripción del artículo no puede ser nula o vacía.", nameof(articulo.Descripcion)));
                _accesoDatos.setearParametro("@IdMarca", articulo.IdMarca.ToString());
                _accesoDatos.setearParametro("@IdCategoria", articulo.IdCategoria.ToString());
                _accesoDatos.setearParametro("@Precio", articulo.Precio.ToString() ?? throw new ArgumentException("El precio del artículo no puede ser nulo o vacía.", nameof(articulo.Precio)));

                _accesoDatos.ejecutarLectura();

                if (_accesoDatos.Lector.HasRows)
                {
                    while (_accesoDatos.Lector.Read())
                    {
                        result.Id = Convert.ToInt32(_accesoDatos.Lector[0]);
                        result.Codigo = articulo.Codigo;
                        result.Nombre = articulo.Nombre;
                        result.Descripcion = articulo.Descripcion;
                        result.IdMarca = articulo.IdMarca;
                        result.IdCategoria = articulo.IdCategoria;
                        result.Precio = articulo.Precio;
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

        //Eliminar articulo

        public bool eliminarArticulo(int id)
        {
            var elimnar = false;
        

            try
            {
                _accesoDatos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                _accesoDatos.setearParametro("@Id", id.ToString()); // Convertir el ID a string
                _accesoDatos.ejecutarLectura(); // Ejecutar la acción de eliminación

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                _accesoDatos.cerrarConexion(); 
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


        public List<DetalleProducto> ObtenerListaDeArticulos()
        {
            var lista = new List<DetalleProducto>();
            try
            {
                _accesoDatos.setearConsulta(@"
                 SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, 
                 M.Id AS IdMarca, M.Descripcion AS DescripcionMarca, 
                 C.Id AS IdCategoria, C.Descripcion AS DescripcionCategoria, 
                I.ImagenURL 
                FROM ARTICULOS A 
                INNER JOIN MARCAS M ON A.IdMarca = M.Id 
                INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id 
                LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo
");

             
                _accesoDatos.ejecutarLectura();

                List<string> imagenesURL = new List<string>(); // Lista para almacenar las URLs de imágenes

                while (_accesoDatos.Lector.Read())
                {
                    DetalleProducto aux = new DetalleProducto();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Codigo = (string)_accesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
                    aux.Precio = (decimal)_accesoDatos.Lector["Precio"];
                    aux.IdMarca = (int)_accesoDatos.Lector["IdMarca"];
                    aux.DescripcionMarca = (string)_accesoDatos.Lector["DescripcionMarca"];
                    aux.IdCategoria = (int)_accesoDatos.Lector["IdCategoria"];
                    aux.DescripcionCategoria = (string)_accesoDatos.Lector["DescripcionCategoria"];


                    lista.Add(aux);
                    if (_accesoDatos.Lector["ImagenURL"] != DBNull.Value)
                    {
                        imagenesURL.Add((string)_accesoDatos.Lector["ImagenURL"]);
                    }
                }

                if (imagenesURL.Count > 0)
                {
                    lista.First().ImagenURLs = imagenesURL; // Asigna la lista de URLs de imágenes al detalle del producto
                }

                if (lista.First().Id== 0) // Si no se encontró el producto
                {
                    throw new Exception("Producto no encontrado");
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el detalle del producto: " + ex.Message);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

    }
}

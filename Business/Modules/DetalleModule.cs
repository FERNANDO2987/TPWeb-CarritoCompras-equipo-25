using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class DetalleModule : IDetalleModule 
    {
        private readonly IAccesoDatos _accesoDatos;
        public DetalleModule(IAccesoDatos accesoDatos) 
        {
            _accesoDatos = accesoDatos;
        }

        public List<ListarArticulosEimagen> listarArticulosEimagnes()
        {
            var listar = new List<ListarArticulosEimagen>();


            try
            {

                _accesoDatos.setearConsulta("SELECT A.*, I.*, I.ImagenURL  FROM ARTICULOS A INNER JOIN IMAGENES I ON A.Id = I.IdArticulo\r\n");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    ListarArticulosEimagen aux = new ListarArticulosEimagen();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Codigo = (string)_accesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
                    aux.IdMarca = (int)_accesoDatos.Lector["IdMarca"];
                    aux.IdCategoria = (int)_accesoDatos.Lector["IdCategoria"];
                    aux.Precio = (decimal)_accesoDatos.Lector["Precio"];
                    aux.IdArticulo = (int)_accesoDatos.Lector["IdArticulo"];
                    aux.ImagenURL = (string)_accesoDatos.Lector["ImagenURL"];
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

        public List<ListarArticulosYCategoria> listarXcategoria()
        {
            var listar = new List<ListarArticulosYCategoria>();


            try
            {

                _accesoDatos.setearConsulta("SELECT A.*, C.*, C.Descripcion AS DescripcionCategoria FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id\r\n");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    ListarArticulosYCategoria aux = new ListarArticulosYCategoria();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Codigo = (string)_accesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
                    aux.IdMarca = (int)_accesoDatos.Lector["IdMarca"];
                    aux.IdCategoria = (int)_accesoDatos.Lector["IdCategoria"];
                    aux.Precio = (decimal)_accesoDatos.Lector["Precio"];
                    aux.DescripcionCategoria = (string)_accesoDatos.Lector["DescripcionCategoria"];

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

        public List<ListarArticulosYMarcas> listarXmarcas()
        {
            var listar = new List<ListarArticulosYMarcas>();


            try
            {

                _accesoDatos.setearConsulta("SELECT A.*, M.*, M.Descripcion AS DescripcionMarca FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id\r\n");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    ListarArticulosYMarcas aux = new ListarArticulosYMarcas();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Codigo = (string)_accesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
                    aux.IdMarca = (int)_accesoDatos.Lector["IdMarca"];
                    aux.IdCategoria = (int)_accesoDatos.Lector["IdCategoria"];
                    aux.Precio = (decimal)_accesoDatos.Lector["Precio"];
                    aux.DescripcionMarca = (string)_accesoDatos.Lector["DescripcionMarca"];

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

        public DetalleProducto ObtenerDetallePorId(int id)
        {
            var detalle = new DetalleProducto();
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
        WHERE A.Id = @Id");
                _accesoDatos.setearParametro("@Id", id.ToString());
                _accesoDatos.ejecutarLectura();

                List<string> imagenesURL = new List<string>(); // Lista para almacenar las URLs de imágenes

                while (_accesoDatos.Lector.Read())
                {
                    detalle.Id = (int)_accesoDatos.Lector["Id"];
                    detalle.Codigo = (string)_accesoDatos.Lector["Codigo"];
                    detalle.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    detalle.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
                    detalle.Precio = (decimal)_accesoDatos.Lector["Precio"];
                    detalle.IdMarca = (int)_accesoDatos.Lector["IdMarca"];
                    detalle.DescripcionMarca = (string)_accesoDatos.Lector["DescripcionMarca"];
                    detalle.IdCategoria = (int)_accesoDatos.Lector["IdCategoria"];
                    detalle.DescripcionCategoria = (string)_accesoDatos.Lector["DescripcionCategoria"];

                    if (_accesoDatos.Lector["ImagenURL"] != DBNull.Value)
                    {
                        imagenesURL.Add((string)_accesoDatos.Lector["ImagenURL"]);
                    }
                }

                if (imagenesURL.Count > 0)
                {
                    detalle.ImagenURLs = imagenesURL; // Asigna la lista de URLs de imágenes al detalle del producto
                }

                if (detalle.Id == 0) // Si no se encontró el producto
                {
                    throw new Exception("Producto no encontrado");
                }

                return detalle;
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

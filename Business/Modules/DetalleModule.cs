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
    }
}

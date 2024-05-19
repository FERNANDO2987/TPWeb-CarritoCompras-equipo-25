using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class MarcasModule : IMarcaModule
    {
        private IAccesoDatos _accesoDatos;
        public MarcasModule(IAccesoDatos accesoDatos)
        {
           _accesoDatos = accesoDatos;
        }

        public Marcas AgregarMarca(Marcas marcas)
        {
            var error = "";
            var result = new Marcas();

            try
            {
                _accesoDatos.setearConsulta("INSERT INTO MARCAS (Descripcion) VALUES (@Descripcion); SELECT SCOPE_IDENTITY();");

                _accesoDatos.setearParametro("@Descripcion", marcas.Descripcion ?? throw new ArgumentException("La descripción de la marca no puede ser nula o vacía.", nameof(marcas.Descripcion)));

                // Ejecutar la consulta y obtener el ID generado automáticamente
                _accesoDatos.ejecutarLectura();

                if (_accesoDatos.Lector.HasRows)
                {
                    while (_accesoDatos.Lector.Read())
                    {
                        result.Id = Convert.ToInt32(_accesoDatos.Lector[0]);
                        result.Descripcion = marcas.Descripcion;
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


        public bool eliminarmarca(int id)
        {
            try
            {
                _accesoDatos.setearConsulta("DELETE FROM MARCAS WHERE Id = @Id");
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

        public List<Marcas> listarMarcas()
        {
            var lista = new List<Marcas>();

            try
            {

                _accesoDatos.setearConsulta("Select Id,Descripcion From MARCAS");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Marcas aux = new Marcas();
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

        public void ModificarMarca(Marcas marcas)
        {

            string error = "";

            try
            {
                _accesoDatos.setearConsulta("UPDATE MARCAS SET Descripcion = @Descripcion WHERE Id = @Id");
                _accesoDatos.setearParametro("@Id", marcas.Id.ToString());
                _accesoDatos.setearParametro("@Descripcion", marcas.Descripcion);


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

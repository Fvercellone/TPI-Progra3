using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class ManejadorPersonas
    {
        public List<Personas> Listar()
        {
            List<Personas> lista = new List<Personas>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("select P.ID, P.Nombre, P.Apellido, P.Email, P.Telefono, P.DNI, P.Activo from Personas as P");
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Personas aux = new Personas();
                    aux.ID = (int)conexion._lector["ID"];
                    aux.Nombre = (string)conexion._lector["Nombre"];
                    aux.Apellido = (string)conexion._lector["Apellido"];
                    aux.Mail = (string)conexion._lector["Email"];
                    aux.Telefono = (string)conexion._lector["Telefono"];
                    aux.DNI = (string)conexion._lector["DNI"];
                    aux.Activo = (bool)conexion._lector["Activo"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        /*AGREGAR, MODIFICAR, ELIMINAR*/

        public void agregar(Personas nuevo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("INSERT INTO dbo.Personas (Nombre, Apellido, Email, Telefono, DNI) VALUES (@nombre, @apellido, @email, @telefono, @dni);");
                conexion.agregarParametro("@nombre", nuevo.Nombre);
                conexion.agregarParametro("@apellido", nuevo.Apellido);
                conexion.agregarParametro("@email", nuevo.Mail);
                conexion.agregarParametro("@telefono", nuevo.Telefono);
                conexion.agregarParametro("@dni", nuevo.DNI);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Eliminar(String DNI)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("EXEC sp_BajaLogicaUsuarioPorDNI @DNI");
                conexion.agregarParametro("@DNI", DNI);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        public void Activar(String DNI)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("EXEC sp_AltaLogicaUsuarioPorDNI @DNI");
                conexion.agregarParametro("@DNI", DNI);
                conexion.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Modificar(string DNI)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                Personas persona = new Personas();
                conexion.settearConsulta("BEGIN TRANSACTION; UPDATE PERSONAS SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Telefono = @Telefono, DNI = @DNI WHERE DNI = @DNI; COMMIT");
                //conexion.agregarParametro("@Id", persona.ID);
                conexion.agregarParametro("@Nombre", persona.Nombre);
                conexion.agregarParametro("@Apellido", persona.Apellido);
                conexion.agregarParametro("@Email", persona.Mail);
                conexion.agregarParametro("@Telefono", persona.Telefono);
                conexion.agregarParametro("@DNI", persona.DNI);
                conexion.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

    }
}

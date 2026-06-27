using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class ManejadorUsuarios
    {
        public List<Usuarios> Listar(string DNI_ = "")
        {
            List<Usuarios> lista = new List<Usuarios>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("select U.ID, U.IDPersona, P.DNI, U.IDRol, U.Usuario, U.Contrasenia, U.Activo from Usuarios as U INNER JOIN Personas P ON U.IDPersona = P.ID");
                if (DNI_ != "")
                {
                    conexion.agregarParametro("@DNI_", DNI_);
                    conexion.settearConsulta("select U.ID, U.IDPersona, P.DNI, U.IDRol, U.Usuario, U.Contrasenia, U.Activo from Usuarios as U INNER JOIN Personas P ON U.IDPersona = P.ID where U.ID = @DNI_");

                }

                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.ID = (int)conexion._lector["ID"];
                    //aux.IDPersona = (int)conexion._lector["IDPersona"];
                    aux.DNI = (string)conexion._lector["DNI"];
                    aux.IDRol = (int)conexion._lector["IDRol"];
                    aux.Usuario = (string)conexion._lector["Usuario"];
                    aux.Contrasenia = (string)conexion._lector["Contrasenia"];
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

        public List<Usuarios> ListarCliente()
        {
            List<Usuarios> lista = new List<Usuarios>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("exec sp_ListarClientes");
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.ID = (int)conexion._lector["ID"];
                    aux.Usuario = (string)conexion._lector["NombreCompleto"];
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
        public List<Usuarios> ListarEmpleados()
        {
            List<Usuarios> lista = new List<Usuarios>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("exec sp_ListarEmpleados");
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.ID = (int)conexion._lector["ID"];
                    aux.Usuario = (string)conexion._lector["NombreCompleto"];
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

        public void agregar(Usuarios nuevo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("EXEC sp_CrearUsuarioPorDNI @DNI, @IDRol, @Usuario, @Contrasenia, @Activo");
                conexion.agregarParametro("@DNI", nuevo.DNI);
                //conexion.agregarParametro("@DNI", nuevo.IDPersona);
                conexion.agregarParametro("@IDRol", nuevo.IDRol);
                conexion.agregarParametro("@Usuario", nuevo.Usuario);
                conexion.agregarParametro("@Contrasenia", nuevo.Contrasenia);
                conexion.agregarParametro("@Activo", nuevo.Activo);
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

        public void Eliminar(int ID)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("EXEC sp_BajaLogicaUsuarioPorID @ID");
                conexion.agregarParametro("@ID", ID);
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
        public void Activar(int ID)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("EXEC sp_AltaLogicaUsuarioPorID @ID");
                conexion.agregarParametro("@ID", ID);
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

        public void Modificar(Usuarios nuevo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta(
                    "EXEC sp_ModificarUsuarioPorDNI @ID, @DNI, @IDRol, @Usuario, @Contrasenia, @Activo"
                );

                conexion.agregarParametro("@ID", nuevo.ID);
                conexion.agregarParametro("@DNI", nuevo.DNI);
                conexion.agregarParametro("@IDRol", nuevo.IDRol);
                conexion.agregarParametro("@Usuario", nuevo.Usuario);
                conexion.agregarParametro("@Contrasenia", nuevo.Contrasenia);
                conexion.agregarParametro("@Activo", nuevo.Activo);

                conexion.ejecutarAccion();
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public bool Login(Usuarios usuario)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("exec sp_LoginUsuario @usuario, @contraseña");
                conexion.agregarParametro("@usuario", usuario.Usuario);
                conexion.agregarParametro("@contraseña", usuario.Contrasenia);
                conexion.ejecutarLectura();
                if (conexion._lector.Read())
                {
                    usuario.ID = (int)conexion._lector["ID"];
                    usuario.DNI = (string)conexion._lector["DNI"];
                    usuario.IDRol = (int)conexion._lector["IDRol"];
                    usuario.Usuario = (string)conexion._lector["Usuario"];
                    usuario.Activo = (bool)conexion._lector["Activo"];

                    //usuario.Contrasenia = (string)conexion._lector["Contrasenia"];
                    //aux.IDPersona = (int)conexion._lector["IDPersona"];
                    return true;
                }
                return false;

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

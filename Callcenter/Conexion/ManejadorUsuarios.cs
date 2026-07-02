using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                conexion.settearConsulta("select U.ID, U.IDPersona, P.DNI, U.IDRol, U.Usuario, U.Contrasenia, U.Activo, R.Nombre as Rol from Usuarios as U INNER JOIN Personas P ON U.IDPersona = P.ID INNER JOIN Roles R ON U.IDRol = R.ID");
                if (DNI_ != "")
                {
                    conexion.agregarParametro("@DNI_", DNI_);
                    conexion.settearConsulta("select U.ID, U.IDPersona, P.DNI, U.IDRol, U.Usuario, U.Contrasenia, U.Activo, R.Nombre as Rol from Usuarios as U INNER JOIN Personas P ON U.IDPersona = P.ID INNER JOIN Roles R ON U.IDRol = R.ID where U.ID = @DNI_");

                }

                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.ID = (int)conexion._lector["ID"];
                    
                    aux.DNI = (string)conexion._lector["DNI"];
                    aux.Rol = (string)conexion._lector["Rol"];
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
                    
                    aux.DNI = (string)conexion._lector["DNI"];
                    aux.Rol = (string)conexion._lector["Rol"];
                    
                    aux.Usuario = (string)conexion._lector["Usuario"];
                    
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
                    
                    aux.DNI = (string)conexion._lector["DNI"];
                    aux.Rol = (string)conexion._lector["Rol"];
                    
                    aux.Usuario = (string)conexion._lector["Usuario"];
                    
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

        public void agregar(Usuarios nuevo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("EXEC sp_CrearUsuarioPorDNI @DNI, @IDRol, @Usuario, @Contrasenia, @Activo");
                conexion.agregarParametro("@DNI", nuevo.DNI);
                
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

        //public List<Roles> filtrar_Roles(int IDusuario) // PERMISOS
        //{
        //    List<Roles> lista = new List<Roles>();
        //    ConexionDB conexion = new ConexionDB();
        //    try
        //    {
        //        conexion.settearConsulta("EXEC sp_FiltrarRolesPorUsuario @IDUsuario");
        //        conexion.agregarParametro("@IDUsuario", IDusuario);
        //        conexion.ejecutarLectura();
        //        while (conexion._lector.Read())
        //        {
        //            Roles rol = new Roles();
        //            rol.ID = (int)conexion._lector["ID"];
        //            rol.Nombre = (string)conexion._lector["Nombre"];
        //            lista.Add(rol);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conexion.cerrarConexion();
        //    }
        //    return lista;
        //}   




        public List<Usuarios> Listafiltrada(string campo = "%", string criterio = "%", string filtro = "%", string estado = "%")
        {
            List<Usuarios> lista = new List<Usuarios>();
            ConexionDB conexion = new ConexionDB();
            try
            {

                string consulta = "select U.ID as ID, P.DNI, U.Usuario As Usuario, U.Activo As Estado, R.Nombre as Rol from Usuarios as U INNER JOIN Personas P ON U.IDPersona = P.ID INNER JOIN Roles R ON U.IDRol = R.ID AND ";
                if (campo == "DNI")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.DNI like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.DNI like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.DNI like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Rol")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "R.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "R.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "R.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Usuario")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "U.Usuario like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "U.Usuario like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "U.Usuario like '%" + filtro + "%'";
                            break;
                    }
                }

                if (estado == "Estado")
                    consulta += " and P.Activo = 1";
                else if (estado == "Inactivo")
                    consulta += " and P.Activo = 0";

                conexion.settearConsulta(consulta);
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.ID = (int)conexion._lector["ID"];

                    aux.DNI = (string)conexion._lector["DNI"];
                    aux.Rol = (string)conexion._lector["Rol"];
                    aux.Usuario = (string)conexion._lector["Usuario"];
                    aux.Activo = bool.Parse(conexion._lector["Estado"].ToString());
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


    
        
        public List<Usuarios> ListafiltradaClientes(string campo = "%", string criterio = "%", string filtro = "%", string estado = "%")
        {
            List<Usuarios> lista = new List<Usuarios>();
            ConexionDB conexion = new ConexionDB();
            try
            {

                string consulta = "select U.ID,  P.DNI, U.Usuario As Usuario, U.Activo As Estado, R.Nombre as Rol from Usuarios as U INNER JOIN Personas P ON U.IDPersona = P.ID INNER JOIN Roles R ON U.IDRol = R.ID where R.Nombre ='Cliente' AND ";
                if (campo == "DNI")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.DNI like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.DNI like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.DNI like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Rol")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "R.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "R.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "R.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Usuario")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "U.Usuario like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "U.Usuario like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "U.Usuario like '%" + filtro + "%'";
                            break;
                    }
                }

                if (estado == "Estado")
                    consulta += " and P.Activo = 1";
                else if (estado == "Inactivo")
                    consulta += " and P.Activo = 0";

                conexion.settearConsulta(consulta);
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.ID = (int)conexion._lector["ID"];

                    aux.DNI = (string)conexion._lector["DNI"];
                    aux.Rol = (string)conexion._lector["Rol"];
                    aux.Usuario = (string)conexion._lector["Usuario"];
                    aux.Activo = bool.Parse(conexion._lector["Estado"].ToString());
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
        public List<Usuarios> ListafiltradaEmpleados(string campo = "%", string criterio = "%", string filtro = "%", string estado = "%")
        {
            List<Usuarios> lista = new List<Usuarios>();
            ConexionDB conexion = new ConexionDB();
            try
            {

                string consulta = "select U.ID,  P.DNI, U.Usuario As Usuario, U.Activo As Estado, R.Nombre as Rol from Usuarios as U INNER JOIN Personas P ON U.IDPersona = P.ID INNER JOIN Roles R ON U.IDRol = R.ID and R.ID >= 2  and  ";

                if (campo == "DNI")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.DNI like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.DNI like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.DNI like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Rol")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "R.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "R.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "R.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Usuario")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "U.Usuario like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "U.Usuario like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "U.Usuario like '%" + filtro + "%'";
                            break;
                    }
                }

                if (estado == "Estado")
                    consulta += " and P.Activo = 1";
                else if (estado == "Inactivo")
                    consulta += " and P.Activo = 0";

                conexion.settearConsulta(consulta);
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Usuarios aux = new Usuarios();
                    aux.ID = (int)conexion._lector["ID"];

                    aux.DNI = (string)conexion._lector["DNI"];
                    aux.Rol = (string)conexion._lector["Rol"];
                    aux.Usuario = (string)conexion._lector["Usuario"];
                    aux.Activo = bool.Parse(conexion._lector["Estado"].ToString());
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


    }
}

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
        public List<Personas> Listar( string DNI_ = "")
        {
            List<Personas> lista = new List<Personas>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("select P.ID, P.Nombre, P.Apellido, P.Email, P.Telefono, P.DNI, P.Activo from Personas as P ");
                if(DNI_!= "")
                {
                    conexion.agregarParametro("@DNI_", DNI_);
                    conexion.settearConsulta("select P.ID, P.Nombre, P.Apellido, P.Email, P.Telefono, P.DNI, P.Activo from Personas as P where DNI = @DNI_");
                }

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

        public void Modificar(Personas persona)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
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


        public List<Personas> Listafiltrada(string campo = "%", string criterio = "%", string filtro = "%", string estado = "%")
        {
            List<Personas> lista = new List<Personas>();
            ConexionDB conexion = new ConexionDB();
            try
            {

                string consulta = "select P.ID, P.Nombre as Nombre, P.Apellido as Apellido, P.Email as Email, P.Telefono as Telefono, P.DNI as DNI, P.Activo as Activo from Personas as P where ";
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
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Apellido")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Apellido like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Apellido like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.Apellido like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Email")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Email like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Email like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.Email like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Telefono")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Telefono like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "P.Telefono like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "P.Telefono like '%" + filtro + "%'";
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


    }
}

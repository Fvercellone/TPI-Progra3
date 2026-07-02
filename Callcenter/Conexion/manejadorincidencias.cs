using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class ManejadorIncidencias
    {
        public List<incidencia> Listar(int id = 0)
        {
            List<incidencia> lista = new List<incidencia>();
            ConexionDB conexion = new ConexionDB();

            try
            {
                if (id == 0)
                    conexion.settearConsulta("SELECT * FROM vw_IncidenciasDetalle");
                else
                {
                    conexion.settearConsulta("SELECT * FROM vw_IncidenciasDetalle WHERE ID = @ID");
                    conexion.agregarParametro("@ID", id);
                }

                conexion.ejecutarLectura();

                while (conexion._lector.Read())
                {
                    incidencia aux = new incidencia();

                    aux.id = (int)conexion._lector["ID"];
                    aux.titulo = conexion._lector["Titulo"].ToString();
                    aux.descripcion = conexion._lector["Descripcion"].ToString();

                    aux.IDCliente = (int)conexion._lector["IDCliente"];
                    aux.Cliente = conexion._lector["Cliente"].ToString();

                    aux.IDEmpleado = (int)conexion._lector["IDEmpleado"];
                    aux.Empleado = conexion._lector["Empleado"].ToString();

                    aux.IDCategoria = (int)conexion._lector["IDCategoria"];
                    aux.Categoria = conexion._lector["Categoria"].ToString();

                    aux.IDPrioridad = (int)conexion._lector["IDPrioridad"];
                    aux.Prioridad = conexion._lector["Prioridad"].ToString();

                    aux.IDEstado = (int)conexion._lector["IDEstado"];
                    aux.Estado = conexion._lector["Estado"].ToString();

                    //aux.comentario = conexion._lector["Comentario"] == DBNull.Value ? "" : conexion._lector["Comentario"].ToString();
                    aux.comentarioCierre = conexion._lector["ComentarioCierre"] == DBNull.Value ? "" : conexion._lector["ComentarioCierre"].ToString();

                    aux.alta = (DateTime)conexion._lector["FechaAlta"];

                    if (!(conexion._lector["FechaModificacion"] is DBNull))
                        aux.modificacion = (DateTime)conexion._lector["FechaModificacion"];

                    if (!(conexion._lector["FechaResolucion"] is DBNull))
                        aux.resolucion = (DateTime)conexion._lector["FechaResolucion"];

                    if (!(conexion._lector["FechaCierre"] is DBNull))
                        aux.cierre = (DateTime)conexion._lector["FechaCierre"];

                    lista.Add(aux);
                }

                return lista;
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


        /*AGREGAR, MODIFICAR, ELIMINAR*/

        public int agregar(incidencia nuevo)
        {
            ConexionDB conexion = new ConexionDB();


            try
            {
                conexion.settearConsulta("EXEC sp_AgregarIncidencia @Titulo, @Descripcion, @IDCliente, @IDEmpleado, @IDCategoria, @IDPrioridad, @IDEstado");

                conexion.agregarParametro("@Titulo", nuevo.titulo);
                conexion.agregarParametro("@Descripcion", nuevo.descripcion);
                conexion.agregarParametro("@IDCliente", nuevo.IDCliente);
                conexion.agregarParametro("@IDEmpleado", nuevo.IDEmpleado);
                conexion.agregarParametro("@IDCategoria", nuevo.IDCategoria);
                conexion.agregarParametro("@IDPrioridad", nuevo.IDPrioridad);
                conexion.agregarParametro("@IDEstado", 1); 

                //conexion.ejecutarAccion();
                return Convert.ToInt32(conexion.ejecutarScalar());


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Modificar(incidencia nuevo)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta(
                    "EXEC sp_ModificarIncidencia @ID, @Titulo, @Descripcion, @IDCliente, @IDEmpleado, @IDCategoria, @IDPrioridad"
                );

                conexion.agregarParametro("@ID", nuevo.id);
                conexion.agregarParametro("@Titulo", nuevo.titulo);
                conexion.agregarParametro("@Descripcion", nuevo.descripcion);
                conexion.agregarParametro("@IDCliente", nuevo.IDCliente);
                conexion.agregarParametro("@IDEmpleado", nuevo.IDEmpleado);
                conexion.agregarParametro("@IDCategoria", nuevo.IDCategoria);
                conexion.agregarParametro("@IDPrioridad", nuevo.IDPrioridad);

                conexion.ejecutarAccion();
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Reasignar(int idIncidencia, int idEmpleado)
        {
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_ReasignarIncidencia @ID, @IDEmpleado");
                conexion.agregarParametro("@ID", idIncidencia);
                conexion.agregarParametro("@IDEmpleado", idEmpleado);
                conexion.ejecutarAccion();
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
        public void Resolver(int id, string comentario)
        {
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_ResolverIncidencia @ID, @ComentarioResolucion");
                conexion.agregarParametro("@ID", id);
                conexion.agregarParametro("@ComentarioResolucion", comentario);
                conexion.ejecutarAccion();
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Cerrar(int id)
        {
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_CerrarIncidencia @ID");
                conexion.agregarParametro("@ID", id);
                conexion.ejecutarAccion();
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public void Reabrir(int idIncidencia)
        {
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_ReabrirIncidencia @IDIncidencia");

                conexion.agregarParametro("@IDIncidencia", idIncidencia);

                conexion.ejecutarAccion();
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public List<incidencia> FiltrarIncidenciasPorUsuario(int idUsuario)
        {
            List<incidencia> lista = new List<incidencia>();
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_FiltrarIncidenciasPorUsuario @IDUsuario");
                conexion.agregarParametro("@IDUsuario", idUsuario);

                conexion.ejecutarLectura();

                while (conexion._lector.Read())
                {
                    incidencia aux = new incidencia();

                    aux.id = (int)conexion._lector["ID"];
                    aux.titulo = conexion._lector["Titulo"].ToString();
                    aux.descripcion = conexion._lector["Descripcion"].ToString();

                    aux.IDCliente = (int)conexion._lector["IDCliente"];
                    aux.Cliente = conexion._lector["Cliente"].ToString();

                    aux.IDEmpleado = (int)conexion._lector["IDEmpleado"];
                    aux.Empleado = conexion._lector["Empleado"].ToString();

                    aux.IDCategoria = (int)conexion._lector["IDCategoria"];
                    aux.Categoria = conexion._lector["Categoria"].ToString();

                    aux.IDPrioridad = (int)conexion._lector["IDPrioridad"];
                    aux.Prioridad = conexion._lector["Prioridad"].ToString();

                    aux.IDEstado = (int)conexion._lector["IDEstado"];
                    aux.Estado = conexion._lector["Estado"].ToString();


                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public List<incidencia> Listafiltrada(string campo = "%", string criterio = "%", string filtro = "%", string estado = "%", string DNI = "%",int Rol = 0)
        {
            List<incidencia> lista = new List<incidencia>();
            ConexionDB conexion = new ConexionDB();
            try
            {

                string consulta = "SELECT I.ID, I.Titulo, I.Descripcion, I.IDCliente, UC.Usuario AS Cliente, I.IDEmpleado, UE.Usuario AS Empleado, I.IDEstado, E.Nombre AS Estado, I.IDCategoria, C.Nombre AS Categoria, I.IDPrioridad, PR.Nombre AS Prioridad, I.ComentarioCierre, I.FechaAlta, I.FechaModificacion, I.FechaResolucion, I.FechaCierre FROM Incidencias AS I INNER JOIN Usuarios AS UC ON I.IDCliente = UC.ID INNER JOIN Personas AS PC ON UC.IDPersona = PC.ID INNER JOIN Usuarios AS UE ON I.IDEmpleado = UE.ID INNER JOIN Personas AS PE ON UE.IDPersona = PE.ID INNER JOIN Estados AS E ON I.IDEstado = E.ID INNER JOIN Categorias AS C ON I.IDCategoria = C.ID INNER JOIN Prioridades AS PR ON I.IDPrioridad = PR.ID AND ";
                if (Rol == 2)
                {
                    consulta += "PE.DNI = '" + DNI + "' AND ";
                }
                else if(Rol == 1)
                {
                    consulta += "PC.DNI = '" + DNI + "' AND ";
                }
                if (campo == "ID")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "I.ID like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "I.ID like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "I.ID like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "I.Titulo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "I.Titulo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "I.Titulo like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Cliente")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "UC.Usuario like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "UC.Usuario like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "UC.Usuario like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Empleado")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "UE.Usuario like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "UE.Usuario like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "UE.Usuario like '%" + filtro + "%'";
                            break;
                    }
                }
                else if (campo == "Categoria")
                {
                    consulta += "C.ID = " + filtro;
                }
                else if (campo == "Prioridad")
                {
                    consulta += " PR.ID = " + filtro;
                }
                    consulta += " and E.ID = " + estado;

 

                conexion.settearConsulta(consulta);
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    incidencia aux = new incidencia(); 
                    
                    aux.id = (int)conexion._lector["ID"];
                    aux.titulo = conexion._lector["Titulo"].ToString();
                    aux.descripcion = conexion._lector["Descripcion"].ToString();

                    aux.IDCliente = (int)conexion._lector["IDCliente"];
                    aux.Cliente = conexion._lector["Cliente"].ToString();

                    aux.IDEmpleado = (int)conexion._lector["IDEmpleado"];
                    aux.Empleado = conexion._lector["Empleado"].ToString();

                    aux.IDCategoria = (int)conexion._lector["IDCategoria"];
                    aux.Categoria = conexion._lector["Categoria"].ToString();

                    aux.IDPrioridad = (int)conexion._lector["IDPrioridad"];
                    aux.Prioridad = conexion._lector["Prioridad"].ToString();

                    aux.IDEstado = (int)conexion._lector["IDEstado"];
                    aux.Estado = conexion._lector["Estado"].ToString();

                    //aux.comentario = conexion._lector["Comentario"] == DBNull.Value ? "" : conexion._lector["Comentario"].ToString();
                    aux.comentarioCierre = conexion._lector["ComentarioCierre"] == DBNull.Value ? "" : conexion._lector["ComentarioCierre"].ToString();

                    aux.alta = (DateTime)conexion._lector["FechaAlta"];

                    if (!(conexion._lector["FechaModificacion"] is DBNull))
                        aux.modificacion = (DateTime)conexion._lector["FechaModificacion"];

                    if (!(conexion._lector["FechaResolucion"] is DBNull))
                        aux.resolucion = (DateTime)conexion._lector["FechaResolucion"];

                    if (!(conexion._lector["FechaCierre"] is DBNull))
                        aux.cierre = (DateTime)conexion._lector["FechaCierre"];

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

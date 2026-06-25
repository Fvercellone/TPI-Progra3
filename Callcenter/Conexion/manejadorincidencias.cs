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
                conexion.settearConsulta("SELECT * FROM vw_Incidencias;");
                if (id != 0)
                {
                    conexion.agregarParametro("@ID", id);
                    conexion.settearConsulta("SELECT * FROM vw_IncidenciasDetalle WHERE ID = @ID;");

                }

                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    incidencia aux = new incidencia();
                    aux.id = (int)conexion._lector["ID"];
                    aux.titulo = (string)conexion._lector["Titulo"];
                    aux.descripcion = (string)conexion._lector["Descripcion"];
                    //aux.idUsuario = (int)conexion._lector["IDUsuario"];
                    //aux.idempleado = (int)conexion._lector["IDEmpleado"];
                    //aux.categoria = (int)conexion._lector["Categoria"];
                    //aux.prioridad = (int)conexion._lector["Prioridad"];
                    aux.comentario = (string)conexion._lector["Comentario"];
                    aux.comentarioCierre = (string)conexion._lector["ComentarioCierre"];
                    aux.alta = (DateTime)conexion._lector["Alta"];
                    aux.cierre = (DateTime)conexion._lector["Cierre"];
                    aux.resolucion = (DateTime)conexion._lector["Resolucion"];
                    aux.modificacion = (DateTime)conexion._lector["Modificacion"];
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

        //public void agregar(incidencia nuevo)
        //{
        //    ConexionDB conexion = new ConexionDB();
        //    try
        //    {
        //        conexion.settearConsulta("EXEC sp_CrearincidenciaPorDNI @DNI, @IDRol, @incidencia, @Contrasenia, @Activo");
        //       // conexion.agregarParametro("@DNI", nuevo.ID);
        //        //conexion.agregarParametro("@DNI", nuevo.IDPersona);
        //        conexion.agregarParametro("@IDRol", nuevo.IDRol);
        //        conexion.agregarParametro("@incidencia", nuevo.incidencia);
        //        conexion.agregarParametro("@Contrasenia", nuevo.Contrasenia);
        //        conexion.agregarParametro("@Activo", nuevo.Activo);
        //        conexion.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conexion.cerrarConexion();
        //    }
        //}

        //public void Eliminar(int ID)
        //{
        //    ConexionDB conexion = new ConexionDB();
        //    try
        //    {
        //        conexion.settearConsulta("EXEC sp_BajaLogicaincidenciaPorID @ID");
        //        conexion.agregarParametro("@ID", ID);
        //        conexion.ejecutarAccion();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        conexion.cerrarConexion();
        //    }
        //}
        //public void Activar(int ID)
        //{
        //    ConexionDB conexion = new ConexionDB();
        //    try
        //    {
        //        conexion.settearConsulta("EXEC sp_AltaLogicaincidenciaPorID @ID");
        //        conexion.agregarParametro("@ID", ID);
        //        conexion.ejecutarAccion();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        conexion.cerrarConexion();
        //    }
        //}

        //public void Modificar(incidencia nuevo)
        //{
        //    ConexionDB conexion = new ConexionDB();
        //    try
        //    {
        //        conexion.settearConsulta(
        //            "EXEC sp_ModificarincidenciaPorDNI @ID, @DNI, @IDRol, @incidencia, @Contrasenia, @Activo"
        //        );

        //        conexion.agregarParametro("@ID", nuevo.ID);
        //        conexion.agregarParametro("@DNI", nuevo.DNI);
        //        conexion.agregarParametro("@IDRol", nuevo.IDRol);
        //        conexion.agregarParametro("@incidencia", nuevo.incidencia);
        //        conexion.agregarParametro("@Contrasenia", nuevo.Contrasenia);
        //        conexion.agregarParametro("@Activo", nuevo.Activo);

        //        conexion.ejecutarAccion();
        //    }
        //    finally
        //    {
        //        conexion.cerrarConexion();
        //    }
        //}

    }
}

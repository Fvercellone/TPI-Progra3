using Dominio;
using System;
using System.Collections.Generic;

namespace Conexion
{
    public class ManejadorComentarios
    {
        public List<ComentarioIncidencia> Listar(int idIncidencia = 0)
        {
            List<ComentarioIncidencia> lista = new List<ComentarioIncidencia>();
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_ListarComentariosIncidencia @IDIncidencia");
                conexion.agregarParametro("@IDIncidencia", idIncidencia);

                conexion.ejecutarLectura();

                while (conexion._lector.Read())
                {
                    ComentarioIncidencia aux = new ComentarioIncidencia();

                    aux.ID = (int)conexion._lector["ID"];
                    aux.IDIncidencia = (int)conexion._lector["IDIncidencia"];
                    aux.IDUsuario = (int)conexion._lector["IDUsuario"];
                    aux.Autor = (string)conexion._lector["Autor"];
                    aux.Rol = (string)conexion._lector["Rol"];
                    aux.Comentario = (string)conexion._lector["Mensaje"];
                    aux.Fecha = (DateTime)conexion._lector["Fecha"];
                    aux.Activo = (bool)conexion._lector["Activo"];
                    aux.EsEmpleado = Convert.ToBoolean(conexion._lector["EsEmpleado"]);

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

        public void Agregar(ComentarioIncidencia nuevo)
        {
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_AgregarComentarioIncidencia @IDIncidencia, @IDUsuario, @Comentario");

                conexion.agregarParametro("@IDIncidencia", nuevo.IDIncidencia);
                conexion.agregarParametro("@IDUsuario", nuevo.IDUsuario);
                conexion.agregarParametro("@Comentario", nuevo.Comentario);

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

        public void Eliminar(int idComentario)
        {
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_EliminarComentarioIncidencia @IDComentario");
                conexion.agregarParametro("@IDComentario", idComentario);

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

        public void Modificar(ComentarioIncidencia comentario)
        {
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.settearConsulta("EXEC sp_ModificarComentarioIncidencia @IDComentario, @Comentario");

                conexion.agregarParametro("@IDComentario", comentario.ID);
                conexion.agregarParametro("@Comentario", comentario.Comentario);

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
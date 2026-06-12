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
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("SELECT U.Id, U.Nombre FROM dbo.USUARIOS as U");
                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.idUsuario = (int)conexion._lector["Id"];
                    aux.Nombre = (string)conexion._lector["Nombre"];
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

        public void Agregar(Usuario nuevo) {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("INSERT INTO dbo.USUARIOS (Nombre) VALUES (@nombre);");
                conexion.agregarParametro("@nombre", nuevo.Nombre);
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

        public void Eliminar(int id)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("DELETE FROM dbo.USUARIOS WHERE Id = @Id");
                conexion.agregarParametro("@Id", id);
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

        public void Modificar(Usuario usuario)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("BEGIN TRANSACTION; UPDATE dbo.USUARIOS SET Nombre = @Nombre WHERE Id = @Id; COMMIT");
                conexion.agregarParametro("@Id", usuario.idUsuario);
                conexion.agregarParametro("@Nombre", usuario.Nombre);
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

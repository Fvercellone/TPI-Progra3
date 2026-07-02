using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class ManejadorDDL
    {
        public List<estado> ListarEstados()
        {
            List<estado> lista = new List<estado>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("select id, nombre from Estados ");


                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    estado aux = new estado();
                    aux.id = (int)conexion._lector["id"];
                    aux.nombre = (string)conexion._lector["nombre"];

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

        public List<Prioridad> ListarPrioridades()
        {
            List<Prioridad> lista = new List<Prioridad>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("select id, nombre from Prioridades ");


                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Prioridad aux = new Prioridad();
                    aux.id = (int)conexion._lector["id"];
                    aux.nombre = (string)conexion._lector["nombre"];

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
        public List<categoria> ListarCategorias()
        {
            List<categoria> lista = new List<categoria>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("select id, nombre from Categorias ");


                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    categoria aux = new categoria();
                    aux.id = (int)conexion._lector["id"];
                    aux.nombre = (string)conexion._lector["nombre"];

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
        public List<Roles> ListarRoles()
        {
            List<Roles> lista = new List<Roles>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("select id, nombre from Roles ");


                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Roles aux = new Roles();
                    aux.ID = (int)conexion._lector["id"];
                    aux.Nombre = (string)conexion._lector["nombre"];

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
        public List<Personas> ListarDNI()
        {
            List<Personas> lista = new List<Personas>();
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.settearConsulta("SELECT P.ID, P.DNI FROM Personas P WHERE NOT EXISTS (SELECT 1  FROM Usuarios U  WHERE U.IDPersona = P.ID);");


                conexion.ejecutarLectura();
                while (conexion._lector.Read())
                {
                    Personas aux = new Personas();
                    aux.ID = (int)conexion._lector["id"];
                    aux.DNI = (string)conexion._lector["DNI"];

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

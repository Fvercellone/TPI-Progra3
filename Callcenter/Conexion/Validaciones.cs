using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

    namespace Conexion
    {
        public class Validaciones
        {
            public static bool TienePermiso(object usuarioSession, int rolMinimo)
            {
                Usuarios usuario = usuarioSession as Usuarios;

                return usuario != null && usuario.IDRol >= rolMinimo;
            }


        public static bool PuedeCerrar(int IDIncidencia)
        {
            ManejadorIncidencias conexion = new ManejadorIncidencias();

            incidencia incidenciaActual = conexion.Listar(IDIncidencia).FirstOrDefault();

            return incidenciaActual != null && incidenciaActual.IDEstado == 4 || incidenciaActual.IDEstado == 6;
        }

        public static bool PuedeReabrir(int IDIncidencia)
            {
            ManejadorIncidencias conexion = new ManejadorIncidencias();

            incidencia incidenciaActual = conexion.Listar(IDIncidencia).FirstOrDefault();

            return incidenciaActual != null && incidenciaActual.IDEstado == 5;
        }
        }
    }

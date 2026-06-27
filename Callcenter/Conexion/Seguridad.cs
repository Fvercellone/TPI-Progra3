using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace negocio
{
    public static class Seguridad
    {
        public static bool sesionActiva(object user)
        {
            Usuarios usuario = user != null ? (Usuarios)user : null;
            if (usuario != null && usuario.ID != 0)
                return true;
            else
                return false;
        }

        public static bool esAdmin(object user)
        {
            Usuarios usuario = user != null ? (Usuarios)user : null;
            return usuario != null ? usuario.IDRol == 4 : false;
        }
    }
}
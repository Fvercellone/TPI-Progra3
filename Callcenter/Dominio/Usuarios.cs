using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class Usuarios
    {
        public int ID { get; set; }
        //public int IDPersona { get; set; }
        public string DNI { get; set; }
        public int IDRol { get; set; }

        public string Rol { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return Usuario;
        }
    }
}

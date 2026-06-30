using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum roles { 
        cliente = 1,
        telefonista = 2,
        administrador = 3,
        supervisor = 4
    }
    public class Usuarios
    {
        public int ID { get; set; }
        //public int IDPersona { get; set; }
        public string DNI { get; set; }
        public int IDRol { get; set; }
        public roles Rol { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }

        public override string ToString()
        {
            return Usuario;
        }
    }
}

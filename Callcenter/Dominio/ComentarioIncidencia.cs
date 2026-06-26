using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ComentarioIncidencia
    {
        public int ID { get; set; }

        public int IDIncidencia { get; set; }

        public int IDUsuario { get; set; }

        public string Autor { get; set; }

        public string Rol { get; set; }

        public string Comentario { get; set; }

        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        public bool EsEmpleado { get; set; }
    }
}

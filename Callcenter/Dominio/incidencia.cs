using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class incidencia
    {
        public int id { get; set; }

        public string titulo { get; set; }
        public string descripcion { get; set; }

        public int IDCliente { get; set; }
        public string Cliente { get; set; }

        public int IDEmpleado { get; set; }
        public string Empleado { get; set; }

        public int IDCategoria { get; set; }
        public string Categoria { get; set; }

        public int IDPrioridad { get; set; }
        public string Prioridad { get; set; }

        public int IDEstado { get; set; }
        public string Estado { get; set; }
        public string comentarioCierre { get; set; }

        public DateTime alta { get; set; }
        public DateTime modificacion { get; set; }
        public DateTime resolucion { get; set; }
        public DateTime cierre { get; set; }
    }
}

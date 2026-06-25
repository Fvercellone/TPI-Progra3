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
        public string Cliente { get; set; }
        public string Empleado { get; set; }
        public string categoria { get; set; }
        public string prioridad { get; set; }
        public string comentario { get; set; }
        public string comentarioCierre { get; set; }
        public DateTime alta { get; set; }
        public DateTime cierre { get; set; }
        public DateTime resolucion { get; set; }
        public DateTime modificacion { get; set; }
    }
}

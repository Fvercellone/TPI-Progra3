using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int Id { get; set; }

        public string Codigo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //Referencia/Relación con Marca y Categoria
        //public Personas Marca { get; set; }
        //public Categoria Categoria { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
    }
}

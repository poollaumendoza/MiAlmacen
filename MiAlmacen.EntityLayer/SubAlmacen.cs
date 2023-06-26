using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class SubAlmacen
    {
        public int IdSubAlmacen { get; set; }
        public Almacen oAlmacen { get; set; }
        public string NombreSubAlmacen { get; set; }
        public Estado oEstado { get; set; }
    }
}
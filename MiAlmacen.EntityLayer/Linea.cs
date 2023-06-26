using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Linea
    {
        public int IdLinea { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreLinea { get; set; }
        public Estado oEstado { get; set; }
    }
}
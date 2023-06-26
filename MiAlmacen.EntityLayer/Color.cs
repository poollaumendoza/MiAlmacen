using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Color
    {
        public int IdColor { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreColor { get; set; }
        public Estado oEstado { get; set; }
    }
}
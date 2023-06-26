using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class UnidadMedida
    {
        public int IdUnidadMedida { get; set; }
        public string NombreUnidadMedida { get; set; }
        public Estado oEstado { get; set; }
    }
}
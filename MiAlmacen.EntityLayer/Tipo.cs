using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Tipo
    {
        public int IdTipo { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreTipo { get; set; }
        public Estado oEstado { get; set; }
    }
}
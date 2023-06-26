using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class EntidadUbicacion
    {
        public int IdEntidadUbicacion { get; set; }
        public Entidad oEntidad { get; set; }
        public Ubicacion oUbicacion { get; set; }
        public Estado oEstado { get; set; }
    }
}
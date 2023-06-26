using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class Picking
    {
        public int IdPicking { get; set; }
        public Entidad oEntidad { get; set; }
        public TipoMovimiento oTipoMovimiento { get; set; }
        public string NroOrden { get; set; }
        public string Fecha { get; set; }
        public Estado oEstado { get; set; }
    }
}
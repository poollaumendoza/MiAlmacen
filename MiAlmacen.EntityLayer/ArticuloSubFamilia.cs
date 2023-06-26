using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class ArticuloSubFamilia
    {
        public int IdArticuloSubFamilia { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreSubFamilia { get; set; }
        public Estado oEstado { get; set; }
    }
}
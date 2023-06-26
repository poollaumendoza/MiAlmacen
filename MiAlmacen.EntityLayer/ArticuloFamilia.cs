using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.EntityLayer
{
    public class ArticuloFamilia
    {
        public int IdArticuloFamilia { get; set; }
        public Entidad oEntidad { get; set; }
        public string NombreArticuloFamilia { get; set; }
        public Estado oEstado { get; set; }
    }
}
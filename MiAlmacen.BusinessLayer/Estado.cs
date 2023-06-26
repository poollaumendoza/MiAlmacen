using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Estado
    {
        DataLayer.Estado dEstado = new DataLayer.Estado();

        public List<EntityLayer.Estado> Listar()
        {
            return dEstado.Listar();
        }

        public int Registrar(EntityLayer.Estado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreEstado) || string.IsNullOrWhiteSpace(obj.NombreEstado))
                Mensaje = "El nombre del estado no puede ser vacío";

            if (string.IsNullOrEmpty(Mensaje))
                return dEstado.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Estado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreEstado) || string.IsNullOrWhiteSpace(obj.NombreEstado))
                Mensaje = "El nombre del estado no puede ser vacío";

            if (string.IsNullOrEmpty(Mensaje))
                return dEstado.Editar(obj, out Mensaje);
            else
                return false;
        }
    }
}
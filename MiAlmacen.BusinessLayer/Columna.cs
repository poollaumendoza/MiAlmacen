using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Columna
    {
        DataLayer.Columna dColumna = new DataLayer.Columna();

        public List<EntityLayer.Columna> Listar()
        {
            return dColumna.Listar();
        }

        public int Registrar(EntityLayer.Columna obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreColumna) || string.IsNullOrWhiteSpace(obj.NombreColumna))
                Mensaje = "El nombre del Columna no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dColumna.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Columna obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreColumna) || string.IsNullOrWhiteSpace(obj.NombreColumna))
                Mensaje = "El nombre del Columna no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dColumna.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dColumna.Eliminar(id, out Mensaje);
        }
    }
}
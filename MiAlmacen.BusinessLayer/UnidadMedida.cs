using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class UnidadMedida
    {
        DataLayer.UnidadMedida dUnidadMedida = new DataLayer.UnidadMedida();

        public List<EntityLayer.UnidadMedida> Listar()
        {
            return dUnidadMedida.Listar();
        }

        public int Registrar(EntityLayer.UnidadMedida obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreUnidadMedida) || string.IsNullOrWhiteSpace(obj.NombreUnidadMedida))
                Mensaje = "El nombre de la unidad de medida no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUnidadMedida.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.UnidadMedida obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.NombreUnidadMedida) || string.IsNullOrWhiteSpace(obj.NombreUnidadMedida))
                Mensaje = "El nombre de la unidad de medida no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dUnidadMedida.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dUnidadMedida.Eliminar(id, out Mensaje);
        }
    }
}
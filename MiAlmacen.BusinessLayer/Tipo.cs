using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Tipo
    {
        DataLayer.Tipo dTipo = new DataLayer.Tipo();

        public List<EntityLayer.Tipo> Listar()
        {
            return dTipo.Listar();
        }

        public int Registrar(EntityLayer.Tipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreTipo) || string.IsNullOrWhiteSpace(obj.NombreTipo))
                Mensaje = "El nombre de la Tipo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipo.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Tipo obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreTipo) || string.IsNullOrWhiteSpace(obj.NombreTipo))
                Mensaje = "El nombre de la Tipo no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dTipo.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dTipo.Eliminar(id, out Mensaje);
        }
    }
}

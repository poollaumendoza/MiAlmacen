using System.Collections.Generic;

namespace MiAlmacen.BusinessLayer
{
    public class Color
    {
        DataLayer.Color dColor = new DataLayer.Color();

        public List<EntityLayer.Color> Listar()
        {
            return dColor.Listar();
        }

        public int Registrar(EntityLayer.Color obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreColor) || string.IsNullOrWhiteSpace(obj.NombreColor))
                Mensaje = "El nombre del color no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dColor.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Color obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreColor) || string.IsNullOrWhiteSpace(obj.NombreColor))
                Mensaje = "El nombre del color no puede ser vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dColor.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dColor.Eliminar(id, out Mensaje);
        }
    }
}
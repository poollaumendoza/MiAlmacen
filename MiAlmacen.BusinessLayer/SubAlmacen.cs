using System.Collections.Generic;

namespace MiAlmacen.BusinessLayer
{
    public class SubAlmacen
    {
        DataLayer.SubAlmacen dSubAlmacen = new DataLayer.SubAlmacen();

        public List<EntityLayer.SubAlmacen> Listar()
        {
            return dSubAlmacen.Listar();
        }

        public int Registrar(EntityLayer.SubAlmacen obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oAlmacen.IdAlmacen == 0)
                Mensaje = "Debe seleccionar un almacen";
            else if (string.IsNullOrEmpty(obj.NombreSubAlmacen) || string.IsNullOrWhiteSpace(obj.NombreSubAlmacen))
                Mensaje = "El nombre del subalmacen no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dSubAlmacen.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.SubAlmacen obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oAlmacen.IdAlmacen == 0)
                Mensaje = "Debe seleccionar un almacen";
            else if (string.IsNullOrEmpty(obj.NombreSubAlmacen) || string.IsNullOrWhiteSpace(obj.NombreSubAlmacen))
                Mensaje = "El nombre del subalmacen no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dSubAlmacen.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dSubAlmacen.Eliminar(id, out Mensaje);
        }
    }
}

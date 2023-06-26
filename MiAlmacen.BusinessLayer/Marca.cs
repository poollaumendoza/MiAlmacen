using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Marca
    {
        DataLayer.Marca dMarca = new DataLayer.Marca();

        public List<EntityLayer.Marca> Listar()
        {
            return dMarca.Listar();
        }

        public int Registrar(EntityLayer.Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreMarca) || string.IsNullOrWhiteSpace(obj.NombreMarca))
                Mensaje = "El nombre de la Marca no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dMarca.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Marca obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreMarca) || string.IsNullOrWhiteSpace(obj.NombreMarca))
                Mensaje = "El nombre de la Marca no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dMarca.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dMarca.Eliminar(id, out Mensaje);
        }
    }
}

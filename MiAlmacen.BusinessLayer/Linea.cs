using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
   public class Linea
    {
        DataLayer.Linea dLinea = new DataLayer.Linea();

        public List<EntityLayer.Linea> Listar()
        {
            return dLinea.Listar();
        }

        public int Registrar(EntityLayer.Linea obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreLinea) || string.IsNullOrWhiteSpace(obj.NombreLinea))
                Mensaje = "El nombre de la linea no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dLinea.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Linea obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oEntidad.IdEntidad == 0)
                Mensaje = "Debe seleccionar un proveedor";
            else if (string.IsNullOrEmpty(obj.NombreLinea) || string.IsNullOrWhiteSpace(obj.NombreLinea))
                Mensaje = "El nombre de la linea no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dLinea.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dLinea.Eliminar(id, out Mensaje);
        }
    }
}
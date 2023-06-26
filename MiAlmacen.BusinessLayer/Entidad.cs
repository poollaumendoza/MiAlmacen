using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Entidad
    {
        DataLayer.Entidad dEntidad = new DataLayer.Entidad();

        public List<EntityLayer.Entidad> Listar()
        {
            return dEntidad.Listar();
        }

        public int Registrar(EntityLayer.Entidad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.RazonSocial) || string.IsNullOrWhiteSpace(obj.RazonSocial))
                Mensaje = "La razón social no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "La razón social no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "La razón social no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
                Mensaje = "La razón social no puede ser vacío";
            else if (obj.EsCliente == false && obj.EsProveedor == false && obj.EsTransportista == false)
                Mensaje = "Debe seleccionar algunas de las opciones siguientes: Cliente, Proveedor o Transportista";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dEntidad.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Entidad obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.RazonSocial) || string.IsNullOrWhiteSpace(obj.RazonSocial))
                Mensaje = "La razón social no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "La razón social no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "La razón social no puede ser vacío";
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
                Mensaje = "La razón social no puede ser vacío";
            else if (obj.EsCliente == false && obj.EsProveedor == false && obj.EsTransportista == false)
                Mensaje = "Debe seleccionar algunas de las opciones siguientes: Cliente, Proveedor o Transportista";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dEntidad.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dEntidad.Eliminar(id, out Mensaje);
        }
    }
}
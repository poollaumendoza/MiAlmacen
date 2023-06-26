using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAlmacen.BusinessLayer
{
    public class Persona
    {
        DataLayer.Persona dPersona = new DataLayer.Persona();

        public List<EntityLayer.Persona> Listar()
        {
            return dPersona.Listar();
        }

        public int Registrar(EntityLayer.Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.ApellidoPaterno) || string.IsNullOrWhiteSpace(obj.ApellidoPaterno))
                Mensaje = "El apellido paterno no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.ApellidoMaterno) || string.IsNullOrWhiteSpace(obj.ApellidoMaterno))
                Mensaje = "El apellido materno no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
                Mensaje = "El primer nombre no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
                Mensaje = "El segundo nombre no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "La dirección no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "El teléfono no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
                Mensaje = "El email no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPersona.Registrar(obj, out Mensaje);
            else
                return 0;
        }

        public bool Editar(EntityLayer.Persona obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.oTipoDocumento.IdTipoDocumento == 0)
                Mensaje = "Debe seleccionar un tipo de documento";
            else if (string.IsNullOrEmpty(obj.NroDocumento) || string.IsNullOrWhiteSpace(obj.NroDocumento))
                Mensaje = "El número de documento no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.ApellidoPaterno) || string.IsNullOrWhiteSpace(obj.ApellidoPaterno))
                Mensaje = "El apellido paterno no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.ApellidoMaterno) || string.IsNullOrWhiteSpace(obj.ApellidoMaterno))
                Mensaje = "El apellido materno no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.PrimerNombre) || string.IsNullOrWhiteSpace(obj.PrimerNombre))
                Mensaje = "El primer nombre no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.SegundoNombre) || string.IsNullOrWhiteSpace(obj.SegundoNombre))
                Mensaje = "El segundo nombre no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.Direccion) || string.IsNullOrWhiteSpace(obj.Direccion))
                Mensaje = "La dirección no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.Telefono) || string.IsNullOrWhiteSpace(obj.Telefono))
                Mensaje = "El teléfono no puede quedar vacío";
            else if (string.IsNullOrEmpty(obj.Email) || string.IsNullOrWhiteSpace(obj.Email))
                Mensaje = "El email no puede quedar vacío";
            else if (obj.oEstado.IdEstado == 0)
                Mensaje = "Debe seleccionar un estado";

            if (string.IsNullOrEmpty(Mensaje))
                return dPersona.Editar(obj, out Mensaje);
            else
                return false;
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return dPersona.Eliminar(id, out Mensaje);
        }
    }
}
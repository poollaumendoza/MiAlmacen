using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class EntidadUbicacionController : Controller
    {
        // GET: EntidadUbicacion
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarEntidadUbicacion()
        {
            List<EntityLayer.EntidadUbicacion> oLista = new List<EntityLayer.EntidadUbicacion>();
            oLista = new BusinessLayer.EntidadUbicacion().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEntidadUbicacion(EntityLayer.EntidadUbicacion objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEntidadUbicacion == 0)
                resultado = new BusinessLayer.EntidadUbicacion().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.EntidadUbicacion().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarEntidadUbicacion(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.EntidadUbicacion().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
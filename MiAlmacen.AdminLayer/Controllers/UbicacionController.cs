using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class UbicacionController : Controller
    {
        // GET: Ubicacion
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarUbicacion()
        {
            List<EntityLayer.Ubicacion> oLista = new List<EntityLayer.Ubicacion>();
            oLista = new BusinessLayer.Ubicacion().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUbicacion(EntityLayer.Ubicacion objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdUbicacion == 0)
                resultado = new BusinessLayer.Ubicacion().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Ubicacion().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUbicacion(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Ubicacion().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
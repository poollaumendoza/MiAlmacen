using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class PickingController : Controller
    {
        // GET: Picking
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarPicking()
        {
            List<EntityLayer.Picking> oLista = new List<EntityLayer.Picking>();
            oLista = new BusinessLayer.Picking().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPicking(EntityLayer.Picking objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdPicking == 0)
                resultado = new BusinessLayer.Picking().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Picking().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPicking(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Picking().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
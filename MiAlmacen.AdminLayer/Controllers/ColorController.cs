using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarColor()
        {
            List<EntityLayer.Color> oLista = new List<EntityLayer.Color>();
            oLista = new BusinessLayer.Color().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarColor(EntityLayer.Color objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdColor == 0)
                resultado = new BusinessLayer.Color().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Color().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarColor(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Color().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
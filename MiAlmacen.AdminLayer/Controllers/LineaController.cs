using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class LineaController : Controller
    {
        // GET: Linea
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarLinea()
        {
            List<EntityLayer.Linea> oLista = new List<EntityLayer.Linea>();
            oLista = new BusinessLayer.Linea().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarLinea(EntityLayer.Linea objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdLinea == 0)
                resultado = new BusinessLayer.Linea().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Linea().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarLinea(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Linea().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class SubAlmacenController : Controller
    {
        // GET: SubAlmacen
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarSubAlmacen()
        {
            List<EntityLayer.SubAlmacen> oLista = new List<EntityLayer.SubAlmacen>();
            oLista = new BusinessLayer.SubAlmacen().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarSubAlmacen(EntityLayer.SubAlmacen objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdSubAlmacen == 0)
                resultado = new BusinessLayer.SubAlmacen().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.SubAlmacen().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarSubAlmacen(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.SubAlmacen().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
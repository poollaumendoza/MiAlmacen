using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ColumnaController : Controller
    {
        // GET: Columna
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarColumna()
        {
            List<EntityLayer.Columna> oLista = new List<EntityLayer.Columna>();
            oLista = new BusinessLayer.Columna().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarColumna(EntityLayer.Columna objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdColumna == 0)
                resultado = new BusinessLayer.Columna().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Columna().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarColumna(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Columna().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
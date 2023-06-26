using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class PasilloController : Controller
    {
        // GET: Pasillo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarPasillo()
        {
            List<EntityLayer.Pasillo> oLista = new List<EntityLayer.Pasillo>();
            oLista = new BusinessLayer.Pasillo().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPasillo(EntityLayer.Pasillo objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdPasillo == 0)
                resultado = new BusinessLayer.Pasillo().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Pasillo().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPasillo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Pasillo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
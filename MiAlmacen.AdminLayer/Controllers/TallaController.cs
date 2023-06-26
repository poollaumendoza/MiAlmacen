using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class TallaController : Controller
    {
        // GET: Talla
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTalla()
        {
            List<EntityLayer.Talla> oLista = new List<EntityLayer.Talla>();
            oLista = new BusinessLayer.Talla().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTalla(EntityLayer.Talla objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTalla == 0)
                resultado = new BusinessLayer.Talla().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Talla().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTalla(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Talla().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
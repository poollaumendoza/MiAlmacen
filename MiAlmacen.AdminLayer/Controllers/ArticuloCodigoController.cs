using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ArticuloCodigoController : Controller
    {
        // GET: ArticuloCodigo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarArticuloCodigo()
        {
            List<EntityLayer.ArticuloCodigo> oLista = new List<EntityLayer.ArticuloCodigo>();
            oLista = new BusinessLayer.ArticuloCodigo().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarArticuloCodigo(EntityLayer.ArticuloCodigo objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdArticuloCodigo == 0)
                resultado = new BusinessLayer.ArticuloCodigo().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ArticuloCodigo().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarArticuloCodigo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ArticuloCodigo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
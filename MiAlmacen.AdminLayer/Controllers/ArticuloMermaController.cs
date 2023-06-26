using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ArticuloMermaMermaController : Controller
    {
        // GET: ArticuloMermaMerma
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarArticuloMerma()
        {
            List<EntityLayer.ArticuloMerma> oLista = new List<EntityLayer.ArticuloMerma>();
            oLista = new BusinessLayer.ArticuloMerma().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarArticuloMerma(EntityLayer.ArticuloMerma objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdArticuloMerma == 0)
                resultado = new BusinessLayer.ArticuloMerma().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ArticuloMerma().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarArticuloMerma(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ArticuloMerma().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
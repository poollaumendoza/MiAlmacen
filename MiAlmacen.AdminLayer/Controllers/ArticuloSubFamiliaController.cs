using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ArticuloSubFamiliaSubFamiliaController : Controller
    {
        // GET: ArticuloSubFamiliaSubFamilia
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarArticuloSubFamilia()
        {
            List<EntityLayer.ArticuloSubFamilia> oLista = new List<EntityLayer.ArticuloSubFamilia>();
            oLista = new BusinessLayer.ArticuloSubFamilia().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarArticuloSubFamilia(EntityLayer.ArticuloSubFamilia objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdArticuloSubFamilia == 0)
                resultado = new BusinessLayer.ArticuloSubFamilia().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ArticuloSubFamilia().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarArticuloSubFamilia(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ArticuloSubFamilia().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
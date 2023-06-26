using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ArticuloFamiliaFamiliaController : Controller
    {
        // GET: ArticuloFamiliaFamilia
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarArticuloFamilia()
        {
            List<EntityLayer.ArticuloFamilia> oLista = new List<EntityLayer.ArticuloFamilia>();
            oLista = new BusinessLayer.ArticuloFamilia().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarArticuloFamilia(EntityLayer.ArticuloFamilia objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdArticuloFamilia == 0)
                resultado = new BusinessLayer.ArticuloFamilia().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ArticuloFamilia().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarArticuloFamilia(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ArticuloFamilia().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ArticuloSubTipoSubTipoController : Controller
    {
        // GET: ArticuloSubTipoSubTipo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarArticuloSubTipo()
        {
            List<EntityLayer.ArticuloSubTipo> oLista = new List<EntityLayer.ArticuloSubTipo>();
            oLista = new BusinessLayer.ArticuloSubTipo().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarArticuloSubTipo(EntityLayer.ArticuloSubTipo objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdArticuloSubTipo == 0)
                resultado = new BusinessLayer.ArticuloSubTipo().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ArticuloSubTipo().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarArticuloSubTipo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ArticuloSubTipo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
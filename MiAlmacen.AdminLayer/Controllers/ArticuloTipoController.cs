using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ArticuloTipoTipoController : Controller
    {
        // GET: ArticuloTipoTipo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarArticuloTipo()
        {
            List<EntityLayer.ArticuloTipo> oLista = new List<EntityLayer.ArticuloTipo>();
            oLista = new BusinessLayer.ArticuloTipo().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarArticuloTipo(EntityLayer.ArticuloTipo objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdArticuloTipo == 0)
                resultado = new BusinessLayer.ArticuloTipo().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.ArticuloTipo().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarArticuloTipo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.ArticuloTipo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
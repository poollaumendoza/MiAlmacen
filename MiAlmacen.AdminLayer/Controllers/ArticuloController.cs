using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarArticulo()
        {
            List<EntityLayer.Articulo> oLista = new List<EntityLayer.Articulo>();
            oLista = new BusinessLayer.Articulo().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarArticulo(EntityLayer.Articulo objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdArticulo == 0)
                resultado = new BusinessLayer.Articulo().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Articulo().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarArticulo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Articulo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
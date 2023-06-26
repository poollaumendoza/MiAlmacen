using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class ModeloController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarModelo()
        {
            List<EntityLayer.Modelo> oLista = new List<EntityLayer.Modelo>();
            oLista = new BusinessLayer.Modelo().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarModelo(EntityLayer.Modelo objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdModelo == 0)
                resultado = new BusinessLayer.Modelo().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Modelo().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarModelo(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Modelo().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
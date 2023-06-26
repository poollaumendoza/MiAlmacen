using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class UnidadMedidaController : Controller
    {
        // GET: UnidadMedida
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarUnidadMedida()
        {
            List<EntityLayer.UnidadMedida> oLista = new List<EntityLayer.UnidadMedida>();
            oLista = new BusinessLayer.UnidadMedida().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUnidadMedida(EntityLayer.UnidadMedida objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdUnidadMedida == 0)
                resultado = new BusinessLayer.UnidadMedida().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.UnidadMedida().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarUnidadMedida(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.UnidadMedida().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class PedidoEntidadController : Controller
    {
        // GET: PedidoEntidad
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarPedidoEntidad()
        {
            List<EntityLayer.PedidoEntidad> oLista = new List<EntityLayer.PedidoEntidad>();
            oLista = new BusinessLayer.PedidoEntidad().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPedidoEntidad(EntityLayer.PedidoEntidad objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdPedidoEntidad == 0)
                resultado = new BusinessLayer.PedidoEntidad().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.PedidoEntidad().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPedidoEntidad(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.PedidoEntidad().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
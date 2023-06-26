using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class PedidoEntidadDetalleController : Controller
    {
        // GET: PedidoEntidadDetalle
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarPedidoEntidadDetalle()
        {
            List<EntityLayer.PedidoEntidadDetalle> oLista = new List<EntityLayer.PedidoEntidadDetalle>();
            oLista = new BusinessLayer.PedidoEntidadDetalle().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPedidoEntidadDetalle(EntityLayer.PedidoEntidadDetalle objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdPedidoEntidadDetalle == 0)
                resultado = new BusinessLayer.PedidoEntidadDetalle().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.PedidoEntidadDetalle().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPedidoEntidadDetalle(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.PedidoEntidadDetalle().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
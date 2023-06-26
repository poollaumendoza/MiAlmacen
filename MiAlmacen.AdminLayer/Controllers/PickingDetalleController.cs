using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class PickingDetalleController : Controller
    {
        // GET: PickingDetalle
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarPickingDetalle()
        {
            List<EntityLayer.PickingDetalle> oLista = new List<EntityLayer.PickingDetalle>();
            oLista = new BusinessLayer.PickingDetalle().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarPickingDetalle(EntityLayer.PickingDetalle objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdPickingDetalle == 0)
                resultado = new BusinessLayer.PickingDetalle().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.PickingDetalle().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarPickingDetalle(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.PickingDetalle().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
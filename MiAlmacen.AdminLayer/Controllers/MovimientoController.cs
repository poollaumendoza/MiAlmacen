using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class MovimientoController : Controller
    {
        // GET: Movimiento
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarMovimiento()
        {
            List<EntityLayer.Movimiento> oLista = new List<EntityLayer.Movimiento>();
            oLista = new BusinessLayer.Movimiento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarMovimiento(EntityLayer.Movimiento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdMovimiento == 0)
                resultado = new BusinessLayer.Movimiento().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Movimiento().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarMovimiento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Movimiento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
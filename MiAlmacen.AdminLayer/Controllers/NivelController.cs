using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class NivelController : Controller
    {
        // GET: Nivel
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarNivel()
        {
            List<EntityLayer.Nivel> oLista = new List<EntityLayer.Nivel>();
            oLista = new BusinessLayer.Nivel().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarNivel(EntityLayer.Nivel objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdNivel == 0)
                resultado = new BusinessLayer.Nivel().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Nivel().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarNivel(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.Nivel().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
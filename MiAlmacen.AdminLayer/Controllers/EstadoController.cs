using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarEstado()
        {
            List<EntityLayer.Estado> oLista = new List<EntityLayer.Estado>();
            oLista = new BusinessLayer.Estado().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEstado(EntityLayer.Estado objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdEstado == 0)
                resultado = new BusinessLayer.Estado().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.Estado().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
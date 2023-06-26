﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiAlmacen.AdminLayer.Controllers
{
    public class TipoDocumentoController : Controller
    {
        // GET: TipoDocumento
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListarTipoDocumento()
        {
            List<EntityLayer.TipoDocumento> oLista = new List<EntityLayer.TipoDocumento>();
            oLista = new BusinessLayer.TipoDocumento().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarTipoDocumento(EntityLayer.TipoDocumento objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.IdTipoDocumento == 0)
                resultado = new BusinessLayer.TipoDocumento().Registrar(objeto, out mensaje);
            else
                resultado = new BusinessLayer.TipoDocumento().Editar(objeto, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarTipoDocumento(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new BusinessLayer.TipoDocumento().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
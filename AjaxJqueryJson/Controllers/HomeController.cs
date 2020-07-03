using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiDev.Bussines.Persona;
using TiDev.Entity.Persona;

namespace AjaxJqueryJson.Controllers
{
    public class HomeController : Controller
    {
        BusPersona Comando = new BusPersona();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            try
            {
                List<EntPersona> lsPersonas = Comando.Obtener();
                return Json(new{mensaje="ok", ls = lsPersonas }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
            //    List<EntPersona> lsPersonas = new List<EntPersona> ();
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerPorId(int id)
        {
            try
            {
                EntPersona Persona = Comando.Obtener(id);
                return Json(new { mensaje = "ok", Ent = Persona }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Agregar(EntPersona p)
        {
            try
            {
                Comando.Create(p);
                return Json(new { mensaje = "ok"}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message },JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult BorrarDeServidor(int id)
        {
            try
            {
                Comando.Delete(id);
                return Json(new { mensaje = "ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Editar (EntPersona p)
        {
            try
            {
                Comando.Edit(p);
                return Json(new { mensaje = "ok" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Buscar(String valor)
        {
            try
            {
                List<EntPersona> lsPersonas = Comando.Obtener(valor);
                return Json(new { mensaje = "ok", ls = lsPersonas }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}

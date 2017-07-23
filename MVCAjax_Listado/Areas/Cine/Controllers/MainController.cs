using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreCine;

namespace MVCAjax_Listado.Areas.Cine.Controllers
{
    public class MainController : Controller
    {
        // GET: Cine/Main
        ////////////////////////// Listado de Cine
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListadoCine()
        {
            return PartialView(DACine.ListadoCine());            
        }

        ///////////////////////// Actualizar Cine        
        public ActionResult ActualizarCine(int CodCine)
        {            
            CoreCine.Cine cine = DACine.ListadoCine().Where(x => x.CodCine == CodCine).FirstOrDefault();
            return View(cine);
        }

        [HttpPost]
        public ActionResult ActualizarCine(CoreCine.Cine cine)
        {
            //para cargar la data
            bool exito = DACine.ActualizarCine(cine);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar cineeeeeeeeeeeeeeeee

        public ActionResult Eliminar(int CodCine)
        {
            bool exito = DACine.EliminarCine(CodCine);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar pedido


        public JsonResult GrabarCine(string NombreCine,
            string Direccion)
        {
            CoreCine.Cine cine = new CoreCine.Cine();


            cine.NombreCine = NombreCine;
            cine.Direccion = Direccion;

            // texto satisfactorio

            bool exito = DACine.RegistrarCine(cine);

            string mensaje = string.Empty;

            if (exito)
            {
                mensaje = "Registro satisfactorio";
            }
            else
            {
                mensaje = "Ha ocurrido un error. Intente nuevamente";
            }

            return Json(mensaje, JsonRequestBehavior.AllowGet);

        }

        public ActionResult FormCine()
        {

            return PartialView();

        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreCine;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Director.Controllers
{
    public class MainController : Controller
    {
        // GET: Director/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoDirector()
        {
            return PartialView(DADirector.ListadoDirector());
        }

        ///////////////////////// Actualizar Director      
        public ActionResult ActualizarDirector(int CodDirector)
        {
            CoreCine.Director director = DADirector.ListadoDirector().Where(x => x.CodDirector == CodDirector).FirstOrDefault();
            return View(director);
        }

        [HttpPost]
        public ActionResult ActualizarDirector(CoreCine.Director direc)
        {
            //para cargar la data
            bool exito = DADirector.ActualizarDirector(direc);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar Director

        public ActionResult Eliminar(int CodDirector)
        {
            bool exito = DADirector.EliminarDirector(CodDirector);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar Director


        public JsonResult GrabarDirector(string NombreDirector)
        {
            CoreCine.Director director = new CoreCine.Director();


            director.NombreDirector = NombreDirector;
            

            // texto satisfactorio

            bool exito = DADirector.RegistrarDirector(director);

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

        public ActionResult FormDirector()
        {

            return PartialView();

        }

    }
}
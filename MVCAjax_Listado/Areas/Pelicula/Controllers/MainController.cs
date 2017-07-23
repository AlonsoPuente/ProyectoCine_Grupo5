using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreCine;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Pelicula.Controllers
{
    public class MainController : Controller
    {
        // GET: Pelicula/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoPelicula()
        {
            ViewBag.ListadoDirector = DADirector.ListadoDirector();
            return PartialView(DAPelicula.ListadoPelicula());
        }

        ///////////////////////// Actualizar Pedido        
        public ActionResult ActualizarPelicula(int CodPelicula)
        {
            CoreCine.Pelicula pelicula = DAPelicula.ListadoPelicula().Where(x => x.CodPelicula == CodPelicula).FirstOrDefault();
            return View(pelicula);
        }

        [HttpPost]
        public ActionResult ActualizarPelicula(CoreCine.Pelicula peli)
        {
            //para cargar la data
            bool exito = DAPelicula.ActualizarPelicula(peli);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar Pedido

        public ActionResult Eliminar(int CodPelicula)
        {
            bool exito = DAPelicula.EliminarPelicula(CodPelicula);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar pedido


        public JsonResult GrabarPelicula(string NombrePelicula, string Duracion, DateTime FechaEstreno, 
            int CodDirector)
        {
            CoreCine.Pelicula pelicula = new CoreCine.Pelicula();


            pelicula.NombrePelicula = NombrePelicula;
            pelicula.Duracion = Duracion;
            pelicula.FechaEstreno = FechaEstreno;
            pelicula.CodDirector = CodDirector;

            // texto satisfactorio

            bool exito = DAPelicula.RegistrarPelicula(pelicula);

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

        public ActionResult FormPelicula()
        {

            return PartialView();

        }


    }
}
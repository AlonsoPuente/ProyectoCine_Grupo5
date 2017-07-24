using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreCine;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.CinePelicula.Controllers
{
    public class MainController : Controller
    {
        // GET: CinePelicula/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoCinePelicula()
        {

            ViewBag.ListadoCine = DACine.ListadoCine();
            ViewBag.ListadoPelicula = DAPelicula.ListadoPelicula();
            return PartialView(DACinePelicula.ListadoCinePelicula());

        }

        ///////////////////////// Actualizar Cinepelicula        
        public ActionResult ActualizarCinePelicula(int CodCine)
        {
            CoreCine.CinePelicula CinePelicula = DACinePelicula.ListadoCinePelicula().Where(x => x.CodCine == CodCine).FirstOrDefault();
            return View(CinePelicula);
        }

        [HttpPost]
        public ActionResult ActualizarCinePelicula(CoreCine.CinePelicula cpeli)
        {
            //para cargar la data
            bool exito = DACinePelicula.ActualizarCinePelicula(cpeli);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar CinePelicula

        public ActionResult Eliminar(int CodCine)
        {
            bool exito = DACinePelicula.EliminarCinePelicula(CodCine);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar CinePelicula


        public JsonResult GrabarCinePelicula(int CodCine, int CodPelicula,
            bool EnCartelera)
        {
            CoreCine.CinePelicula cp = new CoreCine.CinePelicula();


            cp.CodCine = CodCine;
            cp.CodPelicula = CodPelicula;
            cp.EnCartelera = EnCartelera;
            

            // texto satisfactorio

            bool exito = DACinePelicula.RegistrarCinePelicula(cp);

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

        public ActionResult FormCinePelicula()
        {

            return PartialView();

        }

    }
}
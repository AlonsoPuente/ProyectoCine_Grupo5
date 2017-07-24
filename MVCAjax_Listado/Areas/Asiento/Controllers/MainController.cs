using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreCine;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Asiento.Controllers
{
    public class MainController : Controller
    {
        // GET: Asiento/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoAsiento()
        {
            ViewBag.ListadoSala = DASala.ListadoSala();
            return PartialView(DAAsiento.ListadoAsiento());
        }

        ///////////////////////// Actualizar Asiento        
        public ActionResult ActualizarAsiento(int CodAsiento)
        {
            CoreCine.Asiento asiento = DAAsiento.ListadoAsiento().Where(x => x.CodAsiento == CodAsiento).FirstOrDefault();
            return View(asiento);
        }

        [HttpPost]
        public ActionResult ActualizarAsiento(CoreCine.Asiento asiento)
        {
            //para cargar la data
            bool exito = DAAsiento.ActualizarAsiento(asiento);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar Asiento

        public ActionResult Eliminar(int CodAsiento)
        {
            bool exito = DAAsiento.EliminarAsiento(CodAsiento);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar Asiento


        public JsonResult GrabarAsiento(string DescripcionAsiento, int CodSala, int TipoAsiento,
            bool Disponible)
        {
            CoreCine.Asiento asiento = new CoreCine.Asiento();


            asiento.DescripcionAsiento = DescripcionAsiento;
            asiento.CodSala = CodSala;
            asiento.TipoAsiento = TipoAsiento;
            asiento.Disponible = Disponible;

            // texto satisfactorio

            bool exito = DAAsiento.RegistrarAsiento(asiento);

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

        public ActionResult FormAsiento()
        {

            return PartialView();

        }


    }
}
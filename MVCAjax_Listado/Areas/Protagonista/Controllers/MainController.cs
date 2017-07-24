using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreCine;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Protagonista.Controllers
{
    public class MainController : Controller
    {
        // GET: Protagonista/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoProtagonista()
        {
            ViewBag.ListadoInterprete = DAInterprete.ListadoInterprete();
            ViewBag.ListadoPelicula = DAPelicula.ListadoPelicula();
            return PartialView(DAProtagonista.ListadoProtagonista());
        }

        ///////////////////////// Actualizar Pedido        
        public ActionResult ActualizarProtagonista(int CodInterprete)
        {
            CoreCine.Protagonista protagonista = DAProtagonista.ListadoProtagonista().Where(x => x.CodInterprete == CodInterprete).FirstOrDefault();
            return View(protagonista);
        }

        [HttpPost]
        public ActionResult ActualizarProtagonista(CoreCine.Protagonista prota)
        {
            //para cargar la data
            bool exito = DAProtagonista.ActualizarProtagonista(prota);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar Pedido

        public ActionResult Eliminar(int CodInterprete)
        {
            bool exito = DAProtagonista.EliminarProtagonista(CodInterprete);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar pedido


        public JsonResult GrabarProtagonista(int CodInterprete, int CodPelicula, string NombreProtagonista,
             bool EsPrincipal)
        {
            CoreCine.Protagonista protagonista = new CoreCine.Protagonista();


            protagonista.CodInterprete = CodInterprete;
            protagonista.CodPelicula = CodPelicula;
            protagonista.NombreProtagonista = NombreProtagonista;
            protagonista.EsPrincipal = EsPrincipal;

            // texto satisfactorio

            bool exito = DAProtagonista.RegistrarProtagonista(protagonista);

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

        public ActionResult FormProtagonista()
        {

            return PartialView();

        }

    }
}
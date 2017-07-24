using System;
using System.Collections.Generic;
using System.Linq;
using CoreCine;
using System.Web;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Funcion.Controllers
{
    public class MainController : Controller
    {
        // GET: Funcion/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoFuncion()
        {
            ViewBag.ListadoPelicula = DAPelicula.ListadoPelicula();
            return PartialView(DAFuncion.ListadoFuncion());
        }

        ///////////////////////// Actualizar Funcion        
        public ActionResult ActualizarFuncion(int CodFuncion)
        {
            CoreCine.Funcion funcion = DAFuncion.ListadoFuncion().Where(x => x.CodFuncion == CodFuncion).FirstOrDefault();
            return View(funcion);
        }

        [HttpPost]
        public ActionResult ActualizarFuncion(CoreCine.Funcion funcion)
        {
            //para cargar la data
            bool exito = DAFuncion.ActualizarFuncion(funcion);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar Funcion

        public ActionResult Eliminar(int CodFuncion)
        {
            bool exito = DAFuncion.EliminarFuncion(CodFuncion);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar pedido


        public JsonResult GrabarFuncion(int CodFuncion, DateTime HoraInicio, DateTime HoraFin,
            int CodPelicula, DateTime FechaFuncion, decimal Precio)
        {
            CoreCine.Funcion funcion = new CoreCine.Funcion();


            funcion.HoraInicio = HoraInicio;
            funcion.HoraFin = HoraFin;
            funcion.CodPelicula = CodPelicula;
            funcion.FechaFuncion = FechaFuncion;
            funcion.Precio = Precio;
            

            // texto satisfactorio

            bool exito = DAFuncion.RegistrarFuncion(funcion);

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

        public ActionResult FormFuncion()
        {

            return PartialView();

        }

    }
}
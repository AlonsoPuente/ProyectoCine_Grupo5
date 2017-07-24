using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreCine;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Sala.Controllers
{
    public class MainController : Controller
    {
        // GET: Sala/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoSala()
        {
            ViewBag.ListadoCine = DACine.ListadoCine();
            return PartialView(DASala.ListadoSala());
        }

        ///////////////////////// Actualizar Sala        
        public ActionResult ActualizarSala(int CodSala)
        {
            CoreCine.Sala sala = DASala.ListadoSala().Where(x => x.CodSala == CodSala).FirstOrDefault();
            return View(sala);
        }

        [HttpPost]
        public ActionResult ActualizarSala(CoreCine.Sala sala)
        {
            //para cargar la data
            bool exito = DASala.ActualizarSala(sala);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar sala

        public ActionResult Eliminar(int CodSala)
        {
            bool exito = DASala.EliminarSala(CodSala);

            return RedirectToAction("Index");

        }

        ////////////////////////// Registrar sala


        public JsonResult GrabarSala(string NombreSala, int Capacidad, string Tipo,
            int CodCine)
        {
            CoreCine.Sala sala = new CoreCine.Sala();


            sala.NombreSala = NombreSala;
            sala.Capacidad = Capacidad;
            sala.Tipo = Tipo;
            sala.CodCine = CodCine;

            // texto satisfactorio

            bool exito = DASala.RegistrarSala(sala);

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

        public ActionResult FormSala()
        {

            return PartialView();

        }

    }
}
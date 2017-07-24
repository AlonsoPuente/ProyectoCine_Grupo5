using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreCine;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Ticket.Controllers
{
    public class MainController : Controller
    {
        // GET: Ticket/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoTicket()
        {
            ViewBag.ListadoAsiento = DAAsiento.ListadoAsiento();
            ViewBag.ListadoPersona = DAPersona.ListadoPersona();
            ViewBag.ListadoFuncion = DAFuncion.ListadoFuncion();
            return PartialView(DATicket.ListadoTicket());
        }

        ///////////////////////// Actualizar Ticket        
        public ActionResult ActualizarTicket(int CodTicket)
        {
            CoreCine.Ticket Ticket = DATicket.ListadoTicket().Where(x => x.CodTicket == CodTicket).FirstOrDefault();
            return View(Ticket);
        }

        [HttpPost]
        public ActionResult ActualizarTicket(CoreCine.Ticket ti)
        {
            //para cargar la data
            bool exito = DATicket.ActualizarTicket(ti);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar Ticket

        public ActionResult Eliminar(int CodTicket)
        {
            bool exito = DATicket.EliminarTicket(CodTicket);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar Ticket


        public JsonResult GrabarTicket(string Descripcion, int CodAsiento, int CodPersona,
            int CodFuncion)
        {
            CoreCine.Ticket ticket = new CoreCine.Ticket();


            ticket.Descripcion = Descripcion;
            ticket.CodAsiento = CodAsiento;
            ticket.CodPersona = CodPersona;
            ticket.CodFuncion = CodFuncion;

            // texto satisfactorio

            bool exito = DATicket.RegistrarTicket(ticket);

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

        public ActionResult FormTicket()
        {

            return PartialView();

        }



    }
}
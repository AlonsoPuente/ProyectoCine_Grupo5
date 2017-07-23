using CoreCine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Interprete.Controllers
{
    public class MainController : Controller
    {
        // GET: Interprete/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listado()
        {
            ViewBag.ListadoInterprete = DAInterprete.ListadoInterprete();
            return PartialView(DAInterprete.ListadoInterprete());
        }

        ///////////////////////// Registrar Intérprete
        public ActionResult RegistrarInterprete()
        {
            return PartialView();
        }
        
        ///////////////////////// Actualizar Intérprete      
        public ActionResult ActualizarInterprete(int CodInterprete)
        {
            CoreCine.Interprete interprete = DAInterprete.ListadoInterprete().Where(x => x.CodInterprete == CodInterprete).FirstOrDefault();
            return View(interprete);
        }

        [HttpPost]
        public ActionResult ActualizarInterprete(CoreCine.Interprete interprete)
        {
            //para cargar la data
            bool exito = DAInterprete.ActualizarInterprete(interprete);
            return RedirectToAction("Index");

        }

        //////////////////////// Eliminar Intérprete
        public ActionResult EliminarInterprete(int ID)
        {
            bool exito = DAInterprete.EliminarInterprete(ID);
            return RedirectToAction("Index");
        }
    }

}
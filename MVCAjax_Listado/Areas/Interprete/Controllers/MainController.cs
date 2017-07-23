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
            ViewBag.ListadoInterprete = DAInterprete.listadoInterprete();
            return PartialView(DAInterprete.listadoInterprete());
        }
        public ActionResult RegistrarInterprete()
        {
            return PartialView();
        }
        public ActionResult EliminarInterprete(int ID)
        {
            bool exito = DAInterprete.EliminarInterprete(ID);
            return RedirectToAction("Index");
        }
        //public ActionResult EditarInterprete(int ID)
        //{
        //    Interprete proyecto = DAInterprete.listadoInterprete().Where(x => x.CodInterprete == ID).FirstOrDefault();
        //    return View(proyecto);
        //}

        //public ActionResult EditarProyecto(Interprete interprete)
        //{
        //    //para cargar la data
        //    bool exito = DAInterprete.ActualizarInterprete(interprete);
        //    return RedirectToAction("Index");

        //}





    }


}
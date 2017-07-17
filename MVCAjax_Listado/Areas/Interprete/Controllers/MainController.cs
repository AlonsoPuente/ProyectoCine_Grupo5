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
            ViewBag.ListadoProtagonista = DAGeneral.ListadoProtagonista();
            return PartialView(DAGeneral.ListadoInterprete());
        }

        

       
    }

    
}
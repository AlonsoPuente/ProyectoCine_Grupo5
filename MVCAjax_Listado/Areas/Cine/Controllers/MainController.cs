using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreCine;

namespace MVCAjax_Listado.Areas.Cine.Controllers
{
    public class MainController : Controller
    {
        // GET: Cine/Main
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListadoCine()
        {
            return PartialView(DACine.ListadoCine());            
        }

        /// Listado de Cine
    }
}
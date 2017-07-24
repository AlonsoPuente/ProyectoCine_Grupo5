using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreCine;
using System.Web.Mvc;

namespace MVCAjax_Listado.Areas.Pedido.Controllers
{
    public class MainController : Controller
    {
        // GET: Pedido/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoPedido()
        {
            ViewBag.ListadoTicket = DATicket.ListadoTicket();
            return PartialView(DAPedido.ListadoPedido());
        }

        ///////////////////////// Actualizar Pedido        
        public ActionResult ActualizarPedido(int CodPedido)
        {
            CoreCine.Pedido pedido = DAPedido.ListadoPedido().Where(x => x.CodPedido == CodPedido).FirstOrDefault();
            return View(pedido);
        }

        [HttpPost]
        public ActionResult ActualizarPedido(CoreCine.Pedido ped)
        {
            //para cargar la data
            bool exito = DAPedido.ActualizarPedido(ped);
            return RedirectToAction("Index");

        }

        ////////////////////////// Eliminar Pedido

        public ActionResult Eliminar(int CodPedido)
        {
            bool exito = DAPedido.EliminarPedido(CodPedido);

            return RedirectToAction("Index");


        }

        ////////////////////////// Registrar pedido


        public JsonResult GrabarPedido( string Descripcion,
            int CodTicket)
        {
            CoreCine.Pedido pedido = new CoreCine.Pedido();

          
            pedido.Descripcion = Descripcion;
            pedido.CodTicket = CodTicket;

            // texto satisfactorio

            bool exito = DAPedido.RegistrarPedido(pedido);

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

        public ActionResult FormPedido()
        {

            return PartialView();

        }

    }
}
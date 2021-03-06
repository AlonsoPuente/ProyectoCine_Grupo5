﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreCine;

namespace MVCAjax_Listado.Areas.Persona.Controllers
{
    public class MainController : Controller
    {
        // GET: Persona/Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListadoPersona()
        {
            return PartialView(DAPersona.ListadoPersona());
        }

        ///////////////////////// Registrar Persona
        public ActionResult RegistrarPersona()
        {
            return PartialView();
        }

        ///////////////////////// Actualizar Persona        
        public ActionResult ActualizarPersona(int CodPersona)
        {
            CoreCine.Persona persona = DAPersona.ListadoPersona().Where(x => x.CodPersona == CodPersona).FirstOrDefault();
            return View(persona);
        }

        [HttpPost]
        public ActionResult ActualizarPersona(CoreCine.Persona persona)
        {
            //para cargar la data
            bool exito = DAPersona.ActualizarPersona(persona);
            return RedirectToAction("Index");

        }

        ///////////////////////// Eliminar Persona  
        public ActionResult EliminarPersona(int ID)
        {
            bool exito = DAPersona.EliminarPersona(ID);
            return RedirectToAction("Index");
        }
    }
}

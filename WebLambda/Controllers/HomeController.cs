using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABMDocumentos;

namespace WebLambda.Controllers
{
    public class HomeController : Controller
    {
        Firmante _firmante = new Firmante { Edad = 10, Nombre = "Carlos", Firma = "carlitos" };
        List<Firmante> listafirmante = new List<Firmante>();
        Documento _documento = new Documento { Titulo = "GRan documento", Cuerpo = "Que interesante documento" };
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertarFirmanteEnBDD()
        {
           
            return RedirectToAction("Index");
        }
        public ActionResult RealizarConsultas()
        {
            return View();
        }
        public ActionResult AdministrarBaseDeDatos()
        {
            return View();
        }
        public ActionResult CrearDocumento()
        {
            return PartialView("CrearDocumento", _documento);
        }
        public ActionResult CrearFirmante()
        {
            return PartialView("CrearFirmante", _firmante);
        }
        public ActionResult EliminarDocumento()
        {
            return PartialView("EliminarDocumento");
        }
        public ActionResult EliminarFirmante()
        {
            return PartialView("EliminarFirmante");
        }
        public ActionResult ModificarDocumento()
        {
            return PartialView("ModificarDocumento");
        }
        public ActionResult ModificarFirmante()
        {
            return PartialView("ModificarFirmante");
        }
        public ActionResult InformacionDefault()
        {
            return PartialView("InformacionDefault");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
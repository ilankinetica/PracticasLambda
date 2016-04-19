using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ABMDocumentos;
using WebLambda.Models;

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
            string mostrar = "";
            var bddManager = new BDDManager();
            mostrar += bddManager.Abrir().ToString();
            var firmante = new Firmante();
            firmante.Edad = 3;
            firmante.Firma = "def";
            firmante.Nombre = "nkldfsg";
            mostrar += bddManager.InsertarFirmante(firmante);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult insertarDocumentoEnBDD()
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
            return PartialView("Alta/CrearDocumento", listafirmante);
        }
        public ActionResult CrearFirmante()
        {
            return PartialView("Alta/CrearFirmante");
        }
        public ActionResult EliminarDocumento()
        {
            return PartialView("Baja/EliminarDocumento");
        }
        public ActionResult EliminarFirmante()
        {
            return PartialView("Baja/EliminarFirmante");
        }
        public ActionResult ModificarDocumento()
        {
            return PartialView("Modifcacion/ModificarDocumento");
        }
        public ActionResult ModificarFirmante()
        {
            return PartialView("Modificacion/ModificarFirmante");
        }
        public ActionResult DatosFirmante()
        {
            return PartialView("DatosFirmante");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLambda.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
            return PartialView("CrearDocumento");
        }
        public ActionResult CrearFirmante()
        {
            return PartialView("CrearFirmante");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLambda.Models;
using ABMDocumentos;

namespace WebLambda.Controllers
{
    public class BDDManagerTestController : Controller
    {
        // GET: BDDManagerTest
        public ActionResult Index()
        {
            string mostrar = "";
            var bddManager = new BDDManager();
            mostrar += bddManager.Abrir().ToString();
            /*var documento = new Documento();
            documento.Titulo = "abc";
            documento.Cuerpo = "def";
            mostrar += bddManager.InsertarDocumento(documento);*/
            return RedirectToAction("Home/Index");
        }
    }
}
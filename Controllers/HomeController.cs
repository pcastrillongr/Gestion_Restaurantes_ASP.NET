using MVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Empleados.Entities;
using Empleados.BL;

namespace MVC4.Controllers
{
    public class HomeController : Controller
    {
        EmpleadosBL bl = new EmpleadosBL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.name = "Pablo";
            model.location="Vilanova de Lourenza,Lugo";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
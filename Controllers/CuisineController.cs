using MVC4.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Controllers
{
    public class CuisineController : Controller
    {

        [Log]
        public ActionResult Search(string name)
        {
            var message = Server.HtmlEncode(name);
            return Content(message);
        }

        // GET: Cuisine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cuisine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuisine/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuisine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cuisine/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuisine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuisine/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

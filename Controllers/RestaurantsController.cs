using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Empleados.BL;
using Empleados.Entities;
using MVC4.Models;
using PagedList;

namespace MVC4.Controllers
{
    public class RestaurantsController : Controller
    {

        Restaurants_Db db = new Restaurants_Db();
        
        // GET: Restaurants
        public ActionResult Index(string search,int page=1)
        {


            var model = db.restaurants.ToList()
            .Where(r => search == null || r.name.StartsWith(search))
            .ToPagedList(page, 10)
            ;
                return View(model);
         
        }

        // GET: Restaurants/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Restaurant restaurant = new Restaurant();


            if (TryUpdateModel(restaurant))
            {
                db.restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            // TODO: Add insert logic here

            return View(restaurant);

        }
            
        

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int id)
        {

            Restaurant model = new Restaurant();
            model.id = id;
            foreach (Restaurant r in db.restaurants.ToList())
            {
                if (r.id == model.id)
                {
                    model = r;
                }

            }

            return View( model);
        }

        // POST: Restaurants/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Restaurant r = new Restaurant();
            Restaurant model = new Restaurant();
           
            try
            {

               if( TryUpdateModel(model)){
                    r = db.restaurants.Find(id);
                    db.Entry(r).CurrentValues.SetValues(model);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            Restaurant model = new Restaurant();
            model.id = id;
            foreach(Restaurant r in db.restaurants.ToList())
            {
                if (r.id == model.id)
                {
                    model = r;
                }

            }
            return View(model);
        }

        // POST: Restaurants/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            Restaurant model = new Restaurant();
            model.Id = id;
            try
            {
                foreach(Restaurant r in db.restaurants.ToList())
                {
                    if (r.id == model.id)
                    {
                        db.restaurants.Remove(r);
                        db.SaveChanges();

                    }
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null)
            {
                db.Dispose();  
                    }
        }
    }
}

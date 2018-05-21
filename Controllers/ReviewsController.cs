using Empleados.BL;
using MVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Empleados.Entities;
using PagedList;

using System.Web.Mvc;


namespace MVC4.Controllers
{
    public class ReviewsController : Controller
    {

        EmpleadosBL bl = new EmpleadosBL();
        Restaurants_Db db = new Restaurants_Db();

        public ActionResult BestReview()
        {

            var bestreview = db.restaurants.ToList();
            return PartialView("Review", from r in db.restaurants.ToList()

                                         select r.reviews.Max());
        }

        // GET: reviews
        
        public ActionResult Index(int id=-1,int page=1)
        {
            List<RestaurantReview> reviews = new List<RestaurantReview>();
            ViewBag.id = id;
            List<RestaurantReview> pl = new List<RestaurantReview>();
           
            foreach (RestaurantReview r in db.restaurantreview.ToList())
            {
                if (r.restaurantId == id)
                {
                    reviews.Add(r);
                }
            }

                return View(reviews.ToPagedList(page, 10));

        }

        // GET: reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: reviews/Create
        public ActionResult Create(int id)
        {
            RestaurantReview rw = new RestaurantReview();
            rw.restaurantId = id;


            return View(rw);
        }

        // POST: reviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            RestaurantReview rw = new RestaurantReview();
            try
            {
                if (TryUpdateModel(rw))
                {
                    
                    db.restaurantreview.Add(rw);
                    db.SaveChanges();                        }
                return RedirectToAction("Index","Restaurants",null);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // GET: reviews/Edit/5
        public ActionResult Edit(int id)
        {
            RestaurantReview rw = new RestaurantReview();

        
                foreach(RestaurantReview res in db.restaurantreview.ToList())
                {
                    if (res.id == id)
                    {
                        rw = res;
                    }
                }
            
                         
                        
            return View(rw);
        }

        // POST: reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            RestaurantReview rw = new RestaurantReview();
            RestaurantReview review = new RestaurantReview();

            rw.id = id;
           
            if (TryUpdateModel(rw))
            {
               
                    review = db.restaurantreview.Find(id);
                    db.Entry(review).CurrentValues.SetValues(rw);
                    db.SaveChanges();
                
                return RedirectToAction("Index", "Restaurants",null);
            }
            return View();
        }

        // GET: reviews/Delete/5
        public ActionResult Delete(int id)
        {
            RestaurantReview rw = new RestaurantReview();
                foreach (RestaurantReview res in db.restaurantreview.ToList())
                {
                    if (res.id == id)
                    {
                        rw = res;
                    }
                }
            

            return View(rw);
        }

        // POST: reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            RestaurantReview rw = new RestaurantReview();
           
            
                rw=db.restaurantreview.Find(id);
                db.restaurantreview.Remove(rw);
            db.SaveChanges();
                return RedirectToAction("Index",new { id = rw.restaurantId });
            
                     }
        }
        
    }



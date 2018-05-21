using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Empleados.Entities;

namespace MVC4.Models
{ 
    public class Restaurants_Db : DbContext
    {

       

        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<RestaurantReview> restaurantreview { get; set; }

     



    }
}
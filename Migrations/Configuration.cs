namespace MVC4.Migrations
{
    using Empleados.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC4.Models.Restaurants_Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVC4.Models.Restaurants_Db";
        }

        protected override void Seed(MVC4.Models.Restaurants_Db context)
        {
            context.restaurants.AddOrUpdate(r => r.name,
                new Restaurant
                {
                    Name = "Panchito",
                    City = "Granada",
                    Country = "Usa",
                    reviews = new List<RestaurantReview>{
                    new RestaurantReview{id=1, rating=9,body="ouuyeah" }
                }
                });
            context.SaveChanges();
        }
    }
}

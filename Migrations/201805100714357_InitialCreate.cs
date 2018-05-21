namespace MVC4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantReviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rating = c.Int(nullable: false),
                        body = c.String(maxLength: 35),
                        restaurantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Restaurants", t => t.restaurantId, cascadeDelete: true)
                .Index(t => t.restaurantId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantReviews", "restaurantId", "dbo.Restaurants");
            DropIndex("dbo.RestaurantReviews", new[] { "restaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.RestaurantReviews");
        }
    }
}

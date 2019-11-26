using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace OdeToFood.Data.Services
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<RestaurantModel> Restaurants { get; set; }
    }
}

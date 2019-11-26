using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public void Create(RestaurantModel restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Restaurants.Remove(db.Restaurants.Find(id));
            db.SaveChanges();
        }

        public IEnumerable<RestaurantModel> GetAll()
        {
            return db.Restaurants;

            //return from x in db.Restaurants
            //       orderby x.Name
            //       select x;
        }

        public RestaurantModel GetById(int id)
        {
            return db.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public void Update(RestaurantModel restaurant)
        {
            //var x = GetById(restaurant.Id);
            //x.Name = restaurant.Name;
            //x.Menu = restaurant.Menu;
            //db.SaveChanges();

            //optimistic concurrency (multiple users can edit without interfering with each other)
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

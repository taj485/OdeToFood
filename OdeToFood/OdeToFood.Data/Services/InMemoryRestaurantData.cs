using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data.Services
{
    
    public class InMemoryResturantData : IRestaurantData
    {
        List<RestaurantModel> restaurants;

        public InMemoryResturantData()
        {
            restaurants = new List<RestaurantModel>
            {
                new RestaurantModel { Id = 1, Name = "Norahs", Menu = MenuType.English },
                new RestaurantModel { Id = 2, Name = "Bombay Bites", Menu = MenuType.Indian},
                new RestaurantModel { Id = 3, Name = "Dominos", Menu = MenuType.Italian}
            };
        }

        public void Create(RestaurantModel newRestaurant)
        {
            restaurants.Add(new RestaurantModel()
            {
                Name = newRestaurant.Name,
                Menu = newRestaurant.Menu,
                Id = restaurants.Max(x => x.Id) + 1
            });
        }

        public void Delete(int id)
        {
            var deleteRestaurant = GetById(id);
            if (deleteRestaurant != null)
            {
                restaurants.Remove(deleteRestaurant);
            }
        }

        public IEnumerable<RestaurantModel> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
        }

        public RestaurantModel GetById(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public void Update(RestaurantModel restaurant)
        {
            var existing = GetById(restaurant.Id);
            if(existing != null)
            {
                existing.Name = restaurant.Name;
                existing.Menu = restaurant.Menu;
            }
        }
    }
    
}

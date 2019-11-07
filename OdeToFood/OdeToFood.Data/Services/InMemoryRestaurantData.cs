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
                new RestaurantModel { Id = 2, Name = "Bombay Bites", Menu = MenuType.Indian}
                new RestaurantModel { Id = 3, Name = "Dominos", Menu = MenuType.Italian}
            };
        }

        public IEnumerable<RestaurantModel> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
        }
    }
    
}

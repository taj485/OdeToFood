using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<RestaurantModel> GetAll();
        RestaurantModel GetById(int id);
        void Create(RestaurantModel restaurantModel);
    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MenuType Menu { get; set; }
    }
}

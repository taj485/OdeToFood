using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OdeToFood.Data.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public MenuType Menu { get; set; }
    }
}

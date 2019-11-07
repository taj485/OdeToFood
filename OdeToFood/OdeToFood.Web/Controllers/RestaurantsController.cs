using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        readonly IRestaurantData _resaurantData;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            _resaurantData = restaurantData;
        }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = _resaurantData.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _resaurantData.GetById(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(RestaurantModel newRestaurant)
        {
            if (String.IsNullOrEmpty(newRestaurant.Name))
            {
                ModelState.AddModelError(nameof(newRestaurant.Name), "The name is required");
            }

            if (ModelState.IsValid)
            {
                _resaurantData.Create(newRestaurant);
                return Redirect("Index");
            }

            return View();
        }
    }
}
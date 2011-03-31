using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoTweak.Domain;
using NoTweak.Data;
using NoTweak.Service;

namespace NoTweak.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        //
        // GET: /Restaurant/

        public ActionResult Index()
        {
            using (TweakContext tweakcontext = new TweakContext())
            {
                var Restaurants = from restaurant in tweakcontext.Restaurants
                                  select restaurant;
                return View(Restaurants.ToList<Restaurant>());
            }
        }

        //
        // GET: /Restaurant/Details/5

        public ActionResult Details(int id)
        {
            using (TweakContext tweakcontext = new TweakContext())
            {
                var Restaurant = from restaurant in tweakcontext.Restaurants
                                 where restaurant.ID == id
                                 select restaurant;
                Restaurant res = Restaurant.ToList<Restaurant>()[0];
                IList<Dish> dishes = res.Dishes.ToList<Dish>();
                return View(new RestaurantViewModel(res,dishes));
            }
        }

        //
        // GET: /Restaurant/Create

        public ActionResult Create()
        {
            Restaurant restautant = new Restaurant();
            return View(restautant);
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        public ActionResult Create(Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return View(restaurant);
            }
            restaurantService.CreateRestaurant(restaurant);
            return RedirectToAction("Index");
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            Restaurant restautant = restaurantService.GetRestaurant(id);
            return View(restautant);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var restaurant = restaurantService.GetRestaurant(id);
            if (TryUpdateModel(restaurant))
            {
                restaurantService.SaveRestaurant();
                return RedirectToAction("Index");
            }
            else return View(restaurant); 
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost]
        public ActionResult Delete(int id)
        {
            restaurantService.DeleteRestaurant(id);
            var restaurants = restaurantService.GetRestaurants();
            return PartialView("RestaurantList", restaurants);
        }

        [HttpPost]
        public ActionResult DeleteDish(int id,Dish dish)
        {
            Restaurant restaurant = restaurantService.GetRestaurant(id);
            restaurant.Dishes.Remove(dish);
            return PartialView("RestaurantDishList", restaurant.Dishes);
        }
    }
}

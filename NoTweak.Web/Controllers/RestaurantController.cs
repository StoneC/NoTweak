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
                return View(res);
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
        public ActionResult Create(FormCollection collection)
        {
            Restaurant restaurant = new Restaurant();
            try
            {
                UpdateModel(restaurant);
                restaurantService.CreateRestaurant(restaurant);
                return RedirectToAction("Details", new { id = restaurant.ID });

            }
            catch
            {
                return View(restaurant);
            }
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

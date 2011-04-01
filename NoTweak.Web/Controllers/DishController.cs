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
    public class DishController : Controller
    {

        private readonly IDishService dishService;
        private readonly IRestaurantService restaurantService;

        public DishController(IDishService dishService, IRestaurantService restaurantService)
        {
            this.dishService = dishService;
            this.restaurantService = restaurantService;
        }

        public ActionResult Index()
        {

            var Dishes = dishService.GetDishes();
            return View(Dishes.ToList<Dish>());
        }

        public ActionResult ShowDishes(IList<Dish> dishes)
        {
            return View(dishes);
        }


        //
        // GET: /Dish/Details/5

        public ActionResult Details(int id)
        {
            Dish dish = dishService.GetDish(id);

            return View(dish);
        }

        //
        // GET: /Dish/Create

        public ActionResult Create()
        {

            Dish dish = new Dish();
            return View(dish);
        }

        //
        // POST: /Dish/Create

        [HttpPost]
        public ActionResult Create(Dish dish)
        {
            if (!ModelState.IsValid)
            {
                return View(dish);
            }
            dishService.CreateDish(dish);
            return RedirectToAction("Index");
        }

        //
        // GET: /Dish/Edit/5

        public ActionResult Edit(int id)
        {
            Dish dish = dishService.GetDish(id);

            ViewData["Restaurants"] = new SelectList(restaurantService.GetRestaurants(), "ID", "Name",dish.Restaurant);
            return View(dish);
        }

        //
        // POST: /Dish/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, string source, FormCollection collection)
        {
            
            var dish = dishService.GetDish(id);
            ViewData["Restaurants"] = new SelectList(restaurantService.GetRestaurants(), "ID", "Name", dish.Restaurant);
            try
            {
                UpdateModel(dish);
                
                    dishService.SaveDish();
                    return Redirect(source);
                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            dishService.DeleteDish(id);
            var dishes = dishService.GetDishes();
            return PartialView("DishList", dishes);
        }

    }
}
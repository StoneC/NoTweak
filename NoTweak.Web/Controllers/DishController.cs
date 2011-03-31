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

        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }

        public ActionResult Index()
        {

                var Dishes = dishService.GetDishes();
                return View(Dishes.ToList<Dish>());
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
            return View(dish);
        }

        //
        // POST: /Dish/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var dish = dishService.GetDish(id);
            if (TryUpdateModel(dish))
            {
                dishService.SaveDish();
                return RedirectToAction("Index");
            }
            else return View(dish); 
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NoTweak.Domain;

namespace NoTweak.Web
{
    public class RestaurantViewModel
    {
        public RestaurantViewModel(Restaurant restaurant, IList<Dish> dishes)
        {
            Restaurant = restaurant;
            Dishes = dishes;
        }

        public Restaurant Restaurant { get; set; }
        public IList<Dish> Dishes { get; set; }
    }
}
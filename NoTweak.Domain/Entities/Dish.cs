using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoTweak.Domain
{
    public class Dish
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
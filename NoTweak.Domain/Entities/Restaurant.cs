using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoTweak.Domain
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Desc { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }


    }
}
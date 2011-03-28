using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NoTweak.Web.Models
{
    public class TweakContext:DbContext
    {
        public TweakContext()
            : base("TweakConnectionString")
        {
           
        }

        public DbSet<Eater> Eaters { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Dinner> Dinners { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}
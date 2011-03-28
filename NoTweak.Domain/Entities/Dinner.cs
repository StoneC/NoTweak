using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoTweak.Domain
{
    public class Dinner
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Eater> Eaters { get; set; }
        public DinnerStatus Status { get; set; }
        public string Log { get; set; }
       
    }

    public enum DinnerStatus
    {
        New,Approved,Canceled,Done
    }
}
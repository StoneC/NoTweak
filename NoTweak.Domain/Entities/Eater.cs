using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoTweak.Domain
{
    public class Eater
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string BIO { get; set; }
        public int Status { get; set; }
    }
}
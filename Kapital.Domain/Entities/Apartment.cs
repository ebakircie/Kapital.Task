using Kapital.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Domain.Entities
{
    public class Apartment:IBase
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string zip_code { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public int latitude { get; set; }
        public int longtitude { get; set; }
        public string direction { get; set; }
        public bool booked { get; set; }
    }
}

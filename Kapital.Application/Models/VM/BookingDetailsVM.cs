using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Application.Models.VM
{
    public class BookingDetailsVM
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string apartment_name { get; set; }
        public string address { get; set; }
        public string zip_code { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string starts_at { get; set; }
        public string finishes_at { get; set; }
        public int booked_for { get; set; }
        public int confirmed { get; set; }

    }
}

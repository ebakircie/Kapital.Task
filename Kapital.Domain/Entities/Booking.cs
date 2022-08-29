using Kapital.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Domain.Entities
{
    public class Booking:IBase
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string starts_at { get; set; }
        public string booked_at { get; set; }
        public int booked_for { get; set; }
        public int apartment_id { get; set; }
        public int confirmed { get; set; }
    }
}

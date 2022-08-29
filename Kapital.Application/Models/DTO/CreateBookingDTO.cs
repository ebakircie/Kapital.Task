using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Application.Models.DTO
{
    public class CreateBookingDTO
    {
        public int user_id { get; set; }
        public int booked_for { get; set; }
        public int apartment_id { get; set; }
        public int confirmed { get; set; }

    }
}

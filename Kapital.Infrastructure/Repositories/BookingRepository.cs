using Kapital.Domain.Entities;
using Kapital.Domain.Entities.Dummy;
using Kapital.Domain.Repositories;
using Kapital.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Infrastructure.Repositories
{
    public class BookingRepository : BaseRepository<Booking>,IBookingRepository
    {
        private readonly KapitalContext _kapitalContext;
        public BookingRepository(KapitalContext kapitalContext) : base(kapitalContext)
        {
            _kapitalContext = kapitalContext;
        }
        public List<FilteredList> GetFilteredBookingDetails(string? name, string? lastname, string? apartmentName, int? confirmed)
        {
            var query = (from booking in _kapitalContext.bookings
                         join apartment in _kapitalContext.appartments on booking.apartment_id equals apartment.id
                         join user in _kapitalContext.users on booking.user_id equals user.id
                         select new FilteredList
                         {
                             first_name = user.first_name,
                             last_name = user.last_name,
                             email = user.email,
                             phone = user.phone,
                             apartment_name = apartment.name,
                             address = apartment.address,
                             zip_code = apartment.zip_code,
                             city = apartment.city,
                             country = apartment.country,
                             starts_at = DateTime.Parse(booking.starts_at).ToShortDateString(),
                             finishes_at = DateTime.Parse(booking.starts_at).AddDays(booking.booked_for).ToShortDateString(),
                             booked_for = booking.booked_for,
                             confirmed = booking.confirmed
                         }).ToList();

            if (name != null)
            {
                query = query.Where(x => x.first_name == name).ToList();
            }
            if (lastname != null)
            {
                query = query.Where(x => x.last_name == lastname).ToList();
            }
            if (apartmentName != null)
            {
                query = query.Where(x => x.apartment_name.Contains(apartmentName)).ToList();
            }
            if (confirmed != null)
            {
                query = query.Where(x => x.confirmed == confirmed).ToList();
            }
            return query.ToList();
        }
        public int GetLastId()
        {
            var query = Table.AsQueryable();
            return query.Max(x => x.id);
        }
    }
}

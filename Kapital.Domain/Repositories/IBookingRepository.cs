using Kapital.Domain.Entities;
using Kapital.Domain.Entities.Dummy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Domain.Repositories
{
    public interface IBookingRepository:IBaseRepository<Booking>
    {
        public int GetLastId();

        List<FilteredList> GetFilteredBookingDetails(string? name, string? lastname, string? apartmentName, int? confirmed);
    }
}

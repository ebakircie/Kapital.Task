
using Kapital.Application.Models.DTO;
using Kapital.Application.Models.VM;
using Kapital.Domain.Entities.Dummy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Application.Services.BookingServices
{
    public interface IBookingService
    {
        Task Create(CreateBookingDTO model);
        Task Update(UpdateBookingDTO model);
        Task<bool> Delete(int id);

        Task<List<BookingVM>> GetAll();

        Task<BookingVM> GetById(int id);

        int GetLastId();
        List<FilteredList> GetFilteredBookingDetails(string? name, string? lastname, string? apartmentName, int? confirmed);
    }
}

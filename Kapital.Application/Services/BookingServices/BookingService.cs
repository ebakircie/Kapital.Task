using AutoMapper;
using Kapital.Application.Models.DTO;
using Kapital.Application.Models.VM;
using Kapital.Domain.Entities;
using Kapital.Domain.Entities.Dummy;
using Kapital.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Application.Services.BookingServices
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public Task Create(CreateBookingDTO model)
        {
            var booking = _mapper.Map<Booking>(model);
            booking.id = GetLastId();
            booking.starts_at = DateTime.Now.ToString();
            booking.booked_at = DateTime.Now.ToString();
            return _bookingRepository.Create(booking);

        }

        public async Task<bool> Delete(int id)
        {
            var model = await GetById(id);
            var booking = _mapper.Map<Booking>(model);
            if (booking.confirmed == 0)
            {
                _bookingRepository.Delete(booking);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<List<BookingVM>> GetAll()
        {
            var bookings = _bookingRepository.GetFilteredList(
                select: x => new BookingVM
                {
                    id = x.id,
                    user_id = x.user_id,
                    starts_at = x.starts_at,
                    booked_at = x.booked_at,
                    booked_for = x.booked_for,
                    apartment_id = x.apartment_id,
                    confirmed = x.confirmed
                });
            return bookings;
        }

        public Task<BookingVM> GetById(int id)
        {
            var booking = _bookingRepository.GetFilteredFirstOrDefault(
                select: x => new BookingVM
                {
                    id = x.id,
                    user_id = x.user_id,
                    starts_at = x.starts_at,
                    booked_at = x.booked_at,
                    booked_for = x.booked_for,
                    apartment_id = x.apartment_id,
                    confirmed = x.confirmed
                }, where: x => x.id == id
                );
            return booking;
        }

        //TODO: Database'de sorun olduğu için create yaparken Id'yi son id'nin bir fazlası olacak şekilde otomatize edilmiştir.
        public int GetLastId()
        {
            var bookingId = _bookingRepository.GetLastId() + 1;
            return bookingId;
        }

        public async Task Update(UpdateBookingDTO model)
        { 
            var booking = _mapper.Map<Booking>(model);
            booking.starts_at = DateTime.Now.ToString();
            booking.booked_at = DateTime.Now.ToString();
            await _bookingRepository.Update(booking);
        }
        public List<FilteredList> GetFilteredBookingDetails(string? name, string? lastname, string? apartmentName, int? confirmed)
        {
            var list = _bookingRepository.GetFilteredBookingDetails(name, lastname, apartmentName, confirmed);
            return (list);
         
        }

    }
}
 
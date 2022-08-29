using AutoMapper;
using Kapital.Application.Models.DTO;
using Kapital.Application.Models.VM;
using Kapital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Application.Automapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Booking, BookingVM>().ReverseMap();
            CreateMap<Booking, CreateBookingDTO>().ReverseMap();
            CreateMap<Booking, UpdateBookingDTO>().ReverseMap();

        }
    }
}

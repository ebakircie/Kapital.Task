using Kapital.Application.Models.DTO;
using Kapital.Application.Services.BookingServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Kapital.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookingService.GetAll();
            return Ok(result);

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var process = await _bookingService.Delete(id);
            if (process == true)
            {
                return Ok("Booking is deleted successfully"); 
            }
            else
            {
                return BadRequest("Booking is confirmed!");
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateBookingDTO model)
        {
            await _bookingService.Create(model);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateBookingDTO model)
        {
            await _bookingService.Update(model);
            return Ok(); 
        }

        //TODO: Filtre verilmediği takdirde bütün datayı getirir, aski halde filtreye göre datayı getirir ve birden fazla filtre uygulanabilir.
        [HttpGet("FilteredResult")]
        public IActionResult GetFilteredResult (string? name, string? lastname, string? apartmentName, int? confirmed)
        {
            var result =  _bookingService.GetFilteredBookingDetails(name, lastname, apartmentName, confirmed);

            if (result!= null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
           return Ok( await _bookingService.GetById(id));
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using HotelApp.Models;
using HotelApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IBookingManager _bookingManager;

        // INSTANTIATE SINGLETON SERVICE IN CONTROLLER
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            return _bookingManager.GetAllBookings();
        }
        [HttpPost]
        public ActionResult<string> Post([FromBody] Booking booking)
        {
            bool isAvaialble = _bookingManager.IsRoomAvailable(booking.Room, booking.Date);
            if (isAvaialble)
            {
                try
                {
                    _bookingManager.AddBooking(booking.Guest, booking.Room, booking.Date);
                    return Ok();
                } // Send error to FE for user friendly message like Failed to Save
                catch(Exception e)
                {
                    return StatusCode(500, e);
                }

            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}

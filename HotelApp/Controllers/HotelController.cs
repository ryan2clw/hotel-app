using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using HotelApp.Models;
using HotelApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;

        // INSTANTIATE SINGLETON SERVICE IN CONTROLLER
        public HotelController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }
        [HttpGet("GetAvailableRooms")]
        public IEnumerable<int> GetAvailableRooms(DateTime? date)
        {
            return _bookingManager.GetAvailableRooms(date ?? DateTime.Now);
        }
        [HttpGet("IsRoomAvailable")]
        public bool IsRoomAvailable(int RoomNumber, DateTime date)
        {
            return _bookingManager.IsRoomAvailable(RoomNumber, date);
        }
        [HttpPost("AddBooking")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> Post([FromBody] RoomRequest roomRequest)
        {
            bool isAvaialble = _bookingManager.IsRoomAvailable(roomRequest.RoomNumber, roomRequest.Date);
            if (isAvaialble)
            {
                try
                {
                    await _bookingManager.AddBooking(roomRequest.Guest, roomRequest.RoomNumber, roomRequest.Date);
                    return Ok();
                } // Send error to FE for user friendly message like Failed to Save
                catch(Exception e)
                {
                    return BadRequest(e);
                }

            }
            else
            {
                return BadRequest();
            }
        }
    }
}

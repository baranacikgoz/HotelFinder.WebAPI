using HotelFinder.Businness.Abstract;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        /// <summary>
        /// Get All Hotels.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllHotels()
        {
            List<Hotel> hotels = await _hotelService.GetAllHotels();
            return Ok(hotels); // 200 + hotels
        }

        /// <summary>
        /// Get Hotel by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            Hotel hotel = await _hotelService.GetHotelById(id);

            if(hotel == null)
            {
                return NotFound();// 404. Not found.
            }

            return Ok(hotel); // 200.
        }

        /// <summary>
        /// Get Hotel by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            Hotel hotel = await _hotelService.GetHotelByName(name);

            if(hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        /// <summary>
        /// Post a new Hotel.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {
            Hotel createdHotel = await _hotelService.CreateHotel(hotel);
            return CreatedAtAction(nameof(GetHotelById), new {id = createdHotel.Id}, createdHotel);
        }

        /// <summary>
        /// Update an Hotel.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            Hotel hotelToUpdate = await _hotelService.GetHotelById(hotel.Id);

            if(hotelToUpdate == null)
            {
                return NotFound();   
            }

            return Ok(_hotelService.UpdateHotel(hotel));
            
        }

        /// <summary>
        /// Delete an Hotel by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteHotelById(int id)
        {
            Hotel hotelToDelete = await _hotelService.GetHotelById(id);

            if (hotelToDelete == null)
            {
                return NotFound();
            }

            return Ok(_hotelService.DeleteHotel(id));
        }
    }
}

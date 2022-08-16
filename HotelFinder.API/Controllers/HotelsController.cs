using HotelFinder.Businness.Abstract;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult GetAllHotels()
        {
            List<Hotel> hotels = _hotelService.GetAllHotels();
            return Ok(hotels); // 200 + hotels
        }

        /// <summary>
        /// Get Hotel by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelById(int id)
        {
            Hotel hotel = _hotelService.GetHotelById(id);

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
        [Route("[action]/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            //Hotel hotel = _hotelService.GetHotelById(id);

            //if (hotel == null)
            //{
            //    return NotFound();// 404. Not found.
            //}

            return Ok(); // 200.
        }

        /// <summary>
        /// Post a new Hotel.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]Hotel hotel)
        {
            return CreatedAtAction("Get", new {id = hotel.Id}, hotel);
        }

        /// <summary>
        /// Update an Hotel.
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            Hotel hotelToUpdate = _hotelService.GetHotelById(hotel.Id);

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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Hotel hotelToDelete = _hotelService.GetHotelById(id);

            if (hotelToDelete == null)
            {
                return NotFound();
            }

            return Ok(_hotelService.DeleteHotel(id));
        }
    }
}

using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {

        public async Task<List<Hotel>> GetAllHotels()
        {
            using var _hotelDbContext = new HotelDbContext();
            return await _hotelDbContext.Hotels.ToListAsync();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            using var _hotelDbContext = new HotelDbContext();
            return await _hotelDbContext.Hotels.FindAsync(id);
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            using var _hotelDbContext = new HotelDbContext();
            return await _hotelDbContext.Hotels.FirstOrDefaultAsync(hotel=> hotel.Name.ToLower().Equals(name.ToLower()));
        }
        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            using var _hotelDbContext = new HotelDbContext();
            _hotelDbContext.Hotels.Add(hotel);
            await _hotelDbContext.SaveChangesAsync();

            return hotel;
        }

        public async Task<Hotel> DeleteHotel(int id)
        {
            using var _hotelDbContext = new HotelDbContext();
            Hotel hotelToDelete = await GetHotelById(id);
            _hotelDbContext.Remove(hotelToDelete);
            await _hotelDbContext.SaveChangesAsync();
            return hotelToDelete;
        }
        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            using var _hotelDbContext = new HotelDbContext();
            _hotelDbContext.Hotels.Update(hotel);
            await _hotelDbContext.SaveChangesAsync();
            return hotel;
        }

        
    }
}

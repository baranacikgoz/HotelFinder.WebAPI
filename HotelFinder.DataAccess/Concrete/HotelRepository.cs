using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {

        public List<Hotel> GetAllHotels()
        {
            using var _hotelDbContext = new HotelDbContext();
            return _hotelDbContext.Hotels.ToList();
        }

        public Hotel GetHotelById(int id)
        {
            using var _hotelDbContext = new HotelDbContext();
            return _hotelDbContext.Hotels.Find(id);
        }
        public Hotel CreateHotel(Hotel hotel)
        {
            using var _hotelDbContext = new HotelDbContext();
            _hotelDbContext.Hotels.Add(hotel);
            _hotelDbContext.SaveChanges();

            return hotel;
        }

        public Hotel DeleteHotel(int id)
        {
            using var _hotelDbContext = new HotelDbContext();
            Hotel hotelToDelete = GetHotelById(id);
            _hotelDbContext.Remove(hotelToDelete);
            _hotelDbContext.SaveChanges();
            return hotelToDelete;
        }
        public Hotel UpdateHotel(Hotel hotel)
        {
            using var _hotelDbContext = new HotelDbContext();
            _hotelDbContext.Hotels.Update(hotel);
            _hotelDbContext.SaveChanges();
            return hotel;
        }
    }
}

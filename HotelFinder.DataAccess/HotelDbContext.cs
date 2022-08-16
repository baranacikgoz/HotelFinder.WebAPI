using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Database=HotelFinderDB;User Id=postgres;Password=asd;Server=127.0.0.1;Port=5432;");
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}

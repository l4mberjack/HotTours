using Entities;
using Microsoft.EntityFrameworkCore;

namespace HotTourRegister.Context
{
    /// <summary>
    /// Контекст базы данных туров
    /// </summary>
    public class TourContext : DbContext
    {
        public DbSet<Tour> Tours { get; set; } = null!;
        public TourContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}

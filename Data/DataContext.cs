using DeviceManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagerAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<Devices> Devices { get; set; }
        public DbSet<Users> Users { get; set; }


    }
}

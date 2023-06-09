using DeviceManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagerAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<User> Users { get; set; }


    }
}

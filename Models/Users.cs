using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.Models
{
    public class Users
    {
        [Key] public int UserId { get; set; }
        
        public string Name { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public ICollection<Devices> Devices { get; set; }
    }
}

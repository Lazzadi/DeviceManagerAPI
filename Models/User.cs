using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.Models
{
    public class User
    {
        [Key] public int UserId { get; set; }
        
        public string Name { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        
    }
}

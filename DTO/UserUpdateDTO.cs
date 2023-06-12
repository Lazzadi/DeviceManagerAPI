using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.DTO
{
    public class UserUpdateDTO
    {
        [Key] public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }

    }
}

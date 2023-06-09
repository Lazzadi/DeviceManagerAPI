using DeviceManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.DTO
{
    public class RegisterUserDTO
    {

        public string Name { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }

    }
}

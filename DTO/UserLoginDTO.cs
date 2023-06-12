using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.DTO
{
    public class UserLoginDTO
    {
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
    }
}

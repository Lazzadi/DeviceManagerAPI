using DeviceManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.DTO
{
    public class DevicesDTO
    {
        [Key] public int DeviceId { get; set; }

        //public int? UserID { get; set; } do we want the user ID to be shown?
        public Users? User { get; set; }

        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string type { get; set; }
        public string OperatingSystem { get; set; }
        public string OSVersion { get; set; }
        public string Processor { get; set; }
        public int RAMAmount { get; set; }

    }
}

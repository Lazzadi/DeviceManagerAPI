using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.Models
{
    public class Devices
    {
        [Key] public int DeviceId { get; set; }
        
        public Users User { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string OperatingSystem { get; set; }
        public string OSVersion{ get; set; }
        public string Processor { get; set; }
        public int RAMAmount { get; set; }


    }
}

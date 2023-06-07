namespace DeviceManagerAPI.Models
{
    public class Devices
    {
        public int DeviceId { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string OperatingSystem { get; set; }
        public string OSVersion{ get; set; }
        public string Processor { get; set; }
        public int RAMAmount { get; set; }
    }
}

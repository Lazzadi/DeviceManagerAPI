﻿using DeviceManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.DTO
{
    public class CreateDeviceDTO
    {


        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string type { get; set; }
        public string OperatingSystem { get; set; }
        public string OSVersion { get; set; }
        public string Processor { get; set; }
        public int RAMAmount { get; set; }

    }
}

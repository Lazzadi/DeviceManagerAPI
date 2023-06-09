﻿using DeviceManagerAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DeviceManagerAPI.DTO
{
    public class UsersDTO
    {
        [Key] public int UserId { get; set; }

        public string Name { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }

        public ICollection<Devices> Devices { get; set; }
    }
}

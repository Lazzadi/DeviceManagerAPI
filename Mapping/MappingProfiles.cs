using AutoMapper;
using DeviceManagerAPI.DTO;
using DeviceManagerAPI.Models;

namespace DeviceManagerAPI.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Device, DeviceDTO>();
        }
    }
}

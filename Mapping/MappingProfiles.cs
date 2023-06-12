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
            CreateMap<Device, CreateDeviceDTO>();
            CreateMap<CreateDeviceDTO, Device>();
            CreateMap<Device, UpdateDeviceDTO>();
            CreateMap<UpdateDeviceDTO, Device>();
            CreateMap<User, RegisterUserDTO>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<UserLoginDTO, User>();
        }
    }
}

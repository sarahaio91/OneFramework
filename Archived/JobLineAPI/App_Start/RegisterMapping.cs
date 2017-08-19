using AutoMapper;
using Contract.BUS.Dtos;
using Contract.DAL.Entities;
using JobLineAPI.Models;

namespace JobLineAPI
{
    public static class RegisterMapping
    {
        public static void Register()
        {
            Mapper.Initialize(cfg => {
                // Presentation Mapper
                cfg.CreateMap<BaseModel, BaseDto>().ReverseMap();
                cfg.CreateMap<UserModel, UserDto>().ReverseMap();
                cfg.CreateMap<UserProfileModel, UserProfileDto>().ReverseMap();
                cfg.CreateMap<RoleModel, RoleDto>().ReverseMap();

                // BUS Mapper
                cfg.CreateMap<BaseEntity, BaseDto>().ReverseMap();
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
                cfg.CreateMap<Role, RoleDto>().ReverseMap();
            });
        }
    }
}
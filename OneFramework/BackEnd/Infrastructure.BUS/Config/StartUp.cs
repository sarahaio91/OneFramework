using AutoMapper.Configuration;
using Domain.Data;
using Domain.Dtos;
using Domain.Dtos.Account;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Application.Config
{
    public static class StartUp
    {
        public static void ConfigureServices(
            this IServiceCollection services, 
            IConfiguration configuration,
            MapperConfigurationExpression mapperConfig)
        {
            services.AddDbContext<OneDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<OneDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<OneDbContextAbstract, OneDbContext>();

            mapperConfig.CreateMap<SignInResultDto, SignInResult>().ReverseMap();
            mapperConfig.CreateMap<BaseEntity, BaseDto>().ReverseMap();
            mapperConfig.CreateMap<User, UserDto>().ReverseMap();
            mapperConfig.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            mapperConfig.CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}

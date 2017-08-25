using AutoMapper.Configuration;
using Contract.BUS.Dtos;
using Contract.DAL.Data;
using Contract.DAL.Entities;
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
            services.AddDbContext<JobLineDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<JobLineDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<JobLineDbContextAbstract, JobLineDbContext>();

            mapperConfig.CreateMap<SignInResultDto, SignInResult>().ReverseMap();
            mapperConfig.CreateMap<BaseEntity, BaseDto>().ReverseMap();
            mapperConfig.CreateMap<User, UserDto>().ReverseMap();
            mapperConfig.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            mapperConfig.CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}

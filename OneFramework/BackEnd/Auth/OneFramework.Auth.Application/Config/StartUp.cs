using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneFramework.Auth.Domain.Data;
using OneFramework.Auth.Domain.Dtos;
using OneFramework.Auth.Domain.Dtos.Account;
using OneFramework.Auth.Domain.Entities;
using OneFramework.Auth.Domain.Entities.User;
using OneFramework.Auth.Infrastructure.Data;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OneFramework.Auth.Application.Config
{
    public static class StartUp
    {
        public static void ConfigureServices(
            this IServiceCollection services, 
            IConfiguration configuration,
            MapperConfigurationExpression mapperConfig)
        {
            services.AddDbContext<AuthDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<AuthDbContextAbstract, AuthDbContext>();

            mapperConfig.CreateMap<SignInResultDto, SignInResult>().ReverseMap();
            mapperConfig.CreateMap<BaseEntity, BaseDto>().ReverseMap();
            mapperConfig.CreateMap<User, UserDto>().ReverseMap();
            mapperConfig.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            mapperConfig.CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}

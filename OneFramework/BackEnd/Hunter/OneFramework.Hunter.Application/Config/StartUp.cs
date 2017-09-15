using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OneFramework.Hunter.Domain.Data;
using OneFramework.Hunter.Domain.Dtos;
using OneFramework.Hunter.Domain.Dtos.Account;
using OneFramework.Hunter.Domain.Entities;
using OneFramework.Hunter.Domain.Entities.User;
using OneFramework.Hunter.Infrastructure.Data;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OneFramework.Hunter.Application.Config
{
    public static class StartUp
    {
        public static void ConfigureServices(
            this IServiceCollection services, 
            IConfiguration configuration,
            MapperConfigurationExpression mapperConfig)
        {
            services.AddDbContext<HunterDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<HunterDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<HunterDbContextAbstract, HunterDbContext>();

            mapperConfig.CreateMap<SignInResultDto, SignInResult>().ReverseMap();
            mapperConfig.CreateMap<BaseEntity, BaseDto>().ReverseMap();
            mapperConfig.CreateMap<User, UserDto>().ReverseMap();
            mapperConfig.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            mapperConfig.CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}

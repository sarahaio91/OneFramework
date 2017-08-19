using AutoMapper;
using Contract.BUS.Dtos;
using Contract.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // AutoMapper
            Mapper.Initialize(cfg =>
            {
                // Presentation Mapper
                cfg.CreateMap<LoginModel, LoginDto>().ReverseMap();

                // BUS Mapper
                cfg.CreateMap<SignInResultDto, SignInResult>().ReverseMap();
                cfg.CreateMap<BaseEntity, BaseDto>().ReverseMap();
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<UserProfile, UserProfileDto>().ReverseMap();
                cfg.CreateMap<Role, RoleDto>().ReverseMap();
            });

            // Enable Accept CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:3000"));
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "api",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Ping", action = "Get" }
                );
            });
        }
    }
}

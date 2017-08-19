using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Core.Contract.DAL.DbContext;
using Core.Infrastructure.DAL.Repositories;
using Core.Contract.DAL.Repositories;
using Core.Contract.BUS.BusinessLogics;
using Core.Infrastructure.BUS.BusinessLogics;
using Core.Contract.DAL.Entities;
using AutoMapper;
using Core.Contract.BUS.Dtos;
using JobLineCoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JobLineCoreAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.AddSingleton<Microsoft.Extensions.Configuration.IConfiguration>(sp => { return Configuration; });

            // DB Context
            
            services.AddDbContext<JobLineDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbContext, JobLineDbContext>();

            // Repository
            services.AddScoped<IRepository<Role>, BaseRepository<Role>>();
            services.AddScoped<IRepository<User>, BaseRepository<User>>();
            services.AddScoped<IRepository<UserProfile>, BaseRepository<UserProfile>>();

            // Business Logic
            services.AddScoped<IUserService, UserService>();

            // Enable Accept CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:3000"));
            });

            // AutoMapper
            Mapper.Initialize(cfg =>
            {
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("AllowSpecificOrigin");
            app.UseStaticFiles();

            //app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("en-AU"),
                new CultureInfo("en-GB"),
                new CultureInfo("en"),
                new CultureInfo("es-ES"),
                new CultureInfo("es-MX"),
                new CultureInfo("es"),
                new CultureInfo("fr-FR"),
                new CultureInfo("fr"),
                new CultureInfo("ja-JP"),
                new CultureInfo("ja"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseMvc(routes =>
            {
				routes.MapRoute(
					name: "api",
					template: "{controller}/{action}/{id?}",
					defaults: new { controller = "Ping", action="Get"}
                );
                //routes.MapRoute(
                    //name: "mvc",
                    //template: "{controller}/{action}/{id?}");
            });

            //app.UseMvc();
        }
    }
}

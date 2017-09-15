﻿using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OneFramework.Hunter.Application.Config;
using OneFramework.Hunter.Application.Services;
using OneFramework.Hunter.Domain.Dtos.Account;
using OneFramework.Hunter.Domain.Services;
using OneFramework.Hunter.Web.Models.AccountViewModels;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace OneFramework.Auth.Web
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
            var mapperConfig = new MapperConfigurationExpression();

            // Application Tier config
            services.ConfigureServices(Configuration, mapperConfig);

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            // Custom services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IUserService, UserService>();

            // AutoMapper
            mapperConfig.CreateMap<LoginViewModel, LoginDto>().ReverseMap();
            Mapper.Initialize(mapperConfig);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
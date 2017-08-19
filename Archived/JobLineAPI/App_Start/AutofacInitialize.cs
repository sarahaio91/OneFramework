using System.Web.Configuration;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Contract.BUS.BusinessLogics;
using Contract.DAL.DbContext;
using Contract.DAL.Entities;
using Contract.DAL.Repositories;
using Infrastructure.BUS.BusinessLogics;
using Infrastructure.DAL.DbContext;
using Infrastructure.DAL.Repositories;

namespace JobLineAPI
{
    public static class AutofacInitialize
    {
        public static void InitializeIoc()
        {
            var connectString = WebConfigurationManager.ConnectionStrings["JobLineDb"].ConnectionString;

            var builder = new ContainerBuilder();

            // Presentation Register
            builder.RegisterApiControllers(typeof (WebApiApplication).Assembly);

            // BUS Register
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();

            // DAL Register
            builder.Register(c => new JobLineDbContext(connectString)).
                As<IDbContext>().InstancePerRequest();
            builder.RegisterType<BaseRepository<Role>>().
                As<IRepository<Role>>().InstancePerRequest();
            builder.RegisterType<BaseRepository<User>>().
                As<IRepository<User>>().InstancePerRequest();
            builder.RegisterType<BaseRepository<UserProfile>>().
                As<IRepository<UserProfile>>().InstancePerRequest();

            var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver((IContainer) container);
        }
    }
}
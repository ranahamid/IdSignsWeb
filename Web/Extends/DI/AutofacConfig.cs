using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Autofac.Features.ResolveAnything;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Extras.NLog;
using Infrastructure.Data;
using Web.Extends.DI;
using Infrastructure.Data.Repositories;

namespace WebRTC.Extends.DI
{
    /// <summary>
    /// 
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Initialize(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AppDbContext>()
                   .AsSelf()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CompanyRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterType<UserDTORepository>().PropertiesAutowired();

            //builder.RegisterAssemblyTypes(typeof(AwsS3Service).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterModule<NLogModule>();

            // Validators
            //builder.RegisterModule<ValidationModule>();

            // Automapper
            builder.RegisterModule<AutoMapperModule>();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            // Register filters
            builder.RegisterFilterProvider();
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }        
    }
}
using Autofac;
using FluentValidation;
using FluentValidation.Mvc;
using System.Linq;
using System.Web.ModelBinding;

namespace Web.Extends.DI
{
    /// <summary>
    /// ValidationModule
    /// </summary>
    public class ValidationModule : Module
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("Validator"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<FluentValidationModelValidatorProvider>().As<ModelValidatorProvider>();

            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

            base.Load(builder);
        }
    }
}
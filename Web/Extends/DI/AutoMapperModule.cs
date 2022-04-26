using Autofac;
using AutoMapper;
using Web.Mappings;

namespace Web.Extends.DI
{
    /// <summary>
    /// AutoMapperModule
    /// </summary>
    public class AutoMapperModule : Module
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<DomainToViewModelMappingProfile>();
                    cfg.AddProfile<ViewModelToDomainMappingProfile>();
                });

                return config;
            })
            .SingleInstance()
            .AutoActivate()
            .AsSelf();

            builder.Register(tempContext =>
            {
                var ctx = tempContext.Resolve<IComponentContext>();
                var config = ctx.Resolve<MapperConfiguration>();

                // Create our mapper using our configuration above
                return config.CreateMapper();
            }).As<IMapper>();

            base.Load(builder);
        }
    }
}
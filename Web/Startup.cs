using Autofac;
using Autofac.Features.ResolveAnything;
using Autofac.Integration.Mvc;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Mvc;
using Web.Extends.DI;
using Autofac.Extras.NLog;
using System.Web.Http;
using System.Configuration;
using Core;
using Autofac.Integration.WebApi;
using System.Web.Http.ExceptionHandling;
using Web.Extends.Handlers;
using System.Web.Http.Cors;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web
{
    /// <summary>
    /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configure App
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

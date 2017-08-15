using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using PrestacapTask3.Interfaces;
using PrestacapTask3.Services;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PrestacapTask3
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			ConfigureIoC();
		}

		private static void ConfigureIoC()
		{
			var builder = new ContainerBuilder();
			var config = GlobalConfiguration.Configuration;

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
			builder.RegisterType<HotelRatesServices>().As<IHotelRatesServices>();

			var container = builder.Build();
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}

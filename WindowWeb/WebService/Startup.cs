using System.Web.Http;
using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(WindowWeb.WebService.Startup))]
namespace WindowWeb.WebService
{

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "createUserApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Add(new BrowserJsonFormatter());
            appBuilder.UseWebApi(config);
        }
    }
}
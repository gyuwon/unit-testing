using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace HelloWorld
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }

        private static void Main(string[] args)
        {
            var address = "http://localhost:9000";
            using (WebApp.Start<Startup>(url: address))
            {
                Console.WriteLine("Listening on '{0}'...", address);
                Console.WriteLine("Press Enter key to quit");
                Console.ReadLine();
            }
        }
    }
}

using System;
using System.Linq;
using System.Web.Http;
using ContentNegotiation.Controllers;

namespace ContentNegotiation
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var headerValues = GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.ToArray();
            GlobalConfiguration.Configuration.Formatters.Add(new FooFormatter());
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
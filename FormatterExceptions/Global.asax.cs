using System;
using System.Web.Http;

namespace FormatterExceptions
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var supportedMediaTypes = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SupportedMediaTypes;
            GlobalConfiguration.Configuration.Formatters.Add(new FooFormatter());
            GlobalConfiguration.Configuration.Formatters.Add(new HttpErrorFormatter());
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.JsonFormatter);
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            GlobalConfiguration.Configuration.MapHttpAttributeRoutes();
            GlobalConfiguration.Configuration.EnsureInitialized();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EmployeeAppAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        protected void Application_BeginRequest()
        {
            //if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            //{
            //    var origin = HttpContext.Current.Request.Headers["Origin"];

            //    Response.Headers.Add("Access-Control-Allow-Origin", origin);
            //    Response.Headers.Add("Access-Control-Allow-Headers", "content-type, withcredentials, Access-Control-Allow-Headers, Origin,Accept, X-Requested-With, Content-Type, Access-Control-Request-Method, Access-Control-Request-Headers");
            //    Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            //    Response.Headers.Add("Access-Control-Allow-Methods", "GET, HEAD, OPTIONS, POST, PUT");

            //    Response.Flush();
            //}
        }
    }
}

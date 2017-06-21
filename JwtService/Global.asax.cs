using System.Web;
using System.Web.Http;

namespace JwtService
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(FilterConfig.Configure);
        }
    }
}

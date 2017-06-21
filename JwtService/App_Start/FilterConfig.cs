using System.Web.Http;

namespace JwtService
{
    public class FilterConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config.Filters.Add(new AuthorizeAttribute());
        }
    }
}
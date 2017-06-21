using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JwtService.Startup))]

namespace JwtService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
        }
    }
}
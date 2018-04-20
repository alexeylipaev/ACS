using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACSWeb.Startup))]
namespace ACSWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

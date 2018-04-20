using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACSDinamikaWeb.Startup))]
namespace ACSDinamikaWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

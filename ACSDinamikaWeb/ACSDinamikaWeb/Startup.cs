using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ACSWeb.Startup))]
namespace ACSWeb
{
    /*
     Startup.cs: поскольку в приложении MVC 5 используются библиотеки, применяющие спецификацию OWIN, 
     то данный файл организует связь между OWIN и приложением. 
     (OWIN представляет спецификацию, описывающую взаимодействие между компонентами приложения)
         */
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

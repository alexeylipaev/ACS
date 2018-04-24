using Ninject.Modules;
using NLayerApp.BLL.Services;
using NLayerApp.BLL.Interfaces;

namespace NLayerApp.WEB.Util
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOrderService>().To<OrderService>();
        }
    }
}
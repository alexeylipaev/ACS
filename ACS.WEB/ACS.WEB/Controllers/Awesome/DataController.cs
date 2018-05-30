using ACS.BLL.Interfaces;
using Omu.AwesomeMvc;
using System.Linq;
using System.Web.Mvc;

namespace ACS.WEB.Controllers.Awesome
{
    public class DataController : Controller
    {
        IChancelleryService ChancelleryService;

        public DataController(IChancelleryService chancelleryService)
        {
            ChancelleryService = chancelleryService;
        }

        public ActionResult GetAllResponsibles()
        {
            //var items = Db.Meals.Select(o => new KeyContent(o.Id, o.Name));
            //return Json(items);
            var items = ChancelleryService.GetEmployees().Select(o => new KeyContent(o.id, o.LName+" "+o.FName+" "+ o.MName));
            return Json(items);

        }
    }
}
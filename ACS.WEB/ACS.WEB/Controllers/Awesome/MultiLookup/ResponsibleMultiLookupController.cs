using System.Linq;
using System.Web.Mvc;
using Omu.AwesomeMvc;
using ACS.BLL.Interfaces;
using ACS.BLL.DTO;

namespace ACS.WEB.Controllers.Awesome.MultiLookup
{
    public class ResponsibleMultiLookupController : Controller
    {
        IChancelleryService ChancelleryService;

        public ResponsibleMultiLookupController(IChancelleryService chancelleryService)
        {
            ChancelleryService = chancelleryService;
        }

       string getFullname(EmployeeDTO empl)
        {
            return empl.LName + " " + empl.FName + " " + empl.MName;
        }

        public ActionResult GetItems(int[] v)
        {
            //return Json(Db.Meals.Where(o => v != null && v.Contains(o.Id))
            //                .Select(meal => new KeyContent(meal.Id, meal.Name)));

            return Json(ChancelleryService.GetEmployees().Where(o => v != null && v.Contains(o.id))
                           .Select(empl => new KeyContent(empl.id, getFullname(empl))));
        }

        public ActionResult Search(string search, int[] selected, int page)
        {
            //const int PageSize = 10;
            //selected = selected ?? new int[] { };
            //search = (search ?? "").ToLower().Trim();

            //var items = Db.Meals.Where(o => o.Name.ToLower().Contains(search) && (!selected.Contains(o.Id)));

            //return Json(new AjaxListResult
            //{
            //    Items = items.Skip((page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.Id, o.Name)),
            //    More = items.Count() > page * PageSize
            //});

            const int PageSize = 10;
            selected = selected ?? new int[] { };
            search = (search ?? "").ToLower().Trim();

            var items = ChancelleryService.GetEmployees().Where(o => getFullname(o).ToLower().Contains(search) && (!selected.Contains(o.id)));

            return Json(new AjaxListResult
            {
                Items = items.Skip((page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.id, getFullname(o))),
                More = items.Count() > page * PageSize
            });
        }

        public ActionResult Selected(int[] selected)
        {
            return Json(new AjaxListResult
            {
                Items = ChancelleryService.GetEmployees().Where(o => selected != null && selected.Contains(o.id))
                    .Select(o => new KeyContent(o.id, getFullname(o)))
            });
        }
    }
}
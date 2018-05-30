using System.Linq;
using System.Web.Mvc;
using Omu.AwesomeMvc;
using ACS.BLL.Interfaces;

namespace ACS.WEB.Controllers.Awesome.Lookup
{
    public class FolderLookupController : Controller
    {
        IFolderChancelleryService FolderChancelleryService;

        public FolderLookupController(IFolderChancelleryService IFolderChancelleryService)
        {
            FolderChancelleryService = IFolderChancelleryService;
        }

        public ActionResult GetItem(int? v)
        {
            //var o = Db.Get<Chef>(v) ?? new Chef();
            //return Json(new KeyContent(o.Id, o.FirstName + " " + o.LastName));

            var o = FolderChancelleryService.GetFolderChancellery(v.Value);

            return Json(new KeyContent(o.id, o.Name));
        }

        public ActionResult Search(string search, int page)
        {
            //const int PageSize = 7;
            //search = (search ?? "").ToLower().Trim();

            //var list = Db.Chefs.Where(f => (f.FirstName + " " + f.LastName).ToLower().Contains(search));
            //return Json(new AjaxListResult
            //{
            //    Items = list.Skip((page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.Id, o.FirstName + " " + o.LastName)),
            //    More = list.Count() > page * PageSize
            //});

            const int PageSize = 7;
            search = (search ?? "").ToLower().Trim();

            var list = FolderChancelleryService.GetFoldersChancellery().Where(f => (f.Name).ToLower().Contains(search));
            return Json(new AjaxListResult
            {
                Items = list.Skip((page - 1) * PageSize).Take(PageSize).Select(o => new KeyContent(o.id, o.Name)),
                More = list.Count() > page * PageSize
            });
        }
    }
}
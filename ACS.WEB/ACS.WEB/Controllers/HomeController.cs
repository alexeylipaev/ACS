using ACS.BLL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IApplicationUserService>();
            }
        }

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}
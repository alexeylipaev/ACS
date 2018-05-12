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
        private IAccountAppUserService AccountAppUserService
        {
            get
            {
                //Поскольку ранее мы зарегитрировали сервис пользователей через контекст OWIN,
                //то теперь мы можем получить этот сервис с помощью метода
                return HttpContext.GetOwinContext().GetUserManager<IAccountAppUserService>();
            }
        }


        public ActionResult Index()
        {
            //string currentUserEmail = this.User.Identity.Name;

            //var Users = AccountAppUserService.GetUsers().ToList();
             //var appUser = (from user in Users             //               where user.Email == currentUserEmail             //               select user).FirstOrDefault();

            //if (appUser == null)
            //    return RedirectToAction("Login", "Account", "");

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
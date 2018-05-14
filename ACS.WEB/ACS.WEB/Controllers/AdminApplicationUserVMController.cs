using ACS.BLL.DTO;
using ACS.BLL.Interfaces;
using ACS.BLL.Services;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACS.WEB.Util;
namespace ACS.WEB.Controllers
{
    public class AdminApplicationUserVMController : Controller
    {
        IApplicationUserService ApplicationUserService;

        public AdminApplicationUserVMController(IApplicationUserService serv)
        {
            ApplicationUserService = serv;
        }

        // GET: AdminApplicationUserVM
        public ActionResult Index()
        {
            IEnumerable<ApplicationUserDTO> userDtos = ApplicationUserService.GetApplicationUsers();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>()).CreateMapper();
            var users = MapBLLRrsr.GetMap().Map<IEnumerable<ApplicationUserDTO>, List<ApplicationUserViewModel>>(userDtos);
            return View(users);
        }

        // GET: AdminApplicationUserVM/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminApplicationUserVM/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminApplicationUserVM/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminApplicationUserVM/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminApplicationUserVM/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminApplicationUserVM/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminApplicationUserVM/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}

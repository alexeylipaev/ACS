using ACS.BLL.DTO;
using ACS.BLL.Interfaces;
using ACS.WEB.Models;
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
    public class AccessController : Controller
    {
        IAccessService accessService;

        public AccessController(IAccessService serv)
        {
            accessService = serv;
        }

        // GET: Access
        public ActionResult Index()
        {
            IEnumerable<AccessDTO> userDtos = accessService.GetAccesses();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AccessDTO, AccessViewModel>()).CreateMapper();
            var users = MapBLLPresenter.GetMap().Map<IEnumerable<AccessDTO>, List<AccessViewModel>>(userDtos);
            return View(users);
        }

        // GET: Access/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Access/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Access/Create
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

        // GET: Access/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Access/Edit/5
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

        // GET: Access/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Access/Delete/5
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

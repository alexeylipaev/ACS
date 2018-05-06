﻿using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers
{

    public class ChancelleryController : Controller
    {
        IChancelleryService chancelleryService;

        public ChancelleryController(IChancelleryService serv)
        {
            chancelleryService = serv;
        }


        // GET: Chancellery
        public ActionResult Index()
        {
            return View();
        }

        // GET: Chancellery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chancellery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chancellery/Create
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

        // GET: Chancellery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chancellery/Edit/5
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

        // GET: Chancellery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chancellery/Delete/5
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

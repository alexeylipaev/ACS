using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.BLL.Services;
using ACS.WEB.Areas.Admin.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {

        IEmployeeService EmployeeService;

        public EmployeesController(IEmployeeService serv)
        {
            EmployeeService = serv;
        }

        // GET: Admin/Employees
        public ActionResult Index()
        {
            IEnumerable<EmployeeDTO> userDtos = EmployeeService.GetUsers();
            var user = this.User;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeAdminVM>()).CreateMapper();
            var users = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeAdminVM>>(userDtos);
            return View(users);
        }

        // GET: Admin/Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                EmployeeDTO user = EmployeeService.GetUser(id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeAdminVM>()).CreateMapper();
                var userVM = mapper.Map<EmployeeDTO, EmployeeAdminVM>(user);
                //var userVM = new UserViewModel { Id = user.Id };

                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Admin/Employees/Create
        public ActionResult Create()
        {
            try
            {
                var userVM = new EmployeeAdminVM();
               // if (Id != null)
                //{
                //    EmployeeDTO userDTO = EmployeeService.GetUser(Id);
                //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeAdminVM>()).CreateMapper();
                //    userVM = mapper.Map<EmployeeDTO, EmployeeAdminVM>(userDTO);
                //    //userVM.Id = userDTO.Id;
                //}
                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: Admin/Employees/Create
        [HttpPost]
        public ActionResult Create(EmployeeAdminVM employeeAdminVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    var userDto = new EmployeeDTO();
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeAdminVM, EmployeeDTO>()).CreateMapper();
                    userDto = mapper.Map<EmployeeAdminVM, EmployeeDTO>(employeeAdminVM);
                    EmployeeService.CreateUser(userDto, currentUserEmail);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(employeeAdminVM);
        }

        // GET: Admin/Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Employees/Edit/5
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

        // GET: Admin/Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Employees/Delete/5
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

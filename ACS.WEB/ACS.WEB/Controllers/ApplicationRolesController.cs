using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class ApplicationRolesController : Controller
    {
        IApplicationRoleService ApplicationRoleService;

        public ApplicationRolesController(IApplicationRoleService serv)
        {
            ApplicationRoleService = serv;

        }
        // GET: ApplicationRole
        public ActionResult Index()
        {
            IEnumerable<ApplicationRoleDTO> rolesDto = ApplicationRoleService.GetApplicationRoles();
            //var user = this.User;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();
            var roles = mapper.Map<IEnumerable<ApplicationRoleDTO>, List<ApplicationRoleViewModel>>(rolesDto);
            return View(roles);
        }

        // GET: ApplicationRole/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                ApplicationRoleDTO roleDto = ApplicationRoleService.FindRoleById((int)id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();
                var roleVM = mapper.Map<ApplicationRoleDTO, ApplicationRoleViewModel>(roleDto);
                //var userVM = new UserViewModel { Id = user.Id };

                return View(mapper);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: ApplicationRole/Create
        public ActionResult Create(int? id)
        {
            try
            {
                var roleVM = new ApplicationRoleViewModel();
                if (id != null)
                {
                    ApplicationRoleDTO roleDTO = ApplicationRoleService.FindRoleById((int)id);
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();
                    roleVM = mapper.Map<ApplicationRoleDTO, ApplicationRoleViewModel>(roleDTO);
                    //userVM.id = userDTO.id;
                }
                return View(roleVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: ApplicationRole/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Users")] ApplicationRoleViewModel roleVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    var roleDto = new ApplicationRoleDTO { id = roleVM.id, Name = roleVM.Name };
                    ApplicationRoleService.CreateAsync(roleDto);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(roleVM);
        }

        // GET: ApplicationRole/Edit/5
        public ActionResult Edit(int? id)
        {
            var roleVM = new ApplicationRoleViewModel();
            if (id != null)
            {
                ApplicationRoleDTO roleDTO = ApplicationRoleService.FindRoleById((int)id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();
                roleVM = mapper.Map<ApplicationRoleDTO, ApplicationRoleViewModel>(roleDTO);
                //userVM.id = userDTO.id;
            }

            return View(roleVM);
        }

        // POST: ApplicationRole/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Users")] ApplicationRoleViewModel roleVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
            
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    var roleDto = new ApplicationRoleDTO { id = roleVM.id, Name = roleVM.Name};
                    ApplicationRoleService.UpdateRole(roleDto);
                    ViewBag.EditResult = "Данные изменены";
                    return View(roleDto);
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(roleVM);
        }

        // GET: ApplicationRole/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var roleDTO = ApplicationRoleService.FindRoleById((int)id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();
            var roleVM = mapper.Map<ApplicationRoleDTO, ApplicationRoleViewModel>(roleDTO);

            if (roleVM == null)
            {
                return HttpNotFound();
            }
            return View(roleVM);
        }

        // POST: ApplicationRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationRoleService.DeleteRole((int)id);
                    ViewBag.EditResult = "Данные удалены";
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return RedirectToAction("Index");
        }
    
        
    }
}

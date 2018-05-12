using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.ViewModel;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
            return View(roles.OrderBy(r=>r.id));
        }

        // GET: ApplicationRole/Details/5
        public async Task<ActionResult> Details(int id)
        {
           
            try
            {
                ApplicationRoleDTO roleDto = await ApplicationRoleService.FindByIdAsync((int)id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();
                var roleVM = mapper.Map<ApplicationRoleDTO, ApplicationRoleViewModel>(roleDto);
                //var userVM = new UserViewModel { Id = user.Id };

                return View(roleVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(ApplicationRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                OperationDetails operationDetails = await ApplicationRoleService.CreateAsync(new ApplicationRoleDTO
                {
                    Name = model.Name
                    //Description = model.Description
                });
                if (operationDetails.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(int id)
        {
            ApplicationRoleDTO role = await ApplicationRoleService.FindByIdAsync(id);
            if (role != null)
            {
                return View(new ApplicationRoleViewModel
                {
                    //Id = role.Id,
                    Name = role.Name,
                    //Description = role.Description
                });
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Edit(ApplicationRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRoleDTO role = await ApplicationRoleService.FindByIdAsync(model.id);
                if (role != null)
                {
                    //role.Description = model.Description;
                    role.Name = model.Name;
                    OperationDetails result = await ApplicationRoleService.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Что-то пошло не так");
                    }
                }
            }
            return View(model);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            //ApplicationRoleDTO role = await ApplicationRoleService.FindByIdAsync(id);
            if (id != null)
            {
                OperationDetails result = await ApplicationRoleService.DeleteAsync((int)id);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAction(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                if (ModelState.IsValid)
                {
                    await ApplicationRoleService.DeleteAsync((int)id);
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

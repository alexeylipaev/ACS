using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers
{
    [Authorize]
    [Authorize(Roles = "Admin")]
    public class ApplicationUsersController : Controller
    {
        IApplicationUserService ApplicationUserService;


        public ApplicationUsersController(IApplicationUserService serv)
        {
            ApplicationUserService = serv;
        }

        // GET: ApplicationRole
        public ActionResult Index()
        {
            IEnumerable<ApplicationUserDTO> usersDto = ApplicationUserService.GetApplicationUsers();
            //var user = this.User;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<ApplicationUserDTO>, List<ApplicationUserViewModel>>(usersDto);

            //foreach (var userVM in users)
            //{
            //    for (int i = 0; i < userVM.Roles.Count; i++)
            //    {
            //        var roleId = userVM.Roles.ElementAt(i).RoleId;

            //        var role = ApplicationUserService.FindRoleById(roleId);

            //        var mapperRole = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();

            //        var roleVM = mapperRole.Map<ApplicationRoleDTO, ApplicationRoleViewModel>(role);
            //        userVM.DataRoles.Add(roleVM);
            //    }

            //}

            return View(users);
        }

        public async Task<ActionResult> AddOrEditRoles(int id = 0)
        {
            SelectedRoleViewModel rol = new SelectedRoleViewModel();
            var roledDto = ApplicationUserService.GetApplicationRoles();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();
            var roleCollectionVM = mapper.Map<IEnumerable<ApplicationRoleDTO>, List<ApplicationRoleViewModel>>(roledDto);

            rol.RoleCollection = roleCollectionVM;

            ApplicationUserDTO userDto = await ApplicationUserService.FindByIdAsync(id);
            //var user = this.User;
            var mapperUs = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>()).CreateMapper();
            var user = mapperUs.Map<ApplicationUserDTO, ApplicationUserViewModel>(userDto);

            var userRoles = user.Roles;

            for (int i = 0; i < userRoles.Count; i++)
            {
                var roleId = userRoles.ElementAt(i).RoleId;
                rol.SelectedId.Add(roleId);
            }

            return View(rol);
        }
        [HttpPost]
        public async Task<ActionResult> AddOrEditRoles(SelectedRoleViewModel sRole)
        {
            var userId = sRole.Id;
            ApplicationUserDTO userDto = await ApplicationUserService.FindByIdAsync((int)userId);
            var userRoles = userDto.Roles;

            bool IsChanged = false;

            for (int i = 0; i < sRole.SelectedId.Count; i++)
            {
                int newRoleId = sRole.SelectedId.ElementAt(i);

                if (userRoles.Any(dr => dr.RoleId == newRoleId)) continue;

                IsChanged = true;

                var dataRole = ApplicationUserService.GetAppUserRoleAssignmentData(sRole.SelectedId.ElementAt(i), userId);
                userDto.Roles.Add(dataRole);
            }
            if (IsChanged)
            {
                await ApplicationUserService.UpdateAsync(userDto);
                ViewBag.EditResult = "Данные изменены";
            }
            return View(userDto);
            //return RedirectToAction("AddOrEdit", new { id = 0 });


        }

        // GET: ApplicationRole/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                ApplicationUserDTO userDto = await ApplicationUserService.FindByIdAsync((int)id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>()).CreateMapper();
                var userVM = mapper.Map<ApplicationUserDTO, ApplicationUserViewModel>(userDto);
                //var userVM = new UserViewModel { Id = user.Id };

                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: ApplicationRole/Create
        public async Task<ActionResult> Create(int? id)
        {

            try
            {
                var userVM = new ApplicationUserViewModel();
                if (id != null)
                {
                    ApplicationUserDTO userDTO = await ApplicationUserService.FindByIdAsync((int)id);
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>()).CreateMapper();
                    userVM = mapper.Map<ApplicationUserDTO, ApplicationUserViewModel>(userDTO);
                    //userVM.id = userDTO.id;
                }
                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // POST: ApplicationRole/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUserViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserViewModel, ApplicationUserDTO>()).CreateMapper();
                    var userDto = mapper.Map<ApplicationUserViewModel, ApplicationUserDTO>(userVM);

                    await ApplicationUserService.CreateAsync(userDto);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(userVM);
        }

        // GET: ApplicationRole/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var roleVM = new ApplicationUserViewModel();
            if (id != null)
            {
                ApplicationUserDTO userDTO = await ApplicationUserService.FindByIdAsync((int)id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>()).CreateMapper();
                roleVM = mapper.Map<ApplicationUserDTO, ApplicationUserViewModel>(userDTO);
                //userVM.id = userDTO.id;
            }

            return View(roleVM);
        }


        // POST: ApplicationRole/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUserViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserViewModel, ApplicationUserDTO>()).CreateMapper();
                    var userDto = mapper.Map<ApplicationUserViewModel, ApplicationUserDTO>(userVM);

                  await  ApplicationUserService.UpdateAsync(userDto);
                    ViewBag.EditResult = "Данные изменены";
                    return View(userDto);
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(userVM);
        }

        // GET: ApplicationRole/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userDTO = await ApplicationUserService.FindByIdAsync((int)id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>()).CreateMapper();
            var roleVM = mapper.Map<ApplicationUserDTO, ApplicationUserViewModel>(userDTO);

            if (roleVM == null)
            {
                return HttpNotFound();
            }
            return View(roleVM);
        }

        // POST: ApplicationRole/Delete/5
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
                  await  ApplicationUserService.DeleteAsync((int)id);
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


    //// GET: ApplicationRole/Delete/5
    //public ActionResult AddRoleToUsers(int? id)
    //{
    //    int? RoleId = id;
    //    if (RoleId == null)
    //    {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }

    //    return View();
    //}

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult AddRoleToUsers([Bind(Include = "id,Name,Users")] List<int> UsersId)
    //{
    //    try
    //    {
    //        if (ModelState.IsValid)
    //        {

    //            //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
    //            //var roleDto = new ApplicationUserDTO { id = roleVM.id, Name = roleVM.Name };
    //            //ApplicationRoleService.UpdateRole(roleDto);
    //            ViewBag.EditResult = "Данные изменены";
    //            return View();
    //        }
    //    }
    //    catch (ValidationException ex)
    //    {
    //        ModelState.AddModelError(ex.Property, ex.Message);
    //    }

    //    return View();
    //}
}


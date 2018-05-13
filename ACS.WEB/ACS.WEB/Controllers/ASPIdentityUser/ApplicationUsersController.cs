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
   
  
            var users = MappListAppUserDTOToListAppUserVM(usersDto);
            FillDataRoles(users);
            return View(users);
        }

        private void FillDataRoles(IEnumerable<ApplicationUserViewModel> usersVW)
        {
            foreach (var userVW in usersVW)
            {
                for (int i = 0; i < userVW.Roles.Count; i++)
                {
                    var roleId = userVW.Roles.ElementAt(i).RoleId;

                    var AppRoleDTo = ApplicationUserService.FindRoleById(roleId);

                    if (!userVW.DataRoles.Any(dr => dr.Name == AppRoleDTo.Name))
                    {
                        //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();

                        var result = Mapper.Map<ApplicationRoleDTO, ApplicationRoleViewModel>(AppRoleDTo);

                        userVW.DataRoles.Add(result);
                    }
                }
            }

        }

        public async Task<ActionResult> AddOrEditRoles(int id = 0)
        {
             SelectedRoleViewModel rol = new SelectedRoleViewModel();

            var roledDto = ApplicationUserService.GetApplicationRoles();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO, ApplicationRoleViewModel>()).CreateMapper();


            rol.RoleCollection = Mapper.Map<IEnumerable<ApplicationRoleDTO>, List<ApplicationRoleViewModel>>(roledDto); 

            ApplicationUserDTO userDto = await ApplicationUserService.FindByIdAsync(id);
            //var user = this.User;

            var user = MappAppUserDTOToAppUserVM(userDto);

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

            bool IsHaveSelected = sRole.SelectedId.Count > 0;

            if (IsHaveSelected)
                userDto.Roles.Clear();

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
                var resultUpdateRoles=  await ApplicationUserService.UpdateUserRolesAsync(userDto);
                if (resultUpdateRoles.Succeeded)
                {
                    ViewBag.EditResult = "Роли обновлены";
                 
                }
                else
                {
                    throw new Exception("Ошибка обновления ролей пользователя " + userDto.Email);
                }
            }

            //return View(sRole);
            return RedirectToAction("AddOrEditRoles", new { id = userId });

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

                var userVM = MappAppUserDTOToAppUserVM(userDto);
                //var userVM = new UserViewModel { Id = user.Id };

                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: ApplicationRole/Create
        public  ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationRole/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationUserViewModel userVM)
        {
            return await CreateOrUpdateOrDel(userVM);
        }

        // GET: ApplicationRole/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var VM = await GetAppUserVM(id);
            return View(VM);
        }

        async Task<ApplicationUserViewModel> GetAppUserVM(int id)
        {
            var appuserDTO = await ApplicationUserService.FindByIdAsync(id);
            if (appuserDTO == null) { throw new Exception("Пользователь не найден"); }
            return MappAppUserDTOToAppUserVM(appuserDTO);
        }

        // POST: ApplicationRole/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ApplicationUserViewModel userVM)
        {
            return await CreateOrUpdateOrDel(userVM);
        }

      async Task<ActionResult> CreateOrUpdateOrDel(/*[Bind(Include = "Id,Name")]*/ ApplicationUserViewModel applicationUserViewModel, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var applicationUserDTO = MappAppUserVMToAppUserDTO(applicationUserViewModel);

                    OperationDetails result = null;

                    if (del)
                    {
                        result =  await ApplicationUserService.DeleteAsync(applicationUserDTO.id);
                        if (result.Succeeded)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = await ApplicationUserService.CreateOrUpdateAsync(applicationUserDTO);
                        if (result.Succeeded)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(applicationUserViewModel);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(applicationUserViewModel);
        }


        // GET: ApplicationRole/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var vm = await GetAppUserVM(id);
            ActionResult action = await this.DeleteConfirmed(id);
            return action;
        }

        // POST: ApplicationRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var appUserDTO = await ApplicationUserService.FindByIdAsync(id);
            var appUserVM = MappAppUserDTOToAppUserVM(appUserDTO);
            return await CreateOrUpdateOrDel(appUserVM, true);
        }
        #region mapper
        //IMapper MapperUserVMToUserDTO()
        //{
        //    return new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<EmployeeViewModel, EmployeeDTO>();
        //        cfg.CreateMap<AppUserClaimViewModel, AppUserClaimDTO>();
        //        cfg.CreateMap<AppUserLoginViewModel, AppUserClaimDTO>();
        //        cfg.CreateMap<AppUserRoleViewModel, AppUserRoleDTO>();
        //        cfg.CreateMap<ApplicationUserViewModel, ApplicationUserDTO>();

        //    }).CreateMapper();
        //}

        //IMapper MapperUserDTOToUserVM()
        //{
        //    return new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<EmployeeDTO, EmployeeViewModel>();
        //        cfg.CreateMap<AppUserClaimDTO, AppUserClaimViewModel>();
        //        cfg.CreateMap<AppUserLoginDTO, AppUserLoginViewModel>();
        //        cfg.CreateMap<AppUserRoleDTO, AppUserRoleViewModel>();
        //        cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>();

        //    }).CreateMapper();
        //}
        ApplicationUserDTO MappAppUserVMToAppUserDTO(ApplicationUserViewModel ApplicationUserVM)
        {
            return Mapper.Map<ApplicationUserViewModel, ApplicationUserDTO>(ApplicationUserVM);
        }
        ApplicationUserViewModel MappAppUserDTOToAppUserVM(ApplicationUserDTO ApplicationUserDTO)
        {
            return Mapper.Map<ApplicationUserDTO, ApplicationUserViewModel>(ApplicationUserDTO);
        }
        IEnumerable<ApplicationUserViewModel> MappListAppUserDTOToListAppUserVM(IEnumerable<ApplicationUserDTO> ApplicationUserDTO)
        {
            return Mapper.Map<IEnumerable<ApplicationUserDTO>, List<ApplicationUserViewModel>>(ApplicationUserDTO);
        }
        #endregion
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


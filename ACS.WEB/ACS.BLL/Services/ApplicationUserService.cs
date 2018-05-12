using ACS.BLL.DTO; using ACS.BLL.Infrastructure; using ACS.DAL.Entities; using System.Threading.Tasks; using Microsoft.AspNet.Identity; using System.Security.Claims; using ACS.BLL.Interfaces; using ACS.DAL.Interfaces; using System.Collections.Generic; using System.Linq; using System; using ACS.BLL.BusinessModels; using AutoMapper; using System.Diagnostics; using System.Collections;  namespace ACS.BLL.Services {     public class ApplicationUserService :ServiceBase, IApplicationUserService     {         public ApplicationUserService(IUnitOfWork uow) : base(uow) { }
        /// <summary>         /// Получить ID нового объекта         /// </summary>         /// <returns></returns>         public int GetIdNewAppUser()         {             return  Database.UserManager.Users.ToList().Max(appUser => appUser.Id) + 1;         }          /// <summary>         /// Назначить роль         /// </summary>         /// <param name="RoleId"></param>         /// <param name="UserId">Null если нужно создать роль для нового пользователя, not null если пользователь уже есть в БД, поместить его ID</param>         /// <returns></returns>         public AppUserRoleDTO GetAppUserRoleAssignmentData(int RoleId, int? UserId = null)         {             AppUserRoleDTO result = null;             try             {                  UserId = UserId ?? GetIdNewAppUser();                  result = new AppUserRoleDTO() { RoleId = RoleId, UserId = (int)UserId };             }             catch (Exception e)             {

                CatchError(e);                }               return result;         }          public async Task<OperationDetails> CreateAsync(ApplicationUserDTO applicationUserDTO)         {              ApplicationUser appUser = await Database.UserManager.FindByEmailAsync(applicationUserDTO.Email);              if (appUser == null)             {                                 appUser = MappAppUserDTOToAppUser(applicationUserDTO);                   var result = await Database.UserManager.CreateAsync(appUser, applicationUserDTO.PasswordHash);                  //// создаем профиль клиента                 //Employee empl = new Employee {id = appUser.id, Email = appUser.Email};                  //appUser.Employee = empl;                  if (result.Errors.Count() > 0)                     return new OperationDetails(false, result.Errors.FirstOrDefault(), "");                  if (applicationUserDTO.Roles != null && applicationUserDTO.Roles.Any(r=>r != null) )                 {                     foreach (var role in applicationUserDTO.Roles)                     {                         var r = await Database.RoleManager.FindByIdAsync(role.RoleId);                         if(r != null)                         await Database.UserManager.AddToRolesAsync(appUser.Id, r.Name);                     }                 }                 else                 {                     var r = await Database.RoleManager.FindByIdAsync(1);                     await Database.UserManager.AddToRoleAsync(appUser.Id, r.Name);                 }                  await Database.SaveAsync();                  return new OperationDetails(true, "Пользователь успешно создан", "");             }             else             {                 return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");             }         }          public  IEnumerable<ApplicationUserDTO> GetApplicationUsers()         {             var users = Database.UserManager.Users;             return MappListAppUserToListAppUserDTO(users.ToList()); ;         }           public  IEnumerable<ApplicationRoleDTO> GetApplicationRoles()         {             var roles = Database.RoleManager.Roles;             // применяем автомаппер для проекции одной коллекции на другую             var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, ApplicationRoleDTO>()).CreateMapper();             var rolesDto =  mapper.Map<IEnumerable<ApplicationRole>, List<ApplicationRoleDTO>>(roles.ToList());              return rolesDto;         }

        public async Task<ApplicationRoleDTO> FindRoleByIdAsync(int roleId)         {             if (roleId == default(int))                 throw new ValidationException("Роль  не установлена", "");              var AppRole = await Database.RoleManager.FindByIdAsync(roleId);

            if (AppRole == null)                 throw new ValidationException("Роль не найдена", "");              var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, ApplicationRoleDTO>()).CreateMapper();              var result = mapper.Map<ApplicationRole, ApplicationRoleDTO>(AppRole);             return result;         }

        public ApplicationRoleDTO FindRoleById(int roleId)
        {
            if (roleId == default(int))                 throw new ValidationException("Роль  не установлена", "");              var AppRole =  Database.RoleManager.FindById(roleId);

            if (AppRole == null)                 throw new ValidationException("Роль не найдена", "");              var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, ApplicationRoleDTO>()).CreateMapper();              var result = mapper.Map<ApplicationRole, ApplicationRoleDTO>(AppRole);             return result;

        }
        //private async void FillDataRoles(ApplicationUserDTO userDto)
        //{
        //    for (int i = 0; i < userDto.Roles.Count; i++)
        //    {
        //        var roleId = userDto.Roles.ElementAt(i).RoleId;

        //        var AppRole = await Database.RoleManager.FindByIdAsync(roleId);

        //        if (!userDto.DataRoles.Any(dr => dr.Name == AppRole.Name))
        //        {
        //            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, ApplicationRoleDTO>()).CreateMapper();

        //            var result = mapper.Map<ApplicationRole, ApplicationRoleDTO>(AppRole);

        //            userDto.DataRoles.Add(result);
        //        }
           
        //    }
        //}          public bool IsInRole(string userName, string role)         {             bool result = false;             var applicationUser = Database.UserManager.FindByName(userName);              if (applicationUser != null)             {                 var AppRole = Database.RoleManager.FindByName(role);                 if (AppRole != null)                     return AppRole.Users.Any(u => u.UserId == applicationUser.Id);             }             return result;         }          public async Task<ApplicationUserDTO> FindByNameAsync(string userName)         {             if (string.IsNullOrEmpty(userName))                 throw new ValidationException("Имя пользователя не установлено", "");              var appUser = await Database.UserManager.FindByNameAsync(userName);             if (appUser == null)                 throw new ValidationException("Пользователь не найден", ""); 
            var result = MappAppUserToAppUserDTO(appUser);             return result;         }          public async Task<ApplicationUserDTO> FindByEmailAsync(string Email)         {             if (string.IsNullOrEmpty(Email))                 throw new ValidationException("Почта пользователя не установлена", "");              var appUser = await Database.UserManager.FindByEmailAsync(Email);             if (appUser == null)                 throw new ValidationException("Пользователь не найден", "");               var result = MappAppUserToAppUserDTO(appUser);             return result;         }          public ApplicationUserDTO FindByEmail(string Email)         {             if (string.IsNullOrEmpty(Email))                 throw new ValidationException("Почта пользователя не установлена", "");              var Users = Database.UserManager.Users.ToList();              ApplicationUser appUser = (from user in Users                            where user.Email == Email                            select user).FirstOrDefault();              if (appUser == null)                 throw new ValidationException("Пользователь не найден", "");              var result = MappAppUserToAppUserDTO(appUser);             return result;         }

          public async Task<OperationDetails> AddLoginAsync(int userId, UserLoginInfo login)         {             var result = await Database.UserManager.AddLoginAsync(userId, login);              if (result.Errors.Count() > 0)                 return new OperationDetails(false, result.Errors.FirstOrDefault(), "");              return new OperationDetails(true, result.Errors.FirstOrDefault(), "");         }




        public async Task<OperationDetails> CreateOrUpdateAsync(ApplicationUserDTO UserDTO)         {             ApplicationUser EditableObj = await Database.UserManager.FindByIdAsync(UserDTO.id);
            var UpdateAppUser = MappAppUserDTOToAppUser(UserDTO);

            try
            {

                if (EditableObj == null)
                {
                    var result = await Database.UserManager.CreateAsync(UpdateAppUser);

                    if (result.Succeeded)
                        return new OperationDetails(true, "Пользователь успешно создан", "");
                    else
                    {
                        return new OperationDetails(false, "Ошибка создания пользователя", "");
                    }
                }
                else
                {
                    var UserApp = Database.UserManager.FindById(UserDTO.id);

                    if (UserApp != null)
                    {
                        UserApp.Email = UpdateAppUser.Email;
                        UserApp.UserName = UpdateAppUser.UserName;
                        if (!string.IsNullOrEmpty(UpdateAppUser.PasswordHash))
                            UserApp.PasswordHash = UpdateAppUser.PasswordHash;
                        UserApp.PhoneNumber = UpdateAppUser.PhoneNumber;
                        UserApp.SecurityStamp = UpdateAppUser.SecurityStamp;
                        UserApp.TwoFactorEnabled = UpdateAppUser.TwoFactorEnabled;

                        UserApp.Employee = UpdateAppUser.Employee;


                        var resultUpdateRole = await UpdateUserRolesAsync(UserDTO);

                        if (!resultUpdateRole.Succeeded)
                            return new OperationDetails(true, resultUpdateRole.Message, "");


                        var result = await Database.UserManager.UpdateAsync(EditableObj);
                        await Database.SaveAsync();

                        if (result.Succeeded)
                            return new OperationDetails(true, "Данные пользователя успешно обновлены", "");
                        else
                        {
                            return new OperationDetails(false, "Ошибка обновления пользователя", "");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                return new OperationDetails(false, ex.Message, "");
            }

            return new OperationDetails(true, "", "");
        }

     

        public async Task<OperationDetails> UpdateUserRolesAsync(ApplicationUserDTO UserDTO)
        {
           
              var  EditableObj = await Database.UserManager.FindByIdAsync(UserDTO.id);

                if (EditableObj == null)
                {
                    return new OperationDetails(false, "Не возможно редактировать объект с id", "");
                }

            OperationDetails result = null;

            if (EditableObj.Roles.Count == 0)//если ролей нет
                result = await AssignUserRolesAsync(UserDTO);
            else
            {
                 result = await RemoveFromRoleAsync(EditableObj);

                if (!result.Succeeded)
                    return new OperationDetails(false, result.Message, "");

                result = await AssignUserRolesAsync(UserDTO);

                if (!result.Succeeded)
                    return new OperationDetails(false, result.Message, "");
            }

            await Database.SaveAsync();
            return new OperationDetails(true, result.Message, "");
        }


        private async Task<OperationDetails> RemoveFromRoleAsync(ApplicationUser EditableObj)         {
            List<AppUserRole> RolesId = EditableObj.Roles.ToList();

            foreach (var currentDataRole in RolesId)//user
            {
                int currentRoleId = currentDataRole.RoleId;
               
                    ApplicationRole currentRole = await Database.RoleManager.FindByIdAsync(currentRoleId);

                    IdentityResult result = await Database.UserManager.RemoveFromRoleAsync(EditableObj.Id, currentRole.Name);

                if (!result.Succeeded)
                        return new OperationDetails(false, "Ошибка при удалении роли ", currentRole.Name.ToString());
             
            }

             

            return new OperationDetails(true,"Роли пользователя успешно удалены","");
        }          private async Task<OperationDetails> AssignUserRolesAsync(ApplicationUserDTO UserDTO)         {
            foreach (var dRole in UserDTO.Roles)
            {
                ApplicationRole role = await Database.RoleManager.FindByIdAsync(dRole.RoleId);
                var result = await Database.UserManager.AddToRoleAsync(dRole.UserId, role.Name);
                string StrError = string.Empty;
                foreach (var error in result.Errors)
                {
                    StrError += error.ToString();
                }

                if (!result.Succeeded)
                    return new OperationDetails(false, StrError, "");
            }

            return new OperationDetails(true, "Роли пользователя успешно обновлены", "");
        }          public async Task<OperationDetails> DeleteAsync(int userId)         {             ApplicationUser EditableObj = await Database.UserManager.FindByIdAsync(userId);

            if (EditableObj == null)
            {
                return new OperationDetails(false, "Не возможно редактировать объект с id", "");
            }              try             {                await  Database.UserManager.DeleteAsync(EditableObj);
                await Database.SaveAsync();

                return new OperationDetails(true, "Пользователь успешно удален", "");             }             catch (Exception e)             {
                CatchError(e);                 return new OperationDetails(false, e.Message, "");             }         }

        public Task<OperationDetails> AssignRolesAsync(int userId)
        {
            throw new NotImplementedException();

        } 
        //public ApplicationUserDTO FindById(int userId)
        //{
        //    var appUser = Database.UserManager.FindById(userId);

        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()).CreateMapper();          //    var result = mapper.Map<ApplicationUser, ApplicationUserDTO>(appUser);

        //    return result;
        //}

        public async Task<ApplicationUserDTO> FindByIdAsync(int id)
        {
            var appUser = await Database.UserManager.FindByIdAsync(id);
             var result = MappAppUserToAppUserDTO(appUser);

            ApplicationUser user = await Database.UserManager.FindByIdAsync(id);

            var userDto = MappAppUserToAppUserDTO(user);

            //FillDataRoles(userDto);

            return result;
        }
        IMapper MapperUserDtoToUser()
        {
           return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDTO, Employee>();
                cfg.CreateMap<AppUserClaimDTO, AppUserClaim>();
                cfg.CreateMap<AppUserLoginDTO, AppUserLogin>();
                cfg.CreateMap<AppUserRoleDTO, AppUserRole>();
                cfg.CreateMap<ApplicationUserDTO, ApplicationUser>();

            }).CreateMapper();
        }

        IMapper MapperUserToUserDto()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee , EmployeeDTO>();
                cfg.CreateMap<AppUserClaim , AppUserClaimDTO>();
                cfg.CreateMap<AppUserLogin , AppUserLoginDTO>();
                cfg.CreateMap<AppUserRole , AppUserRoleDTO>();
                cfg.CreateMap<ApplicationUser , ApplicationUserDTO>();

            }).CreateMapper();
        }
        ApplicationUser MappAppUserDTOToAppUser(ApplicationUserDTO ApplicationUserDTO)
        {
            return MapperUserDtoToUser().Map<ApplicationUserDTO, ApplicationUser>(ApplicationUserDTO);
        }
       ApplicationUserDTO MappAppUserToAppUserDTO(ApplicationUser ApplicationUser)
        {
            return MapperUserToUserDto().Map<ApplicationUser, ApplicationUserDTO>(ApplicationUser);
        }
        IEnumerable<ApplicationUserDTO> MappListAppUserToListAppUserDTO(IEnumerable<ApplicationUser> ApplicationUser)
        {  
            return MapperUserToUserDto().Map<IEnumerable<ApplicationUser>, List<ApplicationUserDTO>>(ApplicationUser);
        }

        public void Dispose()         {             Database.Dispose();         }
    } }
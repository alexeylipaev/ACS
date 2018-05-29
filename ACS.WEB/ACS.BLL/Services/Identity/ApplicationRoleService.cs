﻿using ACS.BLL.DTO; using ACS.BLL.Infrastructure; using ACS.BLL.Interfaces; using ACS.DAL.Entities; using ACS.DAL.Interfaces;  using System; using System.Collections; using System.Collections.Generic; using System.Diagnostics; using System.Linq; using System.Text; using System.Threading.Tasks;  namespace ACS.BLL.Services {     public class ApplicationRoleService : ServiceBase, IApplicationRoleService     {
        public ApplicationRoleService(IUnitOfWork uow) : base(uow) { } 

        /// <summary>     /// Получить ID нового объекта     /// </summary>     /// <returns></returns>         public int GetIdNewAppUser()         {                return  Database.UserManager.Users.ToList().Max(appUser => appUser.Id) + 1;         }

        /// <summary>         /// Назначить роль         /// </summary>         /// <param name="RoleId"></param>         /// <param name="UserId">Null если нужно создать роль для нового пользователя, not null если пользователь уже есть в БД, поместить его ID</param>         /// <returns></returns>         public AppUserRoleDTO GetAppUserRoleAssignmentData(int RoleId, int? UserId = null)         {             AppUserRoleDTO result = null;             try             {
                UserId = UserId ?? GetIdNewAppUser();
                result = new AppUserRoleDTO() { RoleId = RoleId, UserId = (int)UserId };             }             catch (Exception e)             {

                Debug.WriteLine("Имя члена:               {0}", e.TargetSite);
                Debug.WriteLine("Класс определяющий член: {0}", e.TargetSite.DeclaringType);
                Debug.WriteLine("Тип члена:               {0}", e.TargetSite.MemberType);
                Debug.WriteLine("Message:                 {0}", e.Message);
                Debug.WriteLine("Source:                  {0}", e.Source);
                Debug.WriteLine("Help Link:               {0}", e.HelpLink);
                Debug.WriteLine("Stack:                   {0}", e.StackTrace);                  foreach (DictionaryEntry de in e.Data)                     Debug.WriteLine("{0} : {1}", de.Key, de.Value);             }

            return result;         }          public async Task<OperationDetails> CreateRoleAsync(ApplicationRoleDTO applicationRoleDTO)         {              ApplicationRole  appRole = await Database.RoleManager.FindByNameAsync(applicationRoleDTO.Name);              if (appRole == null)             {                 //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRoleDTO , ApplicationRole>()).CreateMapper();                 //appRole = MapDALBLL.GetMapp().Map<ApplicationRoleDTO, ApplicationRole>(applicationRoleDTO);                  var result = await Database.RoleManager.CreateAsync(appRole);                                if (result.Errors.Count() > 0)                     return new OperationDetails(false, result.Errors.FirstOrDefault(), "");                   await Database.SaveAsync();                  return new OperationDetails(true, "Роль успешна создана", "");             }             else             {                 return new OperationDetails(false, "Роль с таким наименованием уже существует", "Name");             }         }             public IEnumerable<ApplicationRoleDTO> GetApplicationRoles()         {             var roles = Database.RoleManager.Roles;             // применяем автомаппер для проекции одной коллекции на другую             //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, ApplicationRoleDTO>()).CreateMapper();              List<ApplicationRoleDTO> result = new List<ApplicationRoleDTO>();             foreach (var item in roles)
            {
                result.Add(MapApplicationRole.RoleToRoleDTO(item));
            }              return result;         }           public bool IsInRole(string userName, string role)         {             bool result = false;             var applicationUser = Database.UserManager.FindByUserName(userName);              if (applicationUser != null)             {                 var AppRole = Database.RoleManager.FindByName(role);                 if (AppRole != null)                     return AppRole.Users.Any(u => u.UserId == applicationUser.Id);             }             return result;         }          public async Task<ApplicationRoleDTO> FindByNameAsync(string roleName)         {             if (string.IsNullOrEmpty(roleName))                 throw new ValidationException("Имя роли не задано", "");              var appRole = await Database.RoleManager.FindByNameAsync(roleName);             if (appRole == null)                 throw new ValidationException("Роль не найдена", "");              return MapApplicationRole.RoleToRoleDTO(appRole);         }


        public async Task<ApplicationRoleDTO> FindRoleByIdAsync(int id)
        {
            var appRole = await Database.RoleManager.FindByIdAsync(id);
             var result = MapApplicationRole.RoleToRoleDTO(appRole);

            return result;
        }          public ApplicationRoleDTO FindRoleById(int id)         {             if (id == default(int))                 throw new ValidationException("Роль  не установлена", "");              var AppRole = (from role in Database.RoleManager.Roles.ToList()                            where role.Id == id                            select role).FirstOrDefault();              if (AppRole == null)                 throw new ValidationException("Роль не найдена", "");              return MapApplicationRole.RoleToRoleDTO(AppRole);         }          public async Task<OperationDetails> UpdateRoleAsync(ApplicationRoleDTO RoleDTO)         {              ApplicationRole EditableObj = await Database.RoleManager.FindByIdAsync(RoleDTO.id);               if (EditableObj == null)
            {
                return new OperationDetails(false, "Не возможно редактировать объект с id","");
                //throw new ValidationException("Не возможно редактировать объект с id", RoleDTO.id.ToString());
            }             try             {                 EditableObj.Name = RoleDTO.Name;                                await  Database.RoleManager.UpdateAsync(EditableObj);
                await Database.SaveAsync();                  return   new OperationDetails(true, "Роль успешна обновлена", "");             }             catch (Exception e)             {                 Debug.WriteLine("Имя члена:               {0}", e.TargetSite);                 Debug.WriteLine("Класс определяющий член: {0}", e.TargetSite.DeclaringType);                 Debug.WriteLine("Тип члена:               {0}", e.TargetSite.MemberType);                 Debug.WriteLine("Message:                 {0}", e.Message);                 Debug.WriteLine("Source:                  {0}", e.Source);                 Debug.WriteLine("Help Link:               {0}", e.HelpLink);                 Debug.WriteLine("Stack:                   {0}", e.StackTrace);                  foreach (DictionaryEntry de in e.Data)                     Console.WriteLine("{0} : {1}", de.Key, de.Value);

                return new OperationDetails(false, "Ошибка обновления роли", "");             }         }         public async Task<OperationDetails> DeleteRoleAsync(int id)         {             ApplicationRole EditableObj = await Database.RoleManager.FindByIdAsync(id);


            if (EditableObj == null)
            {
                return new OperationDetails(false, "Не возможно редактировать объект с id", "");
            }              try             {

                await Database.RoleManager.DeleteAsync(EditableObj);                 await Database.SaveAsync();
                return new OperationDetails(true, "Роль успешна удалена", "");             }             catch (Exception e)             {                 Debug.WriteLine("Имя члена:               {0}", e.TargetSite);                 Debug.WriteLine("Класс определяющий член: {0}", e.TargetSite.DeclaringType);                 Debug.WriteLine("Тип члена:               {0}", e.TargetSite.MemberType);                 Debug.WriteLine("Message:                 {0}", e.Message);                 Debug.WriteLine("Source:                  {0}", e.Source);                 Debug.WriteLine("Help Link:               {0}", e.HelpLink);                 Debug.WriteLine("Stack:                   {0}", e.StackTrace);                  foreach (DictionaryEntry de in e.Data)                     Console.WriteLine("{0} : {1}", de.Key, de.Value);

                return new OperationDetails(false, "Ошибка удаления роли", "");             }         }

          public void Dispose()         {             Database.Dispose();         }


    } }
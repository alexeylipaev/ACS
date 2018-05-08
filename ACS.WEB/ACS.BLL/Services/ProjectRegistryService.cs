using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.DAL.Interface;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.DAL.Entity;
namespace ACS.BLL.Services
{
   public class ProjectRegistryService : IProjectRegistryService
    {
        IUnitOfWork Database { get; set; }

        public ProjectRegistryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<OperationDetails> CreateAsync(ProjectRegistryDTO ProjectRegistryDto, string authorEmail)
        {
            var Author =  Database.Employees.Find(u => u.Email == authorEmail).FirstOrDefault();

            if (Author == null)
                throw new ValidationException("Не возможно идентифицировать текущего пользователя по почте", authorEmail);
            try
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectRegistryDTO, ProjectRegistry>()).CreateMapper();
                ProjectRegistry projectRegistry = mapper.Map<ProjectRegistryDTO, ProjectRegistry>(ProjectRegistryDto);


                Database.ProjectsRegistry.Create(projectRegistry);
                await Database.SaveAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Имя члена:               {0}", e.TargetSite);
                Debug.WriteLine("Класс определяющий член: {0}", e.TargetSite.DeclaringType);
                Debug.WriteLine("Тип члена:               {0}", e.TargetSite.MemberType);
                Debug.WriteLine("Message:                 {0}", e.Message);
                Debug.WriteLine("Source:                  {0}", e.Source);
                Debug.WriteLine("Help Link:               {0}", e.HelpLink);
                Debug.WriteLine("Stack:                   {0}", e.StackTrace);

                foreach (DictionaryEntry de in e.Data)
                    Console.WriteLine("{0} : {1}", de.Key, de.Value);
                return new OperationDetails(false, e.Message, "");
            }

            await Database.SaveAsync();
            return new OperationDetails(true, "Проект успешно создан", "");
            
        }

        public Task<OperationDetails> UpdateAsync(ProjectRegistryDTO ProjectRegistry, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> MoveToBaskeProjectRegistryAsync(ProjectRegistryDTO ProjectRegistry, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public Task<OperationDetails> DeleteAsync(int userId, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public ProjectRegistryDTO GetProjectRegistryAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectRegistryDTO> GetProjectsRegistry()
        {
           
        }

        public IEnumerable<InputControlPKIDTO> GetPKIProjectRegistry(ProjectRegistryDTO ProjectRegistry)
        {
            throw new NotImplementedException();
        }

        public Task<ReceivedDocPKIDTO> GetDocsPKIProjectRegistry(InputControlPKIDTO PKIProject)
        {
            throw new NotImplementedException();
        }
    }
}
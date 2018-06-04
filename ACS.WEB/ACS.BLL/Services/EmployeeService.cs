using ACS.BLL.Interfaces;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.DAL.Entities;

namespace ACS.BLL.Services
{
    class EmployeeService : ServiceBase, IEmployeeService
    {
        public EmployeeService(IUnitOfWork uow) : base(uow) { }

        public async Task<IEnumerable<EmployeeDTO>> GetAllResponsiblesChancelleryAsync(CorrespondencesBaseDTO correspondencesDTO)
        {
            var responsibles = (from responsible in correspondencesDTO.ResponsibleEmployees
                         select responsible);

            if (responsibles == null)
                throw new ValidationException("Запись не содержит ответственных", "");

            var empls = await Database.Employees.ToListAsync();

            return MapEmpl.ListEmplToListEmplDTO(empls.Where(m => responsibles.Contains(m.Id)));
        }

        public async Task<int> CreateOrUpdateAsync(EmployeeDTO EmplDto, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var empl = Database.Employees.Find(EmplDto.Id);
                empl = MapEmpl.EmplDTOToEmpl(EmplDto);
                InitSystemData<Employee>.Init(ref empl, AuthorID);
                return await Database.Employees.AddOrUpdateAsync(empl);
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Database.Employees.DeleteAsync(id);
        }

        public async Task<EmployeeDTO> FindAsync(int id)
        {
            var result = await Database.Employees.FindAsync(id);
            return MapEmpl.EmplToEmplDto(result);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var resultList = await Database.Employees.GetAllAsync();
            return MapEmpl.ListEmplToListEmplDTO(resultList);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

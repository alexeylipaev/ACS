using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
using AutoMapper;
using ACS.DAL.Entities;
using ACS.BLL.Infrastructure;

namespace ACS.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        IUnitOfWork Database { get; set; }

        public DepartmentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public DepartmentDTO GetDepartment(int? Id)
        {
            if (Id == null)
                throw new ValidationException("Не установлено Id подразделения", "");

            var department = Database.Departments.Get(Id.Value);
            if (department == null)
                throw new ValidationException("Подразделение не найдено", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>()).CreateMapper();
            return mapper.Map<Department, DepartmentDTO>(department);
        }

        public IEnumerable<DepartmentDTO> GetDepartments()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Department>, List<DepartmentDTO>>(Database.Departments.GetAll());
        }


        public void MakeDepartment(DepartmentDTO departmentDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateChancellery(ChancelleryDTO chancelleryDto, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{
    public static class MapEmpl
    {
        public static DAL.Entities.Employee EmplDTOToEmpl(DTO.EmployeeDTO emplDto)
        {
            DAL.Entities.Employee Empl = MapDB.Db.Employees.Find(emplDto.Id);

            if (Empl == null) Empl = new DAL.Entities.Employee();

            Empl.Id = emplDto.Id;

            Empl.LName = emplDto.LName;
            Empl.MName = emplDto.MName;
            Empl.FName = emplDto.FName;
            Empl.Email = emplDto.Email;

            Empl.ApplicationUserId = emplDto.ApplicationUserId;

            return Empl;
        }
        public static DTO.EmployeeDTO EmplToEmplDto(DAL.Entities.Employee Empl)
        {
            DTO.EmployeeDTO emplDto = new DTO.EmployeeDTO();

            emplDto.Id = Empl.Id;

            emplDto.LName = Empl.LName;
            emplDto.MName = Empl.MName;
            emplDto.FName = Empl.FName;
            emplDto.Email = Empl.Email;

            emplDto.ApplicationUserId = Empl.ApplicationUserId;
            BLL.MapSystemParam<DAL.Entities.Employee, DTO.EmployeeDTO>.FillParamDTO(Empl, ref emplDto);
            return emplDto;
        }
        public static List<DTO.EmployeeDTO> ListEmplToListEmplDTO(IEnumerable<DAL.Entities.Employee> empls)
        {
            List<DTO.EmployeeDTO> result = new List<DTO.EmployeeDTO>();

            foreach (var empl in empls)
                result.Add(EmplToEmplDto(empl));

            return result;
        }

    }
}

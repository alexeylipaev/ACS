using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IDepartmentService
    {
        void MakeDepartment(DepartmentDTO departmentDTO);
        DepartmentDTO GetDepartment(int? id);
        IEnumerable<DepartmentDTO> GetDepartment();
        void Dispose();
    }
}

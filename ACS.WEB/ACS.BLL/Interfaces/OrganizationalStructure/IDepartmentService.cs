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

        void MakeDepartment(DepartmentDTO departmentDTO, string authorEmail);

        void UpdateChancellery(ChancelleryDTO chancelleryDto, string authorEmail);

        DepartmentDTO GetDepartment(int? Id);

        //DepartmentDTO GetParentDepartment(int? Id);

        IEnumerable<DepartmentDTO> GetDepartments();
        void Dispose();
    }
}

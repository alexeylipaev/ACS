using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IDepartmentService : IDisposable
    {

        void CreateDepartment(DepartmentDTO departmentDTO, string authorEmail);

        void UpdateChancellery(ChancelleryDTO chancelleryDto, string authorEmail);

        DepartmentDTO GetDepartment(int? id);

        //DepartmentDTO GetParentDepartment(int? id);

        IEnumerable<DepartmentDTO> GetDepartments();

    }
}

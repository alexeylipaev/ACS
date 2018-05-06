using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IPostNameEmployeeService : IDisposable
    {
        void MakePostNameUser(PostNameEmployeeDTO PostNameUserDTO);
        PostNameEmployeeDTO GetPostNameUser(int? id);
        IEnumerable<PostNameEmployeeDTO> GetPostNameUser();

    }
}

using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IPostNameEmployeeService
    {
        void MakePostNameUser(PostNameUserDTO PostNameUserDTO);
        PostNameUserDTO GetPostNameUser(int? Id);
        IEnumerable<PostNameUserDTO> GetPostNameUser();
        void Dispose();
    }
}

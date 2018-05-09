using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IPostsEmployeesСode1СService : IDisposable
    {
        void CreatePostsEmployeesСode1С(PostEmployeeСode1СDTO PostsEmployeesСode1СDTO);
        PostEmployeeСode1СDTO GetPostsEmployeesСode1С(int? id);
        IEnumerable<PostEmployeeСode1СDTO> GetPostsEmployeesСode1С();

    }
}

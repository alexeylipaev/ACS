using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IPostUserСode1СService
    {
        void MakePostUserСode1С(PostUserСode1СDTO PostUserСode1СDTO);
        PostUserСode1СDTO GetPostUserСode1С(int? id);
        IEnumerable<PostUserСode1СDTO> GetPostUserСode1С();
        void Dispose();
    }
}

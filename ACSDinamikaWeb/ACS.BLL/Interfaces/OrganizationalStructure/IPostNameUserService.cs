﻿using ACS.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Interfaces
{
    public interface IPostNameUserService
    {
        void MakePostNameUser(PostNameUserDTO PostNameUserDTO);
        PostNameUserDTO GetPostNameUser(int? id);
        IEnumerable<PostNameUserDTO> GetPostNameUser();
        void Dispose();
    }
}

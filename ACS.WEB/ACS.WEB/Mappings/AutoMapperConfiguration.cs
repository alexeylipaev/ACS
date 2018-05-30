using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACS.WEB.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DTOToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDTOMappingProfile>();
            });
        }
    }
}
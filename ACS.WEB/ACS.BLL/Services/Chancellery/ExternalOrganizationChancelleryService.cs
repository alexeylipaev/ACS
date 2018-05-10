﻿using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL.Services
{
  public  class ExternalOrganizationChancelleryService : ServiceBase, IExternalOrganizationChancelleryService
    {
        public ExternalOrganizationChancelleryService(IUnitOfWork uow) : base(uow) { }

        public int CreateOrUpdateExternalOrganization(ExternalOrganizationChancelleryDTO ExternalOrganizationChancelleryDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var externalOrganization = MappExternalOrganizationDTOToExternalOrganization(ExternalOrganizationChancelleryDTO);

                var ExternalOrganization = Database.ExternalOrganizationChancelleries.Find(ExternalOrganizationChancelleryDTO.id);

                if (ExternalOrganization != null )
                {
                    ExternalOrganization.Name = externalOrganization.Name;
                    ExternalOrganization.Address = externalOrganization.Address;
                    ExternalOrganization.City = externalOrganization.City;
                    ExternalOrganization.Email = externalOrganization.Email;
                    ExternalOrganization.Phone = externalOrganization.Phone;
         
                    return Database.ExternalOrganizationChancelleries.Update(ExternalOrganization, AuthorID);
                }

                else if (ExternalOrganization == null)
                {
                    return Database.ExternalOrganizationChancelleries.Add(externalOrganization, AuthorID);
                }
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public int DeleteExternalOrganization(int id)
        {
            return Database.ExternalOrganizationChancelleries.Delete(id);
        }



        public ExternalOrganizationChancelleryDTO GetExternalOrganization(int id)
        {
            var ExternalOrganization = Database.ExternalOrganizationChancelleries.Find(id);

            if (ExternalOrganization == null)
                throw new ValidationException("Отсутствует папка", "");

            return MappExternalOrganizationToExternalOrganizationDTO(ExternalOrganization);

        }

        public IEnumerable<ExternalOrganizationChancelleryDTO> GetExternalOrganizationsChancellery()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExternalOrganizationChancellery, ExternalOrganizationChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ExternalOrganizationChancellery>, List<ExternalOrganizationChancelleryDTO>>(Database.ExternalOrganizationChancelleries.GetAll());
        }


        ExternalOrganizationChancelleryDTO MappExternalOrganizationToExternalOrganizationDTO(ExternalOrganizationChancellery ExternalOrganization)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExternalOrganizationChancellery, ExternalOrganizationChancelleryDTO>()).CreateMapper();
            return mapper.Map<ExternalOrganizationChancellery, ExternalOrganizationChancelleryDTO>(ExternalOrganization);
        }


        ExternalOrganizationChancellery MappExternalOrganizationDTOToExternalOrganization(ExternalOrganizationChancelleryDTO ExternalOrganizationDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancellery>()).CreateMapper();
            return mapper.Map<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancellery>(ExternalOrganizationDto);
        }


        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
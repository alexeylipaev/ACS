using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Interfaces;
using AutoMapper;
using ACS.DAL.Entities;
using ACS.BLL.Infrastructure;
using System.Diagnostics;
using System.Collections;

namespace ACS.BLL.Services
{
    public class TypeRecordChancelleryService : ServiceBase, ITypeRecordChancelleryService
    {
        public TypeRecordChancelleryService(IUnitOfWork uow) : base(uow) { }

        public int CreateOrUpdateTypeRecordChancellery(TypeRecordChancelleryDTO TypeRecordChancelleryDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var typeRecord = MappTypeRecordDTOToTypeRecord(TypeRecordChancelleryDTO);

                var TypeRecord = Database.TypeRecordChancelleries.Find(TypeRecordChancelleryDTO.id);

                if (TypeRecord != null && TypeRecord.Name != typeRecord.Name)
                {
                    TypeRecord.Name = typeRecord.Name;
                    return Database.TypeRecordChancelleries.Update(TypeRecord, AuthorID);
                }

                else if (TypeRecord == null)
                {
                    return Database.TypeRecordChancelleries.Add(typeRecord, AuthorID);
                }
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

       

        public int DeleteTypeRecordChancellery(int id)
        {
            return Database.TypeRecordChancelleries.Delete(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<ChancelleryDTO> GetChancelleriesByType(int TypeRecordChancelleryId)
        {
            var chancy = Database.Chancelleries.Query(filter: ch => ch.TypeRecordChancellery.id == TypeRecordChancelleryId).ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chancellery, ChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<IEnumerable<Chancellery>, List<ChancelleryDTO>>(chancy);
        }

        public IEnumerable<TypeRecordChancelleryDTO> GetTypesRecordChancellery()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Chancellery, ChancelleryDTO >();
                cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>();
                cfg.CreateMap<FromChancellery, FromChancelleryDTO>();
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<ApplicationUser, ApplicationUserDTO>();
                cfg.CreateMap<ExternalOrganizationChancellery, ExternalOrganizationChancelleryDTO>();
                cfg.CreateMap<ToChancelleryDTO, ToChancelleryDTO>();
                cfg.CreateMap<TypeRecordChancellery,TypeRecordChancelleryDTO>();
            }).CreateMapper();

            return MapDALBLL.GetMapp().Map<IEnumerable<TypeRecordChancellery>, List<TypeRecordChancelleryDTO>>(Database.TypeRecordChancelleries.GetAll());
        }

        public TypeRecordChancelleryDTO GetTypeRecordChancellery(int id)
        {
            var type = Database.TypeRecordChancelleries.Find(id);

            if (type == null)
                throw new ValidationException("Отсутствует тип", "");

            return MappTypeRecordToTypeRecordDTO(type);
        }


        TypeRecordChancelleryDTO MappTypeRecordToTypeRecordDTO(TypeRecordChancellery TypeRecord)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Chancellery, ChancelleryDTO>();
                cfg.CreateMap<TypeRecordChancellery, TypeRecordChancelleryDTO>();
            }).CreateMapper();


           var dto = MapDALBLL.GetMapp().Map<TypeRecordChancellery, TypeRecordChancelleryDTO>(TypeRecord);
            return dto;
        }


        TypeRecordChancellery MappTypeRecordDTOToTypeRecord(TypeRecordChancelleryDTO TypeRecordDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancellery>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<TypeRecordChancelleryDTO, TypeRecordChancellery>(TypeRecordDto);
        }

        public TypeRecordChancelleryDTO GetTypeRecordByName(string nameType)
        {
            TypeRecordChancellery result = Database.TypeRecordChancelleries.Query(filter: t => t.Name == nameType).FirstOrDefault();
            return MappTypeRecordToTypeRecordDTO(result);
        }
    }
}

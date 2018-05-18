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
                var typeRecord = MapDALBLL.GetMapp().Map<TypeRecordChancelleryDTO , TypeRecordChancellery>(TypeRecordChancelleryDTO);

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
        
            return MapDALBLL.GetMapp().Map<IEnumerable<Chancellery>, List<ChancelleryDTO>>(chancy);
        }


        public TypeRecordChancelleryDTO GetTypeRecordChancellery(int id)
        {
            var type = Database.TypeRecordChancelleries.Find(id);

            if (type == null)
                throw new ValidationException("Отсутствует тип", "");

            return MapDALBLL.GetMapp().Map<TypeRecordChancellery, TypeRecordChancelleryDTO>(type);
        }

        public TypeRecordChancelleryDTO GetTypeRecordByName(string nameType)
        {
            TypeRecordChancellery result = Database.TypeRecordChancelleries.Query(filter: t => t.Name == nameType).FirstOrDefault();
            return MapDALBLL.GetMapp().Map<TypeRecordChancellery, TypeRecordChancelleryDTO>(result);
        }

        public IEnumerable<TypeRecordChancelleryDTO> GetTypesRecordChancellery()
        {
            return MapDALBLL.GetMapp().Map<IEnumerable<TypeRecordChancellery>, List<TypeRecordChancelleryDTO >>(Database.TypeRecordChancelleries.GetAll());
        }
    }
}

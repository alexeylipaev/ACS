using ACS.BLL.Interfaces;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using ACS.DAL.Entities;

namespace ACS.BLL.Services
{
    public class TypeRecordChancelleryService : ServiceBase, ITypeRecordChancelleryService
    {
        public TypeRecordChancelleryService(IUnitOfWork uow) : base(uow) { }

        public async Task<int> CreateOrUpdateAsync(TypeRecordCorrespondencesDTO typeDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var type = Database.TypeRecordChancelleries.Find(typeDTO.Id);
                type =  MapChancellery.TypeDTOToType(typeDTO);

                InitSystemData<TypeRecordChancellery>.Init(ref type, AuthorID);

                return await Database.TypeRecordChancelleries.AddOrUpdateAsync(type);
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Database.TypeRecordChancelleries.DeleteAsync(id);
        }


        public async Task<TypeRecordCorrespondencesDTO> FindAsync(int id)
        {
            var result = await Database.TypeRecordChancelleries.FindAsync(id);

            return MapChancellery.TypeToTypeDTO(result);
        }

        public async Task<IEnumerable<TypeRecordCorrespondencesDTO>> GetAllAsync()
        {
            var resultList = await Database.TypeRecordChancelleries.GetAllAsync();
            return MapChancellery.ListTypeToListTypeDto(resultList);
        }

        public Task<IEnumerable<CorrespondencesBaseDTO>> GetChancelleriesByTypeAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}

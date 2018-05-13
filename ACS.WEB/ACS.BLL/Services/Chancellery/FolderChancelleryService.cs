using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using AutoMapper;
using ACS.DAL.Entities;
using ACS.DAL.Interfaces;
using ACS.BLL.Infrastructure;
using System.Diagnostics;
using System.Collections;

namespace ACS.BLL.Services
{
    public class FolderChancelleryService : ServiceBase, IFolderChancelleryService
    {
        public FolderChancelleryService(IUnitOfWork uow) : base(uow) { }

        FolderChancelleryDTO MappFolderToFolderDTO(FolderChancellery Folder)
        {
            //var mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Chancellery, ChancelleryDTO  > ();
            //    cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>();

            //}).CreateMapper();

            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>()).CreateMapper();
            return MappService.GetMapp().Map<FolderChancellery, FolderChancelleryDTO>(Folder);
        }


        FolderChancellery MappFolderDTOToFolder(FolderChancelleryDTO FolderDto)
        {
            //var mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ChancelleryDTO, Chancellery>();
            //    cfg.CreateMap<FolderChancelleryDTO, FolderChancellery>();

            //}).CreateMapper();
           // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancelleryDTO, FolderChancellery>()).CreateMapper();
            return MappService.GetMapp().Map<FolderChancelleryDTO, FolderChancellery>(FolderDto);
        }

        public IEnumerable<FolderChancelleryDTO> GetFoldersChancellery()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>()).CreateMapper();
            return MappService.GetMapp().Map<IEnumerable<FolderChancellery>, List<FolderChancelleryDTO>>(Database.FolderChancelleries.GetAll());
        }

        public FolderChancelleryDTO GetFolderChancellery(int id)
        {
            var Folder = Database.FolderChancelleries.Find(id);

            if (Folder == null)
                throw new ValidationException("Отсутствует папка", "");

            return MappFolderToFolderDTO(Folder);
        }

       
        public int CreateOrUpdateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail)
        {
 
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var folder = MappFolderDTOToFolder(FolderChancelleryDTO);

                var Folder = Database.FolderChancelleries.Find(FolderChancelleryDTO.id);

                if (Folder != null && Folder.Name != folder.Name)
                {
                    Folder.Name = folder.Name;
                    return Database.FolderChancelleries.Update(Folder, AuthorID);
                }
                   
                else if (Folder == null)
                {
                    return Database.FolderChancelleries.Add(folder, AuthorID);
                }
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }


        public void Dispose()
        {
            Database.Dispose();
        }


        public IEnumerable<ChancelleryDTO> GetChancelleriesInForlder(int folderId)
        {
            var chancy = Database.Chancelleries.Query(filter: ch => ch.FolderChancellery.id == folderId).ToList();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Chancellery, ChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Chancellery>, List<ChancelleryDTO>>(chancy);
        }


        public int DeleteFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO)
        {
           return Database.FolderChancelleries.Delete(FolderChancelleryDTO.id);
        }
    }
}

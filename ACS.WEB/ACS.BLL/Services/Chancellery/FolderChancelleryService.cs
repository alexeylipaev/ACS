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

namespace ACS.BLL.Services
{
    public class FolderChancelleryService : IFolderChancelleryService
    {
        IUnitOfWork Database { get; set; }

        public FolderChancelleryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<FolderChancelleryDTO> GetFoldersChancellery()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<FolderChancellery>, List<FolderChancelleryDTO>>(Database.FolderChancelleries.GetAll());
        }

        public FolderChancelleryDTO GetFolderChancellery(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id папки ", "");

            var Folder = Database.FolderChancelleries.Get(id.Value);

            if (Folder == null)
                throw new ValidationException("Отсутствует папка", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancellery, FolderChancelleryDTO>()).CreateMapper();
            return mapper.Map<FolderChancellery, FolderChancelleryDTO>(Folder);
        }

        public void MakeFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateFolderChancellery(FolderChancelleryDTO FolderChancelleryDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

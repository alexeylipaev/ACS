
using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using AutoMapper;
using ACS.DAL.Entities;
using ACS.BLL.Infrastructure;
using ACS.DAL.Interfaces;

namespace ACS.BLL.Services
{
    public class FileRecordChancelleryService : IFileRecordFileRecordChancelleryService
    {
        IUnitOfWork Database { get; set; }

        public FileRecordChancelleryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<FileRecordChancelleryDTO> GetFilesRecordChancellery()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<FileRecordChancellery>, List<FileRecordChancelleryDTO>>(Database.FileRecordChancelleries.GetAll());
        }

        public FileRecordChancelleryDTO GetFileRecordChancellery(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id файла ", "");

            var File = Database.FileRecordChancelleries.Find(id.Value);

            if (File == null)
                throw new ValidationException("Отсутствует ссылка на файл", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return mapper.Map<FileRecordChancellery, FileRecordChancelleryDTO>(File);
        }

        public void MakeFileRecordChancellery(FileRecordChancelleryDTO FileRecordChancelleryDto, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void UpdateFileRecordChancellery(FileRecordChancelleryDTO FileRecordChancelleryDto, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}

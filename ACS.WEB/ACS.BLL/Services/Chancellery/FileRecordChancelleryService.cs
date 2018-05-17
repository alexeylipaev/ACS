
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
using System.Web;
using System.IO;

namespace ACS.BLL.Services
{
    public class FileRecordChancelleryService : ServiceBase, IFileRecordChancelleryService
    {
        public FileRecordChancelleryService(IUnitOfWork uow) : base(uow) { }

        public int CreateOrUpdateFileRecord(FileRecordChancelleryDTO FileRecordChancelleryDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var fileRecord = MappFileRecordDTOToFileRecord(FileRecordChancelleryDTO);

                var FileRecord = Database.FileRecordChancelleries.Find(FileRecordChancelleryDTO.id);

                if (FileRecord != null)
                {
                    FileRecord.Name = fileRecord.Name;
                    FileRecord.Format = fileRecord.Format;
                    FileRecord.Path = FileRecord.Path;

                    return Database.FileRecordChancelleries.Update(FileRecord, AuthorID);
                }

                else if (FileRecord == null)
                {
                    return Database.FileRecordChancelleries.Add(fileRecord, AuthorID);
                }
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public int DeleteFileRecord(int id)
        {
            return Database.FileRecordChancelleries.Delete(id);
        }


        public FileRecordChancelleryDTO GetFileRecord(int id)
        {
            var FileRecord = Database.FileRecordChancelleries.Find(id);

            if (FileRecord == null)
                throw new ValidationException("Файл отсутствует", "");

            return MappFileRecordToFileRecordDTO(FileRecord);

        }

        public IEnumerable<FileRecordChancelleryDTO> GetFilesRecordChancellery()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<IEnumerable<FileRecordChancellery>, List<FileRecordChancelleryDTO>>(Database.FileRecordChancelleries.GetAll());
        }


        FileRecordChancelleryDTO MappFileRecordToFileRecordDTO(FileRecordChancellery FileRecord)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancellery, FileRecordChancelleryDTO>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<FileRecordChancellery, FileRecordChancelleryDTO>(FileRecord);
        }


        FileRecordChancellery MappFileRecordDTOToFileRecord(FileRecordChancelleryDTO FileRecordDto)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancellery>()).CreateMapper();
            return MapDALBLL.GetMapp().Map<FileRecordChancelleryDTO, FileRecordChancellery>(FileRecordDto);
        }


        public void Dispose()
        {
            Database.Dispose();
        }

        public IEnumerable<FileRecordChancelleryDTO> AddFiles(IEnumerable<HttpPostedFileBase> httpPostedFileBases)
        {
            List<FileRecordChancelleryDTO> resultFiles = new List<DTO.FileRecordChancelleryDTO>();
            foreach (var file in httpPostedFileBases)
            {
                string pathForSave = BusinessModels.Chancellery.Constants.FolderPath;

                //Возвращает имя файла указанной строки пути без расширения.
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);

                //Возвращает расширение указанной строки пути.
                string extension = Path.GetExtension(file.FileName);

                string path = Path.Combine(pathForSave, fileName + extension);

                
                FileRecordChancelleryDTO fileDTO = new FileRecordChancelleryDTO();
                fileDTO.Name = fileName;
                fileDTO.Path = path;
                fileDTO.Format = extension;
                fileDTO.DataString = DateTime.Now.ToString("ddMMyyyyhhmmssfff");



                path = Path.Combine(pathForSave, fileDTO.Name + fileDTO.DataString + extension);

                file.SaveAs(path);
                resultFiles.Add(fileDTO);
            }
            return resultFiles;
        }


        //public FileRecordChancelleryDTO DownloadFile(int id)
        //{

        //}

        //public FileRecordChancelleryDTO OpenFileNewTab(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

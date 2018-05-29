using ACS.BLL.Interfaces;
using ACS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACS.BLL.DTO;
using System.Web;
using System.IO;
using ACS.BLL.Infrastructure;

namespace ACS.BLL.Services
{
    public class FilesService : ServiceBase, IFilesSevice
    {
        public FilesService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<FilesDTO> AddFiles(IEnumerable<HttpPostedFileBase> httpPostedFileBases)
        {
            List<FilesDTO> resultFiles = new List<DTO.FilesDTO>();
            foreach (var file in httpPostedFileBases)
            {
                string pathForSave = BusinessModels.Constants.FolderPath;

                //Возвращает имя файла указанной строки пути без расширения.
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);

                //Возвращает расширение указанной строки пути.
                string extension = Path.GetExtension(file.FileName);

                string path = Path.Combine(pathForSave, fileName + extension);

                FilesDTO fileDTO = new FilesDTO();
                fileDTO.FileName = fileName;
                fileDTO.Path = path;
                fileDTO.Extension = extension;
               

                path = Path.Combine(pathForSave, fileDTO.FileName + fileDTO.DataString + extension);

                file.SaveAs(path);
                resultFiles.Add(fileDTO);
            }
            return resultFiles;
        }

        public async Task<int> CreateOrUpdateAsync(FilesDTO FilesDTO, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            try
            {
                var file = Database.Files.Find(FilesDTO.Id);
                file = MapFile.FileDTOToFile(FilesDTO);
                return await Database.Files.AddOrUpdateAsync(file, AuthorID);
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Database.Files.DeleteAsync(id);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public async Task<FilesDTO> FindAsync(int id)
        {
            var FileRecord = await Database.Files.FindAsync(id);

            if (FileRecord == null)
                throw new ValidationException("Файл отсутствует", "");

            return MapFile.FileToFileDTO(FileRecord);
        }

        public async Task<IEnumerable<FilesDTO>> GetAllFilesChancelleryAsync(CorrespondencesBaseDTO Chancellery)
        {
            var Files = (from file in Chancellery.FileRecordChancelleries
                         select file);

            if (Files == null)
                throw new ValidationException("Запись не содержит файлов", "");

            var files =  await Database.Files.ToListAsync();

            return MapFile.ListFileToListFileDto(files.Where(m => Files.Contains(m.Id))); 
        }


        public Task<FilesDTO> GetFileChancellerByPathAsync(string Path, int ChancelleryId)
        {
            throw new NotImplementedException();
        }
    }
}

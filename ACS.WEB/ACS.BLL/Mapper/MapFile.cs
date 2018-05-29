using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACS.BLL
{

    public static class MapFile
    {
        public static DAL.Entities.Files FileDTOToFile(DTO.FilesDTO fileDTO)         {
            DAL.Entities.Files file = MapDB.Db.Files.Find(fileDTO.Id);
            if (file == null) file = new DAL.Entities.Files();
            file.Id = fileDTO.Id;
            file.Extension = fileDTO.Extension;
            file.FileName = fileDTO.FileName;
            file.Path = fileDTO.Path;

            return file;
        }
        public static DTO.FilesDTO FileToFileDTO(DAL.Entities.Files file)         {
            DTO.FilesDTO fileDTO = new DTO.FilesDTO();
            fileDTO.Id = file.Id;
            fileDTO.Extension = file.Extension;
            fileDTO.FileName = file.FileName;
            fileDTO.Path = file.Path;
            BLL.MapSystemParam<DAL.Entities.Files, DTO.FilesDTO>.FillParamDTO(file, ref fileDTO);
            return fileDTO;
        }
        public static List<DTO.FilesDTO> ListFileToListFileDto(IEnumerable<DAL.Entities.Files> Files)
        {
            List<DTO.FilesDTO> result = new List<DTO.FilesDTO>();

            foreach (var file in Files)
                result.Add(FileToFileDTO(file));

            return result;
        }

    }
}

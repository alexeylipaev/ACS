using ACS.BLL.DTO;
using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACS.DAL.Interfaces;
using ACS.BLL.BusinessModels;
using System.Web;
using System.IO;
using ACS.DAL.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace ACS.BLL.Services
{
    public class ChancelleryService : ServiceBase, IChancelleryService
    {
        private IExternalOrganizationService ExternalOrganizationService;
        private IEmployeeService EmployeeService;
        private IJournalRegistrationsChancelleryService JournalRegistrationsChancelleryService;
        private IFolderChancelleryService FolderChancelleryService;
        private ITypeRecordChancelleryService TypeRecordChancelleryService;
        private IFilesSevice FilesService;

        public ChancelleryService(IUnitOfWork uow) : base(uow)
        {
            ExternalOrganizationService = new ExternalOrganizationService(uow);
            EmployeeService = new EmployeeService(uow);
            JournalRegistrationsChancelleryService = new JournalRegistrationsChancelleryService(uow);
            FolderChancelleryService = new FolderChancelleryService(uow);
            TypeRecordChancelleryService = new TypeRecordChancelleryService(uow);
            FilesService = new FilesService(uow);
        }

        #region files
        public IEnumerable<FilesDTO> AttachFiles(IEnumerable<HttpPostedFileBase> httpPostedFileBases, string authorEmail)
        {
            return FilesService.AddFiles(httpPostedFileBases);
        }

        public int AttachFiles(IEnumerable<HttpPostedFileBase> files, int ChancelleryId, string authorEmail)
        {
            foreach (var file in files)
            {
                if (file != null)
                {

                    string pathForSave = BusinessModels.Constants.FolderPath;

                    //Возвращает имя файла указанной строки пути без расширения.
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
                    //fileVM.Name = fileName;

                    //Возвращает расширение указанной строки пути.
                    string extension = System.IO.Path.GetExtension(file.FileName);

                    //fileVM.Format = extension;

                    //fileVM.Path = @"X:/Подразделения/СВиССА/Файлы канцелярии/" + fileName;
                    string path = System.IO.Path.Combine(pathForSave, fileName + extension);

                    FilesDTO fileDTO = null;/* = this.GetFileChancellerByPath(path, ChancelleryId);*/

                    if (fileDTO == null)
                    {
                        fileDTO = new FilesDTO();
                        fileDTO.FileName = fileName;
                        fileDTO.Path = path;
                        fileDTO.Extension = extension;
                    }

                    path = Path.Combine(pathForSave, fileDTO.FileName + fileDTO.DataString + extension);

                    file.SaveAs(path);
                    return this.AttachOrDetachFile(fileDTO, authorEmail, ChancelleryId, true);
                }
            }
            return 0;
        }

        public int AttachOrDetachFile(FilesDTO fileDTO, string authorEmail, int ChancelleryId, bool attach)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            DAL.Entities.Files file = Database.Files.Find(fileDTO.Id);

            if (file == null)//файла нет, создать нужно
            {
                file = MapFile.FileDTOToFile(fileDTO);

                var Chancy = Database.Chancelleries.Find(ChancelleryId);

                Chancy.FileRecordChancelleries.Add(file);

                Database.Chancelleries.AddOrUpdate(Chancy, AuthorID);

            }
            else // файл есть
            {
                try
                {
                    file = MapFile.FileDTOToFile(fileDTO);

                    if (attach) // прикрепить
                        file.s_InBasket = false;
                    else
                    {
                        file.FileName += "_dtch";
                        file.s_InBasket = true;// открепить
                    }

                    return Database.Files.AddOrUpdate(file, AuthorID);

                }
                catch (Exception e)
                {
                    CatchError(e);
                }
            }

            return 0;
        }

        public int AttachOrDetachFiles(IEnumerable<FilesDTO> filesDto, string authorEmail, int ChancelleryId, bool attach)
        {
            int result = 0;
            foreach (var fileDTO in filesDto)
            {
                result += AttachOrDetachFile(fileDTO, authorEmail, ChancelleryId, attach);
            }
            return result;
        }

        #endregion

        #region  Search

        private bool SearchOnBaseParam(ChancellerySearchModel searchModel, Chancellery chancellery, ref bool boolResult)
        {
            if (searchModel.Id.HasValue)
            {
                boolResult = (chancellery.Id == searchModel.Id);
                if (!boolResult) return boolResult;
            }
            if (searchModel.TypeRecordId.HasValue)
            {
                boolResult = (chancellery.TypeRecordChancellery.Id == searchModel.TypeRecordId);
                if (!boolResult) return boolResult;
            }
            if (searchModel.RegistryDateFrom.HasValue)
            {
                boolResult = chancellery.DateRegistration >= searchModel.RegistryDateFrom;
                if (!boolResult) return boolResult;
            }
            if (searchModel.RegistryDateTo.HasValue)
            {
                boolResult = chancellery.DateRegistration <= searchModel.RegistryDateTo;
                if (!boolResult) return boolResult;
            }
            if (searchModel.FolderId.HasValue)
            {
                boolResult = (chancellery.FolderChancellery != null && chancellery.FolderChancellery.Id == searchModel.FolderId);
                if (!boolResult) return boolResult;
            }
            if (!string.IsNullOrWhiteSpace(searchModel.ResponsibleContains))
            {
                string toInLower = searchModel.ResponsibleContains.ToLower();
                bool isContainString = false;
                foreach (var item in chancellery.ResponsibleEmployees)
                {
                    if (isContainString) break;
                    if (item != null)
                    {
                        string fullNameInLower = item.FullName.ToLower();
                        isContainString = fullNameInLower.Contains(toInLower);
                    }
                }
                boolResult = isContainString;
                if (!boolResult) return boolResult;
            }
            return boolResult;
        }
        private bool SearchOnIncomingParam(ChancellerySearchModel searchModel, Chancellery chancellery, ref bool boolResult)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.FromContains))
            {
                string fromInLower = searchModel.FromContains.ToLower();

                boolResult = Database.FromExtlOrgsChancellery.Any(f =>
                chancellery.Id == f.ChancelleryId &&
                f.ExternalOrganization.Name.ToLower().Contains(fromInLower));

                if (!boolResult) return boolResult;
            }

            if (!string.IsNullOrWhiteSpace(searchModel.ToContains))
            {
                string toInLower = searchModel.ToContains.ToLower();

                boolResult = Database.ToEmplsChancellery.Any(f =>
                chancellery.Id == f.ChancelleryId &&
                f.Employee.FullName.ToLower().Contains(toInLower));

                if (!boolResult) return boolResult;
            }

            return boolResult;
        }
        private bool SearchOnOutgoingParam(ChancellerySearchModel searchModel, Chancellery chancellery, ref bool boolResult)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.FromContains))
            {
                string fromInLower = searchModel.FromContains.ToLower();

                boolResult = Database.FromEmplsChancellery.Any(f =>
                chancellery.Id == f.ChancelleryId &&
                f.Employee.FullName.ToLower().Contains(fromInLower));

                if (!boolResult) return boolResult;
            }

            if (!string.IsNullOrWhiteSpace(searchModel.ToContains))
            {
                string toInLower = searchModel.ToContains.ToLower();

                boolResult = Database.ToExtlOrgsChancellery.Any(f =>
                chancellery.Id == f.ChancelleryId &&
                f.ExternalOrganization.Name.ToLower().Contains(toInLower));

                if (!boolResult) return boolResult;
            }

            return boolResult;
        }
        private bool SearchOnInternalParam(ChancellerySearchModel searchModel, Chancellery chancellery, ref bool boolResult)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.FromContains))
            {
                string fromInLower = searchModel.FromContains.ToLower();

                boolResult = Database.FromEmplsChancellery.Any(f =>
                chancellery.Id == f.ChancelleryId &&
                f.Employee.FullName.ToLower().Contains(fromInLower));

                if (!boolResult) return boolResult;
            }

            if (!string.IsNullOrWhiteSpace(searchModel.ToContains))
            {
                string toInLower = searchModel.ToContains.ToLower();

                boolResult = Database.ToEmplsChancellery.Any(f =>
                chancellery.Id == f.ChancelleryId &&
                f.Employee.FullName.ToLower().Contains(toInLower));

                if (!boolResult) return boolResult;
            }

            return boolResult;
        }

        public IEnumerable<Chancellery> GetIncomingAllOnSearch(ChancellerySearchModel searchModel)
        {
            Func<Chancellery, Boolean> predicate = (chancellery) =>
            {
                bool boolResult = false;
                if (searchModel != null)
                {
                    boolResult = SearchOnBaseParam(searchModel, chancellery, ref boolResult) &&
                  SearchOnIncomingParam(searchModel, chancellery, ref boolResult);


         
                }
                return boolResult;
            };

            var chies = Database.Chancelleries.ToList();

            return chies.Where(predicate);

            //ParameterExpression registryDateLess = Expression.Parameter(typeof(DateTime), "registryDate");
            //ConstantExpression regDateLess = Expression.Constant(searchModel.RegistryDateFrom, typeof(DateTime));
            //BinaryExpression registryDateLessThanFive = Expression.LessThan(registryDateLess, regDateLess);
            //Expression<Func<Chancellery, bool>> searchExpression = c =>
            // searchModel.RegistryDateFrom != null ? c.DateRegistration >= searchModel.RegistryDateFrom : c.Id > 0 &&
            // searchModel.RegistryDateTo != null ? c.DateRegistration <= searchModel.RegistryDateTo : c.Id > 0 &&
            // searchModel.TypeRecordId != null ? c.TypeRecordChancelleryId >= searchModel.TypeRecordId : c.Id > 0 &&
            // searchModel.FolderId != null ? c.FolderChancelleryId >= searchModel.FolderId : c.Id > 0;

            //    //Expression.Lambda<Func<Chancellery, bool>>(
            //    //    registryDateLessThanFive,
            //    //    new ParameterExpression[] { registryDateLess });
            ////Expression<Func<Chancellery, bool>> expr = mc => predicate(mc);
            //return Database.Chancelleries.Query(searchExpression);
        }


        public IEnumerable<Chancellery> GetOutgoingAllOnSearch(ChancellerySearchModel searchModel)
        {
            Func<Chancellery, Boolean> predicate = (chancellery) =>
            {
                bool boolResult = false;
                if (searchModel != null)
                {
                    if (!boolResult) return SearchOnBaseParam(searchModel, chancellery, ref boolResult);
                    if (!boolResult) return SearchOnOutgoingParam(searchModel, chancellery, ref boolResult);
                }
                return boolResult;
            };
            return Database.Chancelleries.Find(predicate);
        }



        public IEnumerable<Chancellery> GetInternalAllOnSearch(ChancellerySearchModel searchModel)
        {
            Func<Chancellery, Boolean> predicate = (chancellery) =>
            {
                bool boolResult = false;
                if (searchModel != null)
                {
                    if (!boolResult) return SearchOnBaseParam(searchModel, chancellery, ref boolResult);
                    if (!boolResult) return SearchOnInternalParam(searchModel, chancellery, ref boolResult);
                }
                return boolResult;
            };
            return Database.Chancelleries.Find(predicate);
        }

        /// <summary>
        /// поиск по всем типам
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public IEnumerable<Chancellery> GetAllOnSearch(ChancellerySearchModel searchModel)
        {
            Func<Chancellery, Boolean> predicate = (chancellery) =>
            {
                bool boolResult = false;
                if (searchModel != null)
                {
                    if (!boolResult) return SearchOnBaseParam(searchModel, chancellery, ref boolResult);
                    if (!boolResult) return SearchOnIncomingParam(searchModel, chancellery, ref boolResult);
                    if (!boolResult) return SearchOnInternalParam(searchModel, chancellery, ref boolResult);
                    if (!boolResult) return SearchOnOutgoingParam(searchModel, chancellery, ref boolResult);
                }
                return boolResult;
            };
            //Expression<Func<Chancellery, bool>> expr = mc => predicate(mc);
            return Database.Chancelleries.Find(predicate);
        }

        #endregion

        public async Task<IEnumerable<IncomingCorrespondencyDTO>> ChancelleryGetAllIncomingAsync(ChancellerySearchModel searchModel)
        {
            searchModel.TypeRecordId = (byte)Constants.CorrespondencyType.Incoming;
            var chancelleries = GetIncomingAllOnSearch(searchModel);
            return await MapChancellery.ListChancelleryToListIncomingDTOAsync(chancelleries);
        }

        public async Task<IEnumerable<InternalCorrespondencyDTO>> ChancelleryGetAllInternalAsync(ChancellerySearchModel searchModel)
        {
            searchModel.TypeRecordId = (byte)Constants.CorrespondencyType.Internal;
            var chancelleries = GetInternalAllOnSearch(searchModel);
            return await MapChancellery.ListChancelleryToListInternalDTOAsync(chancelleries);
        }

        public async Task<IEnumerable<OutgoingCorrespondencyDTO>> ChancelleryGetAllOutgoingAsync(ChancellerySearchModel searchModel)
        {
            searchModel.TypeRecordId = (byte)Constants.CorrespondencyType.Outgoing;
            var chancelleries = GetOutgoingAllOnSearch(searchModel);
            return await MapChancellery.ListChancelleryToListOutgoingDTOAsync(chancelleries);
        }

        //TODO: проверить возможность создания объектов from и to при добавлении в базу данных канцелярской записи
        public async Task<int> ChancelleryCreateOrUpdateIncomingAsync(IncomingCorrespondencyDTO incomingCorrespondencyDto, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            FromExtlOrgChancellery fromExtlOrgChancellery = null;
            ToEmplChancellery toEmplChancellery = null;

            try
            {
                var chancellery = Database.Chancelleries.Find(incomingCorrespondencyDto.Id);
                chancellery = await MapChancellery.IncomingToChancelleryAsync(incomingCorrespondencyDto, fromExtlOrgChancellery, toEmplChancellery);
                return await Database.Chancelleries.AddOrUpdateAsync(chancellery, AuthorID);

            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> ChancelleryCreateOrUpdateInternalAsync(InternalCorrespondencyDTO internalCorrespondencyDto, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            FromEmplChancellery fromEmplChancellery = null;
            List<ToEmplChancellery> toEmplChancelleryList = null;

            try
            {
                var chancellery = Database.Chancelleries.Find(internalCorrespondencyDto.Id);
                chancellery = await MapChancellery.InternalToChancelleryAsync(internalCorrespondencyDto, fromEmplChancellery, toEmplChancelleryList);
                return await Database.Chancelleries.AddOrUpdateAsync(chancellery, AuthorID);

            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> ChancelleryCreateOrUpdateOutgoingAsync(OutgoingCorrespondencyDTO outgoingCorrespondencyDto, string authorEmail)
        {
            int AuthorID = 0;
            try { AuthorID = CheckAuthorAndGetIndexAuthor(authorEmail); }
            catch (Exception ex) { throw ex; }

            FromEmplChancellery fromEmplChancellery = null;
            List<ToExtlOrgChancellery> toExtlOrgChancelleryList = null;

            try
            {
                var chancellery = Database.Chancelleries.Find(outgoingCorrespondencyDto.Id);
                chancellery = await MapChancellery.OutgoingToChancelleryAsync(outgoingCorrespondencyDto, fromEmplChancellery, toExtlOrgChancelleryList);
                return await Database.Chancelleries.AddOrUpdateAsync(chancellery, AuthorID);
            }
            catch (Exception e)
            {
                CatchError(e);
            }

            return 0;
        }

        public async Task<int> CreateOrUpdate_TypeChancellery(TypeRecordCorrespondencesDTO typeDTO, string authorEmail)
        {
            return await TypeRecordChancelleryService.CreateOrUpdateAsync(typeDTO, authorEmail);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await Database.Chancelleries.DeleteAsync(id);
        }

        public int DeletedFile(FilesDTO fileDTO)
        {
            int result = 0;
            try
            {
                File.Delete(fileDTO.Path);
                result++;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;
        }

        public int DeletedFiles(IEnumerable<FilesDTO> filesDto)
        {
            int result = 0;
            foreach (var file in filesDto)
            {
                result += DeletedFile(file);
            }

            return result;
        }

        public Task<int> DeleteTypeChancellery(int typeId)
        {
            return TypeRecordChancelleryService.DeleteAsync(typeId);
        }

        public async Task<IncomingCorrespondencyDTO> FindIncomingAsync(int id)
        {
            var result = await Database.Chancelleries.FindAsync(id);
            return await MapChancellery.ChancelleryToIncomingDTOAsync(result);
        }
        public async Task<OutgoingCorrespondencyDTO> FindOutgoingAsync(int id)
        {
            var result = await Database.Chancelleries.FindAsync(id);
            return await MapChancellery.ChancelleryToOutgoingDTOAsync(result);
        }
        public async Task<InternalCorrespondencyDTO> FindInternalAsync(int id)
        {
            var result = await Database.Chancelleries.FindAsync(id);
            return await MapChancellery.ChancelleryToInternalDTOAsync(result);
        }

        public async Task<EmployeeDTO> FindEmplAsync(int id)
        {
            return await EmployeeService.FindAsync(id);
        }

        public async Task<ExternalOrganizationDTO> FindExtlOrgAsync(int id)
        {
            return await ExternalOrganizationService.FindAsync(id);

        }

        public async Task<FilesDTO> FindFileAsync(int FileId)
        {
            return await FilesService.FindAsync(FileId);
        }

        public async Task<FolderCorrespondencesDTO> FindFolderAsync(int id)
        {
            return await FolderChancelleryService.FindAsync(id);
        }

        public async Task<JournalRegistrationsCorrespondencesDTO> FindJournalAsync(int id)
        {
            return await JournalRegistrationsChancelleryService.FindAsync(id);
        }

        public async Task<TypeRecordCorrespondencesDTO> FindTypeChancelleryAsync(int id)
        {
            return await TypeRecordChancelleryService.FindAsync(id);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            return await EmployeeService.GetAllAsync();
        }

        public async Task<IEnumerable<ExternalOrganizationDTO>> GetAllExternalOrganizationsAsync()
        {
            return await ExternalOrganizationService.GetAllAsync();
        }


        public async Task<IEnumerable<FilesDTO>> GetAllFilesChancelleryAsync(CorrespondencesBaseDTO CorrespondencesDTO)
        {
            return await FilesService.GetAllFilesChancelleryAsync(CorrespondencesDTO);
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAllResponsiblesChancelleryAsync(CorrespondencesBaseDTO CorrespondencesDTO)
        {
            return await EmployeeService.GetAllResponsiblesChancelleryAsync(CorrespondencesDTO);
        }

        public async Task<IEnumerable<FolderCorrespondencesDTO>> GetAllFolders()
        {
            return await FolderChancelleryService.GetAllAsync();
        }

        public async Task<IEnumerable<JournalRegistrationsCorrespondencesDTO>> GetAllJournalesRegistrationsAsync()
        {
            return await JournalRegistrationsChancelleryService.GetAllAsync();
        }

        public async Task<IEnumerable<TypeRecordCorrespondencesDTO>> GetAllTypesChancelleryAsync()
        {
            return await TypeRecordChancelleryService.GetAllAsync();
        }

        public async Task<FilesDTO> GetFileChancellerByPathAsync(string Path, int ChancelleryId)
        {
            FilesDTO result = null;
            var files = Database.Files.Query(filter: f => f.Path == Path);

            var Chancelleries = await Database.Chancelleries.ToListAsync();

            foreach (var file in files)
            {
                if (result != null) break;

                var chancellery = (from ch in Chancelleries
                                   from f in ch.FileRecordChancelleries.ToList()
                                   where f.Id == file.Id
                                   select ch).FirstOrDefault();

                if (chancellery != null)
                {
                    result = MapFile.FileToFileDTO(file);
                }
            }
            return result;
        }


        public void Dispose()
        {
            ExternalOrganizationService.Dispose();
            EmployeeService.Dispose();
            JournalRegistrationsChancelleryService.Dispose();
            FolderChancelleryService.Dispose();
            TypeRecordChancelleryService.Dispose();
            FilesService.Dispose();
            Dispose();
        }

        public async Task<ChancelleryDTO> FindAsync(int id)
        {
            var result = await Database.Chancelleries.FindAsync(id);
            return MapChancellery.chancelleryToChancelleryDTO(result);
        }

        public async Task<IEnumerable<ChancelleryDTO>> GetAllAsync()
        {
            var resultList = await Database.Chancelleries.GetAllAsync();
            return MapChancellery.ListChancelleryToListChancelleryDto(resultList);
        }


    }
}

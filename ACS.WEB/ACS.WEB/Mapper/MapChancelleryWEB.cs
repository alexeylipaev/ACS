using ACS.BLL.BusinessModels;
using ACS.BLL.DTO;
using ACS.BLL.Interfaces;
using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ACS.WEB
{
    public static class MapChancelleryWEB
    {

        static IChancelleryService ChancelleryService;

        public static void InitService(IChancelleryService chancelleryService)
        {
            ChancelleryService = chancelleryService;
        }

        private static async Task<IEnumerable<string>> MapFrom(CorrespondencesBaseDTO correspondencesBaseDTO)
        {
            List<string> result = new List<string>();



            switch (correspondencesBaseDTO.TypeRecordChancelleryId)
            {
                case (byte)Constants.CorrespondencyType.Incoming:
                    {
                        var IncomigDto = await ChancelleryService.FindIncomingAsync(correspondencesBaseDTO.Id);
                        if (!IncomigDto.From_ExternalOrganizationChancelleryId.HasValue) return null;
                        var extrExt = await ChancelleryService.FindExtlOrgAsync(IncomigDto.From_ExternalOrganizationChancelleryId.Value);
                        result.Add(extrExt.Name);
                        break;
                    }
                case (byte)Constants.CorrespondencyType.Outgoing:
                    {
                        var OutgoingDto = await ChancelleryService.FindOutgoingAsync(correspondencesBaseDTO.Id);
                        if (!OutgoingDto.From_EmployeeId.HasValue) return null;
                        var empl = await ChancelleryService.FindEmplAsync(OutgoingDto.From_EmployeeId.Value);
                        result.Add(empl.FullName);
                        break;
                    }
                case (byte)Constants.CorrespondencyType.Internal:
                    {
                        var InternalDto = await ChancelleryService.FindInternalAsync(correspondencesBaseDTO.Id);
                        if (!InternalDto.From_EmployeeId.HasValue) return null;
                        var empl = await ChancelleryService.FindEmplAsync(InternalDto.From_EmployeeId.Value);
                        result.Add(empl.FullName);
                        break;
                    }

                default: { break; }
            }

            return result;
        }
        private static async Task<IEnumerable<string>> MapTo(CorrespondencesBaseDTO correspondencesBaseDTO)
        {
            IEnumerable<string> result = new List<string>();

            switch (correspondencesBaseDTO.TypeRecordChancelleryId)
            {
                case (byte)Constants.CorrespondencyType.Incoming:
                    {
                        var IncomingDto = await ChancelleryService.FindIncomingAsync(correspondencesBaseDTO.Id);
                        if (!IncomingDto.To_EmployeeId.HasValue) return null;
                        var empl = await ChancelleryService.FindEmplAsync(IncomingDto.To_EmployeeId.Value);
                        result = new List<string>() { empl.FullName };
                        break;
                    }
                case (byte)Constants.CorrespondencyType.Outgoing:
                    {
                        var OutgoingDto = await ChancelleryService.FindOutgoingAsync(correspondencesBaseDTO.Id);
                        if (OutgoingDto.To_ExtOrgns == null || OutgoingDto.To_ExtOrgns.Count() == 0) return null;

                        var ToExtOrgs = await ChancelleryService.GetAllExternalOrganizationsAsync();


                        result = from extOrgId in OutgoingDto.To_ExtOrgns
                                 from extOrg in ToExtOrgs.Where(d => d.Id == extOrgId)
                                 select extOrg.Name;
                        break;
                    }
                case (byte)Constants.CorrespondencyType.Internal:
                    {
                        var InternalDto = await ChancelleryService.FindInternalAsync(correspondencesBaseDTO.Id);
                        if (InternalDto.To_Employees == null || InternalDto.To_Employees.Count() == 0) return null;

                        var Empls = await ChancelleryService.GetAllEmployeesAsync();


                        result = from emplId in InternalDto.To_Employees
                                 from empl in Empls.Where(d => d.Id == emplId)
                                 select empl.FullName;
                        break;

                    }

                default: { break; }
            }

            return result;
        }


        private static DtoBase CorrespondencesInputToCorrespondencesBaseDTO<DtoBase, InputBase>(DtoBase CorrespondencesBaseDTO, InputBase CorrespondencesBaseInput) where DtoBase : CorrespondencesBaseDTO where InputBase : CorrespondencesBaseInput
        {

            CorrespondencesBaseDTO.Id = CorrespondencesBaseInput.Id;
            CorrespondencesBaseDTO.DateRegistration = CorrespondencesBaseInput.DateRegistration;
            CorrespondencesBaseDTO.RegistrationNumber = CorrespondencesBaseInput.RegistrationNumber;
            CorrespondencesBaseDTO.Summary = CorrespondencesBaseInput.Summary;
            CorrespondencesBaseDTO.Notice = CorrespondencesBaseInput.Notice;
            CorrespondencesBaseDTO.Status = CorrespondencesBaseInput.Status;

            CorrespondencesBaseDTO.FolderChancelleryId = CorrespondencesBaseInput.FolderChancelleryId;
            CorrespondencesBaseDTO.FileRecordChancelleries = CorrespondencesBaseInput.FileRecordChancelleries;
            CorrespondencesBaseDTO.ResponsibleEmployees = CorrespondencesBaseInput.ResponsibleEmployees;
            CorrespondencesBaseDTO.TypeRecordChancelleryId = CorrespondencesBaseInput.TypeRecordChancelleryId;

            return CorrespondencesBaseDTO;
        }

        private static InputBase CorrespondencesBaseDTOToCorrespondencesInput<InputBase, DtoBase>(InputBase CorrespondencesBaseInput, DtoBase CorrespondencesBaseDTO) where InputBase : CorrespondencesBaseInput where DtoBase : CorrespondencesBaseDTO
        {

            CorrespondencesBaseInput.Id = CorrespondencesBaseDTO.Id;
            CorrespondencesBaseInput.DateRegistration = CorrespondencesBaseDTO.DateRegistration;
            CorrespondencesBaseInput.RegistrationNumber = CorrespondencesBaseDTO.RegistrationNumber;
            CorrespondencesBaseInput.Summary = CorrespondencesBaseDTO.Summary;
            CorrespondencesBaseInput.Notice = CorrespondencesBaseDTO.Notice;
            CorrespondencesBaseInput.Status = CorrespondencesBaseDTO.Status;

            CorrespondencesBaseInput.FolderChancelleryId = CorrespondencesBaseDTO.FolderChancelleryId;
            CorrespondencesBaseInput.FileRecordChancelleries = CorrespondencesBaseDTO.FileRecordChancelleries;
            CorrespondencesBaseInput.ResponsibleEmployees = CorrespondencesBaseDTO.ResponsibleEmployees;
            CorrespondencesBaseInput.TypeRecordChancelleryId = CorrespondencesBaseDTO.TypeRecordChancelleryId;

            return CorrespondencesBaseInput;
        }

        public static async Task<ChancelleryViewModel> CorrespondencesBaseDTOToChancelleryVM<T>(T CorrespondencesBaseDTO) where T : CorrespondencesBaseDTO         {

            ChancelleryViewModel chancelleryViewModel = new ChancelleryViewModel();

            chancelleryViewModel.Id = CorrespondencesBaseDTO.Id;
            chancelleryViewModel.DateRegistration = CorrespondencesBaseDTO.DateRegistration;
            chancelleryViewModel.RegistrationNumber = CorrespondencesBaseDTO.RegistrationNumber;
            chancelleryViewModel.Summary = CorrespondencesBaseDTO.Summary;
            chancelleryViewModel.Notice = CorrespondencesBaseDTO.Notice;
            chancelleryViewModel.Status = CorrespondencesBaseDTO.Status;

            var FolderId = CorrespondencesBaseDTO.FolderChancelleryId;
            FolderCorrespondencesDTO folder = null;
            folder = CorrespondencesBaseDTO.FolderChancelleryId != null ? await ChancelleryService.FindFolderAsync(FolderId.Value) : null;
            chancelleryViewModel.Folder = folder.Name;

            var files = await ChancelleryService.GetAllFilesChancelleryAsync(CorrespondencesBaseDTO);
            chancelleryViewModel.Files = from file in files
                                         select file.FileName + file.Extension;


            var responsibles = await ChancelleryService.GetAllResponsiblesChancelleryAsync(CorrespondencesBaseDTO);
            chancelleryViewModel.ResponsibleEmployees = responsibles.Select(f => f.FullName);

            TypeRecordCorrespondencesDTO type = await ChancelleryService.FindTypeChancelleryAsync(CorrespondencesBaseDTO.TypeRecordChancelleryId);
            chancelleryViewModel.Type = type.Name;

            chancelleryViewModel.From = await MapFrom(CorrespondencesBaseDTO);
            chancelleryViewModel.To = await MapTo(CorrespondencesBaseDTO);

            MapSystemParam<T, ChancelleryViewModel>.FillParamDTO(CorrespondencesBaseDTO, ref chancelleryViewModel);

            return chancelleryViewModel;
        }

        #region outgoing

        public static OutgoingCorrespondencyDTO OutgoingInputToOutgoingDTO(OutgoingCorrespondencyInput OutgoingInput)         {
            OutgoingCorrespondencyDTO OutgoingDTO = new OutgoingCorrespondencyDTO();
            OutgoingDTO = CorrespondencesInputToCorrespondencesBaseDTO(OutgoingDTO, OutgoingInput);
            //MapSystemParam<OutgoingCorrespondencyInput, OutgoingCorrespondencyDTO>.FillParamDTO(OutgoingInput, ref OutgoingDTO);
            return OutgoingDTO;
        }
        public static async Task<OutgoingCorrespondencyInput> OutgoingDTOToOutgoingInput(OutgoingCorrespondencyDTO OutgoingCorrespondencyDTO)         {
            OutgoingCorrespondencyInput OutgoingCorrespondencyInput = new OutgoingCorrespondencyInput();
            OutgoingCorrespondencyInput = CorrespondencesBaseDTOToCorrespondencesInput(OutgoingCorrespondencyInput, OutgoingCorrespondencyDTO);

            var FolderId = OutgoingCorrespondencyDTO.FolderChancelleryId;
            FolderCorrespondencesDTO folder = null;
            folder = OutgoingCorrespondencyDTO.FolderChancelleryId != null ? await ChancelleryService.FindFolderAsync(FolderId.Value) : null;
            OutgoingCorrespondencyInput.FolderChancelleryId = folder.Id;

            var files = await ChancelleryService.GetAllFilesChancelleryAsync(OutgoingCorrespondencyDTO);
            OutgoingCorrespondencyInput.FileRecordChancelleries = from file in files
                                                                  select file.Id;


            var responsibles = await ChancelleryService.GetAllResponsiblesChancelleryAsync(OutgoingCorrespondencyDTO);
            OutgoingCorrespondencyInput.ResponsibleEmployees = responsibles.Select(f => f.Id);

            TypeRecordCorrespondencesDTO type = await ChancelleryService.FindTypeChancelleryAsync(OutgoingCorrespondencyDTO.TypeRecordChancelleryId);
            OutgoingCorrespondencyInput.TypeRecordChancelleryId = type.Id;

            OutgoingCorrespondencyInput.From_EmployeeId = OutgoingCorrespondencyDTO.From_EmployeeId;
            OutgoingCorrespondencyInput.To_ExtOrgns = OutgoingCorrespondencyDTO.To_ExtOrgns;

            MapSystemParam<OutgoingCorrespondencyDTO, OutgoingCorrespondencyInput>.FillParamDTO(OutgoingCorrespondencyDTO, ref OutgoingCorrespondencyInput);

            return OutgoingCorrespondencyInput;
        }

        #endregion
        #region Internal

        public static InternalCorrespondencyDTO InternalInputToInternalDTO(InternalCorrespondencyInput InternalInput)         {
            InternalCorrespondencyDTO InternalDTO = new InternalCorrespondencyDTO();
            InternalDTO = CorrespondencesInputToCorrespondencesBaseDTO(InternalDTO, InternalInput);
            //MapSystemParam<InternalCorrespondencyInput, InternalCorrespondencyDTO>.FillParamDTO(InternalInput, ref InternalDTO);
            return InternalDTO;

        }
        public static async Task<InternalCorrespondencyInput> InternalDTOToInternalInput(InternalCorrespondencyDTO InternalCorrespondencyDTO)         {

            InternalCorrespondencyInput InternalCorrespondencyInput = new InternalCorrespondencyInput();
            InternalCorrespondencyInput = CorrespondencesBaseDTOToCorrespondencesInput(InternalCorrespondencyInput, InternalCorrespondencyDTO);

            var FolderId = InternalCorrespondencyDTO.FolderChancelleryId;
            FolderCorrespondencesDTO folder = null;
            folder = InternalCorrespondencyDTO.FolderChancelleryId != null ? await ChancelleryService.FindFolderAsync(FolderId.Value) : null;
            InternalCorrespondencyInput.FolderChancelleryId = folder.Id;

            var files = await ChancelleryService.GetAllFilesChancelleryAsync(InternalCorrespondencyDTO);
            InternalCorrespondencyInput.FileRecordChancelleries = from file in files
                                                                  select file.Id;


            var responsibles = await ChancelleryService.GetAllResponsiblesChancelleryAsync(InternalCorrespondencyDTO);
            InternalCorrespondencyInput.ResponsibleEmployees = responsibles.Select(f => f.Id);

            TypeRecordCorrespondencesDTO type = await ChancelleryService.FindTypeChancelleryAsync(InternalCorrespondencyDTO.TypeRecordChancelleryId);
            InternalCorrespondencyInput.TypeRecordChancelleryId = type.Id;

            InternalCorrespondencyInput.From_EmployeeId = InternalCorrespondencyDTO.From_EmployeeId;
            InternalCorrespondencyInput.To_Employees = InternalCorrespondencyDTO.To_Employees;

            MapSystemParam<InternalCorrespondencyDTO, InternalCorrespondencyInput>.FillParamDTO(InternalCorrespondencyDTO, ref InternalCorrespondencyInput);

            return InternalCorrespondencyInput;
        }

        #endregion
        #region Incoming
        public static IncomingCorrespondencyDTO IncomingInputToIncomingDTO(IncomingCorrespondencyInput IncomingInput)         {
            IncomingCorrespondencyDTO incomingDTO = new IncomingCorrespondencyDTO();
            incomingDTO = CorrespondencesInputToCorrespondencesBaseDTO(incomingDTO, IncomingInput);
            //MapSystemParam<IncomingCorrespondencyInput, IncomingCorrespondencyDTO>.FillParamDTO(IncomingInput, ref incomingDTO);
            return incomingDTO;

        }
        public static async Task<IncomingCorrespondencyInput> IncomingDTOToIncomingInput(IncomingCorrespondencyDTO IncomingCorrespondencyDTO)         {

            IncomingCorrespondencyInput incomingCorrespondencyInput = new IncomingCorrespondencyInput();
            incomingCorrespondencyInput = CorrespondencesBaseDTOToCorrespondencesInput(incomingCorrespondencyInput, IncomingCorrespondencyDTO);

            var FolderId = IncomingCorrespondencyDTO.FolderChancelleryId;
            FolderCorrespondencesDTO folder = null;
            folder = IncomingCorrespondencyDTO.FolderChancelleryId != null ? await ChancelleryService.FindFolderAsync(FolderId.Value) : null;
            incomingCorrespondencyInput.FolderChancelleryId = folder.Id;

            var files = await ChancelleryService.GetAllFilesChancelleryAsync(IncomingCorrespondencyDTO);
            incomingCorrespondencyInput.FileRecordChancelleries = from file in files
                                                                  select file.Id;


            var responsibles = await ChancelleryService.GetAllResponsiblesChancelleryAsync(IncomingCorrespondencyDTO);
            incomingCorrespondencyInput.ResponsibleEmployees = responsibles.Select(f => f.Id);

            TypeRecordCorrespondencesDTO type = await ChancelleryService.FindTypeChancelleryAsync(IncomingCorrespondencyDTO.TypeRecordChancelleryId);
            incomingCorrespondencyInput.TypeRecordChancelleryId = type.Id;

            incomingCorrespondencyInput.From_ExternalOrganizationChancelleryId = IncomingCorrespondencyDTO.From_ExternalOrganizationChancelleryId;
            incomingCorrespondencyInput.To_EmployeeId = IncomingCorrespondencyDTO.To_EmployeeId;

            MapSystemParam<IncomingCorrespondencyDTO, IncomingCorrespondencyInput>.FillParamDTO(IncomingCorrespondencyDTO, ref incomingCorrespondencyInput);

            return incomingCorrespondencyInput;
        }


        #endregion

        public static async Task<List<ChancelleryViewModel>> ListCorrespondencesBaseDTOToListChancelleryVM<T>(IEnumerable<T> correspondencesBaseDTO) where T : CorrespondencesBaseDTO
        {
            List<ChancelleryViewModel> result = new List<ChancelleryViewModel>();

            foreach (var correspondencesBase in correspondencesBaseDTO)
            {
                var VM = await CorrespondencesBaseDTOToChancelleryVM(correspondencesBase);
                result.Add(VM);
            }

            return result;
        }

        public static ChancelleryViewModel chancelleryDtoToChancelleryVM(ChancelleryDTO chancelleryDTO)         {
            ChancelleryViewModel chancelleryViewModel = new ChancelleryViewModel();

            chancelleryViewModel.Id = chancelleryDTO.Id;
            chancelleryViewModel.DateRegistration = chancelleryDTO.DateRegistration;
            chancelleryViewModel.RegistrationNumber = chancelleryDTO.RegistrationNumber;
            chancelleryViewModel.Summary = chancelleryDTO.Summary;
            chancelleryViewModel.Notice = chancelleryDTO.Notice;
            chancelleryViewModel.Status = chancelleryDTO.Status;
            chancelleryViewModel.Folder = chancelleryDTO.Folder;
            chancelleryViewModel.JournalRegistrations = chancelleryDTO.JournalRegistrations;
            chancelleryViewModel.ResponsibleEmployees = chancelleryDTO.ResponsibleEmployees;
            chancelleryViewModel.Type = chancelleryDTO.Type;

            chancelleryViewModel.From = chancelleryDTO.From;
            chancelleryViewModel.To = chancelleryDTO.To;

            MapSystemParam<ChancelleryDTO, ChancelleryViewModel>.FillParamDTO(chancelleryDTO, ref chancelleryViewModel);

            return chancelleryViewModel;
        }
        public static List<ChancelleryViewModel> ListChancelleryDTOToListChancelleryVM(IEnumerable<ChancelleryDTO> ChancelleriesDto)
        {
            List<ChancelleryViewModel> result = new List<ChancelleryViewModel>();

            foreach (var chancelleryDto in ChancelleriesDto)
                result.Add(chancelleryDtoToChancelleryVM(chancelleryDto));

            return result;
        }

        #region journal 
        public static ChancellerySearchModelVM ChancellerySearchModelToChancellerySearchModelVM(ChancellerySearchModel SearchModel)         {
            ChancellerySearchModelVM SearchModelVM = new ChancellerySearchModelVM();

            SearchModelVM.Id = SearchModel.Id;
            //SearchModelVM.Chancelleries = SearchModel.Chancelleries;
            SearchModelVM.FolderId = SearchModel.FolderId;
            SearchModelVM.FromContains = SearchModel.FromContains;
            SearchModelVM.ToContains = SearchModel.ToContains;
            SearchModelVM.RegistryDateFrom = SearchModel.RegistryDateFrom;
            SearchModelVM.RegistryDateTo = SearchModel.RegistryDateTo;
            SearchModelVM.ResponsibleContains = SearchModel.ResponsibleContains;
            SearchModelVM.TypeRecordId = SearchModel.TypeRecordId;

            return SearchModelVM;
        }
        public static List<ChancellerySearchModelVM> ListJChancellerySearchModelToListChancellerySearchModelVM(IEnumerable<ChancellerySearchModel> SearchModels)
        {
            List<ChancellerySearchModelVM> result = new List<ChancellerySearchModelVM>();

            foreach (var SearchModel in SearchModels)
                result.Add(ChancellerySearchModelToChancellerySearchModelVM(SearchModel));

            return result;
        }

        #endregion

        #region folder 

        public static FolderCorrespondencesDTO FolderInputToFolderDto(FolderCorrespondencesInput FolderInput)         {
            FolderCorrespondencesDTO FolderDTO = new FolderCorrespondencesDTO();
            FolderDTO.Id = FolderInput.Id;
            FolderDTO.Name = FolderInput.Name;
            return FolderDTO;
        }


        public static FolderCorrespondencesInput FolderChancelleryDTOToFolderChancelleryInput(FolderCorrespondencesDTO FolderChancelleryDTO)         {
            FolderCorrespondencesInput FolderChancelleryInput = new FolderCorrespondencesInput();
            FolderChancelleryInput.Id = FolderChancelleryDTO.Id;
            FolderChancelleryInput.Name = FolderChancelleryDTO.Name;

            MapSystemParam<FolderCorrespondencesDTO, FolderCorrespondencesInput>.FillParamDTO(FolderChancelleryDTO, ref FolderChancelleryInput);

            return FolderChancelleryInput;
        }

        public static FolderChancelleryViewModel FolderDtoToFolderVM(FolderCorrespondencesDTO folderDto)         {
            FolderChancelleryViewModel journalVM = new FolderChancelleryViewModel();

            journalVM.Id = folderDto.Id;
            journalVM.Name = folderDto.Name;
            journalVM.Chancelleries = string.Join(", ", folderDto.Chancelleries.Select(m => m.ToString()));

            MapSystemParam<FolderCorrespondencesDTO, FolderChancelleryViewModel>.FillParamDTO(folderDto, ref journalVM);
            return journalVM;
        }
        public static List<FolderChancelleryViewModel> ListFolderDTOToListFolderVM(IEnumerable<FolderCorrespondencesDTO> foldersDto)
        {
            List<FolderChancelleryViewModel> result = new List<FolderChancelleryViewModel>();

            foreach (var folderDto in foldersDto)
                result.Add(FolderDtoToFolderVM(folderDto));

            return result;
        }


        #endregion

        #region journal 
        public static JournalRegistrationsCorrespondencesDTO  JournalInputToJournalDto(JournalCorrespondencesInput JournalCorrespondencesInput)         {
            JournalRegistrationsCorrespondencesDTO JournalRegistrationsCorrespondencesDTO = new JournalRegistrationsCorrespondencesDTO();

            JournalRegistrationsCorrespondencesDTO.Id = JournalCorrespondencesInput.Id;
            JournalRegistrationsCorrespondencesDTO.Name = JournalCorrespondencesInput.Name;

            return JournalRegistrationsCorrespondencesDTO;
        }
        public static JournalCorrespondencesInput JournalDtoToJournalInput(JournalRegistrationsCorrespondencesDTO journalDto)         {
            JournalCorrespondencesInput JournalCorrespondencesInput = new JournalCorrespondencesInput();

            JournalCorrespondencesInput.Id = journalDto.Id;
            JournalCorrespondencesInput.Name = journalDto.Name;
           
            MapSystemParam<JournalRegistrationsCorrespondencesDTO, JournalCorrespondencesInput>.FillParamDTO(journalDto, ref JournalCorrespondencesInput);
            return JournalCorrespondencesInput;
        }
        public static JournalRegistrationsViewModel JournalDtoToJournalVM(JournalRegistrationsCorrespondencesDTO journalDto)         {
            JournalRegistrationsViewModel journalVM = new JournalRegistrationsViewModel();

            journalVM.Id = journalDto.Id;
            journalVM.Name = journalDto.Name;
            journalVM.Chancelleries = string.Join(", ", journalDto.Chancelleries.Select(m => m.ToString()));

            MapSystemParam<JournalRegistrationsCorrespondencesDTO, JournalRegistrationsViewModel>.FillParamDTO(journalDto, ref journalVM);
            return journalVM;
        }
        public static List<JournalRegistrationsViewModel> ListJournalDTOToListJournalVM(IEnumerable<JournalRegistrationsCorrespondencesDTO> journalsDto)
        {
            List<JournalRegistrationsViewModel> result = new List<JournalRegistrationsViewModel>();

            foreach (var journal in journalsDto)
                result.Add(JournalDtoToJournalVM(journal));

            return result;
        }

        #endregion

        #region type 

        public static TypeRecordChancelleryViewModel TypeDtoToTypeVM(TypeRecordCorrespondencesDTO typeDto)         {
            TypeRecordChancelleryViewModel typeVM = new TypeRecordChancelleryViewModel();

            typeVM.Id = typeDto.Id;
            typeVM.Name = typeDto.Name;
            typeVM.Chancelleries = string.Join(", ", typeDto.Chancelleries.Select(m => m.ToString()));

            MapSystemParam<TypeRecordCorrespondencesDTO, TypeRecordChancelleryViewModel>.FillParamDTO(typeDto, ref typeVM);
            return typeVM;
        }
        public static List<TypeRecordChancelleryViewModel> ListTypeDTOToListTypeVM(IEnumerable<TypeRecordCorrespondencesDTO> typesDto)
        {
            List<TypeRecordChancelleryViewModel> result = new List<TypeRecordChancelleryViewModel>();

            foreach (var type in typesDto)
                result.Add(TypeDtoToTypeVM(type));

            return result;
        }

        #endregion
    }
}
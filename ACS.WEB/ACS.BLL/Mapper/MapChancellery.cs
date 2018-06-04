using ACS.BLL.BusinessModels;
using ACS.BLL.DTO;
using ACS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.BLL
{
    public static class MapChancellery
    {
        #region DTO_to_DB


        #region journal
        public static async Task<DAL.Entities.JournalRegistrationsChancellery> JournalDTOToJournal(DTO.JournalRegistrationsCorrespondencesDTO journalDto)
        {
            DAL.Entities.JournalRegistrationsChancellery journal = MapDB.Db.JournalRegistrationsChancelleries.Find(journalDto.Id);
            if (journal == null) journal = new DAL.Entities.JournalRegistrationsChancellery();
            journal.Id = journalDto.Id;
            journal.Name = journalDto.Name;

            var chancelleriesDB = await MapDB.Db.Chancelleries.ToListAsync();
            journal.Chancelleries = chancelleriesDB.Select(ch => ch.Id == journal.Id) as ICollection<Chancellery>;

            return journal;
        }
        #endregion

        #region folder

        public static async Task<DAL.Entities.FolderChancellery> FolderDTOToFolder(DTO.FolderCorrespondencesDTO folderDto)
        {
            DAL.Entities.FolderChancellery folder = MapDB.Db.FolderChancelleries.Find(folderDto.Id);
            if (folder == null) folder = new DAL.Entities.FolderChancellery();
            folder.Id = folderDto.Id;
            folder.Name = folderDto.Name;

            var chancelleriesDB = await MapDB.Db.Chancelleries.ToListAsync();
            folder.Chancelleries = chancelleriesDB.Select(ch => ch.Id == folder.Id) as ICollection<Chancellery>;

            return folder;
        }

        #endregion

        #region typeChancellery
        public static async Task<DAL.Entities.TypeRecordChancellery> TypeDTOToType(DTO.TypeRecordCorrespondencesDTO typeDTO)
        {
            DAL.Entities.TypeRecordChancellery type = MapDB.Db.TypeRecordChancelleries.Find(typeDTO.Id);
            if (type == null) type = new DAL.Entities.TypeRecordChancellery();
            type.Id = typeDTO.Id;
            type.Name = typeDTO.Name;

            var chancelleriesDB = await MapDB.Db.Chancelleries.ToListAsync();
            type.Chancelleries = chancelleriesDB.Select(ch => ch.Id == type.Id) as ICollection<Chancellery>;

            return type;
        }
        #endregion

        private static async Task<DAL.Entities.Chancellery> MappingDataChancelleryAsync(Chancellery chancellery, DTO.CorrespondencesBaseDTO correspondencesDTO)
        {
            chancellery = await MapDB.Db.Chancelleries.FindAsync(correspondencesDTO.Id);
            if (chancellery == null) chancellery = new DAL.Entities.Chancellery();

            chancellery.Id = correspondencesDTO.Id;
            chancellery.DateRegistration = correspondencesDTO.DateRegistration;
            chancellery.RegistrationNumber = correspondencesDTO.RegistrationNumber;
            chancellery.Summary = correspondencesDTO.Summary;
            chancellery.Notice = correspondencesDTO.Notice;
            chancellery.Status = correspondencesDTO.Status;
            chancellery.TypeRecordChancelleryId = correspondencesDTO.TypeRecordChancelleryId;
            chancellery.FolderChancelleryId = correspondencesDTO.FolderChancelleryId;
            chancellery.JournalRegistrationsChancelleryId = correspondencesDTO.JournalRegistrationsChancelleryId;

            chancellery.FileRecordChancelleries = MapDB.Db.Files.Find(m => correspondencesDTO.FileRecordChancelleries.Contains(m.Id)) as ICollection<Files>;
            chancellery.ResponsibleEmployees = MapDB.Db.Employees.Find(m => correspondencesDTO.ResponsibleEmployees.Contains(m.Id)) as ICollection<Employee>;

            return chancellery;
        }

        public static async Task<DAL.Entities.Chancellery> IncomingToChancelleryAsync(DTO.IncomingCorrespondencyDTO incomingDTO, FromExtlOrgChancellery fromExtlOrgChancellery, ToEmplChancellery toEmplChancellery)
        {
            Chancellery chancellery = null;

            chancellery = await MappingDataChancelleryAsync(chancellery, incomingDTO);
            #region Type
            chancellery.TypeRecordChancellery = MapDB.Db.TypeRecordChancelleries.Find(incomingDTO.TypeRecordChancelleryId);
            #endregion
            int editorId = incomingDTO.s_EditorId;
            DateTime editDate = DateTime.Now;
            #region from
            bool IsCreateFrom = false;
            fromExtlOrgChancellery = MapDB.Db.FromExtlOrgsChancellery.Query(ex=> ex.ExternalOrganizationId == incomingDTO.From_ExternalOrganizationChancelleryId).FirstOrDefault();

            if (fromExtlOrgChancellery == null)
            {
                fromExtlOrgChancellery = new FromExtlOrgChancellery();
                fromExtlOrgChancellery.s_AuthorId = editorId;
                fromExtlOrgChancellery.s_DateCreation = editDate;
                
                IsCreateFrom = true;
            }
            fromExtlOrgChancellery.s_EditDate = editDate;
            fromExtlOrgChancellery.s_EditorId = editorId;

            fromExtlOrgChancellery.Chancellery = chancellery;
            fromExtlOrgChancellery.ExternalOrganizationId = incomingDTO.From_ExternalOrganizationChancelleryId;
            MapDB.Db.FromExtlOrgsChancellery.Add(fromExtlOrgChancellery/*, incomingDTO.s_EditorId*/);
            //if (!IsCreateFrom)

                #endregion

                #region to

                var to_List = await MapDB.Db.ToEmplsChancellery.ToListAsync();

            toEmplChancellery = to_List.FirstOrDefault(d => d.Chancellery.Id == incomingDTO.Id);

            if (toEmplChancellery == null) toEmplChancellery = new ToEmplChancellery();

            toEmplChancellery.Chancellery = chancellery;
            //toEmplChancellery.EmployeeId = incomingDTO.To_EmployeeId;
            toEmplChancellery.Employee = MapDB.Db.Employees.Find(incomingDTO.To_EmployeeId);
            #endregion

            return chancellery;
        }
        public static async Task<DAL.Entities.Chancellery> OutgoingToChancelleryAsync(DTO.OutgoingCorrespondencyDTO OutgoingDTO, FromEmplChancellery fromEmplChancellery, List<ToExtlOrgChancellery> toExtlOrgChancelleryList)
        {
            Chancellery chancellery = null;

            chancellery = await MappingDataChancelleryAsync(chancellery, OutgoingDTO);

            #region from
            var from_List = await MapDB.Db.FromEmplsChancellery.ToListAsync();

            fromEmplChancellery = from_List.FirstOrDefault(d => d.Chancellery.Id == OutgoingDTO.Id);

            if (fromEmplChancellery == null) fromEmplChancellery = new FromEmplChancellery();

            fromEmplChancellery.Chancellery = chancellery;
            fromEmplChancellery.EmployeeId = OutgoingDTO.From_EmployeeId;

            #endregion

            #region to

            var ToExtlOrgsChancelleryDBList = await MapDB.Db.ToExtlOrgsChancellery.ToListAsync();

            if (OutgoingDTO.To_ExtOrgns.Count() > 0 && toExtlOrgChancelleryList == null) toExtlOrgChancelleryList = new List<ToExtlOrgChancellery>();

            foreach (var extOrgId in OutgoingDTO.To_ExtOrgns)
            {
                ToExtlOrgChancellery toExtlOrgChancellery = ToExtlOrgsChancelleryDBList.FirstOrDefault(d => d.Chancellery.Id == OutgoingDTO.Id && d.ExternalOrganization.Id == extOrgId);

                if (toExtlOrgChancellery == null) toExtlOrgChancellery = new ToExtlOrgChancellery();

                toExtlOrgChancellery.Chancellery = chancellery;
                toExtlOrgChancellery.ExternalOrganizationId = extOrgId;
                toExtlOrgChancelleryList.Add(toExtlOrgChancellery);
            }

            #endregion

            return chancellery;
        }
        public static async Task<DAL.Entities.Chancellery> InternalToChancelleryAsync(DTO.InternalCorrespondencyDTO InternalDTO, FromEmplChancellery fromEmplChancellery, List<ToEmplChancellery> ToEmplChancelleryList)
        {
            Chancellery chancellery = null;

            chancellery = await MappingDataChancelleryAsync(chancellery, InternalDTO);

            #region from
            var from_List = await MapDB.Db.FromEmplsChancellery.ToListAsync();

            fromEmplChancellery = from_List.FirstOrDefault(d => d.Chancellery.Id == InternalDTO.Id);

            if (fromEmplChancellery == null) fromEmplChancellery = new FromEmplChancellery();

            fromEmplChancellery.Chancellery = chancellery;
            fromEmplChancellery.EmployeeId = InternalDTO.From_EmployeeId;

            #endregion

            #region to

            var ToEmplChancelleryDBList = await MapDB.Db.ToEmplsChancellery.ToListAsync();

            if (InternalDTO.To_Employees.Count() > 0 && ToEmplChancelleryList == null) ToEmplChancelleryList = new List<ToEmplChancellery>();

            foreach (var emplId in InternalDTO.To_Employees)
            {
                ToEmplChancellery toEmplChancellery = ToEmplChancelleryDBList.FirstOrDefault(d => d.Chancellery.Id == InternalDTO.Id && d.Employee.Id == emplId);

                if (toEmplChancellery == null) toEmplChancellery = new ToEmplChancellery();

                toEmplChancellery.Chancellery = chancellery;
                toEmplChancellery.EmployeeId = emplId;
                ToEmplChancelleryList.Add(toEmplChancellery);
            }

            #endregion

            return chancellery;
        }

        #endregion

        #region DB_to_DTO


        private static T MappingDataChancelleryToCorrespondencesDTO<T>(T CorrespondencesDTO, Chancellery chancellery) where T : CorrespondencesBaseDTO
        {

            CorrespondencesDTO.Id = chancellery.Id;
            CorrespondencesDTO.DateRegistration = chancellery.DateRegistration;
            CorrespondencesDTO.RegistrationNumber = chancellery.RegistrationNumber;
            CorrespondencesDTO.Summary = chancellery.Summary;
            CorrespondencesDTO.Notice = chancellery.Notice;
            CorrespondencesDTO.Status = chancellery.Status;
            CorrespondencesDTO.TypeRecordChancelleryId = chancellery.TypeRecordChancelleryId;
            CorrespondencesDTO.FolderChancelleryId = chancellery.FolderChancelleryId;
            CorrespondencesDTO.JournalRegistrationsChancelleryId = chancellery.JournalRegistrationsChancelleryId;

            CorrespondencesDTO.FileRecordChancelleries = chancellery.FileRecordChancelleries.Select(d => d.Id);
            CorrespondencesDTO.ResponsibleEmployees = chancellery.ResponsibleEmployees.Select(d => d.Id);

            return CorrespondencesDTO;
        }


        private static IEnumerable<string> MapFrom(Chancellery chancellery)
        {
            IEnumerable<string> result = new List<string>();

            switch (chancellery.TypeRecordChancellery.Id)
            {
                case (byte)Constants.CorrespondencyType.Incoming:
                    {
                        var FromExtOrgs = MapDB.Db.FromExtlOrgsChancellery.Find(f => chancellery.Id == f.Chancellery.Id);
                        result = FromExtOrgs.Select(m => m.ExternalOrganization.Name);
                        break;
                    }
                case (byte)Constants.CorrespondencyType.Outgoing:
                    {
                        var FromEmpls = MapDB.Db.FromEmplsChancellery.Find(f => chancellery.Id == f.Chancellery.Id);
                        result = FromEmpls.Select(m => m.Employee.FullName);
                        break;
                    }
                case (byte)Constants.CorrespondencyType.Internal:
                    {
                        var FromEmpls = MapDB.Db.FromEmplsChancellery.Find(f => chancellery.Id == f.Chancellery.Id);
                        result = FromEmpls.Select(m => m.Employee.FullName);
                        break;
                    }

                default: { break; }
            }

            return result;
        }
        private static IEnumerable<string> MapTo(Chancellery chancellery)
        {
            IEnumerable<string> result = new List<string>();

            switch (chancellery.TypeRecordChancellery.Id)
            {
                case (byte)Constants.CorrespondencyType.Incoming:
                    {
                        var ToEmpls = MapDB.Db.ToEmplsChancellery.Find(f => chancellery.Id == f.Chancellery.Id);
                        result = ToEmpls.Select(m => m.Employee.FullName);
                        break;
                    }
                case (byte)Constants.CorrespondencyType.Outgoing:
                    {
                        var ToExtOrgs = MapDB.Db.ToExtlOrgsChancellery.Find(f => chancellery.Id == f.Chancellery.Id);
                        result = ToExtOrgs.Select(m => m.ExternalOrganization.Name);
                        break;
                    }
                case (byte)Constants.CorrespondencyType.Internal:
                    {
                        var ToEmpls = MapDB.Db.ToEmplsChancellery.Find(f => chancellery.Id == f.Chancellery.Id);
                        result = ToEmpls.Select(m => m.Employee.FullName);
                        break;
                    }

                default: { break; }
            }

            return result;
        }
        public static ChancelleryDTO chancelleryToChancelleryDTO(Chancellery chancellery)
        {
            DTO.ChancelleryDTO chancelleryDTO = new DTO.ChancelleryDTO();

            chancelleryDTO.Id = chancellery.Id;
            chancelleryDTO.DateRegistration = chancellery.DateRegistration;
            chancelleryDTO.RegistrationNumber = chancellery.RegistrationNumber;
            chancelleryDTO.Summary = chancellery.Summary;
            chancelleryDTO.Notice = chancellery.Notice;
            chancelleryDTO.Status = chancellery.Status;
            chancelleryDTO.Folder = chancellery.FolderChancellery!=null ? chancellery.FolderChancellery.Name : null;
            chancelleryDTO.JournalRegistrations = chancellery.JournalRegistrationsChancellery != null ? chancellery.JournalRegistrationsChancellery.Name : null; 
            chancelleryDTO.ResponsibleEmployees = chancellery.ResponsibleEmployees != null ? chancellery.ResponsibleEmployees.Select(m => m.FullName) : new Collection<string>(); 
            chancelleryDTO.Type = chancellery.TypeRecordChancellery != null ? chancellery.TypeRecordChancellery.Name : null;

            chancelleryDTO.Files = chancellery.FileRecordChancelleries != null ? chancellery.FileRecordChancelleries.Select(o => o.FileName + o.Extension) : new Collection<string>(); 

            chancelleryDTO.From = MapFrom(chancellery);
            chancelleryDTO.To = MapTo(chancellery);

            BLL.MapSystemParamBLL<DAL.Entities.Chancellery, DTO.ChancelleryDTO>.FillParamDTO(chancellery, ref chancelleryDTO);

            return chancelleryDTO;
        }
        public static List<DTO.ChancelleryDTO> ListChancelleryToListChancelleryDto(IEnumerable<DAL.Entities.Chancellery> Chancelleries)
        {
            List<DTO.ChancelleryDTO> result = new List<DTO.ChancelleryDTO>();

            foreach (var chancellery in Chancelleries)
                result.Add(chancelleryToChancelleryDTO(chancellery));

            return result;
        }

        #region typeChancellery
        public static TypeRecordCorrespondencesDTO TypeToTypeDTO(TypeRecordChancellery type)
        {
            DTO.TypeRecordCorrespondencesDTO typeDto = new DTO.TypeRecordCorrespondencesDTO();

            typeDto.Id = type.Id;
            typeDto.Name = type.Name;
            typeDto.Chancelleries = type.Chancelleries.Select(j => j.Id);

            BLL.MapSystemParamBLL<DAL.Entities.TypeRecordChancellery, DTO.TypeRecordCorrespondencesDTO>.FillParamDTO(type, ref typeDto);
            return typeDto;
        }
        public static List<DTO.TypeRecordCorrespondencesDTO> ListTypeToListTypeDto(IEnumerable<DAL.Entities.TypeRecordChancellery> types)
        {
            List<DTO.TypeRecordCorrespondencesDTO> result = new List<DTO.TypeRecordCorrespondencesDTO>();

            foreach (var type in types)
                result.Add(TypeToTypeDTO(type));

            return result;
        }


        #endregion

        #region folder


        public static FolderCorrespondencesDTO FolderToFolderDTO(FolderChancellery folder)
        {
            DTO.FolderCorrespondencesDTO folderDto = new DTO.FolderCorrespondencesDTO();

            folderDto.Id = folder.Id;
            folderDto.Name = folder.Name;
            folderDto.Chancelleries = folder.Chancelleries.Select(j => j.Id);

            BLL.MapSystemParamBLL<DAL.Entities.FolderChancellery, DTO.FolderCorrespondencesDTO>.FillParamDTO(folder, ref folderDto);
            return folderDto;
        }

        public static List<DTO.FolderCorrespondencesDTO> ListFolderToListFolderDto(IEnumerable<DAL.Entities.FolderChancellery> folders)
        {
            List<DTO.FolderCorrespondencesDTO> result = new List<DTO.FolderCorrespondencesDTO>();

            foreach (var folder in folders)
                result.Add(FolderToFolderDTO(folder));

            return result;
        }

        #endregion
        #region journal


        public static JournalRegistrationsCorrespondencesDTO JournalToJournalDTO(JournalRegistrationsChancellery journal)
        {
            DTO.JournalRegistrationsCorrespondencesDTO journalDto = new DTO.JournalRegistrationsCorrespondencesDTO();

            journalDto.Id = journal.Id;
            journalDto.Name = journal.Name;
            journalDto.Chancelleries = journal.Chancelleries.Select(j => j.Id);

            BLL.MapSystemParamBLL<DAL.Entities.JournalRegistrationsChancellery, DTO.JournalRegistrationsCorrespondencesDTO>.FillParamDTO(journal, ref journalDto);
            return journalDto;
        }

        public static List<DTO.JournalRegistrationsCorrespondencesDTO> ListJournalToListJournalDto(IEnumerable<DAL.Entities.JournalRegistrationsChancellery> journals)
        {
            List<DTO.JournalRegistrationsCorrespondencesDTO> result = new List<DTO.JournalRegistrationsCorrespondencesDTO>();

            foreach (var journal in journals)
                result.Add(JournalToJournalDTO(journal));

            return result;
        }

        #endregion

        public static async Task<IEnumerable<IncomingCorrespondencyDTO>> ListChancelleryToListIncomingDTOAsync(IEnumerable<DAL.Entities.Chancellery> chancelleries)
        {
            List<DTO.IncomingCorrespondencyDTO> result = new List<DTO.IncomingCorrespondencyDTO>();
            foreach (var chancellery in chancelleries)
            {
                var dto = await ChancelleryToIncomingDTOAsync(chancellery);
                result.Add(dto);
            }

            return result;
        }

        public static async Task<IncomingCorrespondencyDTO> ChancelleryToIncomingDTOAsync(Chancellery chancellery)
        {
            IncomingCorrespondencyDTO incomingCorrespondencyDTO = new IncomingCorrespondencyDTO();

            incomingCorrespondencyDTO = MappingDataChancelleryToCorrespondencesDTO(incomingCorrespondencyDTO, chancellery);

            #region from

            var FromExtlOrgsChancelleryDB_List = await MapDB.Db.FromExtlOrgsChancellery.QueryAsync(filter: f => chancellery.Id == f.ChancelleryId);
            if (FromExtlOrgsChancelleryDB_List != null && FromExtlOrgsChancelleryDB_List.Count > 0)
            {
                var ExtOrgId = FromExtlOrgsChancelleryDB_List.FirstOrDefault().ExternalOrganizationId;

                incomingCorrespondencyDTO.From_ExternalOrganizationChancelleryId = ExtOrgId;
            }
            #endregion

            #region to

            var ToEmplsDB_List = await MapDB.Db.ToEmplsChancellery.QueryAsync(filter: f => chancellery.Id == f.ChancelleryId);
            if(ToEmplsDB_List != null && ToEmplsDB_List.Count > 0)
            incomingCorrespondencyDTO.To_EmployeeId = ToEmplsDB_List.FirstOrDefault().EmployeeId;

            #endregion

            BLL.MapSystemParamBLL<Chancellery, DTO.IncomingCorrespondencyDTO>.FillParamDTO(chancellery, ref incomingCorrespondencyDTO);

            return incomingCorrespondencyDTO;
        }

        public static async Task<IEnumerable<OutgoingCorrespondencyDTO>> ListChancelleryToListOutgoingDTOAsync(IEnumerable<DAL.Entities.Chancellery> chancelleries)
        {
            List<DTO.OutgoingCorrespondencyDTO> result = new List<DTO.OutgoingCorrespondencyDTO>();
            foreach (var chancellery in chancelleries)
            {
                var dto = await ChancelleryToOutgoingDTOAsync(chancellery);
                result.Add(dto);
            }

            return result;
        }

        public static async Task<OutgoingCorrespondencyDTO> ChancelleryToOutgoingDTOAsync(Chancellery chancellery)
        {
            OutgoingCorrespondencyDTO outgoingCorrespondencyDTO = new OutgoingCorrespondencyDTO();

            outgoingCorrespondencyDTO = MappingDataChancelleryToCorrespondencesDTO(outgoingCorrespondencyDTO, chancellery);

            #region from

            var FromEmplsDB_List = await MapDB.Db.FromEmplsChancellery.QueryAsync(filter: f => chancellery.Id == f.ChancelleryId);

            outgoingCorrespondencyDTO.From_EmployeeId = FromEmplsDB_List.FirstOrDefault().EmployeeId;

            #endregion

            #region to

            var ToExtlOrgsChancelleryDB_List = await MapDB.Db.ToExtlOrgsChancellery.QueryAsync(filter: f => chancellery.Id == f.ChancelleryId);

            outgoingCorrespondencyDTO.To_ExtOrgns = ToExtlOrgsChancelleryDB_List.Select(t => t.ExternalOrganizationId.HasValue ? t.ExternalOrganizationId.Value : 0);

            #endregion

            BLL.MapSystemParamBLL<Chancellery, DTO.OutgoingCorrespondencyDTO>.FillParamDTO(chancellery, ref outgoingCorrespondencyDTO);

            return outgoingCorrespondencyDTO;
        }
        public static async Task<IEnumerable<InternalCorrespondencyDTO>> ListChancelleryToListInternalDTOAsync(IEnumerable<DAL.Entities.Chancellery> chancelleries)
        {
            List<DTO.InternalCorrespondencyDTO> result = new List<DTO.InternalCorrespondencyDTO>();
            foreach (var chancellery in chancelleries)
            {
                var dto = await ChancelleryToInternalDTOAsync(chancellery);
                result.Add(dto);
            }

            return result;
        }

        public static async Task<InternalCorrespondencyDTO> ChancelleryToInternalDTOAsync(Chancellery chancellery)
        {
            InternalCorrespondencyDTO internalCorrespondencyDTO = new InternalCorrespondencyDTO();

            internalCorrespondencyDTO = MappingDataChancelleryToCorrespondencesDTO(internalCorrespondencyDTO, chancellery);

            #region from

            var FromEmplsDB_List = await MapDB.Db.FromEmplsChancellery.QueryAsync(filter: f => chancellery.Id == f.ChancelleryId);

            internalCorrespondencyDTO.From_EmployeeId = FromEmplsDB_List.FirstOrDefault().EmployeeId;

            #endregion

            #region to

            var ToEmplsChancelleryDb_List = await MapDB.Db.ToEmplsChancellery.QueryAsync(filter: f => chancellery.Id == f.ChancelleryId);

            internalCorrespondencyDTO.To_Employees = ToEmplsChancelleryDb_List.Select(t => t.EmployeeId.HasValue ? t.EmployeeId.Value : 0);

            #endregion

            BLL.MapSystemParamBLL<Chancellery, DTO.InternalCorrespondencyDTO>.FillParamDTO(chancellery, ref internalCorrespondencyDTO);

            return internalCorrespondencyDTO;
        }

        #endregion
    }
}

using ACS.BLL.DTO;
using ACS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACS.WEB.Tests.Controllers.TetServices
{
    class ChancelleryServiceTest : IChancelleryService
    {
        public int AttachmentFile(FileRecordChancelleryDTO file, int EditorId)
        {
            throw new NotImplementedException();
        }

        public int AttachmentFiles(IEnumerable<FileRecordChancelleryDTO> files, int EditorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChancelleryDTO> ChancellerieGetAll()
        {
            throw new NotImplementedException();
        }

        public ChancelleryDTO ChancelleryGet(int id)
        {
            throw new NotImplementedException();
        }

        public void ChancelleryUpdate(ChancelleryDTO ChancelleryDTO, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public void CreateChancellery(ChancelleryDTO chancelleryDto, string authorEmail)
        {
            throw new NotImplementedException();
        }

        public int DeleteChancellery(int chancelleryId)
        {
            throw new NotImplementedException();
        }

        public int DeletedFile(FileRecordChancelleryDTO fileRecordChancelleryDTO)
        {
            throw new NotImplementedException();
        }

        public int DeletedFiles(IEnumerable<FileRecordChancelleryDTO> files)
        {
            throw new NotImplementedException();
        }

        public int DetachFile(FileRecordChancelleryDTO fileRecordChancelleryDTO)
        {
            throw new NotImplementedException();
        }

        public int DetachFiles(IEnumerable<FileRecordChancelleryDTO> files)
        {
            throw new NotImplementedException();
        }

        public FolderChancelleryDTO FolderGet(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileRecordChancelleryDTO> GetAllFiles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileRecordChancelleryDTO> GetAllFiles(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FolderChancelleryDTO> GetAllFolders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JournalRegistrationsChancelleryDTO> GetAllJournalesRegistrations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDTO> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public FileRecordChancelleryDTO GetFile(int id)
        {
            throw new NotImplementedException();
        }

        public FromChancelleryDTO GetFromWhom(int id)
        {
            throw new NotImplementedException();
        }

        public JournalRegistrationsChancelleryDTO GetJournalRegistrations(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeeDTO GetResponsible(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToChancelleryDTO> GetToList()
        {
            throw new NotImplementedException();
        }

        public void TypeRecordCreate(TypeRecordChancelleryDTO typeDTO, string currentUserEmail)
        {
            throw new NotImplementedException();
        }

        public void TypeRecordDelete(int typeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TypeRecordChancelleryDTO> TypeRecordGetAll()
        {
            throw new NotImplementedException();
        }

        public TypeRecordChancelleryDTO TypeRecordGetById(int id)
        {
            throw new NotImplementedException();
        }

        public TypeRecordChancelleryDTO TypeRecordGetByName(string typeName)
        {
            throw new NotImplementedException();
        }

        public void TypeRecordMoveToBasket(TypeRecordChancelleryDTO typeDTO, string currentUserEmail)
        {
            throw new NotImplementedException();
        }

        public void TypeRecordUpdate(TypeRecordChancelleryDTO typeDTO, string currentUserEmail)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ChancelleryServiceTest() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        public int AttachOrDetachFile(FileRecordChancelleryDTO fileDTO, string authorEmail, int ChancelleryId, bool attach)
        {
            throw new NotImplementedException();
        }

        public int AttachOrDetachFiles(IEnumerable<FileRecordChancelleryDTO> files, string authorEmail, int ChancelleryId, bool attach)
        {
            throw new NotImplementedException();
        }

        public FileRecordChancelleryDTO GetFileChancellerByPath(string Path, int ChancelleryId)
        {
            throw new NotImplementedException();
        }

        public FileRecordChancelleryDTO GetFileChanceller(int FileId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileRecordChancelleryDTO> GetAllFilesChancellery(ChancelleryDTO Chancellery)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}

using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers.Chancellery
{
    public class FileRecordChancelleryController : Controller
    {
        IFileRecordChancelleryService FileRecordChancelleryService;

        public FileRecordChancelleryController(IFileRecordChancelleryService FileRecordChancelleryService)
        {
            this.FileRecordChancelleryService = FileRecordChancelleryService;
        }

        #region Работа с файлами

        public FilePathResult DownloadFile(int id)
        {
            var VM = GetFileRecordChancelleryVM(id);
            string path = Server.MapPath(VM.Path);
            string type = "application/octet-stream";
            string name = VM.Name;
            return File(path, type, name);
        }

        #endregion
        // GET: TypesRecordsChancellery
        public ActionResult Index()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>();

            }).CreateMapper();


            var FileRecorddVM = mapper.Map<IEnumerable<FileRecordChancelleryDTO>, List<FileRecordChancelleryViewModel>>(FileRecordChancelleryService.GetFilesRecordChancellery());
            return View(FileRecorddVM);
        }

        // GET: TypesRecordsChancellery/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var FileRecordDTO = FileRecordChancelleryService.GetFileRecord(id);

                var FileRecordVM = MappFileRecordDTOToFileRecordVM(FileRecordDTO);
                return View(FileRecordVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: TypesRecordsChancellery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypesRecordsChancellery/Create
        [HttpPost]
        public ActionResult Create(FileRecordChancelleryViewModel FileRecordVM)
        {
            return CreateOrUpdateOrDel(FileRecordVM);
        }

        // GET: TypesRecordsChancellery/Edit/5
        public ActionResult Edit(int id)
        {
            var VM = GetFileRecordChancelleryVM(id);
            return View(VM);
        }

        // POST: TypesRecordsChancellery/Edit/5
        [HttpPost]
        public ActionResult Edit(FileRecordChancelleryViewModel FileRecordVM)
        {
            return CreateOrUpdateOrDel(FileRecordVM);
        }

        // GET: TypesRecordsChancellery/Delete/5
        public ActionResult Delete(int id)
        {
            var vm = GetFileRecordChancelleryVM(id);
            ActionResult action = this.DeleteConfirmed(id);
            return action;
        }

        // POST: TypesRecordsChancellery/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var FileRecordDTO = FileRecordChancelleryService.GetFileRecord(id);
            var FileRecordVM = MappFileRecordDTOToFileRecordVM(FileRecordDTO);
            return CreateOrUpdateOrDel(FileRecordVM, true);
        }
        ActionResult CreateOrUpdateOrDel(/*[Bind(Include = "Id,Name")]*/ FileRecordChancelleryViewModel FileRecordVM, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var FileRecordDto = MappFileRecordVMToFileRecordDTO(FileRecordVM);

                    int result = 0;

                    if (del)
                    {
                        result = FileRecordChancelleryService.DeleteFileRecord(FileRecordDto.id);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = FileRecordChancelleryService.CreateOrUpdateFileRecord(FileRecordDto, currentUserEmail);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(FileRecordVM);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(FileRecordVM);
        }
        FileRecordChancelleryViewModel GetFileRecordChancelleryVM(int id)
        {
            var FileRecordDTO = FileRecordChancelleryService.GetFileRecord(id);
            if (FileRecordDTO == null) { throw new Exception("Файл не найден"); }
            return MappFileRecordDTOToFileRecordVM(FileRecordDTO);
        }

        FileRecordChancelleryViewModel MappFileRecordDTOToFileRecordVM(FileRecordChancelleryDTO FileRecordDTO)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>();

            }).CreateMapper();
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>()).CreateMapper();
            return mapper.Map<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>(FileRecordDTO);
        }


        FileRecordChancelleryDTO MappFileRecordVMToFileRecordDTO(FileRecordChancelleryViewModel FileRecordVM)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>();
                cfg.CreateMap<FileRecordChancelleryViewModel, FileRecordChancelleryDTO>();

            }).CreateMapper();
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FileRecordChancelleryViewModel, FileRecordChancelleryDTO>()).CreateMapper();
            return mapper.Map<FileRecordChancelleryViewModel, FileRecordChancelleryDTO>(FileRecordVM);
        }

        private bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    FileRecordChancelleryService.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}

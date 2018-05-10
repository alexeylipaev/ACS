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
namespace ACS.WEB.Controllers
{
    public class FoldersChancelleryController : Controller
    {
        IFolderChancelleryService FolderChancelleryService;

        public FoldersChancelleryController(IFolderChancelleryService folderChancelleryService)
        {
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>()
            //       .ReverseMap();
            //});

            FolderChancelleryService = folderChancelleryService;
        }
        //private object mapFolder(FolderChancelleryDTO folderDTO = null, FolderChancelleryViewModel folderVM = null)
        //{

        //    if (folderDTO != null)
        //        return Mapper.Map<FolderChancelleryDTO, FolderChancelleryViewModel>(folderDTO);
        //    else if (folderVM != null)
        //        return Mapper.Map<FolderChancelleryViewModel, FolderChancelleryDTO>(folderVM);

        //    return null;
        //}

        IMapper mapTemplFolderDTOToFolderVM()
        {
            return new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();
                  cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>();

              }).CreateMapper();
        }

        FolderChancelleryViewModel MappFolderDTOToFolderVM(FolderChancelleryDTO FolderDTO)
        {
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>()).CreateMapper();
            return mapTemplFolderDTOToFolderVM().Map<FolderChancelleryDTO, FolderChancelleryViewModel>(FolderDTO);
        }


        FolderChancelleryDTO MappFolderVMToFolderDTO(FolderChancelleryViewModel FolderVM)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>();
                cfg.CreateMap<FolderChancelleryViewModel, FolderChancelleryDTO>();

            }).CreateMapper();
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancelleryViewModel,FolderChancelleryDTO>()).CreateMapper();
            return mapper.Map<FolderChancelleryViewModel, FolderChancelleryDTO>(FolderVM);
        }

        // GET: FoldersChancellery
        public ActionResult Index()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>()).CreateMapper();
            var folderdVM = mapTemplFolderDTOToFolderVM().Map<IEnumerable<FolderChancelleryDTO>, List<FolderChancelleryViewModel>>(FolderChancelleryService.GetFoldersChancellery());
            return View(folderdVM);
        }


        // GET: FoldersChancellery/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var folderDTO = FolderChancelleryService.GetFolderChancellery(id);

                var folderVM = MappFolderDTOToFolderVM(folderDTO);
                return View(folderVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        FolderChancelleryViewModel GetFolderVM(int id)
        {
            var folderDTO = FolderChancelleryService.GetFolderChancellery(id);
            if (folderDTO == null) { throw new Exception("Папка не найдена"); }
            return MappFolderDTOToFolderVM(folderDTO);
        }

        // GET: FoldersChancellery/Create
        public ActionResult Create()
        {
            return View(/*GetFolderVM(id)*/);
        }

        // POST: FoldersChancellery/Create
        [HttpPost]
        public ActionResult Create(FolderChancelleryViewModel folrderVM)
        {
            return CreateOrUpdateOrDel(folrderVM);
        }

        // GET: FoldersChancellery/Edit/5
        public ActionResult Edit(int id)
        {
            var VM = GetFolderVM(id);
            return View(VM);
        }


        // POST: FoldersChancellery/Edit/5
        [HttpPost]
        public ActionResult Edit(/*[Bind(Include = "Name")]*/ FolderChancelleryViewModel folrderVM)
        {
            return CreateOrUpdateOrDel(folrderVM);
        }

        ActionResult CreateOrUpdateOrDel(/*[Bind(Include = "Id,Name")]*/ FolderChancelleryViewModel folrderVM, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var folrderDto = MappFolderVMToFolderDTO(folrderVM);

                    int result = 0;

                    if (del)
                    {
                        result = FolderChancelleryService.DeleteFolderChancellery(folrderDto);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = FolderChancelleryService.CreateOrUpdateFolderChancellery(folrderDto, currentUserEmail);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(folrderVM);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(folrderVM);
        }

        // GET: FoldersChancellery/Delete/5
        public ActionResult Delete(int id)
        {
            var vm = GetFolderVM(id);
            ActionResult action = this.DeleteConfirmed(id);
            return action;
            //return RedirectToAction("Delete", "FoldersChancellery", new { id = id });
            //return View(vm);
        }

        // POST: FoldersChancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var folderDTO = FolderChancelleryService.GetFolderChancellery(id);
            var folderVM = MappFolderDTOToFolderVM(folderDTO);
            return CreateOrUpdateOrDel(folderVM, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FolderChancelleryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.Util;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers.Chancellery
{
    public class TypesRecordsChancelleryController : Controller
    {
        ITypeRecordChancelleryService TypeRecordChancelleryService;

        public TypesRecordsChancelleryController(ITypeRecordChancelleryService TypeRecordChancelleryService)
        {
            this.TypeRecordChancelleryService = TypeRecordChancelleryService;
        }

        // GET: TypesRecordsChancellery
        public ActionResult Index()
        {
            //var mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();
            //    cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>();

            //}).CreateMapper();


            var TypeRecorddVM = MapBLLPresenter.GetMap().Map<IEnumerable<TypeRecordChancelleryDTO>, List<TypeRecordChancelleryViewModel>>(TypeRecordChancelleryService.GetTypesRecordChancellery());
            return View(TypeRecorddVM);
        }

        // GET: TypesRecordsChancellery/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var TypeRecordDTO = TypeRecordChancelleryService.GetTypeRecordChancellery(id);

                var TypeRecordVM = MappTypeRecordDTOToTypeRecordVM(TypeRecordDTO);
                return View(TypeRecordVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: TypesRecordsChancellery/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            else
            {
                ViewBag.EditResult = "Чтобы создать новый тип, обратитесь в отдел автоматизации";
            }

            return View("Index");

            //return View();
        }

        // POST: TypesRecordsChancellery/Create
        [HttpPost]
        public ActionResult Create(TypeRecordChancelleryViewModel TypeRecordVM)
        {
            if (User.IsInRole("Admin"))
            {
                return CreateOrUpdateOrDel(TypeRecordVM);
            }
            else
            {
                ViewBag.EditResult = "Чтобы создать новый тип, обратитесь в отдел автоматизации";
            }

            return View("Index");

            //return CreateOrUpdateOrDel(TypeRecordVM);
        }

        // GET: TypesRecordsChancellery/Edit/5
        public ActionResult Edit(int id)
        {
            if (User.IsInRole("Admin"))
            {
                var VM = GetTypeRecordChancelleryVM(id);
                return View(VM);
            }  
            else
            {
                ViewBag.EditResult = "Чтобы отредактировать тип, обратитесь в отдел автоматизации";
            }

            return View("Index");

            //
            //
        }

        // POST: TypesRecordsChancellery/Edit/5
        [HttpPost]
        public ActionResult Edit(TypeRecordChancelleryViewModel TypeRecordVM)
        {
            //

            if (User.IsInRole("Admin"))
            {
                return CreateOrUpdateOrDel(TypeRecordVM);
            }
            else
            {
                ViewBag.EditResult = "Чтобы отредактировать тип, обратитесь в отдел автоматизации";
            }

            return View("Index");

        }

        // GET: TypesRecordsChancellery/Delete/5
        public ActionResult Delete(int id)
        {
            //var vm = GetTypeRecordChancelleryVM(id);
            //ActionResult action = this.DeleteConfirmed(id);
            //return action; 

            if (User.IsInRole("Admin"))
            {
                var vm = GetTypeRecordChancelleryVM(id);
                ActionResult action = this.DeleteConfirmed(id);
                return action;
            }
            else
            {
                ViewBag.EditResult = "Чтобы удалить тип, обратитесь в отдел автоматизации";
            }

            return View("Index");
        }

        // POST: TypesRecordsChancellery/Delete/5
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            //var TypeRecordDTO = TypeRecordChancelleryService.GetTypeRecordChancellery(id);
            //var TypeRecordVM = MappTypeRecordDTOToTypeRecordVM(TypeRecordDTO);
            //return CreateOrUpdateOrDel(TypeRecordVM, true);

            if (User.IsInRole("Admin"))
            {
                var TypeRecordDTO = TypeRecordChancelleryService.GetTypeRecordChancellery(id);
                var TypeRecordVM = MappTypeRecordDTOToTypeRecordVM(TypeRecordDTO);
                return CreateOrUpdateOrDel(TypeRecordVM, true);
            }

            else          
            {
                ViewBag.EditResult = "Чтобы удалить тип, обратитесь в отдел автоматизации";
            }

            return View("Index");

        }
        ActionResult CreateOrUpdateOrDel(/*[Bind(Include = "Id,Name")]*/ TypeRecordChancelleryViewModel TypeRecordVM, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var TypeRecordDto = MappTypeRecordVMToTypeRecordDTO(TypeRecordVM);

                    int result = 0;

                    if (del)
                    {
                        result = TypeRecordChancelleryService.DeleteTypeRecordChancellery(TypeRecordDto.id);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = TypeRecordChancelleryService.CreateOrUpdateTypeRecordChancellery(TypeRecordDto, currentUserEmail);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(TypeRecordVM);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(TypeRecordVM);
        }
        TypeRecordChancelleryViewModel GetTypeRecordChancelleryVM(int id)
        {
            var TypeRecordDTO = TypeRecordChancelleryService.GetTypeRecordChancellery(id);
            if (TypeRecordDTO == null) { throw new Exception("Тип не найден"); }
            return MappTypeRecordDTOToTypeRecordVM(TypeRecordDTO);
        }

        TypeRecordChancelleryViewModel MappTypeRecordDTOToTypeRecordVM(TypeRecordChancelleryDTO TypeRecordDTO)
        {
            //var mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();
            //    cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>();

            //}).CreateMapper();
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>()).CreateMapper();
            return MapBLLPresenter.GetMap().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>(TypeRecordDTO);
        }


        TypeRecordChancelleryDTO MappTypeRecordVMToTypeRecordDTO(TypeRecordChancelleryViewModel TypeRecordVM)
        {
            //var mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>();
            //    cfg.CreateMap<TypeRecordChancelleryViewModel, TypeRecordChancelleryDTO>();

            //}).CreateMapper();
            // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancelleryViewModel, TypeRecordChancelleryDTO>()).CreateMapper();
            return MapBLLPresenter.GetMap().Map<TypeRecordChancelleryViewModel, TypeRecordChancelleryDTO>(TypeRecordVM);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                TypeRecordChancelleryService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

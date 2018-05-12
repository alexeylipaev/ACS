using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.Areas.Admin.Models;
using ACS.WEB.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Areas.Admin.Controllers.Chancellery
{
    [Authorize(Roles = "Admin")]
    public class TypeRecordChancelleryController : Controller
    {
        IChancelleryService ChancelleryService;
        public TypeRecordChancelleryController(IChancelleryService chancelleryService)
        {
            ChancelleryService = chancelleryService;
        }
        // GET: Admin/TypeRecordChancellery
        public ActionResult Index()
        {
            var typeDTOs = ChancelleryService.TypeRecordGetAll();
            var typesVM = GetMapTypeRecordChancelleryDTOToTypeRecordChancelleryAdminVM().Map<List<TypeRecordChancelleryDTO>, List<TypeRecordChancelleryAdminVM>>(typeDTOs.ToList());
            return View(typesVM);
        }

        // GET: Admin/TypeRecordChancellery/Details/5
        public ActionResult Details(int id)
        {
            var typeDTO = ChancelleryService.TypeRecordGetById(id);
            var typeVM = GetMapTypeRecordChancelleryDTOToTypeRecordChancelleryAdminVM().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryAdminVM>(typeDTO);
            return View(typeVM);
        }

        // GET: Admin/TypeRecordChancellery/Create
        public ActionResult Create()
        {
            var typeVM = new TypeRecordChancelleryAdminVM();
            return View(typeVM);
        }

        // POST: Admin/TypeRecordChancellery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name")]TypeRecordChancelleryAdminVM typeVM)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    // TODO: Add insert logic here
                    string currentUserEmail = this.User.Identity.Name;

                    var typeDTO = GetMapTypeRecordChancelleryAdminVMToTypeRecordChancelleryDTO().Map<TypeRecordChancelleryAdminVM, TypeRecordChancelleryDTO>(typeVM);
                    ChancelleryService.TypeRecordCreateOrUpdate(typeDTO, currentUserEmail);

                    return RedirectToAction("Index");
                }

                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View(typeVM);
        }



        // GET: Admin/TypeRecordChancellery/Edit/5
        public ActionResult Edit(int id)
        {
            var typeDTO = ChancelleryService.TypeRecordGetById(id);
            var typeVM = GetMapTypeRecordChancelleryDTOToTypeRecordChancelleryAdminVM().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryAdminVM>(typeDTO);
            return View(typeVM);
        }

        // POST: Admin/TypeRecordChancellery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TypeRecordChancelleryAdminVM typeVM)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    // TODO: Add insert logic here
                    string currentUserEmail = this.User.Identity.Name;

                    var typeDTO = GetMapTypeRecordChancelleryAdminVMToTypeRecordChancelleryDTO().Map<TypeRecordChancelleryAdminVM, TypeRecordChancelleryDTO>(typeVM);
                    ChancelleryService.TypeRecordCreateOrUpdate(typeDTO, currentUserEmail);

                    return RedirectToAction("Index");
                }

                catch (ValidationException ex)
                {
                    ModelState.AddModelError(ex.Property, ex.Message);
                }
            }
            return View(typeVM);
        }

        // GET: Admin/TypeRecordChancellery/Delete/5
        public ActionResult Delete(int id)
        {
            var typeDTO = ChancelleryService.TypeRecordGetById(id);
            var typeVM = GetMapTypeRecordChancelleryDTOToTypeRecordChancelleryAdminVM().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryAdminVM>(typeDTO);
            return View(typeVM);
        }

        // POST: Admin/TypeRecordChancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, TypeRecordChancelleryAdminVM typeVM)
        { 
            try
            {
                // TODO: Add delete logic here
                //var typeToDelete = ChancelleryService.GetType(id);
                ChancelleryService.TypeRecordDelete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(typeVM);
            }
        }

        IMapper GetMapTypeRecordChancelleryDTOToTypeRecordChancelleryAdminVM()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>().ForMember(x => x.TypeRecordChancellery,
x => x.MapFrom(m => m.TypeRecordChancellery)); ;
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryAdminVM>();

            }).CreateMapper();

            return mapper;
        }

        private IMapper GetMapTypeRecordChancelleryAdminVMToTypeRecordChancelleryDTO()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>().ForMember(x => x.TypeRecordChancellery,
x => x.MapFrom(m => m.TypeRecordChancellery)); 
                cfg.CreateMap<TypeRecordChancelleryAdminVM, TypeRecordChancelleryDTO>();

            }).CreateMapper();

            return mapper;
        }
    }
}

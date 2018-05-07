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

    public class ChancelleryController : Controller
    {
        IChancelleryService chancelleryService;

        public ChancelleryController(IChancelleryService serv)
        {
            chancelleryService = serv;
        }


        // GET: Chancellery
        public ActionResult Index()
        {
            var chancelleryDTOs = chancelleryService.GetChancelleries();
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>()).CreateMapper();
            var chancelleriesVMs = mapper.Map<IEnumerable<ChancelleryDTO>, List<ChancelleryViewModel>>(chancelleryDTOs);
            return View(chancelleriesVMs);
        }

        // GET: Chancellery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chancellery/Create
        public ActionResult Create()
        {
            var newChancelleryVM =new ChancelleryViewModel();
            newChancelleryVM.DateRegistration = DateTime.Today;
            ViewBag.TypeRecords = new SelectList(GetAllTypes().Select(t => new { TypeId = t.id, TypeName=t.Name }), "TypeId", "TypeName");
            return View(newChancelleryVM);
        }

    
        IMapper GetMapChancelleryDTOToChancelleryVM()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>();
                cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>();
                cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>();
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>();
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();

            }).CreateMapper();

            return mapper;
        }

        // POST: Chancellery/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,DateRegistration,RegistrationNumber,Summary,FolderChancellery,JournalRegistrationsChancellery,FileRecordChancelleries, FromChancelleries,ToChancelleries")] ChancelleryViewModel chancelleryVM, int? TypeRecords)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var typeRecordDTO = chancelleryService.GetType(TypeRecords);
                    string currentUserEmail = this.User.Identity.Name;
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    var chancelleryDTO = new ChancelleryDTO();
                    
                    // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>()).CreateMapper();
                    chancelleryDTO = GetMapChancelleryDTOToChancelleryVM().Map<ChancelleryViewModel, ChancelleryDTO>(chancelleryVM);
                    chancelleryDTO.TypeRecordChancellery = typeRecordDTO;
                    chancelleryService.MakeChancellery(chancelleryDTO, currentUserEmail);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(chancelleryVM);
        }

        // GET: Chancellery/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chancellery/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chancellery/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chancellery/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private  IEnumerable<TypeRecordChancelleryViewModel> GetAllTypes()
        {
            var typeDTOs = chancelleryService.GetAllTypes();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>()).CreateMapper();
            return mapper.Map<List<TypeRecordChancelleryDTO>, List<TypeRecordChancelleryViewModel>>(typeDTOs.ToList());
            //chancelleryService.MakeChancellery(chancelleryDTO, currentUserEmail);
        }
    }
}

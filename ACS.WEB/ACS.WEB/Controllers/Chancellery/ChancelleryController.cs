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
    [Authorize]
    public class ChancelleryController : Controller
    {
        IChancelleryService ChancelleryService;
        IEmployeeService EmployeeService;

        public ChancelleryController(IChancelleryService chancelleryService, IEmployeeService employeeService)
        {
            ChancelleryService = chancelleryService;
            EmployeeService = employeeService;
        }



        // GET: Chancellery
        public ActionResult Index()
        {
            var chancelleryDTOs = ChancelleryService.GetChancelleries();
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>()).CreateMapper();
            var chancelleriesVMs = GetMapChancelleryDTOToChancelleryVM().Map<List<ChancelleryDTO>, List<ChancelleryViewModel>>(chancelleryDTOs.ToList());
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
            ViewBag.TypeRecordIds = new SelectList(GetAllTypes().Select(t => new { TypeId = t.id, TypeName=t.Name }), "TypeId", "TypeName");
            ViewBag.ResponsibleEmployee_Id = new SelectList(GetEmployeeNameSelector().OrderBy(e=>e.EmployeeName), "EmployeeId", "EmployeeName");
            return View(newChancelleryVM);
        }

    
        

        // POST: Chancellery/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "id,DateRegistration,RegistrationNumber,Summary,TypeRecordId,ResponsibleEmployee_Id,FolderChancellery,JournalRegistrationsChancellery,FileRecordChancelleries, FromChancelleries,ToChancelleries")] ChancelleryViewModel chancelleryVM, int TypeRecordIds)
        {
            try
            {
                chancelleryVM.TypeRecordId = TypeRecordIds;
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //EmployeeDTO employee = EmployeeService.GetEmployee(EmployeeId);
                    //var typeRecordDTO = chancelleryVM.TypeRecordChancellery;
                    string currentUserEmail = this.User.Identity.Name;
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    //var chancelleryDTO = new ChancelleryDTO();
                    
                    // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>()).CreateMapper();
                   var chancelleryDTO = GetMapChancelleryVMToDTO().Map<ChancelleryViewModel, ChancelleryDTO>(chancelleryVM);
                    var typeDTO = chancelleryDTO.TypeRecordChancellery;
                    ChancelleryService.CreateChancellery(chancelleryDTO, currentUserEmail);
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

        private IEnumerable<EmployeeSelectItem> GetEmployeeNameSelector()
        {
            var employeesDTO = EmployeeService.GetEmployees();
            var employees = employeesDTO.Select(e => new EmployeeSelectItem { EmployeeId = e.id, EmployeeName = e.LName + " " + e.FName + " " + e.MName });
            return employees;
        }

        private  IEnumerable<TypeRecordChancelleryViewModel> GetAllTypes()
        {
            var typeDTOs = ChancelleryService.TypeRecordGetAll();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>()).CreateMapper();
            return GetMapTypeRecordChancelleryDTOToTypeRecordChancelleryVM().Map<List<TypeRecordChancelleryDTO>, List<TypeRecordChancelleryViewModel>>(typeDTOs.ToList());
        }

        IMapper GetMapChancelleryDTOToChancelleryVM()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                
                //cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>();
                cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>();
                //cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>();
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>();
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>().ForMember(c=> c.TypeRecordId, c=> c.MapFrom(t=>t.TypeRecordChancellery.id));

            }).CreateMapper();

            return mapper;
        }

        IMapper GetMapChancelleryVMToDTO()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FileRecordChancelleryViewModel, FileRecordChancelleryDTO > ();
                cfg.CreateMap<FolderChancelleryViewModel, FolderChancelleryDTO>();
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>();
                /*cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>();*/
                
                //cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>();
                cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>().ForMember(x => x.TypeRecordChancellery, x => x.MapFrom(c => ChancelleryService.TypeRecordGetById((int)c.TypeRecordId)));

            }).CreateMapper();

            return mapper;
        }
        IMapper GetMapTypeRecordChancelleryDTOToTypeRecordChancelleryVM()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>().ForMember(x => x.TypeRecordId,
x => x.MapFrom(m => m.TypeRecordChancellery.id)); ;
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>();/*.ForMember(x => x.,
x => x.MapFrom(m => m.Employee.id));*/

            }).CreateMapper();

            return mapper;
        }
    }
}

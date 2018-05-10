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
            var chancelleryDTOs = ChancelleryService.ChancellerieGetAll();
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>()).CreateMapper();
            var chancelleriesVMs = GetMapChancelleryDTOToChancelleryVM().Map<List<ChancelleryDTO>, List<ChancelleryViewModel>>(chancelleryDTOs.ToList());
            return View(chancelleriesVMs);
        }

        // GET: Chancellery/Details/5
        public ActionResult Details(int id)
        {
            var chancelleryDTO = ChancelleryService.ChancelleryGet(id);
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>()).CreateMapper();
            var chancelleriesVM = GetMapChancelleryDTOToChancelleryVM().Map<ChancelleryDTO, ChancelleryViewModel>(chancelleryDTO);
            return View(chancelleriesVM);
        }

        // GET: Chancellery/Create
        public ActionResult Create()
        {
            var newChancelleryVM =new ChancelleryViewModel();
            newChancelleryVM.DateRegistration = DateTime.Today;
            ViewBag.TypeRecordIds = new SelectList(GetAllTypes().Select(t => new { TypeId = t.id, TypeName=t.Name }), "TypeId", "TypeName");
            ViewBag.ResponsibleEmployee_Id = new SelectList(GetEmployeeNameSelector().OrderBy(e=>e.EmployeeName), "EmployeeId", "EmployeeName");
            ViewBag.Journal_Id = new SelectList(ChancelleryService.GetAllJournalesRegistrations().OrderBy(j => j.Name).Select(j => new { JournalId = j.id, JournalName = j.Name }), "JournalId", "JournalName");
            ViewBag.Folder_Id = new SelectList(ChancelleryService.GetAllFolders().OrderBy(j => j.Name).Select(j => new { FolderId = j.id, FolderName = j.Name }), "FolderId", "FolderName");
            return View(newChancelleryVM);
        }

    
        

        // POST: Chancellery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "id,DateRegistration,RegistrationNumber,Summary,TypeRecordId,ResponsibleEmployee_Id,FolderChancellery,JournalRegistrationsChancellery,FileRecordChancelleries, FromChancelleries,ToChancelleries")] 
        public ActionResult Create(ChancelleryViewModel chancelleryVM, int TypeRecordIds, int ResponsibleEmployee_Id, int Journal_Id, int Folder_Id)
        {
            try
            {
               // var mapperType = new MapperConfiguration(cfg => cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>()).CreateMapper();

                chancelleryVM.TypeRecordChancellery = GetMapChancelleryDTOToChancelleryVM().Map<TypeRecordChancelleryDTO , TypeRecordChancelleryViewModel>(ChancelleryService.TypeRecordGetById(TypeRecordIds));
                chancelleryVM.JournalRegistrationsChancellery = GetMapChancelleryDTOToChancelleryVM().Map<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>(ChancelleryService.GetJournalRegistrations(Journal_Id));
                chancelleryVM.FolderChancellery = GetMapChancelleryDTOToChancelleryVM().Map<FolderChancelleryDTO, FolderChancelleryViewModel>(ChancelleryService.FolderGet(Folder_Id));
                //var mapperEmpl = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();

                chancelleryVM.Employee = GetMapChancelleryDTOToChancelleryVM().Map<EmployeeDTO, EmployeeViewModel>(EmployeeService.GetEmployee((int)ResponsibleEmployee_Id));

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
                    //var typeDTO = chancelleryDTO.TypeRecordChancellery;
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
            ChancelleryDTO chancDTO = ChancelleryService.ChancelleryGet(id);

            var allEmployees =GetEmployeeNameSelector().OrderBy(e => e.EmployeeName);
            ViewBag.ResponsibleEmployee_Id = chancDTO.Employee == null? new SelectList(allEmployees, "EmployeeId", "EmployeeName") : new SelectList(allEmployees, "EmployeeId", "EmployeeName", chancDTO.Employee.id);


            var allJournals = ChancelleryService.GetAllJournalesRegistrations().OrderBy(j => j.Name).Select(j => new { JournalId = j.id, JournalName = j.Name });
            ViewBag.Journal_Id =  chancDTO.JournalRegistrationsChancellery== null ? new SelectList(allJournals, "JournalId", "JournalName") : new SelectList(allJournals, "JournalId", "JournalName", chancDTO.JournalRegistrationsChancellery.id);

            var allFolders = ChancelleryService.GetAllFolders().OrderBy(j => j.Name).Select(j => new { FolderId = j.id, FolderName = j.Name });
            ViewBag.Folder_Id = chancDTO.FolderChancellery == null ? new SelectList(allFolders, "FolderId", "FolderName") : new SelectList(allFolders, "FolderId", "FolderName", chancDTO.FolderChancellery.id);

            var allTypes = ChancelleryService.TypeRecordGetAll().OrderBy(j => j.Name).Select(j => new { TypeId = j.id, TypeName = j.Name });
            ViewBag.TypeRecordIds = chancDTO.FolderChancellery == null ? new SelectList(allTypes, "TypeId", "TypeName") : new SelectList(allTypes, "TypeId", "TypeName", chancDTO.TypeRecordChancellery.id);
            
            var chancVM = GetMapChancelleryDTOToChancelleryVM().Map<ChancelleryDTO, ChancelleryViewModel>(chancDTO);

            int selectedTypeId= chancVM.id;

            return View(chancVM);
        }

        // POST: Chancellery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChancelleryViewModel chancVM, int TypeRecordIds, int ResponsibleEmployee_Id, int Journal_Id, int Folder_Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chancVM.TypeRecordChancellery = GetMapChancelleryVMToDTO().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>(ChancelleryService.TypeRecordGetById(TypeRecordIds));
                    chancVM.JournalRegistrationsChancellery = GetMapChancelleryVMToDTO().Map<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>(ChancelleryService.GetJournalRegistrations(Journal_Id));
                    chancVM.FolderChancellery = GetMapChancelleryVMToDTO().Map<FolderChancelleryDTO, FolderChancelleryViewModel>(ChancelleryService.FolderGet(Folder_Id));

                    var chancDTO = GetMapChancelleryVMToDTO().Map<ChancelleryViewModel, ChancelleryDTO>(chancVM);
                    ChancelleryService.ChancelleryUpdate(chancDTO, this.User.Identity.Name);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(chancVM); 
        }

        // GET: Chancellery/Delete/5
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ActionResult action = this.DeleteConfirmed(id);
            return action;
        }

        // POST: Chancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {

                    result = ChancelleryService.DeleteChancellery(id);
                    if (result > 0)
                        ViewBag.EditResult = "Данные успешно удалены";
 

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return RedirectToAction("Index");
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
            return GetMapChancelleryDTOToChancelleryVM().Map<List<TypeRecordChancelleryDTO>, List<TypeRecordChancelleryViewModel>>(typeDTOs.ToList());
        }

        IMapper GetMapChancelleryDTOToChancelleryVM()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>();
                cfg.CreateMap<EmployeeDTO, EmployeeViewModel> ();
                cfg.CreateMap<FolderChancelleryDTO, FolderChancelleryViewModel>();
                cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>();
                cfg.CreateMap<FileRecordChancelleryDTO, FileRecordChancelleryViewModel>();
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();

            }).CreateMapper();

            return mapper;
        }

        IMapper GetMapChancelleryVMToDTO()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FileRecordChancelleryViewModel, FileRecordChancelleryDTO > ();
                cfg.CreateMap<FolderChancelleryViewModel, FolderChancelleryDTO>();
                cfg.CreateMap<TypeRecordChancelleryViewModel, TypeRecordChancelleryDTO>();
                cfg.CreateMap<JournalRegistrationsChancelleryViewModel, JournalRegistrationsChancelleryDTO>();
                cfg.CreateMap<EmployeeViewModel , EmployeeDTO>();
                cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO>();

            }).CreateMapper();

            return mapper;
        }
       /* IMapper GetMapTypeRecordChancellery_DTO_To_VM()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();
                cfg.CreateMap<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>();
            }).CreateMapper();

            return mapper;
        }*/

    }
}

﻿using ACS.BLL.BusinessModels;
using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.Models.Chancellery;
using ACS.WEB.Util;
using ACS.WEB.ViewModel;
using ACS.WEB.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers
{
    [Authorize]
    public class ChancelleryController : Controller
    {
        IChancelleryService ChancelleryService;

        //Mapper_Chancellery_BLL_PRE Map_Chancellery;
        //Mapper_Empl_BLL_PRE Map_Empl;
        //Mapper_TypeFolderJorn_Templayt<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel> Map_TypeChancellery;
        //Mapper_TypeFolderJorn_Templayt<FolderChancelleryDTO, FolderChancelleryViewModel> Map_FolderChancellery;
        //Mapper_TypeFolderJorn_Templayt<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel> Map_JournalChancellery;

        public ChancelleryController(IChancelleryService chancelleryService)
        {
            ChancelleryService = chancelleryService;
            //Map_Chancellery = Mapper_Chancellery_BLL_PRE.getMapper();
            //Map_Empl = Mapper_Empl_BLL_PRE.getMapper();
            //Map_TypeChancellery = Mapper_TypeFolderJorn_Templayt<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>.getMapper();
            //Map_FolderChancellery = Mapper_TypeFolderJorn_Templayt<FolderChancelleryDTO, FolderChancelleryViewModel>.getMapper();
            //Map_JournalChancellery = Mapper_TypeFolderJorn_Templayt<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>.getMapper();
        }


        // GET: Chancellery
        public ActionResult Index()
        {
            var chancelleryDTOs = ChancelleryService.ChancellerieGetAll().Where(ch=>ch.s_InBasket == false);
            ViewBag.Types = GetAllTypes();

            var chancelleriesVMs = MapBLLRrsr.GetMap().Map<IEnumerable<ChancelleryDTO>, List<ChancelleryViewModel>>(chancelleryDTOs.ToList()); /*(chancelleryDTOs.ToList());*/
            return View(chancelleriesVMs);
        }

        // GET: Chancellery/Details/5
        public ActionResult Details(int id)
        {
            var chancelleryDTO = ChancelleryService.ChancelleryGet(id);
            var chancelleriesVM = MapBLLRrsr.GetMap().Map<ChancelleryDTO, ChancelleryViewModel>(chancelleryDTO);
            return View(chancelleriesVM);
        }

        List<EmployeeViewModel> GetEmplCollection()
        {
            List<EmployeeViewModel> collection = new List<EmployeeViewModel>() { null };
            collection.AddRange(MapBLLRrsr.GetMap().Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(ChancelleryService.GetEmployees().OrderBy(emp => emp.LName)).ToList());
            return collection;
        }
        List<FolderChancelleryViewModel> GetFoldersCollection()
        {
            List<FolderChancelleryViewModel> collection = new List<FolderChancelleryViewModel>() { null };
            collection.AddRange(MapBLLRrsr.GetMap().Map<IEnumerable<FolderChancelleryDTO>, List<FolderChancelleryViewModel>>(ChancelleryService.GetAllFolders().OrderBy(f => f.Name)).ToList());
            return collection;
        }
        List<JournalRegistrationsChancelleryViewModel> GetJournalsCollection()
        {
            List<JournalRegistrationsChancelleryViewModel> collection = new List<JournalRegistrationsChancelleryViewModel>() { null };
            collection.AddRange(MapBLLRrsr.GetMap().Map<IEnumerable<JournalRegistrationsChancelleryDTO>, List<JournalRegistrationsChancelleryViewModel>>(ChancelleryService.GetAllJournalesRegistrations().OrderBy(f => f.Name)).ToList());
            return collection;
        }
        List<ExternalOrganizationChancelleryViewModel> GetExtOrgsCollection()
        {
            List<ExternalOrganizationChancelleryViewModel> collection = new List<ExternalOrganizationChancelleryViewModel>() { null };

            /*            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancelleryViewModel>()).CreateMapper();*/
            collection.AddRange(MapBLLRrsr.GetMap().Map<IEnumerable<ExternalOrganizationChancelleryDTO>, List<ExternalOrganizationChancelleryViewModel>>(ChancelleryService.GetAllExternalOrganizations()));
            return collection;
        }


        public ActionResult Incoming()
        {
            ChancellerySearchModel searchModel = new ChancellerySearchModel { RegistryDateTo = DateTime.Now };
            var incomingDTOs = ChancelleryService.ChancelleryGetIncoming(searchModel);
            var incomings = MapBLLRrsr.GetMap().Map<IEnumerable<IncomingCorrespondency>, IEnumerable<IncomingCorrespondencyViewModel>>(incomingDTOs);
            return View(incomings);
        }

        public ActionResult Create(int TypeRecordId)
        {
            SelectedEmployeeViewModel.Collection = GetEmplCollection();
            SelectedFolderChancellery.Collection = GetFoldersCollection();
            SelectedJournalRegChancellery.Collection = GetJournalsCollection();
            SelectedExternalOrgViewModel.Collection = GetExtOrgsCollection();

            var typeVM = MapBLLRrsr.GetMap().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>(ChancelleryService.TypeRecordGetById(TypeRecordId));

            ViewBag.ActionName = "Создание";

            ViewBag.TypeName = typeVM.Name + " корреспонденция";

            ViewBag.Title = "Создание " + typeVM.Name;
            ViewBag.NameBtn = "Создать";
            var newChancelleryVM = new ChancelleryViewModel();
            newChancelleryVM.TypeRecordChancelleryId = TypeRecordId;
            newChancelleryVM.TypeRecordChancellery = typeVM;
            newChancelleryVM.DateRegistration = DateTime.Today;

            ViewBag.TypeRecordId = TypeRecordId;

            return View(newChancelleryVM);
        }



        // POST: Chancellery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "id,DateRegistration,RegistrationNumber,Summary,TypeRecordId,ResponsibleEmployee_Id,FolderChancellery,JournalRegistrationsChancellery,FileRecordChancelleries, FromChancelleries,ToChancelleries")] 
        public ActionResult Create(ChancelleryViewModel newChancelleryVM, IEnumerable<HttpPostedFileBase> Files)
        {
            try
            {
                newChancelleryVM.TypeRecordChancellery = MapBLLRrsr.GetMap().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>(ChancelleryService.TypeRecordGetById((int)newChancelleryVM.TypeRecordChancelleryId));

                if (newChancelleryVM.EmployeeId != null)
                {
                    var idResponsible = (int)newChancelleryVM.EmployeeId;//.SelectedResponsible.SelectedId.FirstOrDefault();

                    if (idResponsible > 0)
                        newChancelleryVM.Employee = MapBLLRrsr.GetMap().Map<EmployeeDTO, EmployeeViewModel>(ChancelleryService.GetEmployee(idResponsible));
                }

                if (newChancelleryVM.FolderChancelleryId != null)
                {
                    var idFolder = (int)newChancelleryVM.FolderChancelleryId;//newChancelleryVM.SelectedFolder.SelectedId;

                    if (idFolder > 0)
                        newChancelleryVM.FolderChancellery = MapBLLRrsr.GetMap().Map<FolderChancelleryDTO, FolderChancelleryViewModel>(ChancelleryService.FolderGet(idFolder));
                }


                var idJournalsReg = (int)newChancelleryVM.JournalRegistrationsChancelleryId;//newChancelleryVM.SelectedJournalsReg.SelectedId;

                if (idJournalsReg > 0)
                    newChancelleryVM.JournalRegistrationsChancellery = MapBLLRrsr.GetMap().Map<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>(ChancelleryService.GetJournalRegistrations(idJournalsReg));
                #region  Входящая
                if (newChancelleryVM.TypeRecordChancellery.id == 1)
                {
                    //from
                    AddOneFromOrToExtOrg(ref newChancelleryVM, newChancelleryVM.Selected_ExtOrg.SelectedId.FirstOrDefault(), false);
                    //to
                    AddOneFromOrToEmpl(ref newChancelleryVM, newChancelleryVM.Selected_To_Empl.SelectedId.FirstOrDefault(), true);
                }
                #endregion
                #region Исходящая
                else if (newChancelleryVM.TypeRecordChancellery.id == 3)
                {
                    //from
                    AddOneFromOrToEmpl(ref newChancelleryVM, newChancelleryVM.Selected_From_Empl.SelectedId.FirstOrDefault(), false);
                    //to
                    if (newChancelleryVM.Selected_ExtOrg.SelectedId.Count > 0)
                        foreach (var idExtOrg in newChancelleryVM.Selected_ExtOrg.SelectedId)
                            AddOneFromOrToExtOrg(ref newChancelleryVM, idExtOrg, true);
                }
                #endregion
                #region Внутреняя
                else if (newChancelleryVM.TypeRecordChancellery.id == 2)
                {
                    //from
                    AddOneFromOrToEmpl(ref newChancelleryVM, newChancelleryVM.Selected_From_Empl.SelectedId.FirstOrDefault(), false);
                    //to
                    AddOneFromOrToEmpl(ref newChancelleryVM, newChancelleryVM.Selected_To_Empl.SelectedId.FirstOrDefault(), true);
                }
                #endregion


                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;

                    var chancelleryDTO = MapBLLRrsr.GetMap().Map<ChancelleryViewModel, ChancelleryDTO>(newChancelleryVM);
                    //var chancelleryDTO = Map_Chancellery.Map_ChancelleryViewModel_to_ChancelleryDTO(newChancelleryVM);
                    AddFiles(/*this.Request.Files.GetMultiple("Files")*/Files, chancelleryDTO);

                    ChancelleryService.CreateOrUpdateChancellery(chancelleryDTO, currentUserEmail);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(newChancelleryVM);
        }

        void AddOneFromOrToExtOrg(ref ChancelleryViewModel newChancelleryVM, int SelectedId, bool IsTo)
        {
            var idselectedEmp = SelectedId;

            if (idselectedEmp > 0)
            {
                var ExtOrgDTO = ChancelleryService.GetExternalOrganization(idselectedEmp);
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancelleryViewModel>()).CreateMapper();
                var ExtOrgVM = MapBLLRrsr.GetMap().Map<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancelleryViewModel>(ExtOrgDTO);

                if (IsTo)
                {
                    var To = new ToChancelleryViewModel();
                    To.Chancellery = newChancelleryVM;
                    To.ExternalOrganization = ExtOrgVM;
                    newChancelleryVM.ToChancelleries.Add(To);
                }
                else
                {
                    var From = new FromChancelleryViewModel();
                    From.Chancellery = newChancelleryVM;
                    From.ExternalOrganization = ExtOrgVM;
                    newChancelleryVM.FromChancelleries.Add(From);
                }

            }
        }

        void AddOneFromOrToEmpl(ref ChancelleryViewModel newChancelleryVM, int SelectedId, bool IsTo)
        {
            var idselectedEmp = SelectedId;

            if (idselectedEmp > 0)
            {
                if (IsTo)
                {
                    var To = new ToChancelleryViewModel();
                    To.Chancellery = newChancelleryVM;
                    var ToEmplDTO = ChancelleryService.GetEmployee(idselectedEmp);
                    var ToEmplVM = MapBLLRrsr.GetMap().Map<EmployeeDTO, EmployeeViewModel>(ToEmplDTO);

                    To.Employee = ToEmplVM;
                    newChancelleryVM.ToChancelleries.Add(To);
                }
                else
                {
                    var From = new FromChancelleryViewModel();
                    From.Chancellery = newChancelleryVM;
                    var ToEmplDTO = ChancelleryService.GetEmployee(idselectedEmp);
                    var ToEmplVM = MapBLLRrsr.GetMap().Map<EmployeeDTO, EmployeeViewModel>(ToEmplDTO);

                    From.Employee = ToEmplVM;
                    newChancelleryVM.FromChancelleries.Add(From);
                }

            }
        }

        // GET: Chancellery/Edit/5
        public ActionResult Edit(int id)
        {
            SelectedEmployeeViewModel.Collection = GetEmplCollection();
            SelectedFolderChancellery.Collection = GetFoldersCollection();
            SelectedJournalRegChancellery.Collection = GetJournalsCollection();
            SelectedExternalOrgViewModel.Collection = GetExtOrgsCollection();

            ChancelleryDTO chancDTO = ChancelleryService.ChancelleryGet(id);
            var chancVM = MapBLLRrsr.GetMap().Map<ChancelleryDTO, ChancelleryViewModel>(chancDTO);
            if(chancDTO.FolderChancellery != null)
            chancVM.SelectedFolder = new SelectedFolderChancellery() { SelectedId = chancDTO.FolderChancellery.id };
            if(chancDTO.JournalRegistrationsChancellery != null)
            chancVM.SelectedJournalsReg = new SelectedJournalRegChancellery() { SelectedId = chancDTO.JournalRegistrationsChancellery.id };

            if (chancDTO.Employee != null)
            {
                chancVM.SelectedResponsible = new SelectedEmployeeViewModel();
                chancVM.SelectedResponsible.SelectedId.Add(chancDTO.Employee.id);
            }


            if (chancVM.TypeRecordChancellery.id == 1)
            {
                var To = chancDTO.ToChancelleries.FirstOrDefault();
                if (To != null)
                {
                    var empTo = To.Employee;
                    if (empTo != null)
                        chancVM.Selected_To_Empl = new SelectedEmployeeViewModel() { SelectedId = { (empTo.id) } };
                }
                var From = chancDTO.FromChancelleries.FirstOrDefault();
                if (From != null)
                {
                    var extOrgFrom = From.ExternalOrganization;
                    if (extOrgFrom != null)
                        chancVM.Selected_ExtOrg = new SelectedExternalOrgViewModel() { SelectedId = { (extOrgFrom.id) } };
                }
            }
            else if (chancVM.TypeRecordChancellery.id == 2)
            {
                foreach (var To in chancDTO.ToChancelleries)
                {
                    var extOrg = To.ExternalOrganization;
                    if (extOrg != null)
                        chancVM.Selected_ExtOrg = new SelectedExternalOrgViewModel() { SelectedId = { (extOrg.id) } };
                }
                var From = chancDTO.FromChancelleries.FirstOrDefault();
                if (From != null)
                {
                    var empFrom = From.Employee;
                    if (empFrom != null)
                        chancVM.Selected_From_Empl = new SelectedEmployeeViewModel() { SelectedId = { (empFrom.id) } };
                }
            }
            else if (chancVM.TypeRecordChancellery.id == 3)
            {
                var To = chancDTO.ToChancelleries.FirstOrDefault();
                if (To != null)
                {
                    var empTo = chancDTO.ToChancelleries.FirstOrDefault().Employee;
                    if (empTo != null)
                        chancVM.Selected_To_Empl = new SelectedEmployeeViewModel() { SelectedId = { (empTo.id) } };
                }
                var From = chancDTO.FromChancelleries.FirstOrDefault();
                if (From != null)
                {
                    var empTo = chancDTO.FromChancelleries.FirstOrDefault().Employee;
                    if (empTo != null)
                        chancVM.Selected_To_Empl = new SelectedEmployeeViewModel() { SelectedId = { (empTo.id) } };
                }
            }
            chancVM.TypeRecordChancelleryId = chancVM.TypeRecordChancellery.id;
            ViewBag.ActionName = "Редактирование";

            ViewBag.TypeName = chancVM.TypeRecordChancellery.Name + " корреспонденция";


            ViewBag.Title = "Редактирование " + chancVM.TypeRecordChancellery.Name;
            ViewBag.NameBtn = "Сохранить";

            return View(chancVM);
        }

        // POST: Chancellery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChancelleryViewModel chancVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chancVM.TypeRecordChancellery = MapBLLRrsr.GetMap().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>(ChancelleryService.TypeRecordGetById(chancVM.TypeRecordChancelleryId != null ? chancVM.TypeRecordChancelleryId.Value : 0));
                    chancVM.JournalRegistrationsChancellery = MapBLLRrsr.GetMap().Map<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>(ChancelleryService.GetJournalRegistrations(chancVM.JournalRegistrationsChancelleryId));
                    chancVM.FolderChancellery = MapBLLRrsr.GetMap().Map<FolderChancelleryDTO, FolderChancelleryViewModel>(ChancelleryService.FolderGet(chancVM.FolderChancelleryId != null ? chancVM.FolderChancelleryId.Value : 0 ));

                    var chancDTO = MapBLLRrsr.GetMap().Map<ChancelleryViewModel, ChancelleryDTO>(chancVM);
                    ChancelleryService.CreateOrUpdateChancellery(chancDTO, this.User.Identity.Name);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(chancVM);
        }

       
        public ActionResult MoveToBasket(int id)
        {
            ActionResult action = this.MoveToBasketConfirmed(id);
            return action;
        }

        [HttpPost, ActionName("MoveToBasket")]
        [ValidateAntiForgeryToken]
        public ActionResult MoveToBasketConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ChancelleryDTO chancDTO = ChancelleryService.ChancelleryGet(id);
                    chancDTO.s_InBasket = true;

                    ChancelleryService.CreateOrUpdateChancellery(chancDTO, this.User.Identity.Name);

                    ViewBag.EditResult = "Данные успешно перемещены в корзину";

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return RedirectToAction("Index");
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



        private IEnumerable<TypeRecordChancelleryViewModel> GetAllTypes()
        {
            var typeDTOs = ChancelleryService.TypeRecordGetAll();

            return MapBLLRrsr.GetMap().Map<IEnumerable<TypeRecordChancelleryDTO>, List<TypeRecordChancelleryViewModel>>(typeDTOs.ToList());
        }
        #region работа с файлами

        public FilePathResult DownloadFile(int id)
        {
            var fileDTO = ChancelleryService.GetFile(id);
            string path = (fileDTO.Path);
            string type = fileDTO.Format;
            string name = fileDTO.Name;
            return File(path, type, null);
        }


        public ActionResult AttachFiles(int ChancelleryId)
        {
            ViewBag.ChancelleryId = ChancelleryId;
            return View();
        }

        public ActionResult DettachFile(int ChancelleryId, int FileId)
        {
            //ViewBag.ChancelleryId = ChancelleryId;
            FileRecordChancelleryDTO fileDTO = ChancelleryService.GetFile(FileId);
            ChancelleryService.AttachOrDetachFile(fileDTO, this.User.Identity.Name, ChancelleryId, false);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AddFiles(IEnumerable<HttpPostedFileBase> files, int ChancelleryId)
        {
            foreach (var file in files)
            {
                if (file != null)
                {

                    string pathForSave = @"X:\Подразделения\СВиССА\Файлы канцелярии\";

                    //Возвращает имя файла указанной строки пути без расширения.
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    //fileVM.Name = fileName;

                    //Возвращает расширение указанной строки пути.
                    string extension = Path.GetExtension(file.FileName);

                    //fileVM.Format = extension;

                    //fileVM.Path = @"X:/Подразделения/СВиССА/Файлы канцелярии/" + fileName;
                    string path = Path.Combine(pathForSave, fileName + extension);

                    FileRecordChancelleryDTO fileDTO = ChancelleryService.GetFileChancellerByPath(path, ChancelleryId);

                    if (fileDTO == null)
                    {
                        fileDTO = new FileRecordChancelleryDTO();
                        fileDTO.Name = fileName;
                        fileDTO.Path = path;
                        fileDTO.Format = extension;

                    }
                    ChancelleryService.AttachOrDetachFile(fileDTO, this.User.Identity.Name, ChancelleryId, true);
                    file.SaveAs(path);
                }
            }

            return RedirectToAction("Index");
        }

        public void AddFiles(IEnumerable<HttpPostedFileBase> files, ChancelleryDTO ChancelleryDTO)
        {
            foreach (var file in files)
            {
                if (file != null)
                {

                    string pathForSave = @"X:\Подразделения\СВиССА\Файлы канцелярии\";

                    //Возвращает имя файла указанной строки пути без расширения.
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    //fileVM.Name = fileName;

                    //Возвращает расширение указанной строки пути.
                    string extension = Path.GetExtension(file.FileName);

                    //fileVM.Format = extension;

                    //fileVM.Path = @"X:/Подразделения/СВиССА/Файлы канцелярии/" + fileName;
                    string path = Path.Combine(pathForSave, fileName + extension);

                    //FileRecordChancelleryDTO fileDTO = ChancelleryService.GetFileChancellerByPath(path, ChancelleryVM);

                    //if (fileDTO == null)
                    //{
                    FileRecordChancelleryDTO fileDTO = new FileRecordChancelleryDTO();
                    fileDTO.Name = fileName;
                    fileDTO.Path = path;
                    fileDTO.Format = extension;

                    //}
                    ChancelleryDTO.FileRecordChancelleries.Add(fileDTO);
                    //ChancelleryService.AttachOrDetachFile(fileDTO, this.User.Identity.Name, ChancelleryVM, true);
                    file.SaveAs(path);
                }
            }
        }

        #endregion

        [HttpGet]
        public ViewResult Search1(ChancellerySearchModel searchModel)
        {
            ChancellerySearchModel csm = new ChancellerySearchModel();
            //if(searchModel == null) searchModel
            ViewBag.ListChanc = new List<ChancelleryViewModel>();
            return View(csm);

            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";

            //if (Request.HttpMethod == "GET")
            //{
            //    searchString = currentFilter;
            //}
            //else
            //{
            //    page = 1;
            //}
            //ViewBag.CurrentFilter = searchString;

            //IEnumerable< ChancelleryDTO > students = ChancelleryService.ChancelleryGet(chancSM);// = from s in db.Students
            //             //select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    students = ChancelleryService.ChancellerieGetAll().Where(s => s.RegistrationNumber.ToUpper().Contains(searchString.ToUpper())
            //                           || s.Employee.LName.ToUpper().Contains(searchString.ToUpper()));
            //}
            //else students = ChancelleryService.ChancellerieGetAll();
            //switch (sortOrder)
            //{
            //    case "Name desc":
            //        students = students.OrderByDescending(s => s.RegistrationNumber);
            //        break;
            //    case "Date":
            //        students = students.OrderBy(s => s.DateRegistration);
            //        break;
            //    case "Date desc":
            //        students = students.OrderByDescending(s => s.DateRegistration);
            //        break;
            //    default:
            //        students = students.OrderBy(s => s.RegistrationNumber);
            //        break;
            //}

            //int pageSize = 3;
            //int pageIndex = (page ?? 1);
            //var listChancVM = MapBLLRrsr.GetMap().Map<IEnumerable<ChancelleryDTO>, IEnumerable<ChancelleryViewModel>>(students);
            //return View(listChancVM);
            //return View(listChancVM.ToPagedList(pageIndex, pageSize));
        }

        //[HttpPost]
        public ActionResult Search(ChancellerySearchModelVM searchModelVM)
        {
            if (Request.HttpMethod == "POST")
                Session.Add("search", searchModelVM.ChancellerySearchModel);
            
            //else ViewBag.ListChanc = new List<ChancelleryViewModel>();
            ChancellerySearchModel search = (ChancellerySearchModel)Session["search"];
            searchModelVM.ChancellerySearchModel = search;
            searchModelVM.Chancelleries = MapBLLRrsr.GetMap().Map<IEnumerable<ChancelleryDTO>, IEnumerable<ChancelleryViewModel>>( ChancelleryService.ChancelleryGet(search));
            //Session.Add("search", searchModel);
            //else search = (ChancellerySearchModel)Session["search"];
            //else Session.Add("search", searchModel);
            return View(searchModelVM);
        }
    }
}

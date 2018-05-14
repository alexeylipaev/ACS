using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.Models;
using ACS.WEB.Util;
using ACS.WEB.ViewModel;
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
            var chancelleryDTOs = ChancelleryService.ChancellerieGetAll();
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


        public ActionResult Create(int TypeRecordId)
        {
            ViewBag.EmplsCollection = GetEmplCollection();
            ViewBag.FoldersCollection = GetFoldersCollection();
            ViewBag.JournalsCollection = GetJournalsCollection();
            ViewBag.ExternalOrgsCollection = GetExtOrgsCollection();

            var typeVM = MapBLLRrsr.GetMap().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>(ChancelleryService.TypeRecordGetById(TypeRecordId));

            ViewBag.ActionName = typeVM.Name + " корреспонденция";

            ViewBag.Title = typeVM.Name;

            var newChancelleryVM = new ChancelleryViewModel();
            newChancelleryVM.TypeRecordId = TypeRecordId;
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
                newChancelleryVM.TypeRecordChancellery = MapBLLRrsr.GetMap().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>(ChancelleryService.TypeRecordGetById((int)newChancelleryVM.TypeRecordId));

                var idResponsible = (int)newChancelleryVM.ResponsibleEmployee_Id;//.SelectedResponsible.SelectedId.FirstOrDefault();

                if (idResponsible > 0)
                    newChancelleryVM.Employee = MapBLLRrsr.GetMap().Map<EmployeeDTO, EmployeeViewModel>(ChancelleryService.GetEmployee(idResponsible));

                var idFolder = (int)newChancelleryVM.FolderId;//newChancelleryVM.SelectedFolder.SelectedId;

                if (idFolder > 0)
                    newChancelleryVM.FolderChancellery = MapBLLRrsr.GetMap().Map<FolderChancelleryDTO, FolderChancelleryViewModel>(ChancelleryService.FolderGet(idFolder));

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
                else if (newChancelleryVM.TypeRecordChancellery.id == 2)
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
                else if (newChancelleryVM.TypeRecordChancellery.id == 3)
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

                    var chancelleryDTO = MapBLLRrsr.GetMap().Map<ChancelleryViewModel,ChancelleryDTO>(newChancelleryVM);
                    //var chancelleryDTO = Map_Chancellery.Map_ChancelleryViewModel_to_ChancelleryDTO(newChancelleryVM);
                    AddFiles(/*this.Request.Files.GetMultiple("Files")*/Files, chancelleryDTO);

                    ChancelleryService.CreateChancellery(chancelleryDTO, currentUserEmail);
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
            ViewBag.EmplsCollection = GetEmplCollection();
            ViewBag.FoldersCollection = GetFoldersCollection();
            ViewBag.JournalsCollection = GetJournalsCollection();
            ViewBag.ExternalOrgsCollection = GetExtOrgsCollection();

            ChancelleryDTO chancDTO = ChancelleryService.ChancelleryGet(id);
            var chancVM = MapBLLRrsr.GetMap().Map<ChancelleryDTO , ChancelleryViewModel>(chancDTO);

            chancVM.SelectedFolder = new SelectedFolderChancellery() { Id = id, SelectedId =  chancDTO.FolderChancellery.id };
            chancVM.SelectedJournalsReg = new SelectedJournalRegChancellery() { Id = id, SelectedId = chancDTO.JournalRegistrationsChancellery.id };
   
            chancVM.SelectedResponsible = new SelectedEmployeeViewModel() { Id = id };
            chancVM.SelectedResponsible.SelectedId.Add(chancDTO.Employee.id);

            if (chancVM.TypeRecordChancellery.id == 1)
            {
                var To = chancDTO.ToChancelleries.FirstOrDefault();
                if (To != null)
                {
                    var empTo = To.Employee;
                    if (empTo != null)
                        chancVM.Selected_To_Empl = new SelectedEmployeeViewModel() { Id = id, SelectedId = { (empTo.id) } };
                }
                var From = chancDTO.FromChancelleries.FirstOrDefault();
                if (From != null)
                {
                    var extOrgFrom = From.ExternalOrganization;
                    if (extOrgFrom != null)
                        chancVM.Selected_ExtOrg = new SelectedExternalOrgViewModel() { Id = id, SelectedId = { (extOrgFrom.id) } };
                }
            }
            else if (chancVM.TypeRecordChancellery.id == 2)
            {
                foreach (var To in chancDTO.ToChancelleries)
                {
                    var extOrg = To.ExternalOrganization;
                    if (extOrg != null)
                        chancVM.Selected_ExtOrg = new SelectedExternalOrgViewModel() { Id = id, SelectedId = { (extOrg.id) } };
                }
                var From = chancDTO.FromChancelleries.FirstOrDefault();
                if (From != null)
                {
                    var empFrom = From.Employee;
                    if (empFrom != null)
                        chancVM.Selected_From_Empl = new SelectedEmployeeViewModel() { Id = id, SelectedId = { (empFrom.id) } };
                }
            }
            else if (chancVM.TypeRecordChancellery.id == 3)
            {
                var To = chancDTO.ToChancelleries.FirstOrDefault();
                if (To != null)
                {
                    var empTo = chancDTO.ToChancelleries.FirstOrDefault().Employee;
                    if (empTo != null)
                        chancVM.Selected_To_Empl = new SelectedEmployeeViewModel() { Id = id, SelectedId = { (empTo.id) } };
                }
                var From = chancDTO.FromChancelleries.FirstOrDefault();
                if (From != null)
                {
                    var empTo = chancDTO.FromChancelleries.FirstOrDefault().Employee;
                    if (empTo != null)
                        chancVM.Selected_To_Empl = new SelectedEmployeeViewModel() { Id = id, SelectedId = { (empTo.id) } };
                }
            }

            return View(chancVM);
        }

        // POST: Chancellery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ChancelleryViewModel chancVM, int TypeRecordIds, int ResponsibleEmployee_Id, int Journal_Id, int Folder_Id)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        chancVM.TypeRecordChancellery = GetMapChancelleryVMToDTO().Map<TypeRecordChancelleryDTO, TypeRecordChancelleryViewModel>(ChancelleryService.TypeRecordGetById(TypeRecordIds));
            //        chancVM.JournalRegistrationsChancellery = GetMapChancelleryVMToDTO().Map<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>(ChancelleryService.GetJournalRegistrations(Journal_Id));
            //        chancVM.FolderChancellery = GetMapChancelleryVMToDTO().Map<FolderChancelleryDTO, FolderChancelleryViewModel>(ChancelleryService.FolderGet(Folder_Id));

            //        var chancDTO = GetMapChancelleryVMToDTO().Map<ChancelleryViewModel, ChancelleryDTO>(chancVM);
            //        ChancelleryService.ChancelleryUpdate(chancDTO, this.User.Identity.Name);
            //        return RedirectToAction("Index");
            //    }
            //}
            //catch (ValidationException ex)
            //{
            //    ModelState.AddModelError(ex.Property, ex.Message);
            //}
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


    }
}

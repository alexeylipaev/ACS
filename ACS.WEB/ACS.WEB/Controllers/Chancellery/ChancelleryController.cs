using ACS.BLL;
using ACS.BLL.BusinessModels;
using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.Models;
using ACS.WEB.Util;
using ACS.WEB.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers
{
    [Authorize]
    public class ChancelleryController : Controller
    {
        IChancelleryService ChancelleryService;

        public ChancelleryController(IChancelleryService chancelleryService)
        {
            ChancelleryService = chancelleryService;
            MapChancelleryWEB.InitService(ChancelleryService);
        }

        const int pageSize = 12;
        // GET: Chancellery
        public async Task<ActionResult> Index()
        {
            var chancellerisDto = await ChancelleryService.GetAllAsync();
            chancellerisDto = chancellerisDto.Where(ch => ch.s_InBasket == false);

            ViewBag.Types = await GetAllTypesAsync();

            var chancelleriesVMs = MapChancelleryWEB.ListChancelleryDTOToListChancelleryVM(chancellerisDto.ToList()); /*(chancelleryDTOs.ToList());*/
            return View(chancelleriesVMs);
        }

        #region infinite scrolling 
        //public ActionResult Index(int? id)
        //{
        //    ViewBag.Types = GetAllTypes();
        //    int page = id ?? 0;
        //    if (Request.IsAjaxRequest())
        //    {

        //        return PartialView("_Items", GetItemsPage(page));
        //    }
        //    return View("IndexData", GetItemsPage(page));

        //}
        private async Task<List<ChancelleryViewModel>> GetItemsPage(int page = 1)
        {
            var chancellerisDto = await ChancelleryService.GetAllAsync();
            chancellerisDto = chancellerisDto.Where(ch => ch.s_InBasket == false);

            var itemsToSkip = page * pageSize;

            return MapChancelleryWEB.ListChancelleryDTOToListChancelleryVM(chancellerisDto)
                .OrderBy(ch => ch.Id)
                .Skip(itemsToSkip)
                .Take(pageSize).ToList();
        }

        [ChildActionOnly]

        public ActionResult table_row(List<ChancelleryViewModel> Model)
        {
            return PartialView("_Items", Model);

        }
        #endregion

        #region  для пагинации
        public async Task<ActionResult> IndexPage(int page = 1)
        {
            var chancellerisDto = await ChancelleryService.GetAllAsync();
            chancellerisDto = chancellerisDto.Where(ch => ch.s_InBasket == false);

            ViewBag.Types = await GetAllTypesAsync();

            var allVM = MapChancelleryWEB.ListChancelleryDTOToListChancelleryVM(chancellerisDto);

            IEnumerable<ChancelleryViewModel> chancelleriesVMs = allVM
                .Where(ch => ch.s_InBasket == false)
                .OrderBy(ch => ch.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = allVM.ToList().Count };
            IndexChancelleryViewModel ivm = new IndexChancelleryViewModel { PageInfo = pageInfo, Chancelleries = chancelleriesVMs };
            return View(ivm);

        }

        #endregion

        // GET: Chancellery/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var chancelleryDTO = await ChancelleryService.FindAsync(id);
            var chancelleriesVM = MapChancelleryWEB.chancelleryDtoToChancelleryVM(chancelleryDTO);
            return View(chancelleriesVM);
        }

        async Task<IEnumerable<EmployeeViewModel>> GetEmplCollectionAsync()
        {
            var empls = await ChancelleryService.GetAllEmployeesAsync();
            List<EmployeeViewModel> collection = new List<EmployeeViewModel>() { null };
            collection.AddRange(MapEmplWEB.ListEmplToListemplVM(empls).Where(ch => ch.s_InBasket == false).OrderBy(emp => emp.LName));
            return collection;
        }
        async Task<IEnumerable<FolderChancelleryViewModel>> GetFoldersCollectionAsync()
        {
            var folders = await ChancelleryService.GetAllFolders();
            List<FolderChancelleryViewModel> collection = new List<FolderChancelleryViewModel>() { null };
            collection.AddRange(MapChancelleryWEB.ListFolderDTOToListFolderVM(folders).Where(ch => ch.s_InBasket == false).OrderBy(emp => emp.Name));
            return collection;
        }
        async Task<IEnumerable<JournalRegistrationsViewModel>> GetJournalsCollectionAsync()
        {
            var journals = await ChancelleryService.GetAllJournalesRegistrationsAsync();
            List<JournalRegistrationsViewModel> collection = new List<JournalRegistrationsViewModel>() { null };
            collection.AddRange(MapChancelleryWEB.ListJournalDTOToListJournalVM(journals).Where(ch => ch.s_InBasket == false).OrderBy(emp => emp.Name));
            return collection;
        }
        async Task<IEnumerable<ExternalOrganizationViewModel>> GetExtOrgsCollectionAsync()
        {
            var extOrgs = await ChancelleryService.GetAllExternalOrganizationsAsync();
            List<ExternalOrganizationViewModel> collection = new List<ExternalOrganizationViewModel>() { null };
            collection.AddRange(MapExtrlOrgWEB.ListExtlOrgDTOToListextlOrgVM(extOrgs).Where(ch => ch.s_InBasket == false).OrderBy(emp => emp.Name));
            return collection;
        }

        async Task FillViewBagCollectionAsync()
        {
            Collections.Folders = await GetFoldersCollectionAsync();
            Collections.Empls = await GetEmplCollectionAsync();
            Collections.Journals = await GetJournalsCollectionAsync();
            Collections.ExtlOrgs = await GetExtOrgsCollectionAsync();
       
        }

        #region Входящая канцелярия
        const string SearchSessionName = "chancellerySearch";
        public async Task<ActionResult> Incoming(ChancellerySearchModelVM searchModelVM, int? page)
        {
            await FillViewBagCollectionAsync();
            ChancellerySearchModel searchModel;

            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    searchModel = searchModelVM as ChancellerySearchModel;
                    Session.Add(SearchSessionName, searchModel);
                    page = 1;
                }
            }

            if (searchModelVM == null)
                searchModelVM = new ChancellerySearchModelVM();

            searchModel = (ChancellerySearchModel)Session[SearchSessionName];

            if (searchModel != null)
                searchModelVM = MapChancelleryWEB.ChancellerySearchModelToChancellerySearchModelVM(searchModel);

            var incomingsDTO = await ChancelleryService.ChancelleryGetAllIncomingAsync(searchModelVM);
            var chancelleriesVM = await MapChancelleryWEB.ListCorrespondencesBaseDTOToListChancelleryVM(incomingsDTO);

            searchModelVM.Chancelleries = chancelleriesVM;
            return View(searchModelVM);
        }




        public async Task<ActionResult> EditIncoming(int id)
        {
            await FillViewBagCollectionAsync();

            //ChancellerySearchModel searchModel = new ChancellerySearchModel { Id = id };

            IncomingCorrespondencyDTO chancelleriesIncomingDto = await ChancelleryService.FindIncomingAsync(id);

            var IncomingCorrespondencyInput = await MapChancelleryWEB.IncomingDTOToIncomingInput(chancelleriesIncomingDto);
            var files = await ChancelleryService.GetAllFilesChancelleryAsync(chancelleriesIncomingDto);
            IncomingCorrespondencyInput.FileRecordChancelleries = files.Select(f => f.Id);
            IncomingCorrespondencyInput.TypeRecordChancelleryId = (byte)Constants.CorrespondencyType.Internal;

            ViewBag.ActionName = "Редактирование";
            ViewBag.TypeName = "Входящая корреспонденция";

            ViewBag.Title = "Редактирование " + ViewBag.TypeName;
            ViewBag.NameBtn = "Сохранить";

            return View(IncomingCorrespondencyInput);
        }

        async Task<ActionResult> IncomingCreateOrUpdate(IncomingCorrespondencyInput IncomingInput, IEnumerable<HttpPostedFileBase> Files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var authorEmail = this.User.Identity.Name;

                    var IncomingDto = MapChancelleryWEB.IncomingInputToIncomingDTO(IncomingInput);
                    if (Files != null && Files.FirstOrDefault() != null)
                    {
                        var files = ChancelleryService.AttachFiles(Files, authorEmail);// Attach(Files, chancelleryDTO);
                        IncomingDto.FileRecordChancelleries = files.Select(f => f.Id);
                    }
                    await ChancelleryService.ChancelleryCreateOrUpdateIncomingAsync(IncomingDto, this.User.Identity.Name);
                    return RedirectToAction("Incoming");
                }

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(IncomingInput);
        }

        // POST: Chancellery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditIncoming(IncomingCorrespondencyInput IncomingInput, IEnumerable<HttpPostedFileBase> Files)
        {
            return await IncomingCreateOrUpdate(IncomingInput, Files);
        }
        public async Task<ActionResult> CreateIncoming()
        {
            await FillViewBagCollectionAsync();

            ViewBag.NameBtn = "Создать";
            var IncomingInput = new IncomingCorrespondencyInput();
            IncomingInput.DateRegistration = DateTime.Today;

            return View(IncomingInput);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "id,DateRegistration,RegistrationNumber,Summary,TypeRecordId,ResponsibleEmployee_Id,FolderChancellery,JournalRegistrationsChancellery,FileRecordChancelleries, FromChancelleries,ToChancelleries")] 
        public async Task<ActionResult> CreateIncoming(IncomingCorrespondencyInput IncomingInput, IEnumerable<HttpPostedFileBase> Files)
        {
            IncomingInput.TypeRecordChancelleryId = (byte)Constants.CorrespondencyType.Incoming;
            return IncomingCreateOrUpdate(IncomingInput, Files);
        }
        #endregion

        #region Исходящая канцелярия

        public async Task<ActionResult> Outgoing(ChancellerySearchModelVM searchModelVM, int? page)
        {
            const string SearchSessionName = "chancellerySearch";
            ChancellerySearchModel searchModel;

            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    searchModel = searchModelVM as ChancellerySearchModel;
                    Session.Add(SearchSessionName, searchModel);
                    page = 1;
                }
            }

            if (searchModelVM == null)
                searchModelVM = new ChancellerySearchModelVM();

            searchModel = (ChancellerySearchModel)Session[SearchSessionName];

            if (searchModel != null)
                searchModelVM = MapChancelleryWEB.ChancellerySearchModelToChancellerySearchModelVM(searchModel);

            var OutgoingsDTO = await ChancelleryService.ChancelleryGetAllOutgoingAsync(searchModelVM);
            var chancelleriesVM = await MapChancelleryWEB.ListCorrespondencesBaseDTOToListChancelleryVM(OutgoingsDTO);

            searchModelVM.Chancelleries = chancelleriesVM;
            return View(searchModelVM);
        }

        ActionResult OutgoingCreateOrUpdate(OutgoingCorrespondencyInput OutgoingInput, IEnumerable<HttpPostedFileBase> Files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var authorEmail = this.User.Identity.Name;

                    var OutgoingDto = MapChancelleryWEB.OutgoingInputToOutgoingDTO(OutgoingInput);
                    if (Files != null && Files.FirstOrDefault() != null)
                    {
                        var files = ChancelleryService.AttachFiles(Files, authorEmail);// Attach(Files, chancelleryDTO);
                        OutgoingDto.FileRecordChancelleries = files.Select(f => f.Id);
                    }
                    ChancelleryService.ChancelleryCreateOrUpdateOutgoingAsync(OutgoingDto, this.User.Identity.Name);
                    return RedirectToAction("Outgoing");
                }

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(OutgoingInput);
        }


        public async Task<ActionResult> EditOutgoing(int id)
        {
            await FillViewBagCollectionAsync();

            //ChancellerySearchModel searchModel = new ChancellerySearchModel { Id = id };

            OutgoingCorrespondencyDTO OutgoingDTO = await ChancelleryService.FindOutgoingAsync(id);

            var OutgoingInput = await MapChancelleryWEB.OutgoingDTOToOutgoingInput(OutgoingDTO);
            OutgoingInput.TypeRecordChancelleryId = (byte)Constants.CorrespondencyType.Outgoing;
            ViewBag.ActionName = "Редактирование";
            ViewBag.TypeName = "Входящая корреспонденция";

            ViewBag.Title = "Редактирование " + ViewBag.TypeName;
            ViewBag.NameBtn = "Сохранить";

            return View(OutgoingInput);
        }

        // POST: Chancellery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOutgoing(OutgoingCorrespondencyInput OutgoingInput, IEnumerable<HttpPostedFileBase> Files)
        {
            OutgoingInput.TypeRecordChancelleryId = (byte)Constants.CorrespondencyType.Outgoing;
            return OutgoingCreateOrUpdate(OutgoingInput, Files);
        }
        public async Task<ActionResult> CreateOutgoing()
        {
            await FillViewBagCollectionAsync();

            ViewBag.NameBtn = "Создать";
            var OutgoingInput = new OutgoingCorrespondencyInput();
            OutgoingInput.DateRegistration = DateTime.Today;

            return View(OutgoingInput);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "id,DateRegistration,RegistrationNumber,Summary,TypeRecordId,ResponsibleEmployee_Id,FolderChancellery,JournalRegistrationsChancellery,FileRecordChancelleries, FromChancelleries,ToChancelleries")] 
        public ActionResult CreateOutgoing(OutgoingCorrespondencyInput OutgoingInput, IEnumerable<HttpPostedFileBase> Files)
        {
            OutgoingInput.TypeRecordChancelleryId = (byte)Constants.CorrespondencyType.Outgoing;
            return OutgoingCreateOrUpdate(OutgoingInput, Files);
        }
        #endregion

        #region Внутреняя канцелярия

        //[HttpPost]
        public async Task<ActionResult> Internal(ChancellerySearchModelVM searchModelVM, int? page)
        {
            ChancellerySearchModel searchModel;

            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    searchModel = searchModelVM as ChancellerySearchModel;
                    Session.Add(SearchSessionName, searchModel);
                    page = 1;
                }
            }

            if (searchModelVM == null)
                searchModelVM = new ChancellerySearchModelVM();

            searchModel = (ChancellerySearchModel)Session[SearchSessionName];

            if (searchModel != null)
                searchModelVM = MapChancelleryWEB.ChancellerySearchModelToChancellerySearchModelVM(searchModel);

            var InternalsDTO = await ChancelleryService.ChancelleryGetAllInternalAsync(searchModelVM);
            var chancelleriesVM = await MapChancelleryWEB.ListCorrespondencesBaseDTOToListChancelleryVM(InternalsDTO);

            searchModelVM.Chancelleries = chancelleriesVM;
            return View(searchModelVM);
        }

        ActionResult InternalCreateOrUpdate(InternalCorrespondencyInput InternalInput, IEnumerable<HttpPostedFileBase> Files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var authorEmail = this.User.Identity.Name;

                    var InternalDto = MapChancelleryWEB.InternalInputToInternalDTO(InternalInput);
                    if (Files != null && Files.FirstOrDefault() != null)
                    {
                        var files = ChancelleryService.AttachFiles(Files, authorEmail);// Attach(Files, chancelleryDTO);
                        InternalDto.FileRecordChancelleries = files.Select(f => f.Id);
                    }
                    ChancelleryService.ChancelleryCreateOrUpdateInternalAsync(InternalDto, this.User.Identity.Name);
                    return RedirectToAction("Internal");
                }

            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(InternalInput);
        }

        public async Task<ActionResult> EditInternal(int id)
        {
            await FillViewBagCollectionAsync();

            InternalCorrespondencyDTO InternalDTO = await ChancelleryService.FindInternalAsync(id);

            var InternalInput = await MapChancelleryWEB.InternalDTOToInternalInput(InternalDTO);
            InternalInput.TypeRecordChancelleryId = (byte)Constants.CorrespondencyType.Internal;

            var files = await ChancelleryService.GetAllFilesChancelleryAsync(InternalDTO);

            InternalInput.FileRecordChancelleries = files.Select(f=>f.Id);

            ViewBag.ActionName = "Редактирование";
            ViewBag.TypeName = "Входящая корреспонденция";

            ViewBag.Title = "Редактирование " + ViewBag.TypeName;
            ViewBag.NameBtn = "Сохранить";

            return View(InternalInput);
        }

        // POST: Chancellery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInternal(InternalCorrespondencyInput InternalInput, IEnumerable<HttpPostedFileBase> Files)
        {
            InternalInput.TypeRecordChancelleryId = (byte)Constants.CorrespondencyType.Internal;
            return InternalCreateOrUpdate(InternalInput, Files);
        }
        public async Task<ActionResult> CreateInternal()
        {
            await FillViewBagCollectionAsync();

            ViewBag.NameBtn = "Создать";
            var InternalInput = new InternalCorrespondencyInput();
            InternalInput.DateRegistration = DateTime.Today;

            return View(InternalInput);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "id,DateRegistration,RegistrationNumber,Summary,TypeRecordId,ResponsibleEmployee_Id,FolderChancellery,JournalRegistrationsChancellery,FileRecordChancelleries, FromChancelleries,ToChancelleries")] 
        public ActionResult CreateInternal(InternalCorrespondencyInput InternalInput, IEnumerable<HttpPostedFileBase> Files)
        {
            InternalInput.TypeRecordChancelleryId = (byte)Constants.CorrespondencyType.Internal;
            return InternalCreateOrUpdate(InternalInput, Files);
        }
        #endregion


        public async Task<ActionResult> Create(int TypeRecordId)
        {

            ViewBag.NameBtn = "Создать";

            switch (TypeRecordId)
            {
                case (byte)Constants.CorrespondencyType.Incoming:
                    {
                        ActionResult action = await this.CreateIncoming();
                        return action;
                    }

                case (byte)Constants.CorrespondencyType.Outgoing:
                    {
                        ActionResult action = await this.CreateOutgoing();
                        return action;
                    }

                case (byte)Constants.CorrespondencyType.Internal:
                    {
                        ActionResult action = await this.CreateInternal();
                        return action;
                    }

                default:
                    break;
            }


            return View();
        }


        // GET: Chancellery/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var chancelleryDto = await ChancelleryService.FindAsync(id);

            var types = await ChancelleryService.GetAllTypesChancelleryAsync();

            var type = types.FirstOrDefault(t => t.Name == chancelleryDto.Type);

            switch (type.Id)
            {
                case (byte)Constants.CorrespondencyType.Incoming:
                    {
                        ActionResult action = await this.EditIncoming(id);
                        return action;
                    }

                case (byte)Constants.CorrespondencyType.Outgoing:
                    {
                        ActionResult action = await this.EditOutgoing(id);
                        return action;
                    }

                case (byte)Constants.CorrespondencyType.Internal:
                    {
                        ActionResult action = await this.EditInternal(id);
                        return action;
                    }

                default:
                    break;
            }
            return View();
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
            throw new Exception("MoveToBasket не реализован ");
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        ChancelleryDTO chancDTO = ChancelleryService.ChancelleryGet(id);
            //        chancDTO.s_InBasket = true;

            //        ChancelleryService.CreateOrUpdateChancellery(chancDTO, this.User.Identity.Name);

            //        ViewBag.EditResult = "Данные успешно перемещены в корзину";

            //    }
            //}
            //catch (ValidationException ex)
            //{
            //    ModelState.AddModelError(ex.Property, ex.Message);
            //}
            //return RedirectToAction("Index");
        }


        // GET: Chancellery/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            ActionResult action = await this.DeleteConfirmed(id);
            return action;
        }

        // POST: Chancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {

                    result = await ChancelleryService.DeleteAsync(id);
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



        private async Task<IEnumerable<TypeRecordChancelleryViewModel>> GetAllTypesAsync()
        {
            var typesDTO = await ChancelleryService.GetAllTypesChancelleryAsync();

            return MapChancelleryWEB.ListTypeDTOToListTypeVM(typesDTO);
        }
        #region работа с файлами

        public async Task<FilePathResult> DownloadFile(int id)
        {
            var fileDTO = await ChancelleryService.FindFileAsync(id);
            string path = (fileDTO.Path);
            string type = fileDTO.Extension;
            string name = fileDTO.FileName;
            return File(path, type, null);
        }


        public ActionResult AttachFiles(int ChancelleryId)
        {
            ViewBag.ChancelleryId = ChancelleryId;
            return View();
        }

        public async Task<ActionResult> DettachFile(int ChancelleryId, int FileId)
        {
            //ViewBag.ChancelleryId = ChancelleryId;
            FilesDTO fileDTO = await ChancelleryService.FindFileAsync(FileId);
            ChancelleryService.AttachOrDetachFile(fileDTO, this.User.Identity.Name, ChancelleryId, false);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Attach(IEnumerable<HttpPostedFileBase> files, int ChancelleryId)
        {
            int result = 0;
            try
            {
                if (ModelState.IsValid)
                {

                    result = ChancelleryService.AttachFiles(files, ChancelleryId, this.User.Identity.Name);
                    if (result > 0)
                        ViewBag.EditResult = "Файлы успешно добавлены";
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return RedirectToAction("Index");

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

    }
}

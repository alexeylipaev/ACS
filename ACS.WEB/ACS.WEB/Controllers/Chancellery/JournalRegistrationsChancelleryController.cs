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
    public class JournalRegistrationsChancelleryController : Controller
    {
        IJournalRegistrationsChancelleryService JournalRegistrationsChancelleryService;

        public JournalRegistrationsChancelleryController(IJournalRegistrationsChancelleryService journalRegistrationsChancelleryService)
        {
            JournalRegistrationsChancelleryService = journalRegistrationsChancelleryService;
        }
        // GET: JournalRegistrationsChancellery
        public ActionResult Index()
        {
            var journaldVM = mapTempJournalDTOToJournalVM().Map<IEnumerable<JournalRegistrationsChancelleryDTO>, List<JournalRegistrationsChancelleryViewModel>>(JournalRegistrationsChancelleryService.GetJournalsChancellery());
            return View(journaldVM);
        }

        // GET: JournalRegistrationsChancellery/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var journalDTO = JournalRegistrationsChancelleryService.GetJournal(id);

                var journalVM = MappJournalDTOToJournalVM(journalDTO);
                return View(journalVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: JournalRegistrationsChancellery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JournalRegistrationsChancellery/Create
        [HttpPost]
        public ActionResult Create(JournalRegistrationsChancelleryViewModel journalVM)
        {
            return CreateOrUpdateOrDel(journalVM);
        }

        // GET: JournalRegistrationsChancellery/Edit/5
        public ActionResult Edit(int id)
        {
            var VM = GetJournalVM(id);
            return View(VM);
        }

        // POST: JournalRegistrationsChancellery/Edit/5
        [HttpPost]
        public ActionResult Edit(JournalRegistrationsChancelleryViewModel journalVM)
        {
            return CreateOrUpdateOrDel(journalVM);
        }

        // GET: JournalRegistrationsChancellery/Delete/5
        public ActionResult Delete(int id)
        {
            var vm = GetJournalVM(id);
            ActionResult action = this.DeleteConfirmed(id);
            return action;
        }

        // POST: JournalRegistrationsChancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var journalDTO = JournalRegistrationsChancelleryService.GetJournal(id);
            var journalVM = MappJournalDTOToJournalVM(journalDTO);
            return CreateOrUpdateOrDel(journalVM, true);
        }

        ActionResult CreateOrUpdateOrDel(/*[Bind(Include = "Id,Name")]*/ JournalRegistrationsChancelleryViewModel journalVM, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var journalDto = MappJournalVMToJournalDTO(journalVM);

                    int result = 0;

                    if (del)
                    {
                        result = JournalRegistrationsChancelleryService.DeleteJournal(journalDto.id);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = JournalRegistrationsChancelleryService.CreateOrUpdateJournal(journalDto, currentUserEmail);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(journalVM);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(journalVM);
        }

        JournalRegistrationsChancelleryViewModel GetJournalVM(int id)
        {
            var journalDTO = JournalRegistrationsChancelleryService.GetJournal(id);
            if (journalDTO == null) { throw new Exception("Папка не найдена"); }
            return MappJournalDTOToJournalVM(journalDTO);
        }

        IMapper mapTempJournalDTOToJournalVM()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>();
                cfg.CreateMap<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>();

            }).CreateMapper();
        }


        JournalRegistrationsChancelleryViewModel MappJournalDTOToJournalVM(JournalRegistrationsChancelleryDTO JournalDTO)
        {
            return mapTempJournalDTOToJournalVM().Map<JournalRegistrationsChancelleryDTO, JournalRegistrationsChancelleryViewModel>(JournalDTO);
        }


        JournalRegistrationsChancelleryDTO MappJournalVMToJournalDTO(JournalRegistrationsChancelleryViewModel JournalVM)
        {
            //var mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<ChancelleryViewModel, ChancelleryDTO  > ();
            //    cfg.CreateMap<JournalRegistrationsChancelleryViewModel, JournalRegistrationsChancelleryDTO  > ();

            //}).CreateMapper();
            return MapBLLRrsr.GetMap().Map<JournalRegistrationsChancelleryViewModel, JournalRegistrationsChancelleryDTO>(JournalVM);
        }

        //private bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                JournalRegistrationsChancelleryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

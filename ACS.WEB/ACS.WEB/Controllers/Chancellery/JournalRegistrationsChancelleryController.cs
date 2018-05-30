using ACS.BLL.DTO;
using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.Util;
using ACS.WEB.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index()
        {
            var journalsDto = await JournalRegistrationsChancelleryService.GetAllAsync();
            journalsDto = journalsDto.Where(ch => ch.s_InBasket == false);

            var journalsVM = MapChancelleryWEB.ListJournalDTOToListJournalVM(journalsDto.ToList()); /*(chancelleryDTOs.ToList());*/
            return View(journalsVM);
        }

        // GET: JournalRegistrationsChancellery/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var journalDTO = await JournalRegistrationsChancelleryService.FindAsync(id);

                var journalVM = MapChancelleryWEB.JournalDtoToJournalVM(journalDTO);
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
            JournalCorrespondencesInput newJournal = new JournalCorrespondencesInput();
            return View(newJournal);
        }

        // POST: JournalRegistrationsChancellery/Create
        [HttpPost]
        public async Task<ActionResult> Create(JournalCorrespondencesInput JournalInput)
        {
            return await CreateOrUpdateOrDelAsync(JournalInput);
        }

        // GET: JournalRegistrationsChancellery/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var journalDTO = await JournalRegistrationsChancelleryService.FindAsync(id);
            if (journalDTO == null) { throw new Exception("Папка не найдена"); }
            return View(MapChancelleryWEB.JournalDtoToJournalVM(journalDTO));
        }

        // POST: JournalRegistrationsChancellery/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(JournalCorrespondencesInput JournalInput)
        {
            return await CreateOrUpdateOrDelAsync(JournalInput);
        }

        // GET: JournalRegistrationsChancellery/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            ActionResult action = await this.DeleteConfirmed(id);
            return action;
        }

        // POST: JournalRegistrationsChancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var journalDTO = await JournalRegistrationsChancelleryService.FindAsync(id);
            if (journalDTO == null) { throw new Exception("Папка не найдена"); }
            return await CreateOrUpdateOrDelAsync(MapChancelleryWEB.JournalDtoToJournalInput(journalDTO), true);
        }

      async Task <ActionResult> CreateOrUpdateOrDelAsync(/*[Bind(Include = "Id,Name")]*/ JournalCorrespondencesInput JournalInput, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var journalDto = MapChancelleryWEB.JournalInputToJournalDto(JournalInput);

                    int result = 0;

                    if (del)
                    {
                        result = await JournalRegistrationsChancelleryService.DeleteAsync(journalDto.Id);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = await JournalRegistrationsChancelleryService.CreateOrUpdateAsync(journalDto, currentUserEmail);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(JournalInput);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(JournalInput);
        }


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

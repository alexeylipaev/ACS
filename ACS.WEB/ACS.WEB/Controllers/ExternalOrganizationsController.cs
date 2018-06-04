using ACS.BLL.Infrastructure;
using ACS.BLL.Interfaces;
using ACS.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ACS.WEB.Controllers
{
    public class ExternalOrganizationsController : Controller
    {
        IExternalOrganizationService ExternalOrganizationService;

        public ExternalOrganizationsController(IExternalOrganizationService externalOrganizationService)
        {
            ExternalOrganizationService = externalOrganizationService;
        }
        // GET: ExternalOrganizationsChancellery
        public async Task<ActionResult> Index()
        {
            var ExternalOrganizationsDto = await ExternalOrganizationService.GetAllAsync();
            ExternalOrganizationsDto = ExternalOrganizationsDto.Where(ch => ch.s_InBasket == false);

            var ExternalOrganizationsVM = MapExtrlOrgWEB.ListExtlOrgDTOToListextlOrgVM(ExternalOrganizationsDto.ToList()); /*(chancelleryDTOs.ToList());*/
            return View(ExternalOrganizationsVM);

        }

        // GET: ExternalOrganizationsChancellery/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var externalOrganizationDTO = await ExternalOrganizationService.FindAsync(id);

                var externalOrganizationVM = MapExtrlOrgWEB.ExtlOrgDTOToExtlOrgVM(externalOrganizationDTO);
                return View(externalOrganizationVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: ExternalOrganizationsChancellery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExternalOrganizationsChancellery/Create
        [HttpPost]
        public async Task<ActionResult> Create(ExternalOrganizationInput ExternalOrganizationInput)
        {
            await CreateOrUpdateOrDelAsync(ExternalOrganizationInput);
            return RedirectToAction("Index");
        }

        // GET: ExternalOrganizationsChancellery/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var VM = await GetExternalOrganizationInputAsync(id);
            return View(VM);
        }

        // POST: ExternalOrganizationsChancellery/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ExternalOrganizationInput ExternalOrganizationInput)
        {
            await CreateOrUpdateOrDelAsync(ExternalOrganizationInput);
            return RedirectToAction("Index");
        }

        // GET: ExternalOrganizationsChancellery/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var vm = GetExternalOrganizationInputAsync(id);
            ActionResult action = await this.DeleteConfirmed(id);
            return action;
        }

        // POST: ExternalOrganizationsChancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var externalOrganizationDTO = await ExternalOrganizationService.FindAsync(id);
            var externalOrganizationInput = MapExtrlOrgWEB.ExternalOrganizationDTOToExternalOrganizationInput(externalOrganizationDTO);
            await CreateOrUpdateOrDelAsync(externalOrganizationInput, true);
            return RedirectToAction("Index");
        }

        async Task<ActionResult> CreateOrUpdateOrDelAsync(/*[Bind(Include = "Id,Name")]*/ ExternalOrganizationInput ExternalOrganizationInput, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var externalOrganizationDto = MapExtrlOrgWEB.ExtlOrgVMToExtlOrgDTO(ExternalOrganizationInput);

                    int result = 0;

                    if (del)
                    {
                        result = await ExternalOrganizationService.DeleteAsync(externalOrganizationDto.Id);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = await ExternalOrganizationService.CreateOrUpdateAsync(externalOrganizationDto, currentUserEmail);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(ExternalOrganizationInput);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(ExternalOrganizationInput);
        }

        async Task<ExternalOrganizationInput> GetExternalOrganizationInputAsync(int id)
        {
            var externalOrganizationDTO = await ExternalOrganizationService.FindAsync(id);
            if (externalOrganizationDTO == null) { throw new Exception("Организация не найдена"); }
            return MapExtrlOrgWEB.ExternalOrganizationDTOToExternalOrganizationInput(externalOrganizationDTO);
        }

       
        private bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ExternalOrganizationService.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}

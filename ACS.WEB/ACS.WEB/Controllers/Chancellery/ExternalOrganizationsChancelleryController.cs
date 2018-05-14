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
    public class ExternalOrganizationsChancelleryController : Controller
    {
        IExternalOrganizationChancelleryService ExternalOrganizationsChancelleryService;

        public ExternalOrganizationsChancelleryController(IExternalOrganizationChancelleryService externalOrganizationsChancelleryService)
        {
            ExternalOrganizationsChancelleryService = externalOrganizationsChancelleryService;
        }
        // GET: ExternalOrganizationsChancellery
        public ActionResult Index()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancelleryViewModel>()).CreateMapper();
            var externalOrganizationdVM = MapBLLRrsr.GetMap().Map<IEnumerable<ExternalOrganizationChancelleryDTO>, List<ExternalOrganizationChancelleryViewModel>>(ExternalOrganizationsChancelleryService.GetExternalOrganizationsChancellery());
            return View(externalOrganizationdVM);
        }

        // GET: ExternalOrganizationsChancellery/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var externalOrganizationDTO = ExternalOrganizationsChancelleryService.GetExternalOrganization(id);

                var externalOrganizationVM = MappExternalOrganizationDTOToExternalOrganizationVM(externalOrganizationDTO);
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
        public ActionResult Create(ExternalOrganizationChancelleryViewModel externalOrganizationVM)
        {
            return CreateOrUpdateOrDel(externalOrganizationVM);
        }

        // GET: ExternalOrganizationsChancellery/Edit/5
        public ActionResult Edit(int id)
        {
            var VM = GetExternalOrganizationVM(id);
            return View(VM);
        }

        // POST: ExternalOrganizationsChancellery/Edit/5
        [HttpPost]
        public ActionResult Edit(ExternalOrganizationChancelleryViewModel externalOrganizationVM)
        {
            return CreateOrUpdateOrDel(externalOrganizationVM);
        }

        // GET: ExternalOrganizationsChancellery/Delete/5
        public ActionResult Delete(int id)
        {
            var vm = GetExternalOrganizationVM(id);
            ActionResult action = this.DeleteConfirmed(id);
            return action;
        }

        // POST: ExternalOrganizationsChancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var externalOrganizationDTO = ExternalOrganizationsChancelleryService.GetExternalOrganization(id);
            var externalOrganizationVM = MappExternalOrganizationDTOToExternalOrganizationVM(externalOrganizationDTO);
            return CreateOrUpdateOrDel(externalOrganizationVM, true);
        }

        ActionResult CreateOrUpdateOrDel(/*[Bind(Include = "Id,Name")]*/ ExternalOrganizationChancelleryViewModel externalOrganizationVM, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var externalOrganizationDto = MappExternalOrganizationVMToExternalOrganizationDTO(externalOrganizationVM);

                    int result = 0;

                    if (del)
                    {
                        result = ExternalOrganizationsChancelleryService.DeleteExternalOrganization(externalOrganizationDto.id);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = ExternalOrganizationsChancelleryService.CreateOrUpdateExternalOrganization(externalOrganizationDto, currentUserEmail);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(externalOrganizationVM);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(externalOrganizationVM);
        }

        ExternalOrganizationChancelleryViewModel GetExternalOrganizationVM(int id)
        {
            var externalOrganizationDTO = ExternalOrganizationsChancelleryService.GetExternalOrganization(id);
            if (externalOrganizationDTO == null) { throw new Exception("Организация не найдена"); }
            return MappExternalOrganizationDTOToExternalOrganizationVM(externalOrganizationDTO);
        }

        ExternalOrganizationChancelleryViewModel MappExternalOrganizationDTOToExternalOrganizationVM(ExternalOrganizationChancelleryDTO ExternalOrganizationDTO)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancelleryViewModel>()).CreateMapper();
            return MapBLLRrsr.GetMap().Map<ExternalOrganizationChancelleryDTO, ExternalOrganizationChancelleryViewModel>(ExternalOrganizationDTO);
        }


        ExternalOrganizationChancelleryDTO MappExternalOrganizationVMToExternalOrganizationDTO(ExternalOrganizationChancelleryViewModel ExternalOrganizationVM)
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ExternalOrganizationChancelleryViewModel, ExternalOrganizationChancelleryDTO>()).CreateMapper();
            return MapBLLRrsr.GetMap().Map<ExternalOrganizationChancelleryViewModel, ExternalOrganizationChancelleryDTO>(ExternalOrganizationVM);
        }



        private bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ExternalOrganizationsChancelleryService.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}

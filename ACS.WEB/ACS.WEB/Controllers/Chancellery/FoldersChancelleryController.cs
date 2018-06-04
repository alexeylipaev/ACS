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
namespace ACS.WEB.Controllers
{
    public class FoldersChancelleryController : Controller
    {
        IFolderChancelleryService FolderChancelleryService;

        public FoldersChancelleryController(IFolderChancelleryService folderChancelleryService)
        {

            FolderChancelleryService = folderChancelleryService;
        }

        // GET: FoldersChancellery
        public async Task<ActionResult> Index()
        {
            var foldersDto = await FolderChancelleryService.GetAllAsync();
            foldersDto = foldersDto;

            var ExternalOrganizationsVM = MapChancelleryWEB.ListFolderDTOToListFolderVM(foldersDto.ToList()); /*(chancelleryDTOs.ToList());*/
            return View(ExternalOrganizationsVM);
        }


        // GET: FoldersChancellery/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var folderDTO = await FolderChancelleryService.FindAsync(id);

                var folderVM = MapChancelleryWEB.FolderDtoToFolderVM(folderDTO);
                return View(folderVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }



        // GET: FoldersChancellery/Create
        public ActionResult Create()
        {
            FolderCorrespondencesInput newFolder = new ViewModels.FolderCorrespondencesInput();
            return View(newFolder);
        }

        // POST: FoldersChancellery/Create
        [HttpPost]
        public async Task<ActionResult> Create(FolderCorrespondencesInput folderInput)
        {
            await CreateOrUpdateOrDelAsync(folderInput);
            return RedirectToAction("Index");
        }

        // GET: FoldersChancellery/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var folderDTO = await FolderChancelleryService.FindAsync(id);
            if (folderDTO == null) { throw new Exception("Папка не найдена"); }
            return View(MapChancelleryWEB.FolderChancelleryDTOToFolderChancelleryInput(folderDTO));
  
        }


        // POST: FoldersChancellery/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(/*[Bind(Include = "Name")]*/ FolderCorrespondencesInput folderInput)
        {
            await CreateOrUpdateOrDelAsync(folderInput);
            return RedirectToAction("Index");
        }

       async Task<ActionResult> CreateOrUpdateOrDelAsync(/*[Bind(Include = "Id,Name")]*/ FolderCorrespondencesInput folderInput, bool del = false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    var folrderDto = MapChancelleryWEB.FolderInputToFolderDto(folderInput);

                    int result = 0;

                    if (del)
                    {
                        result = await FolderChancelleryService.DeleteAsync(folrderDto.Id);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно удалены";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        result = await FolderChancelleryService.CreateOrUpdateAsync(folrderDto, currentUserEmail);
                        if (result > 0)
                            ViewBag.EditResult = "Данные успешно обновлены";
                        return View(folderInput);
                    }

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(folderInput);
        }

        // GET: FoldersChancellery/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var vm = await FolderChancelleryService.FindAsync(id);
            ActionResult action = await this.DeleteConfirmed(id);
            return action;
            //return RedirectToAction("Delete", "FoldersChancellery", new { id = id });
            //return View(vm);
        }

        // POST: FoldersChancellery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var folderDTO = await FolderChancelleryService.FindAsync(id);
            var folderInput= MapChancelleryWEB.FolderChancelleryDTOToFolderChancelleryInput(folderDTO);
            return await CreateOrUpdateOrDelAsync(folderInput, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                FolderChancelleryService.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

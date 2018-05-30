using System;
using System.Linq;
using System.Web.Mvc;
using Omu.AwesomeMvc;
using ACS.BLL.Interfaces;
using ACS.BLL.DTO;
using ACS.WEB.ViewModels.Input;

namespace ACS.WEB.Controllers
{
    /// <summary>
    /// Note: If your Key Property is not "Id", you need to change the Key = "MyId" in GridGetItems and it in the view
    /// change the Bind = "MyId" (if you're showing the id column), 
    /// and for the action columns you can either specify the MyId property (e.g. GridUtils.EditFormatForGrid("DinnersGrid", "MyId"));
    /// or in MapToGridModel additionally to o.MyId add another property Id = o.MyId
    /// parameters for Edit, Delete need to remain called "id", that's how they are set in GridUtils.cs (params:{{ id: );
    /// Edit and Delete post actions must return an object with property "Id" - in utils.js itemEdited and itemDeleted funcs expect it this way;
    /// </summary>
    public class DinnersGridCrudController : Controller
    {
        IChancelleryService ChancelleryService;

        public DinnersGridCrudController(IChancelleryService chancelleryService)
        {
            ChancelleryService = chancelleryService;
        }

        private static object MapToGridModel(ChancelleryDTO o)
        {
    //        return
    //new
    //{
    //    o.Id,
    //    o.Name,
    //    Date = o.Date.ToShortDateString(),
    //    ChefName = o.Chef.FirstName + " " + o.Chef.LastName,
    //    Meals = string.Join(", ", o.Meals.Select(m => m.Name))
    //};

            return
                new
                {
                    o.Id,
                    o.RegistrationNumber,
                    DateRegistration = o.DateRegistration,
                    Summary = o.Summary,
                    Notice = o.Notice,
                    Journal = o.JournalRegistrationsChancellery != null ? o.JournalRegistrationsChancellery.Name : "",
                    FolderName = o.FolderChancellery != null? o.FolderChancellery.Name : "",
                    Type = o.TypeRecordChancellery.Name,
                    Responcible = string.Join(", ", o.ResponsibleEmployees.Select(m => m.LName+" "+m.FName + " "+ m.MName)),
                };
        }

        public ActionResult GridGetItems(GridParams g, string search)
        {
            //search = (search ?? "").ToLower();
            //var items = Db.Dinners.Where(o => o.Name.ToLower().Contains(search)).AsQueryable();

            //return Json(new GridModelBuilder<Dinner>(items, g)
            //{
            //    Key = "Id", // needed for api select, update, tree, nesting, EF
            //    GetItem = () => Db.Get<Dinner>(Convert.ToInt32(g.Key)), // called by the grid.api.update ( edit popupform success js func )
            //    Map = MapToGridModel
            //}.Build());

            search = (search ?? "").ToLower();
            var items = ChancelleryService.ChancellerieGetAll().Where(o => o.Summary != null && o.Summary.ToString().ToLower().Contains(search)).AsQueryable();

            return Json(new GridModelBuilder<ChancelleryDTO>(items, g)
            {
                Key = "Id", // needed for api select, update, tree, nesting, EF
                GetItem = () => ChancelleryService.ChancelleryGet(Convert.ToInt32(g.Key)), // called by the grid.api.update ( edit popupform success js func )
                Map = MapToGridModel
            }.Build());
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(ChancelleryInput input)
        {
            //if (!ModelState.IsValid) return PartialView(input);

            //var dinner = Db.Insert(new Dinner
            //{
            //    Name = input.Name,
            //    Date = input.Date.Value,
            //    Chef = Db.Get<Chef>(input.Chef),
            //    Meals = Db.Meals.Where(o => input.Meals.Contains(o.Id)),
            //    BonusMeal = Db.Get<Meal>(input.BonusMealId)
            //});

            //return Json(MapToGridModel(dinner)); // returning grid model, used in grid.api.renderRow

            if (!ModelState.IsValid) return PartialView(input);

    
            var ChancelleryDTO = new ChancelleryDTO()
            {
                RegistrationNumber = input.RegistrationNumber,
                DateRegistration = input.DateRegistration,
                Summary = input.Summary,
                Notice = input.Notice,
                JournalRegistrationsChancellery = ChancelleryService.GetJournalRegistrations(input.Journal.Value),
                FolderChancellery = ChancelleryService.FolderGet(input.Folder.Value),
                TypeRecordChancellery = ChancelleryService.TypeRecordGetById(input.Type.Value),
                ResponsibleEmployees = ChancelleryService.GetEmployees().Where(o => input.Responsible.Contains(o.Id)).ToList(),
                //BonusMeal = Db.Get<Meal>(input.BonusMealId)
            };

            //var chancelleryDTO = MapBLLPresenter.GetMap().Map<ChancelleryInput, ChancelleryDTO>(input);

            ChancelleryService.CreateOrUpdateChancellery(ChancelleryDTO, this.User.Identity.Name);

            return Json(MapToGridModel(ChancelleryDTO)); // returning grid model, used in grid.api.renderRow
        }

        public ActionResult Edit(int id)
        {
            //var dinner = Db.Get<Dinner>(id);

            //var input = new DinnerInput
            //{
            //    Id = dinner.Id,
            //    Name = dinner.Name,
            //    Chef = dinner.Chef.Id,
            //    Date = dinner.Date,
            //    Meals = dinner.Meals.Select(o => o.Id),
            //    BonusMealId = dinner.BonusMeal.Id
            //};

            //return PartialView("Create", input);

            var chanDTO = ChancelleryService.ChancelleryGet(id);

            var input = new ChancelleryInput
            {
                RegistrationNumber = chanDTO.RegistrationNumber,
                DateRegistration = chanDTO.DateRegistration,
                Summary = chanDTO.Summary,
                Notice = chanDTO.Notice,
                Journal = chanDTO.JournalRegistrationsChancellery.Id,
                Folder = chanDTO.FolderChancellery.Id,
                Type = chanDTO.TypeRecordChancellery.Id,
                Responsible = chanDTO.ResponsibleEmployees.Select(o => o.Id),
            };


            //var chancelleryVM = MapBLLPresenter.GetMap().Map<ChancelleryDTO , ChancelleryInput>(chanDTO);

            //chancelleryVM = MapBLLPresenter.GetMap().Map(chanDTO, chancelleryVM);


            return PartialView("Create", input);
        }

        [HttpPost]
        public ActionResult Edit(ChancelleryInput input)
        {
            //if (!ModelState.IsValid) return PartialView("Create", input);
            //var dinner = Db.Get<Dinner>(input.Id);

            //dinner.Name = input.Name;
            //dinner.Date = input.Date.Value;
            //dinner.Chef = Db.Get<Chef>(input.Chef);
            //dinner.Meals = Db.Meals.Where(m => input.Meals.Contains(m.Id));
            //dinner.BonusMeal = Db.Get<Meal>(input.BonusMealId);
            //Db.Update(dinner);

            //// returning the key to call grid.api.update
            //return Json(new { Id = dinner.Id });

            if (!ModelState.IsValid) return PartialView("Create", input);

            var originalDTO = ChancelleryService.ChancelleryGet(input.Id);

            originalDTO.RegistrationNumber = input.RegistrationNumber;
            originalDTO.DateRegistration = input.DateRegistration;
            originalDTO.Summary = input.Summary;
            originalDTO.Notice = input.Notice;
            originalDTO.JournalRegistrationsChancellery = ChancelleryService.GetJournalRegistrations(input.Journal.Value);
            originalDTO.FolderChancellery = ChancelleryService.FolderGet(input.Folder.Value);
            originalDTO.TypeRecordChancellery = ChancelleryService.TypeRecordGetById(input.Type.Value);
            originalDTO.ResponsibleEmployees = ChancelleryService.GetEmployees().Where(o => input.Responsible.Contains(o.Id)).ToList();

            ChancelleryService.CreateOrUpdateChancellery(originalDTO, this.User.Identity.Name);

            // returning the key to call grid.api.update
            return Json(new { Id = originalDTO.Id });
        }

        public ActionResult Delete(int id, string gridId)
        {
            //var dinner = Db.Get<Dinner>(id);

            //return PartialView(new DeleteConfirmInput
            //{
            //    Id = id,
            //    GridId = gridId,
            //    Message = string.Format("Are you sure you want to delete dinner <b>{0}</b> ?", dinner.Name)
            //});

            return PartialView(new DeleteConfirmInput
            {
                Id = id,
                GridId = gridId,
                Message = string.Format("Are you sure you want to delete chancellery <b>{0}</b> ?", id)
            });

        }

        [HttpPost]
        public ActionResult Delete(DeleteConfirmInput input)
        {
            //Db.Delete<Dinner>(input.Id);
            //return Json(new { Id = input.Id });
            var originalDTO = ChancelleryService.ChancelleryGet(input.Id);

            originalDTO.s_InBasket = true;

            ChancelleryService.CreateOrUpdateChancellery(originalDTO, this.User.Identity.Name);
            return Json(new { Id = input.Id });

        }
    }
}
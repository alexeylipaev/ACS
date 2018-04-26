using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ACS.BLL.Interfaces;
using ACSWeb.Models;
using ACS.BLL.DTO;
using AutoMapper;
using ACS.BLL.Infrastructure;
using ACSWeb.ViewModel;

namespace ACSWeb.Controllers
{
    //[Authorize]
    public class UsersController : Controller
    {
        //private ACSContext db = new ACSContext();

        IUserService userService;

        public UsersController(IUserService serv)
        {
            userService = serv;
        }

        // GET: Users
        public ActionResult Index()
        {
            IEnumerable<UserDTO> userDtos = userService.GetUsers();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userDtos);
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                UserDTO user = userService.GetUser(id);
                var userVM = new UserViewModel { Id = user.Id };

                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Users/Create
        public ActionResult Create(int? id)
        {
            try
            {
                var userVM = new UserViewModel ();
                if (id != null)
                {
                    UserDTO userDTO = userService.GetUser(id);
                    userVM.Id = userDTO.Id;
                }
                

                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        //POST: Users/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FName,LName,MName")] UserViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userDto = new UserDTO { Id = userVM.Id, LName =userVM.LName, FName = userVM.FName, MName = userVM.MName };
                    userService.MakeUser(userDto);
                    return Content("<h2>Ваш заказ успешно оформлен</h2>");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(userVM);
        }

        //// GET: Users/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,FName,LName,MName,PersonnelNumber,Birthday,PassportSeries,PassportNumber,PassportIssuedBy,PassportUnitCode,PassportDateOfIssue,SID,Guid1C,s_Guid,s_AuthorID,s_DateCreation,s_EditorID,s_EditDate,s_IsLocked,s_LockedBy_Id,s_InBasket")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(user);
        //}

        //// GET: Users/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.Users.Find(id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

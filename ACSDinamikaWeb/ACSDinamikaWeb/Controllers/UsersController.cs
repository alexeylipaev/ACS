using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ACS.BLL.Interfaces;
using ACSWeb.Models;
using ACS.BLL.DTO;
using AutoMapper;
using ACS.BLL.Infrastructure;
using ACSWeb.ViewModel;
using System.DirectoryServices.AccountManagement;
using System.Web.Security;

namespace ACSWeb.Controllers
{
    [Authorize]
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
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                UserDTO user = userService.GetUser(Id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
                var userVM = mapper.Map<UserDTO, UserViewModel>(user);
                //var userVM = new UserViewModel { Id = user.Id };

                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Users/Create
        public ActionResult Create(int? Id)
        {
            try
            {
                var userVM = new UserViewModel ();
                if (Id != null)
                {
                    UserDTO userDTO = userService.GetUser(Id);
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
                    userVM = mapper.Map<UserDTO, UserViewModel>(userDTO);
                    //userVM.Id = userDTO.Id;
                }
                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        public string CurrentUserEmail()
        {
            string name = this.User.Identity.Name;
            PrincipalContext pc = new PrincipalContext(ContextType.Domain);
            UserPrincipal up = UserPrincipal.FindByIdentity(pc, name);
            //userService.GetUser
            return up.EmailAddress;
        }

        //POST: Users/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FName,LName,MName,Email,Birthday")] UserViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = CurrentUserEmail();
                    var userDto = new UserDTO { Id = userVM.Id, LName =userVM.LName, FName = userVM.FName, MName = userVM.MName, Email  = userVM.Email, Birthday = userVM.Birthday};
                    userService.MakeUser(userDto, currentUserEmail);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(userVM);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? Id)
        {
            var userVM = new UserViewModel();
            if (Id != null)
            {
                UserDTO userDTO = userService.GetUser(Id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
                userVM = mapper.Map<UserDTO, UserViewModel>(userDTO);
                //userVM.Id = userDTO.Id;
            }

            return View(userVM);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,MName,EMail")] UserViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = CurrentUserEmail();
                    var userDto = new UserDTO { Id = userVM.Id, LName = userVM.LName, FName = userVM.FName, MName = userVM.MName, Email = userVM.Email };
                    userService.UpdateUser(userDto, currentUserEmail);
                    return View(userVM); 
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(userVM);
        }

        //// GET: Users/Delete/5
        //public ActionResult Delete(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.Users.Find(Id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int Id)
        //{
        //    User user = db.Users.Find(Id);
        //    db.Users.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                userService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ACS.BLL.Interfaces;
using ACS.BLL.DTO;
using AutoMapper;
using ACS.BLL.Infrastructure;
using ACS.WEB.ViewModel;
using System.Linq;

namespace ACS.WEB.Controllers
{
    [Authorize]
    [Authorize(Roles = "Administrators")]
    public class EmployeesController : Controller
    {
        //private ACSContext db = new ACSContext();

        IEmployeeService EmployeeService;

        public EmployeesController(IEmployeeService serv)
        {
            EmployeeService = serv;
        }

        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<EmployeeDTO> userDtos = EmployeeService.GetUsers().Where(e => e.s_InBasket != null && !(bool)e.s_InBasket);
            var user = this.User;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var users = mapper.Map<IEnumerable<EmployeeDTO>, List<EmployeeViewModel>>(userDtos);
            return View(users);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                EmployeeDTO user = EmployeeService.GetUser(Id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
                var userVM = mapper.Map<EmployeeDTO, EmployeeViewModel>(user);
                //var userVM = new UserViewModel { Id = user.Id };

                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Employees/Create
        public ActionResult Create(int? Id)
        {
            try
            {
                var userVM = new EmployeeViewModel ();
                if (Id != null)
                {
                    EmployeeDTO userDTO = EmployeeService.GetUser(Id);
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
                    userVM = mapper.Map<EmployeeDTO, EmployeeViewModel>(userDTO);
                    //userVM.Id = userDTO.Id;
                }
                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        

        //POST: Employees/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FName,LName,MName,Email")] EmployeeViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    var userDto = new EmployeeDTO { Id = userVM.Id, LName =userVM.LName, FName = userVM.FName, MName = userVM.MName, Email  = userVM.Email};
                    EmployeeService.CreateUser(userDto, currentUserEmail);
                    return RedirectToAction("Index");
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(userVM);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? Id)
        {
            var userVM = new EmployeeViewModel();
            if (Id != null)
            {
                EmployeeDTO userDTO = EmployeeService.GetUser(Id);
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
                userVM = mapper.Map<EmployeeDTO, EmployeeViewModel>(userDTO);
                //userVM.Id = userDTO.Id;
            }

            return View(userVM);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,MName,Email")] EmployeeViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    var userDto = new EmployeeDTO { Id = userVM.Id, LName = userVM.LName, FName = userVM.FName, MName = userVM.MName, Email = userVM.Email };
                    EmployeeService.UpdateUser(userDto, currentUserEmail);
                    ViewBag.EditResult = "Данные изменены";
                    return View(userVM); 
                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            
            return View(userVM);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmployeeDTO userDTO = EmployeeService.GetUser(Id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var userVM = mapper.Map<EmployeeDTO, EmployeeViewModel>(userDTO);

            if (userVM == null)
            {
                return HttpNotFound();
            }
            
            return View(userVM);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            string currentUserEmail = this.User.Identity.Name;
            EmployeeService.MoveToBasketUser((int)Id, currentUserEmail);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                EmployeeService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

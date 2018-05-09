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
    [Authorize(Roles = "User")]
    public class EmployeesController : Controller
    {
        //private ACSContext db = new ACSContext();

        IEmployeeService EmployeeService;

        public EmployeesController(IEmployeeService serv)
        {
            EmployeeService = serv;
        }

        IMapper GetMapEmplDTOToEmpViewModel()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AccessDTO, AccessViewModel>().ForMember(x => x.Employee_Id,
x => x.MapFrom(m => m.Employee_Id));
                cfg.CreateMap<ChancelleryDTO, ChancelleryViewModel>().ForMember(x => x.Employee,
x => x.MapFrom(m => m.Employee));
                cfg.CreateMap<ApplicationUserDTO, ApplicationUserViewModel>().ForMember(x => x.Employee_Id,
          x => x.MapFrom(m => m.Employee_Id));
                cfg.CreateMap<PostEmployeeСode1СDTO, PostsEmployeeСode1СViewModel>().ForMember(x => x.Employee_Id,
x => x.MapFrom(m => m.Employee_Id));
                cfg.CreateMap<EmployeeDTO, EmployeeViewModel>();

            }).CreateMapper();

            return mapper;
        }


        // GET: Employees
        public ActionResult Index()
        {
            List<EmployeeDTO> userDtos = EmployeeService.GetEmployees().Where(e => /*e.s_InBasket != null &&*/ !(bool)e.s_InBasket).ToList();
            //var user = this.User;
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var users = GetMapEmplDTOToEmpViewModel().Map<List<EmployeeDTO>, List<EmployeeViewModel>>(userDtos);
            return View(users);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                EmployeeDTO user = EmployeeService.GetEmployee(id);
                //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
                var userVM = GetMapEmplDTOToEmpViewModel().Map<EmployeeDTO, EmployeeViewModel>(user);
                //var userVM = new UserViewModel { id = user.id };

                return View(userVM);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        // GET: Employees/Create
        public ActionResult Create(int? id)
        {
            try
            {
                var userVM = new EmployeeViewModel ();
                if (id != null)
                {
                    EmployeeDTO userDTO = EmployeeService.GetEmployee(id);
                    //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
                    userVM = GetMapEmplDTOToEmpViewModel().Map<EmployeeDTO, EmployeeViewModel>(userDTO);
                    //userVM.id = userDTO.id;
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
        public ActionResult Create([Bind(Include = "id,FName,LName,MName,Email")] EmployeeViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    var userDto = new EmployeeDTO { id = userVM.id, LName =userVM.LName, FName = userVM.FName, MName = userVM.MName, Email  = userVM.Email};
                    EmployeeService.CreateEmployee(userDto, currentUserEmail);
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
        public ActionResult Edit(int? id)
        {
            var userVM = new EmployeeViewModel();
            if (id != null)
            {
                EmployeeDTO userDTO = EmployeeService.GetEmployee(id);
               // var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
                userVM = GetMapEmplDTOToEmpViewModel().Map<EmployeeDTO, EmployeeViewModel>(userDTO);
                //userVM.id = userDTO.id;
            }

            return View(userVM);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FName,LName,MName,Email")] EmployeeViewModel userVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    //string currentUserEmail = ActiveDirectory.IdentityUserEmailFromActiveDirectory(name);
                    var userDto = new EmployeeDTO { id = userVM.id, LName = userVM.LName, FName = userVM.FName, MName = userVM.MName, Email = userVM.Email };
                    EmployeeService.UpdateEmployee(userDto, currentUserEmail);
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmployeeDTO userDTO = EmployeeService.GetEmployee(id);
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            var userVM = GetMapEmplDTOToEmpViewModel().Map<EmployeeDTO, EmployeeViewModel>(userDTO);

            if (userVM == null)
            {
                return HttpNotFound();
            }
            return View(userVM);
        }


        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string currentUserEmail = this.User.Identity.Name;
                    EmployeeService.MoveToBasketEmployee((int)id, currentUserEmail);
                    ViewBag.EditResult = "Данные перемещены в корзину";
                    return RedirectToAction("Index");

                }
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return  RedirectToAction("Index");
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.DTO;
using NLayerApp.WEB.Models;
using AutoMapper;
using NLayerApp.BLL.Infrastructure;
 
namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        IOrderService orderService;
        public HomeController(IOrderService serv)
        {
            orderService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<PhoneDTO> phoneDtos = orderService.GetPhones();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhoneDTO, PhoneViewModel>()).CreateMapper();
            var phones = mapper.Map<IEnumerable<PhoneDTO>, List<PhoneViewModel>>(phoneDtos);
            return View(phones);
        }
 
        public ActionResult MakeOrder(int? id)
        {
            try
            {
                PhoneDTO phone = orderService.GetPhone(id);
                var order = new OrderViewModel { PhoneId = phone.Id };
                 
                return View(order);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult MakeOrder(OrderViewModel order)
        {
            try
            {
                var orderDto = new OrderDTO { PhoneId = order.PhoneId, Address = order.Address, PhoneNumber = order.PhoneNumber };
                orderService.MakeOrder(orderDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(order);
        }
        protected override void Dispose(bool disposing)
        {
            orderService.Dispose();
            base.Dispose(disposing);
        }
    }
}
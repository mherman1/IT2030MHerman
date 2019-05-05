using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models;

namespace EventApplication.Controllers
{
    public class TicketsOrderedController : Controller
    {

        private EventApplicationDB db = new EventApplicationDB();

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
        
        public ActionResult Register(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        public ActionResult OrderSummary(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: ShoppingCart
        public ActionResult TicketOrders()
        {
            TicketsOrdered order = TicketsOrdered.GetOrder(this.HttpContext);

            TicketsOrderedViewModel vm = new TicketsOrderedViewModel()
            {
                OrderItems = order.GetOrderItems(),
                //CartTotal = cart.GetCartTotal()
            };

            return View(vm);
        }

        public ActionResult AddToOrder(int id)
        {
            TicketsOrdered order = TicketsOrdered.GetOrder(this.HttpContext);
            order.AddToOrder(id);
            return RedirectToAction("TicketOrders");
        }

        [HttpPost]
        public ActionResult CancelOrder(int id)
        {
            TicketsOrdered order = TicketsOrdered.GetOrder(this.HttpContext);

            Event @event = db.Orders.SingleOrDefault(c => c.RecordId == id).EventSelected;

            int newItemCount = order.CancelOrder(id);

            TicketsOrderedCancelViewModel vm = new TicketsOrderedCancelViewModel()
            {
                DeleteId = id,
                //CartTotal = cart.GetCartTotal(),
                ItemCount = newItemCount,
                //Status = "Canceled";
            };

            return Json(vm);
        }
    }
}
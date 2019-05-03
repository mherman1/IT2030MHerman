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
    public class OrganizeController : Controller
    {
        private EventApplicationDB db = new EventApplicationDB();

        // GET: Organize
        public ActionResult Index()
        {
            ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "Type");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "EventId,EventTypeId,Title,Description,StartDate,EndDate,MaxTickets,AvailableTickets,Organizer,OrganizerContactInfo,City,State")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index", "Event");
            }

            ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "Type", @event.EventTypeId);
            return View(@event);
        }
    }
}
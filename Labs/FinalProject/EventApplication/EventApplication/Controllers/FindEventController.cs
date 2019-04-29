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
    public class FindEventController : Controller
    {
        private EventApplicationDB db = new EventApplicationDB();

        public ActionResult EventSearch(string q)
        {
            var events = GetEvents(q);

            if (events.Any())
            {
                return PartialView("_EventSearch", events);
            }

            return PartialView("_NoResults");

        }

        private List<Event> GetEvents(string searchString)
        {
           return db.Events
                .Where(a => a.Title.Contains(searchString) || a.Type.Contains(searchString))
                .OrderBy(a => a.Title)
                .ToList();
        }

        public ActionResult LocationSearch(string q)
        {
            var locations = GetLocations(q);

            if (locations.Any())
            {
                return PartialView("_EventSearch", locations);
            }

            return PartialView("_NoResults");
        }

        private List<Event> GetLocations(string searchString)
        {
            return db.Events
                .Where(a => a.City.Contains(searchString) || a.State.Contains(searchString))
                .OrderBy(a => a.State)
                .OrderBy(a => a.City)
                .ToList();
        }

        // GET: FindEvent
        public ActionResult Index()
        {
            return View();
        }

        // GET: FindEvent/Details/1
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
    }
}
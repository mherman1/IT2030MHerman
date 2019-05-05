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
    [AllowAnonymous]
    public class FindEventController : Controller
    {
        private EventApplicationDB db = new EventApplicationDB();

        public ActionResult Search(string p, string q)
        {
            if (p != "" && q == "")
            {
                var events = GetEvents(p);

                if (events.Any())
                {
                    return PartialView("_EventSearch", events);
                }

                return PartialView("_NoResults");
            }
            else if (p == "" && q != "")
            {
                var locations = GetLocations(q);

                if (locations.Any())
                {
                    return PartialView("_EventSearch", locations);
                }

                return PartialView("_NoResults");
            }
            else if (p != "" && q != "")
            {
                var eventsbylocation = GetEventsByLocation(p, q);

                if (eventsbylocation.Any())
                {
                    return PartialView("_EventSearch", eventsbylocation);
                }

                return PartialView("_NoResults");
            }
            else 
            {
                var locations = GetLocations(q);

                if (locations.Any())
                {
                    return PartialView("_EventSearch", locations);
                }

                return PartialView("_NoResults");
            }
            

        }

        private List<Event> GetEvents(string searchString)
        {
           return db.Events
                .Where(a => a.Title.Contains(searchString) || a.Type.Type.Contains(searchString))
                .Where(a => a.StartDate >= DateTime.Today)
                .OrderBy(a => a.Title)
                .ToList();
        }

        private List<Event> GetLocations(string searchString)
        {
            return db.Events
                .Where(a => a.City.Contains(searchString) || a.State.Contains(searchString))
                .Where(a => a.StartDate >= DateTime.Today)
                .OrderBy(a => a.State)
                .OrderBy(a => a.City)
                .ToList();
        }

        private List<Event> GetEventsByLocation(string q, string p)
        {
            return db.Events
                 .Where(a => a.Title.Contains(q) || a.Type.Type.Contains(q))
                 .Where(a => a.City.Contains(p) || a.State.Contains(p))
                 .Where(a => a.StartDate >= DateTime.Today)
                 .OrderBy(a => a.Title)
                 .ToList();
        }


        // GET: FindEvent
        public ActionResult Index()
        {
            return View();
        }

        

        
    }
}
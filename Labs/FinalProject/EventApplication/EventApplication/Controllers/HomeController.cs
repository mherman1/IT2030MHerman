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
    public class HomeController : Controller
    {
        private EventApplicationDB db = new EventApplicationDB();

        public ActionResult LastMinuteDeals()
        {
            var deal = GetLastMinuteDeals();
            return PartialView("_LastMinuteDeals", deal);
        }

        private List<Event> GetLastMinuteDeals()
        {
            var date = DateTime.Today.AddDays(2);

            return db.Events
                 .Where(a => a.StartDate >= DateTime.Today && a.StartDate < date)
                 .OrderBy(a => a.Title)
                 .ToList();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
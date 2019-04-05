using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMusicStoreApplication.Models;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {
        private MVCMusicStoreDB db = new MVCMusicStoreDB();

        public ActionResult Browse()
        {
            return View(db.Genres.OrderBy(a => a.Name).ToList());
        }

        
        public ActionResult Index(int id)
        {
            var albums = GetAlbums(id);

            return View("Index", albums);
        }

        private List<Album> GetAlbums(int searchInt)
        {
                return db.Albums
                .Where(a => a.GenreId.Equals(searchInt))
                .OrderBy(a => a.Title)
                .ToList();
        }

        public ActionResult Details(int id)
        {
            Album album = db.Albums.Find(id);

            return View("Details", album);
        }
    }
}
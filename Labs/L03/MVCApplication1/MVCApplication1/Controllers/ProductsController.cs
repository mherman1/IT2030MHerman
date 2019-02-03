using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication1.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /Products/
        public string Index()
        {
            return "Products/Index is displayed";
        }

        // GET: /Products/Browse
        public string Browse()
        {
            return "Browse displayed";
        }

        // GET: /Products/Details/105
        public string Details(int id)
        {
            string message = "Details displayed for Id=" + id;

            return message;
        }

        // GET: /Products/Location?zip=?44124
        public string Location(int zip)
        {
            string message = 
                HttpUtility.HtmlEncode("Location displayd for zip=" + zip);

            return message;
        }
    }
}
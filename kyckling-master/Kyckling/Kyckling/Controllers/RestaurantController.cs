using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kyckling.WebUI.Controllers
{
    public class RestaurantController : Controller
    {
        //
        // GET: /Restaurant/
        public RestaurantController()
        {
            
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string q)
        {
            var searchFor = q;
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using m2prayer.Services;

namespace m2prayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var EsvApi = new EsvApi();
            ViewBag.TodaysVerse = EsvApi.GetDailyVerse();

            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
    }
}
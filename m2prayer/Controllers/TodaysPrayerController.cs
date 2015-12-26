using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using m2prayer.Services;

namespace m2prayer.Controllers
{
    public class TodaysPrayerController : Controller
    {
        // GET: TodaysPrayer
        public ActionResult Index()
        {
            var EsvApi = new EsvApi();
            ViewBag.TodaysVerse = EsvApi.GetDailyVerse();
            return View();
        }
    }
}
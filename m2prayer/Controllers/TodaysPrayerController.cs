using System.Web.Mvc;
using m2prayer.Services;

namespace m2prayer.Controllers
{
    public class TodaysPrayerController : Controller
    {
        // GET: TodaysPrayer
        public ActionResult Index()
        {
            var esvApi = new EsvApi();
            ViewBag.TodaysVerse = esvApi.GetDailyVerse();
            return View();
        }
    }
}
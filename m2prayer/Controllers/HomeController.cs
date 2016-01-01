using System;
using System.Web.Mvc;
using m2prayer.Services;

namespace m2prayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJmVersesService _verseService;
        public HomeController()
        {
            _verseService = new JmVersesService();
        }

        public HomeController(IJmVersesService verseService)
        {
            if (verseService == null) throw new ArgumentNullException(nameof(verseService));

            _verseService = verseService;
        }

        public ActionResult Index()
        {
            var esvApi = new EsvApi();
            ViewBag.TodaysVerse = esvApi.GetDailyVerse();

            ViewBag.YearsVerses = _verseService.GetYearsVerses();

            return View();
        }
    }
}
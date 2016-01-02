using System;
using System.Web.Mvc;
using m2prayer.Services;

namespace m2prayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJmVersesService _verseService;
        private readonly IWestminsterCatechismService _catechismService;

        public HomeController()
        {
            _verseService = new JmVersesService();
            _catechismService = new WestminsterCatechismService();
        }

        public HomeController(IJmVersesService verseService, IWestminsterCatechismService catechismService)
        {
            if (verseService == null) throw new ArgumentNullException(nameof(verseService));
            if (catechismService == null) throw new ArgumentNullException(nameof(catechismService));

            _verseService = verseService;
            _catechismService = catechismService;
        }

        public ActionResult Index()
        {
            //today's verse
            var esvApi = new EsvApi();
            ViewBag.TodaysVerse = esvApi.GetDailyVerse();
            
            //today's catechism
            ViewBag.TodaysCatechismNumber = _catechismService.GetTodaysCatechism().Number;
            ViewBag.TodaysCatechismQuestion = _catechismService.GetTodaysCatechism().Question;
            ViewBag.TodaysCatechismAnswer = _catechismService.GetTodaysCatechism().Answer;

            ViewBag.YearsVerses = _verseService.GetYearsVerses();

            return View();
        }
    }
}
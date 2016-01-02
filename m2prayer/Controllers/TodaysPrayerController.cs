using System;
using System.Web.Mvc;
using m2prayer.Services;

namespace m2prayer.Controllers
{
    public class TodaysPrayerController : Controller
    {
        private readonly IJmVersesService _verseService;
        private readonly IWestminsterCatechismService _catechismService;
        private readonly IPrayerRequestService _prayerRequestService;

        public TodaysPrayerController()
        {
            _verseService = new JmVersesService();
            _catechismService = new WestminsterCatechismService();
            _prayerRequestService = new PrayerRequestService();
        }

        public TodaysPrayerController(IJmVersesService verseService, IWestminsterCatechismService catechismService, IPrayerRequestService prayerRequestService)
        {
            if (verseService == null) throw new ArgumentNullException(nameof(verseService));
            if (catechismService == null) throw new ArgumentNullException(nameof(catechismService));
            if (prayerRequestService == null) throw new ArgumentNullException(nameof(prayerRequestService));

            _verseService = verseService;
            _catechismService = catechismService;
            _prayerRequestService = prayerRequestService;
        }

        // GET: TodaysPrayer
        public ActionResult Index()
        {
            //today's catechism
            ViewBag.TodaysCatechismNumber = _catechismService.GetTodaysCatechism().Number;
            ViewBag.TodaysCatechismQuestion = _catechismService.GetTodaysCatechism().Question;
            ViewBag.TodaysCatechismAnswer = _catechismService.GetTodaysCatechism().Answer;

            //current Joshua's Men verses
            ViewBag.CurrentVerses = _verseService.GetCurrentVerses();

            //get the daily verse
            var esvApi = new EsvApi();
            ViewBag.TodaysVerse = esvApi.GetDailyVerse();
            return View();
        }
    }
}
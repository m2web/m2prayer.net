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
            //TODO: GetTodaysCatechism()
            //TODO: GetTodaysPrayerRequests()
            //TODO: GetCurrentVerses()
            ViewBag.CurrentVerses = _verseService.GetCurrentVerses();
            var esvApi = new EsvApi();
            ViewBag.TodaysVerse = esvApi.GetDailyVerse();
            return View();
        }
    }
}
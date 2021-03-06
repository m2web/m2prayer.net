﻿using System;
using System.Globalization;
using System.Web.Mvc;
using m2prayer.Models;
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
        public ActionResult Index(int selectedPrayerCategoryId = 0)
        {
            //get the daily verse
            var esvApi = new EsvApi();
            ViewBag.TodaysVerse = esvApi.GetDailyVerse();

            //today's catechism
            ViewBag.TodaysCatechismNumber = _catechismService.GetTodaysCatechism().Number;
            ViewBag.TodaysCatechismQuestion = _catechismService.GetTodaysCatechism().Question;
            ViewBag.TodaysCatechismAnswer = _catechismService.GetTodaysCatechism().Answer;

            //current Joshua's Men verses
            ViewBag.CurrentVerses = _verseService.GetCurrentVerses();

            //get today's prayer request
            ViewBag.TodaysPrayerRequests = _prayerRequestService.GetTodaysPrayerRequests();

            //get all prayer requests for drop-down menu
            ViewBag.AllPrayerRequests = _prayerRequestService.GetRequests();

            //get today's Psalm
            ViewBag.TodaysPsalm = esvApi.GetTodaysPsalm();

            //check if coming from Today's Prayer and selecting a prayer category
            if (selectedPrayerCategoryId > 0)
            {
                ViewBag.SelectedPrayer = _prayerRequestService.GetRequestById(selectedPrayerCategoryId).Request;
            }

            return View();
        }

        public ActionResult GetVovPrayerLink()
        {
            //URL structure items
            var linkBase = "http://markmcfadden.net/prayerweb/vov/";
            var pageExtension = ".html";
            
            //get the day number of the year
            var todaysDate = DateTime.Today;
            var cal = CultureInfo.CurrentCulture.Calendar;
            var todaysVovPrayerNumber = cal.GetDayOfYear(todaysDate);

            var random = new Random();

            //the number of VOV prayers
            var numberOfPrayers = 159;
            //since there is more than 159 days in the year multiply it by 2
            var numberOfPrayersX2 = numberOfPrayers * 2;

            //if today's number is more than the number of prayers but less than twice the number of prayers the difference between the two
            //to get the current day's VOV prayer as you have been through them once this year
            if (todaysVovPrayerNumber > numberOfPrayers && todaysVovPrayerNumber <= numberOfPrayersX2)
            {
                todaysVovPrayerNumber -= numberOfPrayers;
            }
            //if today's number is greater than twice the number of prayers get a random number of a prayer
            else if (todaysVovPrayerNumber > numberOfPrayersX2)
            {
                todaysVovPrayerNumber = random.Next(1, numberOfPrayers);
            }

            return Redirect(linkBase + todaysVovPrayerNumber + pageExtension);
        }

        public ActionResult GetSelectedPrayer(int id)
        {
            var selectedPrayer = _prayerRequestService.GetRequestById(id).Request;
            return Json(selectedPrayer, JsonRequestBehavior.AllowGet);
        }
    }
}
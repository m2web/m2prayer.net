using System;
using System.Linq;
using m2prayer.Repository;
using m2prayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace m2prayer.Tests.Services
{
    [TestClass]
    public class JmVersesTests
    {
        private DateTime _todaysDate;
        private IJmVersesService _verseService;
        //TODO: create below with Mock dependencies
        //TODO: GetCurrentVerses()
        //TODO: GetVersesToDate()
        [TestMethod]
        public void GetCurrentVersesTest()
        {
            using (var context = new PrayerContext())
            {
                _verseService = new JmVersesService(new JmVersesRepository(context));
                var currentVerses = _verseService.GetCurrentVerses();
                Console.WriteLine(currentVerses.Count());
            }
            
        }

        [TestMethod]
        public void GetAllVersesTest()
        {
            _verseService = new JmVersesService();
            var currentVerses = _verseService.GetVerses();
            Console.WriteLine(currentVerses.Count());
        }

        [TestMethod]
        [Ignore]
        public void GetVersesTest()
        {
            //get current date
            _todaysDate = DateTime.Today;

            //get current month
            var thisMonth = 10;//_todaysDate.Month;


            //get list of verses for current and next month (Where Month >= current month AND <= current month +1)
            using (var context = new PrayerContext())
            {
                var thisMonthsVerses = context.JmVerses.Where(v => v.Month.Equals(thisMonth)).ToList();

                Console.WriteLine(thisMonthsVerses.Count());
                foreach (var v in thisMonthsVerses)
                {
                    Console.WriteLine(v.Text);
                }
            }
            //get the verses from the list where the start date < current date
        }
    }
}

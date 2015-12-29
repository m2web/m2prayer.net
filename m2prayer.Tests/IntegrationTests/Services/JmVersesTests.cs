using System;
using System.Linq;
using m2prayer.Repository;
using m2prayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace m2prayer.Tests.IntegrationTests.Services
{
    [TestClass]
    public class JmVersesTests
    {
        private DateTime _todaysDate;
        private IJmVersesService _verseService;

        //TODO: GetCurrentVerses()
        //TODO: GetVersesToDate()
        [TestMethod]
        public void GetCurrentVersesTest()
        {
            //get current date
            _todaysDate = DateTime.Today;

            //get current month
            var thisMonth = _todaysDate.Month;

            //get list of verses for current and next month (Where Month >= current month AND <= current month +1)
            //using (PrayerContext context = new PrayerContext())
            //{
            //    var query =
            //        from verse in context.JmVerses
            //        //where verse.Month >= 2 && verse.Month <= 3
            //        select new
            //        {
            //            verseReference = verse.Reference,
            //            verseText = verse.Text
            //        };
            //    Console.WriteLine(query.Count());
            //    foreach (var verse in query)
            //    {
            //        Console.WriteLine("{0} - {1}",
            //            verse.verseReference, verse.verseText);
            //    }
            //}

            //get the verses from the list where the start date < current date
        }
    }
}

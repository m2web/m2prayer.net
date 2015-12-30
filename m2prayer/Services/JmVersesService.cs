using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using m2prayer.Models;
using m2prayer.Repository;

namespace m2prayer.Services
{
    public interface IJmVersesService
    {
        IEnumerable<JmVerse> GetVerses();
        JmVerse GetVerseById(int? verseId);
        void InsertVerse(JmVerse verse);
        void DeleteVerse(int verseId);
        void UpdateVerse(JmVerse verse);
        void Save();
        void Dispose();
        IEnumerable<JmVerse> GetCurrentVerses();
        IEnumerable<JmVerse> GetYearsVerses();
    }

    public class JmVersesService : IJmVersesService
    {
        private readonly IJmVersesRepository _jmVersesRepository;

        public JmVersesService()
        {
            _jmVersesRepository = new JmVersesRepository(new PrayerContext());
        }

        public JmVersesService(IJmVersesRepository jmVersesRepository)
        {
            _jmVersesRepository = jmVersesRepository;
        }

        public IEnumerable<JmVerse> GetVerses()
        {
            return _jmVersesRepository.GetVerses();
        }

        public JmVerse GetVerseById(int? verseId)
        {
            return _jmVersesRepository.GetVerseById(verseId);
        }

        public void InsertVerse(JmVerse verse)
        {
            _jmVersesRepository.InsertVerse(verse);
        }

        public void DeleteVerse(int verseId)
        {
            _jmVersesRepository.DeleteVerse(verseId);
        }

        public void UpdateVerse(JmVerse verse)
        {
            _jmVersesRepository.UpdateVerse(verse);
        }

        public void Save()
        {
            _jmVersesRepository.Save();
        }

        public void Dispose()
        {
            _jmVersesRepository.Dispose();
        }
        
        public IEnumerable<JmVerse> GetCurrentVerses()
        {
            var todaysDate = DateTime.Today;
            var thisMonth = todaysDate.Month;
            var theYear = (todaysDate.Year % 2 == 0) ? "GRUDEM" : "BOOKS";

            //if date is past December 15th, let's start next years verses
            var cal = CultureInfo.CurrentCulture.Calendar;
            if (thisMonth.Equals(12) && cal.GetDayOfMonth(todaysDate) > 15)
            {
                thisMonth = 2;//start in February as no verses in Jan.
                theYear = theYear.Equals("BOOKS") ? "GRUDEM" : "BOOKS";
            }
            //get verses for the current and next month that are for the upcoming month's meeting for Joshua's Men
            var verses = _jmVersesRepository.GetVerses().Where(v => v.Month <= thisMonth+1 && v.Year.Equals(theYear) && v.StartDate <= todaysDate && v.EndDate > todaysDate).ToList().OrderByDescending(v => v.Month);

            return verses;
        }

        //TODO: impletment below
        public IEnumerable<JmVerse> GetYearsVerses()
        {
            throw new System.NotImplementedException();
        }
    }
}
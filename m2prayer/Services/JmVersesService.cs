using System;
using System.Collections.Generic;
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
        //TODO: impletment below
        public IEnumerable<JmVerse> GetCurrentVerses()
        {
            var todaysDate = DateTime.Today;

            //get current month
            var thisMonth = todaysDate.Month;
            return _jmVersesRepository.GetVerses().Where(v => v.Month <= thisMonth).ToList();
        }

        public IEnumerable<JmVerse> GetYearsVerses()
        {
            throw new System.NotImplementedException();
        }
    }
}
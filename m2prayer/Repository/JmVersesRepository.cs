using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using m2prayer.Models;
using static System.GC;

namespace m2prayer.Repository
{
    public interface IJmVersesRepository
    {
        IEnumerable<JmVerse> GetVerses();
        JmVerse GetVerseById(int? verseId);
        void InsertVerse(JmVerse verse);
        void DeleteVerse(int verseId);
        void UpdateVerse(JmVerse verse);
        void Save();
        void Dispose();
    }

    public class JmVersesRepository: IJmVersesRepository
    {
        private readonly PrayerContext _context;

        public JmVersesRepository(PrayerContext context)
        {
            _context = context;
        }

        public IEnumerable<JmVerse> GetVerses()
        {
            return _context.JmVerses.ToList().OrderBy(v => v.Month);
        }

        public JmVerse GetVerseById(int? verseId)
        {
            return _context.JmVerses.Find(verseId);
        }

        public void InsertVerse(JmVerse verse)
        {
            _context.JmVerses.Add(verse);
        }

        public void DeleteVerse(int verseId)
        {
            var verse = _context.JmVerses.Find(verseId);
            _context.JmVerses.Remove(verse);
        }

        public void UpdateVerse(JmVerse verse)
        {
            _context.JmVerses.AddOrUpdate(verse);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            SuppressFinalize(this);
        }
    }
}
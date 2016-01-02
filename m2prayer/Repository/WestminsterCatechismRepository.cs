using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using m2prayer.Models;
using static System.GC;

namespace m2prayer.Repository
{
    public interface IWestminsterCatechismRepository
    {
        IEnumerable<WestminsterCatechism> GetCatechisms();
        WestminsterCatechism GetCatechismById(int? catechismId);
        void InsertCatechism(WestminsterCatechism catechism);
        void DeleteCatechism(int catechismId);
        void UpdateCatechism(WestminsterCatechism catechism);
        void Save();
        void Dispose();
        WestminsterCatechism GetCatechismByNumber(int number);
    }

    public class WestminsterCatechismRepository : IWestminsterCatechismRepository
    {
        private readonly PrayerContext _context;

        public WestminsterCatechismRepository(PrayerContext context)
        {
            _context = context;
        }

        public IEnumerable<WestminsterCatechism> GetCatechisms()
        {
            return _context.WestminsterCatechisms.ToList().OrderBy(q => q.Number);
        }

        public WestminsterCatechism GetCatechismById(int? catechismId)
        {
            return _context.WestminsterCatechisms.Find(catechismId);
        }

        public void InsertCatechism(WestminsterCatechism catechism)
        {
            _context.WestminsterCatechisms.Add(catechism);
        }

        public void DeleteCatechism(int catechismId)
        {
            var catechism = _context.WestminsterCatechisms.Find(catechismId);
            _context.WestminsterCatechisms.Remove(catechism);
        }

        public void UpdateCatechism(WestminsterCatechism catechism)
        {
            _context.WestminsterCatechisms.AddOrUpdate(catechism);
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

        public WestminsterCatechism GetCatechismByNumber(int number)
        {
            var result = _context.WestminsterCatechisms.FirstOrDefault(c => c.Number.Equals(number));
            return result;
        }
    }
}
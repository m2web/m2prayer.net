using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using m2prayer.Models;
using static System.GC;

namespace m2prayer.Repository
{
    public interface IPrayerRequestRepository : IDisposable
    {
        IEnumerable<PrayerRequest> GetRequests();
        PrayerRequest GetRequestById(int? requestId);
        void InsertRequest(PrayerRequest request);
        void DeleteRequest(int requestId);
        void UpdateRequest(PrayerRequest request);
        void Save();
    }

    public class PrayerRequestRepository: IPrayerRequestRepository
    {
        private readonly PrayerContext _context;

        public PrayerRequestRepository(PrayerContext context)
        {
            _context = context;
        }

        public IEnumerable<PrayerRequest> GetRequests()
        {
            return _context.PrayerRequests.ToList().OrderBy(r => r.Category);
        }

        public PrayerRequest GetRequestById(int? requestId)
        {
            return _context.PrayerRequests.Find(requestId);
        }

        public void InsertRequest(PrayerRequest request)
        {
            _context.PrayerRequests.Add(request);
        }

        public void DeleteRequest(int requestId)
        {
            var request = _context.PrayerRequests.Find(requestId);
            _context.PrayerRequests.Remove(request);
        }

        public void UpdateRequest(PrayerRequest request)
        {
            _context.PrayerRequests.AddOrUpdate(request);
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
using System;
using System.Collections.Generic;
using m2prayer.Models;

namespace m2prayer.Repository
{
    //TODO: look at http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public interface IPrayerRequestRepository : IDisposable
    {
        IEnumerable<PrayerRequest> GetRequests();
        PrayerRequest GetRequestById(int requestId);
        void InsertRequest(PrayerRequest request);
        void DeleteRequest(int requestId);
        void UpdateStudent(PrayerRequest request);
        void Save();
    }

    public class PrayerRequestRepository: IPrayerRequestRepository, IDisposable
    {
        public IEnumerable<PrayerRequest> GetRequests()
        {
            throw new NotImplementedException();
        }

        public PrayerRequest GetRequestById(int requestId)
        {
            throw new NotImplementedException();
        }

        public void InsertRequest(PrayerRequest request)
        {
            throw new NotImplementedException();
        }

        public void DeleteRequest(int requestId)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(PrayerRequest request)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
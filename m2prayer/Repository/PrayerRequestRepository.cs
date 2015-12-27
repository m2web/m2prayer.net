using System;

namespace m2prayer.Repository
{
    //TODO: look at http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    public interface IPrayerRequestRepository : IDisposable
    {
        
    }

    public class PrayerRequestRepository: IPrayerRequestRepository, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
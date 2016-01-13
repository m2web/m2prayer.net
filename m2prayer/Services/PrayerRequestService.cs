using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using m2prayer.Models;
using m2prayer.Repository;

namespace m2prayer.Services
{
    public interface IPrayerRequestService
    {
        IEnumerable<PrayerRequest> GetRequests();
        PrayerRequest GetRequestById(int? requestId);
        void InsertRequest(PrayerRequest request);
        void DeleteRequest(int requestId);
        void UpdateRequest(PrayerRequest request);
        void Save();
        void Dispose();
        IEnumerable<PrayerRequest> GetTodaysPrayerRequests();
    }

    public class PrayerRequestService : IPrayerRequestService
    {
        private readonly IPrayerRequestRepository _prayerRequestRepository;

        public PrayerRequestService()
        {
            _prayerRequestRepository = new PrayerRequestRepository(new PrayerContext());
        }

        public PrayerRequestService(IPrayerRequestRepository prayerRequestRepository)
        {
            _prayerRequestRepository = prayerRequestRepository;
        }

        public IEnumerable<PrayerRequest> GetRequests()
        {
            return _prayerRequestRepository.GetRequests();
        }

        public PrayerRequest GetRequestById(int? requestId)
        {
            return _prayerRequestRepository.GetRequestById(requestId);
        }

        public void InsertRequest(PrayerRequest request)
        {
            _prayerRequestRepository.InsertRequest(request);
        }

        public void DeleteRequest(int requestId)
        {
            _prayerRequestRepository.DeleteRequest(requestId);
        }

        public void UpdateRequest(PrayerRequest request)
        {
            _prayerRequestRepository.UpdateRequest(request);
        }

        public void Save()
        {
            _prayerRequestRepository.Save();
        }

        public void Dispose()
        {
            _prayerRequestRepository.Dispose();
        }

        public IEnumerable<PrayerRequest> GetTodaysPrayerRequests()
        {
            var todaysDate = DateTime.Today;

            //This is the day number for the week
            var cal = CultureInfo.CurrentCulture.Calendar;
            var weekDayNumber = (int)cal.GetDayOfWeek(todaysDate);
            var allRequests = _prayerRequestRepository.GetRequests();
            var requestCount = allRequests.Count();

            //categories per day = (categories / number of days of prayer w unique requests)
            var categoriesPerDay = (requestCount / 4);
            int categoryEnd;
            int categoryStart;

            //determine the last category to pray about that day
            if (weekDayNumber * categoriesPerDay <= requestCount)
            {
                categoryEnd = weekDayNumber * categoriesPerDay;

            }
            else {
                //set the random prayer list days here
                //get a random number for category end since the last days of the week will have the same requests
                if (weekDayNumber > 4)
                { 
                    //if day is Thursday thru Saturday get a random set of categories
                    var random = new Random();
                    categoryEnd = random.Next(1, requestCount + 1); 

                    //check that categoryEnd is at least 4 so wse have 4 categories for which to pray. 
                    //this is because the categoryEnd might be 2 then the result is only 2 categories.
                    if (categoryEnd < 4)
                    {
                        categoryEnd = 4;
                    }
                }
                else {//it is Monday - Wednesday
                    categoryEnd = requestCount;
                }

            }//end random prayer list days setting here

            //determine the first category to pray about that day
            categoryStart = categoryEnd - categoriesPerDay;

            return _prayerRequestRepository.GetTodaysPrayerRequests(categoryStart, categoryEnd);
        }
    }
}
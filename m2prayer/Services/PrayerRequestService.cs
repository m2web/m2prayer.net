using System.Collections.Generic;
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
    }
}
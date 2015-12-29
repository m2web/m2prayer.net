using System.Collections.Generic;
using m2prayer.Models;
using m2prayer.Repository;

namespace m2prayer.Services
{
    public interface IWestminsterCatechismService
    {
        IEnumerable<WestminsterCatechism> GetCatechisms();
        WestminsterCatechism GetCatechismById(int? catechismId);
        void InsertCatechism(WestminsterCatechism catechism);
        void DeleteCatechism(int catechismId);
        void UpdateCatechism(WestminsterCatechism catechism);
        void Save();
        void Dispose();
        WestminsterCatechism GetTodaysCatechism();
    }

    public class WestminsterCatechismService : IWestminsterCatechismService
    {
        private readonly IWestminsterCatechismRepository _catechismRepository;

        public WestminsterCatechismService()
        {
            _catechismRepository = new WestminsterCatechismRepository(new PrayerContext());
        }

        public WestminsterCatechismService(IWestminsterCatechismRepository catechismRepository)
        {
            _catechismRepository = catechismRepository;
        }

        public IEnumerable<WestminsterCatechism> GetCatechisms()
        {
            return _catechismRepository.GetCatechisms();
        }

        public WestminsterCatechism GetCatechismById(int? catechismId)
        {
            return _catechismRepository.GetCatechismById(catechismId);
        }

        public void InsertCatechism(WestminsterCatechism catechism)
        {
            _catechismRepository.InsertCatechism(catechism);
        }

        public void DeleteCatechism(int catechismId)
        {
            _catechismRepository.DeleteCatechism(catechismId);
        }

        public void UpdateCatechism(WestminsterCatechism catechism)
        {
            _catechismRepository.UpdateCatechism(catechism);
        }

        public void Save()
        {
            _catechismRepository.Save();
        }

        public void Dispose()
        {
            _catechismRepository.Dispose();
        }
        //TODO: Implement
        public WestminsterCatechism GetTodaysCatechism()
        {
            throw new System.NotImplementedException();
        }
    }
}
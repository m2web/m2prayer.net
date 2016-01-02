using System;
using System.Collections.Generic;
using System.Globalization;
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
        
        public WestminsterCatechism GetTodaysCatechism()
        {
            var todaysDate = DateTime.Today;

            //This is the day number fo the year (1 - 365)
            var cal = CultureInfo.CurrentCulture.Calendar;
            var todaysWestminsterCatechismNumber = cal.GetDayOfYear(todaysDate);
            
            //get today's question number
            var numberOfQuestions = 107;
            var numberOfQuestionsX2 = numberOfQuestions * 2;//if the day of the year is past 107
            var numberOfQuestionsX3 = numberOfQuestions * 3;//if the day of the year is past 214

            //lets get the catechism number
            //first check if today's day of the year # is between 108 and 214
            if (todaysWestminsterCatechismNumber > numberOfQuestions && todaysWestminsterCatechismNumber <= numberOfQuestionsX2)
            {
                //subtract today's day of the year # from the 107 (total # of questions) to get today's # as we are moving thru the questions for a 2nd time
                todaysWestminsterCatechismNumber = todaysWestminsterCatechismNumber - numberOfQuestions;
            }
            //next check if today's day of the year # is between 215 and 321
            else if (todaysWestminsterCatechismNumber > numberOfQuestionsX2 && todaysWestminsterCatechismNumber <= numberOfQuestionsX3)
            {
                //subtract today's day of the year # from the 214 (total # of questions * 2) to get today's # as we are moving thru the questions for a 3rd time
                todaysWestminsterCatechismNumber = todaysWestminsterCatechismNumber - numberOfQuestionsX2;
            }
            //then check if today's day of the year # is greater than 321
            else if (todaysWestminsterCatechismNumber > numberOfQuestionsX3)
            {
                //since we have been thru 3 times let's get a random question and answer
                var random = new Random();
                todaysWestminsterCatechismNumber = random.Next(1, 108); // creates a number between 1 and 107
            }

            return _catechismRepository.GetCatechismByNumber(todaysWestminsterCatechismNumber);
        }
    }
}
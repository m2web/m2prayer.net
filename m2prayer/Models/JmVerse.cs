using System;

namespace m2prayer.Models
{
    public class JmVerse
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Text { get; set; }
        public string Year { get; set; }
        public int Month { get; set; }
        public DateTime StartDate { get; set; }
    }
}
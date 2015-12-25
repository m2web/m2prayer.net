using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using m2prayer.Models;

namespace m2prayer.DAL
{
    public class PrayerContext : DbContext
    {
        public PrayerContext() : base("PrayerContext")
        {
        }

        public DbSet<JmVerse> JmVerses { get; set; }
        public DbSet<WestminsterCatechism> WestminsterCatechisms { get; set; }
        public DbSet<PrayerRequest> PrayerRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
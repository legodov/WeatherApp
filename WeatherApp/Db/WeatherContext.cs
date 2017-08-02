using System.Data.Entity;
using WeatherApp.Db.WeatherCotextConfig;
using WeatherApp.Models;

namespace WeatherApp.Db
{
    public class WeatherContext : DbContext
    {
        public DbSet<CityName> Cities { get; set; }
        public DbSet<HistoryWeatherDataObject> History { get; set; }

        public WeatherContext()
            : base("name=WeatherContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CityNameConfig());
            modelBuilder.Configurations.Add(new HistoryWeatherDataObjectConfig());
            modelBuilder.ComplexType<ReducedForecastPerDay>();
            Database.SetInitializer(new WeatherInitializer());
        }
    }
}
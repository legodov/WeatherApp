using System.Data.Entity;
using WeatherApp.DAL.WeatherCotextConfig;
using WeatherApp.Models;

namespace WeatherApp.DAL
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
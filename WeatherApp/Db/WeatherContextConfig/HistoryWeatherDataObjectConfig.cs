using System.Data.Entity.ModelConfiguration;
using WeatherApp.Models;

namespace WeatherApp.Db.WeatherCotextConfig
{
    public class HistoryWeatherDataObjectConfig : EntityTypeConfiguration<HistoryWeatherDataObject>
    {
        public HistoryWeatherDataObjectConfig()
        {
            Property(p => p.City).IsRequired();
            Property(p => p.CountDays).IsRequired();
            Property(p => p.RequestTime).IsRequired();
        }
    }
}
using System.Data.Entity.ModelConfiguration;
using WeatherApp.Models;

namespace WeatherApp.DAL.WeatherCotextConfig
{
    public class CityNameConfig : EntityTypeConfiguration<CityName>
    {
        public CityNameConfig()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(30);
        }
    }
}
using System.Collections.Generic;
using System.Data.Entity;
using WeatherApp.Models;

namespace WeatherApp.Db.WeatherCotextConfig
{
    public class WeatherInitializer : CreateDatabaseIfNotExists<WeatherContext>
    {
        protected override void Seed(WeatherContext context)
        {
            IEnumerable<CityName> cities = new List<CityName>
            {
                new CityName { Name = "Kiev" },
                new CityName { Name = "Lviv" },
                new CityName { Name = "Kharkiv" },
                new CityName { Name = "Dnipropetrovsk" },
                new CityName { Name = "Odessa" },
            };

            context.Cities.AddRange(cities);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
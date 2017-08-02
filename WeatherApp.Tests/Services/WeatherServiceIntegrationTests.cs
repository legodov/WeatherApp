using System;
using System.Linq;
using WeatherApp.DAL;
using WeatherApp.Models;
using FakeItEasy;
using NUnit.Framework;
using WeatherApp.Services;
using WeatherApp.Db;

namespace WeatherApp.Tests.Services
{
    [TestFixture]
    public class WeatherServiceIntegrationTests
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IWeatherService _weatherService;

        public WeatherServiceIntegrationTests()
        {
            _unitOfWorkFactory = new SqlUnitOfWorkFactory();
            _weatherService = new WeatherService(_unitOfWorkFactory);
        }

        [Test]
        public void AddCity_When_city_Then_added_city()
        {
            // Arrange
            CityName city1 = new CityName
            {
                Name = "City1"
            };

            // Act
            _weatherService.AddCity(city1);

            // Assert
            using (var db = new WeatherContext())
            {
                Assert.IsNotNull(db.Cities.Where(c => c.Name == city1.Name).FirstOrDefault());
            }
        }

        [Test]
        public void AddCity_When_null_Then_throw_exception()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _weatherService.AddCity(null));
        }

        [Test]
        public void AddHistoryObject_When_history_Then_added_history()
        {
            // Arrange
            var reducedForecastPerDay = new ReducedForecastPerDay
            {
                Time = 444,
                DayTemp = 1,
                NightTemp = 2,
                EveningTemp = 3,
                MorningTemp = 4,
                Rain = "rain",
                Pressure = 1000,
                Humidity = 57,
                WindSpeed = 12,
                WindDirection = 234,
                Clouds = 65
            };

            var history1 = new HistoryWeatherDataObject
            {
                Id = 1,
                City = "city1",
                CountDays = 1,
                RequestTime = DateTime.Now,
                ReducedForecastPerDay = reducedForecastPerDay
            };

            // Act
            _weatherService.AddHistoryObject(history1);

            // Assert
            using (var db = new WeatherContext())
            {
                Assert.IsNotNull(db.History.FirstOrDefault(h => h.City == history1.City));
            }
        }

        [Test]
        public void AddHistoryObject_When_null_Then_throw_exception()
        {
            // Arrange
            //Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _weatherService.AddHistoryObject(null));
        }

        [Test]
        public void DeleteCitiesWithName_When_cities_Then_deleted_cities()
        {
            // Arrange
            CityName city1 = new CityName
            {
                Name = "City1"
            };

            using (var db = new WeatherContext())
            {
                db.Cities.Add(city1);
                db.SaveChanges();

                // Act
                _weatherService.DeleteCitiesWithName(city1.Name);

                // Assert
                Assert.IsNull(db.Cities.FirstOrDefault(c => c.Name == city1.Name));
            }
        }

        [Test]
        public void DeleteCitiesWithName_When_null_Then_throw_exception()
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _weatherService.DeleteCitiesWithName(null));
        }

    }
}
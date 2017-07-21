using System;
using System.Linq;
using WeatherApp.DAL.Repositories;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Tests.Fake;
using FakeItEasy;
using NUnit.Framework;
using System.Threading.Tasks;

namespace WeatherApp.Tests.Services
{
    [TestFixture]
    public class WeatherServiceUnitTests
    {
        private readonly FakeRepository<CityName> _fakeCityRepository;
        private readonly FakeRepository<HistoryWeatherDataObject> _fakeHistoryRepository;
        private readonly FakeUnitOfWorkFactory _fakeUnitOfWorkFactory;

        public WeatherServiceUnitTests()
        {
            _fakeCityRepository = new FakeRepository<CityName>();
            _fakeHistoryRepository = new FakeRepository<HistoryWeatherDataObject>();

            _fakeUnitOfWorkFactory = new FakeUnitOfWorkFactory(
                uow =>
                {
                    uow.SetRepository(_fakeCityRepository);
                    uow.SetRepository(_fakeHistoryRepository);
                });
        }

        [SetUp]
        public void TestSetup()
        {
            var city1 = new CityName { Id = 1, Name = "City1" };
            var city2 = new CityName { Id = 2, Name = "City2" };

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
            var history2 = new HistoryWeatherDataObject
            {
                Id = 2,
                City = "city2",
                CountDays = 1,
                RequestTime = DateTime.Now,
                ReducedForecastPerDay = reducedForecastPerDay
            };
            var history3 = new HistoryWeatherDataObject
            {
                Id = 3,
                City = "city3",
                CountDays = 1,
                RequestTime = DateTime.Now,
                ReducedForecastPerDay = reducedForecastPerDay
            };

            _fakeCityRepository.Data.AddRange(new[] { city1, city2 });
            _fakeHistoryRepository.Data.AddRange(new[] { history1, history2, history3 });
        }

        [TearDown]
        public void TestTearDown()
        {
            _fakeCityRepository.Data.Clear();
            _fakeHistoryRepository.Data.Clear();
        }

        [Test]
        [TestCase("Kiev", 1)]
        [TestCase("Lviv", 3)]
        [TestCase("Odessa", 7)]
        public async Task GetWeatherAsync_When_correct_city_and_count_days_Then_object(string cityName, int countDays)
        {
            // Arrange
            WeatherService service = new WeatherService(_fakeUnitOfWorkFactory);

            // Act
            var weatherData = await service.GetWeatherAsync(cityName, countDays);

            // Assert
            Assert.IsNotNull(weatherData);
        }

        [Test]
        [TestCase("kjdnbkfv,mxf", 1)]
        [TestCase("Lviv", 34)]
        [TestCase("kjdnbkfv,mxf", 72)]
        public void GetWeatherAsync_When_incorrect_city_or_count_days_Then_throw_exception(string cityName, int countDays)
        {
            // Arrange
            WeatherService service = new WeatherService(_fakeUnitOfWorkFactory);

            // Act
            // Assert
            Assert.ThrowsAsync<WeatherException>(async () => await service.GetWeatherAsync(cityName, countDays));
        }

        [Test]
        [TestCase("City2")]
        public void DeleteCitiesWithName_When_existing_one_city_Then_deleted_city(string cityName)
        {
            // Arrange
            WeatherService service = new WeatherService(_fakeUnitOfWorkFactory);

            // Act
            service.DeleteCitiesWithName(cityName);

            // Assert
            Assert.IsNull(service.GetCityList().FirstOrDefault(c => c.Name == cityName));
        }

        [Test]
        [TestCase("City2")]
        public void DeleteCitiesWithName_When_existing_cities_Then_deleted_cities(string cityName)
        {
            // Arrange
            _fakeCityRepository.Add(new CityName
            {
                Id = 3,
                Name = cityName
            });
            WeatherService service = new WeatherService(_fakeUnitOfWorkFactory);

            // Act
            service.DeleteCitiesWithName("City2");

            // Assert
            Assert.IsNull(service.GetCityList().FirstOrDefault(c => c.Name == cityName));
        }

        // Study FakeItEasy =)
        [Test]
        public void AddCity_When_city_Then_SaveChanges_of_UnitOfWork_called()
        {
            // Arrange
            var city1 = new CityName { Id = 1, Name = "City1" };
            var city2 = new CityName { Id = 2, Name = "City2" };

            var cityRepository = A.Fake<IRepository<CityName>>();
            A.CallTo(() => cityRepository.Query()).Returns(new[] { city1 }.AsQueryable());

            var unitOfWork = A.Fake<IUnitOfWork>();
            A.CallTo(() => unitOfWork.Repository<CityName>()).Returns(cityRepository);

            var unitOfWorkFactory = A.Fake<IUnitOfWorkFactory>();
            A.CallTo(() => unitOfWorkFactory.Create()).Returns(unitOfWork);

            var service = new WeatherService(unitOfWorkFactory);

            // Act
            service.AddCity(city2);

            // Assert
            A.CallTo(() => unitOfWork.SaveChanges()).MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}
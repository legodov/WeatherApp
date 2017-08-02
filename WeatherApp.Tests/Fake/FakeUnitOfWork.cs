using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.DAL;
using WeatherApp.Models;

namespace WeatherApp.Tests.Fake
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, object> _repositories;

        public FakeUnitOfWork()
        {
            _repositories = new Dictionary<Type, object>();
        }

        public void SetRepository<T>(IRepository<T> repository) where T : class, IEntity
        {
            _repositories[typeof(T)] = repository;
        }
        public IRepository<T> Repository<T>() where T : class, IEntity
        {
            object repository;
            return _repositories.TryGetValue(typeof(T), out repository)
                       ? (IRepository<T>)repository
                       : new FakeRepository<T>();
        }
        public void SaveChanges()
        { }
        public async Task SaveChangesAsync()
        {
            await Task.Delay(1000);
        }
        public void Dispose()
        { }
    }
}
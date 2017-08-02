using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity;
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

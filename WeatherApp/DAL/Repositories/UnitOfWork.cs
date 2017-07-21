using System.Data.Entity;
using WeatherApp.Models;

namespace WeatherApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dataContext;

        public UnitOfWork(DbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IRepository<T> Repository<T>() where T : class, IEntity
        {
            return new Repository<T>(_dataContext);
        }
        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
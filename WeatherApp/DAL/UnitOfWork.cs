using System.Data.Entity;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.DAL
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
        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
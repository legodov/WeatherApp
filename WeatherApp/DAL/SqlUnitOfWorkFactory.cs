using WeatherApp.Db;

namespace WeatherApp.DAL
{ 
    public class SqlUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new WeatherContext());
        }
    }
}
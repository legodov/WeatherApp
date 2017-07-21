namespace WeatherApp.DAL.Repositories
{
    public class SqlUnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new WeatherContext());
        }
    }
}
namespace WeatherApp.DAL
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}

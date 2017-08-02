using System;
using WeatherApp.DAL;

namespace WeatherApp.Tests.Fake
{
    public class FakeUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly FakeUnitOfWork _unitOfWork;

        public FakeUnitOfWorkFactory(Action<FakeUnitOfWork> constructUnitOfWork)
        {
            _unitOfWork = new FakeUnitOfWork();
            constructUnitOfWork(_unitOfWork);
        }

        public IUnitOfWork Create()
        {
            return _unitOfWork;
        }
    }
}
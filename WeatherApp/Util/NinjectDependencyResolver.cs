using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WeatherApp.DAL.Repositories;
using WeatherApp.Services;

namespace WeatherApp.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IWeatherService>().To<WeatherService>();
            kernel.Bind<IUnitOfWorkFactory>().To<SqlUnitOfWorkFactory>();
        }
    }
}
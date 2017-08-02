using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.DAL
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> Query();
        IEnumerable<T> All();
        Task<IEnumerable<T>> AllAsync();
        T Get(int id);
        Task<T> GetAsync(int id);
        T Get(Func<T, bool> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
    }
}

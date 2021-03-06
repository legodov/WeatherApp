﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.DAL
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly DbContext _dataContext;
        protected readonly DbSet<T> _dataSet;

        public Repository(DbContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = dataContext.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return _dataSet;
        }
        public IEnumerable<T> All()
        {
            return _dataSet.ToList();
        }
        public async Task<IEnumerable<T>> AllAsync()
        {
            return await _dataSet.ToListAsync();
        }
        public T Get(int id)
        {
            return _dataSet.FirstOrDefault(x => x.Id == id);
        }
        public async Task<T> GetAsync(int id)
        {
            return await _dataSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        public T Get(Func<T, bool> predicate)
        {
            return _dataSet.FirstOrDefault(predicate);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dataSet.FirstOrDefaultAsync(predicate);
        }
        public void Add(T entity)
        {
            _dataSet.Add(entity);
        }
        public void Attach(T entity)
        {
            _dataSet.Attach(entity);
        }
        public void Delete(T entity)
        {
            _dataSet.Remove(entity);
        }
        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}

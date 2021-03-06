﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeatherApp.DAL;
using WeatherApp.Models;

namespace WeatherApp.Tests.Fake

{
    public class FakeRepository<T> : IRepository<T> where T : class, IEntity
    {
        public List<T> Data;

        public FakeRepository(params T[] data)
        {
           Data = new List<T>(data);
        }

        public IQueryable<T> Query()
        {
            return Data.AsQueryable();
        }
        public IEnumerable<T> All()
        {
            return Data;
        }
        public async Task<IEnumerable<T>> AllAsync()
        {
            await Task.Delay(1000);
            return Data;
        }
        public T Get(int id)
        {
            return Data.FirstOrDefault(x => x.Id == id);
        }
        public async Task<T> GetAsync(int id)
        {
            await Task.Delay(1000);
            return Data.FirstOrDefault(x => x.Id == id);
        }
        public T Get(Func<T, bool> predicate)
        {
            return Data.FirstOrDefault(predicate);
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            await Task.Delay(1000);
            return Data.FirstOrDefault();
        }
        public void Add(T entity)
        {
            Data.Add(entity);
        }
        public void Attach(T entity)
        {
        }
        public void Delete(T entity)
        {
            Data.Remove(entity);
        }
    }
}
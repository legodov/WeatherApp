﻿using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Models;

namespace WeatherApp.DAL.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> Query();
        IEnumerable<T> All();
        T Get(int id);
        T Get(Func<T, bool> predicate);
        void Add(T entity);
        void Attach(T entity);
        void Delete(T entity);
    }
}

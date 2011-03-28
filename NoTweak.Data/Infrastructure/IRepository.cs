﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoTweak.Data.Infrastructure
{
public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Delete(T entity);
    void Delete(Func<T, Boolean> predicate);
    T GetById(long Id);
    T Get(Func<T, Boolean> where);
    IEnumerable<T> GetAll();
    IEnumerable<T> GetMany(Func<T, bool> where);
}
}

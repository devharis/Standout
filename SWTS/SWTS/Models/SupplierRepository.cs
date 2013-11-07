﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using SWTS.Models.Interface;

namespace SWTS.Models
{
    public class SupplierRepository : ISupplierRepository
    {
        private DbContext _context;

        public SupplierRepository()
        {
            this._context = new SupplierContext();
            this._context.Configuration.LazyLoadingEnabled = true;
        }

        public IQueryable<T> Query<T>() where T : class
        {
            return this._context.Set<T>().AsQueryable<T>();
        }

        public void Add<T>(T entity) where T : class
        {
            this._context.Set<T>().Add(entity);
        }

        public T Find<T>(Func<T, bool> where) where T : class
        {
            return this._context.Set<T>().SingleOrDefault(where);
        }

        public IEnumerable<T> FindAll<T>() where T : class
        {
            return this._context.Set<T>().AsEnumerable();
        }

        public void Update<T>(T entity) where T : class
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<T>(T entity) where T : class
        {
            this._context.Entry(entity).State = EntityState.Deleted;
        }

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}
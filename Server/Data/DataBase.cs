using BlazorBlog.Server.Contracts;
using BlazorBlog.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BlazorBlog.Server.Data
{
    public abstract class DataBase<T> : IDataBase<T> where T : class
    {
        private AMCDbContext AMCDbContext { get; set; }

        protected DataBase(AMCDbContext amcDbContext)
        {
            AMCDbContext = amcDbContext;
        }
        public IQueryable<T> FindAll()
        {
            return AMCDbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return AMCDbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            AMCDbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            AMCDbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            AMCDbContext.Set<T>().Remove(entity);
        }
    }
}

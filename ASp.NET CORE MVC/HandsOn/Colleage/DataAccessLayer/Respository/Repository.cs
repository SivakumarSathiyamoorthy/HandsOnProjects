using DataAccessLayer.DBContext;
using DataAccessLayer.Respository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Respository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> _dbSet;
        MyDBContext _dbContext;
        public Repository(MyDBContext dbContext) 
        {
            _dbContext=dbContext;
            this._dbSet=dbContext.Set<T>();

        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(string? includeProperties=null)
        {
            IQueryable<T> query = _dbSet;
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[]{ ','},StringSplitOptions.RemoveEmptyEntries))
                    {
                       query= query.Include(property);
                }
            }
            return query.ToList();
        }
        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();

        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }
    }
}

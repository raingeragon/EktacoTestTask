using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EktacoTestTask.Entities;
using EktacoTestTask.DataBaseContext;

namespace EktacoTestTask.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {

        protected readonly System.Data.Entity.DbContext _dataContext;
        protected readonly DbSet<T> _dataSet;

        public Repository()
        {
            _dataContext = new EktacoDbContext();
            _dataSet = _dataContext.Set<T>();
        }

        public IQueryable<T> Query()
        {
            return _dataSet;
        }

        public IEnumerable<T> All()
        {
            var list = _dataSet.ToList();
            return list;
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

        public void Add(T entity)
        {
            _dataSet.Add(entity);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
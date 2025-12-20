using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using examinationAPI.Data;
using examinationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace examinationAPI.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbset;

        public Repository(Context context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public bool Add(T entity)
        {
            _dbset.Add(entity);
            return true;
        }

        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await GetAll().Where(expression).FirstOrDefaultAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.Where(x => !x.IsDeleted);
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbset.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<T?> GetWithTrackingById(int id)
        {
            return _dbset
                .Where(x => !x.IsDeleted && x.Id == id)
                .AsTracking()
                .FirstOrDefaultAsync();
        }

        public void HardDelete(int id)
        {
            _dbset
                .Where(x => x.Id == id)
                .ExecuteDelete();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public bool Exists(int id)
        {
            return _dbset.Any(x => x.Id == id);
        }

        public async Task<IEnumerable<TResult>> GetFilter<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        {
            return await _context.Set<T>()
                .Where(predicate)
                .Select(selector)
                .ToListAsync();
        }
    }
}

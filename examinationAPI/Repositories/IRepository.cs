using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using examinationAPI.Models;

namespace examinationAPI.Repositories
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T?> Get(Expression<Func<T,bool>> expression);
        IQueryable<T> GetAll();
        Task<T?> GetById(int id);
        Task<T?> GetWithTrackingById(int id);
        Task<T?> GetWithTracking(Expression<Func<T, bool>> predicate);
        bool Add(T entity);
        void Update(T entity);
        void SoftDelete(T entity);
        void HardDelete(int id);
        Task SaveChanges();
        bool Exists(int id);
        Task<IEnumerable<TResult>> GetFilter<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector);
    }
}
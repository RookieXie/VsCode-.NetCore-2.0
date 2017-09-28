using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace mvcDemo.Base
{
    public interface IRepository<T> where T:class
    {
        void Add(T entity);
        void Add(ICollection<T> entities);

        void Delete(T entity);

        void Delete(Func<T,bool> predicate);

        void DeleteByKey(params object[] keyValues);

        T Get(Expression<Func<T,bool>> where);

        T GetByKey(params object[] keyValues);

        ICollection<T> GetMany(Func<T,bool> where);

        ICollection<T> GetMany<S>(Expression<Func<T, bool>> where, Expression<Func<T, S>> orderByExpression, bool IsDesc, int PageIndex, int PageSize, out int TotalRecord);
        
        IQueryable<T> QueryMany(Expression<Func<T, bool>> where);

        void Update(T entity);
    }
    
}
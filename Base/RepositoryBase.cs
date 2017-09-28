using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace mvcDemo.Base
{
    public abstract class RepositoryBase<T> :IDisposable,IRepository<T> where T:class
    {
        protected readonly DbSet<T> dbset;
        private BaseDBContext fDataContext;

        protected RepositoryBase(BaseDBContext DbContext)
        {
            this.fDataContext = DbContext;
            this.dbset = this.fDataContext.Set<T>();
        }
        public DbContext DataContext => this.fDataContext;
        public DbSet<T> DbSet => this.dbset;
        public virtual void Add(T entity)
        {
            this.dbset.Add(entity);
        }
        public virtual void Add(ICollection<T> entities)
        {
            foreach (T item in entities)
            {
                this.dbset.Add(item);
            }
        }
        public virtual void Delete(T entity)
        {
            this.dbset.Remove(entity);
        }
        public virtual void Delete(Func<T,bool> predicate)
        {
            IEnumerable<T> enumerable = this.dbset.Where<T>(predicate).AsEnumerable<T>();
            foreach (T item in enumerable)
            {
                this.dbset.Remove(item);
            }
        }
        public virtual void DeleteByKey(params Object[] keyValues)
        {
            T entity = this.dbset.Find(keyValues);
            this.dbset.Remove(entity);
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.fDataContext != null)
            {
                this.fDataContext.Dispose();
            }
        }

        public virtual void Edit(T entity)
        {

        }
        public virtual void Edit(T bean,Action<T> editBlock)
        {
            editBlock(bean);
        }
        public virtual T Get(Expression<Func<T, bool>> where) => this.dbset.Where<T>(where).FirstOrDefault<T>();

        public virtual T GetByKey(object key) => this.dbset.Find(new object[] { key });

        public virtual T GetByKey(params object[] keyValues) => this.dbset.Find(keyValues);
        public virtual ICollection<T> GetMany(Func<T, bool> where) => this.dbset.Where<T>(where).ToList<T>();
        public virtual ICollection<T> GetMany<S>(Expression<Func<T,bool>> where,Expression<Func<T,S>> orderByExpression,bool IsDesc,int PageIndex,int PageSize,out int TotalRecord)
        {
            TotalRecord = 0;
            IOrderedQueryable<T> source = IsDesc ? this.dbset.OrderByDescending<T, S>(orderByExpression):this.dbset.OrderBy<T,S>(orderByExpression);
            if (TotalRecord >= 0)
            {
                if (where != null)
                {
                    IEnumerable<T> enumerable = source.Where<T>(where.Compile());
                    TotalRecord = enumerable.Count<T>();
                    return enumerable.Skip<T>((PageIndex - 1) * PageSize).Take<T>(PageSize).ToList<T>();
                }
                TotalRecord = source.Count<T>();
                return source.Skip<T>((PageIndex - 1) * PageSize).Take<T>(PageSize).ToList<T>();
            }
            return null;
        }
        public virtual IQueryable<T> QueryMany(Expression<Func<T, bool>> where) => this.dbset.Where<T>(where);
        public virtual void Update(T entity)
        {
            this.dbset.Update(entity);
            this.fDataContext.Entry<T>(entity).State = EntityState.Modified;
        }

    }
}
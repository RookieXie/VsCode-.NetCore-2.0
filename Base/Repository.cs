using System;
namespace mvcDemo.Base
{
    public class Repository<T,TContext>:RepositoryBase<T>,IDisposable  where T:class where TContext:BaseDBContext
    {
        public Repository(BaseDBContext dbContext) : base(dbContext)
        {

        }
        public TContext DbContext => (base.DataContext as TContext);

        public override void Add(T entity)
        {
            //默认值设定
            base.Add(entity);
        }

        public override void Update(T entity)
        {
            //默认值设定
            base.Update(entity);
        }

        public override void Delete(T entity)
        {
            base.Delete(entity);
        }
        public void TombstonedDelete(T entity)
        {
            //逻辑删除处理
            base.Update(entity);
        }
        public int Commit() =>
     base.DataContext.SaveChanges();

    }
}
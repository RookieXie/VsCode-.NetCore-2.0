using mvcDemo.Base;
namespace mvcDemo.Test
{
   public class TestRespository<T>:Repository<T, TestDBContext>,IRepository<T> where T:class
    {
        public TestRespository(IUnitOfData dbContext) :base(dbContext as TestDBContext)
        {

        }
    } 
}
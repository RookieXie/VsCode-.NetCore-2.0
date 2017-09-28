using mvcDemo.Base;
namespace mvcDemo.Test
{
    public class DATest:TestRespository<TestData>
    {
        public DATest(IUnitOfData dbContext) : base(dbContext)
        {

        }
    }
}
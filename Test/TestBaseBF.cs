using Microsoft.EntityFrameworkCore;
using mvcDemo.Base;
namespace mvcDemo.Test
{
    public class TestBaseBF
    {
        private IUnitOfData fUnitOfData;
       

        public TestBaseBF SetUnitOfData(IUnitOfData unitOfData)
        {
            if (unitOfData != null)
            {
                fUnitOfData = unitOfData;
            }
            return this;
        }

        public IUnitOfData UnitOfData
        {
            get
            {
                if (fUnitOfData == null)
                {
                    var optionsBuilder = new DbContextOptionsBuilder<BaseDBContext>();
                    optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Test;User ID=sa;Pwd=123456");
                    fUnitOfData = new TestDBContext(optionsBuilder.Options);
                    // fUnitOfData.db
                }
                return fUnitOfData;
            }
        }

        public int Submit()
        {
            return UnitOfData.Submit();
        }

        public void Dispose()
        {
            if (fUnitOfData != null)
            {
                fUnitOfData.Dispose();
            }
            // throw new NotImplementedException();
        }

        //public static TestDBContext FetchDbContext()
        //{
        //    DbContextOptions<BaseDBContext> options = new DbContextOptions<BaseDBContext>();
        //    return new TestDBContext(options);
        //}
    }
}
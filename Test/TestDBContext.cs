using Microsoft.EntityFrameworkCore;
using mvcDemo.Base;
namespace mvcDemo.Test
{
    public class TestDBContext: BaseDBContext
    {
        //public TestDBContext() : base()
        //{
        //}
        public TestDBContext(DbContextOptions<BaseDBContext> options) : base(options)
        {
        }
        public DbSet<TestData> TestData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }        
    }
}
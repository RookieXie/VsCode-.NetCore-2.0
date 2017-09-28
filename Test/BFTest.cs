using System.Linq;
namespace mvcDemo.Test
{
    public class BFTest:TestBaseBF
    {
        public void  AddModel(TestData model)
        {
            DATest _da = new DATest(UnitOfData);
            _da.Add(model);
        }
        public TestData GetByFID(string fid){
            DATest _da = new DATest(UnitOfData);
            var model = _da.QueryMany(a => a.FID == fid).FirstOrDefault();
            return model;
        }
    }
}
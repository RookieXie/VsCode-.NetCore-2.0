using System;
using System.Data.SqlClient;
using System.Data;
namespace mvcDemo.Base
{
  public interface IUnitOfData:IDisposable
    {
        int ExecuteSqlCommand(string sql, params SqlParameter[] param);

        int ExecuteStore(string storedName, params SqlParameter[] param);

        string GetUniId();

        DataSet QueryDataSet(string sql, params SqlParameter[] param);

        object QueryObject(string sql, params SqlParameter[] param);

        int Submit();
       
    }  
}
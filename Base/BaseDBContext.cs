using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using System.Data.SqlClient;
namespace mvcDemo.Base
{
    public class BaseDBContext:DbContext,IUnitOfData,IDisposable
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options) : base(options)
        {

        }
        public virtual int ExecuteSqlCommand(string sql, params SqlParameter[] param) =>
base.Database.ExecuteSqlCommand(sql, param);
        public virtual int ExecuteStore(string storedName, params SqlParameter[] param) => base.Database.ExecuteSqlCommand("EXECUTE " + storedName, param);

        public string GetUniId()
        {
            return "";
        }
        public int Submit()
        {
            return base.SaveChanges();
        } 
        public override void Dispose()
        {
            base.Dispose();
        }
        public object QueryObject(string sqlString, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = base.Database.GetDbConnection() as SqlConnection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            cmd.Connection = connection;
            cmd.CommandText = sqlString;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            //StringBuilder sb = new StringBuilder();
            //DBUtil.DbCommandToString(cmd, sb);
            //AtawTrace.WriteFile(LogType.QueryObject, sb.ToString());
            object obj2 = cmd.ExecuteScalar();
            if (connection != null)
            {
                connection.Close();
            }
            return obj2;
        }
        public DataSet QueryDataSet(string sqlString, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = base.Database.GetDbConnection() as SqlConnection;
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            cmd.Connection = connection;
            cmd.CommandText = sqlString;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
            //StringBuilder sb = new StringBuilder();
            //DBUtil.DbCommandToString(cmd, sb);
            //AtawTrace.WriteFile(LogType.PageQuerySql, sb.ToString());
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dataSet);
                    cmd.Parameters.Clear();
                }
                return dataSet;
            }
            catch (Exception exception)
            {
                //AtawTrace.WriteFile(LogType.SqlQueryError, sb.ToString());
                throw exception;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
            //return dataSet;
        }
    }
}
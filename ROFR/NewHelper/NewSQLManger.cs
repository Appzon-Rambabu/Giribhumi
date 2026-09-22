using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ROFR.NewHelper
{
    public class NewSQLManger
    {
        System.Data.SqlClient.SqlConnection sqlconn = null;
        public string connectionString;
        public NewSQLManger()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["DBDCRVCR"].ConnectionString;
        }
        public System.Data.SqlClient.SqlConnection GetConnection()
        {
            sqlconn = new System.Data.SqlClient.SqlConnection();
            sqlconn.ConnectionString = connectionString;
            return sqlconn;
        }

        public void CloseConnection()
        {
            if (sqlconn.State == System.Data.ConnectionState.Open)
                sqlconn.Close();
        }
        public DataTable ExecuteProcedureReturnDataTable(string QueryText, List<SqlParameter> sqlparameters = null)
        {
            System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand();
            sqlcmd.CommandTimeout = 0;
            sqlcmd.Connection = GetConnection();
            sqlcmd.CommandText = QueryText;
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = sqlcmd;

            DataTable result = new DataTable();

            if (sqlparameters != null)
            {
                foreach (var param in sqlparameters)
                    sqlcmd.Parameters.Add(param);
            }

            try
            {
                sqladapter.Fill(result);
            }
            finally
            {
                sqlcmd.Connection.Close();
            }
            return result;
        }

        public DataSet ExecuteProcedureReturnDataSet(string QueryText, List<SqlParameter> sqlparameters = null)
        {
            System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand();
            sqlcmd.CommandTimeout = 0;
            sqlcmd.Connection = GetConnection();
            sqlcmd.CommandText = QueryText;
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            System.Data.SqlClient.SqlDataAdapter sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = sqlcmd;

            DataSet result = new DataSet();

            if (sqlparameters != null)
            {
                foreach (var param in sqlparameters)
                    sqlcmd.Parameters.Add(param);
            }

            try
            {
                sqladapter.Fill(result);
            }
            finally
            {
                sqlcmd.Connection.Close();
            }
            return result;
        }
    }
}
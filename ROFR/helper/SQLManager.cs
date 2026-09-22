using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using ROFR.Models;
using System.Text;

namespace ROFR.helper
{
    public class SQLManager
    {
        System.Data.SqlClient.SqlConnection sqlconn = null;
        public string connectionString;

        public SQLManager()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["ROFR"].ConnectionString;
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

        public int ExecuteProcedure(string QueryText, List<SqlParameter> sqlparameters = null)
        {
            int result = 0;
            System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand();
            sqlcmd.Connection = GetConnection();
            sqlcmd.CommandText = QueryText;
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (sqlparameters != null)
            {
                foreach (var param in sqlparameters)
                    sqlcmd.Parameters.Add(param);
            }

            try
            {
                sqlcmd.Connection.Open();
                result = sqlcmd.ExecuteNonQuery();
            }
            finally
            {
                sqlcmd.Connection.Close();
            }
            return result;
        }

        private object ExecuteProcedureReturnScalar(string queryText, List<SqlParameter> sqlparameters = null)
        {
            object result = 0;
            System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand();
            sqlcmd.Connection = GetConnection();
            sqlcmd.CommandText = queryText;
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (sqlparameters != null)
            {
                foreach (var param in sqlparameters)
                    sqlcmd.Parameters.Add(param);
            }

            try
            {
                sqlcmd.Connection.Open();
                result = sqlcmd.ExecuteScalar();
            }
            finally
            {
                sqlcmd.Connection.Close();
            }
            return result;
        }

        public Int32 ExecuteProcedureReturnIdentity(string queryText, List<SqlParameter> sqlparameters = null)
        {
            return Convert.ToInt32(ExecuteProcedureReturnScalar(queryText, sqlparameters));
        }

        public string ExecuteProcedureReturnString(string queryText, List<SqlParameter> sqlparameters = null)
        {
            return ExecuteProcedureReturnScalar(queryText, sqlparameters).ToString();
        }

        public SqlDataReader ExecuteProcedureReturnDataReader(string QueryText, List<SqlParameter> sqlparameters = null)
        {
            System.Data.SqlClient.SqlDataReader result = null;
            System.Data.SqlClient.SqlCommand sqlcmd = new System.Data.SqlClient.SqlCommand();
            sqlcmd.Connection = GetConnection();
            sqlcmd.CommandText = QueryText;
            sqlcmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (var param in sqlparameters)
                sqlcmd.Parameters.Add(param);
            try
            {
                sqlcmd.Connection.Open();
                result = sqlcmd.ExecuteReader();
            }
            finally
            {
                sqlcmd.Connection.Close();
            }
            return result;
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



        public string StockVerifyToken(System.Net.Http.Headers.HttpRequestHeaders headers)
        {
            #region "Header Response"			
            string token = string.Empty;
            string pwd = string.Empty;
            string username = string.Empty;
            try
            {
                if (headers.Contains("Session_Key"))
                {
                    token = headers.GetValues("Session_Key").First();
                }
                if (headers.Contains("username"))
                {
                    username = headers.GetValues("username").First();
                }
                if (headers.Contains("password"))
                {
                    pwd = headers.GetValues("password").First();
                }

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pwd) || string.IsNullOrEmpty(token))
                {
                    return "Failure, Authentication Token Header is Missing";
                }
                else
                {
                    string dbtoken = "969A687C0F273H0852A75347529CF5D385974995FC1B9JJ97CD0RFV07A215RElTUEFUQ0G";

                    if (token == dbtoken && username == "Voil" && pwd == "Voil@123")
                    {
                        return "success";
                    }
                    else
                    {
                        return "Failure, Authentication Token is Invalid";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            #endregion
        }

        


       




    }
}
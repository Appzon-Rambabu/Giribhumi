using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace ROFR.Loans.CSFiles
{
    public class CommonSPHel
    {
        SqlConnection con;
        string Constr = ConfigurationManager.ConnectionStrings["ROFR"].ConnectionString;
        SqlCommand cmd;
        SqlDataAdapter adp;
        SqlTransaction trans;

        #region "Sql Common Methods"

        public DataTable GetDataAdapter(SqlCommand cmd)
        {
            try
            {
                con = new SqlConnection(Constr);
                cmd.Connection = con;
                cmd.CommandTimeout = 180;
                con.Open();

                DataTable dt = new DataTable();
                adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                cmd.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    cmd.Dispose();
                }
            }
        }
        public int getExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                con = new SqlConnection(Constr);
                cmd.Connection = con;
                cmd.CommandTimeout = 180;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                    cmd.Dispose();
                }
            }
        }

        #endregion
    }
}
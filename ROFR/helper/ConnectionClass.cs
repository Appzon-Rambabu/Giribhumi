using System;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.Dynamic;
using System.Drawing;
using System.Management;

using System.Drawing.Imaging;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Web.UI;

namespace ROFR.helper
{
    public class ConnectionClass
    {


        public DataTable result_tbl = null;

        string oradbnew = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=apexadata-scan1.apsdc.ap.gov.in)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=APSPS16)));User Id=itda;Password=TR_BA_WE_FARE;";

        OracleConnection con;
        OracleCommand objCmd;
        OracleDataAdapter dap;
        DataTable dt;

        string PName = "";

        private void Con_Close()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private void Con_Close_Exception()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (objCmd != null)
            {
                objCmd.Dispose();
                dap.Dispose();
                dt.Dispose();
            }
        }

        public DataTable Data(rofrObject obj)
        {
            try
            {
                con = new OracleConnection(oradbnew);
                con.Open();
                objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.InitialLONGFetchSize = 1000;
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.CommandText = "EducatioN_PRIMARY_SECONDARY";
                objCmd.Parameters.Add("p_itda", OracleDbType.Varchar2).Value = null;
                objCmd.Parameters.Add("p_mandal", OracleDbType.Varchar2).Value = null;
                objCmd.Parameters.Add("p_village", OracleDbType.Varchar2).Value = null;
                objCmd.Parameters.Add("p_report", OracleDbType.Varchar2).Value = "1";

                objCmd.Parameters.Add("p_cur ", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap = new OracleDataAdapter(objCmd);
                objCmd.CommandTimeout = 0;
                dt = new DataTable();
                dap.Fill(dt);
                objCmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    Con_Close();

                    return dt;
                }
                else
                {
                    Con_Close();


                    return null;
                }

            }
            catch (Exception ex)
            {
                return dt;
            }

        }
    }
}
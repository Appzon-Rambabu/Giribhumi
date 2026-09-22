using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System;
using System.IO;
using context = System.Web.HttpContext;


namespace ROFR.helper
{
    public class DBClass
    {
        public DataTable result_tbl = null;
        //DBQuery objDBQuery = new DBQuery();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ROFR"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter dap;
        DataTable dt;
        string stype = string.Empty;
        int column_sum = 0, tot1 = 0, tot2 = 0, tot3 = 0, tot4 = 0, tot5 = 0, tot6 = 0;
        double tot7 = 0;
        //log lg = null;
        string PName = "";


        public DBClass()
        {
            //
            // TODO: Add constructor logic here
            //

        }
        public SqlDataReader ExecuteDataReader(string Query)
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();
                cmd = new SqlCommand(Query, con);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
                return null;
            }
        }
        public DataTable retdt(string query, string keyarea)
        {
            try
            {
                cmd = new SqlCommand(query, con);
                dap = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dap.Fill(dt);
                cmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return dt = new DataTable();
                }

            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    dap.Dispose();
                    dt.Dispose();
                }
                //print(ex.ToString());
                return dt = new DataTable();
            }
        }


        public void WriteErrorLog(Exception ex)
        {
            string webPageName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string errorLogFilename = "ErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            string path = context.Current.Server.MapPath("~/ErrorLog/" + errorLogFilename);
            if (File.Exists(path))
            {
                using (StreamWriter stwriter = new StreamWriter(path, true))
                {
                    stwriter.WriteLine("-------------------Error Log Start-----------as on " + DateTime.Now.ToString("hh:mm tt"));
                    stwriter.WriteLine("WebPage Name :" + webPageName);
                    stwriter.WriteLine("Message:" + ex.ToString());
                    stwriter.WriteLine("-------------------End----------------------------");
                }
            }
            else
            {
                StreamWriter stwriter = File.CreateText(path);
                stwriter.WriteLine("-------------------Error Log Start-----------as on " + DateTime.Now.ToString("hh:mm tt"));
                stwriter.WriteLine("WebPage Name :" + webPageName);
                stwriter.WriteLine("Message: " + ex.ToString());
                stwriter.WriteLine("-------------------End----------------------------");
                stwriter.Close();
            }
        }

        public bool update(string query, string keyarea)
        {
            try
            {
                //lg.Add("update -->:" + query.ToString(), "UPQuery");
                cmd = new SqlCommand(query, con);
                // con.ConnectionTimeout = 180000;
                cmd.CommandTimeout = 360000;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                //con.Close();
                cmd.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                //string ss = keyarea.Split('@')[1].ToString();
                //filemessage(ss);
                // print(ex.ToString());
                return false;
            }
        }
        public string retvalue(string query, string keyarea)
        {
            try
            {
                cmd = new SqlCommand(query, con);
                dap = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dap.Fill(dt);
                cmd.Dispose();
                dap.Dispose();
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                    dap.Dispose();
                    dt.Dispose();
                }
                return string.Empty;
            }
        }
        public DataTable CreateDataTable(string[] strColumnsNames)
        {
            DataTable myDataTable = new DataTable();
            try
            {
                DataColumn myDataColumn;
                foreach (string strCName in strColumnsNames)
                {
                    myDataColumn = new DataColumn();
                    myDataColumn.DataType = Type.GetType("System.String");
                    myDataColumn.ColumnName = strCName;
                    myDataTable.Columns.Add(myDataColumn);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog("/TransLog/add", "exception found while creating new table : " + ex.ToString());
            }
            return myDataTable;
        }
        public DataTable AddDataToGridTable(string[] strGridData, DataTable dtGridData)
        {
            try
            {
                DataRow row;

                if (dtGridData != null)
                {
                    row = dtGridData.NewRow();

                    for (int i = 0; i < dtGridData.Columns.Count; i++)
                    {
                        row[i] = strGridData[i].ToString();
                    }
                    dtGridData.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                // ErrorLog("/TransLog/add", "exception found while adding data to muster table : " + ex.ToString());
            }
            return dtGridData;
        }
        public void AddTotalToDataTable(string strRptID, DataTable dtGridData)
        {
            double ifunctn = 0;
            string[] strSumOfTotal = new string[dtGridData.Columns.Count];
            try
            {
                if (dtGridData.Rows.Count > 0)
                {
                    strSumOfTotal[0] = "Total";

                    foreach (DataRow drSumOfTotal in dtGridData.Rows)
                    {
                        if (strRptID == "z")
                        {
                            if (drSumOfTotal[1] != "")
                            {
                                tot1 += Convert.ToInt32(drSumOfTotal[1].ToString());
                            }
                            if (drSumOfTotal[2] != "")
                            {
                                tot2 += Convert.ToInt32(drSumOfTotal[2].ToString());
                            }
                            if (drSumOfTotal[3] != "")
                            {
                                tot3 += Convert.ToInt32(drSumOfTotal[3].ToString());
                            }
                            if (drSumOfTotal[4] != "")
                            {
                                tot4 += Convert.ToInt32(drSumOfTotal[4].ToString());
                            }
                            if (drSumOfTotal[5] != "")
                            {
                                tot7 += Convert.ToDouble(drSumOfTotal[5].ToString());
                            }

                            strSumOfTotal[1] = tot1.ToString();
                            strSumOfTotal[2] = tot2.ToString();
                            strSumOfTotal[3] = tot3.ToString();
                            strSumOfTotal[4] = tot4.ToString();
                            strSumOfTotal[5] = tot7.ToString();
                        }
                        if (strRptID == "w")
                        {
                            if (drSumOfTotal[1] != "")
                            {
                                tot1 += Convert.ToInt32(drSumOfTotal[1].ToString());
                            }
                            if (drSumOfTotal[2] != "")
                            {
                                tot2 += Convert.ToInt32(drSumOfTotal[2].ToString());
                            }
                            if (drSumOfTotal[3] != "")
                            {
                                tot3 += Convert.ToInt32(drSumOfTotal[3].ToString());
                            }
                            if (drSumOfTotal[4] != "")
                            {
                                tot7 += Convert.ToDouble(drSumOfTotal[4].ToString());
                            }

                            strSumOfTotal[1] = tot1.ToString();
                            strSumOfTotal[2] = tot2.ToString();
                            strSumOfTotal[3] = tot3.ToString();
                            strSumOfTotal[4] = tot7.ToString();
                        }
                        if (strRptID == "vt")
                        {
                            if (drSumOfTotal[1] != "")
                            {
                                tot1 += Convert.ToInt32(drSumOfTotal[1].ToString());
                            }
                            if (drSumOfTotal[2] != "")
                            {
                                tot2 += Convert.ToInt32(drSumOfTotal[2].ToString());
                            }
                            if (drSumOfTotal[3] != "")
                            {
                                tot7 += Convert.ToDouble(drSumOfTotal[3].ToString());
                            }

                            strSumOfTotal[1] = tot1.ToString();
                            strSumOfTotal[2] = tot2.ToString();
                            strSumOfTotal[3] = tot7.ToString();
                        }
                        if (strRptID == "vhno")
                        {
                            if (drSumOfTotal[1] != "")
                            {
                                tot1 += Convert.ToInt32(drSumOfTotal[1].ToString());
                            }
                            if (drSumOfTotal[2] != "")
                            {
                                tot7 += Convert.ToDouble(drSumOfTotal[2].ToString());
                            }

                            strSumOfTotal[1] = tot1.ToString();
                            strSumOfTotal[2] = tot7.ToString();
                        }
                    }

                    AddDataToGridTable(strSumOfTotal, dtGridData);
                }
            }
            catch (Exception ex)
            {
                //ErrorLog("/TransLog/erep", "exception found while summing of the columns " + ex.ToString());
            }
        }
        public void AddLinkToDataTable(string linkdata, DataTable dtGridData)
        {
            string linklabel = "", linkdata1 = string.Empty;
            string[] linkdat;
            foreach (DataRow row in dtGridData.Rows)
            {
                string link = string.Empty;

                string finalString = row[0].ToString();
                //finalString = Cryptography.Encrypt(finalString);  satish
                if (dtGridData.Columns.Count == 6)
                {
                    linkdat = linkdata.Split('$');
                    if (dtGridData.Rows[0][1].ToString() == "Auto" || dtGridData.Rows[0][1].ToString() == "Mini Tippe" || dtGridData.Rows[0][1].ToString() == "Tata Ace" || dtGridData.Rows[0][1].ToString() == "Tipper" || dtGridData.Rows[0][1].ToString() == "Transfer Container")
                    {
                        linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + linkdat[2] + "$" + linkdat[3] + "$" + linkdat[4] + "$" + linkdat[5];
                        linklabel = row[0].ToString() + link;
                    }
                    else
                    {
                        if (linkdat[0] == "ft")
                        {
                            linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + linkdat[2] + "$" + finalString + "$" + linkdat[4] + "$" + linkdat[5] + "$" + linkdat[6];
                        }
                        else
                        {
                            linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + finalString + "$" + linkdat[3] + "$" + linkdat[4] + "$" + linkdat[5];
                        }

                        link = "," + "vhltypezonetripweightDetails.aspx" + linkdata1;
                        linklabel = row[0].ToString() + link;
                        row[0] = linklabel;
                    }
                }
                if (dtGridData.Columns.Count == 5)
                {
                    linkdat = linkdata.Split('$');
                    if (linkdat[0] == "ft")
                    {
                        linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + linkdat[2] + "$" + linkdat[3] + "$" + finalString + "$" + linkdat[5] + "$" + linkdat[6];
                    }
                    else
                    {
                        linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + linkdat[2] + "$" + finalString + "$" + linkdat[4] + "$" + linkdat[5];
                    }
                    //linkdata1 = Encrypt(linkdata1);

                    link = "," + "vhltypezonetripweightDetails.aspx" + linkdata1;
                    linklabel = row[0].ToString() + link;
                    row[0] = linklabel;
                }
                if (dtGridData.Columns.Count == 4)
                {
                    linkdat = linkdata.Split('$');
                    if (linkdat[0] == "ft")
                    {
                        linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + linkdat[2] + "$" + linkdat[3] + "$" + linkdat[4] + "$" + finalString + "$" + linkdat[6];
                    }
                    else
                    {
                        linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + linkdat[2] + "$" + linkdat[3] + "$" + finalString + "$" + linkdat[5];
                    }
                    //linkdata1 = Encrypt(linkdata1);

                    link = "," + "vhltypezonetripweightDetails.aspx" + linkdata1;
                    linklabel = row[0].ToString() + link;
                    row[0] = linklabel;
                }
                if (dtGridData.Columns.Count == 3)
                {
                    linkdat = linkdata.Split('$');
                    if (linkdat[0] == "ft")
                    {
                        linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + linkdat[2] + "$" + linkdat[3] + "$" + linkdat[4] + "$" + linkdat[5] + "$" + finalString;
                    }
                    else
                    {
                        linkdata1 = "?msg=" + linkdat[0] + "$" + linkdat[1] + "$" + linkdat[2] + "$" + linkdat[3] + "$" + linkdat[4] + "$" + finalString;
                    }
                    //linkdata1 = Encrypt(linkdata1);

                    link = "," + "vhltypezonetripweightDetails.aspx" + linkdata1;
                    linklabel = row[0].ToString() + link;
                    row[0] = linklabel;
                }
            }
        }
        private string Encrypt(string linkdata1)
        {
            throw new NotImplementedException();
        }
    }
}
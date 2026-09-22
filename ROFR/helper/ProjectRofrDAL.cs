using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using ROFR.helper;
namespace ROFR.helper
{
    public class ProjectRofrDAL
    {
        public class GetMasterDetails
        {

            public void ErrorLogEntry(Exception ex, string ErrorArea, string Username, string Ip)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                if (ex.Message != "Thread was being aborted.")
                {
                    lstparams.Add(new SqlParameter("@Page", ErrorArea));
                    lstparams.Add(new SqlParameter("@UserName", Username));
                    lstparams.Add(new SqlParameter("@Message", ex.Message));
                    lstparams.Add(new SqlParameter("@Source", ex.Source));
                    lstparams.Add(new SqlParameter("@IPADDRESS", Ip));

                    string StackTrace = ex.StackTrace;
                    if (ex.StackTrace.Contains("\r"))
                        StackTrace = ex.StackTrace.Replace('\r', ' ');

                    lstparams.Add(new SqlParameter("@StackTrace", StackTrace));
                    sqlmngr.ExecuteProcedure("SP_ROFRErrorLogEntry", lstparams);
                }
            }

            public DataTable GetDistrictMasterDetails()
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Ptype", 1));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetAllDivisionsMasterDetails()
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Ptype", 4));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetMandalMasterDetails(string district, string mandal)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", (district)));
                lstparams.Add(new SqlParameter("@MANDAL_LGD_CODE", mandal));
                lstparams.Add(new SqlParameter("@Ptype", 8));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetMaapingBeatMasterDetails(string district, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", (district)));
                lstparams.Add(new SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new SqlParameter("@Ptype", 9));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetVillageMasterDetails(string district, string mandal, string type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", (district)));
                lstparams.Add(new SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new SqlParameter("@Type", type));
                lstparams.Add(new SqlParameter("@Ptype", 3));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetFillterDivisionsDetails(string district, string mandal, string village, string type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", (district)));
                lstparams.Add(new SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                if (type == "Beat")
                {
                    lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", (village)));
                }
                lstparams.Add(new SqlParameter("@Type", type));
                lstparams.Add(new SqlParameter("@Ptype", 11));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetFillterRangeDetails(string district, string mandal, string village, string division, string type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", (district)));
                lstparams.Add(new SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                if (type == "Beat")
                {
                    lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", (village)));
                }
                lstparams.Add(new SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new SqlParameter("@Type", type));
                lstparams.Add(new SqlParameter("@Ptype", 12));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetFillterBeatDetails(string district, string mandal, string village, string division, string range, string type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", (district)));
                lstparams.Add(new SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new SqlParameter("@FOREST_RANGE_CODE", (range)));
                lstparams.Add(new SqlParameter("@Type", type));
                lstparams.Add(new SqlParameter("@Ptype", 13));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetBeatMasterDetails(string division, string range)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new SqlParameter("@FOREST_RANGE_CODE", (range)));
                lstparams.Add(new SqlParameter("@Ptype", 6));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetForestMasterDetails(string district)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new SqlParameter("@Ptype", 7));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }

            public DataSet GetupperdivisionsMasterDetails(string district, string id, string type, string mandal, string village, string division, string Range)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new SqlParameter("@Id", id == "" ? 0 : Convert.ToInt32(id)));
                lstparams.Add(new SqlParameter("@Type", type));
                if (type == "Beat")
                {
                    lstparams.Add(new SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                    lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", (village)));
                    lstparams.Add(new SqlParameter("@FOREST_DIVISION_CODE", (division)));
                    lstparams.Add(new SqlParameter("@FOREST_RANGE_CODE", (Range)));
                }
                else if (type == "Range")
                {
                    lstparams.Add(new SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                    lstparams.Add(new SqlParameter("@FOREST_DIVISION_CODE", (division)));
                }
                lstparams.Add(new SqlParameter("@Ptype", 10));

                SQLManager sqlmngr = new SQLManager();
                DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("sp_Allmasters", lstparams);
                return result;
            }

            public DataTable GetRevenuemandalMasterDetails(string district, string type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new SqlParameter("@Type", type));

                lstparams.Add(new SqlParameter("@Ptype", 2));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }


            public DataTable Get_Land_Images_Phases_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges, string phasetype)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

               
                if (type == "ALL")
                {
                    if (Itdastart == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }

                }
                if (type == "PHASE-I")
                {
                    if (Itdastart == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                }
                if (type == "PHASE-II")
                {
                    if (Itdastart == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                }

                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "Having")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "IHaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "Nothaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "pdfIHaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));

                }
                else if (type == "pdfIHavingupdate")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
                }

                else if (type == "NothavingMandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));
                }

                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_IMAGES_PHASES_REPORT", lstparams);
                return result;
            }
            public DataTable Get_Dlc_Phase_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges, string phasetype)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();
                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                //farmer with no  land image
                if (type == "ALL")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }

                }
                if (type == "PHASE-I")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                }
                if (type == "PHASE-II")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                }
                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));
                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "Having")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "IHaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "Nothaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }
                else if (type == "Not Having Dlc")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", phasetype));

                }

                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_DLC_PHASES_REPORT", lstparams);
                return result;
            }

            public DataTable Get_Latlongs_Phases_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges, string Phasetype)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();
                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                if (type == "ALL")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));


                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));


                    }

                }
                if (type == "PHASE-I")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));


                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));


                    }
                }
                if (type == "PHASE-II")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));


                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));


                    }
                }
                else if (type == "FMandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", Phasetype));

                }
                else if (type == "FVillage")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", Phasetype));
                }
                else if (type == "Having")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", Phasetype));

                }
                else if (type == "Nothaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", Phasetype));
                }
                //all login excel download
                else if (type == "IDistrict")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 12));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));

                    }

                }
                else if (type == "INDistrict")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 11));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 12));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }

                }
                else if (type == "Download")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));


                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 15));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));

                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 13));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", type));


                    }


                }
                else if (type == "Plots not having latlongs")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PHASE", Phasetype));

                }
                else if (type == "LATLONGS LESSTHAN4")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));
                }

                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LATLONGS_PHASES_REPORT", lstparams);
                return result;
            }

            public DataTable GetRangeMasterDetails(string division)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@FOREST_DIVISION_CODE", division));
                lstparams.Add(new SqlParameter("@Ptype", 5));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Allmasters", lstparams);
                return result;
            }
            public DataTable GetForestRangeMasterDetails(string district)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new SqlParameter("@Ptype", 5));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_masters", lstparams);
                return result;
            }

            public DataTable GetForestBeatMasterDetails(string district)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new SqlParameter("@Ptype", 6));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_masters", lstparams);
                return result;
            }
            public DataTable User_Authentication(string UserName)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@UserName", UserName));
                lstparams.Add(new SqlParameter("@Ptype", 1));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
                return result;
            }
            public DataTable User_Password(string UserName,string password)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@UserName", UserName));
                lstparams.Add(new SqlParameter("@old_password", password));
                lstparams.Add(new SqlParameter("@PTYPE", 5));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
                return result;
            }

            public DataTable Update_Password(string UserName, string password,string newpwd,string encrypt_pwd,string oldpwd)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@UserName", UserName));
                lstparams.Add(new SqlParameter("@old_password", password));
                lstparams.Add(new SqlParameter("@new_password", newpwd));
                lstparams.Add(new SqlParameter("@encript_password", encrypt_pwd));
                lstparams.Add(new SqlParameter("@dec_old_password", oldpwd));
                lstparams.Add(new SqlParameter("@PTYPE", 6));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
                return result;
            }
            public DataTable User_Authentication_update(string UserName,string status,string date)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@UserName", UserName));
                lstparams.Add(new SqlParameter("@Status", status));
                lstparams.Add(new SqlParameter("@Login_date", date));
                lstparams.Add(new SqlParameter("@Ptype", 3));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
                return result;
            }


            public DataTable User_Authentication_logout_update(string UserName, string status, string Logoutdate, string lastlogindate)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@UserName", UserName));
                lstparams.Add(new SqlParameter("@Status", status));
                lstparams.Add(new SqlParameter("@Logout_date", Logoutdate));
                lstparams.Add(new SqlParameter("@Last_Login", lastlogindate));
                lstparams.Add(new SqlParameter("@Ptype", 7));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
                return result;
            }
            public DataTable User_Authentication_captchaupdate(string UserName, string status)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@UserName", UserName));
                lstparams.Add(new SqlParameter("@Status", status));
                lstparams.Add(new SqlParameter("@Ptype", 4));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
                return result;
            }

            public DataTable User_Authentication_pwdupdate(string UserName)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@UserName", UserName));
                lstparams.Add(new SqlParameter("@Ptype", 10));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
                return result;
            }
            public DataTable User_Authenticationlog(string UserName, string Ipaddress, string Status)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@UserName", UserName));
                lstparams.Add(new SqlParameter("@IPADDRESS", Ipaddress));
                lstparams.Add(new SqlParameter("@Status", Status));
                lstparams.Add(new SqlParameter("@Ptype", 2));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_User_Authentication", lstparams);
                return result;
            }

            public DataTable GetRecordsCount(string district, string mandal, string village, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                }
                lstparams.Add(new SqlParameter("@DISTRICT_CODE", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@MANDAL_CODE", (mandal)));
                if (village != "")
                {
                    lstparams.Add(new SqlParameter("@VILLAGE_CODE", (village)));
                    lstparams.Add(new SqlParameter("@Ptype", 3));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@Ptype", 5));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ROFR_Details", lstparams);
                return result;
            }


            public DataTable GetForestRecordsCount(string district, string FD, string FR, string FB, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                }
                lstparams.Add(new SqlParameter("@DISTRICT_CODE", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@ForestDivision", (FD)));
                lstparams.Add(new SqlParameter("@ForestRange", (FR)));
                lstparams.Add(new SqlParameter("@ForestBeat", (FB)));
                lstparams.Add(new SqlParameter("@Ptype", 7));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ROFR_Details", lstparams);
                return result;
            }

            public DataTable GetForestBeneficiariesRecordsCount(string FD, string FR, string FB, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                }
                lstparams.Add(new SqlParameter("@ForestDivision", ((FD))));
                lstparams.Add(new SqlParameter("@ForestRange", ((FR))));
                lstparams.Add(new SqlParameter("@ForestBeat", ((FB))));
                lstparams.Add(new SqlParameter("@Ptype", 2));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_forest_Details", lstparams);
                return result;
            }


            public DataTable GetForestBeneficiariesData(string district, string FD, string FR, string FB, string start, string end, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                }
                lstparams.Add(new SqlParameter("@DISTRICT_CODE", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@ForestDivision", (FD)));
                lstparams.Add(new SqlParameter("@ForestRange", (FR)));
                lstparams.Add(new SqlParameter("@ForestBeat", (FB)));
                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
                lstparams.Add(new SqlParameter("@Ptype", 6));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ROFR_Details", lstparams);
                return result;
            }


            public DataTable GetForestBeneficiariesDetails(string FD, string FR, string FB, string start, string end, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                }
                lstparams.Add(new SqlParameter("@ForestDivision", ((FD))));
                lstparams.Add(new SqlParameter("@ForestRange", ((FR))));
                lstparams.Add(new SqlParameter("@ForestBeat", ((FB))));
                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
                lstparams.Add(new SqlParameter("@Ptype", 1));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_forest_Details", lstparams);
                return result;
            }

            public DataTable GetMeeBeneficiariesDetails(string FD, string FR, string FB, string COMPARTMENT_NO, string PLOT_NO, string AADHAAR_NO, string ROFR_PATTA_NO, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                }
                lstparams.Add(new SqlParameter("@ForestDivision", ((FD))));
                lstparams.Add(new SqlParameter("@ForestRange", ((FR))));
                lstparams.Add(new SqlParameter("@ForestBeat", ((FB))));
                lstparams.Add(new SqlParameter("@COMPARTMENT_NO", ((COMPARTMENT_NO))));
                lstparams.Add(new SqlParameter("@PLOT_NO", (PLOT_NO)));
                lstparams.Add(new SqlParameter("@AADHAAR_NO", (AADHAAR_NO)));
                lstparams.Add(new SqlParameter("@ROFR_PATTA_NO", (ROFR_PATTA_NO)));
                lstparams.Add(new SqlParameter("@Ptype", 3));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_forest_Details", lstparams);
                return result;
            }

            public DataTable GetBeneficiariesData(string district, string mandal, string village, string start, string end, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                }
                lstparams.Add(new SqlParameter("@DISTRICT_CODE", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@MANDAL_CODE", (mandal)));
                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
                if (village != "")
                {
                    lstparams.Add(new SqlParameter("@VILLAGE_CODE", (village)));
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@Ptype", 4));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ROFR_Details", lstparams);
                return result;
            }

            public DataTable GetDistrictdetails(string USERNAME, string filtertype, string district, string mandal)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(USERNAME))
                {
                    a = USERNAME;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (filtertype == "District")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                }
                else if (filtertype == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new SqlParameter("@Ptype", 5));
                }
                else if (filtertype == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new SqlParameter("@Ptype", 6));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }
            public DataTable Getextentlandbenpattadharextent(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", PATTADAAR));
                lstparams.Add(new SqlParameter("@Ptype", 8));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ExtentLandviewonGIS", lstparams);
                return result;
            }

            public DataTable Getextentlandbenpattadhar(string Itda, string district, string mandal, string village, string habitation)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@Ptype", 7));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ExtentLandviewonGIS", lstparams);
                return result;
            }

            public DataTable Getextentlandbenhabitations(string Itda, string district, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@Ptype", 6));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ExtentLandviewonGIS", lstparams);
                return result;
            }

            public DataTable GetextentlandbenvillageDetails(string itda,string district, string mandal, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                else {
                    start ="";
                    ITDANAME = itda;
                }
                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                if (mandal == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 5));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@Ptype", 4));
                }


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ExtentLandviewonGIS", lstparams);
                return result;
            }

            public DataSet GetDataMasterDetails(string ITDANAME, string Director)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();
                if (Director == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", "ALL"));
                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME != "" ? "" : "ALL"));
                }
                SQLManager sqlmngr = new SQLManager();
                DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("sp_ROFR_Master", lstparams);
                return result;
            }

            public DataSet GetBeneficiaryDetailsAnalysis(string district, string username)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataSet result = new DataSet();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                    result = sqlmngr.ExecuteProcedureReturnDataSet("Dtwbeneficary_count", lstparams);
                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                    result = sqlmngr.ExecuteProcedureReturnDataSet("Itdabeneficary_count", lstparams);
                }
                else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                {
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                    result = sqlmngr.ExecuteProcedureReturnDataSet("beneficary_count", lstparams);
                }


                return result;
            }

            public DataTable GetDistWiseBeneficiaryMasterCount(string type, string itda,string district,string mandal,string village,string username,string userprevileges)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                        
                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                    }
                   
                    }
                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (type == "VDetails")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                }

                result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficary_Master_Count", lstparams);
                return result;
            }

            public DataTable GetRythuBharosaStatus(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@itda_name", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 3));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@itda_name", ITDANAME));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 4));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 2));

                    }

                }
                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 5));
                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 6));
                }
                else if (type == "Psuccess")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@itda_name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 7));
                }
                else if (type == "Prejected")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@itda_name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@district", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@p_type", 8));
                }
                result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments", lstparams);
                return result;
            }

            public DataTable GetRythuBharosaStatus_May20(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 2));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", ITDANAME));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 3));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 1));

                    }

                }
                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 4));
                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 5));
                }
                else if (type == "Psuccess")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 6));
                }
                else if (type == "Pending")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 7));
                }
                else if (type == "Prejected")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 9));
                }
                result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments_May2020", lstparams);
                return result;
            }

            public DataTable GetRythuBharosaStatus_Oct20(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 11));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", ITDANAME));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 12));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 10));

                    }

                }
                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 13));
                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 5));
                }
                else if (type == "Eligible")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 14));
                }
                else if (type == "NotEligible")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 15));
                }
                else if (type == "Prejected")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 9));
                }
                result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments_May2020", lstparams);
                return result;
            }
            public DataTable GetFarmerImagesReport(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {



                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {
                       
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {
                       
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", ITDANAME));
                       lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                   
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                    }

                }
                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (type == "VDetails")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                }
                else if (type == "VNDetails")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                }
                else if (type == "AIDetails")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                }
                else if (type == "AINDetails")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }
                //farmer witn no image
                else if (type == "FDistrict")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 11));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 12));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));

                    }

                }
                else if (type == "FMandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 13));
                }
                else if (type == "FVillage")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));
                }
                else if (type == "Having")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));
                }
                else if (type == "Nothaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 16));
                }
                //all login excel download
                else if (type == "IDistrict")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 21));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 19));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 17));

                    }

                }
                else if (type == "INDistrict")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 22));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 20));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));

                    }

                }
                else if (type == "FARMERS")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 23));
                }
                else if (type == "IMAGES UPLOADED")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 24));
                }
                else if (type == "IMAGES NOT UPLOADED")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 25));
                }
                else if (type == "Plots not having latlongs")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 17));
                }
                result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Beneficary_Images_report", lstparams);
                return result;
            }
           
            public DataTable Get_Land_Images_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {



                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
               
                //farmer with no  land image
                 if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                    }

                }
                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));

                 

                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (type == "Having")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                }
                else if (type == "IHaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                }
                else if (type == "Nothaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                }
                else if (type == "pdfIHaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }
                else if (type == "pdfIHavingupdate")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
                }

               else if (type == "NothavingMandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
                }

                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_IMAGE_REPORT", lstparams);
                return result;
            }
          
            public DataTable Get_Land_Status_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {



                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                 {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (type == "Mandal")
                {
                    //if (Itdastart == "DTW")
                    //{

                    //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 12));

                    //}
                    //else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    //{

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
                    //}
                    //else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    //{
                    //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    //    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));

                    //}

                }
                if (type == "PMandal")
                {
                   

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 27));
                  
                }
                if (type == "Benificiary")
                {



                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 19));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 23));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                    }

                }
                if (type == "PHASE1")
                {




                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 20));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 24));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 16));

                    }

                }
                if (type == "PHASE2")
                {



                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 21));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 25));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 17));

                    }



                }

                if (type == "PHASESBOTH")
                {



                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 22));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 26));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));

                    }

                }

                if (type == "Mandalben")
                {


                    
                  
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 28));

                }
                if (type == "Mandalphase1")
                {




                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 29));

                }
                if (type == "Mandalphase2")
                {




                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 30));

                }
                if (type == "Mandalbothphase")
                {




                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 31));

                }
                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
                return result;
            }
            public DataTable Get_Land_Invalid_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {



                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                //farmer with no  land image
                if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                    }

                }
                else if (type == "Duplicate")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                }
                else if (type == "Invalid")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (type == "Father")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                }
                else if (type == "Location")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                }
                else if (type == "Land")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                }
                else if (type == ">10")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }
                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_INVALID_DATA_REPORT", lstparams);
                return result;
            }
            public DataTable Get_Dlc_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {



                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                //farmer with no  land image
                if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE",6));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));

                    }

                }
                else if (type == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                }
                else if (type == "Village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                }
                else if (type == "Having")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));
                }
                else if (type == "IHaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }
                else if (type == "Nothaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
                }
                else if (type == "Not Having Dlc")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 12));
                }

                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_DLC_UPLOAD", lstparams);
                return result;
            }
            public DataTable Get_Latlongs_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {



                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                             
                if (type == "FDistrict")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                    }

                }
                else if (type == "FMandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                }
                else if (type == "FVillage")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                }
                else if (type == "Having")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                }
                else if (type == "Nothaving")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                }
                //all login excel download
                else if (type == "IDistrict")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 12));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));

                    }

                }
                else if (type == "INDistrict")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 11));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 13));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));

                    }

                }
                else if (type == "Download")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 16));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));

                    }
                

                }
                else if (type == "Plots not having latlongs")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 17));
                }
                else if (type == "LATLONGS LESSTHAN4")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Itda_Name", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));
                }

                result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Latlongs_Report_Excel", lstparams);
                return result;
            }
            public DataTable GetMandatoryFieldsAnalysis(string type, string userprevileges,string username)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
               
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if(Itdastart!="DTW")
                {
                if (userprevileges== "ALL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", userprevileges));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                    
                }
                else 
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE",userprevileges));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                    
                }
                }
                else if(Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", "Plain Areas"));
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT",ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                }


                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ABSTRACT_REPORTS", lstparams);
                return result;
            }
            public DataTable GetAdharDetails(string itda, string userprevileges, string username)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                if (itda != null)
                { 
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));

                }
                
                else if(itda==null)

                {
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                }
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ITDA_HEALTH", lstparams);
                return result;
            }
            public DataTable GetAdharData(string start, string end)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();

                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ITDA_HEALTH", lstparams);
                return result;
            }
            public DataTable GetAdharUpdate(adhar_detials aobj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@AADHAR_SURVEY_STATUS", aobj.adharstatus));
                lstparams.Add(new SqlParameter("@Aadhaar_NO", aobj.adharno));
                lstparams.Add(new SqlParameter("@AADHAR_SURVEY_NAME", aobj.adharname));
                lstparams.Add(new SqlParameter("@AADHAR_SURVEY_CAREOF", aobj.careof));
                lstparams.Add(new SqlParameter("@State_Code", aobj.statecode));
                lstparams.Add(new SqlParameter("@District_Code", aobj.distcode));
                lstparams.Add(new SqlParameter("@District", aobj.distname));
                lstparams.Add(new SqlParameter("@Mandal_Code", aobj.mandalcode));
                lstparams.Add(new SqlParameter("@Mandal", aobj.mandal));
                lstparams.Add(new SqlParameter("@Village_Code", aobj.vcode));
                lstparams.Add(new SqlParameter("@Village", aobj.vname));
                lstparams.Add(new SqlParameter("@Street", aobj.street));
                lstparams.Add(new SqlParameter("@Pincode", aobj.pincode));
                lstparams.Add(new SqlParameter("@DateofBirth", aobj.dob));
                lstparams.Add(new SqlParameter("@Gender", aobj.gender));
                lstparams.Add(new SqlParameter("@Phoneno", aobj.phoneno));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                    DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ITDA_HEALTH", lstparams);
                    return result;
                



            }

            public DataTable GetAdharcount()
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
             
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
               
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ITDA_HEALTH", lstparams);
                return result;
            }


            public DataTable GetNonMandatoryFieldsAnalysis(string type, string userprevileges, string username)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;

                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (Itdastart != "DTW")
                {
                    if (userprevileges == "ALL")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", userprevileges));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                    }
                    else
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", userprevileges));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                    }
                }
                else if (Itdastart == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@USER_PRIVILEGE", "Plain Areas"));
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                }


                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ABSTRACT_REPORTS", lstparams);
                return result;
            }

            public DataTable GetMasterDetailsAnalysis()
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("master_count", lstparams);
                return result;
            }

            public DataTable GetForestBeneficiaryDetailscountValidate(string district, string ITDA, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA", (ITDA)));
                lstparams.Add(new SqlParameter("@District_Code", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
                lstparams.Add(new SqlParameter("@Village_Code", village));
                if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 2));
                }
                else if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 8));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 10));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 12));
                }




                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Beneficiary_Details_Validate", lstparams);
                return result;
            }

            public DataTable GetcropForestBeneficiaryDetailscountValidate(string district, string ITDA, string mandal)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA", (ITDA)));
                lstparams.Add(new SqlParameter("@District_Code", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
               
                if (district != "" && mandal != "" && mandal != "NULL" )
                {
                    lstparams.Add(new SqlParameter("@Ptype", 2));
                }
                else if (district != "" && mandal != "" && mandal != "NULL" )
                {
                    lstparams.Add(new SqlParameter("@Ptype", 8));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" )
                {
                    lstparams.Add(new SqlParameter("@Ptype", 10));
                }
                else if (district != "" && mandal != "" && mandal == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 12));
                }
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Beneficiary_Details_cropValidate", lstparams);
                return result;
            }

            public DataTable GetadharForestBeneficiaryDetailscountValidate(string district, string ITDA, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA", (ITDA)));
                lstparams.Add(new SqlParameter("@District_Code", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
                lstparams.Add(new SqlParameter("@Village_Code", village));
                if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 2));
                }
                else if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 8));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 10));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 12));
                }




                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Beneficiary_Details_AdharValidate", lstparams);
                return result;
            }
            public DataTable GetadharForestBeneficiaryDetailsValidate(string district, string start, string end, string Itda, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA", (Itda)));
                lstparams.Add(new SqlParameter("@District_Code", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
                lstparams.Add(new SqlParameter("@Village_Code", village));
                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
                if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }
                else if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 7));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 9));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 11));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Beneficiary_Details_AdharValidate", lstparams);
                return result;
            }
            public DataTable GetForestBeneficiaryDetailsValidate(string district, string start, string end, string Itda, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA", (Itda)));
                lstparams.Add(new SqlParameter("@District_Code", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
                lstparams.Add(new SqlParameter("@Village_Code", village));
                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
                if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }
                else if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 7));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 9));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 11));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Beneficiary_Details_Validate", lstparams);
                return result;
            }


            public DataTable GetcropForestBeneficiaryDetailsValidate(string district, string start, string end, string Itda, string mandal)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA", (Itda)));
                lstparams.Add(new SqlParameter("@District_Code", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
               
                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
                if (district != "" && mandal != "" && mandal != "NULL" )
                {
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }
                else if (district != "" && mandal != "" && mandal != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 7));
                }
                else if (district != "" && mandal != "" && mandal == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 9));
                }
                else if (district != "" && mandal != "" && mandal == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 11));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Beneficiary_Details_cropValidate", lstparams);
                return result;
            }

            public DataTable GetForestBeneficiaryDetailscountapproval(string district, string Director, string Itda, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                lstparams.Add(new SqlParameter("@District_Code", (district)));
                if (Director == "DIRECTOR")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 6));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA", Itda));
                    lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
                    lstparams.Add(new SqlParameter("@Village_Code", village));
                    lstparams.Add(new SqlParameter("@Ptype", 4));
                }



                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Beneficiary_Details_Validate", lstparams);
                return result;
            }

            public DataTable GetForestBeneficiaryDetailsapproval(string district, string start, string end, string Director, string Itda, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                lstparams.Add(new SqlParameter("@District_Code", (district)));
                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));
                if (Director == "DIRECTOR")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 5));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@ITDA", Itda));
                    lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
                    lstparams.Add(new SqlParameter("@Village_Code", village));
                    lstparams.Add(new SqlParameter("@Ptype", 3));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_Beneficiary_Details_Validate", lstparams);
                return result;
            }

            public void UpdateValidateBeneficiaryDetails(BeneficiaryDetails BeneficiaryDetailsobj, string Username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@BeneficiaryDetails", BeneficiaryDetailsobj.UpdateForestMasterDetails));
                lstparams.Add(new SqlParameter("@UserName", Username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 1));
                sqlmngr.ExecuteProcedure("sp_Validate_Beneficiary_Details_Update", lstparams);
            }

            public void UpdateRtgsFormatData(BeneficiaryDetails BeneficiaryDetailsobj, string Username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@BeneficiaryDetails", BeneficiaryDetailsobj.UpdateForestMasterDetails));
                lstparams.Add(new SqlParameter("@UserName", Username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                sqlmngr.ExecuteProcedure("Proc_Rtgs_Data", lstparams);
            }

            public void UpdateforestmasterDetails(BeneficiaryDetails BeneficiaryDetailsobj, string level)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ForestMasterDetails", BeneficiaryDetailsobj.UpdateForestMasterDetails));
                if (level == "FD")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 1));
                }
                else if (level == "FR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 2));
                }
                else if (level == "FB")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 3));
                }
                sqlmngr.ExecuteProcedure("sp_Forest_Master_Details_Update", lstparams);
            }

            public DataTable AddBeneficiary(addbeneficiary_details addbeneficiaryobj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA", addbeneficiaryobj.Itda));
                lstparams.Add(new SqlParameter("@ITDA_CODE", addbeneficiaryobj.Itdacode));
                lstparams.Add(new SqlParameter("@District_Code", addbeneficiaryobj.District_Code));
                lstparams.Add(new SqlParameter("@District", addbeneficiaryobj.District));
                lstparams.Add(new SqlParameter("@Mandal_Code", addbeneficiaryobj.Mandal_Code));

                lstparams.Add(new SqlParameter("@Mandal", addbeneficiaryobj.Mandal));
                lstparams.Add(new SqlParameter("@Grama_Panchayat_Code", addbeneficiaryobj.Grama_Panchayat_Code));
                lstparams.Add(new SqlParameter("@Gram_Panchayat", addbeneficiaryobj.Gram_Panchayat));
                lstparams.Add(new SqlParameter("@REV_Village", addbeneficiaryobj.rev_village));
                lstparams.Add(new SqlParameter("@Village_Revcode", addbeneficiaryobj.rev_village_code));
                lstparams.Add(new SqlParameter("@Village_Code", addbeneficiaryobj.Village_Code));
                lstparams.Add(new SqlParameter("@Village", addbeneficiaryobj.Village));
                lstparams.Add(new SqlParameter("@HabitationCode", addbeneficiaryobj.HabitationCode));

                lstparams.Add(new SqlParameter("@HABITATION", addbeneficiaryobj.Habitation));

                lstparams.Add(new SqlParameter("@Forest_DivisionCode", addbeneficiaryobj.Forest_DivisionCode));
                lstparams.Add(new SqlParameter("@Forest_Division", addbeneficiaryobj.Forest_Division));
                lstparams.Add(new SqlParameter("@Forest_RangeCode", addbeneficiaryobj.Forest_RangeCode));
                lstparams.Add(new SqlParameter("@Forest_Range", addbeneficiaryobj.Forest_Range));
                lstparams.Add(new SqlParameter("@Forest_BeatCode", addbeneficiaryobj.Forest_BeatCode));
                lstparams.Add(new SqlParameter("@Forest_Beat", addbeneficiaryobj.Forest_Beat));

                lstparams.Add(new SqlParameter("@FOREST_BLOCK", addbeneficiaryobj.Forest_Block));
                lstparams.Add(new SqlParameter("@COMPARTMENT_NO", addbeneficiaryobj.Compartment_No));

                lstparams.Add(new SqlParameter("@PLOT_NO", addbeneficiaryobj.Plot_No));
                lstparams.Add(new SqlParameter("@EXTENT_PLOT_AREA", addbeneficiaryobj.ExtentPlotArea));
                lstparams.Add(new SqlParameter("@EXTENT_UNCULTIVABLE_LAND", addbeneficiaryobj.Uncultivable_Land));

                lstparams.Add(new SqlParameter("@EXTENT_CULTIVABLE_LAND", addbeneficiaryobj.Cultivable_Land));
                lstparams.Add(new SqlParameter("@PATTA_INAM_GOVT", addbeneficiaryobj.PATTA_INAMGOVT));
                lstparams.Add(new SqlParameter("@WATER_TAX", addbeneficiaryobj.Water_Tax));
                lstparams.Add(new SqlParameter("@DRY_ID_ONE_CROP_TWO_CROP", addbeneficiaryobj.DRYID_ONECROP_TWO_CROP));
                lstparams.Add(new SqlParameter("@WATER_SOURCE ", addbeneficiaryobj.WATER_SOURCE));

                lstparams.Add(new SqlParameter("@EXTENT_IRRIGATED", addbeneficiaryobj.EXTENT_IRRIGATED));
                lstparams.Add(new SqlParameter("@ROFR_PATTA_NO", addbeneficiaryobj.ROFR_PATTANO));

                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", addbeneficiaryobj.ROFR_PATTADAAR));
                lstparams.Add(new SqlParameter("@CULTIVATOR_NAME_", addbeneficiaryobj.CULTIVATOR_NAME));
                lstparams.Add(new SqlParameter("@EXTENT_UNDER_CULTIVATOR", addbeneficiaryobj.EXTENT_UNDER_CULTIVATOR));
                lstparams.Add(new SqlParameter("@HOLDING_NATURE", addbeneficiaryobj.HOLDING_NATURE));
                lstparams.Add(new SqlParameter("@LAND_UTILIZATION_TYPE_CODE", addbeneficiaryobj.TYPE_CODE));

                lstparams.Add(new SqlParameter("@LAND_UTILAZATION_EXTENT", addbeneficiaryobj.EXTENT));
                lstparams.Add(new SqlParameter("@LAND_UTILIZATION_NET_SOWN_AREA", addbeneficiaryobj.NET_SOWN_AREA));
                lstparams.Add(new SqlParameter("@KHARIFF_RABI", addbeneficiaryobj.KHARIFF_RABI));
                lstparams.Add(new SqlParameter("@MONTH_OF_CULTIVATION", addbeneficiaryobj.MONTH_OF_CULTIVATION));
                lstparams.Add(new SqlParameter("@CROP", addbeneficiaryobj.CROP));
                lstparams.Add(new SqlParameter("@EXTENT_SINGLE", addbeneficiaryobj.SINGLE));
                lstparams.Add(new SqlParameter("@EXTENT_MIXED", addbeneficiaryobj.MIXED));
                lstparams.Add(new SqlParameter("@EXTENT_TOTAL", addbeneficiaryobj.TOTAL));
                lstparams.Add(new SqlParameter("@EXTENT_LAND_WATER_SOURCE", addbeneficiaryobj.WATER_SOURCE1));
                lstparams.Add(new SqlParameter("@EXTENT_LAND_CROP_1", addbeneficiaryobj.FIRST_CROP));
                lstparams.Add(new SqlParameter("@EXTENT_LAND_CROP_2_3", addbeneficiaryobj.SECOND_THIRD_CROP));
                lstparams.Add(new SqlParameter("@CROP_YIELD", addbeneficiaryobj.CROP_YIELD));
                lstparams.Add(new SqlParameter("@VRO_RI_REMARKS", addbeneficiaryobj.VRO_RI_REMARKS));
                lstparams.Add(new SqlParameter("@TAHSILDAR_REMARKS", addbeneficiaryobj.TAHSILDAR_REMARKS));
                lstparams.Add(new SqlParameter("@REMARKS", addbeneficiaryobj.REMARKS));
                lstparams.Add(new SqlParameter("@AADHAR_NO", addbeneficiaryobj.Aadhaar_NO));
                lstparams.Add(new SqlParameter("@Dlc_date", addbeneficiaryobj.dlcdate));
                lstparams.Add(new SqlParameter("@Dlc", addbeneficiaryobj.Dlc));
                lstparams.Add(new SqlParameter("@Image1", addbeneficiaryobj.Image));
                lstparams.Add(new SqlParameter("@Imagepath", addbeneficiaryobj.Imagepath));
                lstparams.Add(new SqlParameter("@Landclassification", addbeneficiaryobj.landclassifcation));
                lstparams.Add(new SqlParameter("@Dlcpath", addbeneficiaryobj.Dlcpath));
                lstparams.Add(new SqlParameter("@BankAccountNo", addbeneficiaryobj.bankaccountno));
                lstparams.Add(new SqlParameter("@IfscCode", addbeneficiaryobj.ifsccode));
                lstparams.Add(new SqlParameter("@BankName", addbeneficiaryobj.bankname));
                lstparams.Add(new SqlParameter("@Father_Name", addbeneficiaryobj.fathername));
                lstparams.Add(new SqlParameter("@SUB_CASTE", addbeneficiaryobj.sub_caste));
                lstparams.Add(new SqlParameter("@aadhar_status", addbeneficiaryobj.aadhaarstatus));
                lstparams.Add(new SqlParameter("@Phase", addbeneficiaryobj.Phase_Name));
                lstparams.Add(new SqlParameter("@Ipaddress", addbeneficiaryobj.Ipaddress));
                lstparams.Add(new SqlParameter("@UserName", addbeneficiaryobj.UserName));
                lstparams.Add(new SqlParameter("@Farm_uniqueid", addbeneficiaryobj.ApUniqueID));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 1));

            

                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
                return result;
            }

            public DataTable File_retrieve(string Id)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Id", Id));
                lstparams.Add(new SqlParameter("@Ptype", 1));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_file_retrieve", lstparams);
                return result;
            }
            public DataTable pdfFile_retrieve(string Id)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Id", Id));
                lstparams.Add(new SqlParameter("@Ptype", 2));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_file_retrieve", lstparams);
                return result;
            }

            public void AddBeneficiaryUploadFiles(addbeneficiary_details addbeneficiaryobj, string byteString, string imgString, string username, string ipaddress)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Id", (addbeneficiaryobj.id == "" ? "0" : addbeneficiaryobj.id)));
                lstparams.Add(new SqlParameter("@Dlcid", (addbeneficiaryobj.dlcid == "" ? "0" : addbeneficiaryobj.dlcid)));
                if (byteString != "")
                {
                    lstparams.Add(new SqlParameter("@Dlc", addbeneficiaryobj.Dlc));
                    lstparams.Add(new SqlParameter("@Dlcpath", addbeneficiaryobj.Dlcpath));
                }
                if (imgString != "")
                {
                    lstparams.Add(new SqlParameter("@Image1", addbeneficiaryobj.Image));
                    lstparams.Add(new SqlParameter("@Imagepath", addbeneficiaryobj.Imagepath));
                }
                lstparams.Add(new SqlParameter("@Ipaddress", ipaddress));
                lstparams.Add(new SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 2));
                sqlmngr.ExecuteProcedure("sp_add_details", lstparams);
            }

            public DataTable GetDivisionMaster()
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Ptype", 1));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_masters", lstparams);
                return result;
            }

            public void InsertForestDivision(string district, string FDcode, string FDname, string Ipaddress, string username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", FDcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_NAME", FDname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ipaddress", Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 5));
                sqlmngr.ExecuteProcedure("SP_ADD_DIV_MASTERS", lstparams);
            }
            public void UpdateForestDivision(string Id, string district, string FDcode, string FDname, string Ipaddress, string username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", FDcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_NAME", FDname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ipaddress", Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 3));
                sqlmngr.ExecuteProcedure("SP_ADD_DIV_MASTERS", lstparams);
            }

            public void DeleteForestDivision(string Id, string district)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 6));
                sqlmngr.ExecuteProcedure("SP_ADD_DIV_MASTERS", lstparams);
            }

            public void InsertForestBeat(string district, string mandal, string village, string division, string range, string Fbcode, string Fbname, string Ipaddress, string username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", (range)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT_CODE", Fbcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT_NAME", Fbname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ipaddress", Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 2));
                sqlmngr.ExecuteProcedure("SP_ADDBeat_MASTERS", lstparams);
            }
            public void UpdateForestBeat(string Id, string district, string mandal, string village, string division, string range, string Fbcode, string Fbname, string Ipaddress, string username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", (range)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT_CODE", Fbcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT_NAME", Fbname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ipaddress", Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 1));
                sqlmngr.ExecuteProcedure("SP_ADDBeat_MASTERS", lstparams);
            }

            public void DeleteForestBeat(string Id, string district, string mandal, string village, string division, string range)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", (range)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 3));
                sqlmngr.ExecuteProcedure("SP_ADDBeat_MASTERS", lstparams);
            }


            public void InsertForestRange(string district, string mandal, string division, string Frcode, string Frname, string Ipaddress, string username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", Frcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_NAME", Frname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ipaddress", Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 2));
                sqlmngr.ExecuteProcedure("SP_ADDRange_MASTERS", lstparams);
            }


            public void UpdateForestRange(string Id, string district, string mandal, string division, string Frcode, string Frname, string Ipaddress, string username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", Frcode));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_NAME", Frname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ipaddress", Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 1));
                sqlmngr.ExecuteProcedure("SP_ADDRange_MASTERS", lstparams);
            }

            public void DeleteForestRange(string Id, string district, string mandal, string division)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT_LGD_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL_LGD_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", (division)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 3));
                sqlmngr.ExecuteProcedure("SP_ADDRange_MASTERS", lstparams);
            }

            public DataTable GetDistrictMasterAnalysis(string district, string mandal, string division, string Type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                if (district != "")
                {

                    if (mandal == "4")
                    {
                        if (Type == "")
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", Type));
                            lstparams.Add(new SqlParameter("@Ptype", 2));
                        }
                        else
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", Type));
                            lstparams.Add(new SqlParameter("@Ptype", 2));
                        }
                    }
                    else if (division == "5")
                    {
                        if (Type == "")
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", Type));
                            lstparams.Add(new SqlParameter("@Ptype", 4));
                        }
                        else
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", Type));
                            lstparams.Add(new SqlParameter("@Ptype", 4));
                        }
                    }
                }
                else
                {
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
                return result;
            }

            public DataTable GetMandalMasterAnalysis(string district, string mandal, string end, string Type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                if (district != "")
                {

                    if (end == "7")
                    {
                        if (Type == "")
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", Type));
                            lstparams.Add(new SqlParameter("@Ptype", 3));
                        }
                        else
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", Type));
                            lstparams.Add(new SqlParameter("@Ptype", 3));
                        }
                    }
                    else if (end == "8")
                    {
                        if (Type == "")
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                            //lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", Type));
                            lstparams.Add(new SqlParameter("@Ptype", 6));
                        }
                        else
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@TYPE", Type));
                            lstparams.Add(new SqlParameter("@Ptype", 4));
                        }
                    }
                }
                else
                {
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
                return result;
            }


            public DataTable GetForestDivisionAnalysis(string district, string division, string end, string Type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                if (district != "")
                {
                    if (end == "6")
                    {
                        if (Type == "")
                        {
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                            lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                            lstparams.Add(new SqlParameter("@Ptype", 7));
                        }
                    }
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
                return result;
            }

            public DataTable GetForestRangeAnalysis(string district, string division, string end, string Type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                if (end == "6")
                {
                    if (Type == "")
                    {
                        lstparams.Add(new SqlParameter("@Ptype", 8));
                    }
                }


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
                return result;
            }

            public DataTable GetAllBeats()
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Ptype", 11));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
                return result;
            }

            public DataTable GetvillageBeats(string district, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@Ptype", 9));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
                return result;
            }


            public DataTable GetrangeBeats(string district, string mandal, string division, string range)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", range));
                lstparams.Add(new SqlParameter("@Ptype", 10));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
                return result;
            }


            public DataTable GetHabitations(string district, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@Ptype", 3));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }

            public DataTable GetHabitationsforest(string district, string mandal, string village, string habitation)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", village));
                //lstparams.Add(new System.Data.SqlClient.SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@Ptype", 3));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }


            public DataTable Getbasedonvillagestartandend(string start, string end)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Start_range", start));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@End_range", end));
                lstparams.Add(new SqlParameter("@Ptype", 5));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);
                return result;
            }

            public DataSet GetDataMasterDetails()
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();
                lstparams.Add(new SqlParameter("@Ptype", 1));
                SQLManager sqlmngr = new SQLManager();
                DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("Habitation_Master", lstparams);
                return result;
            }

            public DataTable GetbenmandalDetails(string district, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                    lstparams.Add(new SqlParameter("@Ptype", 1));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
                return result;
            }

            public DataTable GetbenitdaDetails(string district, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype", 4));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype", 4));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new SqlParameter("@itda", (district)));
                    lstparams.Add(new SqlParameter("@Ptype", 4));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
                return result;
            }

            public DataTable GetbenvillageDetails(string district, string mandal, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                }
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                if (mandal == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 3));
                }
                else
                {
                    lstparams.Add(new SqlParameter("@Ptype", 2));
                }


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
                return result;
            }

            public void HabitationDelete(string Id, string district, string mandal, string village)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 7));
                sqlmngr.ExecuteProcedure("Habitation_Master", lstparams);
            }
            public DataSet UniqueHabitation(string id, string district, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                lstparams.Add(new SqlParameter("@Id", id == "" ? 0 : Convert.ToInt32(id)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", (mandal)));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new SqlParameter("@Ptype", 8));

                SQLManager sqlmngr = new SQLManager();
                DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("Habitation_Master", lstparams);
                return result;
            }


            public DataTable GetDLCcount(string ITDA,string district, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA_NAME", (ITDA)));
                 lstparams.Add(new SqlParameter("@District_Code", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
                lstparams.Add(new SqlParameter("@Village_Code", village));
                if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 5));
                }
                else if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 6));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village != "NULL")
                {
                  lstparams.Add(new SqlParameter("@Ptype", 7));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 8));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_dlc_report", lstparams);
                return result;
            }

            public DataTable GetDlcBeneficiaryDetails(string ITDA, string district, string mandal, string village,string Habitation)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA_NAME", (ITDA)));
                lstparams.Add(new SqlParameter("@District_Code", Convert.ToInt32(district)));
                lstparams.Add(new SqlParameter("@Mandal_Code", mandal));
                lstparams.Add(new SqlParameter("@Village_Code", village));
                lstparams.Add(new SqlParameter("@Habitation", Habitation));
                if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 9));
                }
                else if (district != "" && mandal != "" && mandal != "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 11));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village != "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 12));
                }
                else if (district != "" && mandal != "" && mandal == "NULL" && village != "" && village == "NULL")
                {
                    lstparams.Add(new SqlParameter("@Ptype",13));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_dlc_report", lstparams);
                return result;
            }
            public DataTable GetdlcmandalDetails(string district, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@District_Code", (district)));
                    lstparams.Add(new SqlParameter("@PTYPE", 10));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@District_Code", (district)));
                    lstparams.Add(new SqlParameter("@PTYPE", 10));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new SqlParameter("@District_Code", (district)));
                    lstparams.Add(new SqlParameter("@PTYPE", 10));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_dlc_report", lstparams);
                return result;
            }

            public DataSet Getdashboard()
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();
                lstparams.Add(new SqlParameter("@PTYPE", 1));
                SQLManager sqlmngr = new SQLManager();
                DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("sp_dashboard_count", lstparams);
                return result;
            }
            public DataSet validaadhar(string itda, string district)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@District",district ));
                lstparams.Add(new SqlParameter("@PTYPE", 1));
                SQLManager sqlmngr = new SQLManager();
                DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("sp_aadhar_status", lstparams);
                return result;
            }

            public void UpdateAadhaar_status(string id, string status)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Id", Convert.ToInt32(id)));
                lstparams.Add(new SqlParameter("@status", status));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                sqlmngr.ExecuteProcedure("sp_aadhar_status", lstparams);
            }

            public DataSet GetnewDashboard()
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("Proc_Dashboard_Counts", lstparams);
               
                return result;
            }
            public DataSet Checkadhar(string USERNAME, string adhar)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(USERNAME))
                {
                    a = USERNAME;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                lstparams.Add(new SqlParameter("@AADHAR_NO", adhar));
                lstparams.Add(new SqlParameter("@CASTE", null));
                lstparams.Add(new SqlParameter("@DOB", null));
                lstparams.Add(new SqlParameter("@GENDER", null));
                lstparams.Add(new SqlParameter("@HOME_ADRESS", null));
                lstparams.Add(new SqlParameter("@MOBILE_NO", null));
                lstparams.Add(new SqlParameter("@PTYPE", 4));
                SQLManager sqlmngr = new SQLManager();
                DataSet result = sqlmngr.ExecuteProcedureReturnDataSet("sp_add_details", lstparams);
                return result;
            }
            public DataTable AddBeneficiaryMaster(addbeneficiary_details addbeneficiaryobj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA", addbeneficiaryobj.Itda));
                lstparams.Add(new SqlParameter("@ITDA_CODE ", addbeneficiaryobj.Itdacode));
                lstparams.Add(new SqlParameter("@District_Code", addbeneficiaryobj.District_Code));
                lstparams.Add(new SqlParameter("@District", addbeneficiaryobj.District));
                lstparams.Add(new SqlParameter("@Mandal_Code", addbeneficiaryobj.Mandal_Code));
                lstparams.Add(new SqlParameter("@Mandal", addbeneficiaryobj.Mandal));
                
                lstparams.Add(new SqlParameter("@Grama_Panchayat_Code", addbeneficiaryobj.panchayatcode));
                lstparams.Add(new SqlParameter("@Gram_Panchayat", addbeneficiaryobj.panchayat));

                lstparams.Add(new SqlParameter("@Village_Revcode", addbeneficiaryobj.rev_village_code));
                lstparams.Add(new SqlParameter("@REV_Village", addbeneficiaryobj.rev_village));

                lstparams.Add(new SqlParameter("@Village_Code", addbeneficiaryobj.Village_Code));
                lstparams.Add(new SqlParameter("@Village", addbeneficiaryobj.Village));
                lstparams.Add(new SqlParameter("@HabitationCode", addbeneficiaryobj.HabitationCode));

                lstparams.Add(new SqlParameter("@HABITATION", addbeneficiaryobj.Habitation));




                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", addbeneficiaryobj.ROFR_PATTADAAR));



                lstparams.Add(new SqlParameter("@AADHAR_NO", addbeneficiaryobj.Aadhaar_NO));
                lstparams.Add(new SqlParameter("@BankAccountNo", addbeneficiaryobj.bankaccountno));
                lstparams.Add(new SqlParameter("@IfscCode", addbeneficiaryobj.ifsccode));
                lstparams.Add(new SqlParameter("@BankName", addbeneficiaryobj.bankname));
                lstparams.Add(new SqlParameter("@Father_Name", addbeneficiaryobj.fathername));

                lstparams.Add(new SqlParameter("@POaccount", addbeneficiaryobj.postofficeaccount));


                lstparams.Add(new SqlParameter("@POnumber", addbeneficiaryobj.ponumber));
                lstparams.Add(new SqlParameter("@POname", addbeneficiaryobj.poname));
                lstparams.Add(new SqlParameter("@Sub_Caste", addbeneficiaryobj.sub_caste));



                lstparams.Add(new SqlParameter("@Image1", addbeneficiaryobj.Image));
                lstparams.Add(new SqlParameter("@Imagepath", addbeneficiaryobj.Imagepath));


                lstparams.Add(new SqlParameter("@Ipaddress", addbeneficiaryobj.Ipaddress));
                lstparams.Add(new SqlParameter("@UserName", addbeneficiaryobj.UserName));


                lstparams.Add(new SqlParameter("@CASTE", addbeneficiaryobj.caste));



                lstparams.Add(new SqlParameter("@DOB", addbeneficiaryobj.dob));
                lstparams.Add(new SqlParameter("@GENDER", addbeneficiaryobj.gender));


                lstparams.Add(new SqlParameter("@HOME_ADRESS", addbeneficiaryobj.hAddress));
                lstparams.Add(new SqlParameter("@MOBILE_NO", addbeneficiaryobj.Mobileno));


                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));



                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
                return result;


            }
            public DataTable Check_newadhaar(string username, string adhar, string newadhar)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

               

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@AADHAR_NO", adhar));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@aadhar_status", newadhar));
                    lstparams.Add(new SqlParameter("@PTYPE", 16));

              

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
                return result;
            }
            public DataTable GetBeneficiaryMasterAnalysis(string itda, string district, string beneficiary)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                if (beneficiary == "4")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new SqlParameter("@PTYPE", 7));

                }
                else
                {

                    lstparams.Add(new SqlParameter("@PTYPE", 6));


                }


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
                return result;
            }
            public void Update14COLUMNSBeneficiaryDetails(BeneficiaryDetails BeneficiaryDetailsobj, string Username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@BeneficiaryDetails", BeneficiaryDetailsobj.UpdateForestMasterDetails));
                lstparams.Add(new SqlParameter("@UserName", Username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                sqlmngr.ExecuteProcedure("sp_Beneficiary_adhar_update", lstparams);
            }
            public void UpdateCropLoan(BeneficiaryDetails BeneficiaryDetailsobj, string Username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@BeneficiaryDetails", BeneficiaryDetailsobj.UpdateForestMasterDetails));
                lstparams.Add(new SqlParameter("@UserName", Username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                sqlmngr.ExecuteProcedure("PROC_CROP_LOAN", lstparams);
            }

            public DataTable GetMandalwiseDetailsAnalysis(string itda, string district)
            {


                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ABSTRACT_REPORTS", lstparams);
                return result;
            }
            public DataTable land_transfer_regulation(land_transfer_regulation land_transfer_regulation_obj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>(); 
                lstparams.Add(new SqlParameter("@Id", land_transfer_regulation_obj.Id));
                lstparams.Add(new SqlParameter("@village", land_transfer_regulation_obj.village));
              
                lstparams.Add(new SqlParameter("@mandal", land_transfer_regulation_obj.mandal));
                lstparams.Add(new SqlParameter("@ltrp_no", land_transfer_regulation_obj.ltrp_no));
                lstparams.Add(new SqlParameter("@newltrp_date", land_transfer_regulation_obj.ltrp_date));
                lstparams.Add(new SqlParameter("@OLDltrp_date", land_transfer_regulation_obj.OLDltrp_date));
                lstparams.Add(new SqlParameter("@rsno", land_transfer_regulation_obj.rsno));
                lstparams.Add(new SqlParameter("@extent_ac_cts", land_transfer_regulation_obj.extent_ac_cts));

                lstparams.Add(new SqlParameter("@orders_passed_NT", land_transfer_regulation_obj.orders_passed_nt));
                lstparams.Add(new SqlParameter("@orders_passed_tri", land_transfer_regulation_obj.orders_passed_tri));
                lstparams.Add(new SqlParameter("@orders_passed_govt", land_transfer_regulation_obj.orders_passed_govt));

                lstparams.Add(new SqlParameter("@cma_no", land_transfer_regulation_obj.cma_no));
                lstparams.Add(new SqlParameter("@additional_nt", land_transfer_regulation_obj.additional_nt));
                lstparams.Add(new SqlParameter("@additional_tri", land_transfer_regulation_obj.additional_tri));
                lstparams.Add(new SqlParameter("@additional_govt", land_transfer_regulation_obj.additional_govt));
                lstparams.Add(new SqlParameter("@appeal_no", land_transfer_regulation_obj.appeal_no));

                

                lstparams.Add(new SqlParameter("@agent_nt", land_transfer_regulation_obj.agent_nt));
                lstparams.Add(new SqlParameter("@agent_tri", land_transfer_regulation_obj.agent_tri));

                 lstparams.Add(new SqlParameter("@agent_govt", land_transfer_regulation_obj.agent_govt));


                lstparams.Add(new SqlParameter("@rpno", land_transfer_regulation_obj.rpno));
              
                lstparams.Add(new SqlParameter("@govt_nt", land_transfer_regulation_obj.govt_nt));
                lstparams.Add(new SqlParameter("@govt_tri", land_transfer_regulation_obj.govt_tri));



                lstparams.Add(new SqlParameter("@govt_govt", land_transfer_regulation_obj.govt_govt));

                lstparams.Add(new SqlParameter("@wpno", land_transfer_regulation_obj.wpno));
              
                lstparams.Add(new SqlParameter("@high_court_nt", land_transfer_regulation_obj.high_nt));
                lstparams.Add(new SqlParameter("@high_court_tri", land_transfer_regulation_obj.high_court_tri));
                lstparams.Add(new SqlParameter("@high_court_govt", land_transfer_regulation_obj.high_court_govt));

                lstparams.Add(new SqlParameter("@land_already", land_transfer_regulation_obj.land_already));
                lstparams.Add(new SqlParameter("@remarks", land_transfer_regulation_obj.remarks));

                //lstparams.Add(new SqlParameter("@Details_Ac_cts", land_transfer_regulation_obj.Details_Ac_cts));
                //lstparams.Add(new SqlParameter("@Details_Hec_A", land_transfer_regulation_obj.Details_Hec_A));
                lstparams.Add(new SqlParameter("@Rdo_sdc_orders", land_transfer_regulation_obj.Rdo_sdc_orders));

                lstparams.Add(new SqlParameter("@collector_po", land_transfer_regulation_obj.collector_po));
                lstparams.Add(new SqlParameter("@govt_doc", land_transfer_regulation_obj.govt_doc));
                lstparams.Add(new SqlParameter("@high_court_doc", land_transfer_regulation_obj.high_court_doc));

                lstparams.Add(new SqlParameter("@CMADATE_OF_ORDERS", land_transfer_regulation_obj.cmadate));

                lstparams.Add(new SqlParameter("@AppealDATE_OF_ORDERS", land_transfer_regulation_obj.appealdate));
                lstparams.Add(new SqlParameter("@RPDATE_OF_ORDERS", land_transfer_regulation_obj.rpdate));
                lstparams.Add(new SqlParameter("@WPNDATE_OF_ORDERS", land_transfer_regulation_obj.wpdate));
                lstparams.Add(new SqlParameter("@Ipaddress", land_transfer_regulation_obj.Ipaddress));
                lstparams.Add(new SqlParameter("@UserName", land_transfer_regulation_obj.UserName));


                if (land_transfer_regulation_obj.Id == 0)
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                }
              
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_land_transfer_regulation", lstparams);
                return result;
            }


            public DataTable land_transfer_regulation1(land_transfer_regulation land_transfer_regulation_obj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@LTR_ID", land_transfer_regulation_obj.ltrid));
                lstparams.Add(new SqlParameter("@ITDA_NAME", land_transfer_regulation_obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT", land_transfer_regulation_obj.District));
                lstparams.Add(new SqlParameter("@MANDAL", land_transfer_regulation_obj.mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", land_transfer_regulation_obj.village));
                lstparams.Add(new SqlParameter("@HABITATION", land_transfer_regulation_obj.hab));

                lstparams.Add(new SqlParameter("@RS_NO", land_transfer_regulation_obj.rsno));
                lstparams.Add(new SqlParameter("@EXTENT", land_transfer_regulation_obj.extent_ac_cts));
                lstparams.Add(new SqlParameter("@LTRP_NO", land_transfer_regulation_obj.ltrp_no));
                //lstparams.Add(new SqlParameter("@DATE_OF_ORDERS", land_transfer_regulation_obj.OLDltrp_date));
                lstparams.Add(new SqlParameter("@DATE_OF_ORDERS", land_transfer_regulation_obj.ltrp_date));
                lstparams.Add(new SqlParameter("@SDC_LEVEL", land_transfer_regulation_obj.sdc_level));


                lstparams.Add(new SqlParameter("@SDC_ORDERS_PASSED", land_transfer_regulation_obj.sdc_orders_passed));
                lstparams.Add(new SqlParameter("@PETITIONER", land_transfer_regulation_obj.petitioner));
                lstparams.Add(new SqlParameter("@RESPONDENT", land_transfer_regulation_obj.respondent));

                lstparams.Add(new SqlParameter("@O_IN_FAVOUR_OF_NT", land_transfer_regulation_obj.sdc_nt_name));
                lstparams.Add(new SqlParameter("@O_IN_FAVOUR_OF_T", land_transfer_regulation_obj.sdc_tri_name));
                lstparams.Add(new SqlParameter("@O_GOVT", land_transfer_regulation_obj.sdc_gov_name));
                lstparams.Add(new SqlParameter("@O_IN_FAVOUR_OF_NT_EXTENT", land_transfer_regulation_obj.sdc_nt_extent));
                lstparams.Add(new SqlParameter("@O_IN_FAVOUR_OF_T_EXTENT", land_transfer_regulation_obj.sdc_tri_extent));
                lstparams.Add(new SqlParameter("@O_IN_FAVOUR_OF_GOVT_EXTENT", land_transfer_regulation_obj.sdc_gov_extent));

                lstparams.Add(new SqlParameter("@O_T_ORDERS_IMPLEMENT", land_transfer_regulation_obj.sdc_tri_impl));
                lstparams.Add(new SqlParameter("@O_G_ORDERS_IMPLEMENT", land_transfer_regulation_obj.sdc_gov_impl));

                lstparams.Add(new SqlParameter("@NewDATE_OF_ORDERS", land_transfer_regulation_obj.OLDltrp_date));

                //lstparams.Add(new SqlParameter("@AAG_CMA_NO", land_transfer_regulation_obj.cma_no));
                //lstparams.Add(new SqlParameter("@CMADATE_OF_ORDERS", land_transfer_regulation_obj.cmadate));
                //lstparams.Add(new SqlParameter("@AAG_ORDERS_PASSED", land_transfer_regulation_obj.add_orders_passed)); 
                //lstparams.Add(new SqlParameter("@AAG_NT", land_transfer_regulation_obj.add_nt_name));
                //lstparams.Add(new SqlParameter("@AAG_T", land_transfer_regulation_obj.add_tri_name));
                //lstparams.Add(new SqlParameter("@AAG_GOVT", land_transfer_regulation_obj.add_gov_name));
                //lstparams.Add(new SqlParameter("@AAG_EXTENT_NT", land_transfer_regulation_obj.add_nt_extent));
                //lstparams.Add(new SqlParameter("@AAG_EXTENT_T", land_transfer_regulation_obj.add_tri_extent));
                //lstparams.Add(new SqlParameter("@AAG_EXTENT_GOVT", land_transfer_regulation_obj.add_gov_extent));

                //lstparams.Add(new SqlParameter("@AAG_REMARKS", land_transfer_regulation_obj.add_remarks));



                //lstparams.Add(new SqlParameter("@AG_APPEAL_NO", land_transfer_regulation_obj.appeal_no));
                //lstparams.Add(new SqlParameter("@AppealDATE_OF_ORDERS", land_transfer_regulation_obj.appealdate));
                //lstparams.Add(new SqlParameter("@AG_ORDERS_PASSED", land_transfer_regulation_obj.agent_orders_passed));
                //lstparams.Add(new SqlParameter("@AG_NT",land_transfer_regulation_obj.agent_nt_name));
                //lstparams.Add(new SqlParameter("@AG_T", land_transfer_regulation_obj.agent_tri_name));
                //lstparams.Add(new SqlParameter("@AG_GOVT", land_transfer_regulation_obj.agent_gov_name));
                //lstparams.Add(new SqlParameter("@AG_EXTENT_NT", land_transfer_regulation_obj.agent_nt_extent));

                //lstparams.Add(new SqlParameter("@AG_EXTENT_T", land_transfer_regulation_obj.agent_tri_extent));

                //lstparams.Add(new SqlParameter("@AG_EXTENT_GOVT", land_transfer_regulation_obj.agent_gov_extent));
                //lstparams.Add(new SqlParameter("@AG_REMARKS", land_transfer_regulation_obj.agent_remarks));





                //lstparams.Add(new SqlParameter("@G_RP_NO", land_transfer_regulation_obj.rpno));
                //lstparams.Add(new SqlParameter("@RPDATE_OF_ORDERS", land_transfer_regulation_obj.rpdate));
                //lstparams.Add(new SqlParameter("@G_ORDERS_PASSED", land_transfer_regulation_obj.govt_orders_passed));

                //lstparams.Add(new SqlParameter("@G_EXTENT_NT", land_transfer_regulation_obj.gov_nt_extent));
                //lstparams.Add(new SqlParameter("@G_EXTENT_T", land_transfer_regulation_obj.gov_tri_extent));
                //lstparams.Add(new SqlParameter("@G_EXTENT_GOVT", land_transfer_regulation_obj.gov_gov_extent));
                //lstparams.Add(new SqlParameter("@G_NT", land_transfer_regulation_obj.gov_nt_name));
                //lstparams.Add(new SqlParameter("@G_T", land_transfer_regulation_obj.gov_tri_name));

                //lstparams.Add(new SqlParameter("@G_GOVT", land_transfer_regulation_obj.gov_gov_name));

                //lstparams.Add(new SqlParameter("@G_REMARKS", land_transfer_regulation_obj.gov_remarks));



                //lstparams.Add(new SqlParameter("@HC_WP_NO", land_transfer_regulation_obj.wpno));
                //lstparams.Add(new SqlParameter("@WPNDATE_OF_ORDERS", land_transfer_regulation_obj.wpdate));
                //lstparams.Add(new SqlParameter("@HC_ORDERS_PASSED",land_transfer_regulation_obj.hc_orders_passed));
                //lstparams.Add(new SqlParameter("@HC_EXTENT_NT", land_transfer_regulation_obj.hc_nt_extent));
                //lstparams.Add(new SqlParameter("@HC_EXTENT_T", land_transfer_regulation_obj.hc_tri_extent));
                //lstparams.Add(new SqlParameter("@HC_EXTENT_GOVT", land_transfer_regulation_obj.hc_gov_extent));
                //lstparams.Add(new SqlParameter("@HC_NT", land_transfer_regulation_obj.hc_nt_name));

                //lstparams.Add(new SqlParameter("@HC_T", land_transfer_regulation_obj.hc_tri_name));

                //lstparams.Add(new SqlParameter("@HC_GOVT", land_transfer_regulation_obj.hc_gov_name));

                //lstparams.Add(new SqlParameter("@HC_REMARKS", land_transfer_regulation_obj.hc_remarks));




                lstparams.Add(new SqlParameter("@LAND_ALREADY_ACQUIRED", land_transfer_regulation_obj.land_already));
                lstparams.Add(new SqlParameter("@REMARKS", land_transfer_regulation_obj.remarks));

                lstparams.Add(new SqlParameter("@DETAILS_OF_LAND_T_AC_CTS", land_transfer_regulation_obj.Details_T_Ac_cts));
                lstparams.Add(new SqlParameter("@DETAILS_OF_T_LAND_HEC_A", land_transfer_regulation_obj.Details_T_Hec_A));
                lstparams.Add(new SqlParameter("@DETAILS_OF_LAND_G_AC_CTS", land_transfer_regulation_obj.Details_G_Ac_cts));
                lstparams.Add(new SqlParameter("@DETAILS_OF_G_LAND_HEC_A", land_transfer_regulation_obj.Details_G_Hec_A));
                lstparams.Add(new SqlParameter("@case_status", land_transfer_regulation_obj.sdc_casestatus));

                //lstparams.Add(new SqlParameter("@Rdo_sdc_orders", land_transfer_regulation_obj.Rdo_sdc_orders));

                //lstparams.Add(new SqlParameter("@collector_po", land_transfer_regulation_obj.collector_po));
                //lstparams.Add(new SqlParameter("@govt_doc", land_transfer_regulation_obj.govt_doc));
                //lstparams.Add(new SqlParameter("@high_court_doc", land_transfer_regulation_obj.high_court_doc));


                lstparams.Add(new SqlParameter("@IPADDRESS", land_transfer_regulation_obj.Ipaddress));
                lstparams.Add(new SqlParameter("@UserName", land_transfer_regulation_obj.UserName));


                if (land_transfer_regulation_obj.ltrid == "0")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                    DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
                    return result;

                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                    DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC1", lstparams);
                    return result;
                }



            }
            public DataTable Getltrid(string itda,string district)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
               
                lstparams.Add(new SqlParameter("@ITDA_NAME", itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                    DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC1", lstparams);
                    return result;
            }

            public DataTable LTR_Add(land_transfer_regulation land_transfer_regulation_obj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@LTR_ID", land_transfer_regulation_obj.ltrid));
                lstparams.Add(new SqlParameter("@ITDA_NAME", land_transfer_regulation_obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", land_transfer_regulation_obj.District));
                lstparams.Add(new SqlParameter("@DISTRICT", land_transfer_regulation_obj.districtname));
                lstparams.Add(new SqlParameter("@MANDAL", land_transfer_regulation_obj.mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", land_transfer_regulation_obj.village));
                lstparams.Add(new SqlParameter("@HABITATION", land_transfer_regulation_obj.hab));
                lstparams.Add(new SqlParameter("@RS_NO", land_transfer_regulation_obj.rsno));
                lstparams.Add(new SqlParameter("@EXTENT", land_transfer_regulation_obj.extent_ac_cts));
                lstparams.Add(new SqlParameter("@AAG_CMA_NO", land_transfer_regulation_obj.cma_no));
                lstparams.Add(new SqlParameter("@CMADATE_OF_ORDERS", land_transfer_regulation_obj.cmadate));
                lstparams.Add(new SqlParameter("@add_disposal", land_transfer_regulation_obj.add_datedisposal));
                lstparams.Add(new SqlParameter("@addcase_status", land_transfer_regulation_obj.add_casestatus));
                lstparams.Add(new SqlParameter("@AAG_LEVEL", land_transfer_regulation_obj.add_level));
                lstparams.Add(new SqlParameter("@AAG_ORDERS_PASSED", land_transfer_regulation_obj.add_orders_passed));
                lstparams.Add(new SqlParameter("@AAG_NT", land_transfer_regulation_obj.add_nt_name));
                lstparams.Add(new SqlParameter("@AAG_T", land_transfer_regulation_obj.add_tri_name));
                lstparams.Add(new SqlParameter("@AAG_GOVT", land_transfer_regulation_obj.add_gov_name));
                lstparams.Add(new SqlParameter("@AAG_EXTENT_NT", land_transfer_regulation_obj.add_nt_extent));
                lstparams.Add(new SqlParameter("@AAG_EXTENT_T", land_transfer_regulation_obj.add_tri_extent));
                lstparams.Add(new SqlParameter("@AAG_EXTENT_GOVT", land_transfer_regulation_obj.add_gov_extent));
                lstparams.Add(new SqlParameter("@AAG_T_ORDERS_IMPLEMENT", land_transfer_regulation_obj.add_tri_impl));
                lstparams.Add(new SqlParameter("@AAG_G_ORDERS_IMPLEMENT", land_transfer_regulation_obj.add_gov_impl));
                lstparams.Add(new SqlParameter("@AAG_REMARKS", land_transfer_regulation_obj.add_remarks));
                lstparams.Add(new SqlParameter("@IPADDRESS", land_transfer_regulation_obj.Ipaddress));
                lstparams.Add(new SqlParameter("@UserName", land_transfer_regulation_obj.UserName));
                if (land_transfer_regulation_obj.ltrid == "0")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));
                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 12));
                }

                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
                return result;
            }

            public DataTable LTR_Agent(land_transfer_regulation land_transfer_regulation_obj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@LTR_ID", land_transfer_regulation_obj.ltrid));
                lstparams.Add(new SqlParameter("@ITDA_NAME", land_transfer_regulation_obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", land_transfer_regulation_obj.District));
                lstparams.Add(new SqlParameter("@DISTRICT", land_transfer_regulation_obj.districtname));
                lstparams.Add(new SqlParameter("@MANDAL", land_transfer_regulation_obj.mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", land_transfer_regulation_obj.village));
                lstparams.Add(new SqlParameter("@HABITATION", land_transfer_regulation_obj.hab));
                lstparams.Add(new SqlParameter("@RS_NO", land_transfer_regulation_obj.rsno));
                lstparams.Add(new SqlParameter("@EXTENT", land_transfer_regulation_obj.extent_ac_cts));



                lstparams.Add(new SqlParameter("@AG_APPEAL_NO", land_transfer_regulation_obj.appeal_no));
                lstparams.Add(new SqlParameter("@AppealDATE_OF_ORDERS", land_transfer_regulation_obj.appealdate));
                lstparams.Add(new SqlParameter("@agent_disposal", land_transfer_regulation_obj.appeal_disposal));
                lstparams.Add(new SqlParameter("@agentcase_status", land_transfer_regulation_obj.appeal_casestatus));
                lstparams.Add(new SqlParameter("@AG_LEVEL", land_transfer_regulation_obj.agent_level));

                lstparams.Add(new SqlParameter("@AG_ORDERS_PASSED", land_transfer_regulation_obj.agent_orders_passed));
                lstparams.Add(new SqlParameter("@AG_NT", land_transfer_regulation_obj.agent_nt_name));
                lstparams.Add(new SqlParameter("@AG_T", land_transfer_regulation_obj.agent_tri_name));
                lstparams.Add(new SqlParameter("@AG_GOVT", land_transfer_regulation_obj.agent_gov_name));
                lstparams.Add(new SqlParameter("@AG_EXTENT_NT", land_transfer_regulation_obj.agent_nt_extent));

                lstparams.Add(new SqlParameter("@AG_EXTENT_T", land_transfer_regulation_obj.agent_tri_extent));

                lstparams.Add(new SqlParameter("@AG_EXTENT_GOVT", land_transfer_regulation_obj.agent_gov_extent));
                lstparams.Add(new SqlParameter("@AG_T_ORDERS_IMPLEMENT", land_transfer_regulation_obj.agent_tri_impl));
                lstparams.Add(new SqlParameter("@AG_G_ORDERS_IMPLEMENT", land_transfer_regulation_obj.agent_gov_impl));
                lstparams.Add(new SqlParameter("@AG_REMARKS", land_transfer_regulation_obj.agent_remarks));





                lstparams.Add(new SqlParameter("@IPADDRESS", land_transfer_regulation_obj.Ipaddress));
                lstparams.Add(new SqlParameter("@UserName", land_transfer_regulation_obj.UserName));


                if (land_transfer_regulation_obj.ltrid == "0")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 13));
                }

                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
                return result;
            }
            public DataTable LTR_Gov(land_transfer_regulation land_transfer_regulation_obj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@LTR_ID", land_transfer_regulation_obj.ltrid));
                lstparams.Add(new SqlParameter("@ITDA_NAME", land_transfer_regulation_obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", land_transfer_regulation_obj.District));
                lstparams.Add(new SqlParameter("@DISTRICT", land_transfer_regulation_obj.districtname));
                lstparams.Add(new SqlParameter("@MANDAL", land_transfer_regulation_obj.mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", land_transfer_regulation_obj.village));
                lstparams.Add(new SqlParameter("@HABITATION", land_transfer_regulation_obj.hab));

                lstparams.Add(new SqlParameter("@RS_NO", land_transfer_regulation_obj.rsno));
                lstparams.Add(new SqlParameter("@EXTENT", land_transfer_regulation_obj.extent_ac_cts));



                lstparams.Add(new SqlParameter("@G_RP_NO", land_transfer_regulation_obj.rpno));
                lstparams.Add(new SqlParameter("@RPDATE_OF_ORDERS", land_transfer_regulation_obj.rpdate));
                lstparams.Add(new SqlParameter("@gov_disposal", land_transfer_regulation_obj.gov_disposal));
                lstparams.Add(new SqlParameter("@govcase_status", land_transfer_regulation_obj.gov_casestatus));
                lstparams.Add(new SqlParameter("@G_LEVEL", land_transfer_regulation_obj.gov_level));

                lstparams.Add(new SqlParameter("@G_ORDERS_PASSED", land_transfer_regulation_obj.govt_orders_passed));

                lstparams.Add(new SqlParameter("@G_EXTENT_NT", land_transfer_regulation_obj.gov_nt_extent));
                lstparams.Add(new SqlParameter("@G_EXTENT_T", land_transfer_regulation_obj.gov_tri_extent));
                lstparams.Add(new SqlParameter("@G_EXTENT_GOVT", land_transfer_regulation_obj.gov_gov_extent));
                lstparams.Add(new SqlParameter("@G_NT", land_transfer_regulation_obj.gov_nt_name));
                lstparams.Add(new SqlParameter("@G_T", land_transfer_regulation_obj.gov_tri_name));

                lstparams.Add(new SqlParameter("@G_GOVT", land_transfer_regulation_obj.gov_gov_name));


                lstparams.Add(new SqlParameter("@G_T_ORDERS_IMPLEMENT", land_transfer_regulation_obj.gov_tri_impl));
                lstparams.Add(new SqlParameter("@G_G_ORDERS_IMPLEMENT", land_transfer_regulation_obj.gov_gov_impl));

                lstparams.Add(new SqlParameter("@G_REMARKS", land_transfer_regulation_obj.gov_remarks));






                lstparams.Add(new SqlParameter("@IPADDRESS", land_transfer_regulation_obj.Ipaddress));
                lstparams.Add(new SqlParameter("@UserName", land_transfer_regulation_obj.UserName));


                if (land_transfer_regulation_obj.ltrid == "0")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));
                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));
                }

                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
                return result;
            }
            public DataTable LTR_Highcourt(land_transfer_regulation land_transfer_regulation_obj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@LTR_ID", land_transfer_regulation_obj.ltrid));
                lstparams.Add(new SqlParameter("@ITDA_NAME", land_transfer_regulation_obj.Itda));
                lstparams.Add(new SqlParameter("@DISTRICT_LGD_CODE", land_transfer_regulation_obj.District));
                lstparams.Add(new SqlParameter("@DISTRICT", land_transfer_regulation_obj.districtname));

                lstparams.Add(new SqlParameter("@MANDAL", land_transfer_regulation_obj.mandal));
                lstparams.Add(new SqlParameter("@VILLAGE", land_transfer_regulation_obj.village));
                lstparams.Add(new SqlParameter("@HABITATION", land_transfer_regulation_obj.hab));

                lstparams.Add(new SqlParameter("@RS_NO", land_transfer_regulation_obj.rsno));
                lstparams.Add(new SqlParameter("@EXTENT", land_transfer_regulation_obj.extent_ac_cts));



                lstparams.Add(new SqlParameter("@HC_WP_NO", land_transfer_regulation_obj.wpno));
                lstparams.Add(new SqlParameter("@hc_disposal", land_transfer_regulation_obj.hc_disposal));
                lstparams.Add(new SqlParameter("@hccase_status", land_transfer_regulation_obj.hc_casestatus));
                lstparams.Add(new SqlParameter("@hc_wpmpno", land_transfer_regulation_obj.hc_wpmpno));
                lstparams.Add(new SqlParameter("@hc_wpmpstatus", land_transfer_regulation_obj.hc_wpmpno_status));
                lstparams.Add(new SqlParameter("@WPNDATE_OF_ORDERS", land_transfer_regulation_obj.wpdate));
                lstparams.Add(new SqlParameter("@HC_LEVEL", land_transfer_regulation_obj.hc_level));
                lstparams.Add(new SqlParameter("@HC_ORDERS_PASSED", land_transfer_regulation_obj.hc_orders_passed));
                lstparams.Add(new SqlParameter("@HC_EXTENT_NT", land_transfer_regulation_obj.hc_nt_extent));
                lstparams.Add(new SqlParameter("@HC_EXTENT_T", land_transfer_regulation_obj.hc_tri_extent));
                lstparams.Add(new SqlParameter("@HC_EXTENT_GOVT", land_transfer_regulation_obj.hc_gov_extent));
                lstparams.Add(new SqlParameter("@HC_NT", land_transfer_regulation_obj.hc_nt_name));

                lstparams.Add(new SqlParameter("@HC_T", land_transfer_regulation_obj.hc_tri_name));

                lstparams.Add(new SqlParameter("@HC_GOVT", land_transfer_regulation_obj.hc_gov_name));


                lstparams.Add(new SqlParameter("@HC_T_ORDERS_IMPLEMENT", land_transfer_regulation_obj.hc_tri_impl));


                lstparams.Add(new SqlParameter("@HC_G_ORDERS_IMPLEMENT", land_transfer_regulation_obj.hc_gov_impl));



                lstparams.Add(new SqlParameter("@HC_REMARKS", land_transfer_regulation_obj.hc_remarks));

                lstparams.Add(new SqlParameter("@IPADDRESS", land_transfer_regulation_obj.Ipaddress));
                lstparams.Add(new SqlParameter("@UserName", land_transfer_regulation_obj.UserName));


                if (land_transfer_regulation_obj.ltrid == "0")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));
                }
                else
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));
                }

                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MASTER_DATA_PROC", lstparams);
                return result;
            }

            public DataTable land_transfer_files(BeneficiaryDetails BeneficiaryDetailsobj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@landfiles", BeneficiaryDetailsobj.UpdateForestMasterDetails));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_land_transfer_regulation", lstparams);
                return result;
            }
            public DataTable CropLoanFiles(BeneficiaryDetails BeneficiaryDetailsobj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@cropfiles", BeneficiaryDetailsobj.UpdateForestMasterDetails));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_CROP_LOAN", lstparams);
                return result;
            }

            public DataTable Getbenhabitations(string Itda, string district, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@Ptype", 11));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }

            public DataTable Getbenpattadhar(string Itda, string district, string mandal, string village, string habitation)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@Ptype", 12));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }

            public DataTable Getbenpattadharextent(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR,string bid)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", PATTADAAR));
                lstparams.Add(new SqlParameter("@BENFICIARY_ID", bid));
                lstparams.Add(new SqlParameter("@Ptype", 13));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }

            public DataTable Getbenlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                //lstparams.Add(new SqlParameter("@id", PATTADAAR));
                lstparams.Add(new SqlParameter("@id", extent));
               
                lstparams.Add(new SqlParameter("@Ptype", 14));
              
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }

            public DataTable Getbenlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent, string id)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", PATTADAAR));
                lstparams.Add(new SqlParameter("@ExtentPlotArea", extent));
                lstparams.Add(new SqlParameter("@id", Convert.ToInt32(id)));
                lstparams.Add(new SqlParameter("@PTYPE", 15));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }

            public DataTable INSERTlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent, string id, BeneficiaryDetails BeneficiaryDetailsobj)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", PATTADAAR));
                lstparams.Add(new SqlParameter("@ExtentPlotArea", extent));
                lstparams.Add(new SqlParameter("@importBeneficiaryDetails", BeneficiaryDetailsobj.UpdateForestMasterDetails));
                lstparams.Add(new SqlParameter("@Id", Convert.ToInt32(id)));
                lstparams.Add(new SqlParameter("@Ptype", 19));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }


            public DataTable INSERTMultiplelatlongsdata(string Itda,BeneficiaryDetails BeneficiaryDetailsobj)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@importBeneficiaryDetails", BeneficiaryDetailsobj.UpdateForestMasterDetails));
                lstparams.Add(new SqlParameter("@PTYPE", 22));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }
            public DataTable addINSERTlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent, string id, string LAT, string LONG)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", PATTADAAR));
                lstparams.Add(new SqlParameter("@ExtentPlotArea", extent));
                lstparams.Add(new SqlParameter("@LATITUDE", LAT));
                lstparams.Add(new SqlParameter("@LONGITUDE", LONG));
                lstparams.Add(new SqlParameter("@Id", Convert.ToInt32(id)));
                lstparams.Add(new SqlParameter("@Ptype", 16));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }

            public DataTable updatelatlongsdata(string latid, string id, string LAT, string LONG)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                lstparams.Add(new SqlParameter("@L_Id", Convert.ToInt32(latid)));
                lstparams.Add(new SqlParameter("@LATITUDE", LAT));
                lstparams.Add(new SqlParameter("@LONGITUDE", LONG));
                lstparams.Add(new SqlParameter("@Id", Convert.ToInt32(id)));
                lstparams.Add(new SqlParameter("@Ptype", 17));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }

            public DataTable DELETElatlongsdata(string latid, string id)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@L_Id", Convert.ToInt32(latid)));
                lstparams.Add(new SqlParameter("@Id", Convert.ToInt32(id)));
                lstparams.Add(new SqlParameter("@Ptype", 18));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Habitation_Master", lstparams);
                return result;
            }
            public DataTable GetextentlandbenitdaDetails(string district, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
              
                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype", 2));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype", 2));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new SqlParameter("@itda", (district)));
                    lstparams.Add(new SqlParameter("@Ptype", 2));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ExtentLandviewonGIS", lstparams);
                return result;
            }
            public DataTable GetextentlandbenmandalDetails(string itda,string district, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                else
                {
                    start = "";
                    ITDANAME = itda;
                }


                if (start == "DTW")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                    lstparams.Add(new SqlParameter("@Ptype", 3));
                }
                else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                    lstparams.Add(new SqlParameter("@Ptype", 3));
                }
                else if (start == "" || ITDANAME == "DIRECTOR")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                    lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                    lstparams.Add(new SqlParameter("@Ptype", 3));
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ExtentLandviewonGIS", lstparams);
                return result;
            }

            public DataTable Getextentlandbenlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDANAME", (Itda)));
                lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
                lstparams.Add(new SqlParameter("@LGD_MANDAL_CODE", mandal));
                lstparams.Add(new SqlParameter("@LGD_VILLAGE_CODE", village));
                lstparams.Add(new SqlParameter("@HAB_NAME", habitation));
                lstparams.Add(new SqlParameter("@ROFR_PATTADAAR", PATTADAAR));
                lstparams.Add(new SqlParameter("@ExtentPlotArea", extent));
                lstparams.Add(new SqlParameter("@Ptype", 9));
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ExtentLandviewonGIS", lstparams);
                return result;
            }








   public DataTable GetNAdharcount()
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));

                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ITDA_HEALTH", lstparams);
                return result;
            }
            public DataTable GetNAdharData(string start, string end)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();

                lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
                lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));

                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));

                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ITDA_HEALTH", lstparams);
                return result;
            }

            public DataTable GetNAdharUpdate(adhar_detials aobj)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@AADHAR_SURVEY_STATUS", aobj.adharstatus));
                lstparams.Add(new SqlParameter("@Aadhaar_NO", aobj.adharno));
                lstparams.Add(new SqlParameter("@AADHAR_SURVEY_NAME", aobj.adharname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ITDA_HEALTH", lstparams);
                return result;




            }

            public DataTable ExceuteQuery(string sqlQuery)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@SqlQuery", sqlQuery));
                lstparams.Add(new SqlParameter("@PType", 1));
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("SQL_ManageSqlQueries", lstparams);
                return result;
            }

            public DataTable Homedashboardcounr(string itda, string district)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@Itda_Name", itda));
                lstparams.Add(new SqlParameter("@District", district));
                if (itda == "" && district == "")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 8));
                }
                else if (itda != "" && district == "")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 9));
                }
                else if (itda == "" && district != "")
                {
                    lstparams.Add(new SqlParameter("@Ptype", 10));
                }


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficary_Master_Count", lstparams);
                return result;
            }

            public DataTable GetltrMasterAnalysis(string Itda, string district, string mandal, string village)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                if (Itda != "" && district == "" && mandal == "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", Itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                }
                else if (Itda != "" && district != "" && mandal == "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", Itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                }
                else if (Itda != "" && district != "" && mandal != "")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", Itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                }
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_Ltr_Reports", lstparams);
                return result;
            }

            public DataTable Get_Loan_Report(Loan_details lobj)
            {



                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(lobj.username))
                {
                    a = lobj.username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (lobj.type == "bank")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));


                }
                else if (lobj.type == "fdist")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));


                }
                else if (lobj.type == "fdivision")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                   lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.dist));
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));


                }
                else if (lobj.type == "frange")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));


                }
                else if (lobj.type == "fbeat")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE", lobj.range));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));

                }
                else if (lobj.type == "fblock")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE", lobj.range));
                 lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT", lobj.beat));
                   
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));

                }
                else if (lobj.type == "ENTERED")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE", lobj.range));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT", lobj.beat));
                   lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BLOCK", lobj.block));
                   
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));

                }
                else if (lobj.type == "APPROVED")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE", lobj.range));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT", lobj.beat));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BLOCK", lobj.block));
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 8));

                }
                else if (lobj.type == "RELEASED")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE", lobj.range));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BEAT", lobj.beat));
                   lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_BLOCK", lobj.block));
                   
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 9));

                }
                else if (lobj.type == "ritda")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 10));


                }
                else if (lobj.type == "rdist")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 11));


                }
                else if (lobj.type == "rmandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", lobj.dist));
                   lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.division));
                 
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 12));


                }
                else if (lobj.type == "rvillage")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.division));
                   lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", lobj.range));
                   
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 13));

                }
                else if (lobj.type == "RENTERED")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", lobj.range));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", lobj.beat));
                   
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 14));

                }
                else if (lobj.type == "RAPPROVED")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", lobj.range));
               lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", lobj.beat));
                   
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 15));
                }
                else if (lobj.type == "RRELEASED")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", lobj.dist));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", lobj.division));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@MANDAL", lobj.range));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE", lobj.beat));
                   
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 16));

                }
                else if (lobj.type == "bentered")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 18));

                }
                else if (lobj.type == "branch_entered")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BRANCH_NAME", lobj.branch_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 19));

                }
                else if (lobj.type == "bapproved")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 20));

                }
                else if (lobj.type == "branch_approved")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BRANCH_NAME", lobj.branch_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 21));

                }
                else if (lobj.type == "breleased")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 22));

                }
                else if (lobj.type == "branch_released")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BRANCH_NAME", lobj.branch_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 23));

                }
                else if (lobj.type == "bnotreleased")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 24));

                }
                else if (lobj.type == "branch_notreleased")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BRANCH_NAME", lobj.branch_name));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 25));

                }
                else if (lobj.type == "All")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@BANKNAME", lobj.bank_name));
                    
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 26));

                }
                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_ROFR_LOAN_REPORTS", lstparams);
                return result;
            }

            public DataTable Homedashboardcounr(string username)
            {


                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                }
                else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }



                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_MAIN_DASHBOARD", lstparams);
                //result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficary_Master_Count", lstparams);
                return result;
            }

            public DataSet Homedashboardcounr1(string username)
            {

                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataSet result = new DataSet();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                if (Itdastart == "DTW")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));

                }
                else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));
                }
                else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                {

                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                }



                result = sqlmngr.ExecuteProcedureReturnDataSet("PROC_MAIN_DASHBOARD", lstparams);
                //result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficary_Master_Count", lstparams);
                return result;
            }

            public DataTable Landstatusreport()
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                lstparams.Add(new SqlParameter("@PTYPE", 1));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
                return result;
            }

            public DataTable Phase1_Phase2_data(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {



                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                if (type == "Phase1")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 4));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                    }

                }
                if (type == "Phase2")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 6));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 7));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));

                    }

                }


                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
                return result;
            }
            public DataTable Landstatusreport_Beneficiary()
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                lstparams.Add(new SqlParameter("@PTYPE",9));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
                return result;
            }
            public DataTable Nothavinglanddetailsreport()
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                lstparams.Add(new SqlParameter("@PTYPE", 8));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
                return result;
            }
            public DataTable Nothavinglanddetailslevelreport(string Itda, string district)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA_NAME", Itda));
                lstparams.Add(new SqlParameter("@DISTRICT", district));
                lstparams.Add(new SqlParameter("@PTYPE", 10));


                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_LAND_STATUS_REPORT", lstparams);
                return result;
            }

            public DataTable Getlatlongsdata(dynamic obj)
            {
                try
                {
                    List<SqlParameter> lstparams = new List<SqlParameter>();
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", Convert.ToInt32(obj.DistrictId)));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Typeselction", (obj.typeofselectionvalue)));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));
                    SQLManager sqlmngr = new SQLManager();
                    DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Godwans_Gismap", lstparams);


                    if (result != null && result.Rows.Count > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            public DataTable Getnregaadharrecords(string district, string username)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();

                lstparams.Add(new SqlParameter("@ITDA_NAME", (district)));
                lstparams.Add(new SqlParameter("@PTYPE", 1));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_NREGA_SERVICE", lstparams);
                return result;
            }

            public DataTable Getbenallrecordsnerga()
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@PTYPE", 3));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_NREGA_SERVICE", lstparams);
                return result;
            }

            public DataTable Getnregaadharrecordsinsert(string ITDA_NAME, string Aadhaar_NO, string JobCardID, string JobCardName, string JobCardStatus, string WorkCode, string WorkName, string WorkStatus, string Activity, string EstimtedCost, string Expenditure, string CreatedDate, string CompletionDate, string LandExtent)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@ITDA_NAME", (ITDA_NAME)));
                lstparams.Add(new SqlParameter("@Aadhaar_NO", (Aadhaar_NO)));
                lstparams.Add(new SqlParameter("@JobCardID", (JobCardID)));
                lstparams.Add(new SqlParameter("@JobCardName", (JobCardName)));
                lstparams.Add(new SqlParameter("@JobCardStatus", (JobCardStatus)));
                lstparams.Add(new SqlParameter("@WorkCode", (WorkCode)));
                lstparams.Add(new SqlParameter("@WorkName", (WorkName)));
                lstparams.Add(new SqlParameter("@WorkStatus", (WorkStatus)));
                lstparams.Add(new SqlParameter("@Activity", (Activity)));
                lstparams.Add(new SqlParameter("@EstimtedCost", (EstimtedCost)));
                lstparams.Add(new SqlParameter("@Expenditure", (Expenditure)));
             
                        lstparams.Add(new SqlParameter("@CreatedDate", (CreatedDate)));
                
                        lstparams.Add(new SqlParameter("@CompletionDate", (CompletionDate)));
                   
                lstparams.Add(new SqlParameter("@LandExtent", (LandExtent)));
                lstparams.Add(new SqlParameter("@PTYPE", 2));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_NREGA_SERVICE", lstparams);
                return result;
            }


            public DataTable GetRythuBharosaStatus_May21(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                if (type == "DISTRICT")
                {
                    if (Itdastart == "DTW")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 17));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 18));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        //lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district == "" ? "" : district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 16));

                    }

                }
                else if (type == "MANDAL")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 19));
                }
                else if (type == "Belong to Beneficiary Family")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 20));
                }
                else if (type == "Eligible")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 21));
                }
                else if (type == "Ineligible")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", itda));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                    //lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ptype", 22));
                }

                result = sqlmngr.ExecuteProcedureReturnDataTable("Proc_RB_Payments_May2020", lstparams);
                return result;
            }


            public DataTable Get_Beneficiary_Data_for_Rythubharosa_Report(string type, string itda, string district, string mandal, string village, string username, string userprevileges)
            {
                List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                SQLManager sqlmngr = new SQLManager();
                string a = string.Empty;
                if (!string.IsNullOrEmpty(username))
                {
                    a = username;
                }
                else
                {
                    a = "admin";
                }

                var regexItem = new Regex("_");
                string Itdastart = string.Empty;
                string ITDANAME = string.Empty;
                DataTable result = new DataTable();
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    Itdastart = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }

                //farmer with no  land image
                if (type == "District")
                {
                    if (Itdastart == "DTW")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@DISTRICT", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 2));

                    }
                    else if (Itdastart != "DTW" && ITDANAME != "DIRECTOR" && Itdastart != "")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA_NAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 3));
                    }
                    else if (Itdastart == "" || ITDANAME == "DIRECTOR")
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 1));

                    }
                

                }
                result = sqlmngr.ExecuteProcedureReturnDataTable("PROC_RYTHUBHAROSA_DATA_DISPLAY", lstparams);
                return result;
            }


            public DataTable User_Loginstatus(string UserName, string type)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new SqlParameter("@user_name", UserName));
                lstparams.Add(new SqlParameter("@Ptype", type));

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
                return result;
            }
        }
    }
}
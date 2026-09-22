using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROFR.helper;
using System.Text.RegularExpressions;

namespace ROFR.helper
{
    public class RevenueDistrictsDAL
    {
        public class RevenueDistricts
        {
            public DataTable GetDistrictMasterAnalysis(string USERNAME, string filtertype, string district, string mandal)
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
                        lstparams.Add(new SqlParameter("@Ptype", 1));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 1));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new SqlParameter("@Ptype", 1));
                    }
                }
                else if (filtertype == "Mandal")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 2));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 2));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 2));
                    }
                }
                else if (filtertype == "Village")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                        lstparams.Add(new SqlParameter("@Ptype", 3));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                        lstparams.Add(new SqlParameter("@Ptype", 3));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                        lstparams.Add(new SqlParameter("@Ptype", 3));
                    }
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestMasters_Analysis", lstparams);
                return result;
            }

            public DataTable GetForestMasterAnalysis(string USERNAME, string filtertype, string district, string division, string forestrange)
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
                if (filtertype == "Division")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 4));
                    }
                }
                else if (filtertype == "Range")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new SqlParameter("@Ptype", 5));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new SqlParameter("@Ptype", 5));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new SqlParameter("@Ptype", 5));
                    }
                }
                else if (filtertype == "Beat")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", forestrange));
                        lstparams.Add(new SqlParameter("@Ptype", 6));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", forestrange));
                        lstparams.Add(new SqlParameter("@Ptype", 6));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", forestrange));
                        lstparams.Add(new SqlParameter("@Ptype", 6));
                    }
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestMasters_Analysis", lstparams);
                return result;
            }

            public DataTable GetForestDivisionMasterAnalysis(string USERNAME, string filtertype, string division, string forestrange)
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
                if (filtertype == "Division")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 7));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 7));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new SqlParameter("@Ptype", 7));
                    }
                }
                else if (filtertype == "Range")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new SqlParameter("@Ptype", 8));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new SqlParameter("@Ptype", 8));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new SqlParameter("@Ptype", 8));
                    }
                }
                else if (filtertype == "Beat")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", forestrange));
                        lstparams.Add(new SqlParameter("@Ptype", 9));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", forestrange));
                        lstparams.Add(new SqlParameter("@Ptype", 9));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", division));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", forestrange));
                        lstparams.Add(new SqlParameter("@Ptype", 9));
                    }
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestMasters_Analysis", lstparams);
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
                        lstparams.Add(new SqlParameter("@Ptype", 10));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 10));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new SqlParameter("@Ptype", 10));
                    }
                }
                else if (filtertype == "Mandal")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 11));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 11));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new SqlParameter("@Ptype", 11));
                    }
                }
                else if (filtertype == "Village")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                        lstparams.Add(new SqlParameter("@Ptype", 12));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                        lstparams.Add(new SqlParameter("@Ptype", 12));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                        lstparams.Add(new SqlParameter("@Ptype", 12));
                    }
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestMasters_Analysis", lstparams);
                return result;
            }


            public DataTable GetItdadetails(string USERNAME, string filtertype, string district, string mandal)
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
                if (filtertype == "Itda")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", "Plain Areas"));
                        lstparams.Add(new SqlParameter("@Ptype", 13));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 13));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new SqlParameter("@Ptype", 13));
                    }
                }
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestMasters_Analysis", lstparams);
                return result;
            }

            public DataTable Getadddetails(string USERNAME, string filtertype, string district, string mandal)
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
                if (filtertype == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 6));
                }
                else if (filtertype == "Division")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 7));
                }
                else if (filtertype == "Range")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_DIVISION_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 8));
                }
                else if (filtertype == "Beat")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@FOREST_RANGE_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 9));
                }
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
                return result;
            }

            public DataTable GetCurdForestDivisionMasterAnalysis(string USERNAME, string filtertype, string division, string forestrange)
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
                if (filtertype == "Division")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 5));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 5));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new SqlParameter("@Ptype", 5));
                    }
                }

                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
                return result;
            }

            public void InsertForesthab(string district, string mandal, string village, string villagename, string habname, string revname, string Ipaddress, string username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@VILLAGE_NAME", villagename));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@HAB_NAME", habname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@REV_VILLAGE_NAME", revname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ipaddress", Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 9));
                sqlmngr.ExecuteProcedure("Habitation_Master", lstparams);
            }

            public void UpdateForesthab(string Id, string district, string mandal, string village, string habname, string revname, string Ipaddress, string username)
            {
                SQLManager sqlmngr = new SQLManager();
                List<SqlParameter> lstparams = new List<SqlParameter>();
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Id", Convert.ToInt32(Id)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", (mandal)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", (village)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@HAB_NAME", habname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@REV_VILLAGE_NAME", revname));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Ipaddress", Ipaddress));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@UserName", username));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 10));
                sqlmngr.ExecuteProcedure("Habitation_Master", lstparams);
            }

            public DataTable Getcheckergridmasters(string USERNAME, string filtertype, string district, string mandal, string village)
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
                if (filtertype == "Mandal")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 10));
                }
                if (filtertype == "village")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 11));
                }
                else if (filtertype == "Division")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 12));
                }
                else if (filtertype == "Range")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 13));
                }
                else if (filtertype == "Beat")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 14));
                }
                else if (filtertype == "Patta")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 15));
                }
                else if (filtertype == "Dry")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 16));
                }
                else if (filtertype == "Season")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 17));
                }
                else if (filtertype == "Month")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 18));
                }
                else if (filtertype == "Landclass")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 19));
                }
                else if (filtertype == "RevenueMandals")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 20));
                }
                else if (filtertype == "RevenueVillages")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 21));
                }
                else if (filtertype == "FDivision")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 22));
                }
                else if (filtertype == "FRanges")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 23));
                }
                else if (filtertype == "FBeats")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 24));
                }
                else if (filtertype == "Rhabitation")
                {
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_DISTRICT_CODE", district));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_MANDAL_CODE", mandal));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@LGD_VILLAGE_CODE", village));
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 26));
                }
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
                return result;
            }

            public DataTable Search(string USERNAME, string itda, string district, string mandal, string village, string pattadhar, string aadhar, string pattano, string start, string end)
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
                string start1 = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start1 = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
               
                    lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME",itda));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@District", district));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Mandal", mandal));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Village", village));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Pattadar_name", pattadhar));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Aadharno", aadhar));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Pattano", pattano));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@Start_range",Convert.ToInt32(start)));
                lstparams.Add(new System.Data.SqlClient.SqlParameter("@End_range", Convert.ToInt32(end)));


                lstparams.Add(new System.Data.SqlClient.SqlParameter("@PType", 25));
                
               
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("Beneficiary_MastersData_Analysis", lstparams);
                return result;
            }
            public DataTable GetItdaMaster(string USERNAME, string filtertype, string district, string mandal)
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
                if (filtertype == "Itda")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", "Plain Areas"));
                        lstparams.Add(new SqlParameter("@Ptype", 14));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 14));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new SqlParameter("@Ptype", 14));
                    }
                }
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("ForestMasters_Analysis", lstparams);
                return result;
            }

            public DataTable Getbeneficiarytransaction(string USERNAME, string filtertype, string district, string mandal, string village, string adhar)
            {
                List<SqlParameter> lstparams = new List<SqlParameter>();
                string a = string.Empty;
                string uprevilege = district;
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

                if (filtertype == "getdetails")
                {
                    if (district == "ALL" || district == "" || district == null)
                    {

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@userprevileges", district));

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Beneficiary_id", adhar));

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                    }
                    else if (district == ITDANAME)
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@userprevileges", district));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", ITDANAME));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Beneficiary_id", adhar));

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                    }
                    else
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@userprevileges", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDA", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@Beneficiary_id", adhar));

                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@PTYPE", 5));
                    }
                }
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_add_details", lstparams);
                return result;
            }

            public DataTable GetExtentlandItdadetails(string USERNAME, string filtertype, string district, string mandal)
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
                if (filtertype == "Itda")
                {
                    if (start == "DTW")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "Plain Areas"));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", "Plain Areas"));
                        lstparams.Add(new SqlParameter("@Ptype", 1));
                    }
                    else if (start != "DTW" && ITDANAME != "DIRECTOR" && start != "")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", ""));
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDANAME", ITDANAME));
                        lstparams.Add(new SqlParameter("@Ptype", 1));
                    }
                    else if (start == "" || ITDANAME == "DIRECTOR")
                    {
                        lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
                        lstparams.Add(new SqlParameter("@Ptype", 1));
                    }
                }
                SQLManager sqlmngr = new SQLManager();
                DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("sp_ExtentLandviewonGIS", lstparams);
                return result;
            }


        }
    }
}
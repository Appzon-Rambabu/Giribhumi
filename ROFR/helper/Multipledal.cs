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
    public class Multipledal
    {

        public DataTable GetForestBeneficiaryDetailsValidate(string district, string start, string end, string Itda, string mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@itda", (Itda)));
            lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
            lstparams.Add(new SqlParameter("@Dlc_Date", mandal));

            lstparams.Add(new SqlParameter("@Start_range", Convert.ToInt32(start)));
            lstparams.Add(new SqlParameter("@End_range", Convert.ToInt32(end)));

            lstparams.Add(new SqlParameter("@Ptype", 3));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("multipledlc", lstparams);
            return result;
        }

        public DataTable GetForestBeneficiaryDetailscountValidate(string district, string ITDA, string mandal)
        {
            List<SqlParameter> lstparams = new List<SqlParameter>();
            lstparams.Add(new SqlParameter("@itda", (ITDA)));
            lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
            lstparams.Add(new SqlParameter("@Dlc_Date", mandal));
            lstparams.Add(new SqlParameter("@Ptype", 2));

            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("multipledlc", lstparams);
            return result;
        }



        public DataTable GetbenmandalDetails(string itda, string district, string username)
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


            lstparams.Add(new System.Data.SqlClient.SqlParameter("@ITDATYPE", "ALL"));
            lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", (district)));
            lstparams.Add(new SqlParameter("@itda", (itda)));
            lstparams.Add(new SqlParameter("@Ptype", 1));


            SQLManager sqlmngr = new SQLManager();
            DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("multipledlc", lstparams);
            return result;
        }
    }
}
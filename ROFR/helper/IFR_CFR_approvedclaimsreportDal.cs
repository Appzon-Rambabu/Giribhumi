using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ROFR.helper
{
    public class IFR_CFR_approvedclaimsreportDal
    {
        public DataTable GetIFRCFRClaims()
        {
            SQLManager sqlmngr = new SQLManager();

            List<SqlParameter> param = new List<SqlParameter>()
    {
        new SqlParameter("@PTYPE", 3)
    };

            return sqlmngr.ExecuteProcedureReturnDataTable(
                "SP_IFR_Lands_Cropping_Pattern",
                param
            );
        }
    }
}
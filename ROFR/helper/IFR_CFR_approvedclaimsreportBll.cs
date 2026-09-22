using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ROFR.helper
{
    public class IFR_CFR_approvedclaimsreportBll
    {
        IFR_CFR_approvedclaimsreportDal objDal = new IFR_CFR_approvedclaimsreportDal();
        public DataTable GetIFRCFRClaims()         {
            return objDal.GetIFRCFRClaims();
        }
    }
}
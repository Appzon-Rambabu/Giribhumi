using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ROFR.helper;
using System.Web.Services;
using Newtonsoft.Json;

namespace ROFR.NewPages
{
    public partial class IFR_CFR_approvedclaimsreport : System.Web.UI.Page
    {
        //IFR_CFR_approvedclaimsreportBll objbal = new IFR_CFR_approvedclaimsreportBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetIFRCFRClaims();
            }
        }


        [WebMethod]
        public static string GetIFRCFRClaims()
        {
            IFR_CFR_approvedclaimsreportBll objbal = new IFR_CFR_approvedclaimsreportBll();

            DataTable dt = objbal.GetIFRCFRClaims();

            return JsonConvert.SerializeObject(dt);
        }


        //protected DataTable GetIFRCFRClaims()
        //{
        //    IFR_CFR_approvedclaimsreportBll objbal = new IFR_CFR_approvedclaimsreportBll();
        //    return objbal.GetIFRCFRClaims();
        //}


    }
}
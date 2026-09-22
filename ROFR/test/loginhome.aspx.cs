using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ROFR.helper;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace ROFR.test
{
    public partial class loginhome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string a = (string)(Session["username"]);
                string b = (string)(Session["userprevilages"]);
                string start = (string)(Session["start"]);
                string Itda = (string)(Session["ITDANAME"]);
                string district = "";
                if (start == "PO" || start == "STAFF")
                {
                    // Itda = a.Substring(a.LastIndexOf('_') + 1);
                    dt = ProjectRofrBAL.GetMasterDetails.Homedashboardcounr(Itda, "");
                }
                else if (start == "DTW")
                {
                    // district = a.Substring(a.LastIndexOf('_') + 1);
                    dt = ProjectRofrBAL.GetMasterDetails.Homedashboardcounr("", Itda);
                }
                else if (start == "ITDA")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Homedashboardcounr("", "");
                }

                else if (a == "admin" || a == "DTW")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Homedashboardcounr("", "");
                }
                if (dt.Rows.Count > 0)
                {
                    //totalbenificiary.InnerText = dt.Rows[0]["Total_bneficiaries_dept"].ToString();
                    totalbeneficiaries.InnerText = dt.Rows[0]["Total_Beneficiaries"].ToString();
                    aadharavaliable.InnerText = dt.Rows[0]["Total_Received"].ToString();
                    aadharnotavaliable.InnerText = dt.Rows[0]["Adhharnotavaliable"].ToString();
                    vaildaadhar.InnerText = dt.Rows[0]["Adhharisvalid"].ToString();
                    invaildaadhar.InnerText = dt.Rows[0]["Adhharnoinvalid"].ToString();
                    if ((string)(Session["username"]) == "admin")
                    {
                        extent.InnerText = (string)(Session["sessionextent"]);
                    }
                    else
                    {
                        extent.InnerText = dt.Rows[0]["Total_Extent"].ToString();
                    }
                    //rbps.InnerText = dt.Rows[0]["payment_success"].ToString();
                    //rbpf.InnerText = dt.Rows[0]["payment_failure"].ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
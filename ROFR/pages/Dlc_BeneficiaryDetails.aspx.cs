using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;

namespace ROFR.pages
{
    public partial class Dlc_BeneficiaryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentDlcdetails"]) == "Dlc_BeneficiaryDetails.aspx")
                    {
                        BindData((string)(Session["CurrentDlcdetails"]));
                    }
                    else
                    {
                        BindData("");
                    }


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void BindData(string form)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["dtDlcdetails"];
                if (form != "")
                {
                    dt = (DataTable)Session["dtDlcdetails"];
                }
              
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();


                    if (form != "")
                    {
                        Session["CurrentDlcdetails"] = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Linkview_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)(sender);
                string Id = btn.CommandArgument;
                Session["Id"] = Id;
                string url = "VIEWDLC.aspx";
                string s = "window.open('" + url + "', 'popup_window', 'width=1350,height=660,resizable=yes');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
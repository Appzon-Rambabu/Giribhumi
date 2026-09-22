using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Dynamic;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Text;
using System.Web.Helpers;

namespace ROFR.pages
{
    public partial class Aadharwise_Beneficiary_Details_BNK : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


            //    var plainuser = Session["uname"].ToString();
            //    var plainpwd = Session["pwd"].ToString();

            //    if (plainuser == "" && plainpwd == "" || plainuser == null && plainpwd == null)
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //    else
            //    {
            //        if (plainuser == "ROFR_BANKERS" && plainpwd == "rofrbankers#321")
            //        {

            //        }
            //        else
            //        {
            //            Response.Redirect("Login.aspx");
            //        }
            //    }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //AntiForgery.Validate();

                if (txt_adhar_no.Text != "")
                {
                    string adharNo = Request.Form[HiddenField1.UniqueID];
                    DataTable dt = Landsettlementpattas.GetAdharwise_rofrdata("admin", "master", "", adharNo, (string)Session["userprevilages"]);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        System.Threading.Thread.Sleep(5000);
                        ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(5000);
                        ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(5000);
                    ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Aadhar Number!')", true);
                }

            }
            catch (Exception ex)
            {
                System.Threading.Thread.Sleep(5000);
                ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {
                //AntiForgery.Validate();
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');
                DataTable dt = new DataTable();
                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);




                if (start != " ")
                {
                    if (end == "1")
                    {
                        Session["bid"] = start.Trim();
                        Session["Adhar"] = dist.Trim();
                        // Response.Redirect("DetailsView_1B.aspx");
                        string url = "../pages/ViewAdharwiseDetails_Bnk.aspx";
                        string u = "window.open('" + url + "', 'popup_window', 'width=500,height=550,resizable=yes');";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "script", u, true);

                    }

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
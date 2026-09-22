using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using ROFR.helper;
using System.Data;
namespace ROFR.Masters
{
    public partial class LTR_MASTER : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (Session["username"] == null || (string)Session["username"] == "")
                    {

                        Response.Redirect("Login.aspx");

                    }
                    string user = string.Empty;
                    if ((Session["username"] != null))
                    {
                        user = (string)(Session["username"]);
                    }
                    var check = new Regex("_");
                    txt_admin.Text = "Welcome To " + user;
                    System.Timers.Timer timer = new System.Timers.Timer();
                    timer.Interval = 2000;
                    timer.Elapsed += timer_Elapsed;
                    timer.Start();

                }
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void Menu_Click(Object sender, EventArgs e)
        {
            try
            {


                Session["CurrentPage"] = "LAND_TRANSFER_REGULATION.aspx";
                Response.Redirect("LAND_TRANSFER_REGULATION.aspx");
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void PoAnchor_Click(Object sender, EventArgs e)
        {
            try
            {

                Session["Director"] = "Po";
                Response.Redirect("ROFR_BeneficiariesDetailsApproval.aspx");
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void Anchor_Click(Object sender, EventArgs e)
        {
            try
            {

                Session["Director"] = "DIRECTOR";
                Response.Redirect("ROFR_BeneficiariesDetailsApproval.aspx");
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btn_log_out(object sender, EventArgs e)
        {
            try
            {
                //ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["username"]), "0", "");
                //ProjectRofrBAL.GetMasterDetails.User_Authenticationlog((string)(Session["username"]), HttpContext.Current.Request.UserHostAddress, "Logout");
                //Session.Abandon();
                //Session.Clear();
                //Session.RemoveAll();
                //string user = (string)(Session["username"]);

                Response.Redirect("Logout.aspx");
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btn_home(object sender, EventArgs e)
        {
            try
            {
                //ProjectRofrBAL.GetMasterDetails.User_Authenticationlog((string)(Session["username"]), HttpContext.Current.Request.UserHostAddress, "Home");
                //Session.Abandon();
                //Session.Clear();
                //Session.RemoveAll();
                //string user = (string)(Session["username"]);
                Session["CurrentPage"] = "LAND_TRANSFER_REGULATION.aspx";
                Response.Redirect("LAND_TRANSFER_REGULATION.aspx");
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //YourCode

            try
            {
                DataTable dt = ProjectRofrBAL.GetMasterDetails.User_Authentication((string)(Session["username"]));

                DateTime date = DateTime.Now;
                TimeSpan ts = date - (Convert.ToDateTime(dt.Rows[0]["Login_date"].ToString()));
                //string ts1 = ts.TotalHours.ToString();
                //string c = (string)(Session["Captcha"]);
                //if ((string)(Session["Captcha"]) != (dt.Rows[0]["captcha_update"].ToString()))
                if (ts.TotalHours >= 1)
                {
                    ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["username"]), "0", "");
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Session Expired');", true);
                    Session.Abandon();
                    Session.Clear();
                    Session.RemoveAll();
                    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Duplicate User Login Found...Please login again')", true);
                    //Response.Redirect("Login.aspx");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User details saved sucessfully');window.location ='Login.aspx';", true);
                    //ScriptManager.RegisterStartupScript(this,this.GetType(), "alert", "alert('Duplicate User Login Found...Please login again');window.location.href='Login.aspx';", true);


                }
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
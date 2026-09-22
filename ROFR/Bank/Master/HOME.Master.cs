using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using ROFR.helper;
using System.Data;
using System.Web.Helpers;

namespace ROFR.Bank.Master
{
    public partial class HOME : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                csrft.InnerHtml = AntiForgery.GetHtml().ToString();
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {



                if (!IsPostBack)

                {

                    if (Request.Cookies["ASP.NET_SessionId"] != null)
                    {
                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                        string guid = Guid.NewGuid().ToString();
                        Session["ASP.NET_SessionId"] = guid;

                        Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", guid));
                    }
                    //string user = string.Empty;
                    //if ((Session["username"] != null))
                    //{
                    //    user = (string)(Session["username"]);
                    //}
                    //var check = new Regex("_");
                    //txt_admin.Text = "Welcome To " + user;


                    //if (user != "admin")
                    //{
                    //    //menu1.Disabled = true;
                    //    //menu2.Disabled = true;
                    //    //menu3.Disabled = true;
                    //    menu1.Style.Add("display", "none");
                    //    menu2.Style.Add("display", "none");

                    //}

                    //if (user != "")
                    //{
                    //    if (check.IsMatch(user))
                    //    {
                    //        var s = user.IndexOf('_');

                    //        string usertype = user.Substring(0, s);
                    //        string userend = user.Substring(user.LastIndexOf('_') + 1);
                    //        if (usertype == "STAFF")
                    //        {
                    //            menu5_2.Style.Add("display", "none");
                    //            menu5_3.Style.Add("display", "none");
                    //        }
                    //        else if (usertype == "PO")
                    //        {
                    //            menu5_1.Style.Add("display", "none");
                    //            menu5_3.Style.Add("display", "none");
                    //        }
                    //        else if (userend == "DIRECTOR")
                    //        {
                    //            menu5_1.Style.Add("display", "none");
                    //            menu5_2.Style.Add("display", "none");
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    Response.Redirect("Login.aspx");
                    //}
                    //System.Timers.Timer t = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds); // Set the time (5 mins in this case)
                    //t.AutoReset = true;
                    //t.Elapsed += new System.Timers.ElapsedEventHandler(captcha_timer);
                    //t.Start();
                }
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
        protected void captcha_timer(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ProjectRofrBAL.GetMasterDetails.User_Authentication((string)(Session["username"]));

                Session["DbCaptcha"] = dt.Rows[0]["captcha_update"].ToString();

            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
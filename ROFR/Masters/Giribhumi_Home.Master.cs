using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.Text.RegularExpressions;
namespace ROFR.Masters
{
    public partial class Giribhumi_Home : System.Web.UI.MasterPage
    {
        string IPAddress;
        string MacAddress;
        UserDatabase ud = new UserDatabase();
        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        public string GetIPAddress()
        {
            try
            {
                IPAddress = HttpContext.Current.Request.UserHostAddress;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return IPAddress;

        }
        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {


                if (Page.IsValid)
                {
                    var username = Txt_username.Text;
                    var password = Txt_pwd.Text;
                    string captcha = Request.Form["captcha"];

                    DataTable dt = ud.GetUserId(username, password);
                    DataTable dtUser = ProjectRofrBAL.GetMasterDetails.User_Authentication(username);

                    //if (userId <= 0)
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Incorrect Username or Password')", true);
                    //}

                    //if (userId > 0)
                    //{
                    //    Session["username"] = Txt_username.Text;
                    //    string a = (string)(Session["username"]);
                    //    var regexItem = new Regex("_");
                    //    string ITDANAME = string.Empty;
                    //    if (dtUser.Rows.Count > 0)
                    //    {
                    //        Session["userprevilages"] = dtUser.Rows[0]["User_privileges"].ToString();
                    //    }

                    //    if (regexItem.IsMatch(a))
                    //    {
                    //        var range = a.IndexOf('_');

                    //        string start = a.Substring(0, range);
                    //        ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                    //        Session["ITDANAME"] = ITDANAME;
                    //    }
                    //    if (Txt_username.Text == "DTW")
                    //    {
                    //        Session["ITDANAME"] = "Dtw";
                    //    }
                    //    IPAddress = GetIPAddress();
                    //    MacAddress = "";
                    //    Session["IPAddress"] = IPAddress;
                    //    Session["MacAddress"] = MacAddress;
                    //    ProjectRofrBAL.GetMasterDetails.User_Authenticationlog(username, HttpContext.Current.Request.UserHostAddress, "Login");
                    //    if (dtUser.Rows[0]["IsRofr"].ToString() == "False")
                    //    {

                    //        Response.Redirect("LAND_TRANSFER_REGULATION.aspx");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("~//test//loginhome.aspx");
                    //    }

                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Incorrect Username or Password')", true);
                    //    Txt_pwd.Text = "";
                    //    Txt_username.Text = "";
                    //}

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_log_out(object sender, EventArgs e)
        {
            try
            {
                ProjectRofrBAL.GetMasterDetails.User_Authenticationlog((string)(Session["username"]), HttpContext.Current.Request.UserHostAddress, "Logout");
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                string user = (string)(Session["username"]);

                Response.Redirect("Giribhumi.aspx");
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
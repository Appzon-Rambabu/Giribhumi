using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;

namespace ROFR.Errors
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetAllowResponseInBrowserHistory(false);
           
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
         
            //Response.AddHeader("Cache-Control", "no-cache,private, no-store, must-revalidate, pre-check=0, post-check=0,max-stale=0,Accept,Accept-Encoding,Accept-Language,Cache-Control,Content-Type,Host,Origin,Pragma,Referer,User-Agent,username,sessionid");
            //Response.AddHeader("Pragma", "no-cache");
            //Response.AddHeader("Expires", "0");
            //Response.Headers.Remove("X-AspNet-Version");
            //Response.Headers.Remove("X-AspNetMvc-Version");
            //Response.Headers.Remove("X-Powered-By");
            //Response.Headers.Remove("Server");

            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            HttpContext.Current.Response.Headers.Remove("Server");

            //HttpContext.Current.Response.AddHeader("X-Frame-Options", "DENY");
            HttpContext.Current.Response.AddHeader("X-XSS-Protection", "1; mode=block");
            HttpContext.Current.Response.AddHeader("X-Content-Type-Options", "nosniff");
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache,private, no-store, must-revalidate,max-stale=0, post-check=0, pre-check=0");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");

            HttpContext.Current.Response.AddHeader("X-Permitted-Cross-Domain-Policies", "none");
            HttpContext.Current.Response.AddHeader("Strict-Transport-Security", "max-age=31536000; includeSubDomains");

            HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "script-src 'self'; report-uri: https://giribhumi.ap.gov.in;");
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }
            try
            {

                if (!IsPostBack)
                {

                  
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Linklgn_Click(object sender, EventArgs e)
        {
            try
            {

                Response.Redirect("../pages/Login.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
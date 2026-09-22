using ROFR.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ROFR.pages
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label myLabel = this.FindControl("logouttext") as Label;
            myLabel.Text = "Logout Successfully";

            //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Logout Successfully')", true);
            string user = (string)(Session["masterusername"]);
            // ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["masterusername"]), "0","");
            ProjectRofrBAL.GetMasterDetails.User_Authentication_logout_update((string)(Session["masterusername"]), "0", DateTime.Now.ToString(), (string)(Session["Login"]));
            ProjectRofrBAL.GetMasterDetails.User_Authenticationlog((string)(Session["masterusername"]), HttpContext.Current.Request.UserHostAddress, "Logout");
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
              
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();

                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.AddHeader("Cache-Control", "no-cache,private, no-store, must-revalidate,max-stale=0, post-check=0, pre-check=0");
                Response.AddHeader("Pragma", "no-cache");
                Response.AddHeader("Expires", "0");

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
                //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                ReGenerateSessionId();
               // Response.Redirect("dashboard.aspx");
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ReGenerateSessionId()
        {
            SessionIDManager manager = new SessionIDManager();
            string oldId = manager.GetSessionID(System.Web.HttpContext.Current);
            string newId = manager.CreateSessionID(System.Web.HttpContext.Current);
            bool isAdd = false, isRedir = false;
            manager.RemoveSessionID(System.Web.HttpContext.Current);
            manager.SaveSessionID(System.Web.HttpContext.Current, newId, out isRedir, out isAdd);
            HttpApplication ctx = (HttpApplication)System.Web.HttpContext.Current.ApplicationInstance;
            HttpModuleCollection mods = ctx.Modules;
            System.Web.SessionState.SessionStateModule ssm = (SessionStateModule)mods.Get("Session");
            System.Reflection.FieldInfo[] fields = ssm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            SessionStateStoreProviderBase store = null;
            System.Reflection.FieldInfo rqIdField = null, rqLockIdField = null, rqStateNotFoundField = null;
            SessionStateStoreData rqItem = null;
            foreach (System.Reflection.FieldInfo field in fields)
            {
                if (field.Name.Equals("_store")) store = (SessionStateStoreProviderBase)field.GetValue(ssm);
                if (field.Name.Equals("_rqId")) rqIdField = field;
                if (field.Name.Equals("_rqLockId")) rqLockIdField = field;
                if (field.Name.Equals("_rqSessionStateNotFound")) rqStateNotFoundField = field;
                if ((field.Name.Equals("_rqItem")))
                {
                    rqItem = (SessionStateStoreData)field.GetValue(ssm);
                }
            }
            object lockId = rqLockIdField.GetValue(ssm);
            if ((lockId != null) && (oldId != null))
            {
                store.RemoveItem(System.Web.HttpContext.Current, oldId, lockId, rqItem);
            }
            rqStateNotFoundField.SetValue(ssm, true);
            rqIdField.SetValue(ssm, newId);
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
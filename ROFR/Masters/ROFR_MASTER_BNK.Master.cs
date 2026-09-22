using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using ROFR.helper;
using System.Timers;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Helpers;
using System.Web.SessionState;
using System.Reflection;

namespace ROFR.Masters
{
    public partial class ROFR_MASTER_BNK : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
                csrf.InnerHtml = AntiForgery.GetHtml().ToString();
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


                Session["CurrentPage"] = "LTR.aspx";
                Response.Redirect("LTR.aspx");
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
                Session.Clear();
                Session.RemoveAll();
                Response.Redirect("../pages/dashboard.aspx");
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
                ProjectRofrBAL.GetMasterDetails.User_Authentication_logout_update((string)(Session["masterusername"]), "0", DateTime.Now.ToString(), (string)(Session["Login"]));

                string c = (string)(Session["Captcha"]);
                if ((string)(Session["Captcha"]) != (dt.Rows[0]["captcha_update"].ToString()))
                {
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

                    Session.Abandon();
                    Session.Clear();
                    Session.RemoveAll();
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Duplicate User Login Found...Please login again')", true);
                    Response.Redirect("Login.aspx");
                }
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
                DataTable dt = ProjectRofrBAL.GetMasterDetails.User_Authentication((string)(Session["masterusername"]));

                DateTime date = DateTime.Now;
                TimeSpan ts = date - (Convert.ToDateTime(dt.Rows[0]["Login_date"].ToString()));

                if (ts.TotalHours >= 1)
                {
                    // ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["masterusername"]), "0", "");
                    ProjectRofrBAL.GetMasterDetails.User_Authentication_logout_update((string)(Session["masterusername"]), "0", DateTime.Now.ToString(), (string)(Session["Login"]));
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Session Expired');", true);
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


                }
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
    }
}
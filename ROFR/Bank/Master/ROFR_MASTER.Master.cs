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


namespace ROFR.Bank.Master
{
    public partial class ROFR_MASTER : System.Web.UI.MasterPage
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

                // string aspid = Request.Cookies["ASP.NET_SessionId"].ToString();


                if (!IsPostBack)
                {



                    //if (Request.Cookies["ASP.NET_SessionId"] != null)
                    //{
                    //    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    //    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                    //    string guid = Guid.NewGuid().ToString();
                    //    Session["ASP.NET_SessionId"] = guid;

                    //    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", guid));
                    //}

                    if (Session["username"] == null || (string)Session["username"] == "")
                    {
                        Response.Redirect("Login.aspx");

                    }
                    if (((string)(Session["username"]) != null))
                    {
                        UserDatabase ud = new UserDatabase();
                        DataTable dt = ud.checkGetUserId((string)(Session["username"]));
                        if (dt.Rows.Count > 0)
                        {
                            //if ((string)(Session["Captcha"])== (string)(Session["DbCaptcha"]))
                            if (dt.Rows[0]["Login_status"].ToString() == "0")
                            {
                                //Response.Redirect("Login.aspx");
                                if ((string)(Session["username"]) == "PO_CHINTUR" || (string)(Session["username"]) == "Hod_admin" || (string)(Session["username"]) == "master_admin"|| (string)(Session["username"]) == "admin"|| (string)(Session["username"]) == "ITDA_DIRECTOR")
                                {
                                    //Response.Redirect("Login.aspx");
                                }
                                
                                else {
                                   Response.Redirect("Login.aspx");
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Login.aspx");
                        }
                    }
                    string user = string.Empty;
                    if (((string)(Session["username"]) != null))
                    {
                        if ((string)(Session["username"]) == "master_admin")
                        {
                            user = "admin";
                        }
                        else
                        {
                            user = (string)(Session["username"]);
                        }



                        if ((string)(Session["LastLogin"]) != "")
                        {
                            txt_login_dt.Text = (string)(Session["LastLogin"]);
                        }
                        else
                        {
                            txt_login_dt.Text = (string)(Session["Login"]);
                        }


                    }
                    var check = new Regex("_");
                    txt_admin.Text = "Welcome To " + user;
                    // txt_login_dt.Text= (string)(Session["Login"]);


                    if (user != "admin" && !check.IsMatch(user) && user != "PSTW" && user != "TEST" && user == "")
                    {
                        menu2.Style.Add("display", "none");


                        menu1.Style.Add("display", "none");
                        menu_update.Style.Add("display", "none");

                    }
                    if (user == "admin" || user == "VSKP COLLECTOR" || user == "SKLM COLLECTOR" || user == "VZM COLLECTOR" || user == "WG COLLECTOR" || user == "EG COLLECTOR")
                    {
                        masters.Style.Add("display", "none");
                        menu_update.Style.Add("display", "none");
                        dlt_fmr.Style.Add("display", "none");
                        div_p1_p2.Style.Add("display", "none");
                    }



                    if (user != "")
                    {
                        if (check.IsMatch(user))
                        {
                            var s = user.IndexOf('_');

                            string usertype = user.Substring(0, s);
                            string userend = user.Substring(user.LastIndexOf('_') + 1);
                            if (usertype == "STAFF" || usertype == "STAFF1" || usertype == "STAFF2" || usertype == "STAFF3" || usertype == "STAFF4" || usertype == "STAFF5" || usertype == "STAFF6" || usertype == "STAFF7" || usertype == "STAFF8" || usertype == "STAFF9" || usertype == "STAFF10" || usertype == "STAFF11" || usertype == "STAFF12" || usertype == "STAFF13" || usertype == "STAFF14" || usertype == "STAFF15" || usertype == "STAFF16" || usertype == "STAFF17" || usertype == "STAFF18" || usertype == "STAFF19" || usertype == "STAFF20" || usertype == "STAFF21" || usertype == "STAFF22" || usertype == "STAFF23" || usertype == "STAFF24" || usertype == "STAFF25")
                            {
                                masters.Style.Add("display", "none");

                                menu1.Style.Add("display", "none");
                                menu_update.Style.Add("display", "none");
                                rb_oct.Style.Add("display", "none");
                                rb_fw.Style.Add("display", "none");
                                //menu_1_1.Style.Add("display", "none");
                                // memu_1_2.Style.Add("display", "none");
                                dlt_fmr.Style.Add("display", "none");
                                div_ben.Style.Add("display", "none");
                                div_p1_p2.Style.Add("display", "none");
                            }
                            else if (usertype == "PO" || usertype == "PO1" || usertype == "PO2" || usertype == "PO3" || usertype == "PO4" || usertype == "PO5" || usertype == "PO6" || usertype == "PO7" || usertype == "PO8" || usertype == "PO9" || usertype == "PO10" || usertype == "PO11" || usertype == "PO12" || usertype == "PO13" || usertype == "PO14" || usertype == "PO15")
                            {
                                masters.Style.Add("display", "none");
                                menu1.Style.Add("display", "none");
                                menu_update.Style.Add("display", "none");
                                //menu5_0.Style.Add("display", "none");
                                //    menu5_1.Style.Add("display", "none");
                                //    menu5_3.Style.Add("display", "none");
                                // menu_1_1.Style.Add("display", "none");
                                //memu_1_2.Style.Add("display", "none");
                            }
                            else if (usertype == "DTW")
                            {
                                masters.Style.Add("display", "none");
                                menu1.Style.Add("display", "none");
                                menu_update.Style.Add("display", "none");
                                //menu5_2.Style.Add("display", "none");
                                //    menu5_1.Style.Add("display", "none");
                                //    menu5_3.Style.Add("display", "none");
                                // menu_1_1.Style.Add("display", "none");
                                //memu_1_2.Style.Add("display", "none");
                            }
                            else if (usertype == "ROFR")
                            {
                                menu_update.Style.Add("display", "none");
                                menu_add.Style.Add("display", "none");
                                //menu_approval.Style.Add("display", "none");
                                menu_valid.Style.Add("display", "none");
                                menu_ebook.Style.Add("display", "none");
                                menu_reports.Style.Add("display", "none");
                                //menu_1_1.Style.Add("display", "none");
                                //memu_1_2.Style.Add("display", "none");
                                dlt_fmr.Style.Add("display", "none");
                            }
                            //else if (userend == "DIRECTOR")
                            //{
                            //    menu5_1.Style.Add("display", "none");
                            //    menu5_2.Style.Add("display", "none");
                            //}
                        }

                    }

                    if (((string)Session["masterusername"]) == "master_admin"||(string)(Session["username"]) == "prisec_tw")
                    {
                        masters.Style.Add("display", "block");
                        menu_update.Style.Add("display", "block");
                        div_p1_p2.Style.Add("display", "block");

                    }


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
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
using System.Text;
using System.Web.Helpers;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Reflection;

namespace ROFR.Bank.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        string IPAddress;
        string MacAddress;
        char a, b, c, d, e;
        string ct;
        UserDatabase ud = new UserDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ct = GetRandomText();
                // Session["CAPTCHA"] = ct;
                // mainCaptcha.InnerHtml = ct;
                //Image2.ImageUrl = "~/pages/Captcha.aspx?" + DateTime.Now.Ticks.ToString();
                Get_Captcha();


            }
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



        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();

                if (Page.IsValid)
                {

                    ReGenerateSessionId();
                    var username = Txt_username.Text;
                    var password = Txt_pwd.Text;
                    //string captcha = Request.Form["captcha"];
                    string captcha = txtInput.Value;
                    //  string captcha1 = mainCaptcha.InnerHtml;
                    if (captcha != null && captcha != "")
                    {
                        //string string1 = captcha.Replace(" ", "");
                        // string string2 = captcha1.Replace(" ", "");

                        //string string2=string.Empty;


                        if (captcha == (string)Session["CaptchaCode"])
                        {
                            ProjectRofrBAL.GetMasterDetails.User_Authentication_captchaupdate(username, (string)Session["CaptchaCode"]);
                            Session["Captcha"] = (string)Session["CaptchaCode"];



                            dynamic dt = ud.GetUserId(username, password);
                            Session["DbCaptcha"] = dt.dpcaptcha;
                            ProjectRofrBAL.GetMasterDetails.User_Authenticationlog(username, HttpContext.Current.Request.UserHostAddress, "Login");
                            if (dt.userId > 0)
                            {
                                //if ((string)(Session["Captcha"])== (string)(Session["DbCaptcha"]))
                                if (dt.status == "0")
                                {

                                    Session["userprevilages"] = dt.user_previlege;
                                    Session["token"] = dt.tribal;
                                    Session["Login"] = DateTime.Now.ToString();
                                    Session["LastLogin"] = dt.Lastlogin;
                                    if (dt.username == "master_admin" || dt.username == "Hod_admin")
                                    {
                                        Session["username"] = "admin";
                                        Session["masterusername"] = dt.username;
                                        ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["masterusername"]), "1", (string)Session["Login"]);
                                    }
                                    else
                                    {
                                        Session["username"] = dt.username;
                                        Session["masterusername"] = dt.username;
                                        ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["username"]), "1", (string)Session["Login"]);
                                    }
                                    IPAddress = GetIPAddress();
                                    MacAddress = "";
                                    Session["IPAddress"] = IPAddress;
                                    Session["MacAddress"] = MacAddress;

                                    //  ProjectRofrBAL.GetMasterDetails.User_Authentication_update(username, "1");
                                    if (dt.Isrofr == "True")
                                    {
                                        if (dt.newpwd != "")
                                        {
                                            Response.Redirect("loginhome.aspx");
                                        }
                                        else
                                        {
                                            Response.Redirect("Change_Password.aspx");
                                        }
                                    }
                                    else
                                    {


                                        Response.Redirect("LAND_TRANSFER_REGULATION.aspx");
                                    }
                                }

                                else
                                {
                                    //Session.Abandon();
                                    //Session.Clear();
                                    //Session.RemoveAll();
                                    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Duplicate User Login Found...Please login again')", true);
                                    //Response.Redirect("Login.aspx");
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Already User with same username logged-in...Duplicate user cannot login again');", true);
                                    Get_Captcha();
                                    Txt_pwd.Text = "";
                                    Txt_username.Text = "";
                                    txtInput.Value = "";
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Incorrect Username or Password')", true);
                                //ct = GetRandomText();

                                // mainCaptcha.InnerHtml = ct;
                                Get_Captcha();
                                Txt_pwd.Text = "";
                                Txt_username.Text = "";
                                txtInput.Value = "";
                            }
                            //

                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Enter Valid Captcha')", true);
                            txtInput.Value = "";
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Captcha')", true);

                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                //ct = GetRandomText();

                // mainCaptcha.InnerHtml = ct;
                // Get_Captcha();
                Txt_pwd.Text = "";
                Txt_username.Text = "";
                txtInput.Value = "";
            }
        }


        //private string GetRandomText()

        //{

        //    StringBuilder randomText = new StringBuilder();

        //    string alphabets = "012345679";

        //    Random r = new Random();

        //    for (int j = 0; j <5; j++)

        //    {
        //        //randomText.Append(alphabets[r.Next(alphabets.Length)]);

        //     a = (alphabets[r.Next(alphabets.Length)]);
        //     b = (alphabets[r.Next(alphabets.Length)]);
        //       c = (alphabets[r.Next(alphabets.Length)]);
        //       d = (alphabets[r.Next(alphabets.Length)]);
        //        e = (alphabets[r.Next(alphabets.Length)]);

        //    }

        //    // randomText.Append(a + " " + b + " " + " " + c + " " + d + " " + e);

        //    string aa = a.ToString();
        //    string ba = b.ToString();
        //    string ca = c.ToString();
        //    string da = d.ToString();
        //    string ea = e.ToString();
        //    var ss = aa + ba + ca + da + ea;


        //    randomText.Append(ss);
        //    Session["CaptchaCode"] = randomText.ToString();

        //    return Session["CaptchaCode"] as String;

        //}
        private void Get_Captcha()
        {
            try
            {
                // ct = GetRandomText();
                Image2.ImageUrl = "~/pages/Captcha.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void Submit_Click(object sender, EventArgs e)
        {
            AntiForgery.Validate();
            //ct = GetRandomText();

            //mainCaptcha.InnerHtml = ct;
            Get_Captcha();
            txtInput.Value = "";
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
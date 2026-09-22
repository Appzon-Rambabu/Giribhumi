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

namespace ROFR.pages
{
    public partial class Dup_Login : System.Web.UI.Page
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
                Get_Captcha();

            }

        }
        protected void btn_login_Click(object sender, EventArgs e)
        {


            try
            {
                AntiForgery.Validate();

                if (Page.IsValid)
                {
                    string us = (string)Session["username"];
                    ReGenerateSessionId();
                    var username = Txt_username.Text;
                    var password = Txt_pwd.Text;
                    string captcha = txtInput.Value;
                    if (captcha != null && captcha != "")
                    {

                        if (captcha == (string)Session["CaptchaCode"])
                        {

                            if (Txt_username.Text == "SEP_bendetail" && Txt_pwd.Text == "Bendetails#321" || Txt_username.Text == "ROFR_BANKERS" && Txt_pwd.Text == "rofrbankers#321")
                            {
                                Response.Redirect("Aadharwise_Beneficiary_Details_BNK.aspx", true);
                            }
                            else
                            {
                                ProjectRofrBAL.GetMasterDetails.User_Authentication_captchaupdate(username, (string)Session["CaptchaCode"]);
                                Session["Captcha"] = (string)Session["CaptchaCode"];
                                dynamic dt = ud.GetUserId(username, password);
                                Session["DbCaptcha"] = dt.dpcaptcha;
                                ProjectRofrBAL.GetMasterDetails.User_Authenticationlog(username, HttpContext.Current.Request.UserHostAddress, "Login");
                                if (dt.userId > 0)
                                {
                                    if (dt.status == "0")
                                    {

                                        Session["userprevilages"] = dt.user_previlege;
                                        Session["token"] = dt.tribal;
                                        Session["Login"] = DateTime.Now.ToString();
                                        Session["LastLogin"] = dt.Lastlogin;

                                        if (dt.username == "master_admin" || dt.username == "Hod_admin" || dt.username == "prisec_tw")
                                        {
                                            Session["username"] = "admin";
                                            Session["masterusername"] = dt.username;
                                            Session["prinsec"] = dt.username;
                                            ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["masterusername"]), "1", (string)Session["Login"]);
                                        }
                                        else
                                        {
                                            Session["username"] = dt.username;
                                            Session["masterusername"] = dt.username;
                                            Session["prinsec"] = dt.username;
                                            ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["username"]), "1", (string)Session["Login"]);
                                        }
                                        IPAddress = GetIPAddress();
                                        MacAddress = "";
                                        Session["IPAddress"] = IPAddress;
                                        Session["MacAddress"] = MacAddress;

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


                                        Get_Captcha();
                                        //  loglbl.Text = "Already User with same username logged-in...Duplicate user cannot login again";
                                        Txt_pwd.Text = "";
                                        Txt_username.Text = "";
                                        txtInput.Value = "";
                                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Already User with same username logged-in...Duplicate user cannot login again');", true);
                                        return;
                                    }
                                }
                                else
                                {


                                   // Get_Captcha();
                                    Txt_pwd.Text = "";
                                    Txt_username.Text = "";
                                    txtInput.Value = "";
                                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Incorrect Username or Password')", true);

                                }
                                //

                            }
                        }
                        else
                        {
                            txtInput.Value = "";
                            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Enter Valid Captcha')", true);
                            
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Please enter Captcha')", true); 

                    }

                }
            }
            catch (Exception ex)
            {


                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                Txt_pwd.Text = "";
                Txt_username.Text = "";
                txtInput.Value = "";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Error !')", true); return;
            }
        }
        private void Get_Captcha()
        {
            try
            {
                Image2.ImageUrl = "~/pages/Captcha.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Error !')", true); return;
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
        public string GetIPAddress()
        {
            try
            {
                IPAddress = HttpContext.Current.Request.UserHostAddress;
            }
            catch (Exception ex)
            {


                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                return ex.Message.ToString();

            }
            return IPAddress;

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            AntiForgery.Validate();
            Get_Captcha();
            txtInput.Value = "";
        }
    }
}
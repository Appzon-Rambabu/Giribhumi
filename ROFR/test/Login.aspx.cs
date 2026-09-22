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
namespace ROFR.test
{
    public partial class Login : System.Web.UI.Page
    {
        string IPAddress;
        string MacAddress;
        UserDatabase ud = new UserDatabase();
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

        //private string GetMAC()
        //{
        //    string macAddresses = "";
        //    try
        //    {


        //        foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        //        {
        //            if (nic.OperationalStatus == OperationalStatus.Up)
        //            {
        //                nic.GetPhysicalAddress().ToString();
        //                macAddresses = nic.GetPhysicalAddress().ToString();
        //                //int length = address.Length;
        //                //int MODULAS = (address.Length) / 2;

        //                //for (int i = 0; i <= (address.Length); i = address.Length)
        //                //{
        //                //    if (address.Length > 0)
        //                //    {
        //                //        int j = 2;
        //                //        if (j == 2)
        //                //        {
        //                //            start = address.Substring(0, j);
        //                //            //string end1 = address.Substring(3, address.Length-1);
        //                //            //address = end1;
        //                //            string pennies = address.Substring(2);
        //                //            address = pennies;
        //                //            if (address.Length > 0)
        //                //            {
        //                //                end = start + '-';
        //                //            }
        //                //            else
        //                //            {
        //                //                end = start;
        //                //            }
        //                //        }
        //                //        macAddresses += end;
        //                //    }
        //                //}

        //               break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]));
        //    }
        //    return macAddresses;
        //}

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


                if (Page.IsValid)
                {

                    var username = Txt_username.Text;
                    var password = Txt_pwd.Text;
                    string captcha = Request.Form["captcha"];


                    dynamic dt = ud.GetUserId(username, password);

                    if (dt.userId <= 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Incorrect Username or Password')", true);
                        Txt_pwd.Text = "";
                        Txt_username.Text = "";
                    }

                    if (dt.userId > 0)
                    {
                        Session["userprevilages"] = dt.user_previlege;

                        if (dt.username == "master_admin")
                        {
                            Session["username"] = "admin";
                            Session["masterusername"] = dt.username;

                        }
                        else
                        {
                            Session["username"] = dt.username;
                            Session["masterusername"] = dt.username;

                        }






                        IPAddress = GetIPAddress();
                        MacAddress = "";
                        Session["IPAddress"] = IPAddress;
                        Session["MacAddress"] = MacAddress;
                        ProjectRofrBAL.GetMasterDetails.User_Authenticationlog(username, HttpContext.Current.Request.UserHostAddress, "Login");
                        if (dt.Isrofr == "False")
                        {

                            Response.Redirect("LAND_TRANSFER_REGULATION.aspx");
                        }
                        else
                        {
                            Response.Redirect("loginhome.aspx");
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Incorrect Username or Password')", true);
                        Txt_pwd.Text = "";
                        Txt_username.Text = "";
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
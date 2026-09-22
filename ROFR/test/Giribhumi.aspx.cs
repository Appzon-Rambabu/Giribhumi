using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.Text.RegularExpressions;
namespace ROFR.test
{
    public partial class Giribhumi : System.Web.UI.Page
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

            try
            {

                if (!IsPostBack)
                {
                    DataSet dS = ProjectRofrBAL.GetMasterDetails.GetnewDashboard();
                    DataTable dt = dS.Tables[1];
                    DataTable dt1 = dS.Tables[0];
                    //dt1 = calculatetotals(dt);
                    //totalbenificiary.InnerText = dt1.Rows[dt.Rows.Count - 1]["Total_bneficiaries"].ToString();
                    totalbeneficiaries.InnerText = dt1.Rows[dt.Rows.Count - 1]["Giribhumi_beneficiaries"].ToString();
                    Accountsupdated.InnerText = dt1.Rows[dt.Rows.Count - 1]["Bankavaliable"].ToString();
                    Acntsnotupdated.InnerText = dt1.Rows[dt.Rows.Count - 1]["Banknotavaliable"].ToString();
                    Tavailaadhar.InnerText = dt1.Rows[dt.Rows.Count - 1]["total_received"].ToString();
                    Tvalidaadhar.InnerText = dt1.Rows[dt.Rows.Count - 1]["Adhharisvalid"].ToString();
                    Tinvalidaadhar.InnerText = dt1.Rows[dt.Rows.Count - 1]["Adhharnoinvalid"].ToString();
                    Tunavailaadhar.InnerText = dt1.Rows[dt.Rows.Count - 1]["Adhharnotavaliable"].ToString();
                    Session["sessionextent"] = dS.Tables[2].Rows[0]["Total_Extent"].ToString();
                    extent.InnerText = dS.Tables[2].Rows[0]["Total_Extent"].ToString();
                    //latlongsupdated.InnerText = dS.Tables[23].Rows[0]["LatlongsUpdated"].ToString();
                    //latlongsnotupdated.InnerText = dS.Tables[23].Rows[0]["LatlongsnotUpdated"].ToString();
                    //rbsuccess.InnerText = dt.Rows[0]["Payment_Success"].ToString();
                    //rbfail.InnerText = dt.Rows[0]["Payment_Rejected"].ToString();
                    //BindData();
                    BindDistrictcount();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
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

        protected void BindDistrictcount()
        {
            try
            {

                DataSet dS = ProjectRofrBAL.GetMasterDetails.Getdashboard();
                DataTable dt = dS.Tables[0];
                if (dt.Rows.Count > 0)
                {




                    // districts.InnerText= dt.Rows[0]["revienue_dist_count"].ToString();
                    districts.InnerText = dt.Rows[0]["forest_dist_count"].ToString();
                    mandals.InnerText = dt.Rows[0]["forest_mandal_count"].ToString();
                    villages.InnerText = dt.Rows[0]["forest_village_count"].ToString();
                    divisions.InnerText = dt.Rows[0]["forest_division_count"].ToString();
                    ranges.InnerText = dt.Rows[0]["forest_ranges_count"].ToString();
                    beats.InnerText = dt.Rows[0]["forest_beats_count"].ToString();

                    habitations.InnerText = dt.Rows[0]["hab_count"].ToString();


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using ROFR.helper;
namespace ROFR.Masters
{
    public partial class Giribhumi_Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {

                    string user = string.Empty;
                    if ((Session["username"] != null))
                    {
                        user = (string)(Session["username"]);
                    }
                    var check = new Regex("_");
                  txt_admin.Text = "Welcome To " + user;


                    if (user != "admin" && !check.IsMatch(user) && user != "PSTW" && user != "TEST" && user == "")
                    {

                        //menu_1_1.Style.Add("display", "none");
                        //memu_1_2.Style.Add("display", "none");
                    }

                    if (user == "admin")
                    {
                        master.Style.Add("display", "none");
                        master_update.Style.Add("display", "none");
                    }
                    if (user != "")
                    {
                        if (check.IsMatch(user))
                        {
                            var s = user.IndexOf('_');

                            string usertype = user.Substring(0, s);
                            string userend = user.Substring(user.LastIndexOf('_') + 1);

                            if (usertype == "STAFF")
                            {
                                master.Style.Add("display", "none");
                                master_update.Style.Add("display", "none");
                                menu_approval.Style.Add("display", "none");
                            }
                            else if (usertype == "PO")
                            {
                                master.Style.Add("display", "none");
                                master_update.Style.Add("display", "none");
                            }
                            else if (usertype == "DTW")
                            {

                                master.Style.Add("display", "none");
                                master_update.Style.Add("display", "none");
                            }
                            else if (usertype == "master")
                            {

                                master.Style.Add("display", "block");
                                master_update.Style.Add("display", "block");
                            }
                            else if (usertype == "ROFR")
                            {
                                master_update.Style.Add("display", "none");
                                menu_reg.Style.Add("display", "none");
                                menu_valid.Style.Add("display", "none");
                                menu_ebook.Style.Add("display", "none");
                                menu_reports.Style.Add("display", "none");
                            }

                        }
                    }

                    if (((string)Session["masterusername"]) == "master_admin")
                    {
                        master.Style.Add("display", "block");
                        master_update.Style.Add("display", "block");
                        //  menu5_4.Style.Add("display", "block");
                        //  menu5_5.Style.Add("display", "block");
                    }

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
    }
}
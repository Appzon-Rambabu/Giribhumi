using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.IO;
using System.Web.Helpers;
using System.Text.RegularExpressions;

namespace ROFR.pages
{
    public partial class Change_Password : System.Web.UI.Page
    {
        UserDatabase ud = new UserDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                var username = txt_username.Text;
                var password = txt_oldpwd.Text;
                //txt_newpwd.Text = "Admin#321";
                if (!string.IsNullOrEmpty(txt_username.Text))
                {
                    if (!string.IsNullOrEmpty(txt_oldpwd.Text))
                    {
                        if (!string.IsNullOrEmpty(txt_newpwd.Text))
                        {
                            if (txt_newpwd.Text.Length >= 8 && txt_newpwd.Text.Length <= 15)
                            {
                                if (!txt_newpwd.Text.Any(char.IsUpper))
                                {
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Password must contain atleast one Upper character')", true);
                                }
                                else
                                {
                                    if (!txt_newpwd.Text.Any(char.IsLower))
                                    {
                                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Password must contain atleast one Lower character')", true);
                                    }
                                    else
                                    {
                                        Regex no = new Regex("[^0-9]");
                                        if(!txt_newpwd.Text.Any(char.IsDigit))
                                        {
                                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Password must contain atleast one numeric character')", true);
                                        }
                                        else
                                        {
                                            Regex spl = new Regex("[@#$&*_]");
                                            if (!spl.IsMatch(txt_newpwd.Text))
                                            {
                                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Password must contain atleast one special character  @ # $ & *_')", true);
                                            }
                                            else
                                            {


                                                if (txt_newpwd.Text == txt_cnfpwd.Text)
                                                {

                                                    if(username!="admin")
                                                    {

                                                        dynamic dt = ud.GetPassword(username, password);


                                                        if (dt.userId > 0)
                                                        {


                                                            Session["userprevilages"] = dt.user_previlege;
                                                            dynamic udt = ud.Update_Password(dt.username, dt.pwd, txt_newpwd.Text, txt_oldpwd.Text);
                                                            if (udt.status == "1")
                                                            {
                                                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Password Changed Successfully')", true);
                                                                txt_username.Text = "";
                                                                txt_oldpwd.Text = "";
                                                                txt_newpwd.Text = "";
                                                                txt_cnfpwd.Text = "";
                                                            }
                                                            else if (udt.status == "101")
                                                            {
                                                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Updation Failed..Old password and New password cannot be the same')", true);
                                                                txt_username.Text = "";
                                                                txt_oldpwd.Text = "";
                                                                txt_newpwd.Text = "";
                                                                txt_cnfpwd.Text = "";
                                                            }
                                                            else
                                                            {
                                                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Updation Failed')", true);

                                                            }
                                                        }
                                                        else
                                                        {
                                                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Incorrect Username or Old Password')", true);

                                                        }
                                                    }
                                                    else
                                                    {
                                                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Admin  Password cannot be changed')", true);
                                                    }

                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('New Password and Confirm Password are not matched')", true);

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Password must contain min 8 and maximum 15 characters')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter Password')", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter Old Password')", true);

                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter Username')", true);

                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message) ;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error ! " + ex.Message + "')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void btn_reset_Click(object sender, EventArgs e)
        {
            txt_username.Text = "";
            txt_oldpwd.Text = "";
            txt_newpwd.Text = "";
            txt_cnfpwd.Text = "";
        }

        protected void link_click(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx");

        }
    }
}
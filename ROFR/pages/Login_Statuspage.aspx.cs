using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
    public partial class Login_Statuspage : System.Web.UI.Page
    {
        UserDatabase ud = new UserDatabase();

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Visible = false;
        }

        protected void Txt_username_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
               
                    if (Txt_username.Text == "")
                    {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Please Enter username !')", true);
                    Response.Redirect("Login_Statuspage.aspx", true);
                   
                    }
                    else
                    {
                    string username = Txt_username.Text.ToString();
                    string type = "17";
                    dynamic dt = ud.Loginstatus(username, type);
                    if (dt.status == 1)
                    {
                        Button1.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('User Status is Inactive. PLease login...!')", true);
                        Txt_username.Text = "";
                        Button1.Visible = false;
                       
                    }
                }
                
                
            }
            catch (Exception ex)
            {


                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
               
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Error !')", true); return;
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string username = Txt_username.Text.ToString();
            string type = "18";
            dynamic dt = ud.Loginstatus(username, type);
            if (dt.status == 1)
            {
                Button1.Visible = false;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ClientScript", "alert('Logout  !')", true);
                Response.Redirect("Login_Statuspage.aspx", true);
            }
            else
            {
                Button1.Visible = true;
            }
                
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Helpers;
using ROFR.helper;
using System.Web.Services;

namespace ROFR.pages
{
    public partial class Update_Land_Image : System.Web.UI.Page
    {
        string ct = string.Empty;
        char a, b, c, d, e;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user.InnerHtml = (string)Session["userprevilages"];
                string a = string.Empty;
               
                string USERNAME = (string)Session["username"];
                string ip= (string)(Session["IPAddress"]);
                
                if (!string.IsNullOrEmpty(USERNAME))
                {
                    a = USERNAME;
                }
                else
                {
                    a = "admin123";
                }
                var regexItem = new Regex("_");
                string start = string.Empty;
                string ITDANAME = string.Empty;
                if (regexItem.IsMatch(a))
                {
                    var range = a.IndexOf('_');

                    start = a.Substring(0, range);
                    ITDANAME = a.Substring(a.LastIndexOf('_') + 1);
                }
                ustart.InnerHtml = start.ToString();
                end.InnerHtml = ITDANAME.ToString();
                username.InnerHtml = USERNAME.ToString();
                ipadress.InnerHtml = ip.ToString();
                tk.InnerHtml = (string)Session["token"];
           
               
            }
        }

        private string GetRandomText()

        {

            StringBuilder randomText = new StringBuilder();

            string alphabets = "012345679";

            Random r = new Random();

            for (int j = 0; j < 5; j++)

            {
                //randomText.Append(alphabets[r.Next(alphabets.Length)]);

                a = (alphabets[r.Next(alphabets.Length)]);
                b = (alphabets[r.Next(alphabets.Length)]);
                c = (alphabets[r.Next(alphabets.Length)]);
                d = (alphabets[r.Next(alphabets.Length)]);
                e = (alphabets[r.Next(alphabets.Length)]);

            }

            // randomText.Append(a + " " + b + " " + " " + c + " " + d + " " + e);

            string aa = a.ToString();
            string ba = b.ToString();
            string ca = c.ToString();
            string da = d.ToString();
            string ea = e.ToString();
            var ss = aa + ba + ca + da + ea;


            randomText.Append(ss);
            Session["JCaptchaCode"] = randomText.ToString();

            return Session["JCaptchaCode"] as String;

        }
        //private void Get_Captcha()
        //{
        //    try
        //    {
        //        ct = GetRandomText();
        //        Image2.ImageUrl = "~/pages/JCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
              
        //     cpt.InnerHtml = ct;
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}
        //protected void Submit_Click(object sender, EventArgs e)
        //{
        //    AntiForgery.Validate();
        //    cpt.InnerHtml = "";
        //   ct = GetRandomText();
        //    Image2.ImageUrl = "~/pages/JCaptcha.aspx?" + DateTime.Now.Ticks.ToString();

        //    //cpt.InnerHtml = ct;
        //    cpt.InnerHtml = ct;
        //}

        //[WebMethod]
        //private void Get_Captcha_n()
        //{
        //    try
        //    {
        //        ct = GetRandomText();
        //        Image2.ImageUrl = "~/pages/JCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
               
        //        cpt.InnerHtml = ct;
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}
    }
}
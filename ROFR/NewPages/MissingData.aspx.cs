using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace ROFR.NewPages
{
    public partial class MissingData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                userprevilages.InnerHtml = (string)Session["userprevilages"];
                string a = string.Empty;

                string USERNAME = (string)Session["username"];
                string ip = (string)(Session["IPAddress"]);

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
    }
}
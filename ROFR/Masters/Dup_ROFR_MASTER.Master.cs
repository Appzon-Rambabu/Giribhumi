using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
namespace ROFR.Masters
{
    public partial class Dup_ROFR_MASTER : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            try
            {
                csrft.InnerHtml = AntiForgery.GetHtml().ToString();
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)

            {

                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                    string guid = Guid.NewGuid().ToString();
                    Session["ASP.NET_SessionId"] = guid;
                    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", guid));
                }
            }
        }
    }
}
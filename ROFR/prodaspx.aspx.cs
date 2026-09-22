using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.Net;
using ROFR.getEGSJobCardInfoByUIDser;

namespace ROFR
{
    public partial class prodaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Label myLabel = this.FindControl("noofrec") as Label;

                try
                {
              
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    APHousingWS obj = new APHousingWS();
                    var response = obj.WorkDetailsCapturingByUID("732593694873");
                    myLabel.Text = response.ToString();
                }
                catch (Exception ex)
                {
                    myLabel.Text = ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException;
                }
            }
            catch (Exception ex)
            {
                Label myLabel = this.FindControl("noofrec") as Label;
                myLabel.Text = ex.ToString();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
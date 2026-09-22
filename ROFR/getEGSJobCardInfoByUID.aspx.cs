using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;

namespace ROFR
{
    public partial class getEGSJobCardInfoByUID : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               getEGSJobCardInfoByUIDser.APHousingWS obj = new getEGSJobCardInfoByUIDser.APHousingWS();

                var a = obj.getEGSJobCardInfo("755520508165");
                Label myLabel = this.FindControl("noofrec") as Label;
                myLabel.Text = a.ToString();
             

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
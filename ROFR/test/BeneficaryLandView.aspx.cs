using ROFR.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ROFR.test
{
    public partial class BeneficaryLandView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if ((string)(Session["BeneficarylandviewMapid"]) != "")
                {
                    Session["BeneficarylandviewMapid"] = (string)(Session["BeneficaryMapid"]);
                    mapland.Value = (string)(Session["BeneficarylandviewMapid"]);
                }
                else
                {
                    Response.Redirect("~//test//loginhome.aspx");
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
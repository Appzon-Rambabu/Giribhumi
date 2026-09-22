using ROFR.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ROFR.pages
{
    public partial class BeneficaryLandView : System.Web.UI.Page
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if ((string)(Session["BeneficarylandviewMapid"]) != "")
        //        {
        //            Session["BeneficarylandviewMapid"] = (string)(Session["BeneficaryMapid"]);
        //            mapland.Value = (string)(Session["BeneficarylandviewMapid"]);
        //        }
        //        else
        //        {
        //            Response.Redirect("loginhome.aspx");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Headers.Remove("X-Frame-Options");
            Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");

            Response.Headers.Add("X-Debug-Frame", "TEST123");

            try
            {
                string mapId = Convert.ToString(Session["BeneficaryMapid"]);

                if (!string.IsNullOrWhiteSpace(mapId))
                {
                    Session["BeneficarylandviewMapid"] = mapId;
                    mapland.Value = mapId;
                }
                else
                {
                    mapland.Value = "";
                }
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(
                    ex,
                    this.GetType().Name + "/" +
                    System.Reflection.MethodBase.GetCurrentMethod().Name,
                    Convert.ToString(Session["username"]),
                    HttpContext.Current.Request.UserHostAddress
                );
            }
        }
    }
}
using CrystalDecisions.CrystalReports.Engine;
using ROFR.helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ROFR
{
    public partial class sampledatapage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Landsettlementpattas.BeneficiaryePassbook("650504040", "admin", "admin");
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/Datadisplay.rpt"));


                crystalReport.Database.Tables["DataTable4"].SetDataSource(ds.Tables[0]);
             
                string cfilename = "Report.pdf";

                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "EPASSBOOK");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
           
        }
    }
}
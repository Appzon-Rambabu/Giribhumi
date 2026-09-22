using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;

namespace ROFR.test
{
    public partial class GetOracleData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    BindData();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void BindData()
        {
            try
            {

                rofrObject rofrObjectobj = new rofrObject();
                DataTable dt = Landsettlementpattas.GetGirimandalMasterAnalysis(rofrObjectobj);
              
                // dt = calculatetotals(dt);
                if (dt.Rows.Count > 0)
                {
                   
                    GridView1.DataSource = dt;

                    GridView1.DataBind();


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void link_onclick(object sender, EventArgs e)
        {
           

        }

        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dS = ProjectRofrBAL.GetMasterDetails.GetBeneficiaryDetailsAnalysis("", (string)(Session["username"]));
                DataTable dt = dS.Tables[0];
               // dt = calculatetotals(dt);
                dt.Columns["ITDA_NAME"].ColumnName = "ITDA NAME";
                dt.Columns["District"].ColumnName = "DISTRICT";
                dt.Columns["Total_bneficiaries"].ColumnName = "Total Beneficiaries Records";
                dt.Columns["Total_ROFR_PATTADAAR"].ColumnName = "No of Beneficiaries Records Having PATTADAR NAME";
                dt.Columns["ROFR_PATTDAAR_Blank"].ColumnName = "No of Beneficiaries Records Not Having PATTDAR NAME";
                dt.Columns["total_received"].ColumnName = "No of Beneficiaries Records Having Aadhar No";
                dt.Columns["Adhharisvalid"].ColumnName = "No of Beneficiaries Records Having Aadhar No Valid Records";
                dt.Columns["Adhharnoinvalid"].ColumnName = "No of Beneficiaries Records Having Aadhar No InValid Records";
                dt.Columns["Adhharnotavaliable"].ColumnName = "No of Beneficiaries Records Not Having Adhhar No";
                dt.Columns["Bankavaliable"].ColumnName = "No of Beneficiaries Records  Having Bank Details";
                dt.Columns["Banknotavaliable"].ColumnName = "No of Beneficiaries Records Not Having Bank Details";
                if (dt.Rows.Count > 0)
                {
                    string filename = "beneficiariesDataAnalysisExcel.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();

                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btnexcel_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
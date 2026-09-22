using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;

namespace ROFR.test
{
    public partial class DataAnalysis_NonMandatoryFields : System.Web.UI.Page
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

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetNonMandatoryFieldsAnalysis("", (string)(Session["userprevilages"]), (string)(Session["username"]));

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

        protected void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetNonMandatoryFieldsAnalysis("", (string)(Session["userprevilages"]), (string)(Session["username"]));

               
                dt.Columns["ITDA_NAME"].ColumnName = "ITDA NAME";
                dt.Columns["District"].ColumnName = "DISTRICT";
                dt.Columns["TOTAL_BENEFICIARIES"].ColumnName = "TOTAL BENEFICIARIES";
                dt.Columns["TOTAL_PLOTS"].ColumnName = "TOTAL PLOTS";
                dt.Columns["HAVING_MANDAL_CODE"].ColumnName = "NO. OF PLOTS HAVING MANDAL CODE";
                dt.Columns["not_HAVING_MANDAL_CODE"].ColumnName = "NO. OF PLOTS NOT HAVING MANDAL CODE";
                dt.Columns["HAVING_VILLAGE_CODE"].ColumnName = "NO. OF PLOTS HAVING VILLAGE CODE";
                dt.Columns["not_HAVING_VILLAGE_CODE"].ColumnName = "NO. OF PLOTS NOT HAVING VILLAGE CODE";
                dt.Columns["GRAM_PANCHAYAT_CODE"].ColumnName = "NO. OF PLOTS HAVING GRAM PANCHAYAT CODE";
                dt.Columns["not_GRAM_PANCHAYAT_CODE"].ColumnName = "NO. OF PLOTS NOT HAVING GRAM PANCHAYAT CODE";
                dt.Columns["Habitation_CODE"].ColumnName = "NO. OF PLOTS HAVING HABITATION CODE";
                dt.Columns["not_having_Habitation_CODE"].ColumnName = "NO. OF PLOTS NOT HAVING HABITATION CODE";
                dt.Columns["HAVING_FOREST_DIVISION_CODE"].ColumnName = "NO. OF PLOTS HAVING FOREST DIVISION CODE";
                dt.Columns["not_HAVING_FOREST_DIVISION_CODE"].ColumnName = "NO. OF PLOTS NOT HAVING FOREST DIVISION CODE";
                dt.Columns["HAVING_FOREST_RANGE_CODE"].ColumnName = "NO. OF PLOTS HAVING FOREST RANGE CODE ";
                dt.Columns["not_HAVING_FOREST_RANGE_CODE"].ColumnName = "NO. OF PLOTS NOT HAVING FOREST RANGE CODE";
                dt.Columns["HAVING_FOREST_BEAT_CODE"].ColumnName = "NO. OF PLOTS HAVING FOREST BEAT CODE";
                dt.Columns["not_HAVING_FOREST_BEAT_CODE"].ColumnName = "NO. OF PLOTS NOT HAVING FOREST BEAT CODE";
                dt.Columns["PLOTS_HAVING_Uncultivable_Land"].ColumnName = "NO. OF PLOTS HAVING UNCULTIVABLE LAND";
                dt.Columns["PLOTS_NOT_HAVING_Uncultivable_Land"].ColumnName = "NO. OF PLOTS NOT HAVING UNCULTIVABLE LAND";
                dt.Columns["HAVING_Cultivable_Land"].ColumnName = "NO. OF PLOTS HAVING CULTIVABLE LAND";
                dt.Columns["NOT_HAVING_Cultivable_Land"].ColumnName = "NO. OF PLOTS NOT HAVING CULTIVABLE LAND";

                dt.Columns["PLOTS_HAVING_Water_Tax"].ColumnName = "NO. OF PLOTS HAVING WATER TAX";
                dt.Columns["PLOTS_NOT_HAVING_Water_Tax"].ColumnName = "NO. OF PLOTS NOT HAVING WATER TAX";
                dt.Columns["HAVING_DRYID_ONECROP_TWO_CROP"].ColumnName = "NO. OF PLOTS HAVING DRYID ONECROP TWOCROP";
                dt.Columns["NOT_HAVING_DRYID_ONECROP_TWO_CROP"].ColumnName = "NO. OF PLOTS NOT HAVING DRYID ONECROP TWOCROP";
                dt.Columns["PLOTS_HAVING_WATER_SOURCE"].ColumnName = "NO. OF PLOTS HAVING WATER SOURCE";
                dt.Columns["PLOTS_NOT_HAVING_WATER_SOURCE"].ColumnName = "NO. OF PLOTS NOT HAVING WATER SOURCE";

                dt.Columns["PLOTS_HAVING_EXTENT_IRRIGATED"].ColumnName = "NO. OF PLOTS HAVING EXTENT IRRIGATED";
                dt.Columns["PLOTS_NOT_HAVING_EXTENT_IRRIGATED"].ColumnName = "NO. OF PLOTS NOT HAVING EXTENT IRRIGATED";
                dt.Columns["PLOTS_HAVING_EXTENT_UNDER_CULTIVATOR"].ColumnName = "NO. OF PLOTS HAVING EXTENT UNDER CULTIVATOR";
                dt.Columns["PLOTS_NOT_HAVING_EXTENT_UNDER_CULTIVATOR"].ColumnName = "NO. OF PLOTS NOT EXTENT UNDER CULTIVATOR";
                dt.Columns["PLOTS_HAVING_TYPE_CODE"].ColumnName = "NO. OF PLOTS HAVING TYPE CODE";
                dt.Columns["PLOTS_NOT_HAVING_TYPE_CODE"].ColumnName = "NO. OF PLOTS NOT HAVING TYPE CODE";
                dt.Columns["PLOTS_HAVING_NET_SOWN_AREA"].ColumnName = "NO. OF PLOTS HAVING NET SOWN AREA";
                dt.Columns["PLOTS_NOT_HAVING_NET_SOWN_AREA"].ColumnName = "NO. OF PLOTS NOT HAVING NET SOWN AREA";
                dt.Columns["PLOTS_HAVING_KHARIFF_RABI"].ColumnName = "NO. OF PLOTS HAVING KHARIFF/RABI";
                dt.Columns["PLOTS_NOT_HAVING_KHARIFF_RABI"].ColumnName = "NO. OF PLOTS NOT HAVING KHARIFF/RABI";
                dt.Columns["PLOTS_HAVING_MONTH_OF_CULTIVATION"].ColumnName = "NO. OF PLOTS HAVING MONTH OF CULTIVATION";
                dt.Columns["PLOTS_NOT_HAVING_MONTH_OF_CULTIVATION"].ColumnName = "NO. OF PLOTS NOT HAVING MONTH OF CULTIVATION";
                dt.Columns["PLOTS_HAVING_CROP"].ColumnName = "NO. OF PLOTS HAVING CROP";
                dt.Columns["PLOTS_NOT_HAVING_CROP"].ColumnName = "NO. OF PLOTS NOT HAVING CROP";
                dt.Columns["PLOTS_HAVING_EXTENT_SINGLE"].ColumnName = "NO. OF PLOTS HAVING EXTENT SINGLE";
                dt.Columns["PLOTS_NOT_HAVING_EXTENT_SINGLE"].ColumnName = "NO. OF PLOTS NOT HAVING EXTENT SINGLE";
                dt.Columns["PLOTS_HAVING_EXTENT_MIXED"].ColumnName = "NO. OF PLOTS HAVING EXTENT MIXED";
                dt.Columns["PLOTS_NOT_HAVING_EXTENT_MIXED"].ColumnName = "NO. OF PLOTS NOT HAVING EXTENT MIXED";
                dt.Columns["PLOTS_HAVING_EXTENT_TOTAL"].ColumnName = "NO. OF PLOTS HAVING EXTENT TOTAL";
                dt.Columns["PLOTS_NOT_HAVING_EXTENT_TOTAL"].ColumnName = "NO. OF PLOTS NOT HAVING EXTENT TOTAL";
                dt.Columns["PLOTS_HAVING_FIRST_CROP"].ColumnName = "NO. OF PLOTS HAVING FIRST CROP";
                dt.Columns["PLOTS_NOT_HAVING_FIRST_CROP"].ColumnName = "NO. OF PLOTS NOT HAVING FIRST CROP";
                dt.Columns["PLOTS_HAVING_SECOND_THIRD_CROP"].ColumnName = "NO. OF PLOTS HAVING SECOND THIRD CROP";
                dt.Columns["PLOTS_NOT_HAVING_SECOND_THIRD_CROP"].ColumnName = "NO. OF PLOTS NOT HAVING SECOND THIRD CROP";
                dt.Columns["PLOTS_HAVING_CROP_YIELD"].ColumnName = "NO. OF PLOTS HAVING SECOND CROP YIELD";
                dt.Columns["PLOTS_NOT_HAVING_CROP_YIELD"].ColumnName = "NO. OF PLOTS NOT HAVING CROP YIELD";
                dt.Columns["PLOTS_HAVING_REMARKS"].ColumnName = "NO. OF PLOTS HAVING REMARKS";
                dt.Columns["PLOTS_NOT_HAVING_REMARKS"].ColumnName = "NO. OF PLOTS NOT HAVING REMARKS";


                if (dt.Rows.Count > 0)
                {
                    string filename = "DATAANALYSIS_FOR_NONMANDATORYFIELDS.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();

                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();





                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;

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
    }
}
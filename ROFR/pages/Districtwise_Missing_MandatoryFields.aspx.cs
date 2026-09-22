using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;

namespace ROFR.pages
{
    public partial class Districtwise_Missing_MandatoryFields : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
          
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    BindItda();

                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    btn_excel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindItda()
        {
            try

            {


                DataTable dtItda = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);

                if (dtItda.Rows.Count > 0)
                {
                    ddl_Itda.DataSource = dtItda;
                    ddl_Itda.DataTextField = "ITDA_NAME";
                    ddl_Itda.DataValueField = "ITDA_CODE";
                    ddl_Itda.DataBind();
                    ddl_Itda.Items.Insert(0, new ListItem("Select", "0"));
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

        private void BindDistrict(DataTable dt)
        {
            try
            {
                DataTable dtDistricts = dt;
                ddl_district.DataSource = dtDistricts;
                ddl_district.DataTextField = "DISTRICT_NAME";
                ddl_district.DataValueField = "LGD_DISTRICT_CODE";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void ddl_Itda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                GridView1.DataSource = null;
                GridView1.DataBind();
                btn_excel.Visible = false;
                if (ddl_Itda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                  


                    DataTable dtdistrict = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "District", ddl_Itda.SelectedValue, "", "", "", "", (string)Session["userprevilages"]);
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                       
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }


        }

        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                GridView1.DataSource = null;
                GridView1.DataBind();

                if (ddl_Itda.SelectedItem.Text != "Select")
                {

                    GridView1.DataSource = null;

                    GridView1.DataBind();
                    btn_excel.Visible = true;
                    DataTable dt = Landsettlementpattas.GetDistrictMissingData(ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }


                }
                else
                {


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void txtSearch_Click(object sender, EventArgs e)
        {
        }


        protected void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Landsettlementpattas.GetDistrictMissingData(ddl_Itda.SelectedItem.Text,ddl_district.SelectedItem.Text);


                dt.Columns["Id"].ColumnName = "ID";

                dt.Columns["ITDA_NAME"].ColumnName = "ITDA NAME";
              

                dt.Columns["District"].ColumnName = "DISTRICT";
                dt.Columns["Mandal"].ColumnName = "MANDAL";
                dt.Columns["Gram_Panchayat"].ColumnName = "GRAM PANCHAYAT";
                dt.Columns["REV_Village"].ColumnName = "REVENUE VILLAGE";
                dt.Columns["Village"].ColumnName = "VILLAGE";
                dt.Columns["Habitation"].ColumnName = "HABITATION";
                dt.Columns["Forest_Division"].ColumnName = "FOREST DIVISION";
                dt.Columns["Forest_Range"].ColumnName = "FOREST RANGE";
                dt.Columns["Forest_Beat"].ColumnName = "FOREST BEAT";
                dt.Columns["Forest_Block"].ColumnName = "FOREST BLOCK";
                dt.Columns["Compartment_No"].ColumnName = "COMPARTMENT NO";
                dt.Columns["Plot_No"].ColumnName = "PLOT NO";
                dt.Columns["ExtentPlotArea"].ColumnName = "EXTENT PLOT AREA";
                dt.Columns["ROFR_PATTANO"].ColumnName = "ROFR PATTA NO";
                dt.Columns["ROFR_PATTADAAR"].ColumnName = "ROFR PATTADAAR";
                dt.Columns["CULTIVATOR_NAME"].ColumnName = "CULTIVATOR NAME";
                dt.Columns["FATHER_NAME"].ColumnName = "FATHER NAME";
                dt.Columns["SUB_CASTE"].ColumnName = "SUB CASTE";
                dt.Columns["Aadhaar_NO"].ColumnName = "AADHAR NO";
                dt.Columns["Uncultivable_Land"].ColumnName = "UNCULTIVABLE LAND";
                dt.Columns["Cultivable_Land"].ColumnName = "CULTIVABLE LAND";
                dt.Columns["PATTA_INAMGOVT"].ColumnName = "PATTA INAM/GOVT";
                dt.Columns["DRYID_ONECROP_TWO_CROP"].ColumnName = "DRYID ONECROP/TWOCROP";
                dt.Columns["WATER_SOURCE"].ColumnName = "WATER SOURCE";
                dt.Columns["EXTENT_IRRIGATED"].ColumnName = "EXTENT IRRIGATED";
                dt.Columns["EXTENT_UNDER_CULTIVATOR"].ColumnName = "EXTENT UNDER CULTIVATOR";
                dt.Columns["Land_Classification_Name"].ColumnName = "LAND CLASSIFICATION";
                dt.Columns["HOLDING_NATURE"].ColumnName = "HOLDING NATURE";
                dt.Columns["EXTENT"].ColumnName = "EXTENT";
                dt.Columns["NET_SOWN_AREA"].ColumnName = "NET SOWN AREA";
                dt.Columns["MONTH_OF_CULTIVATION"].ColumnName = "MONTH OF CULTIVATION";
                dt.Columns["CROP"].ColumnName = "CROP(SINGLE/MIXED)";
                dt.Columns["TOTAL"].ColumnName = "TOTAL";
                dt.Columns["FIRST_CROP"].ColumnName = "FIRST CROP";
                dt.Columns["SECOND_THIRD_CROP"].ColumnName = "SECOND/THIRD CROP";
                dt.Columns["CROP_YIELD"].ColumnName = "CROP YIELD";
                dt.Columns["REMARKS"].ColumnName = "REMARKS";
                dt.Columns["BankAccountNo"].ColumnName = "BANK ACCOUNT NO.";
                dt.Columns["IfscCode"].ColumnName = "IFSC CODE";
                dt.Columns["BankName"].ColumnName = "BANK NAME";
                dt.Columns["SINGLE"].ColumnName = "EXTENT SINGLE";
                dt.Columns["MIXED"].ColumnName = "EXTENT MIXED";
                if (dt.Rows.Count > 0)
                {
                    string filename = "DISTRICTWISE_MISSING_MANDATORYFIELDS.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    
                    DataGrid dgGrid = new DataGrid();
                    
               
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
             
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.LightSalmon;
                   


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
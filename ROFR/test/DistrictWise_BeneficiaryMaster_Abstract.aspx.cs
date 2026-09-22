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
    public partial class DistrictWise_BeneficiaryMaster_Abstract : System.Web.UI.Page
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

                DataTable dt= ProjectRofrBAL.GetMasterDetails.GetDistWiseBeneficiaryMasterCount("District","","","","", (string)(Session["username"]), (string)Session["userprevilages"]);
               
               
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

   
        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
              

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetDistWiseBeneficiaryMasterCount("District", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                dt.Columns["sno"].ColumnName = "S.No";
                dt.Columns["Itda_Name"].ColumnName = "ITDA Name";
                dt.Columns["District"].ColumnName = "District";
                dt.Columns["Total_bneficiaries_dept"].ColumnName = "Farmers as per record";
                dt.Columns["Total_Beneficiaries"].ColumnName = "Farmers as per Giribhumi";
               
                dt.Columns["Total_Received"].ColumnName = "No of Farmers Having Aadhar Numbers";
                dt.Columns["Adhharnotavaliable"].ColumnName = "No of Farmers Not Having Aadhar Numbers";
                dt.Columns["Adhharisvalid"].ColumnName = "No of Farmers Having Valid Aadhar Numbers";
                dt.Columns["Adhharnoinvalid"].ColumnName = "No of Farmers Having Invalid Aadhar Numbers";
              
                dt.Columns["Bankavaliable"].ColumnName = "No of Farmers Having Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["Banknotavaliable"].ColumnName = "No of Farmers Not Having Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["Bankinvalid"].ColumnName = "No of Farmers Having Invalid Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["FullBankDetails"].ColumnName = "No of Farmers Having Full Details( Bank A/c + IFSC Code + Aadhar No)";

                if (dt.Rows.Count > 0)
                {
                    DataRow dr2 = dt.NewRow();
                    foreach (DataRow dr in dt.Rows)
                    {


                        dr2["District"] = "Note: Invalid Aadhar Number includes Death,Migrated,No Aadhar";
                    }

                    dt.Rows.Add(dr2);
                    string filename = "Farmer_Analysis.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


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

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');
                
                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);

                Session["CurrentPage"] = "MandalWise_BeneficiaryMaster_Abstract";

                if (start != "Total:")
                {
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["Itda"] = start.Trim();
                            Session["District"] = dist.Trim();
                            Response.Redirect("~//test//MandalWise_BeneficiaryMaster_Abstract.aspx");
                        }

                    }
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
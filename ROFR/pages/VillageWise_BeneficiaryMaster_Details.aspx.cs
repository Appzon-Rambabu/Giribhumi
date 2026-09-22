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
    public partial class VillageWise_BeneficiaryMaster_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "MandalWise_BeneficiaryMaster_Abstract.aspx")
                    {
                        string Itda = (string)(Session["Itda"]);
                        string dist = (string)(Session["District"]);
                        string mandal = (string)(Session["Mandal"]);
                        string village = (string)(Session["Village"]);
                        lbl_itda.Text = Itda;
                        lbl_dist.Text = dist;
                        lbl_mandal.Text = mandal;
                        lbl_village.Text = village;
                        if (dist != "" & Itda != "")
                        {
                            BindData(Itda, dist, mandal,village);
                        }
                    }
                    else
                    {
                        if ((string)(Session["District"]) != "" && (string)(Session["Itda"]) != "")
                        {
                            string Itda = (string)(Session["Itda"]);
                            string dist = (string)(Session["District"]);
                            string mandal = (string)(Session["Mandal"]);
                            string village = (string)(Session["Village"]);

                            lbl_itda.Text = Itda;
                            lbl_dist.Text = dist;
                            lbl_mandal.Text = mandal;
                           lbl_village.Text = village;
                            if (dist != "" & Itda != "")
                            {
                                BindData(Itda, dist, mandal,village);
                            }
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

        protected void BindData(string Itda, string dist, string mandal,string village)
        {
            try
            {

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetDistWiseBeneficiaryMasterCount("VDetails", Itda, dist, mandal,village, (string)(Session["username"]), (string)Session["userprevilages"]);

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

                string Itda = (string)(Session["Itda"]);
                string dist = (string)(Session["District"]);
                string mandal = (string)(Session["Mandal"]);
                string village = (string)(Session["Village"]);

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetDistWiseBeneficiaryMasterCount("VDetails", Itda, dist, mandal, village, (string)(Session["username"]), (string)Session["userprevilages"]);

                dt.Columns["Rofr_Pattadaar"].ColumnName = "Farmer Name";
                dt.Columns["Father_Name"].ColumnName = "Farmer Father Name ";

                dt.Columns["Sub_Caste"].ColumnName = "Sub Caste";
                dt.Columns["Aadhaar_NO"].ColumnName = "Aadhar Number";
                dt.Columns["BankAccountNo"].ColumnName = "BankAccount Number";
                dt.Columns["IfscCode"].ColumnName = "IFSC Code";
                dt.Columns["BankName"].ColumnName = "Bank Name";
               
                if (dt.Rows.Count > 0)
                {
                   
                   
                    string filename = "VillageWise_FarmerDetails.xls";
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
        protected void Back_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("VillageWise_BeneficiaryMaster_Abstract.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
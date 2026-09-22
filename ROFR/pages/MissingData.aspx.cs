using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using ROFR.helper;
namespace ROFR.pages
{
    public partial class MissingData : System.Web.UI.Page
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
                DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdadetails((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_NAME";
                    ddl_ITda.DataBind();
                    ddl_ITda.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_district.DataValueField = "DISTRICT_CODE";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void ddlitda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindDistrict(dtMandal);
                        if (dtMandal.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                        }
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



        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    if (ddl_district.SelectedItem.Text != "Select")
                    {

                        // DataSet dS = ProjectRofrBAL.GetMasterDetails.Getmissingdata("", (string)(Session["username"]));
                        List<System.Data.SqlClient.SqlParameter> lstparams = new List<System.Data.SqlClient.SqlParameter>();

                        SQLManager sqlmngr = new SQLManager();
                        lstparams.Add(new SqlParameter("@ITDA", (ddl_ITda.SelectedItem.Text)));
                        lstparams.Add(new SqlParameter("@LGD_DISTRICT_CODE", Convert.ToInt32(ddl_district.SelectedItem.Value)));
                        lstparams.Add(new SqlParameter("@SelectionOptionType", radioid.SelectedValue));
                        lstparams.Add(new SqlParameter("@Ptype", 12));
                        DataTable result = sqlmngr.ExecuteProcedureReturnDataTable("MastersData_Analysis", lstparams);

                        DataTable dt = result;
                        if (dt.Rows.Count > 0)
                        {
                            System.Threading.Thread.Sleep(5000);
                            string filenamef = string.Empty;
                            // DateTime.Now.ToString("dd-MM-yyyy")
                            if (radioid.SelectedValue == "A")
                            {
                                filenamef = ddl_ITda.SelectedItem.Text + "_" + ddl_district.SelectedItem.Text + "_" + "ALL_Details_NotAvailable" + "_" + DateTime.Now;
                            }
                            else if (radioid.SelectedValue == "B")
                            {
                                filenamef = ddl_ITda.SelectedItem.Text + "_" + ddl_district.SelectedItem.Text + "_" + "BankAccount_NotAvailable" + "_" + DateTime.Now;
                            }
                            else if (radioid.SelectedValue == "C")
                            {
                                filenamef = ddl_ITda.SelectedItem.Text + "_" + ddl_district.SelectedItem.Text + "_" + "IfscCode_NotAvailable" + "_" + DateTime.Now;
                            }
                            else if (radioid.SelectedValue == "D")
                            {
                                filenamef = ddl_ITda.SelectedItem.Text + "_" + ddl_district.SelectedItem.Text + "_" + "Total_Invalid_Aadhars" + "_" + DateTime.Now;
                            }
                            else if (radioid.SelectedValue == "E")
                            {
                                filenamef = ddl_ITda.SelectedItem.Text + "_" + ddl_district.SelectedItem.Text + "_" + "Total_Invalid_BankAccounts" + "_" + DateTime.Now;
                            }
                            else if (radioid.SelectedValue == "F")
                            {
                                filenamef = ddl_ITda.SelectedItem.Text + "_" + ddl_district.SelectedItem.Text + "_" + "Total_Invalid_IfscCodes" + "_" + DateTime.Now;
                            }
                            else if (radioid.SelectedValue == "G")
                            {
                                filenamef = ddl_ITda.SelectedItem.Text + "_"+ddl_district.SelectedItem.Text +"_"+ "Total_Aadhar_Not_Available" +"_"+ DateTime.Now;
                            }
                            else if (radioid.SelectedValue == "H")
                            {
                                filenamef = ddl_ITda.SelectedItem.Text + "_" + ddl_district.SelectedItem.Text + "_" + "BankAccount_or_IfscCode_Not_Available" + "_" + DateTime.Now;
                            }

                            string filename = filenamef + ".xls";
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
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found !')", true);
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Select District !')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Select Itda !')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
        }
    }
}
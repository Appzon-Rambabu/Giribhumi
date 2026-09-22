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
    public partial class DataAnalysisMandalwise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    BindItda();
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    GridView1.Visible = false;
                    btnsubmit.Visible = false;

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

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMandalwiseDetailsAnalysis(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue);
                dt = calculatetotals(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    GridView1.Visible = false;
                    btnsubmit.Visible = false;
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
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    GridView1.Visible = false;
                    btnsubmit.Visible = false;
                    DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindDistrict(dtMandal);
                        if (dtMandal.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal1 = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenmandalDetails(ddl_district.SelectedValue, (string)(Session["username"]));
                            if (dtMandal1.Rows.Count > 0)
                            {
                                GridView1.Visible = true;
                                btnsubmit.Visible = true;
                                BindData();

                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    GridView1.Visible = false;
                    btnsubmit.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }


        protected void ddldistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    if (ddl_district.SelectedValue != "0")
                    {
                        if (ddl_ITda.SelectedItem.Text != "Select")
                        {
                            if (ddl_ITda.SelectedValue != "0")
                            {

                                DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenmandalDetails(ddl_district.SelectedValue, (string)(Session["username"]));
                                if (dtMandal.Rows.Count > 0)
                                {
                                    GridView1.Visible = true;
                                    btnsubmit.Visible = true;
                                    BindData();

                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select Itda Name')", true);
                                ddl_district.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select Itda Name')", true);
                            ddl_district.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        GridView1.Visible = false;
                        btnsubmit.Visible = false;
                    }

                }
                else
                {

                    GridView1.Visible = false;
                    btnsubmit.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected DataTable calculatetotals(DataTable dt)
        {
            DataTable dtfinal = new DataTable();
            dtfinal = dt;
            try
            {
                var Totalbneficiaries = 0M;
                var totalplots = 0.00M;
                var totalreceived = 0.00M;

                var Adhharisvalid = 0.00M;
                var Adhharnoinvalid = 0.00M;
                var Adhharnotavaliable = 0.00M;
                var Bankavaliable = 0.00M;
                var Banknotavaliable = 0.00M;
                var Bankinvalid = 0.00M;
                var fullbankdetails = 0.00M;


                if (dtfinal.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    foreach (DataRow dr in dtfinal.Rows)
                    {
                        dr1["Mandal"] = "Total:";
                        Totalbneficiaries += (dr["TOTAL_BENEFICIARIES"].ToString() == "") ? 0 : int.Parse(dr["TOTAL_BENEFICIARIES"].ToString());
                        dr1["TOTAL_BENEFICIARIES"] = Totalbneficiaries;
                        totalplots += (dr["total_plots"].ToString() == "") ? 0 : int.Parse(dr["total_plots"].ToString());
                        dr1["total_plots"] = totalplots;

                        totalreceived += (dr["total_received"].ToString() == "") ? 0 : int.Parse(dr["total_received"].ToString());
                        dr1["total_received"] = totalreceived;
                        Adhharisvalid += (dr["Adhharisvalid"].ToString() == "") ? 0 : int.Parse(dr["Adhharisvalid"].ToString());
                        dr1["Adhharisvalid"] = Adhharisvalid;
                        Adhharnoinvalid += (dr["Adhharnoinvalid"].ToString() == "") ? 0 : int.Parse(dr["Adhharnoinvalid"].ToString());
                        dr1["Adhharnoinvalid"] = Adhharnoinvalid;
                        Adhharnotavaliable += (dr["Adhharnotavaliable"].ToString() == "") ? 0 : int.Parse(dr["Adhharnotavaliable"].ToString());
                        dr1["Adhharnotavaliable"] = Adhharnotavaliable;
                        Bankavaliable += (dr["Bankavaliable"].ToString() == "") ? 0 : int.Parse(dr["Bankavaliable"].ToString());
                        dr1["Bankavaliable"] = Bankavaliable;
                        Banknotavaliable += (dr["Banknotavaliable"].ToString() == "") ? 0 : int.Parse(dr["Banknotavaliable"].ToString());
                        dr1["Banknotavaliable"] = Banknotavaliable;

                        Bankinvalid += (dr["Bankinvalid"].ToString() == "") ? 0 : int.Parse(dr["Bankinvalid"].ToString());
                        dr1["Bankinvalid"] = Bankinvalid;
                        fullbankdetails += (dr["FullBankDetails"].ToString() == "") ? 0 : int.Parse(dr["FullBankDetails"].ToString());
                        dr1["FullBankDetails"] = fullbankdetails;
                    }
                    dtfinal.Rows.Add(dr1);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return dtfinal;

        }
        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    if (ddl_district.SelectedItem.Text != "Select")
                    {

                        DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMandalwiseDetailsAnalysis(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue);
                        dt = calculatetotals(dt);
                        dt.Columns["ITDA_NAME"].ColumnName = "Itda Name";
                        dt.Columns["District"].ColumnName = "District";
                        dt.Columns["Mandal"].ColumnName = "Mandal";
                        dt.Columns["TOTAL_BENEFICIARIES"].ColumnName = "Total Beneficiaries Received(Giribhumi Database) by Department";
                        dt.Columns["total_plots"].ColumnName = "Total Plots";
                        dt.Columns["total_received"].ColumnName = "No of Beneficiaries Records Having Aadhar Numbers";
                        dt.Columns["Adhharisvalid"].ColumnName = "No of Beneficiaries Records Having Valid Aadhar Numbers";
                        dt.Columns["Adhharnoinvalid"].ColumnName = "No of Beneficiaries Records Having Invalid Aadhar Numbers";
                        dt.Columns["Adhharnotavaliable"].ColumnName = "No of Beneficiaries Records Having No Aadhar Numbers";
                        dt.Columns["Bankavaliable"].ColumnName = "No of Beneficiaries Records  Having Bank Details (Bank A/c + IFSC Code)";
                        dt.Columns["Banknotavaliable"].ColumnName = "No of Beneficiaries Records Not Having Bank Details (Bank A/c + IFSC Code)";
                        dt.Columns["Bankinvalid"].ColumnName = "No of Beneficiaries Records Having Invalid Bank Details (Bank A/c + IFSC Code)";
                        dt.Columns["FullBankDetails"].ColumnName = "No of Beneficiaries Records Having Full Bank Details (Aadhar No + Bank A/c + IFSC Code)";
                        if (dt.Rows.Count > 0)
                        {

                            DataRow dr2 = dt.NewRow();
                            foreach (DataRow dr in dt.Rows)
                            {


                                dr2["District"] = "Note: Invalid Aadhar Number includes Death,Migrated,No Aadhar";
                            }

                            string filenamef = ddl_ITda.SelectedItem.Text + ddl_district.SelectedItem.Text + "MandalWise_DataAnalysis" + DateTime.Now;
                            string filename = filenamef + ".xls";
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
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select District !')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select Itda !')", true);
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
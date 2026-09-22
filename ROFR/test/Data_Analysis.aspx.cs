using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;
//using Excel = Microsoft.Office.Interop.Excel;


namespace ROFR.test
{
    public partial class Data_Analysis : System.Web.UI.Page
    {
        DataTable dtTest = new DataTable();
        DataTable dtTest1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if((string)(Session["username"])=="")
                //{
                //    Response.Redirect("Login.aspx");
                //}

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

                DataSet dS = ProjectRofrBAL.GetMasterDetails.GetBeneficiaryDetailsAnalysis("", (string)(Session["username"]));
                DataTable dt = dS.Tables[0];
                dt = calculatetotals(dt);
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
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                DataSet ds = ProjectRofrBAL.GetMasterDetails.GetBeneficiaryDetailsAnalysis(start, (string)(Session["username"]));
                Session["CurrentPage"] = "Data_Analysis.aspx";


                if (end == "1")
                {

                    Session["dtTest"] = ds.Tables[1];
                    Session["dtTest1"] = ds.Tables[2];
                }

                else if (end == "2")
                {

                    Session["dtTest"] = ds.Tables[3];
                    Session["dtTest1"] = ds.Tables[4];
                }

                else if (end == "3")
                {

                    Session["dtTest"] = ds.Tables[5];
                    Session["dtTest1"] = ds.Tables[6];
                }

                else if (end == "4")
                {

                    Session["dtTest"] = ds.Tables[7];
                    Session["dtTest1"] = ds.Tables[8];
                }


                else if (end == "5")
                {

                    Session["dtTest"] = ds.Tables[9];
                    Session["dtTest1"] = ds.Tables[10];
                }




                else if (end == "6")
                {

                    Session["dtTest"] = ds.Tables[11];
                    Session["dtTest1"] = ds.Tables[12];
                }


                else if (end == "7")
                {

                    Session["dtTest"] = ds.Tables[13];
                    Session["dtTest1"] = ds.Tables[14];
                }



                else if (end == "8")
                {

                    Session["dtTest"] = ds.Tables[15];
                    Session["dtTest1"] = ds.Tables[16];
                }

                else if (end == "9")
                {

                    Session["dtTest"] = ds.Tables[17];
                    Session["dtTest1"] = ds.Tables[18];

                }
                else if (end == "10")
                {

                    Session["dtTest"] = ds.Tables[19];
                    Session["dtTest1"] = ds.Tables[20];

                }
                else if (end == "11")
                {

                    Session["dtTest"] = ds.Tables[21];
                    Session["dtTest1"] = ds.Tables[22];

                }
                Response.Redirect("~//test/ROFR_Col_Split");
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
                var Totalbenfgiribhumi = 0M;
                var TotalPlots = 0.00M;
                var TotalROFRPATTADAAR = 0.00M;
                var totalreceived = 0.00M;
                var ROFRPATTDAARBlank = 0.00M;
                var Adhharisvalid = 0.00M;
                var Adhharnoinvalid = 0.00M;
                var Adhharnotavaliable = 0.00M;
                var Bankavaliable = 0.00M;
                var Banknotavaliable = 0.00M;
                var InvalidBankDetails = 0M;
                var FullBankDetails = 0.00M;

                if (dtfinal.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    DataRow dr2 = dt.NewRow();
                    foreach (DataRow dr in dtfinal.Rows)
                    {
                        dr1["District"] = "Total:";
                        Totalbneficiaries += (dr["Total_bneficiaries"].ToString() == "") ? 0 : int.Parse(dr["Total_bneficiaries"].ToString());
                        dr1["Total_bneficiaries"] = Totalbneficiaries;
                        Totalbenfgiribhumi += (dr["Giribhumi_beneficiaries"].ToString() == "") ? 0 : int.Parse(dr["Giribhumi_beneficiaries"].ToString());
                        dr1["Giribhumi_beneficiaries"] = Totalbenfgiribhumi;
                        TotalPlots += (dr["TOTAL_PLOTS"].ToString() == "") ? 0 : int.Parse(dr["TOTAL_PLOTS"].ToString());
                        dr1["TOTAL_PLOTS"] = TotalPlots;
                        TotalROFRPATTADAAR += (dr["Total_ROFR_PATTADAAR"].ToString() == "") ? 0 : int.Parse(dr["Total_ROFR_PATTADAAR"].ToString());
                        dr1["Total_ROFR_PATTADAAR"] = TotalROFRPATTADAAR;
                        ROFRPATTDAARBlank += (dr["ROFR_PATTDAAR_Blank"].ToString() == "") ? 0 : int.Parse(dr["ROFR_PATTDAAR_Blank"].ToString());
                        dr1["ROFR_PATTDAAR_Blank"] = ROFRPATTDAARBlank;
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



                        InvalidBankDetails += (dr["Bankinvalid"].ToString() == "") ? 0 : int.Parse(dr["Bankinvalid"].ToString());
                        dr1["Bankinvalid"] = InvalidBankDetails;
                        FullBankDetails += (dr["FullBankDetails"].ToString() == "") ? 0 : int.Parse(dr["FullBankDetails"].ToString());
                        dr1["FullBankDetails"] = FullBankDetails;
                       
                        // dr2["District"] = "Note: Invalid Aadhar Number includes Death,Migrated,No Aadhar";
                    }
                    dtfinal.Rows.Add(dr1);
                    //dtfinal.Rows.Add(dr2);
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
                DataSet dS = ProjectRofrBAL.GetMasterDetails.GetBeneficiaryDetailsAnalysis("", (string)(Session["username"]));
                DataTable dt = dS.Tables[0];
                string str = "*";
                Label1.Text = str;
             Label1.ForeColor= System.Drawing.Color.Red;
                dt = calculatetotals(dt);
                dt.Columns["sno"].ColumnName = "S.No";
                dt.Columns["ITDA_NAME"].ColumnName = "ITDA Name";
                dt.Columns["District"].ColumnName = "District";
                dt.Columns["Total_bneficiaries"].ColumnName = "Total Beneficiaries As Per Department(Static)";
                dt.Columns["Giribhumi_beneficiaries"].ColumnName = "Total Beneficiaries Received (Giribhumi Database) By Department";
                dt.Columns["TOTAL_PLOTS"].ColumnName = "Total Plots";
                dt.Columns["Total_ROFR_PATTADAAR"].ColumnName = "No of Beneficiaries Records Having Pattadar Name";
                dt.Columns["ROFR_PATTDAAR_Blank"].ColumnName = "No of Beneficiaries Records Not Having Pattadar Name";
                dt.Columns["total_received"].ColumnName = "No of Beneficiaries Records Having Aadhar Numbers";
                dt.Columns["Adhharisvalid"].ColumnName = "No of Beneficiaries Records Having Valid Aadhar Numbers";
                dt.Columns["Adhharnoinvalid"].ColumnName = "No of Beneficiaries Records Having Invalid Aadhar Numbers";
                dt.Columns["Adhharnotavaliable"].ColumnName = "No of Beneficiaries Records Having No Aadhar Numbers";
                dt.Columns["Bankavaliable"].ColumnName = "No of Beneficiaries Records Having Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["Banknotavaliable"].ColumnName = "No of Beneficiaries Records Not Having Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["Bankinvalid"].ColumnName = "No of Beneficiaries Records Having Invalid Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["FullBankDetails"].ColumnName = "No of Beneficiaries Records Having Full Details( Bank A/c + IFSC Code + Aadhar No)";
               
                if (dt.Rows.Count > 0)
                {
                    DataRow dr2 = dt.NewRow();
                    foreach (DataRow dr in dt.Rows)
                    {
                       

                        dr2["District"] = "Note: Invalid Aadhar Number includes Death,Migrated,No Aadhar";
                    }
                   
                    dt.Rows.Add(dr2);
                    string filename = "Beneficiaries_Analysis_Plotwise.xls";
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
        protected void btnexcel_Click(object sender, ImageClickEventArgs e)
        {


        }

    }
}
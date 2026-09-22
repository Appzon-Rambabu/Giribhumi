using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;
namespace ROFR.pages
{
    public partial class ItdawiseLandDetails : System.Web.UI.Page
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
                DataTable dt = Landsettlementpattas.ItdaWiseGetData();
              //  dt = calculatetotals(dt);
                if (dt.Rows.Count > 0)
                {
                   
                    GridView1.DataSource = dt;

                    GridView1.DataBind();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {
                                if (j == 1)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;

                                }
                                else
                                {
                                    if (j != 0)
                                    {
                                        string IL = "lbl";
                                        IL = IL + j;
                                        Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = true;
                                        lbl.ForeColor = System.Drawing.Color.Black;
                                    }
                                }
                            }
                        }
                    }


               

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
               
                Session["CurrentPage"] = "MandalwiseLandDetails.aspx";

                if(start != "Total:")
                {
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["Itdavalue"] = start.Trim();
                            Response.Redirect("MandalwiseLandDetails.aspx");
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


        protected DataTable calculatetotals(DataTable dt)
        {
            DataTable dtfinal = new DataTable();
            dtfinal = dt;
            try
            {
                var totalreceived = 0.00M;
                var ROFRPATTDAARBlank = 0.00M;
                var Adhharisvalid = 0.00M;
                var Adhharnoinvalid = 0.00M;

                if (dtfinal.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    foreach (DataRow dr in dtfinal.Rows)
                    {
                        dr1["itda_name"] = "Total:";
                        ROFRPATTDAARBlank += (dr["Total_Compartments"].ToString() == "") ? 0 : int.Parse(dr["Total_Compartments"].ToString());
                        dr1["Total_Compartments"] = ROFRPATTDAARBlank;
                        totalreceived += (dr["Total_Beneficiaries"].ToString() == "") ? 0 : int.Parse(dr["Total_Beneficiaries"].ToString());
                        dr1["Total_Beneficiaries"] = totalreceived;
                        Adhharisvalid += (dr["Beneficiaries_Having_Adhaar_no"].ToString() == "") ? 0 : int.Parse(dr["Beneficiaries_Having_Adhaar_no"].ToString());
                        dr1["Beneficiaries_Having_Adhaar_no"] = Adhharisvalid;
                        Adhharnoinvalid += (dr["Total_Land"].ToString() == "") ? 0 : decimal.Parse(dr["Total_Land"].ToString());
                        dr1["Total_Land"] = Adhharnoinvalid;
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
                DataSet dS = ProjectRofrBAL.GetMasterDetails.GetBeneficiaryDetailsAnalysis("", (string)(Session["username"]));
                DataTable dt = dS.Tables[0];
              //  dt = calculatetotals(dt);
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
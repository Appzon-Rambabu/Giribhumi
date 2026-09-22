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
    public partial class ForestBeatwiseLandDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "ForestBeatwiseLandDetails.aspx")
                    {
                        string Itda = (string)(Session["FRItdaMandalvalue"]);
                        string Mandal = (string)(Session["FRMandalvalue"]);
                        txtItda.Text = Itda;
                        txtmandal.Text = Mandal;
                        if (Itda != "")
                        {
                            if (Mandal != "")
                            {
                                BindData(Itda, Mandal);
                            }
                        }
                    }
                    else
                    {
                        if ((string)(Session["FRItdaMandalvalue"]) != "" && (string)(Session["FRMandalvalue"]) != "")
                        {
                            string Itda = (string)(Session["FRItdaMandalvalue"]);
                            string Mandal = (string)(Session["FRMandalvalue"]);
                            txtItda.Text = Itda;
                            txtmandal.Text = Mandal;
                            if (Itda != "")
                            {
                                if (Mandal != "")
                                {
                                    BindData(Itda, Mandal);
                                }
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

        protected void BindData(string Itda, string Mandal)
        {
            try
            {
                DataTable dt = Landsettlementpattas.ForestBeatGetData(Itda, Mandal);
                dt = calculatetotals(dt);
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
                                if (j == 2)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.Black;
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
                Session["CurrentPage"] = "ForestCompartementNumberwiseLand.aspx";

                if (start != "Total:")
                {
                    Session["FBMandalvalue"] = (string)(Session["FRMandalvalue"]);
                    Session["FBItdaMandalvalue"] = (string)(Session["FRItdaMandalvalue"]);
                    Session["FBVillagevalue"] = start.Trim();
                    Response.Redirect("ForestCompartementNumberwiseLand.aspx");
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
                        dr1["Forest_Beat"] = "Total:";
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

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtbeneficiareies = new DataTable();
                dtbeneficiareies = Landsettlementpattas.ForestBeatGetData((string)(Session["FRItdaMandalvalue"]), (string)(Session["FRMandalvalue"]));
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format("Forest_Beat LIKE '%{0}%'", txtSearch.Text);
                    GridView1.DataSource = DV;

                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Session["CurrentPage"] = "ForestRangewiseLandDetails.aspx";
                Session["FDItdavalue"] = (string)(Session["FRItdaMandalvalue"]);
                Response.Redirect("ForestRangewiseLandDetails.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Landsettlementpattas.ForestBeatGetData((string)(Session["FRItdaMandalvalue"]), (string)(Session["FRMandalvalue"]));
                dt = calculatetotals(dt);
                dt.Columns["Forest_Beat"].ColumnName = "FOREST BEAT";
                dt.Columns["Total_Compartments"].ColumnName = "Compartments";
                dt.Columns["Total_Beneficiaries"].ColumnName = "Beneficiaries";
                dt.Columns["Beneficiaries_Having_Adhaar_no"].ColumnName = "No of Beneficiaries Having Adhaar No";
                dt.Columns["Total_Land"].ColumnName = "Total Land (In Acres)";
                if (dt.Rows.Count > 0)
                {
                    string filename = "ForestBeatWiseLandSummaryReportExcel.xls";
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
    }
}
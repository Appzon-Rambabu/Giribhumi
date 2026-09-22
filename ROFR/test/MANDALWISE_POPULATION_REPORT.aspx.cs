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
    public partial class MANDALWISE_POPULATION_REPORT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "MANDALWISE_POPULATION_REPORT.aspx")
                    {
                        string Itda = (string)(Session["Itdavalue"]);
                        txtItda.Text = Itda;
                        if (Itda != "")
                        {
                            BindData(Itda);
                        }
                    }
                    else
                    {
                        if ((string)(Session["Itdavalue"]) != "")
                        {
                            string Itda = (string)(Session["Itdavalue"]);
                            txtItda.Text = Itda;
                            if (Itda != "")
                            {
                                BindData(Itda);
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

        protected void BindData(string Itda)
        {
            try
            {
                DataTable dt = Landsettlementpattas.PopulationGetData(Itda);
              //  dt = calculatetotals(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;


                    GridView1.DataBind();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= 6; j++)
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
                Session["CurrentPage"] = "VILLAGEWISE_POPULATION_REPORT.aspx";

                if (start != "Total:")
                {
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["Mandalvalue"] = start.Trim();
                            Session["ItdaMandalvalue"] = txtItda.Text.Trim();
                            Response.Redirect("~//test//VILLAGEWISE_POPULATION_REPORT.aspx");
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
                var totalpopulation = 0.00M;
                var HOUSEHOLDS = 0.00M;
                var totalbeneficiaries = 0.00M;
                var AdhharinPSS = 0.00M;
                var AdhharnotinPSS = 0.00M;
                var totalland = 0.00M;

                if (dtfinal.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    foreach (DataRow dr in dtfinal.Rows)
                    {
                        dr1["Mandal"] = "Total:";
                        HOUSEHOLDS += (dr["HOUSEHOLDS"].ToString() == "") ? 0 : int.Parse(dr["HOUSEHOLDS"].ToString());
                        dr1["HOUSEHOLDS"] = HOUSEHOLDS;
                        totalpopulation += (dr["ST_POPULATION"].ToString() == "") ? 0 : int.Parse(dr["ST_POPULATION"].ToString());
                        dr1["ST_POPULATION"] = totalpopulation;
                        totalbeneficiaries += (dr["Total_Beneficiaries"].ToString() == "") ? 0 : int.Parse(dr["Total_Beneficiaries"].ToString());
                        dr1["Total_Beneficiaries"] = totalbeneficiaries;
                        AdhharinPSS += (dr["Beneficiaries_Surveyed_PSS"].ToString() == "") ? 0 : decimal.Parse(dr["Beneficiaries_Surveyed_PSS"].ToString());
                        dr1["Beneficiaries_Surveyed_PSS"] = AdhharinPSS;
                        //to modify column name
                        AdhharnotinPSS += (dr["Beneficiaries_not_Surveyed_PSS"].ToString() == "") ? 0 : decimal.Parse(dr["Beneficiaries_not_Surveyed_PSS"].ToString());
                        dr1["Beneficiaries_not_Surveyed_PSS"] = AdhharnotinPSS;
                        totalland += (dr["Total_Land"].ToString() == "") ? 0 : decimal.Parse(dr["Total_Land"].ToString());
                        dr1["Total_Land"] = totalland;

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
                dtbeneficiareies = Landsettlementpattas.PopulationGetData((string)(Session["Itdavalue"]));
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format("Mandal LIKE '%{0}%'", txtSearch.Text);
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
                Response.Redirect("~//test//ITDAWISE_POPULATION_REPORT.aspx");
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
                DataTable dt = Landsettlementpattas.PopulationGetData((string)(Session["Itdavalue"]));
                //dt = calculatetotals(dt);
                dt.Columns["Mandal"].ColumnName = "MANDAL";
                dt.Columns["HOUSEHOLDS"].ColumnName = "HOUSEHOLDS";
                dt.Columns["ST_POPULATION"].ColumnName = "TOTAL POPULATION";
                dt.Columns["Total_Beneficiaries"].ColumnName = "TOTAL BENEFICIARIES";
                dt.Columns["Beneficiaries_Surveyed_PSS"].ColumnName = "BENEFICIARIES COVERED IN PSS";
                dt.Columns["Beneficiaries_not_Surveyed_PSS"].ColumnName = "BENEFICIARIES NOT COVERED IN PSS";
                dt.Columns["Total_Land"].ColumnName = "TOTAL DISTRIBUTED LAND(IN ACRES)";
                if (dt.Rows.Count > 0)
                {
                    string filename = "MandalWisePopulationreport.xls";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;


namespace ROFR.test
{
    public partial class VILLAGEWISE_POPULATION_REPORT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "VILLAGEWISE_POPULATION_REPORT.aspx")
                    {
                        string Itda = (string)(Session["ItdaMandalvalue"]);
                        string Mandal = (string)(Session["Mandalvalue"]);
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
                        if ((string)(Session["ItdaMandalvalue"]) != "" && (string)(Session["Mandalvalue"]) != "")
                        {
                            string Itda = (string)(Session["ItdaMandalvalue"]);
                            string Mandal = (string)(Session["Mandalvalue"]);
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
                DataTable dt = Landsettlementpattas.PopulationGetData(Itda, Mandal);
                //dt = calculatetotals(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();

                    for (int i = 0; i <= dt.Rows.Count- 1; i++)
                    {
                        for (int j = 0; j <= 6; j++)
                        {
                            if (i == dt.Rows.Count- 1)
                            {
                                if (j == 1)
                                {
                                 
                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.Blue;

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
                Session["CurrentPage"] = "";

                if (start != "Total:")
                {
                    Session["Mandalvalue"] = (string)(Session["Mandalvalue"]);
                    Session["ItdaMandalvalue"] = (string)(Session["ItdaMandalvalue"]);
                    Session["Villagevalue"] = start.Trim();
                    Response.Redirect("");
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
                        dr1["Village"] = "Total:";
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
                dtbeneficiareies = Landsettlementpattas.PopulationGetData((string)(Session["ItdaMandalvalue"]), (string)(Session["Mandalvalue"]));
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format("Village LIKE '%{0}%'", txtSearch.Text);
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
                Session["CurrentPage"] = "MANDALWISE_POPULATION_REPORT.aspx";
                Session["Itdavalue"] = (string)(Session["ItdaMandalvalue"]);
                Response.Redirect("~//test//MANDALWISE_POPULATION_REPORT.aspx");
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
                DataTable dt = Landsettlementpattas.PopulationGetData((string)(Session["ItdaMandalvalue"]), (string)(Session["Mandalvalue"]));
                //dt = calculatetotals(dt);
                dt.Columns["Village"].ColumnName = "VILLAGE";
                dt.Columns["HOUSEHOLDS"].ColumnName = "HOUSEHOLDS";
                dt.Columns["ST_POPULATION"].ColumnName = "TOTAL POPULATION";
                dt.Columns["Total_Beneficiaries"].ColumnName = "TOTAL BENEFICIARIES";
                dt.Columns["Beneficiaries_Surveyed_PSS"].ColumnName = "BENEFICIARIES COVERED IN PSS";
                dt.Columns["Beneficiaries_not_Surveyed_PSS"].ColumnName = "BENEFICIARIES NOT COVERED IN PSS";
                dt.Columns["Total_Land"].ColumnName = "TOTAL DISTRIBUTED LAND(IN ACRES)";
                if (dt.Rows.Count > 0)
                {
                    string filename = "Villagewisepopulationreport.xls";
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
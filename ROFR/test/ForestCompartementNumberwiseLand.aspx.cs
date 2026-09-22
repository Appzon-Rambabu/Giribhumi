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
    public partial class ForestCompartementNumberwiseLand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "ForestCompartementNumberwiseLand.aspx")
                    {
                        string Itda = (string)(Session["FBItdaMandalvalue"]);
                        string Mandal = (string)(Session["FBMandalvalue"]);
                        string village = (string)(Session["FBVillagevalue"]);
                        txtItda.Text = Itda;
                        txtmandal.Text = Mandal;
                        txtvillage.Text = village;
                        if (Itda != "")
                        {
                            if (Mandal != "")
                            {
                                BindData(Itda, Mandal, village);
                            }
                        }

                    }
                    else
                    {
                        if ((string)(Session["FBItdaMandalvalue"]) != "")
                        {
                            if ((string)(Session["FBMandalvalue"]) != "" && (string)(Session["FBVillagevalue"]) != "")
                            {
                                string Itda = (string)(Session["FBItdaMandalvalue"]);
                                string Mandal = (string)(Session["FBMandalvalue"]);
                                string village = (string)(Session["FBVillagevalue"]);
                                txtItda.Text = Itda;
                                txtmandal.Text = Mandal;
                                txtvillage.Text = village;
                                if (Itda != "")
                                {
                                    if (Mandal != "")
                                    {
                                        BindData(Itda, Mandal, village);
                                    }
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

        protected void BindData(string Itda, string Mandal, string village)
        {
            try
            {
                DataTable dt = Landsettlementpattas.ForestCompartmentWiseGetData(Itda, Mandal, village);
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



        protected DataTable calculatetotals(DataTable dt)
        {
            DataTable dtfinal = new DataTable();
            dtfinal = dt;
            try
            {
                var totalreceived = 0.00M;


                if (dtfinal.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    foreach (DataRow dr in dtfinal.Rows)
                    {
                        dr1["Compartment_No"] = "Total:";
                        totalreceived += (dr["ExtentPlotArea"].ToString() == "") ? 0 : decimal.Parse(dr["ExtentPlotArea"].ToString());
                        dr1["ExtentPlotArea"] = totalreceived;
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
                dtbeneficiareies = Landsettlementpattas.ForestCompartmentWiseGetData((string)(Session["FBItdaMandalvalue"]), (string)(Session["FBMandalvalue"]), (string)(Session["FBVillagevalue"]));
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format("Compartment_No LIKE '%{0}%' OR ROFR_PATTADAAR LIKE '%{0}%'", txtSearch.Text);
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
                Session["CurrentPage"] = "ForestBeatwiseLandDetails.aspx";
                Session["FRItdavalue"] = (string)(Session["FBItdaMandalvalue"]);
                Session["FRMandalvalue"] = (string)(Session["FBMandalvalue"]);
                Response.Redirect("~//test//ForestBeatwiseLandDetails.aspx");
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
                DataTable dt = Landsettlementpattas.ForestCompartmentWiseGetData((string)(Session["FBItdaMandalvalue"]), (string)(Session["FBMandalvalue"]), (string)(Session["FBVillagevalue"]));
                dt = calculatetotals(dt);
                dt.Columns["Compartment_No"].ColumnName = "COMPARTMENT NO";
                dt.Columns["ExtentPlotArea"].ColumnName = "EXTENT";
                dt.Columns["ROFR_PATTADAAR"].ColumnName = "PATTADAAR NAME";
                dt.Columns["mask"].ColumnName = "AADHAAR NO";
                if (dt.Rows.Count > 0)
                {
                    string filename = "CompartmentNoWiseLandSummaryReportExcel.xls";
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
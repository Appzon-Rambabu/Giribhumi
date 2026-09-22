using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Dynamic;

namespace ROFR
{
    public partial class ITDAWISE_POPULATION_REPORT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {

                    BindData();
                    GetPopulationData();
                    GetPopulationData1();

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
                DataTable dt = Landsettlementpattas.PopulationGetData();
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
                                    else if (j == 0)
                                    {
                                        string IL = "lbl";
                                        IL = IL + j;
                                        Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = false;

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

                Session["CurrentPage"] = "MANDALWISE_POPULATION_REPORT";

                if (start != "Total:")
                {
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["Itdavalue"] = start.Trim();
                            Response.Redirect("MANDALWISE_POPULATION_REPORT.aspx");
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
                        dr1["itda_name"] = "Total:";
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

        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] GetPopulationData()
        {

            List<GoogleChartData> data = new List<GoogleChartData>();
            dynamic objDetails = new ExpandoObject();
            DataTable dt = new DataTable();
            //objDetails.dt = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters("admin", "Season", district, mandal, village);
            DataSet ds = Landsettlementpattas.PopulationGetDat();
            dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GoogleChartData GoogleChartData = new GoogleChartData();
                GoogleChartData.SLID = Convert.ToInt32(dt.Rows[i]["S_No"]);
                GoogleChartData.ProductCategory = dt.Rows[i]["A"].ToString();
                GoogleChartData.RevenueAmount = Convert.ToInt32(dt.Rows[i]["ST_POPULATION"]);
                data.Add(GoogleChartData);
            }

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Product Category",
                "Revenue Amount"
            };
            int j = 0;
            foreach (var i in data)
            {
                j++;
                chartData[j] = new object[] { i.ProductCategory, i.RevenueAmount };
            }


            return chartData;
        }

        [WebMethod(enableSession: true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object[] GetPopulationData1()
        {

            List<GoogleChartData> data = new List<GoogleChartData>();
            dynamic objDetails = new ExpandoObject();
            DataTable dt = new DataTable();
            //objDetails.dt = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters("admin", "Season", district, mandal, village);
            DataSet ds = Landsettlementpattas.PopulationGetDat();
            dt = ds.Tables[1];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                GoogleChartData GoogleChartData = new GoogleChartData();
                GoogleChartData.SLID = Convert.ToInt32(dt.Rows[i]["S_No"]);
                GoogleChartData.ProductCategory = dt.Rows[i]["A"].ToString();
                GoogleChartData.RevenueAmount = Convert.ToInt32(dt.Rows[i]["ST_POPULATION"]);
                data.Add(GoogleChartData);
            }

            var chartData = new object[data.Count + 1];
            chartData[0] = new object[]{
                "Product Category",
                "Revenue Amount"
            };
            int j = 0;
            foreach (var i in data)
            {
                j++;
                chartData[j] = new object[] { i.ProductCategory, i.RevenueAmount };
            }


            return chartData;
        }

    }
}
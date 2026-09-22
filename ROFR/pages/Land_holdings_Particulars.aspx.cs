using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;

namespace ROFR.pages
{
    public partial class Land_holdings_Particulars : System.Web.UI.Page
    {
        HealthConnection hc = new HealthConnection();
        addbeneficiary_details obj = new addbeneficiary_details();
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
                DataTable dt = new DataTable();


                obj.Type = "ITDA";
                obj.Itda = "NULL";

                dt = hc.Land_holdings_Particulars(obj);
              //  DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMandatoryFieldsAnalysis("", (string)(Session["userprevilages"]), (string)(Session["username"]));

               // dt = calculatetotals(dt);
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
                var Totalbneficiaries = 0M;
                var TOTALPLOTS = 0.00M;
                var TOTALAADHARS = 0.00M;
                var TOTALAADHARSNOTUPDATED = 0.00M;
                var HAVINGMANDAL = 0.00M;
                var NOTHAVINGMANDAL = 0.00M;
                var HAVINGVILLAGE = 0.00M;
                var NOTHAVINGVILLAGE = 0.00M;
                var GRAMPANCHAYAT = 0.00M;
                var NOTHAVINGGRAMPANCHAYAT = 0.00M;
                var Habitation = 0.00M;
                var NotHavingHabitation = 0.00M;
                var HAVINGFORESTDIVISION = 0.00M;
                var NOTHAVINGFORESTDIVISION = 0.00M;
                var HAVINGFORESTRANGE = 0.00M;
                var NOTHAVINGFORESTRANGE = 0.00M;
                var HAVINGFORESTBEAT = 0.00M;
                var NOTHAVINGFORESTBEAT = 0.00M;
                var HAVINGFORESTBLOCK = 0.00M;
                var NOTHAVINGFORESTBLOCK = 0.00M;
                var PLOTSHAVINGCOMPARTMENTNUMBER = 0.00M;
                var NOTPLOTSHAVINGCOMPARTMENTNUMBER = 0.00M;
                var HAVINGPLOTNO = 0.00M;
                var NOTHAVINGPLOTNO = 0.00M;
                var PLOTSHAVINGEXTENTPLOTAREA = 0.00M;
                var NOTPLOTSHAVINGEXTENTPLOTAREA = 0.00M;
                var HAVINGPATTAINAMGOVT = 0.00M;
                var NOTHAVINGPATTAINAMGOVT = 0.00M;
                var PLOTSHAVINGROFRPATTANO = 0.00M;
                var NOTPLOTSHAVINGROFRPATTANO = 0.00M;
                var PLOTSHAVINGROFRPATTADAAR = 0.00M;
                var NOTPLOTSHAVINGROFRPATTADAAR = 0.00M;
                var PLOTSHAVINGCULTIVATORNAME = 0.00M;
                var NOTPLOTSHAVINGCULTIVATORNAME = 0.00M;
                var PLOTSHAVINGHOLDINGNATURE = 0.00M;
                var NOTPLOTSHAVINGHOLDINGNATURE = 0.00M;
                var PLOTSHAVINGLandClassificationName = 0.00M;

                var NOTPLOTSHAVINGLandClassificationName = 0.00M;
                var PLOTSHAVINGBANKACCOUNTNO = 0.00M;
                var NOTPLOTSHAVINGBANKACCOUNTNO = 0.00M;
                var PLOTSHAVINGIFSCCODE = 0.00M;
                var NOTPLOTSHAVINGIFSCCODE = 0.00M;
                var PLOTSWITHALLMANDATORYFIELDS = 0.00M;
                var NOTPLOTSWITHALLMANDATORYFIELDS = 0.00M;


                if (dtfinal.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    foreach (DataRow dr in dtfinal.Rows)
                    {
                        dr1["ITDA_NAME"] = "Total:";
                        dr1["District"] = "";
                        Totalbneficiaries += (dr["TOTAL_BENEFICIARIES"].ToString() == "") ? 0 : int.Parse(dr["TOTAL_BENEFICIARIES"].ToString());
                        dr1["TOTAL_BENEFICIARIES"] = Totalbneficiaries;

                        TOTALPLOTS += (dr["TOTAL_PLOTS"].ToString() == "") ? 0 : int.Parse(dr["TOTAL_PLOTS"].ToString());
                        dr1["TOTAL_PLOTS"] = TOTALPLOTS;
                        TOTALAADHARS += (dr["TOTAL_AADHARS"].ToString() == "") ? 0 : int.Parse(dr["TOTAL_AADHARS"].ToString());
                        dr1["TOTAL_AADHARS"] = TOTALAADHARS;
                        TOTALAADHARSNOTUPDATED += (dr["NEED_TO_UPDATE_AADHAARS"].ToString() == "") ? 0 : int.Parse(dr["NEED_TO_UPDATE_AADHAARS"].ToString());
                        dr1["NEED_TO_UPDATE_AADHAARS"] = TOTALAADHARSNOTUPDATED;
                        HAVINGMANDAL += (dr["HAVING_MANDAL"].ToString() == "") ? 0 : int.Parse(dr["HAVING_MANDAL"].ToString());
                        dr1["HAVING_MANDAL"] = HAVINGMANDAL;
                        NOTHAVINGMANDAL += (dr["not_HAVING_MANDAL"].ToString() == "") ? 0 : int.Parse(dr["not_HAVING_MANDAL"].ToString());
                        dr1["not_HAVING_MANDAL"] = NOTHAVINGMANDAL;
                        HAVINGVILLAGE += (dr["HAVING_VILLAGE"].ToString() == "") ? 0 : int.Parse(dr["HAVING_VILLAGE"].ToString());
                        dr1["HAVING_VILLAGE"] = HAVINGVILLAGE;
                        NOTHAVINGVILLAGE += (dr["not_HAVING_VILLAGE"].ToString() == "") ? 0 : int.Parse(dr["not_HAVING_VILLAGE"].ToString());
                        dr1["not_HAVING_VILLAGE"] = NOTHAVINGVILLAGE;
                        GRAMPANCHAYAT += (dr["GRAM_PANCHAYAT"].ToString() == "") ? 0 : int.Parse(dr["GRAM_PANCHAYAT"].ToString());
                        dr1["GRAM_PANCHAYAT"] = GRAMPANCHAYAT;
                        NOTHAVINGGRAMPANCHAYAT += (dr["not_GRAM_PANCHAYAT"].ToString() == "") ? 0 : int.Parse(dr["not_GRAM_PANCHAYAT"].ToString());
                        dr1["not_GRAM_PANCHAYAT"] = NOTHAVINGGRAMPANCHAYAT;
                        Habitation += (dr["Habitation"].ToString() == "") ? 0 : int.Parse(dr["Habitation"].ToString());
                        dr1["Habitation"] = Habitation;
                        NotHavingHabitation += (dr["not_having_Habitation"].ToString() == "") ? 0 : int.Parse(dr["not_having_Habitation"].ToString());
                        dr1["not_having_Habitation"] = NotHavingHabitation;

                        HAVINGFORESTDIVISION += (dr["HAVING_FOREST_DIVISION"].ToString() == "") ? 0 : int.Parse(dr["HAVING_FOREST_DIVISION"].ToString());
                        dr1["HAVING_FOREST_DIVISION"] = HAVINGFORESTDIVISION;
                        NOTHAVINGFORESTDIVISION += (dr["not_HAVING_FOREST_DIVISION"].ToString() == "") ? 0 : int.Parse(dr["not_HAVING_FOREST_DIVISION"].ToString());
                        dr1["not_HAVING_FOREST_DIVISION"] = NOTHAVINGFORESTDIVISION;
                        HAVINGFORESTRANGE += (dr["HAVING_FOREST_RANGE"].ToString() == "") ? 0 : int.Parse(dr["HAVING_FOREST_RANGE"].ToString());
                        dr1["HAVING_FOREST_RANGE"] = HAVINGFORESTRANGE;

                        NOTHAVINGFORESTRANGE += (dr["not_HAVING_FOREST_RANGE"].ToString() == "") ? 0 : int.Parse(dr["not_HAVING_FOREST_RANGE"].ToString());
                        dr1["not_HAVING_FOREST_RANGE"] = NOTHAVINGFORESTRANGE;
                        HAVINGFORESTBEAT += (dr["HAVING_FOREST_BEAT"].ToString() == "") ? 0 : int.Parse(dr["HAVING_FOREST_BEAT"].ToString());
                        dr1["HAVING_FOREST_BEAT"] = HAVINGFORESTBEAT;
                        NOTHAVINGFORESTBEAT += (dr["not_HAVING_FOREST_BEAT"].ToString() == "") ? 0 : int.Parse(dr["not_HAVING_FOREST_BEAT"].ToString());
                        dr1["not_HAVING_FOREST_BEAT"] = NOTHAVINGFORESTBEAT;
                        HAVINGFORESTBLOCK += (dr["HAVING_FOREST_BLOCK"].ToString() == "") ? 0 : int.Parse(dr["HAVING_FOREST_BLOCK"].ToString());
                        dr1["HAVING_FOREST_BLOCK"] = HAVINGFORESTBLOCK;
                        NOTHAVINGFORESTBLOCK += (dr["not_HAVING_FOREST_BLOCK"].ToString() == "") ? 0 : int.Parse(dr["not_HAVING_FOREST_BLOCK"].ToString());
                        dr1["not_HAVING_FOREST_BLOCK"] = NOTHAVINGFORESTBLOCK;

                        PLOTSHAVINGCOMPARTMENTNUMBER += (dr["PLOTS_HAVING_COMPARTMENT_NUMBER"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_COMPARTMENT_NUMBER"].ToString());
                        dr1["PLOTS_HAVING_COMPARTMENT_NUMBER"] = PLOTSHAVINGCOMPARTMENTNUMBER;
                        NOTPLOTSHAVINGCOMPARTMENTNUMBER += (dr["PLOTS_NOT_HAVING_COMPARTMENT_NUMBER"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_COMPARTMENT_NUMBER"].ToString());
                        dr1["PLOTS_NOT_HAVING_COMPARTMENT_NUMBER"] = NOTPLOTSHAVINGCOMPARTMENTNUMBER;

                        HAVINGPLOTNO += (dr["HAVING_PLOT_NO"].ToString() == "") ? 0 : int.Parse(dr["HAVING_PLOT_NO"].ToString());

                        dr1["HAVING_PLOT_NO"] = HAVINGPLOTNO;
                        NOTHAVINGPLOTNO += (dr["NOT_HAVING_PLOT_NO"].ToString() == "") ? 0 : int.Parse(dr["NOT_HAVING_PLOT_NO"].ToString());
                        dr1["NOT_HAVING_PLOT_NO"] = NOTHAVINGPLOTNO;
                        PLOTSHAVINGEXTENTPLOTAREA += (dr["PLOTS_HAVING_EXTENTPLOTAREA"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_EXTENTPLOTAREA"].ToString());
                        dr1["PLOTS_HAVING_EXTENTPLOTAREA"] = PLOTSHAVINGEXTENTPLOTAREA;

                        NOTPLOTSHAVINGEXTENTPLOTAREA += (dr["PLOTS_NOT_HAVING_EXTENTPLOTAREA"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_EXTENTPLOTAREA"].ToString());
                        dr1["PLOTS_NOT_HAVING_EXTENTPLOTAREA"] = NOTPLOTSHAVINGEXTENTPLOTAREA;

                        HAVINGPATTAINAMGOVT += (dr["HAVING_PATTA_INAMGOVT"].ToString() == "") ? 0 : int.Parse(dr["HAVING_PATTA_INAMGOVT"].ToString());
                        dr1["HAVING_PATTA_INAMGOVT"] = HAVINGPATTAINAMGOVT;
                        NOTHAVINGPATTAINAMGOVT += (dr["NOT_HAVING_PATTA_INAMGOVT"].ToString() == "") ? 0 : int.Parse(dr["NOT_HAVING_PATTA_INAMGOVT"].ToString());
                        dr1["NOT_HAVING_PATTA_INAMGOVT"] = NOTHAVINGPATTAINAMGOVT;

                        PLOTSHAVINGROFRPATTANO += (dr["PLOTS_HAVING_ROFR_PATTANO"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_ROFR_PATTANO"].ToString());
                        dr1["PLOTS_HAVING_ROFR_PATTANO"] = PLOTSHAVINGROFRPATTANO;
                        NOTPLOTSHAVINGROFRPATTANO += (dr["PLOTS_NOT_HAVING_ROFR_PATTANO"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_ROFR_PATTANO"].ToString());
                        dr1["PLOTS_NOT_HAVING_ROFR_PATTANO"] = NOTPLOTSHAVINGROFRPATTANO;
                        PLOTSHAVINGROFRPATTADAAR += (dr["PLOTS_HAVING_ROFR_PATTADAAR"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_ROFR_PATTADAAR"].ToString());
                        dr1["PLOTS_HAVING_ROFR_PATTADAAR"] = PLOTSHAVINGROFRPATTADAAR;
                        NOTPLOTSHAVINGROFRPATTADAAR += (dr["PLOTS_NOT_HAVING_ROFR_PATTADAAR"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_ROFR_PATTADAAR"].ToString());
                        dr1["PLOTS_NOT_HAVING_ROFR_PATTADAAR"] = NOTPLOTSHAVINGROFRPATTADAAR;
                        PLOTSHAVINGCULTIVATORNAME += (dr["PLOTS_HAVING_CULTIVATOR_NAME"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_CULTIVATOR_NAME"].ToString());
                        dr1["PLOTS_HAVING_CULTIVATOR_NAME"] = PLOTSHAVINGCULTIVATORNAME;
                        NOTPLOTSHAVINGCULTIVATORNAME += (dr["PLOTS_NOT_HAVING_CULTIVATOR_NAME"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_CULTIVATOR_NAME"].ToString());
                        dr1["PLOTS_NOT_HAVING_CULTIVATOR_NAME"] = NOTPLOTSHAVINGCULTIVATORNAME;
                        PLOTSHAVINGHOLDINGNATURE += (dr["PLOTS_HAVING_HOLDING_NATURE"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_HOLDING_NATURE"].ToString());

                        dr1["PLOTS_HAVING_HOLDING_NATURE"] = PLOTSHAVINGHOLDINGNATURE;
                        NOTPLOTSHAVINGHOLDINGNATURE += (dr["PLOTS_NOT_HAVING_HOLDING_NATURE"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_HOLDING_NATURE"].ToString());
                        dr1["PLOTS_NOT_HAVING_HOLDING_NATURE"] = NOTPLOTSHAVINGHOLDINGNATURE;

                        PLOTSHAVINGLandClassificationName += (dr["PLOTS_HAVING_Land_Classification_Name"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_Land_Classification_Name"].ToString());
                        dr1["PLOTS_HAVING_Land_Classification_Name"] = PLOTSHAVINGLandClassificationName;
                        NOTPLOTSHAVINGLandClassificationName += (dr["PLOTS_NOT_HAVING_Land_Classification_Name"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_Land_Classification_Name"].ToString());
                        dr1["PLOTS_NOT_HAVING_Land_Classification_Name"] = NOTPLOTSHAVINGLandClassificationName;
                        PLOTSHAVINGBANKACCOUNTNO += (dr["PLOTS_HAVING_BANKACCOUNTNO"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_BANKACCOUNTNO"].ToString());
                        dr1["PLOTS_HAVING_BANKACCOUNTNO"] = PLOTSHAVINGBANKACCOUNTNO;
                        NOTPLOTSHAVINGBANKACCOUNTNO += (dr["PLOTS_NOT_HAVING_BANKACCOUNTNO"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_BANKACCOUNTNO"].ToString());
                        dr1["PLOTS_NOT_HAVING_BANKACCOUNTNO"] = NOTPLOTSHAVINGBANKACCOUNTNO;
                        PLOTSHAVINGIFSCCODE += (dr["PLOTS_HAVING_IFSCCODE"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_HAVING_IFSCCODE"].ToString());
                        dr1["PLOTS_HAVING_IFSCCODE"] = PLOTSHAVINGIFSCCODE;
                        NOTPLOTSHAVINGIFSCCODE += (dr["PLOTS_NOT_HAVING_IFSCCODE"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_IFSCCODE"].ToString());
                        dr1["PLOTS_NOT_HAVING_IFSCCODE"] = NOTPLOTSHAVINGIFSCCODE;
                        PLOTSWITHALLMANDATORYFIELDS += (dr["PLOTS_WITH_ALL_MANDATORY_FIELDS"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_WITH_ALL_MANDATORY_FIELDS"].ToString());
                        dr1["PLOTS_WITH_ALL_MANDATORY_FIELDS"] = PLOTSWITHALLMANDATORYFIELDS;
                        NOTPLOTSWITHALLMANDATORYFIELDS += (dr["PLOTS_NOT_HAVING_ALL_MANDATORY_FIELDS"].ToString() == "") ? 0 : int.Parse(dr["PLOTS_NOT_HAVING_ALL_MANDATORY_FIELDS"].ToString());
                        dr1["PLOTS_NOT_HAVING_ALL_MANDATORY_FIELDS"] = NOTPLOTSWITHALLMANDATORYFIELDS;

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
        protected void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();


                obj.Type = "ITDA";
                obj.Itda = "NULL";

                dt = hc.Land_holdings_Particulars(obj);

                dt.Columns["DIST_NAME_EN"].ColumnName = "DISTRICT";
                dt.Columns["ITDA"].ColumnName = "ITDA";
                dt.Columns["TOTAL_FAMILIES_ST_RC"].ColumnName = "Total families in Scheduled area (as per Rice cards) (a)";
                dt.Columns["TOTAL_IN_ELIGIBLE_FAM"].ColumnName = "Total In-eligible (b)";
                dt.Columns["TOTAL_ELIGIBLE_FAMILIES"].ColumnName = "Total eligible families for suvey(a-b)";
                dt.Columns["GREATER_THAN_2_ACRES"].ColumnName = "Land holding >2 acres (c)";
                dt.Columns["LESS_THAN_2_ACRES"].ColumnName = "Land holding <2 acres (d)";
                dt.Columns["TOTAL_G2_AND_L2"].ColumnName = "Land holding Total (c+d)";
                dt.Columns["CLAIMS_PEND_APPROVAL"].ColumnName = "Claims pending for approval";
                dt.Columns["NOLAND_AVAILABLE_FOR_ALLOT"].ColumnName = "No Land Available for Allotment";

                
                
                

                if (dt.Rows.Count > 0)
                {
                    string filename = "LAND_HOLDINGS_PARTICULARS.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();

                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();





                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;

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
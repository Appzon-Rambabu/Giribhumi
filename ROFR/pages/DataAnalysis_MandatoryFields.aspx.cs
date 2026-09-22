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
    public partial class DataAnalysis_MandatoryFields : System.Web.UI.Page
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

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMandatoryFieldsAnalysis("", (string)(Session["userprevilages"]),(string)(Session["username"]));
               
                dt = calculatetotals(dt);
                if (dt.Rows.Count > 0)
                {
                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno"] = i + 1;
                    }

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
                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMandatoryFieldsAnalysis("", (string)(Session["userprevilages"]), (string)(Session["username"]));
                
                dt = calculatetotals(dt);
                dt.Columns["ITDA_NAME"].ColumnName = "ITDA NAME";
                dt.Columns["District"].ColumnName = "DISTRICT";
                dt.Columns["TOTAL_BENEFICIARIES"].ColumnName = "TOTAL BENEFICIARIES";
                dt.Columns["TOTAL_PLOTS"].ColumnName = "TOTAL PLOTS";
                dt.Columns["TOTAL_AADHARS"].ColumnName = "NO. OF PLOTS HAVING AADHARS";
                dt.Columns["NEED_TO_UPDATE_AADHAARS"].ColumnName = "NO. OF PLOTS NOT HAVING AADHARS";
                dt.Columns["HAVING_MANDAL"].ColumnName = "NO. OF PLOTS HAVING MANDAL";
                dt.Columns["not_HAVING_MANDAL"].ColumnName = "NO. OF PLOTS NOT HAVING MANDAL";
                dt.Columns["HAVING_VILLAGE"].ColumnName = "NO. OF PLOTS HAVING VILLAGE";
                dt.Columns["not_HAVING_VILLAGE"].ColumnName = "NO. OF PLOTS NOT HAVING VILLAGE";
                dt.Columns["GRAM_PANCHAYAT"].ColumnName = "NO. OF PLOTS HAVING GRAM PANCHAYAT";
                dt.Columns["not_GRAM_PANCHAYAT"].ColumnName = "NO. OF PLOTS NOT HAVING GRAM PANCHAYAT";
                dt.Columns["Habitation"].ColumnName = "NO. OF PLOTS HAVING HABITATION";
                dt.Columns["not_having_Habitation"].ColumnName = "NO. OF PLOTS NOT HAVING HABITATION";
                dt.Columns["HAVING_FOREST_DIVISION"].ColumnName = "NO. OF PLOTS HAVING FOREST DIVISION ";
                dt.Columns["not_HAVING_FOREST_DIVISION"].ColumnName = "NO. OF PLOTS NOT HAVING FOREST DIVISION";
                dt.Columns["HAVING_FOREST_RANGE"].ColumnName = "NO. OF PLOTS HAVING FOREST RANGE";
                dt.Columns["not_HAVING_FOREST_RANGE"].ColumnName = "NO. OF PLOTS NOT HAVING FOREST RANGE";
                dt.Columns["HAVING_FOREST_BEAT"].ColumnName = "NO. OF PLOTS HAVING FOREST BEAT";
                dt.Columns["not_HAVING_FOREST_BEAT"].ColumnName = "NO. OF PLOTS NOT HAVING FOREST BEAT";
                dt.Columns["HAVING_FOREST_BLOCK"].ColumnName = "NO. OF PLOTS HAVING FOREST BLOCK";
                dt.Columns["not_HAVING_FOREST_BLOCK"].ColumnName = "NO. OF PLOTS NOT HAVING FOREST BLOCK";
                dt.Columns["PLOTS_HAVING_COMPARTMENT_NUMBER"].ColumnName = "NO. OF PLOTS HAVING COMPARTMENT NO.";
                dt.Columns["PLOTS_NOT_HAVING_COMPARTMENT_NUMBER"].ColumnName = "NO. OF PLOTS NOT HAVING COMPARTMENT NO.";
                dt.Columns["HAVING_PLOT_NO"].ColumnName = "NO. OF PLOTS HAVING PLOT NO.";
                dt.Columns["NOT_HAVING_PLOT_NO"].ColumnName = "NO. OF PLOTS NOT HAVING PLOT NO.";
                dt.Columns["PLOTS_HAVING_EXTENTPLOTAREA"].ColumnName = "NO. OF PLOTS HAVING EXTENTPLOTAREA";
                dt.Columns["PLOTS_NOT_HAVING_EXTENTPLOTAREA"].ColumnName = "NO. OF PLOTS NOT HAVING EXTENTPLOTAREA";
                dt.Columns["HAVING_PATTA_INAMGOVT"].ColumnName = "NO. OF PLOTS HAVING PATTA INAMGOVT";
                dt.Columns["NOT_HAVING_PATTA_INAMGOVT"].ColumnName = "NO. OF PLOTS NOT HAVING PATTA INAMGOVT";
                dt.Columns["PLOTS_HAVING_ROFR_PATTANO"].ColumnName = "NO. OF PLOTS HAVING PATTA NO. ";
                dt.Columns["PLOTS_NOT_HAVING_ROFR_PATTANO"].ColumnName = "NO. OF PLOTS NOT HAVING PATTA NO.";
                dt.Columns["PLOTS_HAVING_ROFR_PATTADAAR"].ColumnName = "NO. OF PLOTS HAVING PATTADAAR ";
                dt.Columns["PLOTS_NOT_HAVING_ROFR_PATTADAAR"].ColumnName = "NO. OF PLOTS NOT HAVING PATTADAAR";
                dt.Columns["PLOTS_HAVING_CULTIVATOR_NAME"].ColumnName = "NO. OF PLOTS HAVING CULTIVATOR NAME";
                dt.Columns["PLOTS_NOT_HAVING_CULTIVATOR_NAME"].ColumnName = "NO. OF PLOTS NOT HAVING CULTIVATOR NAME";
                dt.Columns["PLOTS_HAVING_HOLDING_NATURE"].ColumnName = "NO. OF PLOTS HAVING HOLDING NATURE";
                dt.Columns["PLOTS_NOT_HAVING_HOLDING_NATURE"].ColumnName = "NO. OF PLOTS NOT HAVING HOLDING NATURE";
                dt.Columns["PLOTS_HAVING_Land_Classification_Name"].ColumnName = "NO. OF PLOTS HAVING LAND CLASSIFICATION";
                dt.Columns["PLOTS_NOT_HAVING_Land_Classification_Name"].ColumnName = "NO. OF PLOTS NOT HAVING LAND CLASSIFICATION";
                dt.Columns["PLOTS_HAVING_BANKACCOUNTNO"].ColumnName = "NO. OF PLOTS HAVING BANK ACCOUNT NO.";
                dt.Columns["PLOTS_NOT_HAVING_BANKACCOUNTNO"].ColumnName = "NO. OF PLOTS NOT HAVING BANK ACCOUNT NO.";
                dt.Columns["PLOTS_HAVING_IFSCCODE"].ColumnName = "NO. OF PLOTS HAVING IFSC CODE";
                dt.Columns["PLOTS_NOT_HAVING_IFSCCODE"].ColumnName = "NO. OF PLOTS NOT HAVING IFSC CODE";
                dt.Columns["PLOTS_WITH_ALL_MANDATORY_FIELDS"].ColumnName = "NO. OF PLOTS HAVING ALL MANDATORY FIELDS";
                dt.Columns["PLOTS_NOT_HAVING_ALL_MANDATORY_FIELDS"].ColumnName = "NO. OF PLOTS NOT HAVING ANY ONE OF THE MANDATORY FIELDS";
             
                if (dt.Rows.Count > 0)
                {
                    string filename = "DATAANALYSIS_FOR_MANDATORYFIELDS.xls";
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
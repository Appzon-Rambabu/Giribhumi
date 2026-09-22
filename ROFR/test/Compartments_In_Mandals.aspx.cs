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
    public partial class Compartments_In_Mandals : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "Compartments_In_Mandals.aspx")
                    {
                        string Itda = (string)(Session["ItdaMandalvalue"]);
                        string Mandal = (string)(Session["Mandalvalue"]);
                        string Village= (string)(Session["Villagevalue"]);
                        txtItda.Text = Itda;
                       // txtmandal.Text = Mandal;
                        if (Itda != "")
                        {
                            if (Mandal != "")
                            {
                                BindData(Itda);
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
                          //  txtmandal.Text = Mandal;
                            if (Itda != "")
                            {
                                if (Mandal != "")
                                {
                                    BindData(Itda);
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


        protected void BindData(string Itda)
        {
            try
            {
                DataTable dt = Landsettlementpattas.ItdaWiseCompartmentsInTwoMandals(Itda);
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

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {

             

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }


  

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtbeneficiareies = new DataTable();
                dtbeneficiareies = Landsettlementpattas.ItdaWiseCompartmentsInTwoMandals((string)(Session["ItdaMandalvalue"]));
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
                Session["CurrentPage"] = "MandalwiseLandDetails.aspx";
                Session["Itdavalue"] = (string)(Session["ItdaMandalvalue"]);
                Response.Redirect("~//test//MandalwiseLandDetails.aspx");
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
                DataTable dt = Landsettlementpattas.ItdaWiseCompartmentsInTwoMandals((string)(Session["ItdaMandalvalue"]));
                //dt = calculatetotals(dt);
                dt.Columns["Compartment_No"].ColumnName = "Compartment Number";
                dt.Columns["Mandal"].ColumnName = "Mandal";
                dt.Columns["Total_Beneficiaries"].ColumnName = "Beneficiaries";
                dt.Columns["Beneficiaries_Having_Adhaar_no"].ColumnName = "No of Beneficiaries Having Adhaar No";
                dt.Columns["Total_Land"].ColumnName = "Total Land (In Acres)";
                if (dt.Rows.Count > 0)
                {
                    string filename = "CompartmentsinTwoMandals.xls";
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
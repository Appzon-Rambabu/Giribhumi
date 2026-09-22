using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.Drawing;



namespace ROFR.test
{
    public partial class ITDA_HEALTH : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindDistrict();
                    BindFacility();
                    ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));




                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindDistrict()
        {
            try

            {


                DataTable dtdist = Landsettlementpattas.GetHealthMasters("", "", "","DISTRICT");

                if (dtdist.Rows.Count > 0)
                {
                    ddl_district.DataSource = dtdist;
                    ddl_district.DataTextField = "DISTRICT";
                    ddl_district.DataValueField = "LGD_DISTRICT_CODE";
                    ddl_district.DataBind();
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
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



        private void BindFacility()
        {
            try

            {


                DataTable dtf = Landsettlementpattas.GetHealthMasters("", "", "", "HEALTH");

                if (dtf.Rows.Count > 0)
                {
                    ddl_facility.DataSource = dtf;
                    ddl_facility.DataTextField = "HEALTH_FACILITY";
                    ddl_facility.DataValueField = "HEALTH_FACILITY";
                    ddl_facility.DataBind();
                    ddl_facility.Items.Insert(0, new ListItem("Select", "0"));
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

        private void BindHospital(DataTable dt)
        {
            try
            {
                DataTable dthospital = dt;
                ddl_hospital.DataSource = dthospital;
                ddl_hospital.DataTextField = "HOSPTIAL_NAME";
                ddl_hospital.DataValueField = "HOSPTIAL_NAME";
                ddl_hospital.DataBind();
                ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                ddl_hospital.Items.Clear();


                ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void ddl_facility_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //ddl_hospital.Items.Clear();


                //ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_district.SelectedItem.Text != "Select" && ddl_facility.SelectedItem.Text != "Select")
                {

                    DataTable dthospital = Landsettlementpattas.GetHealthMasters(ddl_district.SelectedItem.Text, ddl_facility.SelectedItem.Text,"", "HOSPITAL");
                    if (dthospital.Rows.Count > 0)
                    {

                        BindHospital(dthospital);


                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void ddl_hospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //ddl_hospital.Items.Clear();


                //ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_district.SelectedItem.Text != "Select" && ddl_facility.SelectedItem.Text != "Select")
                {

                    DataTable dt = Landsettlementpattas.GetHealthMasters(ddl_district.SelectedItem.Text, ddl_facility.SelectedItem.Text, ddl_hospital.SelectedItem.Text, "DISPLAY");
                    if (dt.Rows.Count > 0)
                    {

                        DataTable dt1 = new DataTable();
                        dt1.Columns.Add("District", typeof(string));
                        dt1.Columns.Add("Health Facility", typeof(string));
                        dt1.Columns.Add("Hospital", typeof(string));
                        dt1.Columns.Add("Function Name", typeof(string));
                        dt1.Columns.Add("As per Norms", typeof(string));
                        dt1.Columns.Add("Submitted", typeof(string));
                        dt1.Columns.Add("GAP", typeof(string));
                        DataRow dr1 = dt1.NewRow();
                        dr1[0] = ddl_district.SelectedItem.Text;
                         dr1[1] = ddl_facility.SelectedItem.Text;
                        dr1[2] = ddl_hospital.SelectedItem.Text;
                        dr1[3] = "Total";
                        dr1[4] = dt.Rows[0]["STATUS"].ToString();
                        dr1[5] = dt.Rows[0]["VALUE"].ToString();
                        dr1[6] = dt.Rows[0]["GAP"].ToString();
                        dt1.Rows.Add(dr1);
                        DataRow dr2 = dt1.NewRow();
                        dr2[0] = ddl_district.SelectedItem.Text;
                        dr2[1] = ddl_facility.SelectedItem.Text;
                        dr2[2] = ddl_hospital.SelectedItem.Text;
                        dr2[3] = "Circular Area and Walls area (27.2%)";
                        dr2[4] = dt.Rows[0]["STATUS_PER"].ToString();  
                         dr2[5] = dt.Rows[0]["VALUE_PER"].ToString();
                        dr2[6] = dt.Rows[0]["GAP_PER"].ToString();
                        dt1.Rows.Add(dr2);
                        DataRow dr3 = dt1.NewRow();
                        dr3[0] = ddl_district.SelectedItem.Text;
                        dr3[1] = ddl_facility.SelectedItem.Text;
                        dr3[2] = ddl_hospital.SelectedItem.Text;
                        dr3[3] = "Grand Total";
                        dr3[4] = dt.Rows[0]["STATUS_ADD"].ToString();
                        dr3[5] = dt.Rows[0]["VALUE_ADD"].ToString();
                        dr3[6] = dt.Rows[0]["GAP_ADD"].ToString();
                        dt1.Rows.Add(dr3);
                        DataRow dr4 = dt1.NewRow();
                        dr4[0] = ddl_district.SelectedItem.Text;
                        dr4[1] = ddl_facility.SelectedItem.Text;
                        dr4[2] = ddl_hospital.SelectedItem.Text;
                        dr4[3] = "Critical Zone (Yes%):";
                        dr4[4] = dt.Rows[0]["CRITICALZONE_YES"].ToString();
                        dr4[5] = "";
                        dr4[6] = "";
                        dt1.Rows.Add(dr4);
                        DataRow dr5 = dt1.NewRow();
                        dr5[0] = ddl_district.SelectedItem.Text;
                        dr5[1] = ddl_facility.SelectedItem.Text;
                        dr5[2] = ddl_hospital.SelectedItem.Text;
                        dr5[3] = "Diagnostic Zone (Yes%):";
                        dr5[4] = dt.Rows[0]["DIAGNOSTICZONE_YES"].ToString();
                        dr5[5] = "";
                        dr5[6] = "";
                        dt1.Rows.Add(dr5);
                        DataRow dr6 = dt1.NewRow();
                        dr6[0] = ddl_district.SelectedItem.Text;
                        dr6[1] = ddl_facility.SelectedItem.Text;
                        dr6[2] = ddl_hospital.SelectedItem.Text;
                        dr6[3] = "Intermediate Zone (inpatient Nursing units)(Yes%):";
                        dr6[4] = dt.Rows[0]["INTER_YES"].ToString();
                        dr6[5] = "";
                        dr6[6] = "";
                        dt1.Rows.Add(dr6);
                        DataRow dr7 = dt1.NewRow();
                        dr7[0] = ddl_district.SelectedItem.Text;
                        dr7[1] = ddl_facility.SelectedItem.Text;
                        dr7[2] = ddl_hospital.SelectedItem.Text;
                        dr7[3] = "Service Zone(Yes%):";
                        dr7[4] = dt.Rows[0]["SERVICE_YES"].ToString();
                        dr7[5] = "";
                        dr7[6] = "";
                        dt1.Rows.Add(dr7);
                        DataRow dr8 = dt1.NewRow();
                        dr8[0] = ddl_district.SelectedItem.Text;
                        dr8[1] = ddl_facility.SelectedItem.Text;
                        dr8[2] = ddl_hospital.SelectedItem.Text;
                        dr8[3] = "Critical Zone (No%):";
                        dr8[4] = dt.Rows[0]["CRITICALZONE_NO"].ToString();
                        dr8[5] = "";
                        dr8[6] = "";
                        dt1.Rows.Add(dr8);
                        DataRow dr9 = dt1.NewRow();
                        dr9[0] = ddl_district.SelectedItem.Text;
                        dr9[1] = ddl_facility.SelectedItem.Text;
                        dr9[2] = ddl_hospital.SelectedItem.Text;
                        dr9[3] = "Diagnostic Zone (No%):";
                        dr9[4] = dt.Rows[0]["DIAGNOSTICZONE_NO"].ToString();
                        dr9[5] = "";
                        dr9[6] = "";
                        dt1.Rows.Add(dr9);
                        DataRow dr10 = dt1.NewRow();
                        dr10[0] = ddl_district.SelectedItem.Text;
                        dr10[1] = ddl_facility.SelectedItem.Text;
                        dr10[2] = ddl_hospital.SelectedItem.Text;
                        dr10[3] = "Intermediate Zone (inpatient Nursing units) (No%):";
                        dr10[4] = dt.Rows[0]["INTER_NO"].ToString();
                        dr10[5] = "";
                        dr10[6] = "";
                        dt1.Rows.Add(dr10);
                        DataRow dr11 = dt1.NewRow();
                       
                        dr11[0] = ddl_district.SelectedItem.Text;
                        dr11[1] = ddl_facility.SelectedItem.Text;
                        dr11[2] = ddl_hospital.SelectedItem.Text;
                        dr11[3] = "Service Zone (No%):";
                        dr11[4] = dt.Rows[0]["SERVICE_NO"].ToString();
                        dr11[5] = "";
                        dr11[6] = "";
                        dt1.Rows.Add(dr11);

                       
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();

                        Session["gdata"] = dt1;



                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }


        }

        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)(Session["gdata"]);
           

                if (dt.Rows.Count > 0)
                {
                    string filename = "HealthAnalysis.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CadetBlue;

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
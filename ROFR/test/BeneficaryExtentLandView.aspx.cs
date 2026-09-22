using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using ROFR.helper;
using System.Data.OleDb;
using System.IO;
using System.Configuration;

namespace ROFR.test
{
    public partial class BeneficaryExtentLandView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindItda();
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_Village.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
                    uploadfile.Visible = false;



                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        private void BindItda()
        {
            try
            {
                DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetExtentlandItdadetails((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_NAME";
                    ddl_ITda.DataBind();
                    ddl_ITda.Items.Insert(0, new ListItem("Select", "0"));
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

        private void BindDistrict(DataTable dt)
        {
            try
            {
                DataTable dtDistricts = dt;
                ddl_district.DataSource = dtDistricts;
                ddl_district.DataTextField = "DISTRICT_NAME";
                ddl_district.DataValueField = "DISTRICT_CODE";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindMandal(DataTable dtMandal)
        {
            try
            {

                ddl_mandal.DataSource = dtMandal;
                ddl_mandal.DataTextField = "MANDAL_NAME";
                ddl_mandal.DataValueField = "MANDAL_NAME";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        private void BindVillage(DataTable dtVillages)
        {
            try
            {
                ddl_Village.DataSource = dtVillages;
                ddl_Village.DataTextField = "VILLAGE_NAME";
                ddl_Village.DataValueField = "VILLAGE_NAME";
                ddl_Village.DataBind();
                ddl_Village.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindHabitations(DataTable dt)
        {
            try
            {
                ddl_hab.DataSource = dt;
                ddl_hab.DataTextField = "HAB_NAME";
                ddl_hab.DataValueField = "HAB_NAME";
                ddl_hab.DataBind();
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void Bindpattadhar(DataTable dt)
        {
            try
            {
                ddl_pattadhar.DataSource = dt;
                ddl_pattadhar.DataTextField = "ROFR_PATTADAAR";
                ddl_pattadhar.DataValueField = "ROFR_PATTADAAR";
                ddl_pattadhar.DataBind();
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void Bindextent(DataTable dt)
        {
            try
            {
                ddl_extentplotarea.DataSource = dt;
                ddl_extentplotarea.DataTextField = "ExtentPlotArea";
                ddl_extentplotarea.DataValueField = "ExtentPlotArea";
                ddl_extentplotarea.DataBind();
                ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindHabitations()
        {
            try
            {
                if (ddl_ITda.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" &&
                    ddl_Village.SelectedItem.Text != "Select" && ddl_hab.SelectedItem.Text != "Select" && ddl_pattadhar.SelectedItem.Text != "Select" && ddl_extentplotarea.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    // GridView1.Visible = false;


                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.Getbenlatlongsdata(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue, ddl_pattadhar.SelectedValue, ddl_extentplotarea.SelectedValue);
                    Session["latlongId"] = dt.Rows[0]["ID"].ToString();
                    DataTable dt1 = MastersDataAnalysisBAL.MastersDataAnalysis.Getbenlatlongsdata(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue, ddl_pattadhar.SelectedValue, ddl_extentplotarea.SelectedValue, (string)(Session["latlongId"]));
                    if (dt1.Rows.Count > 0)
                    {
                        dt1.Columns.Add("Sno");
                        dt1.Rows[0]["Sno"] = "1";
                        for (int i = 2; i <= 20; i++)
                        {
                            DataRow row;
                            row = dt1.NewRow();
                            row["Sno"] = i.ToString();
                            dt1.Rows.Add(row);
                        }
                        //  GridView1.Visible = true;

                        // GridView1.DataSource = dt1;
                        // GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                        //  GridView1.Visible = false;

                        DataTable DTR = new DataTable();
                        DTR.Columns.Add("LATITUDE");
                        DTR.Columns.Add("LONGITUDE");
                        DataRow dr = DTR.NewRow();
                        DTR.Rows.Add(dr);

                    }
                }
                else
                {


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }



        protected void ddlitda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl_mandal.Items.Clear();
                ddl_Village.Items.Clear();
                ddl_hab.Items.Clear();
                ddl_pattadhar.Items.Clear();
                ddl_extentplotarea.Items.Clear();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_Village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_ITda.SelectedItem.Text != "Select")
                {




                    DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetextentlandbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindDistrict(dtMandal);
                        if (dtMandal.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            ddl_mandal.ClearSelection();
                            ddl_Village.ClearSelection();

                            DataTable dtMandal1 = MastersDataAnalysisBAL.MastersDataAnalysis.GetextentlandbenmandalDetails(ddl_ITda.SelectedItem.Text,ddl_district.SelectedValue, (string)(Session["username"]));
                            if (dtMandal1.Rows.Count > 0)
                            {
                                BindMandal(dtMandal1);
                                ddl_Village.DataSource = null;
                                ddl_Village.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                            }
                        }
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

        protected void ddldistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_Village.Items.Clear();
                ddl_hab.Items.Clear();
                ddl_pattadhar.Items.Clear();
                ddl_extentplotarea.Items.Clear();
                ddl_Village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    if (ddl_district.SelectedValue != "0")
                    {
                        if (ddl_ITda.SelectedItem.Text != "Select")
                        {
                            if (ddl_ITda.SelectedValue != "0")
                            {
                                ddl_mandal.ClearSelection();
                                ddl_Village.ClearSelection();

                                DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetextentlandbenmandalDetails(ddl_ITda.SelectedItem.Text,ddl_district.SelectedValue, (string)(Session["username"]));
                                if (dtMandal.Rows.Count > 0)
                                {
                                    BindMandal(dtMandal);
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select Itda Name')", true);
                                ddl_district.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select Itda Name')", true);
                            ddl_district.SelectedIndex = 0;
                        }
                    }
                    else
                    {

                    }

                }
                else
                {
                    ddl_mandal.ClearSelection();
                    ddl_Village.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void ddlmandal_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_Village.Items.Clear();
                ddl_hab.Items.Clear();
                ddl_pattadhar.Items.Clear();
                ddl_extentplotarea.Items.Clear();
                ddl_Village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    DataTable dtVillages = MastersDataAnalysisBAL.MastersDataAnalysis.GetextentlandbenvillageDetails(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, (string)(Session["username"]));
                    if (dtVillages.Rows.Count > 0)
                    {
                        if (dtVillages.Rows.Count > 0)
                        {
                            BindVillage(dtVillages);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        }

                    }
                }
                else
                {
                    ddl_Village.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlvillage_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_hab.Items.Clear();
                ddl_pattadhar.Items.Clear();
                ddl_extentplotarea.Items.Clear();

                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_Village.SelectedItem.Text != "Select")
                {
                    DataTable dtVillages = MastersDataAnalysisBAL.MastersDataAnalysis.Getextentlandbenhabitations(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue);
                    if (dtVillages.Rows.Count > 0)
                    {
                        if (dtVillages.Rows.Count > 0)
                        {
                            BindHabitations(dtVillages);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        }

                    }
                }
                else
                {
                    ddl_Village.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlhab_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl_pattadhar.Items.Clear();
                ddl_extentplotarea.Items.Clear();

                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_hab.SelectedItem.Text != "Select")
                {
                    DataTable dtVillages = MastersDataAnalysisBAL.MastersDataAnalysis.Getextentlandbenpattadhar(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue);
                    if (dtVillages.Rows.Count > 0)
                    {
                        if (dtVillages.Rows.Count > 0)
                        {
                            Bindpattadhar(dtVillages);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        }

                    }
                }
                else
                {
                    ddl_hab.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlpattadhar_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_extentplotarea.Items.Clear();

                ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_pattadhar.SelectedItem.Text != "Select")
                {
                    DataTable dtVillages = MastersDataAnalysisBAL.MastersDataAnalysis.Getextentlandbenpattadharextent(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue, ddl_pattadhar.SelectedValue);
                    if (dtVillages.Rows.Count > 0)
                    {
                        if (dtVillages.Rows.Count > 0)
                        {
                            Bindextent(dtVillages);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        }

                    }
                }
                else
                {
                    ddl_pattadhar.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlextentplotarea_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_extentplotarea.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    // GridView1.Visible = false;


                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.Getextentlandbenlatlongsdata(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue, ddl_pattadhar.SelectedValue, ddl_extentplotarea.SelectedValue);
                    Session["latlongId"] = dt.Rows[0]["ID"].ToString();
                    uploadfile.Visible = true;

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }







        protected void btnmap_Click(object sender, EventArgs e)
        {
            try
            {
                Session["BeneficaryMapid"] = (string)(Session["latlongId"]);
                string url = "../pages/BeneficaryLandView.aspx";
                string s = "window.open('" + url + "', 'popup_window', 'width=500,height=500,resizable=yes');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void import(string FilePath, string Extension)
        {
            try
            {
                string conStr = "";

                switch (Extension)

                {

                    case ".xls": //Excel 97-03

                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                                 .ConnectionString;

                        break;

                    case ".xlsx": //Excel 07

                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                                  .ConnectionString;

                        break;

                }

                conStr = String.Format(conStr, FilePath, "Yes");

                OleDbConnection connExcel = new OleDbConnection(conStr);

                OleDbCommand cmdExcel = new OleDbCommand();

                OleDbDataAdapter oda = new OleDbDataAdapter();

                DataTable dt = new DataTable();

                cmdExcel.Connection = connExcel;



                //Get the name of First Sheet

                connExcel.Open();

                DataTable dtExcelSchema;

                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                connExcel.Close();



                //Read Data from First Sheet

                connExcel.Open();

                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                oda.SelectCommand = cmdExcel;

                oda.Fill(dt);

                connExcel.Close();

                BeneficiaryDetails BeneficiaryDetailsobj = new BeneficiaryDetails();
                DataTable dtUpdateDetails = new DataTable();
                dtUpdateDetails.Columns.Add("Option1");
                dtUpdateDetails.Columns.Add("Option2");
                dtUpdateDetails.Columns.Add("Option3");
                dtUpdateDetails.Columns.Add("Option4");
                dtUpdateDetails.Columns.Add("Option5");

                foreach (DataRow drow in dt.Rows)
                {
                    if ((string)(Session["latlongId"]) != "")
                    {
                        System.Data.DataRow dr = dtUpdateDetails.NewRow();

                        //dr["Option1"] = Convert.ToInt32(drow["IDNUMBER"].ToString().Trim());
                        //dr["Option2"] = drow["Aadhaar_NO"].ToString().Trim();
                        //dr["Option3"] = drow["Accountnumber"].ToString().Trim();
                        //dr["Option4"] = drow["IFSCCODE"].ToString().Trim();
                        //dr["Option5"] = drow["BANKNAME"].ToString().Trim();
                        if (!string.IsNullOrEmpty((string)(Session["username"])))
                        {
                            dr["Option1"] = Convert.ToInt32((string)(Session["latlongId"]));
                            dr["Option2"] = drow["LATITUDE"].ToString().Trim();
                            dr["Option3"] = drow["LONGITUDE"].ToString().Trim();
                            // dr["Option4"] = drow["IFSCCODE"].ToString().Trim();
                            // dr["Option5"] = drow["BANKNAME"].ToString().Trim();


                            dtUpdateDetails.Rows.Add(dr);
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                            break;
                        }
                    }
                }

                BeneficiaryDetailsobj.UpdateForestMasterDetails = dtUpdateDetails;
                if (dtUpdateDetails.Rows.Count > 0)
                {
                    MastersDataAnalysisBAL.MastersDataAnalysis.INSERTlatlongsdata(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue, ddl_pattadhar.SelectedValue, ddl_extentplotarea.SelectedValue, (string)(Session["latlongId"]), BeneficiaryDetailsobj);
                    // ProjectRofrBAL.GetMasterDetails.importUpdateValidateBeneficiaryDetails(BeneficiaryDetailsobj, (string)(Session["username"]), ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, radioid.SelectedValue);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('LatLongs Inserted Successfully !')", true);
                    BindHabitations();
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
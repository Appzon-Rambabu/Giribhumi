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
using System.Web.Helpers;
using System.Web.SessionState;
using System.Reflection;

namespace ROFR.pages
{
    public partial class UpdateLatLongs : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_Village.Items.Insert(0, new ListItem("Select", "0"));
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
            ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
            ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
        }
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
                string sessionstring = (string)(Session["username"]);
                if ((string)(Session["username"]) == "master_admin")
                {
                    sessionstring = "admin";
                }
                else
                {
                    sessionstring = (string)(Session["username"]);
                }
                DataTable dtItda = Landsettlementpattas.GetRofrMasters2((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);

                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_CODE";
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
                ddl_district.DataValueField = "LGD_DISTRICT_CODE";
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
                ddl_mandal.DataValueField = "LGD_MANDAL_CODE";
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
                ddl_Village.DataValueField = "LGD_VILLAGE_CODE";
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
                ddl_hab.DataTextField = "HABITATION";
                ddl_hab.DataValueField = "HabitationCode";
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
                ddl_pattadhar.DataValueField = "benficiary_id2";
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
                ddl_extentplotarea.DataValueField = "id";
                ddl_extentplotarea.DataBind();
                ddl_extentplotarea.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void Bindgrid()
        {
            try
            {
                if (ddl_ITda.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" &&
                    ddl_Village.SelectedItem.Text != "Select" && ddl_hab.SelectedItem.Text != "Select" && ddl_pattadhar.SelectedItem.Text != "Select" && ddl_extentplotarea.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    GridView1.Visible = false;


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
                        GridView1.Visible = true;

                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                        GridView1.Visible = false;

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


                    string sessionstring = (string)(Session["username"]);
                    if ((string)(Session["username"]) == "master_admin")
                    {
                        sessionstring = "admin";
                    }
                    else
                    {
                        sessionstring = (string)(Session["username"]);
                    }
                    DataTable dtMandal = Landsettlementpattas.GetRofrMasters2((string)(Session["username"]), "District", ddl_ITda.SelectedValue, "", "", "", "", (string)Session["userprevilages"]);

                    if (dtMandal.Rows.Count > 0)
                    {
                        BindDistrict(dtMandal);
                        if (dtMandal.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            ddl_mandal.ClearSelection();
                            ddl_Village.ClearSelection();
                            DataTable dtMandal1 = Landsettlementpattas.GetRofrMasters2((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", (string)Session["userprevilages"]);

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
                                string sessionstring = (string)(Session["username"]);
                                if ((string)(Session["username"]) == "master_admin")
                                {
                                    sessionstring = "admin";
                                }
                                else
                                {
                                    sessionstring = (string)(Session["username"]);
                                }
                                DataTable dtMandal = Landsettlementpattas.GetRofrMasters2((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", (string)Session["userprevilages"]);

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
                    string sessionstring = (string)(Session["username"]);
                    if ((string)(Session["username"]) == "master_admin")
                    {
                        sessionstring = "admin";
                    }
                    else
                    {
                        sessionstring = (string)(Session["username"]);
                    }
                    DataTable dtVillages = Landsettlementpattas.GetRofrMasters2((string)(Session["username"]), "Village", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);

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
                    DataTable dtVillages = Landsettlementpattas.GetRofrMasters2((string)(Session["username"]), "Habitation", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedItem.Text, "", (string)Session["userprevilages"]);

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
                    DataTable dtVillages = MastersDataAnalysisBAL.MastersDataAnalysis.Getbenpattadhar(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedItem.Text, ddl_hab.SelectedItem.Text);
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
                    DataTable dtVillages = MastersDataAnalysisBAL.MastersDataAnalysis.Getbenpattadharextent(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue, ddl_pattadhar.SelectedItem.Text, ddl_pattadhar.SelectedValue);
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
                    GridView1.Visible = false;


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
                        GridView1.Visible = true;

                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                        uploadfile.Visible = true;

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                        GridView1.Visible = false;

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


        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                Bindgrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                        string id = GridView1.DataKeys[e.RowIndex].Values["L_ID"].ToString();

                        TextBox FDC = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_divisioncode");
                        TextBox FDN = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_division");


                        if (FDC.Text == "" || FDN.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter Values')", true);
                        }
                        else
                        {
                            Regex rx = new Regex(@"^[\.0-9]*$");

                            if (rx.IsMatch(FDC.Text) && rx.IsMatch(FDN.Text))
                            {

                                string IPAddress = (string)(Session["IPAddress"]);


                                if (!string.IsNullOrEmpty((string)(Session["username"])))
                                {
                                    if (id == "0" || id == "")
                                    {
                                        if ((string)(Session["latlongId"]) != "")
                                        {
                                            MastersDataAnalysisBAL.MastersDataAnalysis.addINSERTlatlongsdata(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue, ddl_pattadhar.SelectedValue, ddl_extentplotarea.SelectedValue,(string)(Session["latlongId"]), FDC.Text, FDN.Text);
                                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Latlongs Update Successfully')", true);
                                        }
                                    }
                                    else
                                    {
                                        MastersDataAnalysisBAL.MastersDataAnalysis.updatelatlongsdata(id, (string)(Session["latlongId"]), FDC.Text, FDN.Text);
                                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Latlongs Update Successfully')", true);
                                    }


                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                                }
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('please enter valid data!')", true);
                            }

                        }
                    }
                   
              
            
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = -1;
                Bindgrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string id = GridView1.DataKeys[e.RowIndex].Values["L_ID"].ToString();
                if (id != "")
                {
                    if (id != "0")
                    {
                        if (id != "0")
                        {
                            if ((string)(Session["latlongId"]) != "")
                            {
                                MastersDataAnalysisBAL.MastersDataAnalysis.DELETElatlongsdata(id, (string)(Session["latlongId"]));
                                Bindgrid();
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Latlong Delete Successfully')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
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
        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string stor_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "L_ID"));
                    Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                    if (lnkbtnresult != null)
                    {
                        lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + ID + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
               
                        if (e.CommandName.Equals("AddNew"))

                        {
                            Regex rx = new Regex(@"^[\.0-9]*$");

                            TextBox FDC = new TextBox();
                            TextBox FDN = new TextBox();
                            if (GridView1.Visible != false)
                            {
                                FDC = (TextBox)GridView1.FooterRow.FindControl("instorid");
                                FDN = (TextBox)GridView1.FooterRow.FindControl("inname");
                            }

                            if (rx.IsMatch(FDC.Text) && rx.IsMatch(FDN.Text))
                            {

                                string IPAddress = (string)(Session["IPAddress"]);

                                if (!string.IsNullOrEmpty((string)(Session["username"])))
                                {
                                    MastersDataAnalysisBAL.MastersDataAnalysis.addINSERTlatlongsdata(ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedValue, ddl_pattadhar.SelectedValue, ddl_extentplotarea.SelectedValue, (string)(Session["latlongId"]), FDC.Text, FDN.Text);
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Latlongs Added Successfully')", true);
                                    Bindgrid();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please enter valid data')", true);
                                return;

                            }



                        }
                   
               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                       //AntiForgery.Validate();
                        if ((string)(Session["latlongId"]) != "")
                        {
                            string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file

                            string filename1 = Path.GetFileName(filePath);     // getting the file name of uploaded file

                            filename1 = (string)(Session["latlongId"]) + filename1;
                            string ext = Path.GetExtension(filename1);
                            // getting the file extension of uploaded file
                            if (filename1 != "")//&& ddl_ITda.SelectedItem.Text != "" && ddl_district.SelectedItem.Text != ""
                            {
                                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
                                 string FilePath = HttpContext.Current.Server.MapPath(FolderPath + filename1);

                                FileUpload1.SaveAs(FilePath);
                                string type = String.Empty;
                                String strConnection = "";

                                import(FilePath, ext);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' please select file and Itda and District !')", true);
                            }
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);

                        }
                   
                
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }



        protected void errorlogoutfunctn()
        {
            

            //  ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Logout Successfully')", true);
            string user = (string)(Session["masterusername"]);
            // ProjectRofrBAL.GetMasterDetails.User_Authentication_update((string)(Session["masterusername"]), "0","");
            ProjectRofrBAL.GetMasterDetails.User_Authentication_logout_update((string)(Session["masterusername"]), "0", DateTime.Now.ToString(), (string)(Session["Login"]));
            ProjectRofrBAL.GetMasterDetails.User_Authenticationlog((string)(Session["masterusername"]), HttpContext.Current.Request.UserHostAddress, "Logout");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Expires = -1;
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetAllowResponseInBrowserHistory(false);

            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));

            //Response.AddHeader("Cache-Control", "no-cache,private, no-store, must-revalidate, pre-check=0, post-check=0,max-stale=0,Accept,Accept-Encoding,Accept-Language,Cache-Control,Content-Type,Host,Origin,Pragma,Referer,User-Agent,username,sessionid");
            //Response.AddHeader("Pragma", "no-cache");
            //Response.AddHeader("Expires", "0");
            //Response.Headers.Remove("X-AspNet-Version");
            //Response.Headers.Remove("X-AspNetMvc-Version");
            //Response.Headers.Remove("X-Powered-By");
            //Response.Headers.Remove("Server");

            HttpContext.Current.Response.Headers.Remove("X-Powered-By");
            HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            HttpContext.Current.Response.Headers.Remove("X-AspNetMvc-Version");
            HttpContext.Current.Response.Headers.Remove("Server");

            //HttpContext.Current.Response.AddHeader("X-Frame-Options", "DENY");
            HttpContext.Current.Response.AddHeader("X-XSS-Protection", "1; mode=block");
            HttpContext.Current.Response.AddHeader("X-Content-Type-Options", "nosniff");
            HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache,private, no-store, must-revalidate,max-stale=0, post-check=0, pre-check=0");
            HttpContext.Current.Response.AddHeader("Pragma", "no-cache");
            HttpContext.Current.Response.AddHeader("Expires", "0");

            HttpContext.Current.Response.AddHeader("X-Permitted-Cross-Domain-Policies", "none");
            HttpContext.Current.Response.AddHeader("Strict-Transport-Security", "max-age=31536000; includeSubDomains");

            HttpContext.Current.Response.AddHeader("Content-Security-Policy-Report-Only", "script-src 'self'; report-uri: http://giribhumi.staging.ap.gov.in/staging%20tribal/;");
            //Session.Abandon();
            //Session.Clear();
            //Session.RemoveAll();
            if (Request.Cookies["ROFR1.0"] != null)
            {
                Response.Cookies["ROFR1.0"].Value = string.Empty;
                Response.Cookies["ROFR1.0"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["ROFR1.0"] != null)
            {
                Response.Cookies["ROFR1.0"].Value = string.Empty;
                Response.Cookies["ROFR1.0"].Expires = DateTime.Now.AddMonths(-20);
            }
            try
            {


                //Session.RemoveAll();

                Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.AddHeader("Cache-Control", "no-cache,private, no-store, must-revalidate,max-stale=0, post-check=0, pre-check=0");
                Response.AddHeader("Pragma", "no-cache");
                Response.AddHeader("Expires", "0");

                if (Request.Cookies["ROFR1.0"] != null)
                {
                    Response.Cookies["ROFR1.0"].Value = string.Empty;
                    Response.Cookies["ROFR1.0"].Expires = DateTime.Now.AddMonths(-20);
                }

                if (Request.Cookies["ROFR1.0"] != null)
                {
                    Response.Cookies["ROFR1.0"].Value = string.Empty;
                    Response.Cookies["ROFR1.0"].Expires = DateTime.Now.AddMonths(-20);
                }
                //Response.Cookies.Add(new HttpCookie("ROFR1.0", ""));
                Session.Abandon();
                Session.Clear();
                Session.RemoveAll();
                logoutReGenerateSessionId();
                //Response.Cookies.Clear();
                Response.Redirect("../Errors/Error404.aspx");
                //Response.Redirect("../pages/Login.aspx");
            }
            catch (Exception ex)
            {
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

            }

        }

        protected void logoutReGenerateSessionId()
        {
            SessionIDManager manager = new SessionIDManager();
            string oldId = manager.GetSessionID(System.Web.HttpContext.Current);
            string newId = manager.CreateSessionID(System.Web.HttpContext.Current);
            bool isAdd = false, isRedir = false;
            manager.RemoveSessionID(System.Web.HttpContext.Current);
            manager.SaveSessionID(System.Web.HttpContext.Current, newId, out isRedir, out isAdd);
            HttpApplication ctx = (HttpApplication)System.Web.HttpContext.Current.ApplicationInstance;
            HttpModuleCollection mods = ctx.Modules;
            System.Web.SessionState.SessionStateModule ssm = (SessionStateModule)mods.Get("Session");
            System.Reflection.FieldInfo[] fields = ssm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            SessionStateStoreProviderBase store = null;
            System.Reflection.FieldInfo rqIdField = null, rqLockIdField = null, rqStateNotFoundField = null;
            SessionStateStoreData rqItem = null;
            foreach (System.Reflection.FieldInfo field in fields)
            {
                if (field.Name.Equals("_store")) store = (SessionStateStoreProviderBase)field.GetValue(ssm);
                if (field.Name.Equals("_rqId")) rqIdField = field;
                if (field.Name.Equals("_rqLockId")) rqLockIdField = field;
                if (field.Name.Equals("_rqSessionStateNotFound")) rqStateNotFoundField = field;
                if ((field.Name.Equals("_rqItem")))
                {
                    rqItem = (SessionStateStoreData)field.GetValue(ssm);
                }
            }
            object lockId = rqLockIdField.GetValue(ssm);
            if ((lockId != null) && (oldId != null))
            {
                store.RemoveItem(System.Web.HttpContext.Current, oldId, lockId, rqItem);
            }
            rqStateNotFoundField.SetValue(ssm, true);
            rqIdField.SetValue(ssm, newId);
        }

        protected void btnmap_Click(object sender, EventArgs e)
        {
            try
            {
               // AntiForgery.Validate();
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
               // AntiForgery.Validate();
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
                            if ((drow["LATITUDE"].ToString().Trim()) != "")
                            {
                                if ((drow["LONGITUDE"].ToString().Trim()) != "")
                                {
                                    dr["Option1"] = Convert.ToInt32((string)(Session["latlongId"]));
                                    dr["Option2"] = drow["LATITUDE"].ToString().Trim();
                                    dr["Option3"] = drow["LONGITUDE"].ToString().Trim();
                                    // dr["Option4"] = drow["IFSCCODE"].ToString().Trim();
                                    // dr["Option5"] = drow["BANKNAME"].ToString().Trim();


                                    dtUpdateDetails.Rows.Add(dr);
                                }
                            }
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
                    if (dtUpdateDetails.Rows.Count >= 4)
                    {
                        MastersDataAnalysisBAL.MastersDataAnalysis.INSERTlatlongsdata(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_Village.SelectedValue, ddl_hab.SelectedItem.Text, ddl_pattadhar.SelectedValue, ddl_extentplotarea.SelectedValue, (string)(Session["latlongId"]), BeneficiaryDetailsobj);
                        // ProjectRofrBAL.GetMasterDetails.importUpdateValidateBeneficiaryDetails(BeneficiaryDetailsobj, (string)(Session["username"]), ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, radioid.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('LatLongs Inserted Successfully !')", true);
                        Bindgrid();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Your Upload Excel Rejected !')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Your Upload Excel Rejected !')", true);
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
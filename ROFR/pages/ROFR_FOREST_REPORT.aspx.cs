using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
using ROFR.helper;
namespace ROFR.pages
{
    public partial class ROFR_FOREST_REPORT : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_FD.Items.Insert(0, new ListItem("Select", "0"));
            ddl_FR.Items.Insert(0, new ListItem("Select", "0"));
            ddl_FB.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    BindDistrict();
                    ddl_FD.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_FR.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_FB.Items.Insert(0, new ListItem("Select", "0"));
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
                DataTable dtDistricts = RevenueDistrictsBAL.RevenueDistricts.GetDistrictMasterAnalysis((string)(Session["username"]), "District", "", "");
                if (dtDistricts.Rows.Count > 0)
                {
                    ddl_district.DataSource = dtDistricts;
                    ddl_district.DataTextField = "DISTRICT_NAME";
                    ddl_district.DataValueField = "DISTRICT_CODE";
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


        private void BindFDivision(DataTable dtFDivisions)
        {
            try
            {
                ddl_FD.DataSource = dtFDivisions;
                ddl_FD.DataTextField = "Forest_Division";
                ddl_FD.DataValueField = "Forest_Division";
                ddl_FD.DataBind();
                ddl_FD.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        private void BindFRange(DataTable dtFRanges)
        {
            try
            {
                ddl_FR.DataSource = dtFRanges;
                ddl_FR.DataTextField = "Forest_Range";
                ddl_FR.DataValueField = "Forest_Range";
                ddl_FR.DataBind();
                ddl_FR.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        private void BindBeat(DataTable dtFBeats)
        {
            try
            {
                ddl_FB.DataSource = dtFBeats;
                ddl_FB.DataTextField = "Forest_Beat";
                ddl_FB.DataValueField = "Forest_Beat";
                ddl_FB.DataBind();
                ddl_FB.Items.Insert(0, new ListItem("Select", "0"));
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
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    ddl_FD.ClearSelection();
                    ddl_FR.ClearSelection();
                    ddl_FB.ClearSelection();
                    DataTable dtFDivisions = RevenueDistrictsBAL.RevenueDistricts.GetForestMasterAnalysis((string)(Session["username"]), "Division", ddl_district.SelectedValue, "", "");
                    if (dtFDivisions.Rows.Count > 0)
                    {
                        BindFDivision(dtFDivisions);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    ddl_FD.ClearSelection();
                    ddl_FR.ClearSelection();
                    ddl_FB.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlFD_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_FD.SelectedItem.Text != "Select")
                {
                    ddl_FR.ClearSelection();
                    ddl_FB.ClearSelection();
                    DataTable dtFRanges = RevenueDistrictsBAL.RevenueDistricts.GetForestMasterAnalysis((string)(Session["username"]), "Range", ddl_district.SelectedValue, ddl_FD.SelectedItem.Text, "");
                    if (dtFRanges.Rows.Count > 0)
                    {
                        BindFRange(dtFRanges);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    ddl_FR.ClearSelection();
                    ddl_FB.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void ddlFR_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_FR.SelectedItem.Text != "Select")
                {
                    ddl_FB.ClearSelection();
                    DataTable dtFBeats = RevenueDistrictsBAL.RevenueDistricts.GetForestMasterAnalysis((string)(Session["username"]), "Beat", ddl_district.SelectedValue, ddl_FD.SelectedItem.Text, ddl_FR.SelectedItem.Text);
                    if (dtFBeats.Rows.Count > 0)
                    {
                        BindBeat(dtFBeats);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    ddl_FB.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {

                Session["district"] = ddl_district.SelectedValue;
                Session["Division"] = ddl_FD.SelectedValue;
                Session["Range"] = ddl_FR.SelectedValue;
                Session["Beat"] = ddl_FB.SelectedValue;
                Session["dist"] = ddl_district.SelectedItem.Text;
                Session["FD"] = ddl_FD.SelectedItem.Text;
                Session["FR"] = ddl_FR.SelectedItem.Text;
                Session["FB"] = ddl_FB.SelectedItem.Text;
                Response.Redirect("Display_Forest_Data.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
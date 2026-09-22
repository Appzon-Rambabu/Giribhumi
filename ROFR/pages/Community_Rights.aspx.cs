using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ROFR.helper;

namespace ROFR.pages
{
    public partial class Community_Rights : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_itda.Items.Insert(0, new ListItem("Select", "0"));

            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_division.Items.Insert(0, new ListItem("Select", "0"));
            ddl_village.Items.Insert(0, new ListItem("Select", "0"));
            ddl_range.Items.Insert(0, new ListItem("Select", "0"));
            ddl_beat.Items.Insert(0, new ListItem("Select", "0"));

            ddl_gp.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    BindItda();
                    ddl_itda.Items.Insert(0, new ListItem("Select", "0"));

                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_division.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_range.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_beat.Items.Insert(0, new ListItem("Select", "0"));
                  
                    ddl_gp.Items.Insert(0, new ListItem("Select", "0"));
                  
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
                DataTable dtItda = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Itda", "", "", "", "", "", "", "", (string)Session["userprevilages"]);
                // DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdaMaster((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_itda.DataSource = dtItda;
                    ddl_itda.DataTextField = "ITDA_NAME";
                    ddl_itda.DataValueField = "ITDA_CODE";
                    ddl_itda.DataBind();
                    ddl_itda.Items.Insert(0, new ListItem("Select", "0"));
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
        private void BindGp(DataTable dtGp)
        {
            try
            {
                ddl_gp.DataSource = dtGp;
                ddl_gp.DataTextField = "Gram_Panchayat";
                ddl_gp.DataValueField = "Grama_Panchayat_Code";
                ddl_gp.DataBind();
                ddl_gp.Items.Insert(0, new ListItem("Select", "0"));

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
                ddl_village.DataSource = dtVillages;
                ddl_village.DataTextField = "VILLAGE_NAME";
                ddl_village.DataValueField = "LGD_VILLAGE_CODE";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

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
                ddl_division.DataSource = dtFDivisions;
                ddl_division.DataTextField = "FOREST_DIVISION_NAME";
                ddl_division.DataValueField = "FOREST_DIVISION_CODE";
                ddl_division.DataBind();
                ddl_division.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_range.DataSource = dtFRanges;
                ddl_range.DataTextField = "FOREST_RANGE_NAME";
                ddl_range.DataValueField = "FOREST_RANGE_CODE";

                ddl_range.DataBind();

                ddl_range.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_beat.DataSource = dtFBeats;
                ddl_beat.DataTextField = "FOREST_BEAT_NAME";
                ddl_beat.DataValueField = "FOREST_BEAT_CODE";
                ddl_beat.DataBind();
                ddl_beat.Items.Insert(0, new ListItem("Select", "0"));
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

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
               

                if (ddl_itda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                   

                    DataTable dtdistrict = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "District", ddl_itda.SelectedValue, "", "", "", "", "", "", (string)Session["userprevilages"]);
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", ddl_itda.SelectedValue, ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);
                            // DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


                            if (dtMandal.Rows.Count > 0)
                            {
                                BindMandal(dtMandal);
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

                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
              
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", ddl_itda.SelectedValue, ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);

                    // DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }

                    DataTable dtFDivisions = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Division", "", ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);
                    // DataTable dtFDivisions = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "FDivision", ddl_district.SelectedValue, " ", " ");


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
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                


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

                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Village", ddl_itda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                    // DataTable dtVillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueVillages", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


                    if (dtVillages.Rows.Count > 0)
                    {
                        BindVillage(dtVillages);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                    DataTable dtGp = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Gp", (string)(Session["itdacode"]), ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                    // DataTable dtFDivisions = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "FDivision", ddl_district.SelectedValue, " ", " ");


                    if (dtGp.Rows.Count > 0)
                    {
                        BindGp(dtGp);
                    }
                }
                else
                {
                    ddl_village.ClearSelection();

               

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


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void ddl_division_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl_range.Items.Clear();

                ddl_range.Items.Insert(0, new ListItem("Select", "0"));

                ddl_beat.Items.Clear();

                ddl_beat.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_division.SelectedItem.Text != "Select")
                {
                    ddl_range.ClearSelection();
                    ddl_beat.ClearSelection();
                    DataTable dtFRanges = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Range", "", ddl_district.SelectedValue, ddl_division.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                    // DataTable dtFRanges = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "FRanges", ddl_district.SelectedValue, ddl_division.SelectedValue, " ");


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
                    ddl_range.ClearSelection();
                    ddl_beat.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void ddl_range_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                ddl_beat.Items.Clear();

                ddl_beat.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_range.SelectedItem.Text != "Select")

                {
                    DataTable dtFBeats = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Beat", "", ddl_district.SelectedValue, ddl_division.SelectedItem.Text, ddl_range.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);
                    // DataTable dtFBeats = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "FBeats", ddl_district.SelectedValue, ddl_division.SelectedValue, ddl_range.SelectedValue);




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
                    ddl_beat.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddl_beat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
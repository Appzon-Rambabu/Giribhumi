using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.NetworkInformation;
using ROFR.helper;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.Helpers;

namespace ROFR.pages
{
    public partial class Update_Farmer_Details : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_village.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    BindItda();
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));
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

                DataTable dtItda = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);
                // DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdaMaster((string)(Session["username"]), "Itda", "", "");
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
                //ddl_mandal.Items.Insert(1, new ListItem("NULL", "1"));
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
                //ddl_village.Items.Insert(1, new ListItem("NULL", "1"));

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

                ddl_district.Items.Clear();

                ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                GridView1.Visible = false;

                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();


                    DataTable dtdistrict = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "District", ddl_ITda.SelectedValue, "", "", "", "", (string)Session["userprevilages"]);
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", (string)Session["userprevilages"]);
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
                GridView1.Visible = false;
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", (string)Session["userprevilages"]);

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
                GridView1.Visible = false;
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Village", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);
                    // DataTable dtVillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueVillages", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


                    if (dtVillages.Rows.Count > 0)
                    {
                        BindVillage(dtVillages);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
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


                if (ddl_village.SelectedItem.Text != "Select")


                {
                    BindGrid();


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
        protected void BindGrid()
        {
            try
            {
                DataTable dt = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "FDetails", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", (string)Session["userprevilages"]);



                if (dt.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["Data"] = dt;
                }
                else
                {
                    GridView1.Visible = false;

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                foreach (GridViewRow item in GridView1.Rows)
                {

                    string filename = string.Empty;
                    string path = string.Empty;
                    string imgBase64String = string.Empty;
                  
                    CheckBox btn = (CheckBox)item.FindControl("CheckBox1");
                    if (btn.Checked == true)
                    {
                        ddl_division.Items.Clear();
                        ddl_gp.Items.Clear();
                        ddl_rv.Items.Clear();
                        ddl_range.Items.Clear();
                        ddl_beat.Items.Clear();
                        ddl_dryid.Items.Clear();
                        ddl_nature.Items.Clear();
                        ddl_kharif.Items.Clear();
                        ddl_month.Items.Clear();
                        
                        Label id = item.FindControl("id") as Label;
                        Label bid = item.FindControl("bid") as Label;
                        Label farmer = item.FindControl("farmer") as Label;
                        Label cultivator = item.FindControl("cultivator") as Label;
                        Label gp = item.FindControl("gp") as Label;
                        Label gpcode = item.FindControl("gpcode") as Label;
                        Label rev_village = item.FindControl("rev_village") as Label;
                        Label rev_village_code = item.FindControl("rev_village_code") as Label;
                        Label hab = item.FindControl("hab") as Label;
                        Label divisioncode = item.FindControl("divisioncode") as Label;
                        Label division = item.FindControl("division") as Label;
                        Label rangecode = item.FindControl("rangecode") as Label;
                        Label range = item.FindControl("range") as Label;
                      
                        Label beatcode = item.FindControl("beatcode") as Label;
                        Label beat = item.FindControl("beat") as Label;
                        Label block = item.FindControl("block") as Label;
                        Label cno = item.FindControl("cno") as Label;
                        Label plotno = item.FindControl("plotno") as Label;
                        Label pattano = item.FindControl("pattano") as Label;
                        Label extent = item.FindControl("extent") as Label;
                        Label cult_land = item.FindControl("cult_land") as Label;
                        Label uncult_land = item.FindControl("uncult_land") as Label;
                        Label patta_inam = item.FindControl("patta_inam") as Label;
                        Label h_nature = item.FindControl("h_nature") as Label;
                        Label land_class = item.FindControl("land_class") as Label;
                        Label water_tax = item.FindControl("water_tax") as Label;
                        Label dry_id = item.FindControl("dry_id") as Label;
                        Label water_source = item.FindControl("water_source") as Label;
                        Label extent_irrigated = item.FindControl("extent_irrigated") as Label;
                        Label extent_u_cult = item.FindControl("extent_u_cult") as Label;
                        Label type_code = item.FindControl("type_code") as Label;
                        Label extents = item.FindControl("extents") as Label;
                        Label net_sown_area = item.FindControl("net_sown_area") as Label;
                        Label khariff = item.FindControl("khariff") as Label;
                        Label month = item.FindControl("month") as Label;
                        Label crop = item.FindControl("crop") as Label;
                        Label single = item.FindControl("single") as Label;
                        Label mixed = item.FindControl("mixed") as Label;
                        Label total = item.FindControl("total") as Label;
                        Label water_source1 = item.FindControl("water_source1") as Label;
                        Label first_crop = item.FindControl("first_crop") as Label;
                        Label second_crop = item.FindControl("second_crop") as Label;
                        Label crop_yield = item.FindControl("crop_yield") as Label;
                        Label vro = item.FindControl("vro") as Label;
                        Label tahsildar = item.FindControl("tahsildar") as Label;
                        Label remarks = item.FindControl("remarks") as Label;
                      


                        BindDivision();
                        BindGP();
                        BindRevenueVillage();
                        BindDryid();
                        BindHnature();
                        BindKharif();
                        BindMonth();
                        ddl_division.Items.Insert(0, new ListItem(division.Text, divisioncode.Text));
                        ddl_gp.Items.Insert(0, new ListItem(gp.Text, gpcode.Text));
                        ddl_rv.Items.Insert(0, new ListItem(rev_village.Text, rev_village_code.Text));
                        if (ddl_division.SelectedItem.Text!="Select" || ddl_division.SelectedItem.Text != ""|| ddl_division.SelectedItem.Text != null)
                        {
                            BindRange();
                        }
                            ddl_range.Items.Insert(0, new ListItem(range.Text, rangecode.Text));
                        if (ddl_range.SelectedItem.Text != "Select" || ddl_range.SelectedItem.Text != "" || ddl_range.SelectedItem.Text != null)
                        {
                            BindBeat();
                        }
                        ddl_beat.Items.Insert(0, new ListItem(beat.Text, beatcode.Text));
                       
                        txt_id.Text = id.Text;
                        txt_bid.Text = bid.Text;
                        txt_farmer.Text = farmer.Text;
                        txt_cultivator.Text = cultivator.Text;
                        //txt_gp.Text = gp.Text;
                      //  txt_rev_village.Text = rev_village.Text;
                        txt_hab.Text = hab.Text;
                        txt_division.Text = division.Text;
                        txt_divisioncode.Text = divisioncode.Text;
                        txt_range.Text = range.Text;
                        txt_rangecode.Text = rangecode.Text;
                        txt_beat.Text = beat.Text;
                        txt_beatcode.Text = beatcode.Text;
                        txt_block.Text = block.Text;

                        txt_cno.Text = cno.Text;
                        txt_plotno.Text = plotno.Text;
                        txt_patta.Text = pattano.Text;
                        txt_extent.Text = extent.Text;
                        txt_cultivable.Text = cult_land.Text;
                        txt_uncultivable.Text = uncult_land.Text;
                        ddl_nature.Items.Insert(0, new ListItem(h_nature.Text, h_nature.Text));
                        txt_nature.Text = h_nature.Text;
                        txt_w_tax.Text = water_tax.Text;
                        ddl_dryid.Items.Insert(0, new ListItem(dry_id.Text, dry_id.Text));
                        txt_dryid.Text = dry_id.Text;
                        txt_w_source.Text = water_source.Text;
                        txt_eirrigated.Text = extent_irrigated.Text;
                       txt_extent_cult.Text = extent_u_cult.Text;
                        txt_tcode.Text = type_code.Text;
                       txt_extnt.Text = extents.Text;
                        txt_net.Text = net_sown_area.Text;
                        ddl_kharif.Items.Insert(0, new ListItem(khariff.Text, khariff.Text));
                        txt_kharif.Text = khariff.Text;
                        ddl_month.Items.Insert(0, new ListItem(month.Text, month.Text));
                        txt_month.Text = month.Text;
                        txt_crop.Text = crop.Text;
                        txt_single.Text = single.Text;
                        txt_mixed.Text = mixed.Text;
                        txt_tcrop.Text = total.Text;
                        txt_w_source1.Text = water_source1.Text;
                        txt_first.Text = first_crop.Text;
                        txt_second.Text = second_crop.Text;
                        txt_cyield.Text = crop_yield.Text;
                        txt_vro.Text = vro.Text;
                        txt_tahsildar.Text = tahsildar.Text;
                        txt_remarks.Text = remarks.Text;
                       
                   

                        string script = "window.onload = function() { openModal(); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "openModal", script, true);

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btn_click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                string script = "window.onload = function() { openModal(); };";
                ClientScript.RegisterStartupScript(this.GetType(), "openModal", script, true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void mbtn_click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();


                addbeneficiaryobj.id = txt_id.Text;
                if (ddl_division.SelectedItem.Text != "Select" && ddl_division.SelectedItem.Text !=null && ddl_division.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.Forest_Division = ddl_division.SelectedItem.Text;
                    addbeneficiaryobj.Forest_DivisionCode = ddl_division.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Forest_Division = null;
                    addbeneficiaryobj.Forest_DivisionCode = null;
                }
                if (ddl_range.SelectedItem.Text != "Select" && ddl_range.SelectedItem.Text != null && ddl_range.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.Forest_Range = ddl_range.SelectedItem.Text;
                    addbeneficiaryobj.Forest_RangeCode = ddl_range.SelectedValue;
                    
                }
                else
                {
                    addbeneficiaryobj.Forest_Range = null;
                    addbeneficiaryobj.Forest_RangeCode = null;
                }
                if (ddl_beat.SelectedItem.Text != "Select" && ddl_beat.SelectedItem.Text != null && ddl_beat.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.Forest_Beat = ddl_beat.SelectedItem.Text;
                    addbeneficiaryobj.Forest_BeatCode = ddl_beat.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Forest_Beat = null;
                    addbeneficiaryobj.Forest_BeatCode = null;
                }
                if (ddl_gp.SelectedItem.Text != "Select" && ddl_gp.SelectedItem.Text != null && ddl_gp.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.Gram_Panchayat = ddl_gp.SelectedItem.Text;
                    addbeneficiaryobj.Grama_Panchayat_Code = ddl_gp.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Gram_Panchayat = null;
                    addbeneficiaryobj.Grama_Panchayat_Code = null;
                }
                if (ddl_rv.SelectedItem.Text != "Select" && ddl_rv.SelectedItem.Text != null && ddl_rv.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.rev_village = ddl_rv.SelectedItem.Text;
                    addbeneficiaryobj.rev_village_code = ddl_rv.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.rev_village = null;
                    addbeneficiaryobj.rev_village_code = null;
                }
               
                if (txt_block.Text!="" && txt_block.Text!=null)
                { 
                addbeneficiaryobj.Forest_Block = txt_block.Text ;
                }
                else
                {
                    addbeneficiaryobj.Forest_Block = null;
                }
                if (txt_cno.Text != "" && txt_cno.Text != null)
                {
                    addbeneficiaryobj.Compartment_No = txt_cno.Text;
                }
                else
                {
                    addbeneficiaryobj.Compartment_No = null;
                }
                if (txt_plotno.Text != "" && txt_plotno.Text != null)
                {
                    addbeneficiaryobj.Plot_No = txt_plotno.Text;
                    
                }
                else
                {
                    addbeneficiaryobj.Plot_No = null;
                }
                if (txt_patta.Text != "" && txt_patta.Text != null)
                {
                    addbeneficiaryobj.ROFR_PATTANO = txt_patta.Text;
                }
                else
                {
                    addbeneficiaryobj.ROFR_PATTANO = null;
                }
                if (txt_extent.Text != "" && txt_extent.Text != null)
                {
                    addbeneficiaryobj.ExtentPlotArea = txt_extent.Text;
                }
                else
                {
                    addbeneficiaryobj.ExtentPlotArea =null;
                }
                if (txt_cultivable.Text != "" && txt_cultivable.Text != null)
                {
                    addbeneficiaryobj.Cultivable_Land = txt_cultivable.Text;
                }
                else
                {
                    addbeneficiaryobj.Cultivable_Land = null;
                }
                if (txt_uncultivable.Text != "" && txt_uncultivable.Text != null)
                {
                    addbeneficiaryobj.Uncultivable_Land = txt_uncultivable.Text;
                }
                else
                {
                    addbeneficiaryobj.Uncultivable_Land = null;
                }
                if (ddl_nature.SelectedItem.Text != "Select" && ddl_nature.SelectedItem.Text != null && ddl_nature.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.HOLDING_NATURE = ddl_nature.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.HOLDING_NATURE = null;
                }
                if (txt_w_tax.Text != "" && txt_w_tax.Text != null)
                {
                    addbeneficiaryobj.Water_Tax = txt_w_tax.Text;
                }
                else
                {
                    addbeneficiaryobj.Water_Tax = null;
                }
                if (ddl_dryid.SelectedItem.Text != "Select" && ddl_dryid.SelectedItem.Text != null && ddl_dryid.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.DRYID_ONECROP_TWO_CROP = ddl_dryid.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.DRYID_ONECROP_TWO_CROP = null;
                }
                if (txt_w_source.Text != "" && txt_w_source.Text != null)
                {
                    addbeneficiaryobj.WATER_SOURCE = txt_w_source.Text;
                }
                else
                {
                    addbeneficiaryobj.WATER_SOURCE = null;
                }
                if (txt_eirrigated.Text != "" && txt_eirrigated.Text != null)
                {
                    addbeneficiaryobj.EXTENT_IRRIGATED = txt_eirrigated.Text;
                }
                else
                {
                    addbeneficiaryobj.EXTENT_IRRIGATED = null;
                }
                if (txt_extent_cult.Text != "" && txt_extent_cult.Text != null)
                {
                    addbeneficiaryobj.EXTENT_UNDER_CULTIVATOR = txt_extent_cult.Text;
                }
                else
                {
                    addbeneficiaryobj.EXTENT_UNDER_CULTIVATOR = null;
                }
                if (txt_tcode.Text != "" && txt_tcode.Text != null)
                {
                    addbeneficiaryobj.TYPE_CODE = txt_tcode.Text;
                }
                else
                {
                    addbeneficiaryobj.TYPE_CODE = null;
                }
                if (txt_extnt.Text != "" && txt_extnt.Text != null)
                {
                    addbeneficiaryobj.EXTENT = txt_extnt.Text;
                }
                else
                {
                    addbeneficiaryobj.EXTENT = null;
                }
                if (txt_net.Text != "" && txt_net.Text != null)
                {
                    addbeneficiaryobj.NET_SOWN_AREA = txt_net.Text;
                }
                else
                {
                    addbeneficiaryobj.NET_SOWN_AREA = null;
                }
                if (ddl_kharif.SelectedItem.Text != "Select" && ddl_kharif.SelectedItem.Text != null && ddl_kharif.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.KHARIFF_RABI = ddl_kharif.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.KHARIFF_RABI = null;
                }
                if (ddl_month.SelectedItem.Text != "Select" && ddl_month.SelectedItem.Text != null && ddl_month.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.MONTH_OF_CULTIVATION = ddl_month.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.MONTH_OF_CULTIVATION = null;
                }
                if (txt_crop.Text != "" && txt_crop.Text != null)
                {
                    addbeneficiaryobj.CROP = txt_crop.Text;
                }
                else
                {
                    addbeneficiaryobj.CROP = null;
                }
                if (txt_single.Text != "" && txt_single.Text != null)
                {
                    addbeneficiaryobj.SINGLE = txt_single.Text;
                }
                else
                {
                    addbeneficiaryobj.SINGLE = null;
                }
                if (txt_mixed.Text != "" && txt_mixed.Text != null)
                {
                    addbeneficiaryobj.MIXED = txt_mixed.Text;
                }
                else
                {
                    addbeneficiaryobj.MIXED = null;
                }
                if (txt_tcrop.Text != "" && txt_tcrop.Text != null)
                {
                    addbeneficiaryobj.TOTAL = txt_tcrop.Text;
                }
                else
                {
                    addbeneficiaryobj.TOTAL = null;
                }
                if (txt_w_source1.Text != "" && txt_w_source1.Text != null)
                {
                    addbeneficiaryobj.WATER_SOURCE1 = txt_w_source1.Text;
                }
                else
                {
                    addbeneficiaryobj.WATER_SOURCE1 = null;
                }
                if (txt_first.Text != "" && txt_first.Text != null)
                {
                    addbeneficiaryobj.FIRST_CROP = txt_first.Text;
                }
                else
                {
                    addbeneficiaryobj.FIRST_CROP = null;
                }
                if (txt_second.Text != "" && txt_second.Text != null)
                {
                    addbeneficiaryobj.SECOND_THIRD_CROP = txt_second.Text;
                }
                else
                {

                    addbeneficiaryobj.SECOND_THIRD_CROP = null;
                }
                if (txt_cyield.Text != "" && txt_cyield.Text != null)
                {
                    addbeneficiaryobj.CROP_YIELD = txt_cyield.Text;
                }
                else
                {
                    addbeneficiaryobj.CROP_YIELD =null;
                }
                if (txt_vro.Text != "" && txt_vro.Text != null)
                {
                    addbeneficiaryobj.VRO_RI_REMARKS = txt_vro.Text;
                }
                else
                {
                    addbeneficiaryobj.VRO_RI_REMARKS = null;
                }
                if (txt_tahsildar.Text != "" && txt_tahsildar.Text != null)
                {
                    addbeneficiaryobj.TAHSILDAR_REMARKS = txt_tahsildar.Text;
                    
                }
                else
                {
                    addbeneficiaryobj.TAHSILDAR_REMARKS = null;
                }
                if (txt_remarks.Text != "" && txt_remarks.Text != null)
                {
                    addbeneficiaryobj.REMARKS = txt_remarks.Text;
                }
                else
                {
                    addbeneficiaryobj.REMARKS = null;
                }

                addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                addbeneficiaryobj.UserName = (string)(Session["username"]);


                if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                {

                    if (!string.IsNullOrEmpty(txt_bid.Text))
                    {
                        DataTable dt=Landsettlementpattas.UpdateFarmerLandDetails(addbeneficiaryobj, (string)(Session["username"]));
                       
                        if (dt.Rows.Count > 0 && dt != null)
                        {
                            if(dt.Rows[0]["STATUS"].ToString() == "103")
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Insertion Failed...Total Extent for Beneficiary should not be greater than 10 Acres')", true);
                                BindGrid();
                            }
                            else 
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Farmer Details Updated Successfully')", true);

                                BindGrid();
                            }
                        }

                       

                    }
                    else
                    {
                        foreach (GridViewRow item in GridView1.Rows)
                        {
                            CheckBox btn = (CheckBox)item.FindControl("CheckBox1");

                            //LinkButton btn = (LinkButton)(sender);

                            if (btn.Checked == true)
                            {
                                btn.Checked = false;
                            }
                        }

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

        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        protected void Close_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow item in GridView1.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox1");
                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }
        private void BindDivision()
        {
            try
            {
               
                DataTable division = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Division", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", (string)Session["userprevilages"]);
               
                if (division.Rows.Count > 0)
                {
                   ddl_division.DataSource = division;
                    ddl_division.DataTextField = "Forest_Division";
                    ddl_division.DataValueField = "Forest_DivisionCode";
                    ddl_division.DataBind();
                    ddl_division.Items.Insert(0, new ListItem("Select", "0"));
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
        private void BindGP()
        {
            try
            {

                DataTable gp = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Gp", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);

                if (gp.Rows.Count > 0)
                {
                    ddl_gp.DataSource = gp;
                    ddl_gp.DataTextField = "Gram_Panchayat";
                    ddl_gp.DataValueField = "Grama_Panchayat_Code";
                    ddl_gp.DataBind();
                    ddl_gp.Items.Insert(0, new ListItem("Select", "0"));
                }
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindRevenueVillage()
        {
            try
            {

                DataTable rv = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "RV", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);

                if (rv.Rows.Count > 0)
                {
                    ddl_rv.DataSource = rv;
                    ddl_rv.DataTextField = "REV_Village";
                    ddl_rv.DataValueField = "REV_VILLAGE_CODE";
                    ddl_rv.DataBind();
                    ddl_rv.Items.Insert(0, new ListItem("Select", "0"));
                }
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindRange()
        {
            try
            {
                DataTable dtrange = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Range", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_division.SelectedItem.Text, "", "", (string)Session["userprevilages"]);

                if (dtrange.Rows.Count > 0)
                {
                    ddl_range.DataSource = dtrange;
                    ddl_range.DataTextField = "Forest_Range";
                    ddl_range.DataValueField = "Forest_RangeCode";
                    ddl_range.DataBind();
                    ddl_range.Items.Insert(0, new ListItem("Select", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindBeat()
        {
            try
            {
                DataTable dtbeat = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Beat", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_division.SelectedItem.Text, ddl_range.SelectedItem.Text, "", (string)Session["userprevilages"]);

                if (dtbeat.Rows.Count > 0)
                {
                    ddl_beat.DataSource = dtbeat;
                    ddl_beat.DataTextField = "Forest_Beat";
                    ddl_beat.DataValueField = "Forest_BeatCode";
                    ddl_beat.DataBind();
                    ddl_beat.Items.Insert(0, new ListItem("Select", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void ddldivision_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             
                ddl_range.Items.Clear();

                ddl_range.Items.Insert(0, new ListItem("Select", "0"));
                ddl_beat.Items.Clear();

                ddl_beat.Items.Insert(0, new ListItem("Select", "0"));
               
                if (ddl_division.SelectedItem.Text != "Select" || ddl_division.SelectedItem.Text != "" || ddl_division.SelectedItem.Text != null)
                {
                    //DataTable range = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Range", ddl_ITda.SelectedValue, ddl_district.SelectedValue,  ddl_division.SelectedItem.Text, "","", (string)Session["userprevilages"]);

                   


                    //if (range.Rows.Count > 0)
                    //{
                        BindRange();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    //}


                }
                else
                {
                   ddl_beat.ClearSelection();
                   ddl_range.ClearSelection();



                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void ddlrange_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

           
                ddl_beat.Items.Clear();

                ddl_beat.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_range.SelectedItem.Text != "Select" || ddl_range.SelectedItem.Text != "" || ddl_range.SelectedItem.Text != null)
                {
                    //DataTable beat = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Beat", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_division.SelectedItem.Text, ddl_range.SelectedItem.Text, "", (string)Session["userprevilages"]);




                    //if (beat.Rows.Count > 0)
                    //{
                        BindBeat();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    //}


                }
                else
                {
                  
                    ddl_range.ClearSelection();



                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void ddlbeat_OnSelectedIndexChanged(object sender, EventArgs e)
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

        private void BindDryid()
        {
            try
            {
                DataTable dtdry = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Dryid", "", "", "", "", "", (string)Session["userprevilages"]);
               

                if (dtdry.Rows.Count > 0)
                {
                    
                        ddl_dryid.DataSource = dtdry;

                    ddl_dryid.DataTextField = "Land_type";
                    ddl_dryid.DataValueField = "Land_type_id";
                    ddl_dryid.DataBind();


                    ddl_dryid.Items.Insert(0, new ListItem("Select", "0"));
                   
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

        private void BindKharif()
        {
            try
            {

                DataTable dtkharif = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Kharif", "", "", "", "", "", (string)Session["userprevilages"]);


                if (dtkharif.Rows.Count > 0)
                {
               
                        ddl_kharif.DataSource = dtkharif;

                        ddl_kharif.DataTextField = "crop_type";
                        ddl_kharif.DataValueField = "crop_type_id";
                        ddl_kharif.DataBind();


                        ddl_kharif.Items.Insert(0, new ListItem("Select", "0"));
                    
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
        private void BindMonth()
        {
            try
            {


                DataTable dtmonth = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Month", "", "", "", "", "", (string)Session["userprevilages"]);



                if (dtmonth.Rows.Count > 0)
                {
                    
                        ddl_month.DataSource = dtmonth;

                        ddl_month.DataTextField = "month_eng";
                        ddl_month.DataValueField = "sno";
                        ddl_month.DataBind();


                        ddl_month.Items.Insert(0, new ListItem("Select", "0"));
                   
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
        private void BindHnature()
        {
            try
            {


                DataTable dtnature = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Nature", "", "", "", "", "", (string)Session["userprevilages"]);



                if (dtnature.Rows.Count > 0)
                {

                    ddl_nature.DataSource = dtnature;

                    ddl_nature.DataTextField = "HOLDING_NATURE";
                    ddl_nature.DataValueField = "HOLDING_NATURE";
                    ddl_nature.DataBind();


                    ddl_nature.Items.Insert(0, new ListItem("Select", "0"));

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
    }
}
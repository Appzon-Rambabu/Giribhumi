using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ROFR.helper;

namespace ROFR.test
{
    public partial class Beneficiary_Transaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                   // BindDistrict();

                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_division.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_range.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_beat.Items.Insert(0, new ListItem("Select", "0"));
                    //ddl_land_class.Items.Insert(0, new ListItem("Select", "0"));
                   // ddl_patta_inam.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_dry_id.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_kharif.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_month.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_gp.Items.Insert(0, new ListItem("Select", "0"));
                    file_dlc.Attributes.Add("onchange", "return file(this,'" + file_dlc.ClientID + "');");
                    div_getdetails.Visible = false;
                    div_click.Visible = false;
                    div_field.Visible = false;
                    div_forest.Visible = false;
                    div_beneficiary.Visible = false;
                }
            
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = RevenueDistrictsBAL.RevenueDistricts.Getbeneficiarytransaction((string)(Session["username"]), "getdetails", ((string)Session["userprevilages"]), "", "", txt_adhar.Text.Trim());

                if (dt.Rows.Count > 0)
                {
                    Session["itdacode"]= dt.Rows[0]["Itda_Code"].ToString();
                    Lbl_itda.Text = dt.Rows[0]["ITDA_NAME"].ToString();
                    lbl_dist.Text = dt.Rows[0]["District"].ToString();
                    lbl_mandal.Text = dt.Rows[0]["Mandal"].ToString();
                    lbl_village.Text = dt.Rows[0]["Village"].ToString();
                    lbl_habitation.Text = dt.Rows[0]["Habitation"].ToString();
                    lbl_pattadhar.Text = dt.Rows[0]["ROFR_PATTADAAR"].ToString();

                    lbl_adhaar.Text = dt.Rows[0]["Aadhaar_NO"].ToString();
                    Session["bankname"]= dt.Rows[0]["BankName"].ToString();
                    Session["bankacno"] = dt.Rows[0]["BankAccountNo"].ToString();
                    Session["ifsc"] = dt.Rows[0]["IfscCode"].ToString();
                    Session["subcaste"] = dt.Rows[0]["Sub_Caste"].ToString();
                    Session["habcode"] = dt.Rows[0]["HabitationCode"].ToString();
                    //lbl_bankname.Text = dt.Rows[0]["BankName"].ToString();
                    // lbl_bank_account.Text = dt.Rows[0]["BankAccountNo"].ToString();
                    //lbl_ifsc.Text = dt.Rows[0]["IfscCode"].ToString();
                    lbl_father.Text = dt.Rows[0]["Father_Name"].ToString();
                    //lbl_poname.Text = dt.Rows[0]["Postoffice_name"].ToString();
                    //lbl_po_account.Text = dt.Rows[0]["Postoffice_account"].ToString();
                    //lbl_po_number.Text = dt.Rows[0]["Postoffice_number"].ToString();
                    div_getdetails.Visible = true;
                    div_click.Visible = true;
                    div_field.Visible = false;
                    div_forest.Visible = false;
                    div_beneficiary.Visible = false;
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
        private void land_classification()
        {
            try
            {

                DataTable dtlandclass = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Landclass", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                if (dtlandclass.Rows.Count > 0)
                {
                    if (ddl_village.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select")

                    {
                        ddl_land_class.DataSource = dtlandclass;

                        ddl_land_class.DataTextField = "Land_Classification_Name";
                        ddl_land_class.DataValueField = "Land_Classification_Code";
                        ddl_land_class.DataBind();


                        ddl_land_class.Items.Insert(0, new ListItem("Select", "0"));
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


        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_district.SelectedItem.Text != "Select")
                {
                     DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", (string)(Session["itdacode"]), ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);

                  //  DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, Lbl_itda.Text, " ");


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

        protected void ddl_mandal_SelectedIndexChanged(object sender, EventArgs e)
        {

            try

            {

                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Village", (string)(Session["itdacode"]), ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_gp.SelectedItem.Text," ", "", "", (string)Session["userprevilages"]);
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
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    //}
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

        protected void ddl_village_SelectedIndexChanged(object sender, EventArgs e)
        {

            land_classification();
            bind_patta_inam();
            bind_dry_id();
            bind_khariff();
            bind_month_cultivation();
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


        private void bind_patta_inam()
        {
            try
            {
                DataTable dtpatta = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Patta", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);

                if (dtpatta.Rows.Count > 0)
                {
                    if (ddl_village.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select")

                    {
                        ddl_patta_inam.DataSource = dtpatta;

                        ddl_patta_inam.DataTextField = "rofr_patta_name";
                        ddl_patta_inam.DataValueField = "rofr_patta_id";
                        ddl_patta_inam.DataBind();


                        ddl_patta_inam.Items.Insert(0, new ListItem("Select", "0"));
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

        private void bind_dry_id()
        {
            try
            {

                DataTable dtdry = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Dry", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);

                if (dtdry.Rows.Count > 0)
                {
                    if (ddl_village.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select")

                    {
                        ddl_dry_id.DataSource = dtdry;

                        ddl_dry_id.DataTextField = "Land_type";
                        ddl_dry_id.DataValueField = "Land_type_id";
                        ddl_dry_id.DataBind();


                        ddl_dry_id.Items.Insert(0, new ListItem("Select", "0"));
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

        private void bind_khariff()
        {
            try
            {

                DataTable dtcropseason = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Season", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);


                if (dtcropseason.Rows.Count > 0)
                {
                    if (ddl_village.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select")

                    {
                        ddl_kharif.DataSource = dtcropseason;

                        ddl_kharif.DataTextField = "crop_type";
                        ddl_kharif.DataValueField = "crop_type_id";
                        ddl_kharif.DataBind();


                        ddl_kharif.Items.Insert(0, new ListItem("Select", "0"));
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
        private void bind_month_cultivation()
        {
            try
            {


                DataTable dtcropmnth = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Month", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);



                if (dtcropmnth.Rows.Count > 0)
                {
                    if (ddl_village.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select")

                    {
                        ddl_month.DataSource = dtcropmnth;

                        ddl_month.DataTextField = "month_eng";
                        ddl_month.DataValueField = "sno";
                        ddl_month.DataBind();


                        ddl_month.Items.Insert(0, new ListItem("Select", "0"));
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


        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string IPAddress = (string)(Session["IPAddress"]);
                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();



                HttpPostedFile dlc = file_dlc.PostedFile;
                string dlcpath = file_dlc.PostedFile.FileName;
                string dlcname = Path.GetFileName(dlcpath);
                string ext = Path.GetExtension(dlcname);
                string jpgext = Path.GetExtension(dlcname);
                string type = string.Empty;
                string type1 = string.Empty;
                string Compartmentno2 = string.Empty;
                string compartmentno = lbl_pattadhar.Text;
                string location = string.Empty;
                Compartmentno2 = lbl_pattadhar.Text;
                compartmentno = compartmentno.Replace(" ", string.Empty);
                compartmentno = compartmentno + "New";
                string dlcfolder = Lbl_itda.Text.Replace(" ", string.Empty) + ddl_district.SelectedValue;

                string aadhar = lbl_adhaar.Text;
                //if (!string.IsNullOrEmpty(Compartmentno2)&& !string.IsNullOrEmpty(aadhar))
                //{
                if (dlc != null && dlc.ContentLength > 0)
                {
                    //if (!string.IsNullOrEmpty(Compartmentno2))
                    //{
                    try
                    {
                         location = HttpContext.Current.Server.MapPath("~/DLC/" + dlcfolder + "/");

                        if (!Directory.Exists(location))
                        {
                            Directory.CreateDirectory(location);

                        }
                        //  string dlcpath1 = Server.MapPath("~/DLC/") + compartmentno + "/" + DateTime.Now.ToString("dd-MM-yyy") + "/" + Path.GetFileName(dlc.FileName);
                        string dlcpath1 = location + Path.GetFileName(dlc.FileName);
                        dlc.SaveAs(dlcpath1);

                        if (file_dlc.PostedFile != null)
                        {
                            txt_dlc.Text = file_dlc.PostedFile.FileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Dlc File Location Created Error !')('" + compartmentno + "')", true);
                        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                    }
                    if (file_dlc.HasFile)
                    {

                        switch (ext)
                        {
                            case ".pdf":
                                type = "pdf";

                                break;
                        }
                        switch (jpgext)
                        {
                            case ".jpg":
                                type1 = "jpg";
                                break;
                        }
                        if (type != string.Empty)
                        {
                            Stream filestream = file_dlc.PostedFile.InputStream;
                            BinaryReader br = new BinaryReader(filestream);
                            // bytes = br.ReadBytes((Int32)filestream.Length);
                        }
                        if (type1 != string.Empty)
                        {
                            int length1 = file_dlc.PostedFile.ContentLength;
                            byte[] imgbyte1 = new byte[] { };
                            imgbyte1 = new byte[length1];

                            HttpPostedFile image1 = file_dlc.PostedFile;

                            // image1.InputStream.Read(imgbyte1, 0, length);
                            //string imagename = file_dlc.PostedFile.FileName;
                            // bytes = imgbyte1;
                        }
                        // }
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please entert compartment no')", true);
                        //}
                    }
                }
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please entert Pattadaar Name ')", true);
                //}
                // if (file_dlc.HasFile)
                //{
                if (!string.IsNullOrEmpty(Lbl_itda.Text))
                {
                    addbeneficiaryobj.Itda = Lbl_itda.Text;
                }
                else
                {
                    addbeneficiaryobj.Itda = null;
                }
                if (!string.IsNullOrEmpty((string)Session["itdacode"]))
                {
                    addbeneficiaryobj.Itdacode = (string)Session["itdacode"];
                }
                else
                {
                    addbeneficiaryobj.Itdacode = null;
                }
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.District = ddl_district.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.District = null;
                }
                if (!string.IsNullOrEmpty(ddl_district.SelectedValue)|| ddl_district.SelectedValue!="0")
                {
                    addbeneficiaryobj.District_Code = ddl_district.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.District_Code = null;
                }
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.Mandal = ddl_mandal.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.Mandal = null;
                }
                if (!string.IsNullOrEmpty(ddl_mandal.SelectedValue)||( ddl_mandal.SelectedValue!="0"))
                {
                    addbeneficiaryobj.Mandal_Code = ddl_mandal.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Mandal_Code = null;
                }
                if (ddl_division.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.Forest_Division = ddl_division.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.Forest_Division = null;
                }
                if (!string.IsNullOrEmpty(ddl_division.SelectedValue)|| (ddl_division.SelectedValue!="0"))
                {
                    addbeneficiaryobj.Forest_DivisionCode = ddl_division.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Forest_DivisionCode = null;
                }
                if (ddl_range.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.Forest_Range = ddl_range.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.Forest_Range = null;
                }
                if (!string.IsNullOrEmpty(ddl_range.SelectedValue)|| (ddl_range.SelectedValue!="0"))
                {
                    addbeneficiaryobj.Forest_RangeCode = ddl_range.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Forest_RangeCode = null;
                }
                if (ddl_beat.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.Forest_Beat = ddl_beat.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.Forest_Beat = null;
                }
                if (!string.IsNullOrEmpty(ddl_beat.SelectedValue)|| (ddl_beat.SelectedValue!="0"))
                {
                    addbeneficiaryobj.Forest_BeatCode = ddl_beat.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Forest_BeatCode = null;
                }
                if (ddl_gp.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.Gram_Panchayat = ddl_gp.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.Gram_Panchayat = null;
                }
                if (!string.IsNullOrEmpty(ddl_gp.SelectedValue)|| (ddl_gp.SelectedValue!="0"))
                {
                    addbeneficiaryobj.Grama_Panchayat_Code = ddl_gp.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Grama_Panchayat_Code = null;
                }
                if (ddl_village.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.Village = ddl_village.SelectedItem.Text;
                }
                else

                {
                    addbeneficiaryobj.Village = null;
                }
                if (!string.IsNullOrEmpty(ddl_village.SelectedValue)|| (ddl_village.SelectedValue!="0"))
                {
                    addbeneficiaryobj.Village_Code = ddl_village.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.Village_Code = null;
                }

                //addbeneficiaryobj.Village = txt_village.Text;
                //addbeneficiaryobj.Village_Code = txt_villagecode.Text;
                if (!string.IsNullOrEmpty((string)Session["habcode"])|| ((string)Session["habcode"])!="0")
                {
                    addbeneficiaryobj.HabitationCode = (string)Session["habcode"];
                }
                else
                {
                    addbeneficiaryobj.HabitationCode = null;
                }
                if (!string.IsNullOrEmpty(lbl_habitation.Text))
                {
                    addbeneficiaryobj.Habitation = lbl_habitation.Text;
                }
                else
                {
                    addbeneficiaryobj.Habitation = null;
                }
                if (!string.IsNullOrEmpty(txt_fblock.Text))
                {
                    addbeneficiaryobj.Forest_Block = txt_fblock.Text;
                }
                else
                {
                    addbeneficiaryobj.Forest_Block = null;
                }
                if (!string.IsNullOrEmpty(txt_compartment.Text))
                {
                    addbeneficiaryobj.Compartment_No = txt_compartment.Text;
                }
                else
                {
                    addbeneficiaryobj.Compartment_No = null;
                }
                if (!string.IsNullOrEmpty(txt_plot.Text))
                {
                    addbeneficiaryobj.Plot_No = txt_plot.Text;
                }
                else
                {
                    addbeneficiaryobj.Plot_No = null;
                }
                if (!string.IsNullOrEmpty(txt_plotarea.Text))
                {
                    addbeneficiaryobj.ExtentPlotArea = txt_plotarea.Text;
                }
                else
                {
                    addbeneficiaryobj.ExtentPlotArea = null;
                }
                if (!string.IsNullOrEmpty(txt_uc_land.Text))
                {
                    addbeneficiaryobj.Uncultivable_Land = txt_uc_land.Text;
                }
                else
                {
                    addbeneficiaryobj.Uncultivable_Land = null;
                }
                if (!string.IsNullOrEmpty(txt_c_land.Text))
                {
                    addbeneficiaryobj.Cultivable_Land = txt_c_land.Text;
                }
                else
                {
                    addbeneficiaryobj.Cultivable_Land = null;
                }
                //  addbeneficiaryobj.PATTA_INAMGOVT = txt_patta_inam.Text;
                if (!string.IsNullOrEmpty(txt_patta_inam.Text))
                {
                    addbeneficiaryobj.PATTA_INAMGOVT = txt_patta_inam.Text;
                }
                else
                {
                    addbeneficiaryobj.PATTA_INAMGOVT = null;
                }
                if (!string.IsNullOrEmpty(txt_wtax.Text))
                {
                    addbeneficiaryobj.Water_Tax = txt_wtax.Text;
                }
                else
                {
                    addbeneficiaryobj.Water_Tax = null;
                }
                //addbeneficiaryobj.DRYID_ONECROP_TWO_CROP = txt_dry_id.Text;
                if (ddl_dry_id.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.DRYID_ONECROP_TWO_CROP = ddl_dry_id.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.DRYID_ONECROP_TWO_CROP = null;
                }
                if (!string.IsNullOrEmpty(txt_wsource.Text))
                {
                    addbeneficiaryobj.WATER_SOURCE = txt_wsource.Text;
                }
                else
                {
                    addbeneficiaryobj.WATER_SOURCE = null;
                }
                if (!string.IsNullOrEmpty(txt_Eirrigated.Text))
                {
                    addbeneficiaryobj.EXTENT_IRRIGATED = txt_Eirrigated.Text;
                }
                else
                {
                    addbeneficiaryobj.EXTENT_IRRIGATED = null;
                }
                if (!string.IsNullOrEmpty(txt_patta_no.Text))
                {
                    addbeneficiaryobj.ROFR_PATTANO = txt_patta_no.Text;
                }
                else
                {
                    addbeneficiaryobj.ROFR_PATTANO = null;
                }
                if (!string.IsNullOrEmpty(lbl_pattadhar.Text))
                {
                    addbeneficiaryobj.ROFR_PATTADAAR = lbl_pattadhar.Text;
                }
                else
                {
                    addbeneficiaryobj.ROFR_PATTADAAR = null;
                }
                if (!string.IsNullOrEmpty(txt_cname.Text))
                {

                    addbeneficiaryobj.CULTIVATOR_NAME = txt_cname.Text;
                }
                else
                {
                    addbeneficiaryobj.CULTIVATOR_NAME = null;
                }

                if (!string.IsNullOrEmpty(txt_eu_cultivator.Text))
                {
                    addbeneficiaryobj.EXTENT_UNDER_CULTIVATOR = txt_eu_cultivator.Text;
                }
                else
                {
                    addbeneficiaryobj.EXTENT_UNDER_CULTIVATOR = null;
                }
                if (!string.IsNullOrEmpty(txt_holding.Text))
                {
                    addbeneficiaryobj.HOLDING_NATURE = txt_holding.Text;
                }
                else
                {
                    addbeneficiaryobj.HOLDING_NATURE = null;
                }
                if (!string.IsNullOrEmpty(txt_typecode.Text))
                {
                    addbeneficiaryobj.TYPE_CODE = txt_typecode.Text;
                }
                else
                {
                    addbeneficiaryobj.TYPE_CODE = null;
                }
                if (!string.IsNullOrEmpty(txt_extent.Text))
                {
                    addbeneficiaryobj.EXTENT = txt_extent.Text;
                }
                else
                {
                    addbeneficiaryobj.EXTENT = null;
                }
                if (!string.IsNullOrEmpty(txt_net_area.Text))
                {
                    addbeneficiaryobj.NET_SOWN_AREA = txt_net_area.Text;
                }
                else
                {
                    addbeneficiaryobj.NET_SOWN_AREA = null;
                }
                // addbeneficiaryobj.KHARIFF_RABI = txt_kharif.Text;
                if (ddl_kharif.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.KHARIFF_RABI = ddl_kharif.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.KHARIFF_RABI = null;
                }
                if (ddl_month.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.MONTH_OF_CULTIVATION = ddl_month.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.MONTH_OF_CULTIVATION = null;
                }
                if (!string.IsNullOrEmpty(txt_crop.Text))
                {
                    addbeneficiaryobj.CROP = txt_crop.Text;
                }
                else
                {
                    addbeneficiaryobj.CROP = null;
                }
                if (!string.IsNullOrEmpty(txt_single.Text))
                {
                    addbeneficiaryobj.SINGLE = txt_single.Text;
                }
                else
                {
                    addbeneficiaryobj.SINGLE = null;
                }
                if (!string.IsNullOrEmpty(txt_mixed.Text))
                {
                    addbeneficiaryobj.MIXED = txt_mixed.Text;
                }
                else
                {
                    addbeneficiaryobj.MIXED = null;
                }
                if (!string.IsNullOrEmpty(txt_total.Text))
                {
                    addbeneficiaryobj.TOTAL = txt_total.Text;
                }
                else
                {
                    addbeneficiaryobj.TOTAL = null;

                }
                if (!string.IsNullOrEmpty(txt_water.Text))
                {
                    addbeneficiaryobj.WATER_SOURCE1 = txt_water.Text;
                }
                else
                {
                    addbeneficiaryobj.WATER_SOURCE1 = null;
                }
                // addbeneficiaryobj.MONTH_OF_CULTIVATION = txt_month.Text;
                if (!string.IsNullOrEmpty(txt_firstcrop.Text))
                {
                    addbeneficiaryobj.FIRST_CROP = txt_firstcrop.Text;
                }
                else
                {
                    addbeneficiaryobj.FIRST_CROP = null;
                }
                if (!string.IsNullOrEmpty(txt_secondcrop.Text))
                {
                    addbeneficiaryobj.SECOND_THIRD_CROP = txt_secondcrop.Text;
                }
                else
                {
                    addbeneficiaryobj.SECOND_THIRD_CROP = null;
                }
                if (!string.IsNullOrEmpty(txt_crop_yield.Text))
                {
                    addbeneficiaryobj.CROP_YIELD = txt_crop_yield.Text;
                }
                else
                {
                    addbeneficiaryobj.CROP_YIELD=null;
                }
                if (!string.IsNullOrEmpty(txt_vro.Text))
                {
                    addbeneficiaryobj.VRO_RI_REMARKS = txt_vro.Text;
                }
                else
                {
                    addbeneficiaryobj.VRO_RI_REMARKS = null;
                }
                if (!string.IsNullOrEmpty(txt_Thasildar.Text))
                {
                    addbeneficiaryobj.TAHSILDAR_REMARKS = txt_Thasildar.Text;
                }
                else
                {
                    addbeneficiaryobj.TAHSILDAR_REMARKS = null;
                }
                if (!string.IsNullOrEmpty(txt_remarks.Text))
                {
                    addbeneficiaryobj.REMARKS = txt_remarks.Text;
                }
                else
                {
                    addbeneficiaryobj.REMARKS = null;
                }
                if (!string.IsNullOrEmpty(txt_land_class.Text))
                {
                    addbeneficiaryobj.landclassifcation = txt_land_class.Text;
                }
                else
                {
                    addbeneficiaryobj.landclassifcation = null;
                }
                if (!string.IsNullOrEmpty(txt_dlc_date.Text))
                {
                    addbeneficiaryobj.dlcdate = txt_dlc_date.Text;
                }
                else
                {
                    addbeneficiaryobj.dlcdate = null;
                }
                if (!string.IsNullOrEmpty(lbl_adhaar.Text))
                {
                    addbeneficiaryobj.Aadhaar_NO = lbl_adhaar.Text;
                }
                else
                {

                    addbeneficiaryobj.Aadhaar_NO = null;
                }
                // addbeneficiaryobj.Image = imagefloder;
                if (dlc != null && dlc.ContentLength > 0)
                {
                    addbeneficiaryobj.Dlc = txt_dlc.Text;
                }
                else
                {
                    addbeneficiaryobj.Dlc = null;
                }
                //addbeneficiaryobj.Imagepath = txt_image.Text;
                if (dlc != null && dlc.ContentLength > 0)
                {
                    addbeneficiaryobj.Dlcpath = location;
                }
                else
                {
                    addbeneficiaryobj.Dlcpath = null;
                }
                if (!string.IsNullOrEmpty((string)Session["bankname"]))
                {
                    addbeneficiaryobj.bankname = (string)Session["bankname"];
                }
                else
                {
                    addbeneficiaryobj.bankname = null;
                }
                if (!string.IsNullOrEmpty((string)Session["bankacno"]))
                {
                    addbeneficiaryobj.bankaccountno = (string)Session["bankacno"];
                }
                else
                {
                    addbeneficiaryobj.bankaccountno = null;
                }
                if (!string.IsNullOrEmpty((string)Session["ifsc"]))
                {
                    addbeneficiaryobj.ifsccode = (string)Session["ifsc"];
                }
                else
                {
                    addbeneficiaryobj.ifsccode = null;
                }
                if (!string.IsNullOrEmpty(lbl_father.Text))
                {
                    addbeneficiaryobj.fathername = lbl_father.Text;
                }
                else
                {
                    addbeneficiaryobj.fathername = null;
                }
                if (!string.IsNullOrEmpty((string)Session["subcaste"]))
                {
                    addbeneficiaryobj.sub_caste = (string)Session["subcaste"];
                }
                else
                {
                    addbeneficiaryobj.sub_caste = null;
                }

                addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                    addbeneficiaryobj.UserName = (string)(Session["username"]);

                    if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                    {
                        try
                        {
                            ProjectRofrBAL.GetMasterDetails.AddBeneficiaryDetails(addbeneficiaryobj);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Beneficiary Details added successfully')", true);
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Beneficiary Details insertion failed !')", true);
                            ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                    Reset();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' please image and dlc upload files')", true);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try {
                DataTable dtdistrict = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "District", (string)(Session["itdacode"]), "", "", "", "", "", "", (string)Session["userprevilages"]);
               // DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(Lbl_itda.Text, (string)(Session["username"]));
                if (dtdistrict.Rows.Count > 0)
                {
                    BindDistrict(dtdistrict);
                    if (dtdistrict.Rows.Count <= 1)
                    {
                        ddl_district.SelectedIndex = 1;
                        DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", (string)(Session["itdacode"]), ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);
                      //  DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, Lbl_itda.Text, " ");


                        if (dtMandal.Rows.Count > 0)
                        {
                            BindMandal(dtMandal);
                        }
                        DataTable dtFDivisions = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Division", "", ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);
                      //  DataTable dtFDivisions = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "FDivision", ddl_district.SelectedValue, " ", " ");

                        if (dtFDivisions.Rows.Count > 0)
                        {
                            BindFDivision(dtFDivisions);
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

                div_field.Visible = true;
            div_forest.Visible = true;
            div_beneficiary.Visible = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void Reset()
        {
            ddl_district.ClearSelection();
            ddl_mandal.ClearSelection();

            ddl_village.ClearSelection();
            ddl_division.ClearSelection();
            ddl_range.ClearSelection();
            ddl_beat.ClearSelection();
            ddl_gp.ClearSelection();
            //txt_gp.Text = "";
            //txt_gpcode.Text = "";
            //txt_village.Text = "";
            //txt_villagecode.Text = "";

            // txt_Habitation.Text = "";
            txt_fblock.Text = "";
            txt_compartment.Text = "";
            txt_plot.Text = "";
            txt_plotarea.Text = "";
            txt_uc_land.Text = "";
            txt_c_land.Text = "";
            //txt_patta_inam.Text = "";
            ddl_patta_inam.ClearSelection();
            txt_patta_inam.Text = "";
            txt_wtax.Text = "";
            // txt_dry_id.Text = "";
            ddl_dry_id.ClearSelection();
            txt_wsource.Text = "";
            txt_Eirrigated.Text = "";
            txt_patta_no.Text = "";
            // txt_pattadar.Text = "";
            txt_cname.Text = "";
            txt_eu_cultivator.Text = "";
            txt_holding.Text = "";
            txt_typecode.Text = "";
            txt_extent.Text = "";
            txt_net_area.Text = "";
            //txt_kharif.Text = "";
            ddl_kharif.ClearSelection();
            txt_crop.Text = "";
            txt_single.Text = "";
            txt_mixed.Text = "";
            txt_total.Text = "";
            txt_water.Text = "";
            //txt_month.Text = "";
            ddl_land_class.ClearSelection();
            txt_land_class.Text = "";
            ddl_month.ClearSelection();
            txt_firstcrop.Text = "";
            txt_secondcrop.Text = "";
            txt_crop_yield.Text = "";
            txt_vro.Text = "";
            txt_Thasildar.Text = "";
            txt_remarks.Text = "";
            // txt_aadhar.Text = "";
            //txt_image.Text = "";
            txt_dlc.Text = "";
            txt_dlc_date.Text = "";
            // txt_bank_name.Text = "";
            // txt_bank_acnt.Text = "";
            //txt_ifsc_code.Text = "";
            //txt_father_name.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            div_beneficiary.Visible = false;
            div_forest.Visible = false;
            div_getdetails.Visible = false;
            div_click.Visible = false;
            div_field.Visible = false;
            txt_adhar.Text = "";
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using ROFR.helper;
using System.Text;

namespace ROFR.test
{
    public partial class Add_Beneficiary_Details : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    BindItda();
                   
                    ddl_district.Items.Insert(0, new ListItem("District", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Mandal", "0"));
                    ddl_division.Items.Insert(0, new ListItem("Division", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Village", "0"));
                    ddl_range.Items.Insert(0, new ListItem("Range", "0"));
                    ddl_beat.Items.Insert(0, new ListItem("Beat", "0"));
                    ddl_land_class.Items.Insert(0, new ListItem("Land Classification", "0"));
                    ddl_patta_inam.Items.Insert(0, new ListItem("Patta/Inam/Govt", "0"));
                    ddl_dry_id.Items.Insert(0, new ListItem("DRYID ONECROP TWO CROP", "0"));
                    ddl_kharif.Items.Insert(0, new ListItem("Khariff/Rabhi", "0"));
                    ddl_month.Items.Insert(0, new ListItem("Month of Cultivation", "0"));

                    file_dlc.Attributes.Add("onchange", "return file(this,'" + file_dlc.ClientID + "');");

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }
        private void BindItda()
        {
            try
            {
                DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdadetails((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_NAME";
                    ddl_ITda.DataBind();
                    ddl_ITda.Items.Insert(0, new ListItem("ITDA NAME", "0"));
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

        protected void ddlitda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_division.ClearSelection();
                    ddl_range.ClearSelection();
                    ddl_beat.ClearSelection();
                    DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
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

        private void BindDistrict(DataTable dt)
        {
            try
            {
                DataTable dtDistricts = dt;
                ddl_district.DataSource = dtDistricts;
                ddl_district.DataTextField = "DISTRICT_NAME";
                ddl_district.DataValueField = "DISTRICT_CODE";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("District", "0"));
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
                ddl_mandal.DataValueField = "MANDAL_CODE";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Mandal", "0"));
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
                ddl_village.DataValueField = "VILLAGE_CODE";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Village", "0"));
                
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
                ddl_division.Items.Insert(0, new ListItem("Division", "0"));
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

                ddl_range.Items.Insert(0, new ListItem("Range", "0"));
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
                ddl_beat.Items.Insert(0, new ListItem("Beat", "0"));
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
                    if (ddl_village.SelectedItem.Text != "Village" && ddl_mandal.SelectedItem.Text != "Mandal" && ddl_district.SelectedItem.Text != "District")

                    {
                        ddl_land_class.DataSource = dtlandclass;

                        ddl_land_class.DataTextField = "Land_Classification_Name";
                        ddl_land_class.DataValueField = "Land_Classification_Code";
                        ddl_land_class.DataBind();


                        ddl_land_class.Items.Insert(0, new ListItem("Land Classification", "0"));
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
                if (ddl_district.SelectedItem.Text != "District")
                {
                    ddl_range.ClearSelection();
                    ddl_beat.ClearSelection();
                    DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, " ", " ");


                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }

                    DataTable dtFDivisions = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "FDivision", ddl_district.SelectedValue, " ", " ");


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
                    ddl_division.ClearSelection();
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

        protected void ddl_mandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueVillages", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


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



       
        protected void ddl_division_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_division.SelectedItem.Text != "Division")
                {
                    ddl_range.ClearSelection();
                    ddl_beat.ClearSelection();
                    DataTable dtFRanges = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "FRanges", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


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
                if (ddl_range.SelectedItem.Text != "Range")

                {
                    DataTable dtFBeats = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "FBeats", ddl_district.SelectedValue, ddl_mandal.SelectedValue, ddl_village.SelectedValue);



                    
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                string IPAddress = (string)(Session["IPAddress"]);
                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                int length = FileUpload.PostedFile.ContentLength;
                Byte[] bytes = new byte[] { };
                byte[] imgbyte = new byte[] { };
                imgbyte = new byte[length];

                HttpPostedFile image = FileUpload.PostedFile;

                image.InputStream.Read(imgbyte, 0, length);
                string imagename = FileUpload.PostedFile.FileName;

                // FileUpload.PostedFile.SaveAs("~//Beneficiary Images" + "//" + imagename);
               string imagefloder = ddl_ITda.SelectedItem.Text+ ddl_district.SelectedValue;
                string benid = txt_pattadar.Text + txt_aadhar.Text;
                //HttpPostedFile image1 = Request.Files["FileUpload"];
                if (image != null && image.ContentLength > 0)
                {
                    try
                    {
                        string location = HttpContext.Current.Server.MapPath("~/BeneficairyImages/" + DateTime.Now.ToString("dd-MM-yyyy") + "/"+imagefloder+ "/"+benid+ "/");

                        if (!Directory.Exists(location))
                        {
                            Directory.CreateDirectory(location);

                        }
                        string imagesavefilename = image.FileName;
                        string filepath = location + Path.GetFileName(image.FileName);
                        image.SaveAs(filepath);
                        if (image != null)
                        {
                            txt_image.Text = image.FileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Image Location Created Error !')", true);
                        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                    }
                }
                HttpPostedFile dlc = file_dlc.PostedFile;
                string dlcpath = file_dlc.PostedFile.FileName;
                string dlcname = Path.GetFileName(dlcpath);
                string ext = Path.GetExtension(dlcname);
                string jpgext = Path.GetExtension(dlcname);
                string type = string.Empty;
                string type1 = string.Empty;
                string Compartmentno2 = string.Empty;
                string compartmentno = txt_pattadar.Text;
                Compartmentno2 = txt_pattadar.Text;
                compartmentno = compartmentno.Replace(" ", string.Empty);
                compartmentno = compartmentno + "New";
                string dlcfolder = ddl_ITda.SelectedItem.Text + ddl_district.SelectedValue;
                string aadhar = txt_aadhar.Text;
                //if (!string.IsNullOrEmpty(Compartmentno2)&& !string.IsNullOrEmpty(aadhar))
                //{
                    if (dlc != null && dlc.ContentLength > 0)
                    {
                        //if (!string.IsNullOrEmpty(Compartmentno2))
                        //{
                            try
                            {
                                string location = HttpContext.Current.Server.MapPath("~/DLC/" + dlcfolder + "/" );

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
                                    bytes = br.ReadBytes((Int32)filestream.Length);
                                }
                                if (type1 != string.Empty)
                                {
                                    int length1 = file_dlc.PostedFile.ContentLength;
                                    byte[] imgbyte1 = new byte[] { };
                                    imgbyte1 = new byte[length1];

                                    HttpPostedFile image1 = file_dlc.PostedFile;

                                    image1.InputStream.Read(imgbyte1, 0, length);
                                    //string imagename = file_dlc.PostedFile.FileName;
                                    bytes = imgbyte1;
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
                if (file_dlc.HasFile && image != null && image.ContentLength > 0)
                {
                    addbeneficiaryobj.Itda = ddl_ITda.SelectedItem.Text;
                    addbeneficiaryobj.District = ddl_district.SelectedItem.Text;
                    addbeneficiaryobj.District_Code = ddl_district.SelectedItem.Value;
                    addbeneficiaryobj.Mandal = ddl_mandal.SelectedItem.Text;
                    addbeneficiaryobj.Mandal_Code = ddl_mandal.SelectedItem.Value;
                    addbeneficiaryobj.Forest_Division = ddl_division.SelectedItem.Text;
                    addbeneficiaryobj.Forest_DivisionCode = ddl_division.SelectedItem.Value;
                    addbeneficiaryobj.Forest_Range = ddl_range.SelectedItem.Text;
                    addbeneficiaryobj.Forest_RangeCode = ddl_range.SelectedItem.Value;
                    addbeneficiaryobj.Forest_Beat = ddl_beat.SelectedItem.Text;
                    addbeneficiaryobj.Forest_BeatCode = ddl_beat.SelectedItem.Value;
                    addbeneficiaryobj.Gram_Panchayat = txt_gp.Text;
                    addbeneficiaryobj.Grama_Panchayat_Code = txt_gpcode.Text;
                    addbeneficiaryobj.Village = ddl_village.SelectedItem.Text;
                    addbeneficiaryobj.Village_Code = ddl_village.SelectedValue;

                    //addbeneficiaryobj.Village = txt_village.Text;
                    //addbeneficiaryobj.Village_Code = txt_villagecode.Text;
                    addbeneficiaryobj.HabitationCode = txt_habitation_code.Text;
                    addbeneficiaryobj.Habitation = txt_Habitation.Text;
                    addbeneficiaryobj.Forest_Block = txt_fblock.Text;
                    addbeneficiaryobj.Compartment_No = txt_compartment.Text;
                    addbeneficiaryobj.Plot_No = txt_plot.Text;
                    addbeneficiaryobj.ExtentPlotArea = txt_plotarea.Text;
                    addbeneficiaryobj.Uncultivable_Land = txt_uc_land.Text;
                    addbeneficiaryobj.Cultivable_Land = txt_c_land.Text;
                    //  addbeneficiaryobj.PATTA_INAMGOVT = txt_patta_inam.Text;
                    addbeneficiaryobj.PATTA_INAMGOVT = ddl_patta_inam.SelectedItem.Text;
                    addbeneficiaryobj.Water_Tax = txt_wtax.Text;
                    //addbeneficiaryobj.DRYID_ONECROP_TWO_CROP = txt_dry_id.Text;
                    addbeneficiaryobj.DRYID_ONECROP_TWO_CROP = ddl_dry_id.SelectedItem.Text;
                    addbeneficiaryobj.WATER_SOURCE = txt_wsource.Text;
                    addbeneficiaryobj.EXTENT_IRRIGATED = txt_Eirrigated.Text;
                    addbeneficiaryobj.ROFR_PATTANO = txt_patta_no.Text;
                    addbeneficiaryobj.ROFR_PATTADAAR = txt_pattadar.Text;
                    addbeneficiaryobj.CULTIVATOR_NAME = txt_cname.Text;
                    addbeneficiaryobj.EXTENT_UNDER_CULTIVATOR = txt_eu_cultivator.Text;
                    addbeneficiaryobj.HOLDING_NATURE = txt_holding.Text;
                    addbeneficiaryobj.TYPE_CODE = txt_typecode.Text;
                    addbeneficiaryobj.EXTENT = txt_extent.Text;
                    addbeneficiaryobj.NET_SOWN_AREA = txt_net_area.Text;
                    // addbeneficiaryobj.KHARIFF_RABI = txt_kharif.Text;
                    addbeneficiaryobj.KHARIFF_RABI = ddl_kharif.SelectedItem.Text;
                    addbeneficiaryobj.MONTH_OF_CULTIVATION = ddl_month.SelectedItem.Text;
                    addbeneficiaryobj.CROP = txt_crop.Text;
                    addbeneficiaryobj.SINGLE = txt_single.Text;
                    addbeneficiaryobj.MIXED = txt_mixed.Text;
                    addbeneficiaryobj.TOTAL = txt_total.Text;
                    addbeneficiaryobj.WATER_SOURCE1 = txt_water.Text;
                   // addbeneficiaryobj.MONTH_OF_CULTIVATION = txt_month.Text;
                    addbeneficiaryobj.FIRST_CROP = txt_firstcrop.Text;
                    addbeneficiaryobj.SECOND_THIRD_CROP = txt_secondcrop.Text;
                    addbeneficiaryobj.CROP_YIELD = txt_crop_yield.Text;
                    addbeneficiaryobj.VRO_RI_REMARKS = txt_vro.Text;
                    addbeneficiaryobj.TAHSILDAR_REMARKS = txt_Thasildar.Text;
                    addbeneficiaryobj.REMARKS = txt_remarks.Text;
                    addbeneficiaryobj.landclassifcation = ddl_land_class.SelectedItem.Text;
                    addbeneficiaryobj.dlcdate = txt_dlc_date.Text;
                    addbeneficiaryobj.Aadhaar_NO = txt_aadhar.Text;
                    addbeneficiaryobj.Image =imagefloder;
                    addbeneficiaryobj.Dlc = dlcfolder;
                    addbeneficiaryobj.Imagepath = txt_image.Text;
                    addbeneficiaryobj.Dlcpath = txt_dlc.Text;
                    addbeneficiaryobj.bankname = txt_bank_name.Text;
                    addbeneficiaryobj.bankaccountno = txt_bank_acnt.Text;
                    addbeneficiaryobj.ifsccode = txt_ifsc_code.Text;
                    addbeneficiaryobj.fathername = txt_father_name.Text;

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
                }
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

        private void Reset()
        {
            ddl_district.ClearSelection();
            ddl_mandal.ClearSelection();
            ddl_division.ClearSelection();
            ddl_range.ClearSelection();
            ddl_beat.ClearSelection();
            ddl_village.ClearSelection();
            txt_gp.Text = "";
            txt_gpcode.Text = "";
            //txt_village.Text = "";
            //txt_villagecode.Text = "";
            txt_habitation_code.Text = "";
            txt_Habitation.Text = "";
            txt_fblock.Text = "";
            txt_compartment.Text = "";
            txt_plot.Text = "";
            txt_plotarea.Text = "";
            txt_uc_land.Text = "";
            txt_c_land.Text = "";
            //txt_patta_inam.Text = "";
            ddl_patta_inam.ClearSelection();
            txt_wtax.Text = "";
            // txt_dry_id.Text = "";
            ddl_dry_id.ClearSelection();
            txt_wsource.Text = "";
            txt_Eirrigated.Text = "";
            txt_patta_no.Text = "";
            txt_pattadar.Text = "";
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

            ddl_month.ClearSelection();
            txt_firstcrop.Text = "";
            txt_secondcrop.Text = "";
            txt_crop_yield.Text = "";
            txt_vro.Text = "";
            txt_Thasildar.Text = "";
            txt_remarks.Text = "";
            txt_aadhar.Text = "";
            txt_image.Text = "";
            txt_dlc.Text = "";
            txt_dlc_date.Text= "";
            txt_bank_name.Text= "";
            txt_bank_acnt.Text= "";
            txt_ifsc_code.Text= "";
            txt_father_name.Text= "";
        }

        protected void ddl_village_SelectedIndexChanged(object sender, EventArgs e)
        {
            land_classification();
            bind_patta_inam();
            bind_dry_id();
            bind_khariff();
            bind_month_cultivation();

        }


        private void bind_patta_inam()
        {
            try
            {
                DataTable dtpatta = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Patta", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
               
                if (dtpatta.Rows.Count > 0)
                {
                    if (ddl_village.SelectedItem.Text != "Village" && ddl_mandal.SelectedItem.Text != "Mandal" && ddl_district.SelectedItem.Text != "District")

                    {
                        ddl_patta_inam.DataSource = dtpatta;

                        ddl_patta_inam.DataTextField = "rofr_patta_name";
                        ddl_patta_inam.DataValueField = "rofr_patta_id";
                        ddl_patta_inam.DataBind();


                        ddl_patta_inam.Items.Insert(0, new ListItem("Patta/Inam/Govt", "0"));
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
                    if (ddl_village.SelectedItem.Text != "Village" && ddl_mandal.SelectedItem.Text != "Mandal" && ddl_district.SelectedItem.Text != "District")

                    {
                        ddl_dry_id.DataSource = dtdry;

                        ddl_dry_id.DataTextField = "Land_type";
                        ddl_dry_id.DataValueField = "Land_type_id";
                        ddl_dry_id.DataBind();


                        ddl_dry_id.Items.Insert(0, new ListItem("DRYID ONECROP TWO CROP", "0"));
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
                    if (ddl_village.SelectedItem.Text != "Village" && ddl_mandal.SelectedItem.Text != "Mandal" && ddl_district.SelectedItem.Text != "District")

                    {
                        ddl_kharif.DataSource = dtcropseason;

                        ddl_kharif.DataTextField = "crop_type";
                        ddl_kharif.DataValueField = "crop_type_id";
                        ddl_kharif.DataBind();


                        ddl_kharif.Items.Insert(0, new ListItem("KHARIFF/RABI", "0"));
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
                    if (ddl_village.SelectedItem.Text != "Village" && ddl_mandal.SelectedItem.Text != "Mandal" && ddl_district.SelectedItem.Text != "District")

                    {
                       ddl_month.DataSource = dtcropmnth;

                        ddl_month.DataTextField = "month_eng";
                        ddl_month.DataValueField = "sno";
                        ddl_month.DataBind();


                        ddl_month.Items.Insert(0, new ListItem("Month of Cultivation", "0"));
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

    }
}
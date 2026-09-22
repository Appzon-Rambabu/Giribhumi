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
    public partial class Update_Farmer : System.Web.UI.Page
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
                System.Threading.Thread.Sleep(5000);
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
                System.Threading.Thread.Sleep(5000);
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
                System.Threading.Thread.Sleep(5000);
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
                System.Threading.Thread.Sleep(5000);

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
                DataTable dt = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Details", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", (string)Session["userprevilages"]);
              


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

        protected void ddl_gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGender = ddl_gender.SelectedValue;  // "M" or "F"
        }

        
        //Newly adding for Caste
        private void BindCaste()
        {
            try
            {

                DataTable cs = Landsettlementpattas.GetCaste((string)(Session["username"]), "cs", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);

                if (cs.Rows.Count > 0)
                {
                    ddl_Caste.DataSource = cs;
                    ddl_Caste.DataTextField = "CASTE";
                    ddl_Caste.DataValueField = "CASTE";
                    ddl_Caste.DataBind();
                    ddl_Caste.Items.Insert(0, new ListItem("Select", "0"));

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindSubCaste()
        {
            try
            {

                DataTable scs = Landsettlementpattas.GetSUBCaste((string)(Session["username"]), ddl_Caste.Text, ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);

                if (scs.Rows.Count > 0)
                {

                    ddl_Subcaste.DataSource = scs;
                    ddl_Subcaste.DataTextField = "SUB_CASTE";
                    ddl_Subcaste.DataValueField = "SUB_CASTE";
                    ddl_Subcaste.DataBind();
                    ddl_Subcaste.Items.Insert(0, new ListItem("Select", "0"));
                    string script = "window.onload = function() { openModal(); };";
                    ClientScript.RegisterStartupScript(this.GetType(), "openModal", script, true);
                   
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

        protected void ddl_Caste_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_Subcaste.Items.Clear();

              //  ddl_Subcaste.Items.Insert(0, new ListItem("Select", "0"));

                //if (ddl_Caste.SelectedItem.Text != "Select" || ddl_Caste.SelectedItem.Text != "" || ddl_Caste.SelectedItem.Text != null)
                //{
                    BindSubCaste();
                //}
                //else
                //{
                //    ddl_Subcaste.ClearSelection();
                //}
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
                        //ddl_Caste.Items.Clear();
                        //ddl_Subcaste.Items.Clear();
                        Label farmer = item.FindControl("farmer") as Label;
                        Label father = item.FindControl("fname") as Label;
                        Label adhar = item.FindControl("adhar") as Label;
                        //Label newadhar = item.FindControl("newadhar") as Label;
                        Label bankacnt = item.FindControl("banckacnt") as Label;
                        Label ifsc = item.FindControl("ifsccode") as Label;
                        Label bankname = item.FindControl("bankname") as Label;
                        Label bid = item.FindControl("bid") as Label;
                        Label hab = item.FindControl("hab") as Label;
                        Label mobile = item.FindControl("mobile") as Label;
                        Label dob = item.FindControl("Dob") as Label;
                        Label homeAddress = item.FindControl("Address") as Label;
                        Label gender = item.FindControl("Gender") as Label;
                        Label Image1 = item.FindControl("Image1") as Label;
                        Label Imagepath = item.FindControl("Imagepath") as Label;

                        Label caste = item.FindControl("caste_") as Label;
                        Label subcaste = item.FindControl("subcaste") as Label;

                        BindCaste();


                       
                        ddl_Caste.Items.Insert(0, new ListItem(caste.Text, caste.Text));
                        
                        if (ddl_Caste.SelectedItem.Text != "Select" || ddl_Caste.SelectedItem.Text != "" || ddl_Caste.SelectedItem.Text != null)
                        {
                            BindSubCaste();
                        }

                         ddl_Subcaste.Items.Insert(0, new ListItem(subcaste.Text, subcaste.Text));

                        // ✅ Set Date of Birth textbox correctly
                        if (dob != null && !string.IsNullOrEmpty(dob.Text))
                        {
                            DateTime parsedDate;
                            if (DateTime.TryParse(dob.Text, out parsedDate))
                            {
                                Apply.Text = parsedDate.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                Apply.Text = string.Empty;
                            }
                        }
                        else
                        {
                            Apply.Text = string.Empty;
                        }
                        // For Gender 20-12-2024
                        //List<string> genders = new List<string> { "Male", "Female" };

                        //ddl_gender.DataSource = genders;
                        //ddl_gender.DataBind();
                        //ddl_gender.Items.Insert(0, new ListItem(gender.Text, gender.Text));

                        //ddl_gender.Items.Insert(1, new ListItem("--Select Gender--", ""));

                        List<ListItem> genders = new List<ListItem>
                            {
                                new ListItem("--Select Gender--", ""), // default item
                                new ListItem("Male", "M"),
                                new ListItem("Female", "F")
                            };

                        ddl_gender.DataSource = genders;
                        ddl_gender.DataTextField = "Text";
                        ddl_gender.DataValueField = "Value";
                        ddl_gender.DataBind();

                        // ✅ Set selected gender based on value from GridView
                        if (gender != null && !string.IsNullOrEmpty(gender.Text))
                        {
                            // Handles both full word and single-letter gender
                            if (gender.Text.Equals("Male", StringComparison.OrdinalIgnoreCase) ||
                                gender.Text.Equals("M", StringComparison.OrdinalIgnoreCase))
                            {
                                ddl_gender.SelectedValue = "M";
                            }
                            else if (gender.Text.Equals("Female", StringComparison.OrdinalIgnoreCase) ||
                                     gender.Text.Equals("F", StringComparison.OrdinalIgnoreCase))
                            {
                                ddl_gender.SelectedValue = "F";
                            }
                            else
                            {
                                ddl_gender.SelectedValue = ""; // Default
                            }
                        }

                        if (Image1.Text != "NA" && Imagepath.Text != "NA")
                        {
                            filename = Image1.Text;
                            path = Imagepath.Text;



                            imgBase64String = GetBase64StringForImage(path + filename);


                            // DisplayImages(ds.Tables[0].Rows[i], "Image", (path + filename));


                        }
                        else
                        {

                            string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");

                            imgBase64String = GetBase64StringForImage(imgpath);


                        }
                        txt_bid.Text = bid.Text;
                        txt_hab.Text = hab.Text;
                        txt_farmer.Text = farmer.Text;
                        txt_fname.Text = father.Text;
                        //txt_subcaste.Text = subcaste.Text;
                        txt_adhar.Text = adhar.Text;
                         txt_newadhar.Text = "";
                        txt_bacnt.Text = bankacnt.Text;
                        txt_ifsc.Text = ifsc.Text;
                        txt_bname.Text = bankname.Text;
                        txt_mob.Text = mobile.Text;
                        Txt_address.Text = homeAddress.Text;
                       // txt_gender.Text = gender.Text;
                        Apply.Text = dob.Text;
                        txt_Caste.Text = caste.Text;
                        txt_Subcaste.Text = subcaste.Text;
                       // txt_gender.Text= gender.Text;
                        FarmerImage.ImageUrl = "data:image/jpeg;base64," + imgBase64String;
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
                string mask = Request.Form[HiddenField1.UniqueID];
                //if (!string.IsNullOrEmpty(txt_newadhar.Text))
                //{
                //    DataTable dt = ProjectRofrBAL.GetMasterDetails.Check_newadhaar((string)(Session["username"]), txt_adhar.Text.Trim(), mask.Trim());

                //    if (dt.Rows.Count > 0)
                //    {
                //        string adhar = mask;
                //        string ad = dt.Rows[0]["New_Aadhaar_no"].ToString();
                //        if (adhar == ad)
                //        {

                //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Aadhar number already Exists')", true);
                //        }
                //        else
                //        {
                //            data_update();
                //        }

                //    }
                //}
                //else
                //{
                //    data_update();



                //}

                string admask = Request.Form[HiddenField1.UniqueID];

                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                addbeneficiaryobj.id = txt_bid.Text;


                //newly adding for 

                if (ddl_Caste.SelectedItem.Text != "Select" && ddl_Caste.SelectedItem.Text != null && ddl_Caste.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.caste = ddl_Caste.SelectedItem.Text;
                    addbeneficiaryobj.caste = ddl_Caste.SelectedValue;
                }
                else
                {
                    addbeneficiaryobj.caste = null;
                    addbeneficiaryobj.caste = null;
                }
                if (ddl_Subcaste.SelectedItem.Text != "Select" && ddl_Subcaste.SelectedItem.Text != null && ddl_Subcaste.SelectedItem.Text != "")
                {
                    addbeneficiaryobj.sub_caste = ddl_Subcaste.SelectedItem.Text;
                    addbeneficiaryobj.sub_caste = ddl_Subcaste.SelectedValue;

                }
                else
                {
                    addbeneficiaryobj.sub_caste = null;
                    addbeneficiaryobj.sub_caste = null;
                }
                if (txt_fname.Text != "" && txt_fname.Text != null)
                {
                    addbeneficiaryobj.fathername = txt_fname.Text;
                }
                else
                {
                    addbeneficiaryobj.fathername = null;
                }
                
                if (txt_newadhar.Text != "" && txt_newadhar.Text != null)
                {
                    addbeneficiaryobj.Aadhaar_NO = admask;
                }
                else
                {
                    addbeneficiaryobj.Aadhaar_NO = null;
                }
                if (txt_bacnt.Text != "" && txt_bacnt.Text != null)
                {
                    addbeneficiaryobj.bankaccountno = txt_bacnt.Text;
                }
                else
                {
                    addbeneficiaryobj.bankaccountno = null;
                }
                if (txt_ifsc.Text != "" && txt_ifsc.Text != null)
                {
                    addbeneficiaryobj.ifsccode = txt_ifsc.Text;
                }
                else
                {
                    addbeneficiaryobj.ifsccode = null;
                }

                if (txt_bname.Text != "" && txt_bname.Text != null)
                {
                    addbeneficiaryobj.bankname = txt_bname.Text;
                }
                else
                {
                    addbeneficiaryobj.bankname = null;
                }

                //New 04-01-2024 
                //if (ddl_gender.SelectedItem.Text != "Select" && ddl_gender.SelectedItem.Text != null && ddl_gender.SelectedItem.Text != "")
                //{
                //    addbeneficiaryobj.gender = ddl_gender.SelectedItem.Text;

                //}
                //else
                //{
                //    addbeneficiaryobj.gender = null;
                //    addbeneficiaryobj.gender = null;
                //}
                if (!string.IsNullOrEmpty(ddl_gender.SelectedValue))
                {
                    addbeneficiaryobj.gender = ddl_gender.SelectedValue; // "M" or "F"
                }
                    
                else
                {
                    addbeneficiaryobj.gender = null;
                }
                    


                if (txt_mob.Text != "" && txt_mob.Text != null)
                {
                    addbeneficiaryobj.Mobileno = txt_mob.Text;
                }
                else
                {
                    addbeneficiaryobj.Mobileno = null;
                }
                if (Txt_address.Text != "" && Txt_address.Text != null)
                {
                    addbeneficiaryobj.Address = Txt_address.Text;
                }
                else
                {
                    addbeneficiaryobj.Address = null;
                }
                if (Apply.Text != "" && Apply.Text != null)
                {
                    addbeneficiaryobj.dob = Apply.Text;
                }
                else
                {
                    addbeneficiaryobj.dob = null;
                }

                addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                addbeneficiaryobj.UserName = (string)(Session["username"]);


                if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                {
                    if (!string.IsNullOrEmpty(txt_bid.Text))
                    {


                       DataTable dt= Landsettlementpattas.UpdateFarmer(addbeneficiaryobj, (string)(Session["username"]));
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            if(dt.Rows[0]["STATUS"].ToString()=="1")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Farmer Details Updated Successfully !')", true);
                            }
                           else if (dt.Rows[0]["STATUS"].ToString() == "101")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Already Aadhar Exists')", true);
                            }
                            else if (dt.Rows[0]["STATUS"].ToString() == "102")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Aadhar Freezed cannot be updated')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updation Failed !')", true);
                            }
                        }
                       
                        //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                        //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                        BindGrid();
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
                    ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
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
            AntiForgery.Validate();
            foreach (GridViewRow item in GridView1.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox1");
                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }

        protected void ddl_Subcaste_SelectedIndexChanged(object sender, EventArgs e)
        {
            string script = "window.onload = function() { openModal(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openModal", script, true);
        }

        
    }

}
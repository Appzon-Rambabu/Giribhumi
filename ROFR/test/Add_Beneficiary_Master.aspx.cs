using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.IO;

namespace ROFR.test
{
    public partial class Add_Beneficiary_Master : System.Web.UI.Page
    {
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
                    ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));



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

        private void Bindhabitation(DataTable dthabitation)
        {
            try
            {
                ddl_Habitation.DataSource = dthabitation;
                ddl_Habitation.DataTextField = "HABITATION";
                ddl_Habitation.DataValueField = "HabitationCode";
                ddl_Habitation.DataBind();
                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
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

        protected void ddlitda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try

            {
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                    ddl_Habitation.ClearSelection();

                    DataTable dtdistrict = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "District", ddl_ITda.SelectedValue, "", "", "", "", "", "", (string)Session["userprevilages"]);
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);
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
        protected void ddlHabitation_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddldistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);

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
                    ddl_Habitation.ClearSelection();


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
                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Village", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
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

                    ddl_Habitation.ClearSelection();


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

               
                ddl_Habitation.Items.Clear();

                ddl_Habitation.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_village.SelectedItem.Text != "Select")


                {
                    DataTable dthab = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Habitation", ddl_ITda.SelectedValue, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);
                  //  DataTable dthab = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Rhabitation", ddl_district.SelectedValue, ddl_mandal.SelectedValue, ddl_village.SelectedValue);




                    if (dthab.Rows.Count > 0)
                    {
                        Bindhabitation(dthab);

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {

                    ddl_Habitation.ClearSelection();


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
                string filepath = string.Empty;
                string location = string.Empty;
                string IPAddress = (string)(Session["IPAddress"]);
                string mask = Request.Form[HiddenField1.UniqueID];
                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                int length = FileUpload.PostedFile.ContentLength;
                Byte[] bytes = new byte[] { };
                byte[] imgbyte = new byte[] { };
                imgbyte = new byte[length];

                HttpPostedFile image = FileUpload.PostedFile;

                image.InputStream.Read(imgbyte, 0, length);
                string imagename = FileUpload.PostedFile.FileName;

                // FileUpload.PostedFile.SaveAs("~//Beneficiary Images" + "//" + imagename);
                string imagefloder = ddl_ITda.SelectedItem.Text + ddl_district.SelectedValue;
                string benid = txt_pattadhar.Text +mask;
                //HttpPostedFile image1 = Request.Files["FileUpload"];

                if (image != null && image.ContentLength > 0)
                {
                    try
                    {
                        location = HttpContext.Current.Server.MapPath("~/BeneficairyImages/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + imagefloder + "/" + benid + "/");

                        if (!Directory.Exists(location))
                        {
                            Directory.CreateDirectory(location);

                        }
                        string imagesavefilename = image.FileName;
                         filepath = location + Path.GetFileName(image.FileName);
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
           
                DataSet ds = ProjectRofrBAL.GetMasterDetails.Checkadhar((string)(Session["username"]), mask.Trim());
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string adhar = mask;
                    string ad = dt.Rows[0]["Aadhaar_NO"].ToString();
                    if (adhar == ad)
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Aadhar number already Exists')", true);
                    }
                    Reset();
                }
                else
                {

                    // if (image != null && image.ContentLength > 0)
                    // {

                    if (ddl_ITda.SelectedItem.Text != "Select")
                    {
                        addbeneficiaryobj.Itda = ddl_ITda.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.Itda = null;
                    }
                    if (!string.IsNullOrEmpty(ddl_ITda.SelectedValue)|| (ddl_ITda.SelectedValue!="0"))
                    {
                        addbeneficiaryobj.Itdacode = ddl_ITda.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.Itdacode = null;
                    }
                    if(ddl_district.SelectedItem.Text!="Select")
                    { 
                        addbeneficiaryobj.District = ddl_district.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.District = null;
                    }
                    if (!string.IsNullOrEmpty(ddl_district.SelectedValue)|| (ddl_district.SelectedValue!="0"))
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
                    if (!string.IsNullOrEmpty(ddl_mandal.SelectedValue)|| (ddl_mandal.SelectedValue!="0"))
                    {
                        addbeneficiaryobj.Mandal_Code = ddl_mandal.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.Mandal_Code = null;
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
                    if (!string.IsNullOrEmpty(ddl_Habitation.SelectedValue)|| (ddl_Habitation.SelectedValue!="0"))
                    {
                        addbeneficiaryobj.HabitationCode = ddl_Habitation.SelectedValue;
                    }
                    else
                    {
                        addbeneficiaryobj.HabitationCode = null;
                    }
                    if (ddl_Habitation.SelectedItem.Text != "Select")
                    {
                        addbeneficiaryobj.Habitation = ddl_Habitation.SelectedItem.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.Habitation = null;
                    }
                    if (!string.IsNullOrEmpty(txt_pattadhar.Text))
                    {
                        addbeneficiaryobj.ROFR_PATTADAAR = txt_pattadhar.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.ROFR_PATTADAAR = null;
                    }
                    if (!string.IsNullOrEmpty(mask))
                    {
                        addbeneficiaryobj.Aadhaar_NO = mask;
                    }
                    else
                    {
                        addbeneficiaryobj.Aadhaar_NO = null;
                    }

                    if (!string.IsNullOrEmpty(txt_bankname.Text))
                    {
                        addbeneficiaryobj.bankname = txt_bankname.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.bankname = null;
                    }
                    if (!string.IsNullOrEmpty(txt_bankaccount.Text))
                    {
                        addbeneficiaryobj.bankaccountno = txt_bankaccount.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.bankaccountno = null;
                    }
                    if (!string.IsNullOrEmpty(txt_ifsc.Text))
                    {
                        addbeneficiaryobj.ifsccode = txt_ifsc.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.ifsccode = null;
                    }
                    if (!string.IsNullOrEmpty(txt_father.Text))
                    {
                        addbeneficiaryobj.fathername = txt_father.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.fathername = null;
                    }
                    if (!string.IsNullOrEmpty(txt_poaccount.Text))
                    {
                        addbeneficiaryobj.postofficeaccount = txt_poaccount.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.postofficeaccount = null;
                    }
                    if (!string.IsNullOrEmpty(txt_po_number.Text))
                    {
                        addbeneficiaryobj.ponumber = txt_po_number.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.ponumber = null;
                    }
                    if (!string.IsNullOrEmpty(txt_poname.Text))
                    {
                        addbeneficiaryobj.poname = txt_poname.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.poname = null;
                    }
                    if (!string.IsNullOrEmpty(txt_subcaste.Text))
                    {
                        addbeneficiaryobj.sub_caste = txt_subcaste.Text;
                    }
                    else
                    {
                        addbeneficiaryobj.sub_caste = null;
                    }
                    if (image != null && image.ContentLength > 0)
                    {
                        addbeneficiaryobj.Image = image.FileName;
                    }
                    else
                    {
                        addbeneficiaryobj.Image = null;
                    }
                    if (image != null && image.ContentLength > 0)
                    {
                        addbeneficiaryobj.Imagepath =location;

                    }
                    else
                    {
                        addbeneficiaryobj.Imagepath = null;
                    }

                        addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                        addbeneficiaryobj.UserName = (string)(Session["username"]);

                        if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                        {
                            try
                            {
                                DataTable id = ProjectRofrBAL.GetMasterDetails.AddBeneficiaryMaster(addbeneficiaryobj);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Beneficiary added successfully.Please save Beneficiary ID for future purpose and Beneficiary ID is:  " + id.Rows[0]["beneficiary_id"].ToString() + "')", true);
                                // DataSet ds= ProjectRofrBAL.GetMasterDetails.getbenificiaryid("","");

                                //GetBenficiaryID();

                            }

                            catch (Exception ex)
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Beneficiary insertion failed !')", true);
                                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                        // Reset();


                    //}
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void Reset()
        {
            ddl_ITda.ClearSelection();
            ddl_district.ClearSelection();
            ddl_mandal.ClearSelection();

            ddl_village.ClearSelection();

            ddl_Habitation.ClearSelection();

            txt_pattadhar.Text = "";
            txt_subcaste.Text = "";
            txt_Adhar.Text = "";
            txt_image.Text = "";
            txt_father.Text = "";
            txt_bankaccount.Text = "";
            txt_bankname.Text = "";
            txt_ifsc.Text = "";
            txt_poaccount.Text = "";
            txt_poname.Text = "";
            txt_po_number.Text = "";


        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = ProjectRofrBAL.GetMasterDetails.Checkadhar((string)(Session["username"]), txt_Adhar.Text.Trim());
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string adhar = txt_Adhar.Text;
                    string ad = dt.Rows[0]["Aadhaar_NO"].ToString();
                    if (adhar == ad)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Aadhar number is available')", true);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        //protected void txt_Adhar_TextChanged(object sender, EventArgs e)

        //{
        //    string str = txt_Adhar.Text.Trim();
        //    this.txt_Adhar.Text = string.Format("************{0}", this.txt_Adhar.Text.Trim().Substring((str.Length)-4, 4));
        //}



        protected void btn_reset_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
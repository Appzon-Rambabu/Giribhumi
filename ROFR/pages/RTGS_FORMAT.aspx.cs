using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.IO;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace ROFR
{
    public partial class RTGS_FORMAT : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_village.Items.Insert(0, new ListItem("Select", "0"));
            ddl_valid.Items.Insert(0, new ListItem("Select", "0"));
            ddl_type.Items.Insert(0, new ListItem("Select", "0"));

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    BindItda();
                    // BindDistrict();
                    //select_records.Visible = false;
                    btn_submit.Visible = false;

                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_valid.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_type.Items.Insert(0, new ListItem("Select", "0"));
                    chkAll.Visible = false;


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
                DataTable dtItda = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);

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
                ddl_mandal.Items.Insert(1, new ListItem("NULL", "NULL"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindVillage(DataTable dtVillage)
        {
            try
            {

                ddl_village.DataSource = dtVillage;
                ddl_village.DataTextField = "VILLAGE_NAME";
                ddl_village.DataValueField = "Village_Code";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Insert(1, new ListItem("NULL", "NULL"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindStatus(DataTable dtstatus)
        {
            try
            {

                ddl_valid.DataSource = dtstatus;
                ddl_valid.DataTextField = "status";
                ddl_valid.DataValueField = "status";
                ddl_valid.DataBind();
                ddl_valid.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void Bindtype(DataTable dttype)
        {
            try
            {

                ddl_type.DataSource = dttype;
                ddl_type.DataTextField = "type";
                ddl_type.DataValueField = "type";
                ddl_type.DataBind();
                ddl_type.Items.Insert(0, new ListItem("Select", "0"));

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
                Repeater1.Visible = false;
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_valid.Items.Clear();

                ddl_valid.Items.Insert(0, new ListItem("Select", "0"));
                ddl_type.Items.Clear();

                ddl_type.Items.Insert(0, new ListItem("Select", "0"));
                chkAll.Visible = false;
                btn_submit.Visible = false;
                //ddl_records.Items.Clear();
                // Repeater1.DataSource = null;
                //Repeater1.DataBind();

                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();


                    DataTable dtdistrict = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "District", ddl_ITda.SelectedValue, "", "", "", "", (string)Session["userprevilages"]);
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", (string)Session["userprevilages"]);


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

                Repeater1.Visible = false;
                chkAll.Visible = false;
                btn_submit.Visible = false;
                ddl_valid.Items.Clear();

                ddl_valid.Items.Insert(0, new ListItem("Select", "0"));
                ddl_type.Items.Clear();

                ddl_type.Items.Insert(0, new ListItem("Select", "0"));

                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                //ddl_records.Items.Clear();
                //Repeater1.DataSource = null;
               // Repeater1.DataBind();

                if (ddl_district.SelectedItem.Text != "Select")
                {


                    DataTable dtMandal = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "Mandal", ddl_ITda.SelectedValue, ddl_district.SelectedValue, "", "", "", (string)Session["userprevilages"]);


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

                Repeater1.Visible = false;
                chkAll.Visible = false;
                btn_submit.Visible = false;
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_valid.Items.Clear();

                ddl_valid.Items.Insert(0, new ListItem("Select", "0"));
                ddl_type.Items.Clear();

                ddl_type.Items.Insert(0, new ListItem("Select", "0"));


                //ddl_records.Items.Clear();
                //Repeater1.DataSource = null;
                // Repeater1.DataBind();

                if (ddl_mandal.SelectedItem.Text != "Select")
                {


                    DataTable dtvillage = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "RtgsVillage", ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);


                    if (dtvillage.Rows.Count > 0)
                    {
                        BindVillage(dtvillage);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }


                }
                else
                {
                    ddl_mandal.ClearSelection();



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
                Repeater1.Visible = false;
                chkAll.Visible = false;
                btn_submit.Visible = false;
                ddl_type.Items.Clear();

                ddl_type.Items.Insert(0, new ListItem("Select", "0"));


                //ddl_records.Items.Clear();
                //Repeater1.DataSource = null;
                // Repeater1.DataBind();

                if (ddl_ITda.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select"  && ddl_village.SelectedItem.Text != "Select")
                {


                    DataTable dtstatus = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "status", "", "", "", "", "", (string)Session["userprevilages"]);


                    if (dtstatus.Rows.Count > 0)
                    {
                        BindStatus(dtstatus);
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
        protected void ddlvalid_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Repeater1.Visible = false;
                btn_submit.Visible = false;
                chkAll.Visible = false;
                ddl_type.Items.Clear();

                ddl_type.Items.Insert(0, new ListItem("Select", "0"));


                //ddl_records.Items.Clear();
                //Repeater1.DataSource = null;
                // Repeater1.DataBind();

                if (ddl_ITda.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_village.SelectedItem.Text != "Select" && ddl_valid.SelectedItem.Text != "Select")
                {

                    DataTable dttype = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "type", "", "", "", "", "", (string)Session["userprevilages"]);


                    if (dttype.Rows.Count > 0)
                    {
                        Bindtype(dttype);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }



                }
                else
                {
                    ddl_valid.ClearSelection();



                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddltype_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              
                Repeater1.DataSource = null;

                Repeater1.DataBind();
             
                if (ddl_ITda.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_village.SelectedItem.Text != "Select" && ddl_valid.SelectedItem.Text != "Select" && ddl_type.SelectedItem.Text != "Select")
                {
                    DataTable dt = Landsettlementpattas.GetRtgs_FormatData(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, ddl_valid.SelectedItem.Text, ddl_type.SelectedItem.Text);



                    if (dt.Rows.Count > 0)
                    {
                        Repeater1.DataSource = dt;

                        Repeater1.DataBind();

                        chkAll.Visible = true;
                        btn_submit.Visible = true;
                        Repeater1.Visible = true;
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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox chk1 = (CheckBox)item.FindControl("chkSelect");
                if (chk1.Checked == false)
                {
                    HtmlTableRow row = (HtmlTableRow)item.FindControl("row");
                    row.Attributes["style"] = "background-color:white";

                    TextBox mandal = item.FindControl("txt_mandal") as TextBox;
                    mandal.BackColor = Color.White;
                    TextBox village = item.FindControl("txt_village") as TextBox;
                    village.BackColor = Color.White;
                    TextBox cno = item.FindControl("txt_cno") as TextBox;
                    cno.BackColor = Color.White;
                    TextBox epa = item.FindControl("txt_epa") as TextBox;
                    epa.BackColor = Color.White;
                    TextBox rpn = item.FindControl("txt_rpn") as TextBox;
                    rpn.BackColor = Color.White;
                    TextBox pno = item.FindControl("txt_pn") as TextBox;
                    pno.BackColor = Color.White;
                    TextBox rpd = item.FindControl("txt_rpd") as TextBox;
                    rpd.BackColor = Color.White;
                    TextBox fathername = item.FindControl("txt_Fathername") as TextBox;
                    fathername.BackColor = Color.White;
                    
                    TextBox adhar = item.FindControl("txt_adhar") as TextBox;
                   adhar.BackColor = Color.White;
                   
                    TextBox bankno = item.FindControl("txt_bankno") as TextBox;
                    bankno.BackColor = Color.White;
                    TextBox ifsc = item.FindControl("txt_ifsc") as TextBox;
                   ifsc.BackColor = Color.White;
                    TextBox bname = item.FindControl("txt_bname") as TextBox;
                 bname.BackColor = Color.White;
                    
                }
            }
            var chk = (CheckBox)sender;
            var item1 = (RepeaterItem)chk.NamingContainer;
            // var item1 = ((CheckBox)sender).Parent as RepeaterItem;
            if (item1 != null)
            {
                if (chk.Checked != false)
                {

                  HtmlTableRow crow = (HtmlTableRow)item1.FindControl("row");
                   

                    TextBox mandal = crow.FindControl("txt_mandal") as TextBox;
                    mandal.BackColor = Color.LightBlue;
                    TextBox village = crow.FindControl("txt_village") as TextBox;
                    village.BackColor = Color.LightBlue;
                    TextBox cno = crow.FindControl("txt_cno") as TextBox;
                    cno.BackColor = Color.LightBlue;
                    TextBox epa = crow.FindControl("txt_epa") as TextBox;
                    epa.BackColor = Color.LightBlue;
                    TextBox rpn = crow.FindControl("txt_rpn") as TextBox;
                    rpn.BackColor = Color.LightBlue;
                    TextBox pno = crow.FindControl("txt_pn") as TextBox;
                    pno.BackColor = Color.LightBlue;
                    TextBox rpd = crow.FindControl("txt_rpd") as TextBox;
                    rpd.BackColor = Color.LightBlue;
                    TextBox fathername = crow.FindControl("txt_Fathername") as TextBox;
                    fathername.BackColor = Color.LightBlue;
                    
                    TextBox adhar = crow.FindControl("txt_adhar") as TextBox;
                   adhar.BackColor = Color.LightBlue;
                   
                    TextBox bankno = crow.FindControl("txt_bankno") as TextBox;
                    bankno.BackColor = Color.LightBlue;
                    TextBox ifsc = crow.FindControl("txt_ifsc") as TextBox;
                   ifsc.BackColor = Color.LightBlue;
                    TextBox bname = crow.FindControl("txt_bname") as TextBox;
                 bname.BackColor = Color.LightBlue;
                    
                }

            }
        }
        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool c = chkAll.Checked;
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {
                    //to get the dropdown of each line
                    CheckBox chk = (CheckBox)itemEquipment.FindControl("chkSelect");
                    if (c == true)
                    {
                        chk.Checked = true;
                    }
                    else if (c == false)
                    {
                        chk.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                bool mandatoryfalg = false;
                string IPAddress = (string)(Session["IPAddress"]);
                string MacAddress = (string)(Session["MacAddress"]);
                bool Atleastoneselectrow = false;

                //Changeclour();
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {

                    CheckBox chkup = (CheckBox)itemEquipment.FindControl("chkSelect");
                    if (chkup.Checked == true)
                    {
                        

                        TextBox mandal = itemEquipment.FindControl("txt_mandal") as TextBox;
                     
                        TextBox village = itemEquipment.FindControl("txt_village") as TextBox;
                       
                        TextBox cno = itemEquipment.FindControl("txt_cno") as TextBox;
                      
                        TextBox epa = itemEquipment.FindControl("txt_epa") as TextBox;
                       
                        TextBox rpn = itemEquipment.FindControl("txt_rpn") as TextBox;
                       
                        TextBox pno = itemEquipment.FindControl("txt_pn") as TextBox;
                       
                        TextBox rpd = itemEquipment.FindControl("txt_rpd") as TextBox;
                       
                        TextBox fathername = itemEquipment.FindControl("txt_Fathername") as TextBox;


                        TextBox adhar = itemEquipment.FindControl("txt_adhar") as TextBox;
                      

                        TextBox bankno = itemEquipment.FindControl("txt_bankno") as TextBox;
                     
                        TextBox ifsc = itemEquipment.FindControl("txt_ifsc") as TextBox;
                  
                        TextBox bname = itemEquipment.FindControl("txt_bname") as TextBox;
                 
                      
                    }
                }
                if (mandatoryfalg == false)
                {
                    BeneficiaryDetails BeneficiaryDetailsobj = new BeneficiaryDetails();
                    DataTable dtUpdateDetails = new DataTable();
                    dtUpdateDetails.Columns.Add("District_Code");
                    dtUpdateDetails.Columns.Add("District");
                    dtUpdateDetails.Columns.Add("Mandal_Code");
                    dtUpdateDetails.Columns.Add("Mandal");
                    dtUpdateDetails.Columns.Add("Grama_Panchayat_Code");
                    dtUpdateDetails.Columns.Add("Gram_Panchayat");
                    dtUpdateDetails.Columns.Add("Village_Code");
                    dtUpdateDetails.Columns.Add("Village");
                    dtUpdateDetails.Columns.Add("HabitationCode");
                    dtUpdateDetails.Columns.Add("Habitation");
                    dtUpdateDetails.Columns.Add("Forest_DivisionCode");
                    dtUpdateDetails.Columns.Add("Forest_Division");
                    dtUpdateDetails.Columns.Add("Forest_RangeCode");
                    dtUpdateDetails.Columns.Add("Forest_Range");
                    dtUpdateDetails.Columns.Add("Forest_BeatCode");
                    dtUpdateDetails.Columns.Add("Forest_Beat");
                    dtUpdateDetails.Columns.Add("Forest_Block");
                    dtUpdateDetails.Columns.Add("Compartment_No");
                    dtUpdateDetails.Columns.Add("Plot_No");
                    dtUpdateDetails.Columns.Add("ExtentPlotArea");
                    dtUpdateDetails.Columns.Add("Uncultivable_Land");
                    dtUpdateDetails.Columns.Add("Cultivable_Land");
                    dtUpdateDetails.Columns.Add("PATTA_INAMGOVT");
                    dtUpdateDetails.Columns.Add("Water_Tax");
                    dtUpdateDetails.Columns.Add("DRYID_ONECROP_TWO_CROP");
                    dtUpdateDetails.Columns.Add("WATER_SOURCE");
                    dtUpdateDetails.Columns.Add("EXTENT_IRRIGATED");
                    dtUpdateDetails.Columns.Add("ROFR_PATTANO");
                    dtUpdateDetails.Columns.Add("ROFR_PATTADAAR");
                    dtUpdateDetails.Columns.Add("CULTIVATOR_NAME");
                    dtUpdateDetails.Columns.Add("EXTENT_UNDER_CULTIVATOR");
                    dtUpdateDetails.Columns.Add("HOLDING_NATURE");
                    dtUpdateDetails.Columns.Add("TYPE_CODE");
                    dtUpdateDetails.Columns.Add("EXTENT");
                    dtUpdateDetails.Columns.Add("NET_SOWN_AREA");
                    dtUpdateDetails.Columns.Add("KHARIFF_RABI");
                    dtUpdateDetails.Columns.Add("MONTH_OF_CULTIVATION");
                    dtUpdateDetails.Columns.Add("CROP");
                    dtUpdateDetails.Columns.Add("SINGLE");
                    dtUpdateDetails.Columns.Add("MIXED");
                    dtUpdateDetails.Columns.Add("TOTAL");
                    dtUpdateDetails.Columns.Add("WATER_SOURCE1");
                    dtUpdateDetails.Columns.Add("FIRST_CROP");
                    dtUpdateDetails.Columns.Add("SECOND_THIRD_CROP");
                    dtUpdateDetails.Columns.Add("CROP_YIELD");
                    dtUpdateDetails.Columns.Add("VRO_RI_REMARKS");
                    dtUpdateDetails.Columns.Add("TAHSILDAR_REMARKS");
                    dtUpdateDetails.Columns.Add("REMARKS");
                    dtUpdateDetails.Columns.Add("Aadhaar_NO");
                    dtUpdateDetails.Columns.Add("Image");
                    dtUpdateDetails.Columns.Add("Id");
                    dtUpdateDetails.Columns.Add("IPADDRESS");
                    dtUpdateDetails.Columns.Add("MACADDRESS");
                    dtUpdateDetails.Columns.Add("IsEdit");
                    dtUpdateDetails.Columns.Add("IsApproved");
                    dtUpdateDetails.Columns.Add("Status");

                    dtUpdateDetails.Columns.Add("Dlc_date");
                    dtUpdateDetails.Columns.Add("Landclassification");
                    dtUpdateDetails.Columns.Add("BankName");
                    dtUpdateDetails.Columns.Add("BankAccountNo");
                    dtUpdateDetails.Columns.Add("IfscCode");
                    dtUpdateDetails.Columns.Add("Father_Name");
                    dtUpdateDetails.Columns.Add("SUB_CASTE");



                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {
                        //to get the dropdown of each line
                        CheckBox chk = (CheckBox)itemEquipment.FindControl("chkSelect");
                        //  chk.Attributes.Add("style", "background-color:Green;");
                        if (chk.Checked == true)
                        {
                            bool edit = true;
                            bool isapproved = false;
                            Label id = itemEquipment.FindControl("lbl_id") as Label;
                            Atleastoneselectrow = true;

                            TextBox mandal = itemEquipment.FindControl("txt_mandal") as TextBox;

                            TextBox village = itemEquipment.FindControl("txt_village") as TextBox;

                            TextBox cno = itemEquipment.FindControl("txt_cno") as TextBox;

                            TextBox epa = itemEquipment.FindControl("txt_epa") as TextBox;

                            TextBox rpn = itemEquipment.FindControl("txt_rpn") as TextBox;

                            TextBox pno = itemEquipment.FindControl("txt_pn") as TextBox;

                            TextBox rpd = itemEquipment.FindControl("txt_rpd") as TextBox;

                            TextBox fathername = itemEquipment.FindControl("txt_Fathername") as TextBox;


                            TextBox adhar = itemEquipment.FindControl("txt_adhar") as TextBox;


                            TextBox bankno = itemEquipment.FindControl("txt_bankno") as TextBox;

                            TextBox ifsc = itemEquipment.FindControl("txt_ifsc") as TextBox;

                            TextBox bname = itemEquipment.FindControl("txt_bname") as TextBox;



                            DataRow dr = dtUpdateDetails.NewRow();
                      
                            dr["Mandal"] = mandal.Text;
                          
                            dr["Village"] =village.Text;
                             dr["Compartment_No"] = cno.Text;
                            dr["Plot_No"] = pno.Text;
                            dr["ExtentPlotArea"] = epa.Text;
                          
                            dr["ROFR_PATTANO"] = rpn.Text;
                            dr["ROFR_PATTADAAR"] = rpd.Text;

                            dr["Father_Name"] = fathername.Text;

                            dr["Aadhaar_NO"] = adhar.Text;
                            
                            dr["BankName"] = bname.Text;
                            dr["BankAccountNo"] = bankno.Text;
                            dr["IfscCode"] = ifsc.Text;
                            dr["Id"] = id.Text;
                            dr["IsEdit"] = edit;

                            dr["IPADDRESS"] = IPAddress;
                            dr["MACADDRESS"] = MacAddress;


                            dtUpdateDetails.Rows.Add(dr);

                        }
                        else if (chk.Checked == false)
                        {

                        }




                    }
                    BeneficiaryDetailsobj.UpdateForestMasterDetails = dtUpdateDetails;
                    if (Atleastoneselectrow == true)
                    {
                        if (!string.IsNullOrEmpty((string)(Session["username"])))
                        {
                            ProjectRofrBAL.GetMasterDetails.UpdateRtgsFormatData(BeneficiaryDetailsobj, (string)(Session["username"]));
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficiary Details Updated Successfully')", true);
                            if (ddl_ITda.SelectedItem.Text != "Select" && ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_village.SelectedItem.Text != "Select" && ddl_valid.SelectedItem.Text != "Select" && ddl_type.SelectedItem.Text != "Select")
                            {
                                DataTable dt = Landsettlementpattas.GetRtgs_FormatData(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, ddl_valid.SelectedItem.Text, ddl_type.SelectedItem.Text);



                                if (dt.Rows.Count > 0)
                                {
                                    Repeater1.DataSource = dt;

                                    Repeater1.DataBind();

                                    chkAll.Visible = true;
                                    btn_submit.Visible = true; ;
                                }

                               
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('please Select Records!')", true);
                        Atleastoneselectrow = false;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter mandatory fields for all checked records!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        public DataTable searchBindData(string Itda, string district, string mandal, string village,string status,string type)
        {
            DataTable dt = new DataTable();
            try
            {
                

                Repeater1.DataSource = null;

                Repeater1.DataBind();


                dt = Landsettlementpattas.GetRtgs_FormatData(Itda, district,   mandal, village,status,type);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return dt;
        }
        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtbeneficiareies = new DataTable();
                dtbeneficiareies = searchBindData(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, ddl_valid.SelectedItem.Text, ddl_type.SelectedItem.Text);
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format("ROFR_PATTADAAR LIKE '%{0}%'", txtSearch.Text);
                    Repeater1.DataSource = DV;

                    Repeater1.DataBind();
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
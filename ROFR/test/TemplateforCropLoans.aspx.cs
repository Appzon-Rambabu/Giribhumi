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

namespace ROFR.test
{
    public partial class TemplateforCropLoans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    BindItda();
                    // BindDistrict();
                    select_records.Visible = false;

                   
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    //LinkButton btn = (LinkButton)(sender);

                    //btn.Attributes.Add("data-toggle", "modal");
                    //btn.Attributes.Add("data-target", "#exampleModal");
                    file_dlc.Attributes.Add("onchange", "return dlcfile(this,'" + file_dlc.ClientID + "');");
                    file_sdlc.Attributes.Add("onchange", "return sdlcfile(this,'" + file_sdlc.ClientID + "');");
                    file_gp.Attributes.Add("onchange", "return gpfile(this,'" + file_gp.ClientID + "');");
                    file_pbook.Attributes.Add("onchange", "return pbookfile(this,'" + file_pbook.ClientID + "');");
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
                ddl_records.Items.Clear();
                Repeater1.DataSource = null;
                Repeater1.DataBind();
               
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
                ddl_mandal.Items.Clear();
               
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_records.Items.Clear();
                Repeater1.DataSource = null;
                Repeater1.DataBind();

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
                ddl_records.Items.Clear();
                Repeater1.DataSource = null;
                Repeater1.DataBind();

                if (ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select")
                {

                    Repeater1.DataSource = null;

                    Repeater1.DataBind();
              
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                   
                    select_records.Visible = false;
                    BindCount(ddl_district.SelectedItem.Text, true, "", ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
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
        protected void BindData(string district, string Itda, string mandal)
        {
            try
            {
                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);

                Repeater1.DataSource = null;

                Repeater1.DataBind();
                DataTable dt = Landsettlementpattas.GetCropLoanData(district, start, end, Itda, mandal);

               

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();

                    ViewState["Data"] = dt;
                    Session["Data"] = dt;


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void ddlrecords_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    if (ddl_records.SelectedValue != "0")
                    {
                        BindData(ddl_district.SelectedItem.Text, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
                      //  panlimage.Visible = true;
                       // btn_submit.Visible = true;
                      
                    }
                    else
                    {
                        Repeater1.DataSource = null;

                        Repeater1.DataBind();
                     
                      // panlimage.Visible = false;
                       // btn_submit.Visible = false;
                      

                        //Panel_Uploaddlc.Visible = false;

                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        public void BindCount(string district, bool FLAG, string VALUE, string Itda, string mandal)
        {
            try
            {
                string recordvalue = string.Empty;

                Repeater1.DataSource = null;

                Repeater1.DataBind();
              

                DataTable dt = Landsettlementpattas.GetCropLoanDataCount(district, Itda, mandal);

                if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                    {
                        select_records.Visible = true;
                        ListItemCollection list = new ListItemCollection();
                        int rowscount = Convert.ToInt32(dt.Rows[0]["count"].ToString());
                        string k = string.Empty;
                        for (int i = 1; i <= rowscount; i++)
                        {
                            if (rowscount <= 100)
                            {
                                int j = i + (rowscount - 1);
                                k = i + "-" + j;
                                list.Add(new ListItem(k));
                                i = j;
                            }
                            else
                            {
                                int remainingrows = rowscount - i;
                                if (remainingrows > 100)
                                {
                                    int j = i + 99;
                                    k = i + "-" + j;
                                    if (FLAG == false)
                                    {
                                        if (VALUE == k)
                                        {
                                            recordvalue = k;
                                        }
                                    }
                                    list.Add(new ListItem(k));
                                    i = j;
                                }
                                else
                                {
                                    int j = (i) + remainingrows;
                                    k = i + "-" + j;
                                    list.Add(new ListItem(k));
                                    i = j;
                                    break;
                                }
                            }
                        }
                        ddl_records.DataSource = list;
                        ddl_records.DataBind();
                        if (FLAG == true)
                        {
                            ddl_records.Items.Insert(0, new ListItem("Select", "0"));
                        }
                        else
                        {
                            ddl_records.Items.Insert(0, new ListItem("Select", "0"));
                            if (recordvalue != string.Empty)
                            {
                                ddl_records.SelectedValue = recordvalue;
                            }
                            else
                            {
                                ddl_records.SelectedValue = k;
                            }

                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('No Data Found')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

    

        public DataTable searchBindData(string district, string Itda, string mandal)
        {
            DataTable dt = new DataTable();
            try
            {
                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);

                Repeater1.DataSource = null;

                Repeater1.DataBind();


                dt = Landsettlementpattas.GetCropLoanData(district, start, end, Itda, mandal);

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
               dtbeneficiareies = searchBindData(ddl_district.SelectedItem.Text, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format("ROFR_PATTADAAR LIKE '%{0}%'", txtSearch.Text);
                    if (DV.Count != 0)
                    {
                        Repeater1.DataSource = DV;

                        Repeater1.DataBind();
                    }
                    else
                    {
                        addsinglerow();
                    }
                }
             }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
   

    

  
        protected void Checkselect_CheckedChanged(object sender, EventArgs e)
        {

            try

            {
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    CheckBox btn = (CheckBox)item.FindControl("chkSelect");

                  

                    if (btn.Checked==true)
                {
                        Label rid = item.FindControl("lblrid") as Label;
                       // Label rid = (Label)(sender);
                    //string Id = btn.CommandArgument;
                    int Id = int.Parse(rid.Text);
                    // DataTable dt = (DataTable)ViewState["Data"];
                    DataTable dt = (DataTable)Session["Data"];
                    IEnumerable<DataRow> query = from j in dt.AsEnumerable()
                                                 where j.Field<int>("Id").Equals(Id)
                                                 select j;
                    DataTable dtrecords = query.CopyToDataTable<DataRow>();

                    txt_mid.Text = dtrecords.Rows[0]["id"].ToString();
                    txt_mid1.Text = dtrecords.Rows[0]["croploan_id"].ToString();
                    //txt_mid1.Text = dtrecords.Rows[0]["id"].ToString();
                    txt_dist.Text = dtrecords.Rows[0]["District"].ToString();
                    txt_pattano.Text = dtrecords.Rows[0]["ROFR_PATTANO"].ToString();
                    txt_adhar.Text = dtrecords.Rows[0]["Aadhaar_NO"].ToString();
                    txt_bname.Text = dtrecords.Rows[0]["BankName"].ToString();
                    txt_ifsc_code.Text = dtrecords.Rows[0]["IfscCode"].ToString();
                    txt_gpt.Text = dtrecords.Rows[0]["Gram_Panchayat"].ToString();
                    txt_hb.Text = dtrecords.Rows[0]["Habitation"].ToString();
                    txt_fr.Text = dtrecords.Rows[0]["Forest_Range"].ToString();
                    txt_fb.Text = dtrecords.Rows[0]["Forest_Block"].ToString();
                    txt_epa.Text = dtrecords.Rows[0]["extentplotarea"].ToString();
                    txt_pname.Text = dtrecords.Rows[0]["ROFR_PATTADAAR"].ToString();
                    txt_fname.Text = dtrecords.Rows[0]["Father_Name"].ToString();
                    txt_accno.Text = dtrecords.Rows[0]["BankAccountNo"].ToString();
                    txt_mdl.Text = dtrecords.Rows[0]["Mandal"].ToString();
                    txt_vlg.Text = dtrecords.Rows[0]["Village"].ToString();
                    txt_fd.Text = dtrecords.Rows[0]["Forest_Division"].ToString();
                    txt_fbeat.Text = dtrecords.Rows[0]["Forest_Beat"].ToString();
                    txt_cmno.Text = dtrecords.Rows[0]["Compartment_No"].ToString();
                        txt_revillage.Text = dtrecords.Rows[0]["REV_Village"].ToString();
                        txt_ext.Text = dtrecords.Rows[0]["EXTENT"].ToString();
                        txt_epa.Text = dtrecords.Rows[0]["extentplotarea"].ToString();
                        txt_tepa.Text = dtrecords.Rows[0]["total_extentplotarea"].ToString();
                    //btn.Attributes.Add("data-toggle", "modal");
                    //btn.Attributes.Add("data-target", "#exampleModal");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() {openModal(); });", true);
                    }
                  
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }




        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            
           
        }

        protected void mbtn_click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtUploadFiles = new DataTable();
                dtUploadFiles.Columns.Add("Option1");
                dtUploadFiles.Columns.Add("Option2");
                dtUploadFiles.Columns.Add("Option3");
                dtUploadFiles.Columns.Add("Option4");
                dtUploadFiles.Columns.Add("Option5");
                dtUploadFiles.Columns.Add("Option6");
                dtUploadFiles.Columns.Add("Option7");

                bool edit = true;
            BeneficiaryDetails BeneficiaryDetailsobj = new BeneficiaryDetails();
            DataTable dtUpdateDetails = new DataTable();
            dtUpdateDetails.Columns.Add("District_Code");
            dtUpdateDetails.Columns.Add("District");
            dtUpdateDetails.Columns.Add("ROFR_PATTANO");
            dtUpdateDetails.Columns.Add("ROFR_PATTADAAR");
            dtUpdateDetails.Columns.Add("Aadhaar_NO");
            dtUpdateDetails.Columns.Add("FATHER_NAME");
            dtUpdateDetails.Columns.Add("BankName");
            dtUpdateDetails.Columns.Add("BankAccountNo");
            dtUpdateDetails.Columns.Add("IfscCode");
            //dtUpdateDetails.Columns.Add("UPLOADFILES");
            dtUpdateDetails.Columns.Add("Mandal_Code");
            dtUpdateDetails.Columns.Add("Mandal");

            dtUpdateDetails.Columns.Add("Gram_Panchayat");
            dtUpdateDetails.Columns.Add("Village_Code");
            dtUpdateDetails.Columns.Add("Village");

            dtUpdateDetails.Columns.Add("Habitation");
            dtUpdateDetails.Columns.Add("ForestDivision");
            dtUpdateDetails.Columns.Add("ForestDivisionCode");
            dtUpdateDetails.Columns.Add("ForestRange");
            dtUpdateDetails.Columns.Add("ForestRangeCode");
            dtUpdateDetails.Columns.Add("ForestBeat");
            dtUpdateDetails.Columns.Add("ForestBeatCode");
            dtUpdateDetails.Columns.Add("ForestBlock");

            dtUpdateDetails.Columns.Add("Compartment_No");

            dtUpdateDetails.Columns.Add("ExtentPlotArea");
            dtUpdateDetails.Columns.Add("TotalExtentPlotArea");

            dtUpdateDetails.Columns.Add("Id");
            dtUpdateDetails.Columns.Add("IPADDRESS");
            dtUpdateDetails.Columns.Add("MACADDRESS");
            dtUpdateDetails.Columns.Add("IsEdit");
            dtUpdateDetails.Columns.Add("IsApproved");
            dtUpdateDetails.Columns.Add("Status");
                dtUpdateDetails.Columns.Add("Extent");
                dtUpdateDetails.Columns.Add("REVVILLAGE");
                DataRow dr = dtUpdateDetails.NewRow();
            //dr["District_Code"]="";
            dr["District"] = txt_dist.Text;
            dr["ROFR_PATTANO"] = txt_pattano.Text;
            dr["ROFR_PATTADAAR"] = txt_pname.Text;
            dr["Aadhaar_NO"] = txt_adhar.Text;
            dr["FATHER_NAME"] = txt_fname.Text;
            dr["BankName"] =txt_bname.Text;
            dr["BankAccountNo"] = txt_accno.Text;
            dr["IfscCode"] = txt_ifsc_code.Text;
            //dr["UPLOADFILES"]="";
            //dr["Mandal_Code"]="";
            dr["Mandal"] =txt_mdl.Text;

            dr["Gram_Panchayat"] = txt_gpt.Text;
            //dr["Village_Code"]="";
            dr["Village"] = txt_vlg.Text;

            dr["Habitation"] = txt_hb.Text;
            dr["ForestDivision"] = txt_fd.Text;
            //dr["ForestDivisionCode"]="";
            dr["ForestRange"] = txt_fr.Text;
            //dr["ForestRangeCode"]="";
            dr["ForestBeat"] = txt_fd.Text;
            //dr["ForestBeatCode"]="";
            dr["ForestBlock"] = txt_fb.Text;

            dr["Compartment_No"] = txt_cmno.Text;

            dr["ExtentPlotArea"] = txt_epa.Text;
            dr["TotalExtentPlotArea"] = txt_tepa.Text;
           
            dr["Id"] = txt_mid.Text;
            dr["IPADDRESS"] = (string)(Session["IPAddress"]);
            dr["MACADDRESS"] = (string)(Session["MacAddress"]);
            dr["IsEdit"] = edit;
            dr["IsApproved"] = "";
            dr["Status"] = "U";
                dr["Extent"] = txt_ext.Text;
                dr["REVVILLAGE"] = txt_revillage.Text;

                dtUpdateDetails.Rows.Add(dr);
               
                if (file_dlc.HasFile == true)
                {
                    try
                    {
                        //Get The File Extension  
                        string filetype = Path.GetExtension(file_dlc.PostedFile.FileName);
                        if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
                        {

                            double filesize = file_dlc.PostedFile.ContentLength;

                            string serverfolder = string.Empty;
                            string serverpath = string.Empty;

                            switch (filetype)
                            {
                                case ".pdf":
                                    serverfolder = Server.MapPath("~/BENEFICIARYCROPLOAN/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "DLC" + "/" + txt_mid.Text + "/");



                                    if (!Directory.Exists(serverfolder))
                                    {
                                        // create Folder  
                                        Directory.CreateDirectory(serverfolder);
                                    }
                                    if (file_dlc.PostedFile.ContentLength == filesize)
                                    {

                                        serverpath = serverfolder + Path.GetFileName(file_dlc.PostedFile.FileName);
                                        file_dlc.PostedFile.SaveAs(serverpath);
                                    }

                                    break;
                                case ".jpg":
                                case ".jpeg":
                                    // serverfolder = Server.MapPath(@"uplaodfiles\document\");
                                    serverfolder = Server.MapPath("~/BENEFICIARYCROPLOAN/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "DLC" + "/" + txt_mid.Text + "/");

                                    if (!Directory.Exists(serverfolder))
                                    {
                                        Directory.CreateDirectory(serverfolder);
                                    }
                                    if (file_dlc.PostedFile.ContentLength == filesize)
                                    {


                                        serverpath = serverfolder + Path.GetFileName(file_dlc.PostedFile.FileName);
                                        file_dlc.PostedFile.SaveAs(serverpath);
                                    }
                                    //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
                                    break;

                            }
                            DataRow dr1 = dtUploadFiles.NewRow();
                            dr1["Option1"] = txt_mid.Text;
                            dr1["Option2"] = serverfolder;
                            dr1["Option3"] = file_dlc.PostedFile.FileName;
                            dr1["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr1["Option5"] = "DLC";
                            dr1["Option6"] = (string)(Session["IPAddress"]);
                            dr1["Option7"]= (string)(Session["username"]);
                            dtUploadFiles.Rows.Add(dr1);

                        }



                    }




                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' DLC Documents Location Created Error !')", true);
                        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                    }

                }
                // sdlc


                if (file_sdlc.HasFile == true)
                {
                    try
                    {
                        //Get The File Extension  
                        string filetype = Path.GetExtension(file_sdlc.PostedFile.FileName);
                        if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
                        {

                            double filesize = file_sdlc.PostedFile.ContentLength;

                            string serverfolder = string.Empty;
                            string serverpath = string.Empty;

                            switch (filetype)
                            {
                                case ".pdf":
                                    serverfolder = Server.MapPath("~/BENEFICIARYCROPLOAN/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "SDLC" + "/" + txt_mid.Text + "/");



                                    if (!Directory.Exists(serverfolder))
                                    {
                                        // create Folder  
                                        Directory.CreateDirectory(serverfolder);
                                    }
                                    if (file_sdlc.PostedFile.ContentLength == filesize)
                                    {

                                        serverpath = serverfolder + Path.GetFileName(file_sdlc.PostedFile.FileName);
                                        file_sdlc.PostedFile.SaveAs(serverpath);
                                    }

                                    break;
                                case ".jpg":
                                case ".jpeg":
                                    // serverfolder = Server.MapPath(@"uplaodfiles\document\");
                                    serverfolder = Server.MapPath("~/BENEFICIARYCROPLOAN/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "SDLC" + "/" + txt_mid.Text + "/");

                                    if (!Directory.Exists(serverfolder))
                                    {
                                        Directory.CreateDirectory(serverfolder);
                                    }
                                    if (file_sdlc.PostedFile.ContentLength == filesize)
                                    {


                                        serverpath = serverfolder + Path.GetFileName(file_sdlc.PostedFile.FileName);
                                        file_sdlc.PostedFile.SaveAs(serverpath);
                                    }
                                    //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
                                    break;

                            }
                            DataRow dr2 = dtUploadFiles.NewRow();
                            dr2["Option1"] = txt_mid.Text;
                            dr2["Option2"] = serverfolder;
                            dr2["Option3"] = file_sdlc.PostedFile.FileName;
                            dr2["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr2["Option5"] = "SDLC";
                            dr2["Option6"] = (string)(Session["IPAddress"]);
                            dr2["Option7"] = (string)(Session["username"]);
                            dtUploadFiles.Rows.Add(dr2);

                        }



                    }




                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' SDLC Documents Location Created Error !')", true);
                        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                    }

                }
                //gpresolution

                if (file_gp.HasFile == true)
                {
                    try
                    {
                        //Get The File Extension  
                        string filetype = Path.GetExtension(file_gp.PostedFile.FileName);
                        if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
                        {

                            double filesize = file_gp.PostedFile.ContentLength;

                            string serverfolder = string.Empty;
                            string serverpath = string.Empty;

                            switch (filetype)
                            {
                                case ".pdf":
                                    serverfolder = Server.MapPath("~/BENEFICIARYCROPLOAN/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "GPRESOLUTION" + "/" + txt_mid.Text + "/");



                                    if (!Directory.Exists(serverfolder))
                                    {
                                        // create Folder  
                                        Directory.CreateDirectory(serverfolder);
                                    }
                                    if (file_gp.PostedFile.ContentLength == filesize)
                                    {

                                        serverpath = serverfolder + Path.GetFileName(file_gp.PostedFile.FileName);
                                        file_gp.PostedFile.SaveAs(serverpath);
                                    }

                                    break;
                                case ".jpg":
                                case ".jpeg":
                                    // serverfolder = Server.MapPath(@"uplaodfiles\document\");
                                    serverfolder = Server.MapPath("~/BENEFICIARYCROPLOAN/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "GPRESOLUTION" + "/" + txt_mid.Text + "/");

                                    if (!Directory.Exists(serverfolder))
                                    {
                                        Directory.CreateDirectory(serverfolder);
                                    }
                                    if (file_gp.PostedFile.ContentLength == filesize)
                                    {


                                        serverpath = serverfolder + Path.GetFileName(file_gp.PostedFile.FileName);
                                        file_gp.PostedFile.SaveAs(serverpath);
                                    }
                                    //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
                                    break;

                            }
                            DataRow dr3 = dtUploadFiles.NewRow();
                            dr3["Option1"] = txt_mid.Text;
                            dr3["Option2"] = serverfolder;
                            dr3["Option3"] = file_gp.PostedFile.FileName;
                            dr3["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr3["Option5"] = "GPRESOLUTION";
                            dr3["Option6"] = (string)(Session["IPAddress"]);
                            dr3["Option7"] = (string)(Session["username"]);
                            dtUploadFiles.Rows.Add(dr3);

                        }



                    }




                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Gp resolution Documents Location Created Error !')", true);
                        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                    }

                }
                //ROFRPASSBOOK

                if (file_pbook.HasFile == true)
                {
                    try
                    {
                        //Get The File Extension  
                        string filetype = Path.GetExtension(file_pbook.PostedFile.FileName);
                        if (filetype.ToLower() == ".pdf" || filetype.ToLower() == ".jpeg" || filetype.ToLower() == ".jpg")
                        {

                            double filesize = file_pbook.PostedFile.ContentLength;

                            string serverfolder = string.Empty;
                            string serverpath = string.Empty;

                            switch (filetype)
                            {
                                case ".pdf":
                                    serverfolder = Server.MapPath("~/BENEFICIARYCROPLOAN/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "ROFRPATTABOOK" + "/" + txt_mid.Text + "/");



                                    if (!Directory.Exists(serverfolder))
                                    {
                                        // create Folder  
                                        Directory.CreateDirectory(serverfolder);
                                    }
                                    if (file_pbook.PostedFile.ContentLength == filesize)
                                    {

                                        serverpath = serverfolder + Path.GetFileName(file_pbook.PostedFile.FileName);
                                        file_pbook.PostedFile.SaveAs(serverpath);
                                    }

                                    break;
                                case ".jpg":
                                case ".jpeg":
                                    // serverfolder = Server.MapPath(@"uplaodfiles\document\");
                                    serverfolder = Server.MapPath("~/BENEFICIARYCROPLOAN/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + "ROFRPATTABOOK" + "/" + txt_mid.Text + "/");

                                    if (!Directory.Exists(serverfolder))
                                    {
                                        Directory.CreateDirectory(serverfolder);
                                    }
                                    if (file_pbook.PostedFile.ContentLength == filesize)
                                    {


                                        serverpath = serverfolder + Path.GetFileName(file_pbook.PostedFile.FileName);
                                        file_pbook.PostedFile.SaveAs(serverpath);
                                    }
                                    //label1.Text += "[" + postfiles.FileName + "]- document file uploaded  successfully<br/>";
                                    break;

                            }
                            DataRow dr4 = dtUploadFiles.NewRow();
                            dr4["Option1"] = txt_mid.Text;
                            dr4["Option2"] = serverfolder;
                            dr4["Option3"] = file_pbook.PostedFile.FileName;
                            dr4["Option4"] = DateTime.Now.ToString("dd-MM-yyyy");
                            dr4["Option5"] = "ROFRPATTABOOK";
                            dr4["Option6"] = (string)(Session["IPAddress"]);
                            dr4["Option7"] = (string)(Session["username"]);
                            dtUploadFiles.Rows.Add(dr4);

                        }



                    }




                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' ROFR Patta Book Documents Location Created Error !')", true);
                        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                    }

                }

                if (!string.IsNullOrEmpty((string)(Session["username"])))
                    {
                    if (!string.IsNullOrEmpty(txt_cmno.Text))
                    {
                        BeneficiaryDetailsobj.UpdateForestMasterDetails = dtUpdateDetails;

                        if (dtUpdateDetails.Rows.Count>0)
                        {
                        ProjectRofrBAL.GetMasterDetails.UpdateCropLoan(BeneficiaryDetailsobj, (string)(Session["username"]));
                            BindData(ddl_district.SelectedItem.Text, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficiary Details Updated Successfully')", true);
                        }
                        BeneficiaryDetailsobj.UpdateForestMasterDetails = dtUploadFiles;
                        if (dtUploadFiles.Rows.Count > 0)
                        {
                            ProjectRofrBAL.GetMasterDetails.CropLoanFiles(BeneficiaryDetailsobj);

                        }
                       // BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
                    }
                    else
                    {
                        foreach (RepeaterItem item in Repeater1.Items)
                        {
                            CheckBox btn = (CheckBox)item.FindControl("chkSelect");

                            //LinkButton btn = (LinkButton)(sender);

                            if (btn.Checked == true)
                            {
                                btn.Checked = false;
                            }
                        }
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please enter compartment no!')", true);
                    }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void Close_Click(object sender, ImageClickEventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox btn = (CheckBox)item.FindControl("chkSelect");

                //LinkButton btn = (LinkButton)(sender);

                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }

        public void addsinglerow()
        {
            DataTable dtsinglerow = new DataTable();
            dtsinglerow.Columns.Add("croploan_id");
            dtsinglerow.Columns.Add("id");
            dtsinglerow.Columns.Add("District");
            dtsinglerow.Columns.Add("ROFR_PATTANO");
            dtsinglerow.Columns.Add("ROFR_PATTADAAR");

            dtsinglerow.Columns.Add("EXTENT");
            dtsinglerow.Columns.Add("Aadhaar_NO");
            dtsinglerow.Columns.Add("Father_Name");
            dtsinglerow.Columns.Add("BankName");
            dtsinglerow.Columns.Add("BankAccountNo");

            dtsinglerow.Columns.Add("IfscCode");
            dtsinglerow.Columns.Add("Dlcpath");
            dtsinglerow.Columns.Add("Mandal");
            dtsinglerow.Columns.Add("Gram_Panchayat");
            dtsinglerow.Columns.Add("Village");

            dtsinglerow.Columns.Add("Habitation");
            dtsinglerow.Columns.Add("REV_Village");
            dtsinglerow.Columns.Add("Forest_Division");
            dtsinglerow.Columns.Add("Forest_Range");
            dtsinglerow.Columns.Add("Forest_Beat");

            dtsinglerow.Columns.Add("Forest_Block");
            dtsinglerow.Columns.Add("Compartment_No");
            dtsinglerow.Columns.Add("extentplotarea");
            dtsinglerow.Columns.Add("total_extentplotarea");
            System.Data.DataRow dr = dtsinglerow.NewRow();
            dr["croploan_id"] = "";
            dr["id"] = "";
            dr["District"] = "";
            dr["ROFR_PATTANO"] = "";
            dr["ROFR_PATTADAAR"] = "";
            dr["EXTENT"] = "";
            dr["Aadhaar_NO"] = "";
            dr["Father_Name"] = "";
            dr["BankName"] = "";
            dr["BankAccountNo"] = "";
            dr["IfscCode"] = "";
            dr["Dlcpath"] = "";
            dr["Mandal"] = "";
            dr["Gram_Panchayat"] = "";
            dr["Village"] = "";
            dr["Habitation"] = "";
            dr["REV_Village"] = "";
            dr["Forest_Division"] = "";
            dr["Forest_Range"] = "";
            dr["Forest_Beat"] = "";
            dr["Forest_Block"] = "";
            dr["Compartment_No"] = "";
            dr["extentplotarea"] = "";
            dr["total_extentplotarea"] = "";
            dtsinglerow.Rows.Add(dr);
            Repeater1.DataSource = dtsinglerow;

            Repeater1.DataBind();
        }

    }
}
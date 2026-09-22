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

namespace ROFR.pages
{
    public partial class ROFR_BeneficiariesDetailsChecker : System.Web.UI.Page
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
                    // BindDistrict();
                    select_records.Visible = false;
                    btn_submit.Visible = false;
                    lblnote.Visible = false;
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                    panlimage.Visible = false;
                    chkAll.Visible = false;
                    btn_Image.Visible = false;
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));

                    file_dlc.Attributes.Add("onchange", "return file(this,'" + file_dlc.ClientID + "');");

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
                DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdadetails((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_NAME";
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
                ddl_district.DataValueField = "DISTRICT_CODE";
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
                ddl_mandal.DataValueField = "MANDAL_NAME";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_mandal.Items.Insert(1, new ListItem("NULL", "1"));
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
                ddl_village.DataValueField = "VILLAGE_NAME";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Insert(1, new ListItem("NULL", "1"));
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
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                    ddl_district.ClearSelection();
                    Repeater1.DataBind();
                    btn_submit.Visible = false;
                    lblnote.Visible = false;
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                    panlimage.Visible = false;
                    btn_Image.Visible = false;
                    chkAll.Visible = false;
                    select_records.Visible = false;
                    DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindDistrict(dtMandal);
                        if (dtMandal.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            ddl_mandal.ClearSelection();
                            ddl_village.ClearSelection();
                            Repeater1.DataSource = null;

                            Repeater1.DataBind();
                            btn_submit.Visible = false;
                            lblnote.Visible = false;
                            //Panel_Image.Visible = false;
                            //Panel_Uploaddlc.Visible = false;
                            panlimage.Visible = false;
                            btn_Image.Visible = false;
                            chkAll.Visible = false;
                            select_records.Visible = false;
                            DataTable dtMandal1 = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenmandalDetails(ddl_district.SelectedValue, (string)(Session["username"]));
                            if (dtMandal1.Rows.Count > 0)
                            {
                                BindMandal(dtMandal1);
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
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    if (ddl_district.SelectedValue != "0")
                    {
                        if (ddl_ITda.SelectedItem.Text != "Select")
                        {
                            if (ddl_ITda.SelectedValue != "0")
                            {
                                ddl_mandal.ClearSelection();
                                ddl_village.ClearSelection();
                                Repeater1.DataSource = null;

                                Repeater1.DataBind();
                                btn_submit.Visible = false;
                                lblnote.Visible = false;
                                //Panel_Image.Visible = false;
                                //Panel_Uploaddlc.Visible = false;
                                panlimage.Visible = false;
                                btn_Image.Visible = false;
                                chkAll.Visible = false;
                                select_records.Visible = false;
                                DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenmandalDetails(ddl_district.SelectedValue, (string)(Session["username"]));
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

                    Repeater1.DataSource = null;

                    Repeater1.DataBind();
                    btn_submit.Visible = false;
                    lblnote.Visible = false;
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                    panlimage.Visible = false;
                    btn_Image.Visible = false;
                    chkAll.Visible = false;
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
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    DataTable dtVillages = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenvillageDetails(ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, (string)(Session["username"]));
                    if (dtVillages.Rows.Count > 0)
                    {
                        Repeater1.DataSource = null;
                        //ddl_mandal.ClearSelection();
                        ddl_village.ClearSelection();
                        Repeater1.DataBind();
                        btn_submit.Visible = false;
                        lblnote.Visible = false;
                        //Panel_Image.Visible = false;
                        //Panel_Uploaddlc.Visible = false;
                        panlimage.Visible = false;
                        btn_Image.Visible = false;
                        chkAll.Visible = false;
                        select_records.Visible = false;
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
                if (ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select")
                {

                    Repeater1.DataSource = null;

                    Repeater1.DataBind();
                    btn_submit.Visible = false;
                    lblnote.Visible = false;
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                    panlimage.Visible = false;
                    btn_Image.Visible = false;
                    chkAll.Visible = false;
                    select_records.Visible = false;
                    BindCount(ddl_district.SelectedValue, true, "", ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
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



        protected void BindData(string district, string Itda, string mandal, string village)
        {
            try
            {
                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);

                Repeater1.DataSource = null;

                Repeater1.DataBind();


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal, village);

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();

                    btn_submit.Visible = true;
                    lblnote.Visible = true;
                    lblnote.Text = "Note: Please Enter All Mandatory Fields(*)";
                    panlimage.Visible = true;
                    btn_Image.Visible = true;
                    chkAll.Visible = true;
                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {
                        Label id = itemEquipment.FindControl("Label4") as Label;
                        id.Visible = false;
                        Label Dlc = itemEquipment.FindControl("txtDlc") as Label;
                        Dlc.Visible = false;
                        Label image = itemEquipment.FindControl("txtimage") as Label;
                        image.Visible = false;
                        if (!string.IsNullOrEmpty(Dlc.Text))
                        {
                            LinkButton ibutton = itemEquipment.FindControl("view_file") as LinkButton;
                            ibutton.Visible = true;
                        }
                        else
                        {
                            LinkButton ibutton1 = itemEquipment.FindControl("view_file") as LinkButton;
                            ibutton1.Visible = false;
                        }

                        if (!string.IsNullOrEmpty(image.Text))
                        {
                            LinkButton ibutton = itemEquipment.FindControl("View_image") as LinkButton;
                            ibutton.Visible = true;
                        }
                        else
                        {
                            LinkButton ibutton1 = itemEquipment.FindControl("View_image") as LinkButton;
                            ibutton1.Visible = false;
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

        protected void ddlrecords_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    if (ddl_records.SelectedValue != "0")
                    {
                        BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                    }
                    else
                    {
                        Repeater1.DataSource = null;

                        Repeater1.DataBind();
                        btn_submit.Visible = false;
                        lblnote.Visible = false;
                        //Panel_Image.Visible = false;
                        //Panel_Uploaddlc.Visible = false;
                        panlimage.Visible = false;
                        btn_Image.Visible = false;
                        chkAll.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        public void BindCount(string district, bool FLAG, string VALUE, string Itda, string mandal, string village)
        {
            try
            {
                string recordvalue = string.Empty;

                Repeater1.DataSource = null;

                Repeater1.DataBind();


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiaryDetailscountValidate(district, Itda, mandal, village);

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
        protected void btn_Image1_Click(object sender, EventArgs e)
        {
            try
            {
                bool MANDA = false;
                bool errorflag = false;
                bool multiflag = false;
                string multistring = string.Empty;
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {

                    CheckBox chkup = (CheckBox)itemEquipment.FindControl("Update_dlc");
                    if (chkup.Checked == true)
                    {
                        TextBox CNO = itemEquipment.FindControl("txt_dlcdate") as TextBox;
                        if (CNO.Text == "")
                        {
                            MANDA = false;
                            break;
                        }
                    }
                }
                if (MANDA == false)
                {
                    Byte[] bytes = new byte[] { };
                    HttpPostedFile dlc = file_dlc.PostedFile;
                    string dlcpath = file_dlc.PostedFile.FileName;
                                    string dlcname = Path.GetFileName(dlcpath);
                    string ext = Path.GetExtension(dlcname);
                    string jpgext = Path.GetExtension(dlcname);
                    string type = string.Empty;
                    string type1 = string.Empty;
                    addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();
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
                            int length = file_dlc.PostedFile.ContentLength;
                            byte[] imgbyte = new byte[] { };
                            imgbyte = new byte[length];

                            HttpPostedFile image = file_dlc.PostedFile;

                            image.InputStream.Read(imgbyte, 0, length);
                            string imagename = file_dlc.PostedFile.FileName;
                            bytes = imgbyte;
                        }
                    }

                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {

                        CheckBox chkup = (CheckBox)itemEquipment.FindControl("Update_dlc");

                        if (chkup.Checked == true)
                        {

                            Label dlcid = itemEquipment.FindControl("Label4") as Label;
                            TextBox CNO = itemEquipment.FindControl("txt_RPD") as TextBox;
                            string Iddlc = dlcid.Text;
                            string Compartmentno1 = CNO.Text;




                            string compartmentno = Compartmentno1;
                            // compartmentno = compartmentno.Replace(" ", string.Empty);
                            // compartmentno = compartmentno + Iddlc;
                            compartmentno = ddl_ITda.SelectedItem.Text.Replace(" ", string.Empty) + ddl_district.SelectedValue;

                            DateTime n = new DateTime();
                            n = DateTime.UtcNow.Date;
                            string location = string.Empty;
                            // DATETIME = DATETIME.Replace(" ", string.Empty);
                            if (!string.IsNullOrEmpty(Compartmentno1))
                            {
                                if (dlc != null && dlc.ContentLength > 0)
                                {
                                    if (!string.IsNullOrEmpty(Compartmentno1))
                                    {
                                        try
                                        {
                                            // string location = HttpContext.Current.Server.MapPath("~/DLC/" + compartmentno + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "/");
                                            location = HttpContext.Current.Server.MapPath("~/DLC/" + compartmentno + "/");
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
                                            break;
                                        }



                                    }
                                    //else
                                    //{
                                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please entert compartment no')", true);
                                    //}
                                    // byte[] imgbyte = new byte[] { };
                                    addbeneficiaryobj.id = "";
                                    addbeneficiaryobj.dlcid = Iddlc;
                                    //addbeneficiaryobj.Aadhaar_NO = txt_aadhar.Text;
                                    // addbeneficiaryobj.Image = "";
                                    if (multiflag == false)
                                    {
                                        addbeneficiaryobj.Dlc = txt_dlc.Text;
                                        addbeneficiaryobj.Dlcpath = location;
                                        multiflag = true;
                                    }
                                    addbeneficiaryobj.Imagepath = txt_image.Text;
                                    string byteString = BitConverter.ToString(bytes);
                                    // string imgString = BitConverter.ToString(imgbyte);
                                    if (multiflag == false)
                                    {
                                        multistring = byteString;
                                        multiflag = true;
                                    }
                                    if (!string.IsNullOrEmpty((string)(Session["username"])))
                                    {
                                        //if ( multistring != "")
                                        //{
                                        if (!string.IsNullOrEmpty(Compartmentno1))
                                        {
                                            try
                                            {

                                                try
                                                {
                                                    ProjectRofrBAL.GetMasterDetails.AddBeneficiaryUploadFiles(addbeneficiaryobj, "a", "", (string)(Session["username"]), (string)(Session["IPAddress"]));
                                                }
                                                catch (Exception ex)
                                                {
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Dlc Upload Saved Error !')('" + compartmentno + "')", true);
                                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                                                    break;
                                                    errorflag = false;
                                                }
                                                errorflag = true;
                                            }
                                            catch (Exception ex)
                                            {
                                                errorflag = false;
                                            }
                                            // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Dlc Uploaded successfully')", true);
                                        }
                                        // }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please enter DLC Date ')", true);
                            }



                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please entert Pattadaar Name for All Checked Records ')", true);
                }

                if (errorflag == true)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Dlc Uploaded successfully')", true);
                    if (ddl_district.SelectedItem.Text != "Select")
                    {
                        if (ddl_records.SelectedValue != "0")
                        {
                            BindCount(ddl_district.SelectedValue, false, ddl_records.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                            BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                        }

                    }
                    txt_dlc.Text = string.Empty;
                    txt_image.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_Image_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                int j = 0;
                bool UPDATEFLAG = false;
                string Id = string.Empty;
                string Iddlc = string.Empty;
                string Compartmentno1 = string.Empty;
                string Compartmentno2 = string.Empty;
                string imagefloder = string.Empty;
                string dlcfloder = string.Empty;
                string imgbenficary = string.Empty;
                string imagesavefilename = string.Empty;
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {
                    //to get the dropdown of each line
                    CheckBox chk = (CheckBox)itemEquipment.FindControl("Update_Image");
                    if (chk.Checked == true)
                    {
                        i++;
                    }

                    CheckBox chkup = (CheckBox)itemEquipment.FindControl("Update_dlc");
                    if (chkup.Checked == true)
                    {
                        j++;
                    }
                }

                if (i == 1 && j == 1)
                {
                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {
                        //to get the dropdown of each line
                        CheckBox chk = (CheckBox)itemEquipment.FindControl("Update_Image");
                        if (chk.Checked == true)
                        {
                            Label imageid = itemEquipment.FindControl("Label4") as Label;
                            TextBox CNO = itemEquipment.FindControl("txt_RPD") as TextBox;
                            Id = imageid.Text;
                            imgbenficary = CNO.Text;


                        }

                        CheckBox chkup = (CheckBox)itemEquipment.FindControl("Update_dlc");
                        if (chkup.Checked == true)
                        {
                            Label dlcid = itemEquipment.FindControl("Label4") as Label;
                            TextBox CNO = itemEquipment.FindControl("txt_RPD") as TextBox;
                            Iddlc = dlcid.Text;
                            Compartmentno1 = CNO.Text;
                            Compartmentno2 = CNO.Text;


                        }
                    }
                    UPDATEFLAG = true;
                }
                else if (i > 1 && j > 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please Update Single Beneficiary Image and Dlc at a time')", true);
                    UPDATEFLAG = false;
                }

                if (i == 0 && j == 1)
                {
                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {
                        CheckBox chkup = (CheckBox)itemEquipment.FindControl("Update_dlc");
                        if (chkup.Checked == true)
                        {
                            Label dlcid = itemEquipment.FindControl("Label4") as Label;
                            TextBox CNO = itemEquipment.FindControl("txt_RPD") as TextBox;
                            Iddlc = dlcid.Text;
                            Compartmentno1 = CNO.Text;
                            Compartmentno2 = CNO.Text;
                        }
                    }
                    UPDATEFLAG = true;
                }
                else if (j > 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please Update Single Beneficiary  Dlc at a time')", true);
                    UPDATEFLAG = false;
                }

                if (i == 1 && j == 0)
                {
                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {
                        CheckBox chk = (CheckBox)itemEquipment.FindControl("Update_Image");
                        if (chk.Checked == true)
                        {
                            Label imageid = itemEquipment.FindControl("Label4") as Label;

                            TextBox CNO = itemEquipment.FindControl("txt_RPD") as TextBox;
                            Id = imageid.Text;
                            imgbenficary = CNO.Text;
                        }
                    }
                    UPDATEFLAG = true;
                }
                else if (i > 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please Update Single Beneficiary Image at a time')", true);
                    UPDATEFLAG = false;
                }

                if (UPDATEFLAG == true)
                {
                    addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();
                    //IMAGE CODE START
                    int length = FileUpload.PostedFile.ContentLength;
                    Byte[] bytes = new byte[] { };
                    Byte[] comparebytes = new byte[] { };
                    byte[] imgbyte = new byte[] { };
                    string benid = string.Empty;
                    string imglocation = string.Empty;
                    imgbyte = new byte[length];
                    if (i == 1)
                    {
                        HttpPostedFile image = FileUpload.PostedFile;

                        image.InputStream.Read(imgbyte, 0, length);
                        string imagename = FileUpload.PostedFile.FileName;
                        imagefloder = ddl_ITda.SelectedItem.Text.Replace(" ", string.Empty) + ddl_district.SelectedValue;
                        benid = imgbenficary.Replace(" ", string.Empty) + Id;
                        // FileUpload.PostedFile.SaveAs("~//Beneficiary Images" + "//" + imagename);

                        //HttpPostedFile image1 = Request.Files["FileUpload"];
                        if (image != null && image.ContentLength > 0)
                        {
                            try
                            {
                                imglocation = HttpContext.Current.Server.MapPath("~/BeneficairyImages/" + DateTime.Now.ToString("dd-MM-yyyy") + "/" + imagefloder + "/" + benid + "/");

                                if (!Directory.Exists(imglocation))
                                {
                                    Directory.CreateDirectory(imglocation);

                                }
                                imagesavefilename = image.FileName;
                                string filepath = imglocation + Path.GetFileName(image.FileName);
                                image.SaveAs(filepath);
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Image Location Created Error !')", true);
                                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                            }
                        }

                    }
                    //DLC CODE START
                    HttpPostedFile dlc = file_dlc.PostedFile;
                    string dlcpath = file_dlc.PostedFile.FileName;
                    string dlcname = Path.GetFileName(dlcpath);
                    string ext = Path.GetExtension(dlcname);
                    string jpgext = Path.GetExtension(dlcname);
                    string type = string.Empty;
                    string type1 = string.Empty;
                    string dlclocation = string.Empty;
                    string compartmentno = Compartmentno1;
                    compartmentno = compartmentno.Replace(" ", string.Empty);
                    compartmentno = compartmentno + Iddlc;
                    DateTime n = new DateTime();
                    n = DateTime.UtcNow.Date;
                    // DATETIME = DATETIME.Replace(" ", string.Empty);
                    dlcfloder = ddl_ITda.SelectedItem.Text.Replace(" ", string.Empty) + ddl_district.SelectedValue;
                    if (j == 1)
                    {


                        if (!string.IsNullOrEmpty(Compartmentno2))
                        {
                            if (dlc != null && dlc.ContentLength > 0)
                            {
                                if (!string.IsNullOrEmpty(Compartmentno2))
                                {
                                    try
                                    {
                                        //string location = HttpContext.Current.Server.MapPath("~/DLC/" + compartmentno + "/" + DateTime.Now.ToString("dd-MM-yyyy") + "/");
                                        dlclocation = HttpContext.Current.Server.MapPath("~/DLC/" + dlcfloder + "/");

                                        if (!Directory.Exists(dlclocation))
                                        {
                                            Directory.CreateDirectory(dlclocation);

                                        }
                                        //  string dlcpath1 = Server.MapPath("~/DLC/") + compartmentno + "/" + DateTime.Now.ToString("dd-MM-yyy") + "/" + Path.GetFileName(dlc.FileName);
                                        string dlcpath1 = dlclocation + Path.GetFileName(dlc.FileName);
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
                                            //  string imagename = file_dlc.PostedFile.FileName;
                                            bytes = imgbyte1;
                                        }
                                    }
                                }
                                //else
                                //{
                                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please entert compartment no')", true);
                                //}
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please entert Pattadaar Name ')", true);
                        }
                    }

                    addbeneficiaryobj.id = Id;
                    addbeneficiaryobj.dlcid = Iddlc;
                    //addbeneficiaryobj.Aadhaar_NO = txt_aadhar.Text;
                    addbeneficiaryobj.Image = imagesavefilename;
                    addbeneficiaryobj.Dlc = txt_dlc.Text;
                    addbeneficiaryobj.Imagepath = imglocation;
                    addbeneficiaryobj.Dlcpath = dlclocation;
                    string byteString = BitConverter.ToString(bytes);
                    string imgString = BitConverter.ToString(imgbyte);
                    if (!string.IsNullOrEmpty((string)(Session["username"])))
                    {
                        if (byteString == "" && imgString != "")
                        {
                            try
                            {
                                ProjectRofrBAL.GetMasterDetails.AddBeneficiaryUploadFiles(addbeneficiaryobj, byteString, imgString, (string)(Session["username"]), (string)(Session["IPAddress"]));
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Image file Uploaded successfully')", true);
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Image file Uploaded  Error !')('" + compartmentno + "')", true);
                                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                            }
                        }
                        if (byteString != "" && imgString == "")
                        {
                            if (!string.IsNullOrEmpty(Compartmentno2))
                            {
                                try
                                {
                                    ProjectRofrBAL.GetMasterDetails.AddBeneficiaryUploadFiles(addbeneficiaryobj, byteString, imgString, (string)(Session["username"]), (string)(Session["IPAddress"]));
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Dlc Uploaded successfully')", true);
                                }
                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Dlc Uploaded Error !')('" + compartmentno + "')", true);
                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please entert Pattadaar Name')", true);
                            }
                        }
                        else if (byteString != "" && imgString != "")
                        {
                            if (!string.IsNullOrEmpty(Compartmentno2))
                            {
                                try
                                {
                                    ProjectRofrBAL.GetMasterDetails.AddBeneficiaryUploadFiles(addbeneficiaryobj, byteString, imgString, (string)(Session["username"]), (string)(Session["IPAddress"]));
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Files Uploaded successfully')", true);
                                }
                                catch (Exception ex)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Files Uploaded  Error !')('" + compartmentno + "')", true);
                                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please enter Dlc Date')", true);
                            }
                        }
                        else if (byteString == "" && imgString == "" && UPDATEFLAG == true)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please Choose Files')", true);
                        }

                        if (ddl_district.SelectedItem.Text != "Select")
                        {
                            if (ddl_records.SelectedValue != "0")
                            {
                                BindCount(ddl_district.SelectedValue, false, ddl_records.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                                BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                            }

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                    txt_dlc.Text = string.Empty;
                    txt_image.Text = string.Empty;
                    UPDATEFLAG = false;
                    Id = string.Empty;
                    Iddlc = string.Empty;
                    Compartmentno1 = string.Empty;
                    Compartmentno2 = string.Empty;
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
                bool mandatoryfalg = false;
                string IPAddress = (string)(Session["IPAddress"]);
                string MacAddress = (string)(Session["MacAddress"]);
                bool Atleastoneselectrow = false;

                Changeclour();
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {

                    CheckBox chkup = (CheckBox)itemEquipment.FindControl("chkSelect");
                    if (chkup.Checked == true)
                    {
                        DropDownList mandal = itemEquipment.FindControl("ddlmandalas") as DropDownList;
                        DropDownList village = itemEquipment.FindControl("ddlvillages") as DropDownList;
                        TextBox grampanchat = itemEquipment.FindControl("txt_GPN") as TextBox;
                        TextBox habitation = itemEquipment.FindControl("txt_HAB") as TextBox;
                        DropDownList forestdivision = itemEquipment.FindControl("ddldivisions") as DropDownList;
                        DropDownList forestrange = itemEquipment.FindControl("ddlranges") as DropDownList;
                        DropDownList forestbeat = itemEquipment.FindControl("ddlbeats") as DropDownList;
                        TextBox forestblock = itemEquipment.FindControl("txt_FBL") as TextBox;
                        TextBox compatmentno = itemEquipment.FindControl("txt_CNO") as TextBox;
                        TextBox pattano = itemEquipment.FindControl("txt_RPN") as TextBox;
                        DropDownList pattainamgovt = itemEquipment.FindControl("ddlpig") as DropDownList;
                        TextBox holidingnature = itemEquipment.FindControl("txt_HN") as TextBox;
                        TextBox extentplotarea = itemEquipment.FindControl("txt_EPA") as TextBox;
                        TextBox pattadarname = itemEquipment.FindControl("txt_RPD") as TextBox;
                        TextBox cultivatorname = itemEquipment.FindControl("txt_CNA") as TextBox;
                        TextBox dlcdate = itemEquipment.FindControl("txt_dlcdate") as TextBox;
                        DropDownList landclass = itemEquipment.FindControl("landclassfication") as DropDownList;


                        if (mandal.SelectedItem.Text == "select")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (village.SelectedItem.Text == "select")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (grampanchat.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (habitation.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (forestdivision.SelectedItem.Text == "select")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (forestrange.SelectedItem.Text == "select")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (forestbeat.SelectedItem.Text == "select")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (forestblock.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (compatmentno.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        //if (pattano.Text == "")
                        //{
                        //    mandatoryfalg = true;
                        //    break;
                        //}
                        if (pattainamgovt.SelectedItem.Text == "select")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (holidingnature.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (extentplotarea.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (pattadarname.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (cultivatorname.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        //if (dlcdate.Text == "")
                        //{
                        //    mandatoryfalg = true;
                        //    break;
                        //}
                        if (landclass.SelectedItem.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
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
                            Label id = itemEquipment.FindControl("Label4") as Label;
                            Atleastoneselectrow = true;

                            DropDownList MNC = itemEquipment.FindControl("ddlmandalas") as DropDownList;
                            DropDownList MN = itemEquipment.FindControl("ddlmandalas") as DropDownList;
                            TextBox GPN = itemEquipment.FindControl("txt_GPN") as TextBox;
                            DropDownList VNC = itemEquipment.FindControl("ddlvillages") as DropDownList;
                            DropDownList VN = itemEquipment.FindControl("ddlvillages") as DropDownList;
                            TextBox HABC = itemEquipment.FindControl("txt_HABC") as TextBox;
                            TextBox HAB = itemEquipment.FindControl("txt_HAB") as TextBox;
                            DropDownList FDNC = itemEquipment.FindControl("ddldivisions") as DropDownList;
                            DropDownList FDN = itemEquipment.FindControl("ddldivisions") as DropDownList;
                            DropDownList FRNC = itemEquipment.FindControl("ddlranges") as DropDownList;
                            DropDownList FRN = itemEquipment.FindControl("ddlranges") as DropDownList;
                            DropDownList FBNC = itemEquipment.FindControl("ddlbeats") as DropDownList;
                            DropDownList FBN = itemEquipment.FindControl("ddlbeats") as DropDownList;
                            TextBox FB = itemEquipment.FindControl("txt_FBL") as TextBox;
                            TextBox CNO = itemEquipment.FindControl("txt_CNO") as TextBox;
                            TextBox PN = itemEquipment.FindControl("txt_PN") as TextBox;
                            TextBox EPA = itemEquipment.FindControl("txt_EPA") as TextBox;
                            TextBox EUL = itemEquipment.FindControl("txt_EUL") as TextBox;
                            TextBox ECL = itemEquipment.FindControl("txt_ECL") as TextBox;
                            //TextBox PIG = itemEquipment.FindControl("txt_PIG") as TextBox;
                            DropDownList PIG = itemEquipment.FindControl("ddlpig") as DropDownList;
                            TextBox WT = itemEquipment.FindControl("txt_WT") as TextBox;
                            //TextBox DRYIC = itemEquipment.FindControl("txt_DI") as TextBox;
                            DropDownList DRYIC = itemEquipment.FindControl("ddldl") as DropDownList;
                            TextBox WS = itemEquipment.FindControl("txt_WS") as TextBox;
                            TextBox EI = itemEquipment.FindControl("txt_EI") as TextBox;
                            TextBox RPN = itemEquipment.FindControl("txt_RPN") as TextBox;
                            TextBox RPD = itemEquipment.FindControl("txt_RPD") as TextBox;
                            TextBox CN = itemEquipment.FindControl("txt_CNA") as TextBox;
                            TextBox EUC = itemEquipment.FindControl("txt_EUC") as TextBox;
                            TextBox HN = itemEquipment.FindControl("txt_HN") as TextBox;
                           // TextBox LUTC = itemEquipment.FindControl("txt_LUTC") as TextBox;
                            TextBox LUE = itemEquipment.FindControl("txt_LUE") as TextBox;
                            TextBox LUNSA = itemEquipment.FindControl("txt_LUNSA") as TextBox;
                            DropDownList KR = itemEquipment.FindControl("ddlkr") as DropDownList;
                            //TextBox KR = itemEquipment.FindControl("txt_KR") as TextBox;
                            DropDownList MOC = itemEquipment.FindControl("ddlmoc") as DropDownList;
                            // TextBox MOC = itemEquipment.FindControl("txt_MOC") as TextBox;
                            TextBox CROP = itemEquipment.FindControl("txt_Crop") as TextBox;
                            TextBox ES = itemEquipment.FindControl("txt_ES") as TextBox;
                            TextBox EM = itemEquipment.FindControl("txt_EM") as TextBox;
                            TextBox ET = itemEquipment.FindControl("txt_ET") as TextBox;
                            TextBox ELWS = itemEquipment.FindControl("txt_ELWS") as TextBox;
                            TextBox ELC = itemEquipment.FindControl("txt_ELCO") as TextBox;
                            TextBox ELCT = itemEquipment.FindControl("txt_ELCTH") as TextBox;
                            TextBox CY = itemEquipment.FindControl("txt_CY") as TextBox;
                            TextBox VRR = itemEquipment.FindControl("txt_VRE") as TextBox;
                            TextBox TR = itemEquipment.FindControl("txt_TRE") as TextBox;
                            TextBox REMARKS = itemEquipment.FindControl("txt_RE") as TextBox;
                            //TextBox AADHAR_NO = itemEquipment.FindControl("AADHAR_NO") as TextBox;
                            //IPAddress = GetIPAddress();
                            //MacAddress = GetMAC();
                            TextBox Dlcdate = itemEquipment.FindControl("txt_dlcdate") as TextBox;
                            DropDownList landclass = itemEquipment.FindControl("landclassfication") as DropDownList;
                            // TextBox BANKNAME = itemEquipment.FindControl("txt_Bank") as TextBox;
                            // TextBox BACKACCNO = itemEquipment.FindControl("txt_Bankac") as TextBox;
                            // TextBox IFSC = itemEquipment.FindControl("txt_ifsc") as TextBox;
                            TextBox pattadarfathername = itemEquipment.FindControl("txt_Fathername") as TextBox;
                            TextBox subcaste = itemEquipment.FindControl("txt_subcaste") as TextBox;
                            TextBox adhar = itemEquipment.FindControl("txt_adhar") as TextBox;
                            TextBox bankno = itemEquipment.FindControl("txt_bankno") as TextBox;
                            TextBox ifsc = itemEquipment.FindControl("txt_ifsc") as TextBox;
                            TextBox bname = itemEquipment.FindControl("txt_bname") as TextBox;

                            DataRow dr = dtUpdateDetails.NewRow();
                            dr["Mandal_Code"] = MNC.SelectedValue;
                            dr["Mandal"] = MN.SelectedItem.Text;
                            dr["Gram_Panchayat"] = GPN.Text;
                            dr["Village_Code"] = VNC.SelectedValue;
                            dr["Village"] = VN.SelectedItem.Text;
                            dr["HabitationCode"] = HABC.Text;
                            dr["Habitation"] = HAB.Text;
                            dr["Forest_DivisionCode"] = FDNC.SelectedValue;
                            dr["Forest_Division"] = FDN.SelectedItem.Text;
                            dr["Forest_RangeCode"] = FRNC.SelectedValue;
                            dr["Forest_Range"] = FRN.SelectedItem.Text;
                            dr["Forest_BeatCode"] = FBNC.SelectedValue;
                            dr["Forest_Beat"] = FBN.SelectedItem.Text;
                            dr["Forest_Block"] = FB.Text;
                            dr["Compartment_No"] = CNO.Text;
                            dr["Plot_No"] = PN.Text;
                            dr["ExtentPlotArea"] = EPA.Text;
                            dr["Uncultivable_Land"] = EUL.Text;
                            dr["Cultivable_Land"] = ECL.Text;
                            dr["PATTA_INAMGOVT"] = PIG.SelectedItem.Text;
                            dr["Water_Tax"] = WT.Text;
                            dr["DRYID_ONECROP_TWO_CROP"] = DRYIC.SelectedItem.Text;
                            dr["WATER_SOURCE"] = WS.Text;
                            dr["EXTENT_IRRIGATED"] = EI.Text;
                            dr["ROFR_PATTANO"] = RPN.Text;
                            dr["ROFR_PATTADAAR"] = RPD.Text;
                            dr["CULTIVATOR_NAME"] = CN.Text;
                            dr["EXTENT_UNDER_CULTIVATOR"] = EUC.Text;
                            dr["HOLDING_NATURE"] = HN.Text;
                            dr["TYPE_CODE"] = "";
                            dr["EXTENT"] = LUE.Text;
                            dr["NET_SOWN_AREA"] = LUNSA.Text;
                            dr["KHARIFF_RABI"] = KR.SelectedItem.Text;
                            dr["MONTH_OF_CULTIVATION"] = MOC.SelectedItem.Text;
                            dr["CROP"] = CROP.Text;
                            dr["SINGLE"] = ES.Text;
                            dr["MIXED"] = EM.Text;
                            dr["TOTAL"] = ET.Text;
                            dr["WATER_SOURCE1"] = ELWS.Text;
                            dr["FIRST_CROP"] = ELC.Text;
                            dr["SECOND_THIRD_CROP"] = ELCT.Text;
                            dr["CROP_YIELD"] = CY.Text;
                            dr["VRO_RI_REMARKS"] = VRR.Text;
                            dr["TAHSILDAR_REMARKS"] = TR.Text;
                            dr["REMARKS"] = REMARKS.Text;
                            dr["Aadhaar_NO"] = adhar.Text;
                            dr["Id"] = id.Text;
                            dr["IsEdit"] = edit;
                            dr["Status"] = "C";
                            dr["IsApproved"] = isapproved;
                            dr["IPADDRESS"] = IPAddress;
                            dr["MACADDRESS"] = MacAddress;

                            dr["Dlc_date"] = Dlcdate.Text;
                            dr["Landclassification"] = landclass.SelectedItem.Text;
                             dr["BankName"] = bname.Text;
                             dr["BankAccountNo"] = bankno.Text;
                             dr["IfscCode"] = ifsc.Text;
                            dr["Father_Name"] = pattadarfathername.Text;
                            dr["SUB_CASTE"] = subcaste.Text;

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
                            ProjectRofrBAL.GetMasterDetails.UpdateValidateBeneficiaryDetails(BeneficiaryDetailsobj, (string)(Session["username"]));
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficiary Details Updated Successfully')", true);
                            if (ddl_district.SelectedItem.Text != "Select")
                            {
                                if (ddl_records.SelectedValue != "0")
                                {
                                    BindCount(ddl_district.SelectedValue, false, ddl_records.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                                    BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
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

        public DataTable searchBindData(string district, string Itda, string mandal, string village)
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


                dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal, village);

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
                dtbeneficiareies = searchBindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
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
        public void Changeclour()
        {
            try
            {

                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {

                    CheckBox chkup = (CheckBox)itemEquipment.FindControl("chkSelect");
                    if (chkup.Checked == true)
                    {

                        DropDownList mandal = itemEquipment.FindControl("ddlmandalas") as DropDownList;
                        DropDownList village = itemEquipment.FindControl("ddlvillages") as DropDownList;
                        TextBox grampanchat = itemEquipment.FindControl("txt_GPN") as TextBox;
                        TextBox habitation = itemEquipment.FindControl("txt_HAB") as TextBox;
                        DropDownList forestdivision = itemEquipment.FindControl("ddldivisions") as DropDownList;
                        DropDownList forestrange = itemEquipment.FindControl("ddlranges") as DropDownList;
                        DropDownList forestbeat = itemEquipment.FindControl("ddlbeats") as DropDownList;
                        TextBox forestblock = itemEquipment.FindControl("txt_FBL") as TextBox;
                        TextBox compatmentno = itemEquipment.FindControl("txt_CNO") as TextBox;
                        TextBox pattano = itemEquipment.FindControl("txt_RPN") as TextBox;
                        DropDownList pattainamgovt = itemEquipment.FindControl("ddlpig") as DropDownList;
                        TextBox holidingnature = itemEquipment.FindControl("txt_HN") as TextBox;
                        TextBox extentplotarea = itemEquipment.FindControl("txt_EPA") as TextBox;
                        TextBox pattadarname = itemEquipment.FindControl("txt_RPD") as TextBox;
                        TextBox cultivatorname = itemEquipment.FindControl("txt_CNA") as TextBox;
                        TextBox dlcdate = itemEquipment.FindControl("txt_dlcdate") as TextBox;
                        DropDownList landclass = itemEquipment.FindControl("landclassfication") as DropDownList;

                        if (pattainamgovt.SelectedItem.Text == "select")
                        {
                            pattainamgovt.BorderColor = Color.Red;
                        }
                        else if (pattainamgovt.SelectedItem.Text != "select")
                        {
                            if (pattainamgovt.BorderColor == Color.Red)
                                pattainamgovt.BorderColor = Color.LightGray;
                        }
                        //if (dlcdate.Text == "")
                        //{
                        //    dlcdate.BorderColor = Color.Red;
                        //}
                        //else if (dlcdate.Text != "")
                        //{
                        //    if (dlcdate.BorderColor == Color.Red)
                        //        dlcdate.BorderColor = Color.LightGray;
                        //}
                        if (landclass.SelectedItem.Text == "select")
                        {
                            landclass.BorderColor = Color.Red;
                        }
                        else if (landclass.SelectedItem.Text != "select")
                        {
                            if (landclass.BorderColor == Color.Red)
                                landclass.BorderColor = Color.LightGray;
                        }
                        if (mandal.SelectedItem.Text == "select")
                        {
                            mandal.BorderColor = Color.Red;
                        }
                        else if (mandal.SelectedItem.Text != "select")
                        {
                            if (mandal.BorderColor == Color.Red)
                                mandal.BorderColor = Color.LightGray;
                        }
                        if (village.SelectedItem.Text == "select")
                        {
                            village.BorderColor = Color.Red;
                        }
                        else if (village.SelectedItem.Text != "select")
                        {
                            if (village.BorderColor == Color.Red)
                                village.BorderColor = Color.LightGray;
                        }
                        if (grampanchat.Text == "")
                        {
                            grampanchat.BorderColor = Color.Red;
                        }
                        else if (grampanchat.Text != "")
                        {
                            if (grampanchat.BorderColor == Color.Red)
                                grampanchat.BorderColor = Color.LightGray;
                        }
                        if (habitation.Text == "")
                        {
                            habitation.BorderColor = Color.Red;
                        }
                        else if (habitation.Text != "")
                        {
                            if (habitation.BorderColor == Color.Red)
                                habitation.BorderColor = Color.LightGray;
                        }
                        if (forestdivision.SelectedItem.Text == "select")
                        {
                            forestdivision.BorderColor = Color.Red;
                        }
                        else if (forestdivision.SelectedItem.Text != "select")
                        {
                            if (forestdivision.BorderColor == Color.Red)
                                forestdivision.BorderColor = Color.LightGray;
                        }
                        if (forestrange.SelectedItem.Text == "select")
                        {
                            forestrange.BorderColor = Color.Red;
                        }
                        else if (forestrange.SelectedItem.Text != "select")
                        {
                            if (forestrange.BorderColor == Color.Red)
                                forestrange.BorderColor = Color.LightGray;
                        }
                        if (forestbeat.SelectedItem.Text == "select")
                        {
                            forestbeat.BorderColor = Color.Red;
                        }
                        else if (forestbeat.SelectedItem.Text != "select")
                        {
                            if (forestbeat.BorderColor == Color.Red)
                                forestbeat.BorderColor = Color.LightGray;
                        }
                        if (forestblock.Text == "")
                        {
                            forestblock.BorderColor = Color.Red;
                        }
                        else if (forestblock.Text != "")
                        {
                            if (forestblock.BorderColor == Color.Red)
                                forestblock.BorderColor = Color.LightGray;
                        }
                        if (compatmentno.Text == "")
                        {
                            compatmentno.BorderColor = Color.Red;
                        }
                        else if (compatmentno.Text != "")
                        {
                            if (compatmentno.BorderColor == Color.Red)
                                compatmentno.BorderColor = Color.LightGray;
                        }
                        //if (pattano.Text == "")
                        //{
                        //    pattano.BorderColor = Color.Red;
                        //}
                        //else if (pattano.Text != "")
                        //{
                        //    if (pattano.BorderColor == Color.Red)
                        //        pattano.BorderColor = Color.LightGray;
                        //}

                        if (holidingnature.Text == "")
                        {
                            holidingnature.BorderColor = Color.Red;
                        }
                        else if (holidingnature.Text != "")
                        {
                            if (holidingnature.BorderColor == Color.Red)
                                holidingnature.BorderColor = Color.LightGray;
                        }
                        if (extentplotarea.Text == "")
                        {
                            extentplotarea.BorderColor = Color.Red;
                        }
                        else if (extentplotarea.Text != "")
                        {
                            if (extentplotarea.BorderColor == Color.Red)
                                extentplotarea.BorderColor = Color.LightGray;
                        }
                        if (pattadarname.Text == "")
                        {
                            pattadarname.BorderColor = Color.Red;
                        }
                        else if (pattadarname.Text != "")
                        {
                            if (pattadarname.BorderColor == Color.Red)
                                pattadarname.BorderColor = Color.LightGray;
                        }
                        if (cultivatorname.Text == "")
                        {
                            cultivatorname.BorderColor = Color.Red;
                        }
                        else if (cultivatorname.Text != "")
                        {
                            if (cultivatorname.BorderColor == Color.Red)
                                cultivatorname.BorderColor = Color.LightGray;
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

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater1.Items)
            {
                CheckBox chk1 = (CheckBox)item.FindControl("chkSelect");
                if (chk1.Checked == false)
                {
                    HtmlTableRow row = (HtmlTableRow)item.FindControl("row");
                    row.Attributes["style"] = "background-color:white";
                    TextBox grampanchat1 = item.FindControl("txt_GPN") as TextBox;
                    DropDownList mandalas1 = item.FindControl("ddlmandalas") as DropDownList;
                    DropDownList village1 = item.FindControl("ddlvillages") as DropDownList;
                    DropDownList divisions1 = item.FindControl("ddldivisions") as DropDownList;
                    DropDownList ranges1 = item.FindControl("ddlranges") as DropDownList;
                    DropDownList beats1 = item.FindControl("ddlbeats") as DropDownList;
                    TextBox txt_HABC1 = item.FindControl("txt_HABC") as TextBox;
                    TextBox txt_HAB1 = item.FindControl("txt_HAB") as TextBox;
                    TextBox txt_CNO1 = item.FindControl("txt_CNO") as TextBox;
                    TextBox txt_EPA1 = item.FindControl("txt_EPA") as TextBox;
                    TextBox txt_FBL1 = item.FindControl("txt_FBL") as TextBox;
                    TextBox txt_PN1 = item.FindControl("txt_PN") as TextBox;
                    TextBox txt_EUL1 = item.FindControl("txt_EUL") as TextBox;
                    TextBox ECL1 = item.FindControl("txt_ECL") as TextBox;
                    ECL1.BackColor = Color.White;
                    DropDownList PIG1 = item.FindControl("ddlpig") as DropDownList;
                    PIG1.BackColor = Color.White;
                    TextBox WT1 = item.FindControl("txt_WT") as TextBox;
                    WT1.BackColor = Color.White;
                    DropDownList DRYIC1 = item.FindControl("ddldl") as DropDownList;
                    DRYIC1.BackColor = Color.White;
                    TextBox WS1 = item.FindControl("txt_WS") as TextBox;
                    WS1.BackColor = Color.White;
                    TextBox EI1 = item.FindControl("txt_EI") as TextBox;
                    EI1.BackColor = Color.White;
                    TextBox RPN1 = item.FindControl("txt_RPN") as TextBox;
                    RPN1.BackColor = Color.White;
                    TextBox RPD1 = item.FindControl("txt_RPD") as TextBox;
                    RPD1.BackColor = Color.White;
                    TextBox CN1 = item.FindControl("txt_CNA") as TextBox;
                    CN1.BackColor = Color.White;
                    TextBox EUC1 = item.FindControl("txt_EUC") as TextBox;
                    EUC1.BackColor = Color.White;
                    TextBox HN1 = item.FindControl("txt_HN") as TextBox;
                    HN1.BackColor = Color.White;
                   // TextBox LUTC = item.FindControl("txt_LUTC") as TextBox;
                   // LUTC.BackColor = Color.White;
                    TextBox LUE = item.FindControl("txt_LUE") as TextBox;
                    LUE.BackColor = Color.White;
                    TextBox LUNSA = item.FindControl("txt_LUNSA") as TextBox;
                    LUNSA.BackColor = Color.White;
                    DropDownList KR = item.FindControl("ddlkr") as DropDownList;
                    KR.BackColor = Color.White;
                    DropDownList MOC1 = item.FindControl("ddlmoc") as DropDownList;
                    MOC1.BackColor = Color.White;
                    TextBox CROP1 = item.FindControl("txt_Crop") as TextBox;
                    CROP1.BackColor = Color.White;
                    TextBox ES1 = item.FindControl("txt_ES") as TextBox;
                    ES1.BackColor = Color.White;
                    TextBox EM1 = item.FindControl("txt_EM") as TextBox;
                    EM1.BackColor = Color.White;
                    TextBox ET1 = item.FindControl("txt_ET") as TextBox;
                    ET1.BackColor = Color.White;
                    TextBox ELWS1 = item.FindControl("txt_ELWS") as TextBox;
                    ELWS1.BackColor = Color.White;
                    TextBox ELC1 = item.FindControl("txt_ELCO") as TextBox;
                    ELC1.BackColor = Color.White;
                    TextBox ELCT1 = item.FindControl("txt_ELCTH") as TextBox;
                    ELCT1.BackColor = Color.White;
                    TextBox CY1 = item.FindControl("txt_CY") as TextBox;
                    CY1.BackColor = Color.White;
                    TextBox VRR1 = item.FindControl("txt_VRE") as TextBox;
                    VRR1.BackColor = Color.White;
                    TextBox TR1 = item.FindControl("txt_TRE") as TextBox;
                    TR1.BackColor = Color.White;
                    TextBox REMARKS1 = item.FindControl("txt_RE") as TextBox;
                    REMARKS1.BackColor = Color.White;
                    TextBox Dlcdate1 = item.FindControl("txt_dlcdate") as TextBox;
                    Dlcdate1.BackColor = Color.White;
                    DropDownList landclass1 = item.FindControl("landclassfication") as DropDownList;
                    landclass1.BackColor = Color.White;
                    TextBox pattadarfathername1 = item.FindControl("txt_Fathername") as TextBox;
                    pattadarfathername1.BackColor = Color.White;
                    txt_EUL1.BackColor = Color.White;
                    txt_PN1.BackColor = Color.White;
                    txt_FBL1.BackColor = Color.White;
                    grampanchat1.BackColor = Color.White;
                    mandalas1.BackColor = Color.White;
                    village1.BackColor = Color.White;
                    divisions1.BackColor = Color.White;
                    ranges1.BackColor = Color.White;
                    beats1.BackColor = Color.White;
                    txt_HABC1.BackColor = Color.White;
                    txt_HAB1.BackColor = Color.White;
                    txt_CNO1.BackColor = Color.White;
                    txt_EPA1.BackColor = Color.White;
                }
            }
            var chk = (CheckBox)sender;
            var item1 = (RepeaterItem)chk.NamingContainer;
            // var item1 = ((CheckBox)sender).Parent as RepeaterItem;
            if (item1 != null)
            {
                if (chk.Checked != false)
                {

                    HtmlTableRow currentrow = (HtmlTableRow)item1.FindControl("row");
                    TextBox grampanchat = currentrow.FindControl("txt_GPN") as TextBox;
                    DropDownList mandalas = currentrow.FindControl("ddlmandalas") as DropDownList;
                    DropDownList village = currentrow.FindControl("ddlvillages") as DropDownList;
                    DropDownList divisions = currentrow.FindControl("ddldivisions") as DropDownList;
                    DropDownList ranges = currentrow.FindControl("ddlranges") as DropDownList;
                    DropDownList beats = currentrow.FindControl("ddlbeats") as DropDownList;
                    TextBox txt_HABC = currentrow.FindControl("txt_HABC") as TextBox;
                    TextBox txt_HAB = currentrow.FindControl("txt_HAB") as TextBox;
                    TextBox txt_CNO = currentrow.FindControl("txt_CNO") as TextBox;
                    TextBox txt_EPA = currentrow.FindControl("txt_EPA") as TextBox;

                    TextBox txt_FBL = currentrow.FindControl("txt_FBL") as TextBox;
                    TextBox txt_PN = currentrow.FindControl("txt_PN") as TextBox;
                    TextBox txt_EUL = currentrow.FindControl("txt_EUL") as TextBox;
                    TextBox ECL = currentrow.FindControl("txt_ECL") as TextBox;
                    ECL.BackColor = Color.LightBlue;
                    DropDownList PIG = currentrow.FindControl("ddlpig") as DropDownList;
                    PIG.BackColor = Color.LightBlue;
                    TextBox WT = currentrow.FindControl("txt_WT") as TextBox;
                    WT.BackColor = Color.LightBlue;
                    DropDownList DRYIC = currentrow.FindControl("ddldl") as DropDownList;
                    DRYIC.BackColor = Color.LightBlue;
                    TextBox WS = currentrow.FindControl("txt_WS") as TextBox;
                    WS.BackColor = Color.LightBlue;
                    TextBox EI = currentrow.FindControl("txt_EI") as TextBox;
                    EI.BackColor = Color.LightBlue;
                    TextBox RPN = currentrow.FindControl("txt_RPN") as TextBox;
                    RPN.BackColor = Color.LightBlue;
                    TextBox RPD = currentrow.FindControl("txt_RPD") as TextBox;
                    RPD.BackColor = Color.LightBlue;
                    TextBox CN = currentrow.FindControl("txt_CNA") as TextBox;
                    CN.BackColor = Color.LightBlue;
                    TextBox EUC = currentrow.FindControl("txt_EUC") as TextBox;
                    EUC.BackColor = Color.LightBlue;
                    TextBox HN = currentrow.FindControl("txt_HN") as TextBox;
                    HN.BackColor = Color.LightBlue;
                   // TextBox LUTC = currentrow.FindControl("txt_LUTC") as TextBox;
                   // LUTC.BackColor = Color.LightBlue;
                    TextBox LUE = currentrow.FindControl("txt_LUE") as TextBox;
                    LUE.BackColor = Color.LightBlue;
                    TextBox LUNSA = currentrow.FindControl("txt_LUNSA") as TextBox;
                    LUNSA.BackColor = Color.LightBlue;
                    DropDownList KR = currentrow.FindControl("ddlkr") as DropDownList;
                    KR.BackColor = Color.LightBlue;
                    DropDownList MOC = currentrow.FindControl("ddlmoc") as DropDownList;
                    MOC.BackColor = Color.LightBlue;
                    TextBox CROP = currentrow.FindControl("txt_Crop") as TextBox;
                    CROP.BackColor = Color.LightBlue;
                    TextBox ES = currentrow.FindControl("txt_ES") as TextBox;
                    ES.BackColor = Color.LightBlue;
                    TextBox EM = currentrow.FindControl("txt_EM") as TextBox;
                    EM.BackColor = Color.LightBlue;
                    TextBox ET = currentrow.FindControl("txt_ET") as TextBox;
                    ET.BackColor = Color.LightBlue;
                    TextBox ELWS = currentrow.FindControl("txt_ELWS") as TextBox;
                    ELWS.BackColor = Color.LightBlue;
                    TextBox ELC = currentrow.FindControl("txt_ELCO") as TextBox;
                    ELC.BackColor = Color.LightBlue;
                    TextBox ELCT = currentrow.FindControl("txt_ELCTH") as TextBox;
                    ELCT.BackColor = Color.LightBlue;
                    TextBox CY = currentrow.FindControl("txt_CY") as TextBox;
                    CY.BackColor = Color.LightBlue;
                    TextBox VRR = currentrow.FindControl("txt_VRE") as TextBox;
                    VRR.BackColor = Color.LightBlue;
                    TextBox TR = currentrow.FindControl("txt_TRE") as TextBox;
                    TR.BackColor = Color.LightBlue;
                    TextBox REMARKS = currentrow.FindControl("txt_RE") as TextBox;
                    REMARKS.BackColor = Color.LightBlue;
                    TextBox Dlcdate = currentrow.FindControl("txt_dlcdate") as TextBox;
                    Dlcdate.BackColor = Color.LightBlue;
                    DropDownList landclass = currentrow.FindControl("landclassfication") as DropDownList;
                    landclass.BackColor = Color.LightBlue;
                    TextBox pattadarfathername = currentrow.FindControl("txt_Fathername") as TextBox;
                    pattadarfathername.BackColor = Color.LightBlue;
                    txt_EUL.BackColor = Color.LightBlue;
                    txt_PN.BackColor = Color.LightBlue;
                    mandalas.BackColor = Color.LightBlue;
                    village.BackColor = Color.LightBlue;
                    grampanchat.BackColor = Color.LightBlue;
                    divisions.BackColor = Color.LightBlue;
                    ranges.BackColor = Color.LightBlue;
                    beats.BackColor = Color.LightBlue;
                    txt_HABC.BackColor = Color.LightBlue;
                    txt_HAB.BackColor = Color.LightBlue;
                    txt_CNO.BackColor = Color.LightBlue;
                    txt_EPA.BackColor = Color.LightBlue;
                    txt_FBL.BackColor = Color.LightBlue;
                }

            }


        }
        protected void ChckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {
                    //to get the dropdown of each line
                    CheckBox chk = (CheckBox)itemEquipment.FindControl("chkSelect");
                    //  chk.Attributes.Add("style", "background-color:Green;");
                    if (chk.Checked == true)
                    {
                        TextBox CNO = itemEquipment.FindControl("txt_CNO") as TextBox;
                        Label lbl_CNO = itemEquipment.FindControl("lbl_CNO") as Label;

                        var regexItem = new Regex("^[a-zA-Z]*$");

                        if (regexItem.IsMatch(CNO.Text))
                        {
                            CNO.Text = string.Empty;
                            lbl_CNO.Visible = true;

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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    //Find the DropDownList in the Repeater Item.
                    DataTable dtMandals = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Mandal", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "");
                    DataTable dtvillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "village", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                    DataTable dtdivisions = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Division", ddl_district.SelectedValue, "", "");
                    DataTable dtranges = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Range", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, "");
                    DataTable dtbeats = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Beat", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                    DataTable dtpatta = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Patta", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                    DataTable dtdry = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Dry", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                    DataTable dtcropseason = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Season", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                    DataTable dtcropmnth = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Month", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                    DataTable dtlandclass = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Landclass", ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                    if (dtMandals.Rows.Count > 0)
                    {
                        DropDownList ddlmandal = (e.Item.FindControl("ddlmandalas") as DropDownList);
                        ddlmandal.DataSource = dtMandals;
                        ddlmandal.DataTextField = "MANDAL_NAME";
                        ddlmandal.DataValueField = "LGD_MANDAL_CODE";
                        ddlmandal.DataBind();

                        //Add Default Item in the DropDownList.
                        ddlmandal.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["MANDAL_NAME"].ToString();
                        ddlmandal.SelectedIndex = ddlmandal.Items.IndexOf(ddlmandal.Items.FindByText(country));
                        if (ddlmandal.SelectedIndex != 0)
                        {
                            ddlmandal.Items.FindByText(country).Selected = true;
                        }

                    }
                    if (dtvillages.Rows.Count > 0)
                    {
                        DropDownList ddlvillage = (e.Item.FindControl("ddlvillages") as DropDownList);
                        ddlvillage.DataSource = dtvillages;
                        ddlvillage.DataTextField = "VILLAGE_NAME";
                        ddlvillage.DataValueField = "LGD_VILLAGE_CODE";
                        ddlvillage.DataBind();

                        //Add Default Item in the DropDownList.
                        ddlvillage.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["VILLAGE_NAME"].ToString();

                        ddlvillage.SelectedIndex = ddlvillage.Items.IndexOf(ddlvillage.Items.FindByText(country));
                        if (ddlvillage.SelectedIndex != 0)
                        {
                            ddlvillage.Items.FindByText(country).Selected = true;
                        }

                    }
                    if (dtdivisions.Rows.Count > 0)
                    {
                        DropDownList ddldiv = (e.Item.FindControl("ddldivisions") as DropDownList);
                        ddldiv.DataSource = dtdivisions;
                        ddldiv.DataTextField = "FOREST_DIVISION_NAME";
                        ddldiv.DataValueField = "FOREST_DIVISION_CODE";
                        ddldiv.DataBind();

                        //Add Default Item in the DropDownList.
                        ddldiv.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["FOREST_DIVISION_NAME"].ToString();
                        ddldiv.SelectedIndex = ddldiv.Items.IndexOf(ddldiv.Items.FindByText(country));
                        if (ddldiv.SelectedIndex != 0)
                        {
                            ddldiv.Items.FindByText(country).Selected = true;
                        }
                    }
                    if (dtranges.Rows.Count > 0)
                    {
                        DropDownList ddlran = (e.Item.FindControl("ddlranges") as DropDownList);
                        ddlran.DataSource = dtranges;
                        ddlran.DataTextField = "FOREST_RANGE_NAME";
                        ddlran.DataValueField = "FOREST_RANGE_CODE";
                        ddlran.DataBind();

                        //Add Default Item in the DropDownList.
                        ddlran.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["FOREST_RANGE_NAME"].ToString();
                        ddlran.SelectedIndex = ddlran.Items.IndexOf(ddlran.Items.FindByText(country));
                        if (ddlran.SelectedIndex != 0)
                        {
                            ddlran.Items.FindByText(country).Selected = true;
                        }
                    }
                    if (dtbeats.Rows.Count > 0)
                    {
                        DropDownList ddlbeat = (e.Item.FindControl("ddlbeats") as DropDownList);
                        ddlbeat.DataSource = dtbeats;
                        ddlbeat.DataTextField = "FOREST_BEAT_NAME";
                        ddlbeat.DataValueField = "FOREST_BEAT_CODE";
                        ddlbeat.DataBind();

                        //Add Default Item in the DropDownList.
                        ddlbeat.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["FOREST_BEAT_NAME"].ToString();
                        ddlbeat.SelectedIndex = ddlbeat.Items.IndexOf(ddlbeat.Items.FindByText(country));
                        if (ddlbeat.SelectedIndex != 0)
                        {
                            ddlbeat.Items.FindByText(country).Selected = true;
                        }
                    }
                    if (dtpatta.Rows.Count > 0)
                    {
                        DropDownList ddlpig = (e.Item.FindControl("ddlpig") as DropDownList);
                        ddlpig.DataSource = dtpatta;
                        ddlpig.DataTextField = "rofr_patta_name";
                        ddlpig.DataValueField = "rofr_patta_id";
                        ddlpig.DataBind();

                        //Add Default Item in the DropDownList.
                        ddlpig.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["PATTA_INAM_GOVT"].ToString();
                        ddlpig.SelectedIndex = ddlpig.Items.IndexOf(ddlpig.Items.FindByValue(country));
                        if (ddlpig.SelectedIndex != 0)
                        {
                            ddlpig.Items.FindByText(country).Selected = true;
                        }
                    }
                    if (dtdry.Rows.Count > 0)
                    {
                        DropDownList ddldl = (e.Item.FindControl("ddldl") as DropDownList);
                        ddldl.DataSource = dtdry;
                        ddldl.DataTextField = "Land_type";
                        ddldl.DataValueField = "Land_type_id";
                        ddldl.DataBind();

                        //Add Default Item in the DropDownList.
                        ddldl.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["DRY_ID_ONE_CROP_TWO_CROP"].ToString();
                        ddldl.SelectedIndex = ddldl.Items.IndexOf(ddldl.Items.FindByValue(country));
                        if (ddldl.SelectedIndex != 0)
                        {
                            ddldl.Items.FindByText(country).Selected = true;
                        }
                    }
                    if (dtcropseason.Rows.Count > 0)
                    {
                        DropDownList ddlkr = (e.Item.FindControl("ddlkr") as DropDownList);
                        ddlkr.DataSource = dtcropseason;
                        ddlkr.DataTextField = "crop_type";
                        ddlkr.DataValueField = "crop_type_id";
                        ddlkr.DataBind();

                        //Add Default Item in the DropDownList.
                        ddlkr.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["KHARIFF_RABI"].ToString();
                        ddlkr.SelectedIndex = ddlkr.Items.IndexOf(ddlkr.Items.FindByValue(country));
                        if (ddlkr.SelectedIndex != 0)
                        {
                            ddlkr.Items.FindByText(country).Selected = true;
                        }
                    }
                    if (dtcropmnth.Rows.Count > 0)
                    {
                        DropDownList ddlmoc = (e.Item.FindControl("ddlmoc") as DropDownList);
                        ddlmoc.DataSource = dtcropmnth;
                        ddlmoc.DataTextField = "month_eng";
                        ddlmoc.DataValueField = "sno";
                        ddlmoc.DataBind();

                        //Add Default Item in the DropDownList.
                        ddlmoc.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["DRY_ID_ONE_CROP_TWO_CROP"].ToString();
                        ddlmoc.SelectedIndex = ddlmoc.Items.IndexOf(ddlmoc.Items.FindByValue(country));
                        if (ddlmoc.SelectedIndex != 0)
                        {
                            ddlmoc.Items.FindByText(country).Selected = true;
                        }
                    }
                    if (dtlandclass.Rows.Count > 0)
                    {
                        DropDownList ddllandclassfication = (e.Item.FindControl("landclassfication") as DropDownList);
                        ddllandclassfication.DataSource = dtlandclass;
                        ddllandclassfication.DataTextField = "Land_Classification_Name";
                        ddllandclassfication.DataValueField = "Land_Classification_Code";
                        ddllandclassfication.DataBind();

                        //Add Default Item in the DropDownList.
                        ddllandclassfication.Items.Insert(0, new ListItem("select"));

                        //Select the Country of Customer in DropDownList.
                        string country = (e.Item.DataItem as DataRowView)["Landclassification"].ToString();
                        ddllandclassfication.SelectedIndex = ddllandclassfication.Items.IndexOf(ddllandclassfication.Items.FindByValue(country));
                        if (ddllandclassfication.SelectedIndex != 0)
                        {
                            ddllandclassfication.Items.FindByText(country).Selected = true;
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

        protected void Linkview_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)(sender);
                string Id = btn.CommandArgument;
                Session["Id"] = Id;
                string url = "VIEWDLC.aspx";
                string s = "window.open('" + url + "', 'popup_window', 'width=1350,height=660,resizable=yes');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Linkview1_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)(sender);
                string Id = btn.CommandArgument;
                Session["IMAGEId"] = Id;
                string url = "VIEWIMAGE.aspx";
                string s = "window.open('" + url + "', 'popup_window', 'width=500,height=500,resizable=yes');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

    }
}
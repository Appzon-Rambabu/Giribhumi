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
    public partial class UploadMultipleDlc : System.Web.UI.Page
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
                    btn_submit.Visible = false;
                    lblnote.Visible = false;
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                    panlimage.Visible = false;
                    chkAll.Visible = false;
                    btn_Image.Visible = false;
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));


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
                ddl_mandal.DataTextField = "DLCDATE";
                ddl_mandal.DataValueField = "DLCDATE";
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
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_mandal.ClearSelection();

                    ddl_district.ClearSelection();
                    Repeater1.DataBind();
                    btn_submit.Visible = false;
                    lblnote.Visible = false;
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                    panlimage.Visible = false;
                    btn_Image.Visible = false;
                    chkAll.Visible = false;
                    chkAll.Checked = false;
                    select_records.Visible = false;
                    DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindDistrict(dtMandal);
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

                                Repeater1.DataSource = null;

                                Repeater1.DataBind();
                                btn_submit.Visible = false;
                                lblnote.Visible = false;
                                //Panel_Image.Visible = false;
                                //Panel_Uploaddlc.Visible = false;
                                panlimage.Visible = false;
                                btn_Image.Visible = false;
                                chkAll.Visible = false;
                                chkAll.Checked = false;
                                select_records.Visible = false;
                                //  DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenmandalDetails(ddl_district.SelectedValue, (string)(Session["username"]));
                                DataTable dtMandal = Multipledlcbal.GetbenmandalDetails(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, (string)(Session["username"]));
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
                    chkAll.Checked = false;
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
                if (ddl_mandal.SelectedItem.Text != "Select")
                {

                    Repeater1.DataSource = null;
                    //ddl_mandal.ClearSelection();

                    Repeater1.DataBind();
                    btn_submit.Visible = false;
                    lblnote.Visible = false;
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                    panlimage.Visible = false;
                    btn_Image.Visible = false;
                    chkAll.Visible = false;
                    select_records.Visible = false;

                    BindCount(ddl_district.SelectedValue, true, "", ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
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


                DataTable dt = Multipledlcbal.GetForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal);

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();

                    btn_submit.Visible = false;
                    lblnote.Visible = true;
                    lblnote.Text = "Note: Please Enter All Mandatory Fields(*)";
                    panlimage.Visible = true;
                    btn_Image.Visible = false;
                    chkAll.Visible = true;
                    chkAll.Checked = false;
                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {
                        Label id = itemEquipment.FindControl("Label4") as Label;
                        id.Visible = false;
                        Label Dlc = itemEquipment.FindControl("txtDlc") as Label;
                        Dlc.Visible = false;
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
                        BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
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
                        chkAll.Checked = false;
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


                DataTable dt = Multipledlcbal.GetForestBeneficiaryDetailscountValidate(district, Itda, mandal);

                if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                {
                    chkAll.Checked = false;
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
                    CheckBox chk = (CheckBox)itemEquipment.FindControl("Update_dlc");
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
                        TextBox RPD = itemEquipment.FindControl("txt_RPD") as TextBox;
                        if (CNO.Text == "")
                        {
                            MANDA = true;
                            break;
                        }
                        if (RPD.Text == "")
                        {
                            MANDA = true;
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
                                    addbeneficiaryobj.Imagepath = "";
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
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please enter Pattadaar Name ')", true);
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
                            BindCount(ddl_district.SelectedValue, false, ddl_records.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
                            BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
                        }

                    }
                    txt_dlc.Text = string.Empty;
                    chkAll.Checked = false;
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
                        TextBox pattainamgovt = itemEquipment.FindControl("txt_PIG") as TextBox;
                        TextBox holidingnature = itemEquipment.FindControl("txt_HN") as TextBox;
                        TextBox extentplotarea = itemEquipment.FindControl("txt_EPA") as TextBox;
                        TextBox pattadarname = itemEquipment.FindControl("txt_RPN") as TextBox;
                        TextBox cultivatorname = itemEquipment.FindControl("txt_CNA") as TextBox;


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
                        if (pattano.Text == "")
                        {
                            mandatoryfalg = true;
                            break;
                        }
                        if (pattainamgovt.Text == "")
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
                            TextBox PIG = itemEquipment.FindControl("txt_PIG") as TextBox;
                            TextBox WT = itemEquipment.FindControl("txt_WT") as TextBox;
                            TextBox DRYIC = itemEquipment.FindControl("txt_DI") as TextBox;
                            TextBox WS = itemEquipment.FindControl("txt_WS") as TextBox;
                            TextBox EI = itemEquipment.FindControl("txt_EI") as TextBox;
                            TextBox RPN = itemEquipment.FindControl("txt_RPN") as TextBox;
                            TextBox RPD = itemEquipment.FindControl("txt_RPD") as TextBox;
                            TextBox CN = itemEquipment.FindControl("txt_CNA") as TextBox;
                            TextBox EUC = itemEquipment.FindControl("txt_EUC") as TextBox;
                            TextBox HN = itemEquipment.FindControl("txt_HN") as TextBox;
                            TextBox LUTC = itemEquipment.FindControl("txt_LUTC") as TextBox;
                            TextBox LUE = itemEquipment.FindControl("txt_LUE") as TextBox;
                            TextBox LUNSA = itemEquipment.FindControl("txt_LUNSA") as TextBox;
                            TextBox KR = itemEquipment.FindControl("txt_KR") as TextBox;
                            TextBox MOC = itemEquipment.FindControl("txt_MOC") as TextBox;
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
                            TextBox AADHAR_NO = itemEquipment.FindControl("AADHAR_NO") as TextBox;
                            //IPAddress = GetIPAddress();
                            //MacAddress = GetMAC();

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
                            dr["PATTA_INAMGOVT"] = PIG.Text;
                            dr["Water_Tax"] = WT.Text;
                            dr["DRYID_ONECROP_TWO_CROP"] = DRYIC.Text;
                            dr["WATER_SOURCE"] = WS.Text;
                            dr["EXTENT_IRRIGATED"] = EI.Text;
                            dr["ROFR_PATTANO"] = RPN.Text;
                            dr["ROFR_PATTADAAR"] = RPD.Text;
                            dr["CULTIVATOR_NAME"] = CN.Text;
                            dr["EXTENT_UNDER_CULTIVATOR"] = EUC.Text;
                            dr["HOLDING_NATURE"] = HN.Text;
                            dr["TYPE_CODE"] = LUTC.Text;
                            dr["EXTENT"] = LUE.Text;
                            dr["NET_SOWN_AREA"] = LUNSA.Text;
                            dr["KHARIFF_RABI"] = KR.Text;
                            dr["MONTH_OF_CULTIVATION"] = MOC.Text;
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
                            dr["Aadhaar_NO"] = AADHAR_NO.Text;
                            dr["Id"] = id.Text;
                            dr["IsEdit"] = edit;
                            dr["Status"] = "C";
                            dr["IsApproved"] = isapproved;
                            dr["IPADDRESS"] = IPAddress;
                            dr["MACADDRESS"] = MacAddress;


                            dtUpdateDetails.Rows.Add(dr);

                        }
                        else if (chk.Checked == false)
                        {

                        }




                    }
                    BeneficiaryDetailsobj.UpdateForestMasterDetails = dtUpdateDetails;
                    if (!string.IsNullOrEmpty((string)(Session["username"])))
                    {
                        ProjectRofrBAL.GetMasterDetails.UpdateValidateBeneficiaryDetails(BeneficiaryDetailsobj, (string)(Session["username"]));
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficiary Details Updated Successfully')", true);
                        if (ddl_district.SelectedItem.Text != "Select")
                        {
                            if (ddl_records.SelectedValue != "0")
                            {
                                // BindCount(ddl_district.SelectedValue, false, ddl_records.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
                                // BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter mandatory fields for all checked records!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
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
                        TextBox pattainamgovt = itemEquipment.FindControl("txt_PIG") as TextBox;
                        TextBox holidingnature = itemEquipment.FindControl("txt_HN") as TextBox;
                        TextBox extentplotarea = itemEquipment.FindControl("txt_EPA") as TextBox;
                        TextBox pattadarname = itemEquipment.FindControl("txt_RPN") as TextBox;
                        TextBox cultivatorname = itemEquipment.FindControl("txt_CNA") as TextBox;


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
                        if (pattano.Text == "")
                        {
                            pattano.BorderColor = Color.Red;
                        }
                        else if (pattano.Text != "")
                        {
                            if (pattano.BorderColor == Color.Red)
                                pattano.BorderColor = Color.LightGray;
                        }
                        if (pattainamgovt.Text == "")
                        {
                            pattainamgovt.BorderColor = Color.Red;
                        }
                        else if (pattainamgovt.Text != "")
                        {
                            if (pattainamgovt.BorderColor == Color.Red)
                                pattainamgovt.BorderColor = Color.LightGray;
                        }
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
                    DataTable dtMandals = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Mandal", ddl_district.SelectedValue, "NULL", "");
                    DataTable dtvillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "village", ddl_district.SelectedValue, "NULL", "NULL");
                    DataTable dtdivisions = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Division", ddl_district.SelectedValue, "", "");
                    DataTable dtranges = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Range", ddl_district.SelectedValue, "NULL", "");
                    DataTable dtbeats = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "Beat", ddl_district.SelectedValue, "NULL", "NULL");
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
    }
}
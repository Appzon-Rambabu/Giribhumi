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
    public partial class addadhaar : System.Web.UI.Page
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


        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtbeneficiareies = new DataTable();
                dtbeneficiareies = searchBindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format(" ROFR_PATTADAAR LIKE '%{0}%'", txtSearch.Text);
                    Repeater1.DataSource = DV;

                    Repeater1.DataBind();
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


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetadharForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal, village);

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();

                    btn_submit.Visible = true;
                    lblnote.Visible = true;
                    lblnote.Text = "Note: Please Enter All Mandatory Fields(*)";
                    panlimage.Visible = false;
                    btn_Image.Visible = false;
                    chkAll.Visible = true;

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


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetadharForestBeneficiaryDetailscountValidate(district, Itda, mandal, village);

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

                // Changeclour();

                if (mandatoryfalg == false)
                {
                    BeneficiaryDetails BeneficiaryDetailsobj = new BeneficiaryDetails();
                    DataTable dtUpdateDetails = new DataTable();
                    dtUpdateDetails.Columns.Add("District_Code");
                    dtUpdateDetails.Columns.Add("District");
                    dtUpdateDetails.Columns.Add("Mandal_Code");
                    dtUpdateDetails.Columns.Add("Mandal");

                    dtUpdateDetails.Columns.Add("Gram_Panchayat");
                    dtUpdateDetails.Columns.Add("Village_Code");
                    dtUpdateDetails.Columns.Add("Village");

                    dtUpdateDetails.Columns.Add("Habitation");

                    dtUpdateDetails.Columns.Add("Compartment_No");

                    dtUpdateDetails.Columns.Add("ExtentPlotArea");

                    dtUpdateDetails.Columns.Add("ROFR_PATTANO");
                    dtUpdateDetails.Columns.Add("ROFR_PATTADAAR");



                    dtUpdateDetails.Columns.Add("Aadhaar_NO");

                    dtUpdateDetails.Columns.Add("Id");
                    dtUpdateDetails.Columns.Add("IPADDRESS");
                    dtUpdateDetails.Columns.Add("MACADDRESS");
                    dtUpdateDetails.Columns.Add("IsEdit");
                    dtUpdateDetails.Columns.Add("IsApproved");
                    dtUpdateDetails.Columns.Add("Status");


                    dtUpdateDetails.Columns.Add("BankName");
                    dtUpdateDetails.Columns.Add("BankAccountNo");
                    dtUpdateDetails.Columns.Add("IfscCode");




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

                            TextBox HAB = itemEquipment.FindControl("txt_HAB") as TextBox;


                            TextBox CNO = itemEquipment.FindControl("txt_CNO") as TextBox;

                            TextBox EPA = itemEquipment.FindControl("txt_EPA") as TextBox;



                            TextBox RPN = itemEquipment.FindControl("txt_RPN") as TextBox;
                            TextBox RPD = itemEquipment.FindControl("txt_RPD") as TextBox;



                            TextBox AADHAR_NO = itemEquipment.FindControl("AADHAR_NO") as TextBox;
                            //IPAddress = GetIPAddress();
                            //MacAddress = GetMAC();


                            TextBox BANKNAME = itemEquipment.FindControl("txt_Bank") as TextBox;
                            TextBox BACKACCNO = itemEquipment.FindControl("txt_Bankac") as TextBox;
                            TextBox IFSC = itemEquipment.FindControl("txt_ifsc") as TextBox;

                            DataRow dr = dtUpdateDetails.NewRow();
                            dr["Mandal_Code"] = MNC.SelectedValue;
                            dr["Mandal"] = MN.SelectedItem.Text;
                            dr["Gram_Panchayat"] = GPN.Text;
                            dr["Village_Code"] = VNC.SelectedValue;
                            dr["Village"] = VN.SelectedItem.Text;

                            dr["Habitation"] = HAB.Text;

                            dr["Compartment_No"] = CNO.Text;

                            dr["ExtentPlotArea"] = EPA.Text;

                            dr["ROFR_PATTANO"] = RPN.Text;
                            dr["ROFR_PATTADAAR"] = RPD.Text;


                            dr["Aadhaar_NO"] = AADHAR_NO.Text;
                            dr["Id"] = id.Text;
                            dr["IsEdit"] = edit;
                            dr["Status"] = "C";
                            dr["IsApproved"] = isapproved;
                            dr["IPADDRESS"] = IPAddress;
                            dr["MACADDRESS"] = MacAddress;


                            dr["BankName"] = BANKNAME.Text;
                            dr["BankAccountNo"] = BACKACCNO.Text;
                            dr["IfscCode"] = IFSC.Text;


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
                            ProjectRofrBAL.GetMasterDetails.Update14COLUMNSBeneficiaryDetails(BeneficiaryDetailsobj, (string)(Session["username"]));
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
                    TextBox txt_HAB1 = item.FindControl("txt_HAB") as TextBox;
                    TextBox txt_CNO1 = item.FindControl("txt_CNO") as TextBox;
                    TextBox txt_EPA1 = item.FindControl("txt_EPA") as TextBox;
                    TextBox txt_RPN1 = item.FindControl("txt_RPN") as TextBox;
                    TextBox txt_RPD1 = item.FindControl("txt_RPD") as TextBox;
                    TextBox AADHAR_NO1 = item.FindControl("AADHAR_NO") as TextBox;
                    TextBox txt_Bank1 = item.FindControl("txt_Bank") as TextBox;
                    TextBox txt_Bankac1 = item.FindControl("txt_Bankac") as TextBox;
                    TextBox txt_ifsc1 = item.FindControl("txt_ifsc") as TextBox;
                    mandalas1.BackColor = Color.White;
                    grampanchat1.BackColor = Color.White;
                    village1.BackColor = Color.White;
                    txt_HAB1.BackColor = Color.White;
                    txt_CNO1.BackColor = Color.White;
                    txt_EPA1.BackColor = Color.White;
                    txt_RPN1.BackColor = Color.White;
                    txt_RPD1.BackColor = Color.White;
                    AADHAR_NO1.BackColor = Color.White;
                    txt_Bank1.BackColor = Color.White;
                    txt_Bankac1.BackColor = Color.White;
                    txt_ifsc1.BackColor = Color.White;
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
                    TextBox txt_HAB = currentrow.FindControl("txt_HAB") as TextBox;
                    TextBox txt_CNO = currentrow.FindControl("txt_CNO") as TextBox;
                    TextBox txt_EPA = currentrow.FindControl("txt_EPA") as TextBox;
                    TextBox txt_RPN = currentrow.FindControl("txt_RPN") as TextBox;
                    TextBox txt_RPD = currentrow.FindControl("txt_RPD") as TextBox;
                    TextBox AADHAR_NO = currentrow.FindControl("AADHAR_NO") as TextBox;
                    TextBox txt_Bank = currentrow.FindControl("txt_Bank") as TextBox;
                    TextBox txt_Bankac = currentrow.FindControl("txt_Bankac") as TextBox;
                    TextBox txt_ifsc = currentrow.FindControl("txt_ifsc") as TextBox;
                    mandalas.BackColor = Color.LightBlue;
                    village.BackColor = Color.LightBlue;
                    grampanchat.BackColor = Color.LightBlue;
                    txt_HAB.BackColor = Color.LightBlue;
                    txt_CNO.BackColor = Color.LightBlue;
                    txt_EPA.BackColor = Color.LightBlue;
                    txt_RPN.BackColor = Color.LightBlue;
                    txt_RPD.BackColor = Color.LightBlue;
                    AADHAR_NO.BackColor = Color.LightBlue;
                    txt_Bank.BackColor = Color.LightBlue;
                    txt_Bankac.BackColor = Color.LightBlue;
                    txt_ifsc.BackColor = Color.LightBlue;
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

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                foreach (RepeaterItem item in Repeater1.Items)
                {
                    HtmlTableRow row = (HtmlTableRow)item.FindControl("row");
                    row.Attributes["style"] = "background-color:white";
                    TextBox grampanchat1 = item.FindControl("txt_GPN") as TextBox;
                    DropDownList village1 = item.FindControl("ddlvillages") as DropDownList;
                    TextBox txt_HAB1 = item.FindControl("txt_HAB") as TextBox;
                    TextBox txt_CNO1 = item.FindControl("txt_CNO") as TextBox;
                    TextBox txt_EPA1 = item.FindControl("txt_EPA") as TextBox;
                    TextBox txt_RPN1 = item.FindControl("txt_RPN") as TextBox;
                    TextBox txt_RPD1 = item.FindControl("txt_RPD") as TextBox;
                    TextBox AADHAR_NO1 = item.FindControl("AADHAR_NO") as TextBox;
                    TextBox txt_Bank1 = item.FindControl("txt_Bank") as TextBox;
                    TextBox txt_Bankac1 = item.FindControl("txt_Bankac") as TextBox;
                    TextBox txt_ifsc1 = item.FindControl("txt_ifsc") as TextBox;
                    grampanchat1.BackColor = Color.White;
                    village1.BackColor = Color.White;
                    txt_HAB1.BackColor = Color.White;
                    txt_CNO1.BackColor = Color.White;
                    txt_EPA1.BackColor = Color.White;
                    txt_RPN1.BackColor = Color.White;
                    txt_RPD1.BackColor = Color.White;
                    AADHAR_NO1.BackColor = Color.White;
                    txt_Bank1.BackColor = Color.White;
                    txt_Bankac1.BackColor = Color.White;
                    txt_ifsc1.BackColor = Color.White;
                }

                RepeaterItem selectitem = (RepeaterItem)(((LinkButton)e.CommandSource).NamingContainer);
                HtmlTableRow currentrow = (HtmlTableRow)selectitem.FindControl("row");
                currentrow.Attributes["style"] = "background-color:yellow";
                TextBox grampanchat = currentrow.FindControl("txt_GPN") as TextBox;
                DropDownList village = currentrow.FindControl("ddlvillages") as DropDownList;
                TextBox txt_HAB = currentrow.FindControl("txt_HAB") as TextBox;
                TextBox txt_CNO = currentrow.FindControl("txt_CNO") as TextBox;
                TextBox txt_EPA = currentrow.FindControl("txt_EPA") as TextBox;
                TextBox txt_RPN = currentrow.FindControl("txt_RPN") as TextBox;
                TextBox txt_RPD = currentrow.FindControl("txt_RPD") as TextBox;
                TextBox AADHAR_NO = currentrow.FindControl("AADHAR_NO") as TextBox;
                TextBox txt_Bank = currentrow.FindControl("txt_Bank") as TextBox;
                TextBox txt_Bankac = currentrow.FindControl("txt_Bankac") as TextBox;
                TextBox txt_ifsc = currentrow.FindControl("txt_ifsc") as TextBox;
                village.BackColor = Color.LightBlue;
                grampanchat.BackColor = Color.LightBlue;
                txt_HAB.BackColor = Color.LightBlue;
                txt_CNO.BackColor = Color.LightBlue;
                txt_EPA.BackColor = Color.LightBlue;
                txt_RPN.BackColor = Color.LightBlue;
                txt_RPD.BackColor = Color.LightBlue;
                AADHAR_NO.BackColor = Color.LightBlue;
                txt_Bank.BackColor = Color.LightBlue;
                txt_Bankac.BackColor = Color.LightBlue;
                txt_ifsc.BackColor = Color.LightBlue;
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






                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
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
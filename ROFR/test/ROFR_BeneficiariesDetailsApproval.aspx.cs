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
using ROFR.helper;



namespace ROFR.test
{
    public partial class ROFR_BeneficiariesDetailsApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if ((string)(Session["Director"]) == "DIRECTOR")
                    {
                        po.Visible = false;
                        Director.Visible = true;
                        BindDistrict();
                    }
                    else
                    {
                        Director.Visible = false;
                        po.Visible = true;
                        BindItda();
                        ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                    }

                    // BindDistrict();
                    Session["chkditems"] = null;
                    select_records.Visible = false;
                    btn_submit.Visible = false;
                    chkAll.Visible = false;
                    btn_Reject.Visible = false;

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        private void BindDistrict()
        {
            try
            {

                DataTable dtDistricts = RevenueDistrictsBAL.RevenueDistricts.GetCurdForestDivisionMasterAnalysis((string)(Session["username"]), "Division", "", "");
                if (dtDistricts.Rows.Count > 0)
                {
                    ddl_district1.DataSource = dtDistricts;
                    ddl_district1.DataTextField = "DISTRICT_NAME";
                    ddl_district1.DataValueField = "DISTRICT_CODE";
                    ddl_district1.DataBind();
                    ddl_district1.Items.Insert(0, new ListItem("Select", "0"));
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
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
                ddl_village.DataValueField = "VILLAGE_NAME";
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

        protected void ddldistrict1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_district1.SelectedItem.Text != "Select")
                {
                    Session["chkditems"] = null;
                    BindDirectorCount(ddl_district1.SelectedValue, true, "");
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


        public void BindDirectorCount(string district, bool FLAG, string VALUE)
        {
            try
            {
                string recordvalue = string.Empty;

                Repeater1.DataSource = null;

                Repeater1.DataBind();
                string username = (string)(Session["username"]);
                var regexItem = new Regex("_");
                string endname = string.Empty;

                if (regexItem.IsMatch(username))
                {
                    var range = username.IndexOf('_');

                    string d = username.Substring(0, range);
                    endname = username.Substring(username.LastIndexOf('_') + 1);
                }

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiaryDetailscountapproval(district, (string)(Session["Director"]), "", "", "");

                if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                {
                    string k = string.Empty;
                    if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                    {
                        select_records.Visible = true;
                        ListItemCollection list = new ListItemCollection();
                        int rowscount = Convert.ToInt32(dt.Rows[0]["count"].ToString());

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
                        ddl_records1.DataSource = list;
                        ddl_records1.DataBind();
                        if (FLAG == true)
                        {
                            ddl_records1.Items.Insert(0, new ListItem("Select", "0"));
                        }
                        else
                        {
                            ddl_records1.Items.Insert(0, new ListItem("Select", "0"));
                            if (recordvalue != string.Empty)
                            {
                                ddl_records1.SelectedValue = recordvalue;
                            }
                            else
                            {
                                ddl_records1.SelectedValue = k;
                            }
                        }
                        lbl_msg.Visible = false;
                    }
                    else
                    {
                        select_records.Visible = false;
                        btn_submit.Visible = false;
                        chkAll.Visible = false;
                        btn_Reject.Visible = false;
                        lbl_msg.Visible = true;
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
                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;
                    //panlimage.Visible = false;
                    //btn_Image.Visible = false;
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

        protected void BindDirectorData(string district)
        {
            try
            {
                string a = ddl_records1.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);

                Repeater1.DataSource = null;

                Repeater1.DataBind();
                string username = (string)(Session["username"]);
                var regexItem = new Regex("_");
                string endname = string.Empty;

                if (regexItem.IsMatch(username))
                {
                    var userrange = username.IndexOf('_');

                    string d = username.Substring(0, userrange);
                    endname = username.Substring(username.LastIndexOf('_') + 1);
                }


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiaryDetailsapproval(district, start, end, (string)(Session["Director"]), "", "", "");

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();
                    btn_submit.Visible = true;
                    chkAll.Visible = true;
                    btn_Reject.Visible = true;
                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {
                        Label id = itemEquipment.FindControl("Label4") as Label;
                        id.Visible = false;
                        Label MNC = itemEquipment.FindControl("lbl_MNC") as Label;
                        MNC.Visible = false;
                        Label VNC = itemEquipment.FindControl("lbl_VNC") as Label;
                        VNC.Visible = false;
                        Label FDC = itemEquipment.FindControl("lbl_FDC") as Label;
                        FDC.Visible = false;
                        Label FRC = itemEquipment.FindControl("lbl_FRC") as Label;
                        FRC.Visible = false;
                        Label FBC = itemEquipment.FindControl("lbl_FBC") as Label;
                        FBC.Visible = false;
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
                    lbl_msg.Visible = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found!')", true);
                    select_records.Visible = false;
                    btn_submit.Visible = false;
                    chkAll.Visible = false;
                    btn_Reject.Visible = false;
                    lbl_msg.Visible = true;
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
                string username = (string)(Session["username"]);
                var regexItem = new Regex("_");
                string endname = string.Empty;

                if (regexItem.IsMatch(username))
                {
                    var userrange = username.IndexOf('_');

                    string d = username.Substring(0, userrange);
                    endname = username.Substring(username.LastIndexOf('_') + 1);
                }


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiaryDetailsapproval(district, start, end, (string)(Session["Director"]), Itda, mandal, village);

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();
                    btn_submit.Visible = true;
                    chkAll.Visible = true;
                    btn_Reject.Visible = true;
                    foreach (RepeaterItem itemEquipment in Repeater1.Items)
                    {
                        Label id = itemEquipment.FindControl("Label4") as Label;
                        id.Visible = false;
                        Label MNC = itemEquipment.FindControl("lbl_MNC") as Label;
                        MNC.Visible = false;
                        Label VNC = itemEquipment.FindControl("lbl_VNC") as Label;
                        VNC.Visible = false;
                        Label FDC = itemEquipment.FindControl("lbl_FDC") as Label;
                        FDC.Visible = false;
                        Label FRC = itemEquipment.FindControl("lbl_FRC") as Label;
                        FRC.Visible = false;
                        Label FBC = itemEquipment.FindControl("lbl_FBC") as Label;
                        FBC.Visible = false;
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
                    lbl_msg.Visible = false;
                }
                else
                {
                    select_records.Visible = false;
                    btn_submit.Visible = false;
                    chkAll.Visible = false;
                    btn_Reject.Visible = false;
                    lbl_msg.Visible = true;
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

        protected void ddlrecords1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_district1.SelectedItem.Text != "Select")
                {
                    if (ddl_records1.SelectedValue != "0")
                    {
                        BindDirectorData(ddl_district1.SelectedValue);
                    }
                    else
                    {
                        Repeater1.DataSource = null;

                        Repeater1.DataBind();
                        btn_submit.Visible = false;
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
                string username = (string)(Session["username"]);
                var regexItem = new Regex("_");
                string endname = string.Empty;

                if (regexItem.IsMatch(username))
                {
                    var range = username.IndexOf('_');

                    string d = username.Substring(0, range);
                    endname = username.Substring(username.LastIndexOf('_') + 1);
                }

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiaryDetailscountapproval(district, (string)(Session["Director"]), Itda, mandal, village);
                if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                {
                    string k = string.Empty;
                    if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                    {
                        select_records.Visible = true;
                        ListItemCollection list = new ListItemCollection();
                        int rowscount = Convert.ToInt32(dt.Rows[0]["count"].ToString());

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
                        lbl_msg.Visible = false;
                    }
                    else
                    {
                        select_records.Visible = false;
                        btn_submit.Visible = false;
                        chkAll.Visible = false;
                        btn_Reject.Visible = false;
                        lbl_msg.Visible = true;
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

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {
                bool Atleastoneselectrow = false;
                string IPAddress = (string)(Session["IPAddress"]);
                string MacAddress = (string)(Session["MacAddress"]);
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
                int i = 0;
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {
                    //to get the dropdown of each line
                    CheckBox chk = (CheckBox)itemEquipment.FindControl("chkSelect");
                    // chk.Attributes.Add("style", "background-color:Green;");
                    if (chk.Checked == true)
                    {
                        bool edit = true;
                        bool isapproved = true;
                        Atleastoneselectrow = true;
                        Label id = itemEquipment.FindControl("Label4") as Label;
                        Label MNC = itemEquipment.FindControl("lbl_MNC") as Label;
                        Label MN = itemEquipment.FindControl("txt_MN") as Label;
                        Label GPN = itemEquipment.FindControl("txt_GPN") as Label;
                        Label VNC = itemEquipment.FindControl("lbl_VNC") as Label;
                        Label VN = itemEquipment.FindControl("txt_VN") as Label;
                        Label HABC = itemEquipment.FindControl("txt_HABC") as Label;
                        Label HAB = itemEquipment.FindControl("txt_HAB") as Label;
                        Label FDC = itemEquipment.FindControl("lbl_FDC") as Label;
                        Label FDN = itemEquipment.FindControl("txt_FDN") as Label;
                        Label FRC = itemEquipment.FindControl("lbl_FRC") as Label;
                        Label FRN = itemEquipment.FindControl("txt_FRN") as Label;
                        Label FBC = itemEquipment.FindControl("lbl_FBC") as Label;
                        Label FBN = itemEquipment.FindControl("txt_FBN") as Label;
                        Label FB = itemEquipment.FindControl("txt_FBL") as Label;
                        Label CNO = itemEquipment.FindControl("txt_CNO") as Label;
                        Label PN = itemEquipment.FindControl("txt_PN") as Label;
                        Label EPA = itemEquipment.FindControl("txt_EPA") as Label;
                        Label EUL = itemEquipment.FindControl("txt_EUL") as Label;
                        Label ECL = itemEquipment.FindControl("txt_ECL") as Label;
                        Label PIG = itemEquipment.FindControl("txt_PIG") as Label;
                        Label WT = itemEquipment.FindControl("txt_WT") as Label;
                        Label DRYIC = itemEquipment.FindControl("txt_DI") as Label;
                        Label WS = itemEquipment.FindControl("txt_WS") as Label;
                        Label EI = itemEquipment.FindControl("txt_EI") as Label;
                        Label RPN = itemEquipment.FindControl("txt_RPN") as Label;
                        Label RPD = itemEquipment.FindControl("txt_RPD") as Label;
                        Label CN = itemEquipment.FindControl("txt_CNA") as Label;
                        Label EUC = itemEquipment.FindControl("txt_EUC") as Label;
                        Label HN = itemEquipment.FindControl("txt_HN") as Label;
                        Label LUTC = itemEquipment.FindControl("txt_LUTC") as Label;
                        Label LUE = itemEquipment.FindControl("txt_LUE") as Label;
                        Label LUNSA = itemEquipment.FindControl("txt_LUNSA") as Label;
                        Label KR = itemEquipment.FindControl("txt_KR") as Label;
                        Label MOC = itemEquipment.FindControl("txt_MOC") as Label;
                        Label CROP = itemEquipment.FindControl("txt_Crop") as Label;
                        Label ES = itemEquipment.FindControl("txt_ES") as Label;
                        Label EM = itemEquipment.FindControl("txt_EM") as Label;
                        Label ET = itemEquipment.FindControl("txt_ET") as Label;
                        Label ELWS = itemEquipment.FindControl("txt_ELWS") as Label;
                        Label ELC = itemEquipment.FindControl("txt_ELCO") as Label;
                        Label ELCT = itemEquipment.FindControl("txt_ELCTH") as Label;
                        Label CY = itemEquipment.FindControl("txt_CY") as Label;
                        Label VRR = itemEquipment.FindControl("txt_VRE") as Label;
                        Label TR = itemEquipment.FindControl("txt_TRE") as Label;
                        Label REMARKS = itemEquipment.FindControl("txt_RE") as Label;
                        Label AADHAR_NO = itemEquipment.FindControl("AADHAR_NO") as Label;

                        Label Dlcdate = itemEquipment.FindControl("txt_dlcdate") as Label;
                        Label landclass = itemEquipment.FindControl("txtland") as Label;
                        Label BANKNAME = itemEquipment.FindControl("txt_Bank") as Label;
                        Label BACKACCNO = itemEquipment.FindControl("txt_Bankac") as Label;
                        Label IFSC = itemEquipment.FindControl("txt_ifsc") as Label;
                        Label pattadarfathername = itemEquipment.FindControl("txt_Fathername") as Label;

                        DataRow dr = dtUpdateDetails.NewRow();
                        dr["Mandal_Code"] = MNC.Text;
                        dr["Mandal"] = MN.Text;
                        dr["Gram_Panchayat"] = GPN.Text;
                        dr["Village_Code"] = VNC.Text;
                        dr["Village"] = VN.Text;
                        dr["HabitationCode"] = HABC.Text;
                        dr["Habitation"] = HAB.Text;
                        dr["Forest_DivisionCode"] = FDC.Text;
                        dr["Forest_Division"] = FDN.Text;
                        dr["Forest_RangeCode"] = FRC.Text;
                        dr["Forest_Range"] = FRN.Text;
                        dr["Forest_BeatCode"] = FBC.Text;
                        dr["Forest_Beat"] = FBN.Text;
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
                        dr["IPADDRESS"] = MOC.Text;
                        dr["MACADDRESS"] = CROP.Text;
                        dr["Id"] = id.Text;
                        dr["IsEdit"] = edit;
                        if ((string)(Session["Director"]) == "DIRECTOR")
                        {
                            dr["IsApproved"] = isapproved;
                            dr["Status"] = "D";
                        }
                        else
                        {
                            dr["IsApproved"] = isapproved;
                            dr["Status"] = "P";
                        }
                        dr["IPADDRESS"] = IPAddress;
                        dr["MACADDRESS"] = MacAddress;

                        dr["Dlc_date"] = Dlcdate.Text;
                        dr["Landclassification"] = landclass.Text;
                        dr["BankName"] = BANKNAME.Text;
                        dr["BankAccountNo"] = BACKACCNO.Text;
                        dr["IfscCode"] = IFSC.Text;
                        dr["Father_Name"] = pattadarfathername.Text;
                        dtUpdateDetails.Rows.Add(dr);

                        i++;
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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficiary Details Approve Successfully')", true);
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
                if ((string)(Session["Director"]) == "DIRECTOR")
                {
                    if (ddl_district1.SelectedItem.Text != "Select")
                    {
                        if (ddl_records1.SelectedValue != "0")
                        {
                            BindDirectorCount(ddl_district1.SelectedValue, false, ddl_records.SelectedValue);
                            BindDirectorData(ddl_district1.SelectedValue);
                        }

                    }
                }
                else
                {
                    if (ddl_district.SelectedItem.Text != "Select")
                    {
                        if (ddl_records.SelectedValue != "0")
                        {
                            BindCount(ddl_district.SelectedValue, false, ddl_records.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                            BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
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


        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                bool Atleastoneselectrow = false;
                string IPAddress = (string)(Session["IPAddress"]);
                string MacAddress = (string)(Session["MacAddress"]);
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

                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {
                    //to get the dropdown of each line
                    CheckBox chk = (CheckBox)itemEquipment.FindControl("chkSelect");
                    // chk.Attributes.Add("style", "background-color:Green;");
                    if (chk.Checked == true)
                    {
                        bool edit = true;
                        bool isapproved = false;
                        Atleastoneselectrow = true;
                        Label id = itemEquipment.FindControl("Label4") as Label;
                        Label MNC = itemEquipment.FindControl("lbl_MNC") as Label;
                        Label MN = itemEquipment.FindControl("txt_MN") as Label;
                        Label GPN = itemEquipment.FindControl("txt_GPN") as Label;
                        Label VNC = itemEquipment.FindControl("lbl_VNC") as Label;
                        Label VN = itemEquipment.FindControl("txt_VN") as Label;
                        Label HABC = itemEquipment.FindControl("txt_HABC") as Label;
                        Label HAB = itemEquipment.FindControl("txt_HAB") as Label;
                        Label FDC = itemEquipment.FindControl("lbl_FDC") as Label;
                        Label FDN = itemEquipment.FindControl("txt_FDN") as Label;
                        Label FRC = itemEquipment.FindControl("lbl_FRC") as Label;
                        Label FRN = itemEquipment.FindControl("txt_FRN") as Label;
                        Label FBC = itemEquipment.FindControl("lbl_FBC") as Label;
                        Label FBN = itemEquipment.FindControl("txt_FBN") as Label;
                        Label FB = itemEquipment.FindControl("txt_FBL") as Label;
                        Label CNO = itemEquipment.FindControl("txt_CNO") as Label;
                        Label PN = itemEquipment.FindControl("txt_PN") as Label;
                        Label EPA = itemEquipment.FindControl("txt_EPA") as Label;
                        Label EUL = itemEquipment.FindControl("txt_EUL") as Label;
                        Label ECL = itemEquipment.FindControl("txt_ECL") as Label;
                        Label PIG = itemEquipment.FindControl("txt_PIG") as Label;
                        Label WT = itemEquipment.FindControl("txt_WT") as Label;
                        Label DRYIC = itemEquipment.FindControl("txt_DI") as Label;
                        Label WS = itemEquipment.FindControl("txt_WS") as Label;
                        Label EI = itemEquipment.FindControl("txt_EI") as Label;
                        Label RPN = itemEquipment.FindControl("txt_RPN") as Label;
                        Label RPD = itemEquipment.FindControl("txt_RPD") as Label;
                        Label CN = itemEquipment.FindControl("txt_CNA") as Label;
                        Label EUC = itemEquipment.FindControl("txt_EUC") as Label;
                        Label HN = itemEquipment.FindControl("txt_HN") as Label;
                        Label LUTC = itemEquipment.FindControl("txt_LUTC") as Label;
                        Label LUE = itemEquipment.FindControl("txt_LUE") as Label;
                        Label LUNSA = itemEquipment.FindControl("txt_LUNSA") as Label;
                        Label KR = itemEquipment.FindControl("txt_KR") as Label;
                        Label MOC = itemEquipment.FindControl("txt_MOC") as Label;
                        Label CROP = itemEquipment.FindControl("txt_Crop") as Label;
                        Label ES = itemEquipment.FindControl("txt_ES") as Label;
                        Label EM = itemEquipment.FindControl("txt_EM") as Label;
                        Label ET = itemEquipment.FindControl("txt_ET") as Label;
                        Label ELWS = itemEquipment.FindControl("txt_ELWS") as Label;
                        Label ELC = itemEquipment.FindControl("txt_ELCO") as Label;
                        Label ELCT = itemEquipment.FindControl("txt_ELCTH") as Label;
                        Label CY = itemEquipment.FindControl("txt_CY") as Label;
                        Label VRR = itemEquipment.FindControl("txt_VRE") as Label;
                        Label TR = itemEquipment.FindControl("txt_TRE") as Label;
                        Label REMARKS = itemEquipment.FindControl("txt_RE") as Label;
                        Label AADHAR_NO = itemEquipment.FindControl("AADHAR_NO") as Label;
                        Label Dlcdate = itemEquipment.FindControl("txt_dlcdate") as Label;
                        Label landclass = itemEquipment.FindControl("txtland") as Label;
                        Label BANKNAME = itemEquipment.FindControl("txt_Bank") as Label;
                        Label BACKACCNO = itemEquipment.FindControl("txt_Bankac") as Label;
                        Label IFSC = itemEquipment.FindControl("txt_ifsc") as Label;
                        Label pattadarfathername = itemEquipment.FindControl("txt_Fathername") as Label;
                        DataRow dr = dtUpdateDetails.NewRow();
                        dr["Mandal_Code"] = MNC.Text;
                        dr["Mandal"] = MN.Text;
                        dr["Gram_Panchayat"] = GPN.Text;
                        dr["Village_Code"] = VNC.Text;
                        dr["Village"] = VN.Text;
                        dr["HabitationCode"] = HABC.Text;
                        dr["Habitation"] = HAB.Text;
                        dr["Forest_DivisionCode"] = FDC.Text;
                        dr["Forest_Division"] = FDN.Text;
                        dr["Forest_RangeCode"] = FRC.Text;
                        dr["Forest_Range"] = FRN.Text;
                        dr["Forest_BeatCode"] = FBC.Text;
                        dr["Forest_Beat"] = FBN.Text;
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
                        if ((string)(Session["Director"]) == "DIRECTOR")
                        {
                            dr["IsApproved"] = isapproved;
                            dr["Status"] = "DR";
                        }
                        else
                        {
                            dr["IsApproved"] = isapproved;
                            dr["Status"] = "PR";
                        }
                        dr["IPADDRESS"] = IPAddress;
                        dr["MACADDRESS"] = MacAddress;

                        dr["Dlc_date"] = Dlcdate.Text;
                        dr["Landclassification"] = landclass.Text;
                        dr["BankName"] = BANKNAME.Text;
                        dr["BankAccountNo"] = BACKACCNO.Text;
                        dr["IfscCode"] = IFSC.Text;
                        dr["Father_Name"] = pattadarfathername.Text;
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
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficiary Details Reject Successfully')", true);
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
                if ((string)(Session["Director"]) == "DIRECTOR")
                {
                    if (ddl_district1.SelectedItem.Text != "Select")
                    {
                        if (ddl_records1.SelectedValue != "0")
                        {
                            BindDirectorCount(ddl_district1.SelectedValue, false, ddl_records.SelectedValue);
                            BindDirectorData(ddl_district1.SelectedValue);
                        }

                    }
                }
                else
                {
                    if (ddl_district.SelectedItem.Text != "Select")
                    {
                        if (ddl_records.SelectedValue != "0")
                        {
                            BindCount(ddl_district.SelectedValue, false, ddl_records.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                            BindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
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


        protected void btnselect_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {
                    //to get the dropdown of each line
                    CheckBox chk = (CheckBox)itemEquipment.FindControl("chkSelect");
                    chk.Checked = true;
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
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


    }
}
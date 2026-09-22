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
    public partial class BeneficiaryCropLoans : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
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

                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;

                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));




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

        protected void ddlitda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_mandal.ClearSelection();

                    ddl_district.ClearSelection();
                    Repeater1.DataBind();

                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;

                    select_records.Visible = false;
                    DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindDistrict(dtMandal);
                        if (dtMandal.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            ddl_mandal.ClearSelection();

                            Repeater1.DataSource = null;

                            Repeater1.DataBind();

                            //Panel_Image.Visible = false;
                            //Panel_Uploaddlc.Visible = false;

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

                                Repeater1.DataSource = null;

                                Repeater1.DataBind();

                                //Panel_Image.Visible = false;
                                //Panel_Uploaddlc.Visible = false;

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

                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;

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
                if (ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select")
                {

                    Repeater1.DataSource = null;

                    Repeater1.DataBind();

                    //Panel_Image.Visible = false;
                    //Panel_Uploaddlc.Visible = false;

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


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetcropForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal);

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();

                    visibleorunvisible();


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

                        //Panel_Image.Visible = false;
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


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetcropForestBeneficiaryDetailscountValidate(district, Itda, mandal);

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
                bool c = false;
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
                // dtbeneficiareies = searchBindData(ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, ddl_mandal.SelectedItem.Text);
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format("ROFR_PATTADAAR LIKE '%{0}%'", "");
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
                        TextBox pattadarname = itemEquipment.FindControl("txt_RPN") as TextBox;
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
                        if (dlcdate.Text == "")
                        {
                            dlcdate.BorderColor = Color.Red;
                        }
                        else if (dlcdate.Text != "")
                        {
                            if (dlcdate.BorderColor == Color.Red)
                                dlcdate.BorderColor = Color.LightGray;
                        }
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
                        if (pattano.Text == "")
                        {
                            pattano.BorderColor = Color.Red;
                        }
                        else if (pattano.Text != "")
                        {
                            if (pattano.BorderColor == Color.Red)
                                pattano.BorderColor = Color.LightGray;
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
        public void visibleorunvisible()
        {
            try
            {
                foreach (RepeaterItem itemEquipment in Repeater1.Items)
                {
                    Label lblrpn= itemEquipment.FindControl("lbl_RPN") as Label;
                    TextBox txtrpn = itemEquipment.FindControl("txt_RPN") as TextBox;
                    if (txtrpn.Text != "")
                    {
                        lblrpn.Visible = true;
                        txtrpn.Visible = false;
                    }
                    Label lblRPD = itemEquipment.FindControl("lbl_RPD") as Label;
                    TextBox txtRPD = itemEquipment.FindControl("txt_RPD") as TextBox;
                    if (txtRPD.Text != "")
                    {
                        lblRPD.Visible = true;
                        txtRPD.Visible = false;
                    }
                    Label lblMN = itemEquipment.FindControl("lbl_MN") as Label;
                    TextBox txtMN = itemEquipment.FindControl("txt_MN") as TextBox;
                    if (txtMN.Text != "")
                    {
                        lblMN.Visible = true;
                        txtMN.Visible = false;
                    }

                    Label lblGPN = itemEquipment.FindControl("lbl_GPN") as Label;
                    TextBox txtGPN = itemEquipment.FindControl("txt_GPN") as TextBox;
                    if (txtMN.Text != "")
                    {
                        lblGPN.Visible = true;
                        txtGPN.Visible = false;
                    }

                    Label lblVN = itemEquipment.FindControl("lbl_VN") as Label;
                    TextBox txtVN = itemEquipment.FindControl("txt_VN") as TextBox;
                    if (txtVN.Text != "")
                    {
                        lblVN.Visible = true;
                        txtVN.Visible = false;
                    }

                    Label lblhab = itemEquipment.FindControl("lbl_hab") as Label;
                    TextBox txthab = itemEquipment.FindControl("txt_hab") as TextBox;
                    if (txthab.Text != "")
                    {
                        lblhab.Visible = true;
                        txthab.Visible = false;
                    }

                    Label lblfd = itemEquipment.FindControl("lbl_fd") as Label;
                    TextBox txtfd = itemEquipment.FindControl("txt_fd") as TextBox;
                    if (txtfd.Text != "")
                    {
                        lblfd.Visible = true;
                        txtfd.Visible = false;
                    }

                    Label lblfr = itemEquipment.FindControl("lbl_fr") as Label;
                    TextBox txtfr = itemEquipment.FindControl("txt_fr") as TextBox;
                    if (txtfr.Text != "")
                    {
                        lblfr.Visible = true;
                        txtfr.Visible = false;
                    }

                    Label lblfb = itemEquipment.FindControl("lbl_fb") as Label;
                    TextBox txtfb = itemEquipment.FindControl("txt_fb") as TextBox;
                    if (txtfb.Text != "")
                    {
                        lblfb.Visible = true;
                        txtfb.Visible = false;
                    }

                    Label lblfbl = itemEquipment.FindControl("lbl_fbl") as Label;
                    TextBox txtfbl = itemEquipment.FindControl("txt_fbl") as TextBox;
                    if (txtfbl.Text != "")
                    {
                        lblfbl.Visible = true;
                        txtfbl.Visible = false;
                    }

                    Label lblcno = itemEquipment.FindControl("lbl_cno") as Label;
                    TextBox txtcno = itemEquipment.FindControl("txt_cno") as TextBox;
                    if (txtcno.Text != "")
                    {
                        lblcno.Visible = true;
                        txtcno.Visible = false;
                    }

                    Label lblepa = itemEquipment.FindControl("lbl_epa") as Label;
                    TextBox txtepa = itemEquipment.FindControl("txt_epa") as TextBox;
                    if (txtepa.Text != "")
                    {
                        lblepa.Visible = true;
                        txtepa.Visible = false;
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
                    TextBox LUTC = item.FindControl("txt_LUTC") as TextBox;
                    LUTC.BackColor = Color.White;
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
                    TextBox LUTC = currentrow.FindControl("txt_LUTC") as TextBox;
                    LUTC.BackColor = Color.LightBlue;
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
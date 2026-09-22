using ROFR.helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ROFR.pages
{
    public partial class LotLogs_Phases_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    ddl_Itda.Items.FindByValue("ALL").Selected = true;
                     div_mandal.Visible = false;
                    DataTable dt = new DataTable();
                    if (ddl_Itda.SelectedValue == "ALL")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("ALL", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"],"");
                        BindData(dt);
                    }

                    if (ddl_Itda.SelectedValue == "PHASE-I")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("PHASE-I", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                        BindData(dt);
                    }
                    if (ddl_Itda.SelectedValue == "PHASE-II")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("PHASE-II", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                        BindData(dt);
                    }


                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void BindData(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["districtexcel"] = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {
                                string value = dt.Rows[i][j].ToString();
                                if (j == 1)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 2)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 3)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 4)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 5)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                            }

                        }
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

        protected void LinkDistrict_OnClick(object sender,EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');
                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);
                Session["Itda"] = start.Trim();
                Session["District"] = dist.Trim();

                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("FMandal", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"], ddl_Itda.SelectedValue);

                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    district.Visible = true;
                    div_lbl.Visible = true;
                    div_mandal.Visible = true;
                    Div3.Visible = false;
                    itda.Visible = true;
                    btn_uploadDISTRICTWISE.Visible = false;
                    btn_uploadMandalWise.Visible = true;
                    btn_UploadvillageWise.Visible = false;
                    btn_back_dist.Visible = true;
                    btn_notupload.Visible = false;
                    dwnld_latlongs.Visible = false;
                    btn_Mand_Excel.Visible = false;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    Session["mandalexcel"] = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            //first row
                            if (i != dt.Rows.Count - 1)
                            {

                                string value = dt.Rows[i][j].ToString();
                                if (j == 3 && value=="0")
                                {
                                    string IL = "lbl";
                                    IL = IL + j;
                                    string IL1 = IL + "Buttonmand";
                                    LinkButton ibutton = GridView2.Rows[i].FindControl(IL1) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;

                                }
                                if (j == 4 && value=="0")
                                {

                                    string IL = "lbl";
                                    IL = IL + j;
                                    string IL1 = IL + "LinkButton";
                                    LinkButton ibutton = GridView2.Rows[i].FindControl(IL1) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }

                            }

                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 0)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView2.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 1)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 2)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 3)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;
                                    string IL1 = IL + "Buttonmand";
                                    LinkButton ibutton = GridView2.Rows[i].FindControl(IL1) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 4)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;
                                    string IL1 = IL + "LinkButton";
                                    LinkButton ibutton = GridView2.Rows[i].FindControl(IL1) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                            }

                        }
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
        protected void LinkMandal_OnClick(object sender,EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                Session["Mandal"] = s.Trim();
                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("FVillage", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), "", (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    btn_uploadDISTRICTWISE.Visible = false;
                    btn_uploadMandalWise.Visible = false;
                    btn_UploadvillageWise.Visible = true;
                    dwnld_latlongs.Visible = false;
                    btn_Mand_Excel.Visible = false;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
                    btn_back_dist.Visible = false;
                    btn_back_mandal.Visible = true;
                    latlongback.Visible = false;
                   // btn_upload.Visible = false;
                    btn_notupload.Visible = false;
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    Session["villageexcel"] = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {

                            string value = dt.Rows[i][j].ToString();
                            if (i != dt.Rows.Count - 1)
                            {
                                if ((j == 3 && value == "0") || (j == 3 && value == "0"))
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView3.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;

                                }
                            }
                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 0)
                                {
                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;


                                }
                                if (j == 1)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                
                                if (j == 2)
                                {

                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView3.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 3)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView3.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                            }

                        }
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
        protected void Rejected_onclick(object sender,EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');
                string txtstatus = string.Empty;
                string start = s.Substring(0, range);

                string end = s.Substring(s.LastIndexOf(',') + 1);
                // btn_upload.Visible = false;
                btn_Mand_Excel.Visible = false;
                btn_notupload.Visible = false;
                btn_uploadDISTRICTWISE.Visible = false;
                btn_uploadMandalWise.Visible = false;
                btn_UploadvillageWise.Visible = false;
                Session["Village"] = start.Trim();

                if (end == "HAVING")
                {
                    btn_Village_Excel.Visible = true;
                    btn_Not_Village_Excel.Visible = false;
                    btn_Village_Excel.Visible = true;
                    btn_Mand_Excel.Visible = false;
                    btn_uploadDISTRICTWISE.Visible = false;
                    btn_uploadMandalWise.Visible = false;
                    btn_UploadvillageWise.Visible = false;
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("Having", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);
                    txtstatus = "LATLONGS UPLOADED";

                    if (dt.Rows.Count > 0)
                    {
                        div_success.Visible = true;
                        div_dist.Visible = false;
                        div_mandal.Visible = false;
                        div_village.Visible = false;

                        div_rejected.Visible = false;
                        div_lbl.Visible = true;
                        itda.Visible = true;
                        district.Visible = true;
                        mandal.Visible = true;
                        village.Visible = true;
                        status.Visible = true;
                        dwnld_latlongs.Visible = false;
                        btn_Mand_Excel.Visible = false;
                        btn_uploadDISTRICTWISE.Visible = false;
                        btn_uploadMandalWise.Visible = false;
                        btn_UploadvillageWise.Visible = false;
                        lbl_itda.Text = (string)(Session["Itda"]);
                        lbl_dist.Text = (string)(Session["District"]);
                        lbl_mandal.Text = (string)(Session["Mandal"]);
                        lbl_village.Text = (string)(Session["Village"]);

                        lbl_status.Text = txtstatus.Trim();
                        btn_back_dist.Visible = false;
                        btn_back_mandal.Visible = false;
                        btn_back_village.Visible = true;
                        latlongback.Visible = false;
                        GridView4.DataSource = dt;
                        GridView4.DataBind();

                        Session["uploaddata"] = dt;



                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                if (end == "NOTHAVING")
                {
                    btn_Village_Excel.Visible = false;
                    btn_Not_Village_Excel.Visible = true;
                    btn_Mand_Excel.Visible = false;
                    btn_uploadDISTRICTWISE.Visible = false;
                    btn_uploadMandalWise.Visible = false;
                    btn_UploadvillageWise.Visible = false;
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("Nothaving", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);
                    txtstatus = "LATLONGS NOT UPLOADED";

                    if (dt.Rows.Count > 0)
                    {
                        div_rejected.Visible = true;
                        div_dist.Visible = false;
                        div_mandal.Visible = false;
                        div_village.Visible = false;
                        div_success.Visible = false;

                        div_lbl.Visible = true;
                        itda.Visible = true;
                        district.Visible = true;
                        mandal.Visible = true;
                        village.Visible = true;
                        status.Visible = true;
                        dwnld_latlongs.Visible = false;
                        btn_Mand_Excel.Visible = false;
                        btn_uploadDISTRICTWISE.Visible = false;
                        btn_uploadMandalWise.Visible = false;
                        btn_UploadvillageWise.Visible = false;
                        lbl_itda.Text = (string)(Session["Itda"]);
                        lbl_dist.Text = (string)(Session["District"]);
                        lbl_mandal.Text = (string)(Session["Mandal"]);
                        lbl_village.Text = (string)(Session["Village"]);

                        lbl_status.Text = txtstatus.Trim();
                        btn_back_dist.Visible = false;
                        btn_back_mandal.Visible = false;
                        btn_back_village.Visible = true;
                        latlongback.Visible = false;
                        GridView5.DataSource = dt;
                        GridView5.DataBind();
                        Session["notuploaddata"] = dt;
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
        protected void MandalLevel_NotHaving_OnClick(object sender,EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');
                string txtstatus = string.Empty;
                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                //btn_upload.Visible = false;
                btn_notupload.Visible = false;
                Session["Mandal"] = start.Trim();
                btn_Village_Excel.Visible = false;
                btn_Not_Village_Excel.Visible = false;
                // btn_Mand_Excel.Visible = false;
                btn_uploadDISTRICTWISE.Visible = false;
                btn_uploadMandalWise.Visible = false;
                btn_UploadvillageWise.Visible = false;
                dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report(end, (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);
                Session["inputtype"] = end;
                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = false;
                    div_success.Visible = false;
                    div_rejected.Visible = false;
                    btn_Mand_Excel.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    btn_uploadDISTRICTWISE.Visible = false;
                    btn_uploadMandalWise.Visible = false;
                    btn_UploadvillageWise.Visible = false;
                    div_madalDetailswise.Visible = true;
                    village.Visible = false;
                    status.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
                    lbl_status.Text = end;
                    btn_back_dist.Visible = false;
                    btn_back_mandal.Visible = true;
                    btn_back_village.Visible = false;
                    latlongback.Visible = false;
                    GridView6.DataSource = dt;
                    GridView6.DataBind();
                    Session["exceldatabutton2"] = dt;
                    Session["exceldata_type"] = end;
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
        protected void Get_back_dist(object sender, EventArgs e)
        {
            div_lbl.Visible = false;
            div_dist.Visible = true;
            div_mandal.Visible = false;
            btn_back_dist.Visible = false;
            btn_back_mandal.Visible = false;
            Div3.Visible = true;

           // btn_upload.Visible = false;
            btn_notupload.Visible = true;
            dwnld_latlongs.Visible = true;
            btn_Village_Excel.Visible = false;
            btn_Not_Village_Excel.Visible = false;
            latlongback.Visible = false;
            btn_Mand_Excel.Visible = false;
            btn_uploadDISTRICTWISE.Visible = true;
            btn_uploadMandalWise.Visible = false;
            btn_UploadvillageWise.Visible = false;
        }
        protected void Get_back_mandal(object sender, EventArgs e)
        {
            btn_Mand_Excel.Visible = false;
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = true;
            div_village.Visible = false;
            btn_back_dist.Visible = true;
            latlongback.Visible = false;
            btn_back_mandal.Visible = false;
           // btn_upload.Visible = false;
            btn_notupload.Visible = false;
            btn_Village_Excel.Visible = false;
            btn_Not_Village_Excel.Visible = false;
            div_madalDetailswise.Visible = false;
            btn_uploadDISTRICTWISE.Visible = false;
            btn_uploadMandalWise.Visible = true;
            btn_UploadvillageWise.Visible = false;
        }
        protected void Get_back_village(object sender, EventArgs e)
        {
            btn_Mand_Excel.Visible = false;
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = true;
            village.Visible = false;
            status.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = false;
            div_village.Visible = true;
            div_success.Visible = false;
            div_rejected.Visible = false;
            btn_back_dist.Visible = false;
            btn_back_mandal.Visible = true;
            btn_back_village.Visible = false;
            latlongback.Visible = false;
           // btn_upload.Visible = false;
            btn_notupload.Visible = false;
            btn_Village_Excel.Visible = false;
            btn_Not_Village_Excel.Visible = false;
            btn_uploadDISTRICTWISE.Visible = false;
            btn_uploadMandalWise.Visible = false;
            btn_UploadvillageWise.Visible = true;
        }
        protected void latlongback_Click(object sender, EventArgs e)
        {
            status.Visible = false;
           // Button1.Visible = false;
            latlongback.Visible = false;
           // divlatlongmandal.Visible = false;
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = true;
            div_village.Visible = false;
            btn_back_dist.Visible = true;
            btn_back_mandal.Visible = false;
           // btn_upload.Visible = false;
            btn_notupload.Visible = false;
            btn_Village_Excel.Visible = false;
            btn_Not_Village_Excel.Visible = false;
            div_madalDetailswise.Visible = false;
            btn_Mand_Excel.Visible = false;
        }
        protected void ddl_Itda_SelectedIndexChanged(object sender,EventArgs e)
        {
            DataTable dt = new DataTable();
            if (ddl_Itda.SelectedValue == "ALL")
            {
                dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("ALL", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                BindData(dt);
            }

            if (ddl_Itda.SelectedValue == "PHASE-I")
            {
                dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("PHASE-I", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                BindData(dt);
            }
            if (ddl_Itda.SelectedValue == "PHASE-II")
            {
                dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("PHASE-II", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                BindData(dt);
            }

        }
        protected void Down_LessThan_4(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("Download", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);


                if (dt.Rows.Count > 0)
                {


                    string filename = "Latlongs_Lessthan_4.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

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
        protected void btn_notupload_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Latlongs_Phases_Report("INDistrict", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);


                if (dt.Rows.Count > 0)
                {


                    string filename = "Latlongs_NotUploaded.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

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

        protected void Mandalwise_Not_DownLoad(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = (DataTable)(Session["exceldatabutton2"]);

                if (dt.Rows.Count > 0)
                {


                    string filename = "Mandalwise_Latlongs_Not_Uploaded.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

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
        protected void Village_LotLongs_Download(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = (DataTable)(Session["uploaddata"]);

                if (dt.Rows.Count > 0)
                {

                    string filename = "Villagewise_Latlongs_Uploaded.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

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

        protected void Village_LotLongs_Not_Download(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = (DataTable)(Session["notuploaddata"]);

                if (dt.Rows.Count > 0)
                {


                    string filename = "Villagewise_Latlongs_NotUploaded.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

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

        protected void btn_Excel_uploadDist__Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = (DataTable)(Session["districtexcel"]);

                if (dt.Rows.Count > 0)
                {

                    string filename = "Districtwise_LotLongs_Report.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btn_Excel_uploadMand_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = (DataTable)(Session["mandalexcel"]);

                if (dt.Rows.Count > 0)
                {
                    string filename = "Mandalwise_LotLongs_Report.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_Excel_uploadVill_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = (DataTable)(Session["villageexcel"]);

                if (dt.Rows.Count > 0)
                {
                    string filename = "Villagewise_LotLongs_Report.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;
                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btn_img_pdf_Click(object sender, EventArgs e)
        {
            string vurl = "../pages/WebForm6.aspx";//modified by gopi
            //string vurl = "https://giribhumi.ap.gov.in/pages/WebForm6.aspx";
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "openlink", "window.open(vurl);", true);


            string u = "window.open('" + vurl + "', '_blank');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", u, true);

        }
    }
}
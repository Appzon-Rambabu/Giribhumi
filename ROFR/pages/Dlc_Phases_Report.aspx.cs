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
    public partial class Dlc_Phases_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    ddl_Itda.Items.FindByValue("ALL").Selected = true;
                    div_mandal.Visible = false;
                    btn_uploadMandalWise.Visible = false;
                    DataTable dt = new DataTable();
                    if (ddl_Itda.SelectedValue == "ALL")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("ALL", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"],"");
                        BindData(dt);
                    }
                    if (ddl_Itda.SelectedValue == "PHASE-I")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("PHASE-I", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                        BindData(dt);
                    }
                    if (ddl_Itda.SelectedValue == "PHASE-II")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("PHASE-II", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
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
        protected void ddl_Itda_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (ddl_Itda.SelectedValue == "ALL")
            {
                dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("ALL", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                BindData(dt);
            }
            if (ddl_Itda.SelectedValue == "PHASE-I")
            {
                dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("PHASE-I", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                BindData(dt);
            }
            if (ddl_Itda.SelectedValue == "PHASE-II")
            {
                dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("PHASE-II", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"], "");
                BindData(dt);
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

                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("Mandal", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"], ddl_Itda.SelectedValue);

                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    district.Visible = true;
                    div_lbl.Visible = true;
                    div_mandal.Visible = true;
                    Div3.Visible = false;
                    btn_uploadDISTRICTWISE.Visible = false;
                    btn_uploadMandalWise.Visible = true;
                    btn_UploadvillageWise.Visible = false;
                    //btnmandnothaving.Visible = false;
                    btn_mand_nothaving.Visible = false;
                    btn_img_upload.Visible = false;
                    btn_img_notupload.Visible = false;
                    itda.Visible = true;
                    btn_back_dist.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    Session["mandalexcel"] = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            string value = dt.Rows[i][j].ToString();
                            if (i != dt.Rows.Count - 1)
                            {
                                if (j == 3 && value == "0")
                                {
                                    string IB = "Buttonmand";

                                    string IL = "lbl";
                                    IB = IL + j + IB;
                                    IL = IL + j;
                                    LinkButton ibutton = GridView2.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;

                                }
                            }
                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 0)
                                {
                                    string IB = "LinkButton";

                                    string IL = "lbl";
                                    IL = IL + j;
                                    IB = IB + j;
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
                                //if (j == 3)
                                //{

                                //    string IL = "lbl";
                                //    IL = IL + j;

                                //    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;

                                //    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                //}
                                if (j == 3)
                                {
                                    string IB = "Buttonmand";
                                    string IL = "lbl";
                                    IB = IL + j + IB;
                                    IL = IL + j;
                                    LinkButton ibutton = GridView2.Rows[i].FindControl(IB) as LinkButton;
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
                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("Village", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), "", (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);


                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    Div3.Visible = false;
                    btn_uploadDISTRICTWISE.Visible = false;
                    btn_uploadMandalWise.Visible = false;
                    btn_UploadvillageWise.Visible = true;
                    //btnmandnothaving.Visible = false;
                    btn_back_dist.Visible = false;
                    btn_back_mandal.Visible = true;
                    btn_mand_nothaving.Visible = false;
                    btn_img_upload.Visible = false;
                    btn_img_notupload.Visible = false;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
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
                                if ((j == 2 && value == "0") || (j == 3 && value == "0"))
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
        protected void MandalLevel_OnClick(object sender,EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');
                string txtstatus = string.Empty;
                string start = s.Substring(0, range);
                string filename = string.Empty;
                string path = string.Empty;
                string end = s.Substring(s.LastIndexOf(',') + 1);
                Session["Mandal"] = start.Trim();

                if (end == "Not Having Dlc")
                {
                    btn_img_upload.Visible = false;
                    btn_img_notupload.Visible = true;
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("Not Having Dlc", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), " ", (string)(Session["username"]), (string)Session["userprevilages"], ddl_Itda.SelectedValue);
                    txtstatus = "DLC Not Having In Mandal Level";
                }
                if (dt.Rows.Count > 0)
                {
                    //divMandcount.Visible = true;
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = false;
                    div_rejected.Visible = true;
                    Div3.Visible = false;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    village.Visible = false;
                    btn_uploadDISTRICTWISE.Visible = false;
                    btn_uploadMandalWise.Visible = false; ;
                    btn_UploadvillageWise.Visible = false;
                    status.Visible = true;
                    btn_mand_nothaving.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
                    lbl_status.Text = txtstatus.Trim();
                    btn_back_dist.Visible = false;
                    btn_back_mandal.Visible = false;
                    btn_back_village.Visible = false;
                    GridView5.DataSource = dt;
                    GridView5.DataBind();
                    Session["exceldata"] = dt;

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
        protected void Rejected_onclick(object sender, EventArgs e)
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
                btn_uploadDISTRICTWISE.Visible = false;
                btn_uploadMandalWise.Visible = false;
                btn_UploadvillageWise.Visible = false;
                Div3.Visible = false;
                Session["Village"] = start.Trim();

                if (end == "HAVING")
                {
                    btn_img_upload.Visible = true;
                    btn_img_notupload.Visible = false;
                    btn_UploadvillageWise.Visible = false;
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("IHaving", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);
                    txtstatus = "DLC UPLOADED";
                }
                if (end == "NOTHAVING")
                {
                    btn_img_upload.Visible = false;
                    btn_img_notupload.Visible = true;
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("Nothaving", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);
                    txtstatus = "DLC NOT UPLOADED";
                }

                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = false;
                    div_rejected.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    village.Visible = true;
                    status.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
                    lbl_village.Text = (string)(Session["Village"]);
                    lbl_status.Text = txtstatus.Trim();
                    btn_back_dist.Visible = false;
                    btn_back_mandal.Visible = false;
                    btn_back_village.Visible = true;
                    GridView5.DataSource = dt;
                    GridView5.DataBind();
                    Session["exceldata"] = dt;
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
            
            btn_mand_nothaving.Visible = false;
            div_lbl.Visible = false;
            div_dist.Visible = true;
            div_mandal.Visible = false;
            btn_back_dist.Visible = false;
            btn_back_mandal.Visible = false;
            btn_uploadDISTRICTWISE.Visible = true;
            btn_uploadMandalWise.Visible = false;
            btn_UploadvillageWise.Visible = false;
            Div3.Visible = true;
            btn_img_upload.Visible = false;
            btn_img_notupload.Visible = false;

        }
        protected void Get_back_mandal(object sender, EventArgs e)
        {
            btn_mand_nothaving.Visible = false;
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = true;
            div_village.Visible = false;
            btn_back_dist.Visible = true;
            btn_back_mandal.Visible = true;
            btn_uploadDISTRICTWISE.Visible = false;
            btn_uploadMandalWise.Visible = true;
            btn_UploadvillageWise.Visible = false;
            Div3.Visible = false;
            btn_back_mandal.Visible = false;
            btn_img_upload.Visible = false;
            btn_img_notupload.Visible = false;
        }
        protected void Get_back_village(object sender, EventArgs e)
        {
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = true;
            village.Visible = false;
            status.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = false;
            div_village.Visible = true;
            Div3.Visible = false;

            btn_mand_nothaving.Visible = false;
            div_rejected.Visible = false;
            btn_back_dist.Visible = false;
            btn_back_mandal.Visible = true;
            btn_back_village.Visible = false;
            btn_uploadDISTRICTWISE.Visible = false;
            btn_UploadvillageWise.Visible = true;
            btn_uploadMandalWise.Visible = false;
            btn_img_upload.Visible = false;
            btn_img_notupload.Visible = false;
        }
        protected void btn_mand_nothaving_Click(object sender, EventArgs e)
        {
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = true;
            village.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = true;
            div_village.Visible = false;
            Div3.Visible = false;
            btn_mand_nothaving.Visible = false;
            div_rejected.Visible = false;
            btn_back_dist.Visible = true;
            btn_back_mandal.Visible = false;
            btn_back_village.Visible = false;
            btn_uploadDISTRICTWISE.Visible = false;
            btn_uploadMandalWise.Visible = true;
            btn_UploadvillageWise.Visible = false;
            btn_img_upload.Visible = false;
            btn_img_notupload.Visible = false;
        }
        protected void btn_Excel_uploadDist__Click(object sender,EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = (DataTable)(Session["districtexcel"]);

                if (dt.Rows.Count > 0)
                {

                    string filename = "Districtwise_DLC_Report.xls";
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
        protected void btn_Excel_uploadMand_Click(object sender,EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = (DataTable)(Session["mandalexcel"]);

                if (dt.Rows.Count > 0)
                {
                    string filename = "Mandalwise_DLC_Report.xls";
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
        protected void btn_Excel_uploadVill_Click(object sender,EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = (DataTable)(Session["villageexcel"]);

                if (dt.Rows.Count > 0)
                {
                    string filename = "Villagewise_DLC_Report.xls";
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
        protected void btn_img_upload_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                // dt = (DataTable)(Session["exceldata"]);

                dt = ProjectRofrBAL.GetMasterDetails.Get_Dlc_Phase_Report("Having", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"],ddl_Itda.SelectedValue);
                if (dt.Rows.Count > 0)
                {
                    string filename = "Dlc_Uploaded.xls";
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
        protected void btn_img_notupload_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt = (DataTable)(Session["exceldata"]);

                if (dt.Rows.Count > 0)
                {


                    string filename = "Dlc_NotUploaded.xls";
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

    }
}
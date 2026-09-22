using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Data;
using ROFR.helper;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;

namespace ROFR.pages
{
    public partial class Land_Images_Abstract_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btn_upload);
                scriptManager.RegisterPostBackControl(this.btn_notupload);
                scriptManager.RegisterPostBackControl(this.btn_village_excel);
                scriptManager.RegisterPostBackControl(this.btn_img_upload);
                scriptManager.RegisterPostBackControl(this.btn_img_notupload);
                scriptManager.RegisterPostBackControl(this.btnmandnothaving);
                scriptManager.RegisterPostBackControl(this.btn_img_pdf);


                if (!IsPostBack)
                {

                    BindData();

                    div_mandal.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void BindData()
        {
            try
            {

                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("District", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);


                if (dt.Rows.Count > 0)
                {

                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno"] = i + 1;
                    }

                    btn_notupload.Visible = false;
                    GridView1.DataSource = dt;

                    GridView1.DataBind();
                    Session["districtexcel"] = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {

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
        protected void link_onclick(object sender, EventArgs e)

        {
            try
            {
                System.Threading.Thread.Sleep(5000);
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


                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("Mandal", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);


                if (dt.Rows.Count > 0)
                {

                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno1", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno1"] = i + 1;
                    }
                    div_dist.Visible = false;
                    div_mandal.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    btnmandnothaving.Visible = false;
                    btn_mand_nothaving.Visible = false;
                    district.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    btn_back_dist.Visible = true;
                    btn_upload.Visible = false;
                    btn_notupload.Visible = true;
                    GridView2.DataSource = dt;
                    btn_mand_nothaving.Visible = false;
                    GridView2.DataBind();
                    Session["mandalexcel"] = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            string value = dt.Rows[i][j].ToString();

                            if (i != dt.Rows.Count - 1)
                            {
                              

                                if (j == 5 && value == "0")
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView2.Rows[i].FindControl("LinkButtonmand") as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl("lblmand") as Label;
                                    lbl.Visible = true;

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

                                    Label lbl = GridView2.Rows[i].FindControl("lblmand") as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }

                                if (j == 4)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;
                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 5)
                                {

                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView2.Rows[i].FindControl("LinkButtonmand") as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl("lblmand") as Label;
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

        protected void Mandal_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;


                Session["Mandal"] = s.Trim();



                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("Village", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), "", (string)(Session["username"]), (string)Session["userprevilages"]);


                if (dt.Rows.Count > 0)
                {

                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno2", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno2"] = i + 1;
                    }
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    btnmandnothaving.Visible = false;
                    btn_mand_nothaving.Visible = false;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
                    btn_back_dist.Visible = false;
                    btn_village_excel.Visible = true;
                    btn_back_mandal.Visible = true;
                    btn_upload.Visible = false;
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
                                if ((j == 4 && value == "0") || (j == 5 && value == "0"))
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
                                if (j == 1|| j == 2|| j == 3)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 4)
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
                                if (j == 5)
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



        protected void mandclick_Click(object sender, EventArgs e)
        {
            try {
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();
            LinkButton btn = (LinkButton)sender;
            string s = btn.CommandArgument;
            var range = s.IndexOf(',');
            string txtstatus = string.Empty;
            string start = s.Substring(0, range);
            string filename = string.Empty;
            string path = string.Empty;
            string end = s.Substring(s.LastIndexOf(',') + 1);
            btn_upload.Visible = false;
            btn_notupload.Visible = false;
            btn_village_excel.Visible = false;
            Session["Mandal"] = start.Trim();

            if (end == "NOTHAVING")
            {
                btn_img_upload.Visible = false;
                btn_img_pdf.Visible = false;
                btn_img_notupload.Visible = false;
                dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("NothavingMandal", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"])," ",(string)(Session["username"]), (string)Session["userprevilages"]);
                txtstatus = "LAND IMAGES NOT UPLOADED";
            }
                if (dt.Rows.Count > 0)
            {
                    divMandcount.Visible = true;
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = false;
                    div_rejected.Visible = false;
                    itda.Visible = true;
                district.Visible = true;
                mandal.Visible = true;
                village.Visible = false;
                status.Visible = true;
                btn_mand_nothaving.Visible = true;
                btnmandnothaving.Visible = true;
                lbl_itda.Text = (string)(Session["Itda"]);
                lbl_dist.Text = (string)(Session["District"]);
                lbl_mandal.Text = (string)(Session["Mandal"]);
                lbl_status.Text = txtstatus.Trim();
                btn_back_dist.Visible = false;
                btn_back_mandal.Visible = false;
                btn_back_village.Visible = false;
                GridView7.DataSource = dt;
                GridView7.DataBind();   
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
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');
                string txtstatus = string.Empty;
                string start = s.Substring(0, range);
                string filename = string.Empty;
                string path = string.Empty;
                string end = s.Substring(s.LastIndexOf(',') + 1);
                btn_upload.Visible = false;
                btn_notupload.Visible = false;
                btn_village_excel.Visible = false;
                Session["Village"] = start.Trim();

                if (end == "HAVING")
                {
                    btn_img_upload.Visible = true;
                    btn_img_pdf.Visible = true;
                    btn_img_notupload.Visible = false;
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("IHaving", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);
                    txtstatus = "LAND IMAGES UPLOADED";
                }
                if (end == "NOTHAVING")
                {
                    btn_img_upload.Visible = false;
                    btn_img_pdf.Visible = false;
                    btn_img_notupload.Visible = true;
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("Nothaving", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);
                    txtstatus = "LAND IMAGES NOT UPLOADED";
                }
                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = false;
                    btnmandnothaving.Visible = false;
                    btn_mand_nothaving.Visible = false;
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
            divMandcount.Visible = false;
            btnmandnothaving.Visible = false;
            btn_mand_nothaving.Visible = false;
            div_lbl.Visible = false;
            div_dist.Visible = true;
            div_mandal.Visible = false;
            btn_back_dist.Visible = false;
            btn_back_mandal.Visible = false;
            btn_upload.Visible = true;
            btn_notupload.Visible = false;
            btn_img_upload.Visible = false;
            btn_img_pdf.Visible = false;
            btn_img_notupload.Visible = false;
            btn_village_excel.Visible = false;
        }
        protected void Get_back_mandal(object sender, EventArgs e)
        {
            btnmandnothaving.Visible = false;
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
            btn_upload.Visible = false;
            btn_notupload.Visible = true;
            btn_back_mandal.Visible = false;
            btn_img_upload.Visible = false;
            btn_img_pdf.Visible = false;
            btn_img_notupload.Visible = false;
            btn_village_excel.Visible = false;
            divMandcount.Visible = false;
        }
        protected void Get_back_village(object sender, EventArgs e)
        {
            divMandcount.Visible = false;
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = true;
            village.Visible = false;
            status.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = false;
            div_village.Visible = true;
            btnmandnothaving.Visible = false;
            btn_mand_nothaving.Visible = false;
            div_rejected.Visible = false;
            btn_back_dist.Visible = false;
            btn_back_mandal.Visible = true;
            btn_back_village.Visible = false;
            btn_upload.Visible = false;
            btn_notupload.Visible = false;
            btn_img_upload.Visible = false;
            btn_img_pdf.Visible = false;
            btn_img_notupload.Visible = false;
            btn_village_excel.Visible = true;
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = (DataTable)(Session["districtexcel"]);

                if (dt.Rows.Count > 0)
                {


                    string filename = "Districtwise_Land_Image_Report.xls";
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
        protected void btn_notupload_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = (DataTable)(Session["mandalexcel"]);

                if (dt.Rows.Count > 0)
                {


                    string filename = "Mandalwise_Land_Images_Report.xls";
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

        protected void btn_village_excel_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = (DataTable)(Session["villageexcel"]);

                if (dt.Rows.Count > 0)
                {


                    string filename = "Villagewise_Land_Images_Report.xls";
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

        protected void btn_img_pdf1_Click(object sender, EventArgs e)
        {
            string vurl = "http://localhost:60061/HtmlPage2.html";
            string u = "window.open('" + vurl + "', 'popup_window', 'width=800,height=550,resizable=yes');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", u, true);
            ReportDocument crystalReport = new ReportDocument();
            string firstid = "";
            string lastid = "";
            try
            {

                DataTable dtpdf = new DataTable();
                // dt = (DataTable)(Session["exceldata"]);


                dtpdf = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("pdfIHaving", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);

                for (int i = 0; i <= (dtpdf.Rows.Count - 1); i++)
                {
                    if (i == 0)
                    {
                        firstid = dtpdf.Rows[i]["ID"].ToString();
                    }
                    else if (i == (dtpdf.Rows.Count - 1))
                    {
                        lastid = dtpdf.Rows[i]["ID"].ToString();
                    }
                }
                dtpdf.Columns.Add("Image3", typeof(byte[]));
                dtpdf.Columns.Add("Image4", typeof(byte[]));
                //dtpdf.Columns.Add("Image2", typeof(byte[]));
                if (dtpdf.Rows.Count > 0)
                {
                    for (int i = 0; i <= (dtpdf.Rows.Count - 1); i++)
                    {
                        byte[] bv = new byte[5000];
                        string url = dtpdf.Rows[i]["Land_Img_path1"].ToString();

                        bv = getImageFromUrl(url);
                        // string base641 = Convert.ToString(bv);
                        // System.Drawing.Image img = Base64StringToBitmap(base641);

                        // string base64= ProjectRofrBAL.GetMasterDetails.imageurltoimage(url);
                        //  Bitmap objBitmap = new Bitmap(base64, new Size(227, 171));
                        //ProjectRofrBAL.GetMasterDetails.ResizeImage(url);
                        //string url = "https://giribhumi.ap.gov.in/Land Images/Image1/08-12-2020_150504455_218886_10-10-2020_150502702_202461_150502702_202461_1 (1).jpg";

                        DisplayImages(dtpdf.Rows[i], "Image3", bv);

                        byte[] bv1 = new byte[5000];
                        string url1 = dtpdf.Rows[i]["Land_Img_path2"].ToString();
                        bv = getImageFromUrl(url1);
                        DisplayImages(dtpdf.Rows[i], "Image4", bv);
                        //  DisplayImages(dtpdf.Rows[i], "Image2", dtpdf.Rows[i]["Land_Img_path1"].ToString());
                    }
                }
                crystalReport = new ReportDocument();
                // crystalReport.Load(Server.MapPath("~/Datadisplay.rpt"));
                // crystalReport.Database.Tables["DataTable6"].SetDataSource(dtpdf);

                crystalReport.Load(Server.MapPath("~/Farmerlandimagereporttnew.rpt"));



                crystalReport.Database.Tables["DataTable3"].SetDataSource(dtpdf);

                string cfilename = "Report.pdf";

                for (int i = 0; i <= (dtpdf.Rows.Count - 1); i++)
                {
                    ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("pdfIHavingupdate", dtpdf.Rows[i]["ID"].ToString(), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);
                }

                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "Farmerlandimagereport" + firstid + "-" + lastid);




            }
            catch (Exception ex)
            {
                crystalReport.Dispose();
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

                dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("Having", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);

             
              
                if (dt.Rows.Count > 0)
                {


                    string filename = "Farmer_Images_Uploaded.xls";
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


                    string filename = "Farmer_Images_NotUploaded.xls";
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
        private void DisplayImages(DataRow row, string img, byte[] ImgData)

        {
           
              //  FileStream stream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);

            //byte[] ImgData = new byte[stream.Length];

           // stream.Read(ImgData, 0, Convert.ToInt32(stream.Length));

           // stream.Close();


            row[img] = ImgData;

        }

        public  Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;


            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);


            memoryStream.Position = 0;


            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);


            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;


            return bmpReturn;
        }

        public byte[] getImageFromUrl(string url)
        {
            System.Net.HttpWebRequest request = null;
            System.Net.HttpWebResponse response = null;
            byte[] b = null;

            request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            response = (System.Net.HttpWebResponse)request.GetResponse();

            if (request.HaveResponse)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    using (BinaryReader br = new BinaryReader(receiveStream))
                    {
                        b = br.ReadBytes(500000000);
                        br.Close();
                    }
                }
            }

            return b;
        }

        protected void btnmandnothaving_Click(object sender, EventArgs e)
        {

            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();
                dt = (DataTable)(Session["exceldata"]);

                if (dt.Rows.Count > 0)
                {


                    string filename = "Farmer_Images_NotUploaded.xls";
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

        protected void btn_mand_nothaving_Click(object sender, EventArgs e)
        {
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = true;
            village.Visible = false;
            status.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = true;
            div_village.Visible = false;
            divMandcount.Visible = false;
            btnmandnothaving.Visible = false;
            btn_mand_nothaving.Visible = false;
            div_rejected.Visible = false;
            btn_back_dist.Visible = true;
            btn_back_mandal.Visible = false;
            btn_back_village.Visible = false;
            btn_upload.Visible = false;
            btn_notupload.Visible = true;
            btn_img_upload.Visible = false;
            btn_img_pdf.Visible = false;
            btn_img_notupload.Visible = false;
            btn_village_excel.Visible = false;
        }
    }
}
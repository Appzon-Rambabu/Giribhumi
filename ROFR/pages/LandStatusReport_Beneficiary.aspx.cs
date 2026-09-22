using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;
using System.Drawing;
using System.IO;


namespace ROFR.pages
{
    public partial class LandStatusReport_Beneficiary : System.Web.UI.Page
    {
        DataTable dtTest = new DataTable();
        DataTable dtTest1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btn_upload);
                scriptManager.RegisterPostBackControl(this.btn_notupload);

                if (!this.IsPostBack)
                {
                    BindData("");
                    div_mandal.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }
        protected void BindData(string form)
        {
            try
            {
                DataTable dt = new DataTable();
                if (form == "")
                {
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.Landstatusreport_Beneficiary();
                }

                if (dt.Rows.Count > 0)
                {

                    btn_notupload.Visible = false;

                    GridView.Visible = true;
                    GridView.DataSource = dt;

                    GridView.DataBind();
                 
                    Session["districtexcel"] = dt;



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


        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string today = "";
            string yesterday = "";
            today = DateTime.Now.ToString("dd.MM.yyyy");
            yesterday = DateTime.Today.AddDays(-1).ToString("dd.MM.yyyy");
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_yes = e.Item.FindControl("lbl_yes") as Label;
                Label lbl_today = e.Item.FindControl("lbl_today") as Label;
                Label lbl_cum = e.Item.FindControl("lbl_cum") as Label;
                lbl_yes.Text = "Upto Yesterday  (" + yesterday + ")";
                lbl_today.Text = "As on Today (" + today + ")";
                lbl_cum.Text = "Cumulative as on " + today;
                lbl_cum.Text = "Cumulative as on " + today;
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
                div_dist.Visible = false;
                div_mandal.Visible = true;

                btn_back_dist.Visible = true;
                btn_upload.Visible = false;
                btn_notupload.Visible = true;
                BindMandal("");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void BindMandal(string form)
        {
            try
            {
                DataTable dt = new DataTable();
                if (form == "")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandal", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                }

                if (dt.Rows.Count > 0)
                {

                    GridView2.DataSource = dt;

                    GridView2.DataBind();
                    foreach (GridViewRow item in GridView2.Rows)
                    {
                        Label sno = (Label)item.FindControl("lbl_sno");
                        Label lbl_mandal = (Label)item.FindControl("lbl_mandal");
                        if(lbl_mandal.Text=="Total")
                        {
                            sno.Text = "";
                        }
                    }
                    Session["mandalexcel"] = dt;




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
        protected void OnDataBound(object sender, EventArgs e)
        {
            string today = "";
            string yesterday = "";
            today = DateTime.Now.ToString("dd.MM.yyyy");
            yesterday = DateTime.Today.AddDays(-1).ToString("dd.MM.yyyy");
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();

            cell.Text = "Already Approved";
            cell.ColumnSpan = 2;
            cell.Attributes.Add("style", "text-align:center !important;");

            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Attributes.Add("style", "text-align:center !important;");
            cell.Text = "Upto Yesterday  (" + yesterday + ")";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Attributes.Add("style", "text-align:center !important;");
            cell.Text = "As on Today (" + today + ")";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Attributes.Add("style", "text-align:center !important;");
            cell.Text = "Cumulative as on " + today;

            row.Controls.Add(cell);

            row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            // GridView.HeaderRow.Parent.Controls.AddAt(0, row);
        }
        protected void OnDataBoundMandal(object sender, EventArgs e)
        {
            string today = "";
            string yesterday = "";
            today = DateTime.Now.ToString("dd.MM.yyyy");
            yesterday = DateTime.Today.AddDays(-1).ToString("dd.MM.yyyy");
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();



            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Attributes.Add("style", "text-align:center !important;");
            cell.Text = "Upto Yesterday  (" + yesterday + ")";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Attributes.Add("style", "text-align:center !important;");
            cell.Text = "As on Today (" + today + ")";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.ColumnSpan = 2;
            cell.Attributes.Add("style", "text-align:center !important;");
            cell.Text = "Cumulative as on " + today;

            row.Controls.Add(cell);

            row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            GridView2.HeaderRow.Parent.Controls.AddAt(0, row);
        }
        protected void Get_back_dist(object sender, EventArgs e)
        {

            div_dist.Visible = true;
            div_mandal.Visible = false;
            btn_back_dist.Visible = false;

            btn_upload.Visible = true;
            btn_notupload.Visible = false;

        }


        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.BindData("");
                string Filename = "Benificiarywise Land Status Report" + DateTime.Now + ".xls";
                Response.ClearContent();
                Response.Clear();
                Response.Buffer = true;
                Response.ClearHeaders();
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                StringWriter str = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(str);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //GridView.AllowPaging = false;
                //GridView.GridLines = GridLines.Both;
                //GridView.HeaderStyle.Font.Bold = true;
                GridView.RenderControl(htw);
                Response.Write(str.ToString());
                Response.Flush();
                Response.Close();
                Response.End();

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
               
                this.BindMandal("");
                string Filename = "Mandalwise Land Status Report" + DateTime.Now + ".xls";
                Response.ClearContent();
                Response.Clear();
                Response.Buffer = true;
                Response.ClearHeaders();
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                StringWriter str = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(str);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                GridView2.AllowPaging = false;
                GridView2.GridLines = GridLines.Both;
                GridView2.HeaderStyle.Font.Bold = true;
                GridView2.RenderControl(htw);
                Response.Write(str.ToString());
                Response.Flush();
                Response.Close();
                Response.End();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

    }
}
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
    public partial class Nothavinglanddetailsreport : System.Web.UI.Page
    {
        DataTable dtTest = new DataTable();
        DataTable dtTest1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.Button1);
                scriptManager.RegisterPostBackControl(this.Button3);
                if (!this.IsPostBack)
                {
                    BindData("");
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
                if (form != "")
                {
                    dt = (DataTable)Session["dtDistrictMadalas"];
                }
                else
                {
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.Nothavinglanddetailsreport();
                }
                if (dt.Rows.Count > 0)
                {

                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno"] = i + 1;
                    }
                    GridView1.DataSource = dt;

                    GridView1.DataBind();
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {

                            string value = dt.Rows[i][j].ToString();
                            if (i != dt.Rows.Count - 1)
                            {
                                if ((j == 4 && value == "0"))
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;

                                }
                            }
                            if (i == dt.Rows.Count - 1)
                            {


                                if (j == 2 || j == 3)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }

                                if (j == 4)
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
                            }

                        }
                    }

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





        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        protected void Backtonohavingcounts(object sender, EventArgs e)
        {
            
            GridView1.Visible = true;
            Button1.Visible = true;
            Button3.Visible = false;
            Button2.Visible = false;
            GridView2.Visible = false;
        }

        protected void Rejected_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);

                GridView1.Visible = false;
                Button1.Visible = false;
                Button3.Visible = true;
                Button2.Visible = true;
                GridView2.Visible = true;

                DataTable dt = new DataTable();
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');

                string start = s.Substring(0, range);

                string end = s.Substring(s.LastIndexOf(',') + 1);

                string itda = start.Trim();
                string district = end.Trim();
                dt = MastersDataAnalysisBAL.MastersDataAnalysis.Nothavinglanddetailslevelreport(itda, district);
                GridView2.DataSource = dt;

                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }


        }



        protected void ExportToExcel(object sender, EventArgs e)
        {
            try
            {
                updatepanel1.Visible = false;
                this.BindData("");
                string Filename = "Not having Land Details Count Report" + DateTime.Now + ".xls";
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
                GridView1.AllowPaging = false;
                GridView1.GridLines = GridLines.Both;
                GridView1.HeaderStyle.Font.Bold = true;
                GridView1.RenderControl(htw);
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

        protected void ExportToExcelDetails(object sender, EventArgs e)
        {
            try
            {
                updatepanel1.Visible = false;
                //  this.BindData("");
                string Filename = "Not having Land Details Report" + DateTime.Now + ".xls";
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
    }
}
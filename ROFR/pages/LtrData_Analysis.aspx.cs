using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;

namespace ROFR.pages
{
    public partial class LtrData_Analysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    
                    Session["username1"] = "";

                    DataTable dtUser = ProjectRofrBAL.GetMasterDetails.User_Authentication((string)(Session["username"]));
                    if (dtUser.Rows.Count > 0)
                    {
                        Session["userprevilages"] = dtUser.Rows[0]["User_privileges"].ToString();
                        if ((string)(Session["userprevilages"]) == "ALL")
                        {
                            DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis("ALL", "", "", "");
                            BindData(dt);
                        }
                        else
                        {
                            DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis((string)(Session["userprevilages"]), "", "", "");
                            BindData(dt);
                        }


                    }


                    // Hide back button on first load
                    btnback.Visible = false;


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
        protected void btnback_Click(object sender, EventArgs e)
        {
            try
            {
                string levelk = (string)(Session["username1"]);
                if (levelk == "Village")
                {
                    Session["username1"] = "district";
                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis((string)(Session["itda"]), (string)(Session["dist"]), "", "");
                    BindData(dt);
                    btnback.Visible = true; // still visible because District level
                }
                else if (levelk == "district")
                {
                    Session["username1"] = "";
                    if ((string)(Session["userprevilages"]) == "ALL")
                    {
                        DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis("ALL", "", "", "");
                        BindData(dt);
                        div_field.Visible = false;
                    }
                    else
                    {
                        DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis((string)(Session["userprevilages"]), "", "", "");
                        BindData(dt);
                        btnback.Visible = false; // hide back button because top level
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

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            string value = dt.Rows[i][j].ToString();

                            if (i != (dt.Rows.Count))
                            {
                                if ((value == "0" && (j == 2 || j == 3)))
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
                                else if ((value != "0" && (j == 2 || j == 3)))
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = true;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = false;
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


        protected void dislink_onclick(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string dist = s.Substring(0, range);
                string itda = s.Substring(s.LastIndexOf(',') + 1);
                if (dist != "" && itda != "")
                {
                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis(itda, dist, "", "");
                    if (dt.Rows.Count > 0)
                    {
                        Session["username1"] = "district";
                        btnback.Visible = true; // Show back button
                        Session["itda"] = itda;
                        Session["dist"] = dist;
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

        protected void manlink_onclick(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string mandal = s.Substring(0, range);

                string dist = s.Substring(s.LastIndexOf(',') + 1);
                string substring = dist;
                var range1 = dist.IndexOf('-');
                string dist1 = dist.Substring(0, range1);
                string itda1 = dist.Substring(dist.LastIndexOf('-') + 1);
                if (dist1 != "" && itda1 != "" && mandal != "")
                {
                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis(itda1, dist1, mandal, "");
                    if (dt.Rows.Count > 0)
                    {

                        Session["username1"] = "Village";
                        btnback.Visible = true; // Show back button
                        Session["itda"] = itda1;
                        Session["dist"] = dist1;
                        Session["mandal"] = mandal;
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

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                string level = (string)(Session["username1"]);
                if (level == "")
                {
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;

                    if (e.Row.RowType == DataControlRowType.Header)
                    {
                        GridView HeaderGrid = (GridView)sender;
                        GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                        TableCell HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "SDC";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "ADDITIONAL AGENT";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "AGENT GOVT";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "GOVT";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "HIGHCOURT";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

                    }
                }
                else if (level == "district")
                {
                    e.Row.Cells[4].Visible = false;

                    if (e.Row.RowType == DataControlRowType.Header)
                    {
                        GridView HeaderGrid = (GridView)sender;
                        GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                        TableCell HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "SDC";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "ADDITIONAL AGENT";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "AGENT GOVT";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "GOVT";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "HIGHCOURT";
                        HeaderCell.ColumnSpan = 2;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderCell.ForeColor = System.Drawing.Color.White;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.BackColor = System.Drawing.Color.Green;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btnexcel_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                string filename = "";
                DataTable dt = new DataTable();
                if ((string)(Session["username1"]) == "")
                {
                    filename = "ItdaData";
                    if ((string)(Session["userprevilages"]) == "ALL")
                    {

                        dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis("ALL", "", "", "");
                    }
                    else
                    {
                        dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis((string)(Session["userprevilages"]), "", "", "");
                    }

                }
                else if ((string)(Session["username1"]) == "district")
                {
                    filename = "DistrictData";
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis((string)(Session["itda"]), (string)(Session["dist"]), "", "");
                }
                else if ((string)(Session["username1"]) == "Village")
                {
                    filename = "MandalData";
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetltrMasterAnalysis((string)(Session["itda"]), (string)(Session["dist"]), (string)(Session["mandal"]), "");
                }
                filename = filename + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

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
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
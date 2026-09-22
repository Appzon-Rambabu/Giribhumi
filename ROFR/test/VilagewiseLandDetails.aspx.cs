using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;

namespace ROFR.test
{
    public partial class VilagewiseLandDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "VilagewiseLandDetails.aspx")
                    {
                        string Itda = (string)(Session["ItdaMandalvalue"]);
                        string Mandal =(string)(Session["Mandalvalue"]);
                        txtItda.Text = Itda;
                        txtmandal.Text = Mandal;
                        if (Itda != "" )
                        {
                            if (Mandal != "")
                            {
                                BindData(Itda, Mandal);
                            }
                        }
                    }
                    else
                    {
                        if((string)(Session["ItdaMandalvalue"])!="" && (string)(Session["Mandalvalue"])!="")
                        {
                        string Itda = (string)(Session["ItdaMandalvalue"]);
                        string Mandal = (string)(Session["Mandalvalue"]);
                        txtItda.Text = Itda;
                        txtmandal.Text = Mandal;
                        if (Itda != "")
                        {
                            if (Mandal != "")
                            {
                                BindData(Itda, Mandal);
                            }
                        }
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

        protected void BindData(string Itda, string Mandal)
        {
            try
            {
                DataTable dt = Landsettlementpattas.ItdaWiseGetData(Itda,Mandal);
               // dt = calculatetotals(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= 5; j++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {
                                if (j == 2)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.Black;
                                }
                              else  if (j == 3)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.Black;
                                }
                                else
                                {
                                    if (j != 0)
                                    {
                                        string IL = "lbl";
                                        IL = IL + j;
                                        Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = true;
                                        lbl.ForeColor = System.Drawing.Color.Black;
                                    }
                                }
                            }
                            else if (i == dt.Rows.Count - 2)
                            {
                                if(Itda!="CHINTUR")
                                { 
                                if (j == 2)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = true;
                                    ibutton.ForeColor = System.Drawing.Color.Red;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = false;
                                    lbl.ForeColor = System.Drawing.Color.Green;
                                }
                              else  if (j == 3)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.Green;
                                }
                                else
                                {
                                    if (j != 0)
                                    {
                                        string IL = "lbl";
                                        IL = IL + j;
                                        Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = true;
                                        lbl.ForeColor = System.Drawing.Color.Green;
                                    }
                                    else
                                    {
                                        string IL = "lbl";
                                        IL = IL + j;
                                        Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = false;
                                       
                                    }
                                }
                            }

                                else if (Itda == "CHINTUR")
                                {
                                    if (j == 2)
                                    {
                                        string IB = "LinkButton";
                                        IB = IB + j;
                                        string IL = "lbl";
                                        IL = IL + j;
                                        LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                        ibutton.Visible = false;
                                        ibutton.ForeColor = System.Drawing.Color.Red;
                                        Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = true;
                                        lbl.ForeColor = System.Drawing.Color.Blue;
                                    }
                                }
                            }
                            else
                            {
                                if(j==2)
                                {

                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    ibutton.ForeColor = System.Drawing.Color.Green;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.Green;
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

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                Session["CurrentPage"] = "CompartementNumberwiseLand.aspx";

                if (start != "Total:")
                {
                    Session["Mandalvalue"] = (string)(Session["Mandalvalue"]);
                    Session["ItdaMandalvalue"] = (string)(Session["ItdaMandalvalue"]);
                    Session["Villagevalue"] = start.Trim();
                    Response.Redirect("~//test//CompartementNumberwiseLand.aspx");
                }




            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void link_onclick1(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                Session["CurrentPage"] = "Compartments_In_Villages.aspx";

                if (start != "Total:")
                {
                    Session["Mandalvalue"] = (string)(Session["Mandalvalue"]);
                    Session["ItdaMandalvalue"] = (string)(Session["ItdaMandalvalue"]);
                    Session["Villagevalue"] = start.Trim();
                    Response.Redirect("~//test//Compartments_In_Villages.aspx");
                }




            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }


        protected DataTable calculatetotals(DataTable dt)
        {
            DataTable dtfinal = new DataTable();
            dtfinal = dt;
            try
            {
                var totalreceived = 0.00M;
                var ROFRPATTDAARBlank = 0;
                var Adhharisvalid = 0.00M;
                var Adhharnoinvalid = 0.00M;

                if (dtfinal.Rows.Count > 0)
                {
                    DataRow dr1 = dt.NewRow();
                    foreach (DataRow dr in dtfinal.Rows)
                    {
                        dr1["Village"] = "Total:";
                        ROFRPATTDAARBlank += (dr["calTotal_Compartments"].ToString() == "") ? 0 : int.Parse(dr["calTotal_Compartments"].ToString());
                        dr1["Total_Compartments"] = ROFRPATTDAARBlank;
                        totalreceived += (dr["Total_Beneficiaries"].ToString() == "") ? 0 : int.Parse(dr["Total_Beneficiaries"].ToString());
                        dr1["Total_Beneficiaries"] = totalreceived;
                        Adhharisvalid += (dr["Beneficiaries_Having_Adhaar_no"].ToString() == "") ? 0 : int.Parse(dr["Beneficiaries_Having_Adhaar_no"].ToString());
                        dr1["Beneficiaries_Having_Adhaar_no"] = Adhharisvalid;
                        Adhharnoinvalid += (dr["Total_Land"].ToString() == "") ? 0 : decimal.Parse(dr["Total_Land"].ToString());
                        dr1["Total_Land"] = Adhharnoinvalid;
                    }
                    dtfinal.Rows.Add(dr1);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return dtfinal;

        }

        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtbeneficiareies = new DataTable();
                dtbeneficiareies = Landsettlementpattas.ItdaWiseGetData((string)(Session["ItdaMandalvalue"]), (string)(Session["Mandalvalue"]));
                if (dtbeneficiareies.Rows.Count > 0)
                {
                    DataView DV = dtbeneficiareies.AsDataView();
                    DV.RowFilter = string.Format("Village LIKE '%{0}%'", txtSearch.Text);
                    GridView1.DataSource = DV;

                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Session["CurrentPage"] = "MandalwiseLandDetails.aspx";
                Session["Itdavalue"] = (string)(Session["ItdaMandalvalue"]);
                Response.Redirect("~//test//MandalwiseLandDetails.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Landsettlementpattas.ItdaWiseGetData((string)(Session["ItdaMandalvalue"]), (string)(Session["Mandalvalue"]));
                //dt = calculatetotals(dt);
                dt.Columns["Village"].ColumnName = "VILLAGE";
                dt.Columns["Total_Compartments"].ColumnName = "Compartments";
                dt.Columns["Total_Beneficiaries"].ColumnName = "Beneficiaries";
                dt.Columns["Beneficiaries_Having_Adhaar_no"].ColumnName = "No of Beneficiaries Having Adhaar No";
                dt.Columns["Total_Land"].ColumnName = "Total Land (In Acres)";
                if (dt.Rows.Count > 0)
                {
                    string filename = "VillageWiseLandSummaryReportExcel.xls";
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
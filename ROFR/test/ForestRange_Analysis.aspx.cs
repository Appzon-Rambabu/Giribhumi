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
    public partial class ForestRange_Analysis : System.Web.UI.Page
    {

        DataTable dtTest = new DataTable();
        DataTable dtTest1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentRangeAnalysisPage"]) == "ForestRange_Analysis.aspx" && (string)(Session["CurrentForestRangeAnalysisPage"]) == "")
                    {
                        BindData("Mandal");
                    }
                    else if ((string)(Session["CurrentRangeAnalysisPage"]) == "" && (string)(Session["CurrentForestRangeAnalysisPage"]) == "ForestRange_Analysis.aspx")
                    {
                        BindData("Division");
                    }
                    else
                    {
                        BindData("ALL");
                    }



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
        protected void BindData(string type)
        {
            try
            {

                DataTable dt = new DataTable();
                if (type == "Mandal")
                {
                    dt = (DataTable)Session["dtMandalRanges"];
                }
                else if (type == "Division")
                {
                    dt = (DataTable)Session["dtForestRanges"];
                }
                else if (type == "ALL")
                {
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetForestRangeAnalysis("", "", "6", "");
                }
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
                                if ((value == "0" && j > 10))
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
                                else if ((value != "0" && j > 10))
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
                    if (type == "Mandal" || type == "Division")
                    {
                        Session["CurrentForestRangeAnalysisPage"] = "";
                        Session["CurrentRangeAnalysisPage"] = "";
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
        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {

                string district = string.Empty;
                string mandal = string.Empty;
                string division = string.Empty;
                string range = string.Empty;
                string end = string.Empty;
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var districtrange = s.IndexOf('-');

                district = s.Substring(0, districtrange);
                string MMandal = s.Substring(s.LastIndexOf('-') + 1);

                string t = MMandal;
                var mandalrange = t.IndexOf('&');
                mandal = t.Substring(0, mandalrange);
                string division1 = t.Substring(t.LastIndexOf('&') + 1);

                string f = division1;
                var divisionrange = f.IndexOf('#');
                division = f.Substring(0, divisionrange);
                string range1 = f.Substring(f.LastIndexOf('#') + 1);

                string v = range1;
                var Rrange = v.IndexOf(',');
                range = v.Substring(0, Rrange);
                end = v.Substring(v.LastIndexOf(',') + 1);

                if (end == "11")
                {
                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetrangeBeats(district, mandal, division, range);
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtrangeBeats = new DataTable();
                        Session["dtrangeBeats"] = dt;
                        Session["CurrentrangeBeatsAnalysisPage"] = "ForestBeat_Analysis.aspx";
                        Session["CurrentvillagebeatsAnalysisPage"] = "";
                        {
                            Response.Redirect("~//test//ForestBeat_Analysis.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                    }
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
    }
}
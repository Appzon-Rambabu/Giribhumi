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
    public partial class MandalMaster_Analysis : System.Web.UI.Page
    {
        DataTable dtTest = new DataTable();
        DataTable dtTest1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentMandalAnalysisPage"]) == "MandalMaster_Analysis.aspx")
                    {
                        BindData((string)(Session["CurrentMandalAnalysisPage"]));
                    }
                    else
                    {
                        BindData("");
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
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetDistrictMasterAnalysis("start", "4", "", "ALL");
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
                                if ((value == "0" && j > 6))
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
                                else if ((value != "0" && j > 6))
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

                    if (form != "")
                    {
                        Session["CurrentMandalAnalysisPage"] = "";
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
                string end = string.Empty;
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var districtrange = s.IndexOf('-');
                if (districtrange != -1)
                {
                    district = s.Substring(0, districtrange);
                    string MMandal = s.Substring(s.LastIndexOf('-') + 1);
                    string t = MMandal;
                    var mandalrange = t.IndexOf(',');
                    mandal = t.Substring(0, mandalrange);
                    end = t.Substring(t.LastIndexOf(',') + 1);
                }
                else
                {
                    var range = s.IndexOf(',');
                    mandal = s.Substring(0, range);
                    end = s.Substring(s.LastIndexOf(',') + 1);
                }

                if (end == "7")
                {
                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetMandalMasterAnalysis(district, mandal, "7", "");
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtMadalaVillages = new DataTable();
                        Session["dtMadalaVillages"] = dt;
                        Session["CurrentVillageAnalysisPage"] = "VillageMaster_Analysis.aspx";
                        {
                            Response.Redirect("~//test//VillageMaster_Analysis.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                    }
                }
                else if (end == "8")
                {
                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetMandalMasterAnalysis(district, mandal, "8", "");
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtMandalRanges = new DataTable();
                        Session["dtMandalRanges"] = dt;
                        Session["CurrentRangeAnalysisPage"] = "ForestRange_Analysis.aspx";
                        Session["CurrentForestRangeAnalysisPage"] = "";
                        {
                            Response.Redirect("~//test//ForestRange_Analysis.aspx");
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
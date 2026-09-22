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

    public partial class ForestDivision_Analysis : System.Web.UI.Page
    {
        DataTable dtTest = new DataTable();
        DataTable dtTest1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    if ((string)(Session["CurrentDivisionAnalysisPage"]) == "ForestDivision_Analysis.aspx")
                    {
                        BindData((string)(Session["CurrentDivisionAnalysisPage"]));
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
                    dt = (DataTable)Session["dtDistrictVillages"];
                }
                else
                {
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetDistrictMasterAnalysis("start", "", "5", "ALL");
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
                                if ((value == "0" && j > 5))
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
                                else if ((value != "0" && j > 5))
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
                        Session["CurrentDivisionAnalysisPage"] = "";

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
                System.Threading.Thread.Sleep(5000);
                string district = string.Empty;
                string division = string.Empty;
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
                    division = t.Substring(0, mandalrange);
                    end = t.Substring(t.LastIndexOf(',') + 1);
                }

                if (end == "6")
                {
                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetForestDivisionAnalysis(district, division, "6", "");
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtForestRanges = new DataTable();
                        Session["dtForestRanges"] = dt;
                        Session["CurrentForestRangeAnalysisPage"] = "ForestRange_Analysis.aspx";
                        Session["CurrentRangeAnalysisPage"] = "";
                        {
                            Response.Redirect("ForestRange_Analysis.aspx");
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
        protected void Get_District(object sender, EventArgs e)
        {
            Response.Redirect("DistictData_Analysis.aspx");
        }
    }
}
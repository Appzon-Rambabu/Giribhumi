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
    public partial class VillageMaster_Analysis : System.Web.UI.Page
    {
        DataTable dtTest = new DataTable();
        DataTable dtTest1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentVillageAnalysisPage"]) == "VillageMaster_Analysis.aspx")
                    {
                        BindData((string)(Session["CurrentVillageAnalysisPage"]));
                        Select_Records.Visible = false;
                    }
                    else
                    {
                        Select_Records.Visible = true;
                        BindCount();
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
                    dt = (DataTable)Session["dtMadalaVillages"];
                }
                else
                {
                    string a = ddl_records.SelectedItem.Text;
                    var range = a.IndexOf('-');

                    string start = a.Substring(0, range);
                    string end = a.Substring(a.LastIndexOf('-') + 1);
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.Getbasedonvillagestartandend(start, end);
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
                                if ((value == "0" && j == 10))
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
                                else if ((value != "0" && j == 10))
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
                        Session["CurrentVillageAnalysisPage"] = "";
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

        protected void ddlrecords_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                BindData("");

                //GridView1.DataSource = null;
                //GridView1.Visible = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        public void BindCount()
        {
            try
            {
                DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetMandalMasterAnalysis("start", "", "7", "ALL");
                if (dt.Rows.Count > 0)
                {
                    ListItemCollection list = new ListItemCollection();
                    int rowscount = Convert.ToInt32(dt.Rows[0]["count"].ToString());
                    string k = string.Empty;
                    for (int i = 1; i <= rowscount; i++)
                    {
                        if (rowscount <= 100)
                        {
                            int j = i + (rowscount - 1);
                            k = i + "-" + j;
                            list.Add(new ListItem(k));
                            i = j;
                        }
                        else
                        {
                            int remainingrows = rowscount - i;
                            if (remainingrows > 100)
                            {
                                int j = i + 99;
                                k = i + "-" + j;
                                list.Add(new ListItem(k));
                                i = j;
                            }
                            else
                            {
                                int j = (i) + remainingrows;
                                k = i + "-" + j;
                                list.Add(new ListItem(k));
                                i = j;
                                break;
                            }
                        }
                    }
                    ddl_records.DataSource = list;
                    ddl_records.DataBind();
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
                string mandal = string.Empty;
                string village = string.Empty;
                string end = string.Empty;
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var districtrange = s.IndexOf('-');

                district = s.Substring(0, districtrange);
                string MMandal = s.Substring(s.LastIndexOf('-') + 1);
                string t = MMandal;
                var mandalrange = t.IndexOf('&');
                mandal = t.Substring(0, mandalrange);
                string village1 = t.Substring(t.LastIndexOf('&') + 1);
                string v = village1;
                var villagerange = v.IndexOf(',');
                village = v.Substring(0, villagerange);
                end = v.Substring(v.LastIndexOf(',') + 1);

                if (end == "10")
                {
                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetvillageBeats(district, mandal, village);
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtvillagebeats = new DataTable();
                        Session["dtvillagebeats"] = dt;
                        Session["CurrentvillagebeatsAnalysisPage"] = "ForestBeat_Analysis.aspx";
                        Session["CurrentrangeBeatsAnalysisPage"] = "";
                        {
                            Response.Redirect("ForestBeat_Analysis.aspx");
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

        protected void Get_Mandal(object sender, EventArgs e)
        {
            Response.Redirect("MandalMaster_Analysis.aspx");

        }
    }
}
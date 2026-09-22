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
    public partial class ForestBeat_Analysis : System.Web.UI.Page
    {
        DataTable dtTest = new DataTable();
        DataTable dtTest1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentvillagebeatsAnalysisPage"]) == "ForestBeat_Analysis.aspx" && (string)(Session["CurrentrangeBeatsAnalysisPage"]) == "")
                    {
                        BindData("Village");
                    }
                    else if ((string)(Session["CurrentvillagebeatsAnalysisPage"]) == "" && (string)(Session["CurrentrangeBeatsAnalysisPage"]) == "ForestBeat_Analysis.aspx")
                    {
                        BindData("Range");
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
                if (type == "Village")
                {
                    dt = (DataTable)Session["dtvillagebeats"];
                }
                else if (type == "Range")
                {
                    dt = (DataTable)Session["dtrangeBeats"];
                }
                else if (type == "ALL")
                {
                    dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetAllBeats();
                }
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();

                    //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    //{
                    //    for (int j = 0; j <= dt.Columns.Count - 1; j++)
                    //    {
                    //        string value = dt.Rows[i][j].ToString();

                    //        if (i != (dt.Rows.Count - 1))
                    //        {
                    //            if ((value == "0" && j > 9))
                    //            {
                    //                string IB = "LinkButton";
                    //                IB = IB + j;
                    //                string IL = "lbl";
                    //                IL = IL + j;
                    //                LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                    //                ibutton.Visible = false;
                    //                Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                    //                lbl.Visible = true;

                    //            }
                    //            else if ((value != "0" && j > 9))
                    //            {
                    //                string IB = "LinkButton";
                    //                IB = IB + j;
                    //                string IL = "lbl";
                    //                IL = IL + j;
                    //                LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                    //                ibutton.Visible = true;
                    //                Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                    //                lbl.Visible = false;
                    //            }
                    //        }


                    //    }

                    //}

                    if (type == "Village" || type == "Range")
                    {
                        Session["CurrentvillagebeatsAnalysisPage"] = "";
                        Session["CurrentrangeBeatsAnalysisPage"] = "";
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

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                DataSet ds = ProjectRofrBAL.GetMasterDetails.GetBeneficiaryDetailsAnalysis(start, (string)(Session["username"]));


                if (end == "6")
                {

                    Session["dtTest"] = ds.Tables[5];
                    Session["dtTest1"] = ds.Tables[6];
                    Response.Redirect("~//test//ROFR_Col_Split");
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
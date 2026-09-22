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
    public partial class Data_Master_Analysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    BindData();

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

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMasterDetailsAnalysis();

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();
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
                DataSet ds = new DataSet();
                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMasterDetailsAnalysis();
                Session["CurrentPage"] = "Data_Master_Analysis.aspx";


                if (end == "1")
                {
                    Session["dtTest"] = ds.Tables[1];

                }

                else if (end == "2")
                {
                    Session["dtTest"] = ds.Tables[2];

                }

                else if (end == "3")
                {
                    Session["dtTest"] = ds.Tables[3];

                }


                else if (end == "4")
                {
                    Session["dtTest"] = ds.Tables[4];

                }




                else if (end == "5")
                {
                    Session["dtTest"] = ds.Tables[5];

                }


                else if (end == "6")
                {
                    Session["dtTest"] = ds.Tables[6];

                }



                else if (end == "7")
                {
                    Session["dtTest"] = ds.Tables[7];

                }

                else if (end == "8")
                {
                    Session["dtTest"] = ds.Tables[8];

                }
                else if (end == "9")
                {
                    Session["dtTest"] = ds.Tables[9];

                }
                else if (end == "10")
                {
                    Session["dtTest"] = ds.Tables[10];

                }
                else if (end == "11")
                {
                    Session["dtTest"] = ds.Tables[11];

                }
                else if (end == "12")
                {
                    Session["dtTest"] = ds.Tables[12];

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
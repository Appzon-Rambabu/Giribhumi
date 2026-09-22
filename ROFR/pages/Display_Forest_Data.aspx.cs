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
    public partial class Display_Forest_Data : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    ddl_records.Items.Insert(0, new ListItem("Select", "0"));
                    BindCount();
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

                string district = (string)(Session["district"]);
                string FD = (string)(Session["FD"]);
                string FR = (string)(Session["FR"]);
                string FB = (string)(Session["FB"]);
                txt_district.Text = (string)(Session["dist"]);
                txt_FD.Text = (string)(Session["FD"]);
                txt_FR.Text = (string)(Session["FR"]);
                txt_FB.Text = (string)(Session["FB"]);
                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiariesData(district, FD, FR, FB, start, end, (string)(Session["username"]));

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    Response.Redirect("ROFR_FOREST_REPORT.aspx");
                }
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

                string district = (string)(Session["district"]);
                string FD = (string)(Session["FD"]);
                string FR = (string)(Session["FR"]);
                string FB = (string)(Session["FB"]);

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestRecordsCount(district, FD, FR, FB, (string)(Session["username"]));

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
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    Response.Redirect("ROFR_FOREST_REPORT.aspx");
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

                BindData();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
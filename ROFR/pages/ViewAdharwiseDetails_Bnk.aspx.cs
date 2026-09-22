using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.IO;

namespace ROFR.pages
{
    public partial class ViewAdharwiseDetails_Bnk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "ViewAdharwiseDetails_Bnk.aspx")
                    {

                        string bid = (string)(Session["bid"]);
                        lbl_itda.Text = bid;

                        if (bid != "")
                        {
                            BindGrid();
                        }
                    }
                    else
                    {
                        if ((string)(Session["bid"]) != "")
                        {
                            string bid = (string)(Session["bid"]);
                            lbl_itda.Text = bid;

                            if (bid != "")
                            {
                                BindGrid();
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

        protected void BindGrid()
        {
            try
            {
                DataTable dt = Landsettlementpattas.GetAdharwise_rofrdata("admin", "details", (string)(Session["bid"]), (string)(Session["Adhar"]), (string)Session["userprevilages"]);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);
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
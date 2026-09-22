using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using ROFR.helper;

namespace ROFR.pages
{
    public partial class Beneficiary_Analysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentBeneficiaryAnalysisPage"]) == "Beneficiary_Analysis.aspx")
                    {
                        txt_district.Text = (string)(Session["DISTRICT"]);
                        txt_itda.Text = (string)(Session["ITDA"]);
                        BindData((string)(Session["CurrentBeneficiaryAnalysisPage"]));
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

        protected void BindData(string form)
        {
            try
            {
                DataTable dt = new DataTable();

                dt = (DataTable)Session["dtbeneficiary"];

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();


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

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Beneficiary_Master_analysis.aspx");
        }

        protected void txtSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
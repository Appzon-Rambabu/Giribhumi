using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.IO;

namespace ROFR.test
{
    public partial class View_FarmerPlots : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           


            try
            {
                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "View_FarmerPlots.aspx")
                    {
                        string Itda = (string)(Session["Itda"]);
                        string dist = (string)(Session["District"]);
                        string mandal = (string)(Session["Mandal"]);
                        string village = (string)(Session["Village"]);
                        string bid = (string)(Session["bid"]);
                        lbl_itda.Text = Itda;
                        lbl_dist.Text = dist;
                        lbl_mandal.Text = mandal;
                        lbl_village.Text = village;
                        if (bid != "")
                        {
                            BindGrid();
                        }
                    }
                    else
                    {
                        if ((string)(Session["bid"]) != "" )
                        {
                            string Itda = (string)(Session["Itda"]);
                            string dist = (string)(Session["District"]);
                            string mandal = (string)(Session["Mandal"]);
                            string village = (string)(Session["Village"]);
                            string bid = (string)(Session["bid"]);
                            lbl_itda.Text = Itda;
                            lbl_dist.Text = dist;
                            lbl_mandal.Text = mandal;
                            lbl_village.Text = village;
                            if (bid != "" )
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
            DataTable dt = Landsettlementpattas.ViewBeneficiaryPlots((string)(Session["bid"]), (string)(Session["userprevilages"]), (string)(Session["username"]));
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ROFR.helper;

namespace ROFR.test
{
    public partial class DetailsView_1B : System.Web.UI.Page
    {
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            if ((string)(Session["username"]) != null)
            {
                this.MasterPageFile = "~/Masters/Giribhumi_Master.Master";
            }
            else
            {

                this.MasterPageFile = "~/Masters/Giribhumi_Master.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "DetailsView_1B.aspx")
                    {
                        string Itda = (string)(Session["Itda"]);
                        string dist = (string)(Session["District"]);
                        string mandal = (string)(Session["Mandal"]);
                        string village = (string)(Session["Village"]);
                        string pattadar = (string)(Session["pattadar"]);
                        lbl_itda.Text = Itda;
                        lbl_dist.Text = dist;
                        lbl_mandal.Text = mandal;
                        lbl_village.Text = village;
                        if (pattadar != "" )
                        {
                            BindData(Itda, dist, mandal, village, pattadar);
                        }
                    }
                    else
                    {
                        if ((string)(Session["pattadar"]) != "" )
                        {
                            string Itda = (string)(Session["Itda"]);
                            string dist = (string)(Session["District"]);
                            string mandal = (string)(Session["Mandal"]);
                            string village = (string)(Session["Village"]);
                            string pattadar = (string)(Session["pattadar"]);
                            lbl_itda.Text = Itda;
                            lbl_dist.Text = dist;
                            lbl_mandal.Text = mandal;
                            lbl_village.Text = village;
                            if (pattadar != "" )
                            {
                                BindData(Itda, dist, mandal, village, pattadar);
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

        protected void BindData(string Itda, string dist, string mandal, string village,string pattadar)
        {
            try
            {

                
                DataTable dt = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "1bdetails", Itda, dist, mandal, village, pattadar, "", "", "", (string)Session["userprevilages"]);
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

    }
}
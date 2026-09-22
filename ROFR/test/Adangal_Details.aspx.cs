using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;

namespace ROFR.test
{
    public partial class Adangal_Details : System.Web.UI.Page
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
                    if ((string)(Session["CurrentPage"]) == "Adangal_Details.aspx")
                    {
                        string Itda = (string)(Session["Itda"]);
                        string dist = (string)(Session["District"]);
                        string mandal = (string)(Session["Mandal"]);
                        string village = (string)(Session["Village"]);
                        string cmno = (string)(Session["cmno"]);
                        lbl_itda.Text = Itda;
                        lbl_dist.Text = dist;
                        lbl_mandal.Text = mandal;
                        lbl_village.Text = village;
                        if (cmno != "")
                        {
                            BindData(Itda, dist, mandal, village, cmno);
                        }
                    }
                    else
                    {
                        if ((string)(Session["cmno"]) != "")
                        {
                            string Itda = (string)(Session["Itda"]);
                            string dist = (string)(Session["District"]);
                            string mandal = (string)(Session["Mandal"]);
                            string village = (string)(Session["Village"]);
                            string cmno = (string)(Session["cmno"]);
                            lbl_itda.Text = Itda;
                            lbl_dist.Text = dist;
                            lbl_mandal.Text = mandal;
                            lbl_village.Text = village;
                            if (cmno != "")
                            {
                                BindData(Itda, dist, mandal, village, cmno);
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

        protected void BindData(string Itda, string dist, string mandal, string village, string cmno)
        {
            try
            {


                DataTable dt = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "adangal", Itda, dist, mandal, village, "", "", cmno, "", (string)Session["userprevilages"]);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using ROFR.helper;

namespace ROFR.pages
{
    public partial class DetailsView_1B : System.Web.UI.Page
    {
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            //if ((string)(Session["username"]) != null)
            //{
            //    this.MasterPageFile = "~/Masters/ROFR_MASTER.Master";
            //}
            //else
            //{

            //    this.MasterPageFile = "~/Masters/ROFR_MASTER.Master";
            //}
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
                        string adharno = (string)(Session["aano"]); //add new aadhar
                        lbl_itda.Text = Itda;
                        lbl_dist.Text = dist;
                        lbl_mandal.Text = mandal;
                        lbl_village.Text = village;
                        if (pattadar != "" )
                        {
                            BindData(Itda, dist, mandal, village, pattadar, adharno); //add new aadhar 
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
                            string adharno = (string)(Session["aano"]);
                            
                            lbl_itda.Text = Itda;
                            lbl_dist.Text = dist;
                            lbl_mandal.Text = mandal;
                            lbl_village.Text = village;
                            if (pattadar != "" )
                            {
                                BindData(Itda, dist, mandal, village, pattadar, adharno); //add New aadhar
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

        protected void BindData(string Itda, string dist, string mandal, string village,string pattadar,string adharno)
        {
            try
            {

                
              DataTable dt = Landsettlementpattas.Get1bdetails("", "1bdetails", Itda, dist, mandal, village, pattadar, "", "", adharno, ""); //add aadhar 28-01-2026
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
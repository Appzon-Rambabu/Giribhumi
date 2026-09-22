using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;

namespace ROFR.test
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    BindDistrictcount();
                    
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void BindDistrictcount()
        {
            try
            {

                DataSet dS = ProjectRofrBAL.GetMasterDetails.Getdashboard();
                DataTable dt = dS.Tables[0];
                if (dt.Rows.Count > 0)
                {

                    distcount.InnerText= dt.Rows[0]["revienue_dist_count"].ToString();
                    Mandalcount.InnerText= dt.Rows[0]["revienue_mandals_count"].ToString();
                    Villcount.InnerText= dt.Rows[0]["revienue_villages_count"].ToString();
                    Fdistcount.InnerText = dt.Rows[0]["forest_dist_count"].ToString();
                    FMandalcount.InnerText = dt.Rows[0]["forest_mandal_count"].ToString();
                    Fvillcount.InnerText = dt.Rows[0]["forest_village_count"].ToString();
                    Fdivcount.InnerText = dt.Rows[0]["forest_division_count"].ToString();
                    Frangecount.InnerText = dt.Rows[0]["forest_ranges_count"].ToString();
                    Fbeatcount.InnerText = dt.Rows[0]["forest_beats_count"].ToString();
                    totalbenf.InnerText = dt.Rows[0]["target_ben"].ToString();
                    Abencount.InnerText = dt.Rows[0]["uniq_benf_count"].ToString();
                    Apercount.InnerText = dt.Rows[0]["avail_ben_percent"].ToString();
                    NAbencount.InnerText = dt.Rows[0]["benfi_diff"].ToString();
                    NApercount.InnerText = dt.Rows[0]["notavail_ben_percent"].ToString();
                    beneficiary.InnerText = dt.Rows[0]["tot_benf_count"].ToString();
                    Ebeneficary.InnerText = dt.Rows[0]["valid_benificiaries"].ToString();
                    Ebenfpercent.InnerText = dt.Rows[0]["percent_valid_benificiaries"].ToString();
                    NEbeneficiary.InnerText = dt.Rows[0]["not_valid_benificiaries"].ToString();
                    NEbenfpercent.InnerText = dt.Rows[0]["percent_valid_notbenificiaries"].ToString();
                    Cmptcount.InnerText = dt.Rows[0]["Compartment_valid"].ToString();
                    cmptpercent.InnerText = dt.Rows[0]["percent_cmpt_valid"].ToString();
                    NEcmptcount.InnerText = dt.Rows[0]["Compartment_Not_valid"].ToString();
                    NEcmptpercent.InnerText = dt.Rows[0]["percent_cmpt_notvalid"].ToString();
                    plotcount.InnerText = dt.Rows[0]["Plot_valid"].ToString();
                    plotpercent.InnerText = dt.Rows[0]["percent_plot_valid"].ToString();
                    NEplotcount.InnerText = dt.Rows[0]["Plot_Not_valid"].ToString();
                    NEplotpercent.InnerText = dt.Rows[0]["percent_plot_notvalid"].ToString();
                    Habitations.InnerText = dt.Rows[0]["Habitation_valid"].ToString();
                    Habpercent.InnerText = dt.Rows[0]["percent_Habitation_valid"].ToString();
                    NEhabcount.InnerText = dt.Rows[0]["Habitation_not_valid"].ToString();
                    NEhabpercent.InnerText = dt.Rows[0]["percent_Habitation_notvalid"].ToString();
                    plotarea.InnerText = dt.Rows[0]["ExtentPlotArea_valid"].ToString();
                    plotareapercent.InnerText = dt.Rows[0]["percent_extent_valid"].ToString();
                    NEplotareacount.InnerText = dt.Rows[0]["ExtentPlotArea_not_valid"].ToString();
                    NEplotareapercent.InnerText = dt.Rows[0]["percent_extent_notvalid"].ToString();
                    Pattano.InnerText = dt.Rows[0]["ROFR_PATTANO_valid"].ToString();
                    pattapercent.InnerText = dt.Rows[0]["percent_patta_valid"].ToString();
                    NEpattacount.InnerText = dt.Rows[0]["ROFR_PATTANO_not_valid"].ToString();
                    NEpattapercent.InnerText = dt.Rows[0]["percent_patta_notvalid"].ToString();

                     Eadhaar.InnerText = dt.Rows[0]["valid_Aadhaar_NO"].ToString();
                    Eadharpercent.InnerText = dt.Rows[0]["valid_Aadhaar_percent"].ToString();

                    NEadhaar.InnerText = dt.Rows[0]["not_valid_Aadhaar_NO"].ToString();

                    NEadharpercent.InnerText = dt.Rows[0]["not_valid_Aadhaar_percent"].ToString();

                    Eadhaar1.InnerText = dt.Rows[0]["invalid_aadhar"].ToString();
                    Eadharpercent1.InnerText = dt.Rows[0]["invalid_aadar_percent"].ToString();



                    // districts.InnerText= dt.Rows[0]["revienue_dist_count"].ToString();
                    districts.InnerText= dt.Rows[0]["forest_dist_count"].ToString();
                    mandals.InnerText = dt.Rows[0]["forest_mandal_count"].ToString();
                    villages.InnerText = dt.Rows[0]["forest_village_count"].ToString();
                    divisions.InnerText = dt.Rows[0]["forest_division_count"].ToString();
                    ranges.InnerText = dt.Rows[0]["forest_ranges_count"].ToString();
                    beats.InnerText = dt.Rows[0]["forest_beats_count"].ToString();






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
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
    public partial class Aadhaarwise_Beneficiary_Analysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindItda();
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));

                    div_getdetails.Visible = false;
                    Repeater1.Visible = false;

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindItda()
        {
            try

            {


                DataTable dtItda = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);

                if (dtItda.Rows.Count > 0)
                {
                    ddl_Itda.DataSource = dtItda;
                    ddl_Itda.DataTextField = "ITDA_NAME";
                    ddl_Itda.DataValueField = "ITDA_CODE";
                    ddl_Itda.DataBind();
                    ddl_Itda.Items.Insert(0, new ListItem("Select", "0"));
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

        private void BindDistrict(DataTable dt)
        {
            try
            {
                DataTable dtDistricts = dt;
                ddl_district.DataSource = dtDistricts;
                ddl_district.DataTextField = "DISTRICT_NAME";
                ddl_district.DataValueField = "LGD_DISTRICT_CODE";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddl_Itda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Repeater1.Visible = false;
                div_getdetails.Visible = false;
                if (ddl_Itda.SelectedItem.Text != "Select")
                {

                    DataTable dtdistrict = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "District", ddl_Itda.SelectedValue, "", "", "", "", (string)Session["userprevilages"]);
                    if (dtdistrict.Rows.Count > 0)
                    {

                        BindDistrict(dtdistrict);
                        //if (dtdistrict.Rows.Count <= 1)
                        //{


                        //    ddl_district.SelectedIndex = 1;
                           
                        //}

                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              

                if (ddl_district.SelectedItem.Text != "Select")
            {
                    div_getdetails.Visible = true;
                    Repeater1.Visible = true;
                    DataSet ds= Landsettlementpattas.GetAdhar_Analysis(ddl_Itda.SelectedItem.Text,ddl_district.SelectedItem.Text);
                    DataTable dt = ds.Tables[0];
                    txt_records.Text = dt.Rows[0]["RECORDSCOUNT"].ToString();
                    DataTable dt1 = ds.Tables[1]; 
                        txt_adhar.Text= dt1.Rows[0]["NOOFRECORDSHAVINGADHHAR"].ToString();
                    txt_uadhar.Text = dt1.Rows[0]["UNIQUECOUNTOFADHHARRECEIVED"].ToString();
                    DataTable dt2 = ds.Tables[2];
                    txt_valid_adhar.Text = dt2.Rows[0]["NOOFRECORDSHAVINGVAILDADHHAR"].ToString();
                    txt_uvalid_adhar.Text = dt2.Rows[0]["UNIQUECOUNTOFVAILDADHHAR"].ToString();
                    DataTable dt3 = ds.Tables[3];
                    txt_invadhar.Text = dt3.Rows[0]["NOOFRECORDSHAVINGINVAILDADHHAR"].ToString();
                    txt_uinvadhar.Text = dt3.Rows[0]["UNIQUECOUNTOFINVAILDADHHAR"].ToString();
                    DataTable dt4 = ds.Tables[4];
                    txt_rs_rtgs.Text = dt4.Rows[0]["RECORDSSENDTORTGS"].ToString();
                    txt_uadhar_rtgs.Text = dt4.Rows[0]["UNIQUEADHHARSENDTORTGSCOUNT"].ToString();
                   // txt_madhar_rtgs.Text = dt4.Rows[0]["SAMEADHHARMULTIPLERECORDS"].ToString();
                    DataTable dt5 = ds.Tables[5];
                    txt_rtgs_success.Text = dt5.Rows[0]["RTGSSENDTOPAYMNETSUCCESSRECORDS"].ToString();
                    txt_rtgs_usadhar.Text = dt5.Rows[0]["UNIQUEADHHARPAYMNETSUCCESSCOUNT"].ToString();
                   // txt_rtgs_musadhar.Text = dt5.Rows[0]["SAMEADHHARMULTIPLERECORDS"].ToString();

                    DataTable dt6 = ds.Tables[6];
                    txt_rtgs_failed.Text = dt6.Rows[0]["RTGSSENDTOPAYMNETFAILEDRECORDS"].ToString();
                    txt_rtgs_ufailed.Text = dt6.Rows[0]["UNIQUEADHHARPAYMNETFAILEDCOUNT"].ToString();
                    // txt_rtgs_mufailed.Text = dt6.Rows[0]["SAMEADHHARMULTIPLERECORDS"].ToString();
                    DataTable dt7 = ds.Tables[7];
                    if(dt7.Rows.Count>0)
                    {
                        Repeater1.DataSource = dt7;
                        Repeater1.DataBind();
                    }
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
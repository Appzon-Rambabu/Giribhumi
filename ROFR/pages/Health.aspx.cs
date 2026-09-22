using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data.SqlClient;
using System.Data;
using Oracle.ManagedDataAccess.Client;



namespace ROFR.pages
{
    public partial class Health : System.Web.UI.Page
    {
       
  


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                   // BindDistrict();
                    //BindFacility();
                    ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));

                   
                   

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        //private void BindDistrict()
        //{
        //    try

        //    {


        //        DataTable dtdist = Landsettlementpattas.GetHealthMasters("district","","");

        //        if (dtdist.Rows.Count > 0)
        //        {
        //            ddl_district.DataSource = dtdist;
        //            ddl_district.DataTextField = "DISTRICT";
        //            ddl_district.DataValueField = "DISTRICT_ID";
        //            ddl_district.DataBind();
        //            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}

        //private void BindFacility()
        //{
        //    try

        //    {


        //        DataTable dtf = Landsettlementpattas.GetHealthMasters("facility", "", "");

        //        if (dtf.Rows.Count > 0)
        //        {
        //            ddl_facility.DataSource = dtf;
        //            ddl_facility.DataTextField = "HEALTH_FACILITY";
        //            ddl_facility.DataValueField = "HEALTH_FACILITY";
        //            ddl_facility.DataBind();
        //            ddl_facility.Items.Insert(0, new ListItem("Select", "0"));
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}

        //private void BindHospital(DataTable dt)
        //{
        //    try
        //    {
        //        DataTable dthospital = dt;
        //        ddl_hospital.DataSource = dthospital;
        //        ddl_hospital.DataTextField = "HOSPTIAL_NAME";
        //        ddl_hospital.DataValueField = "HOSPTIAL_NAME";
        //        ddl_hospital.DataBind();
        //        ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));

        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}

        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddl_hospital.Items.Clear();


                ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void ddl_facility_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    //ddl_hospital.Items.Clear();
               
            
            //    //ddl_hospital.Items.Insert(0, new ListItem("Select", "0"));

            //    if (ddl_district.SelectedItem.Text != "Select" && ddl_facility.SelectedItem.Text != "Select")
            //    {

            //        DataTable dthospital = Landsettlementpattas.GetHealthMasters("hospital", ddl_district.SelectedItem.Text,ddl_facility.SelectedItem.Text);
            //        if (dthospital.Rows.Count > 0)
            //        {

            //            BindHospital(dthospital);


            //        }
            //        else
            //        {

            //            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
            //        }
            //    }


            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
            //    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            //}

        }

        protected void ddl_hospital_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
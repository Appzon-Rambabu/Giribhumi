using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using ROFR.helper;

namespace ROFR.pages
{
    public partial class Mandal_Master : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    BindDistrict();
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    Repeater1.Visible = false;
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                }

            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
        }
        private void BindDistrict()
        {
            try
            {

                DataTable dtDistricts = RevenueDistrictsBAL.RevenueDistricts.GetDistrictdetails((string)(Session["username"]), "District", "", "");
                if (dtDistricts.Rows.Count > 0)
                {
                    ddl_district.DataSource = dtDistricts;
                    ddl_district.DataTextField = "DISTRICT_NAME";
                    ddl_district.DataValueField = "DISTRICT_CODE";
                    ddl_district.DataBind();
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
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

        private void BindMandal(DataTable dtMandal)
        {
            try
            {

                ddl_mandal.DataSource = dtMandal;
                ddl_mandal.DataTextField = "MANDAL_NAME";
                ddl_mandal.DataValueField = "MANDAL_CODE";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btnsend_Click(object sender, EventArgs e)
        {
            try
            {

                BindData();

                Repeater1.Visible = true;
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

                string district = ddl_district.SelectedValue;
                string mandal = ddl_mandal.SelectedValue;
                Repeater1.Visible = true;
                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMandalMasterDetails(district, mandal);

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                    Repeater1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddldistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    Repeater1.Visible = false;
                    DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.GetDistrictdetails((string)(Session["username"]), "Mandal", ddl_district.SelectedValue, "");
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                    }
                }
                else
                {
                    Repeater1.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void ddlmandal_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Repeater1.Visible = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
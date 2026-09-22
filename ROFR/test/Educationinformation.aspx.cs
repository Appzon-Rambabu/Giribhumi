using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using ROFR.helper;

namespace ROFR.test
{
    public partial class Educationinformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindMandals();
                    ddl_mandalname.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_villagename.Items.Insert(0, new ListItem("Select", "0"));

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindMandals()
        {
            try
            {
                rofrObject rofrObjectobj = new rofrObject();
                DataTable dtMandals = Landsettlementpattas.GetGirimandalMasterAnalysis(rofrObjectobj);
                if (dtMandals.Rows.Count > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Data Found !')", true);
                    ddl_mandalname.DataSource = dtMandals;
                    ddl_mandalname.DataTextField = "Itda";
                    ddl_mandalname.DataValueField = "Itda";
                    ddl_mandalname.DataBind();
                    ddl_mandalname.Items.Insert(0, new ListItem("Select", "0"));
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
        private void BindVillage(DataTable dtVillages)
        {
            try
            {
                ddl_villagename.DataSource = dtVillages;
                ddl_villagename.DataTextField = "VillageName";
                ddl_villagename.DataValueField = "VillageName";
                ddl_villagename.DataBind();
                ddl_villagename.Items.Insert(0, new ListItem("Select", "0"));
                //ddl_village.Items.Insert(1, new ListItem("NULL", "1"));
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
                if (ddl_mandalname.SelectedItem.Text != "Select")
                {
                    DataTable dtVillages = Landsettlementpattas.GetvillageMasterAnalysis(ddl_mandalname.SelectedValue);
                    if (dtVillages.Rows.Count > 0)
                    {
                        Repeater1.DataSource = null;
                        //ddl_mandal.ClearSelection();
                        ddl_villagename.ClearSelection();
                        Repeater1.DataBind();
                        if (dtVillages.Rows.Count > 0)
                        {
                            BindVillage(dtVillages);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        }

                    }
                }
                else
                {
                    ddl_villagename.ClearSelection();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlvillage_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_mandalname.SelectedItem.Text != "Select")
                {
                    if (ddl_villagename.SelectedItem.Text != "Select")
                    {
                        Repeater1.DataSource = null;

                        Repeater1.DataBind();
                        DataTable dt = Landsettlementpattas.GetData(ddl_mandalname.SelectedItem.Text, ddl_villagename.SelectedItem.Text);
                        Repeater1.DataSource = dt;

                        Repeater1.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Village !')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Mandal !')", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Linkview_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)(sender);
                string Id = btn.CommandArgument;
                Session["ltId"] = Id;
                Session["CurrentPage"] = "ViewLandTransferRegulation.aspx";
                Response.Redirect("~//test//LandTransferRegulation.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
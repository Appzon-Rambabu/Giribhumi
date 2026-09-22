using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using ROFR.helper;

namespace ROFR.test
{
    public partial class HabitationUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    BindDistrict();
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_Village.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_Hab.Items.Insert(0, new ListItem("Select", "-1"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindDistrict()
        {
            try
            {

                DataTable dtDistricts = MastersDataAnalysisBAL.MastersDataAnalysis.GetDistrictdetails((string)(Session["username"]), "District", "", "");
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
                ddl_mandal.DataValueField ="LGD_MANDAL_CODE";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        private void BindVillage(DataTable dtVillage)
        {
            try
            {

                ddl_Village.DataSource = dtVillage;
                ddl_Village.DataTextField = "VILLAGE_NAME";
                ddl_Village.DataValueField = "LGD_VILLAGE_CODE";
                ddl_Village.DataBind();
                ddl_Village.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindHabitations(DataTable dt)
        {
            try
            {
                ddl_Hab.DataSource = dt;
                ddl_Hab.DataTextField = "HAB_NAME";
                ddl_Hab.DataValueField = "HAB_NAME";
                ddl_Hab.DataBind();
                ddl_Hab.Items.Insert(0, new ListItem("Select", "0"));
                ddl_Hab.Items.Insert(1, new ListItem("NEW", "1"));
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
                    ddl_mandal.ClearSelection();
                    ddl_Village.ClearSelection();
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    DataTable dtMandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetDistrictdetails((string)(Session["username"]), "Mandal", ddl_district.SelectedValue, "");
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                    }
                }
                else
                {

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
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_Village.ClearSelection();
                    DataTable dtmandal = MastersDataAnalysisBAL.MastersDataAnalysis.GetDistrictdetails((string)(Session["username"]), "Village", ddl_district.SelectedValue, ddl_mandal.SelectedValue);
                    GridView1.Visible = false;
                    GridView2.Visible = false;
                    if (dtmandal.Rows.Count > 0)
                    {
                        BindVillage(dtmandal);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                        GridView1.Visible = false;
                        GridView2.Visible = false;
                    }
                }
                else
                {

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
                if (ddl_Village.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    GridView1.Visible = false;
                    GridView2.Visible = false;

                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetHabitations(district, mandal, village);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView2.Visible = false;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Habitations')", true);
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        DataTable DTR = new DataTable();
                        DTR.Columns.Add("HAB_NAME");
                        DTR.Columns.Add("REV_VILLAGE_NAME");
                        DataRow dr = DTR.NewRow();
                        DTR.Rows.Add(dr);
                        GridView2.DataSource = DTR;
                        GridView2.DataBind();
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindHabitations()
        {
            try
            {
                if (ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_Village.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    GridView1.Visible = false;
                    GridView2.Visible = false;

                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetHabitations(district, mandal, village);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView2.Visible = false;
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Habitations')", true);
                        GridView1.Visible = false;
                        GridView2.Visible = true;
                        DataTable DTR = new DataTable();
                        DTR.Columns.Add("HAB_NAME");
                        DTR.Columns.Add("REV_VILLAGE_NAME");
                        DataRow dr = DTR.NewRow();
                        DTR.Rows.Add(dr);
                        GridView2.DataSource = DTR;
                        GridView2.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = -1;
                BindHabitations();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                string id = GridView1.DataKeys[e.RowIndex].Values["Id"].ToString();
                string district = ddl_district.SelectedValue;
                string mandal = ddl_mandal.SelectedValue;
                string village = ddl_Village.SelectedValue;

                ProjectRofrBAL.GetMasterDetails.HabitationDelete(id, district, mandal, village);
                BindHabitations();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Habitation Delete Successfully')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                BindHabitations();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string stor_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "HAB_NAME"));
                    Button lnkbtnresult = (Button)e.Row.FindControl("ButtonDelete");
                    if (lnkbtnresult != null)
                    {
                        lnkbtnresult.Attributes.Add("onclick", "javascript:return deleteConfirm('" + ID + "')");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

                if (e.CommandName.Equals("AddNew"))
                {
                    TextBox HAB = new TextBox();
                    //TextBox REVN = new TextBox();
                    if (GridView1.Visible != false)
                    {
                        HAB = (TextBox)GridView1.FooterRow.FindControl("instorid");
                        //REVN = (TextBox)GridView1.FooterRow.FindControl("inname");
                    }
                    if (HAB.Text.Trim() == "")
                    {
                        HAB = (TextBox)GridView2.FooterRow.FindControl("instorid");
                        //REVN = (TextBox)GridView2.FooterRow.FindControl("inname");
                    }
                    string code = HAB.Text.ToUpper();
                    //string name = REVN.Text.Trim().ToUpper();
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;

                    string village = ddl_Village.SelectedValue;



                    DataSet dt = ProjectRofrBAL.GetMasterDetails.UniqueHabitation("", district, mandal, village);
                    string n = string.Empty;
                    string c = string.Empty;
                    bool unique = false;
                    //bool revunique = false;
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        //for (int i = 0; i <= dt.Tables[0].Rows.Count - 1; i++)
                        //{
                        //    n = dt.Tables[0].Rows[i]["REV_VILLAGE_NAME"].ToString();
                        //    if (name == n.ToUpper().Trim())
                        //    {   
                        //        revunique = true;
                        //        break;
                        //    }

                        //}

                        for (int i = 0; i <= dt.Tables[0].Rows.Count - 1; i++)
                        {
                            c = dt.Tables[0].Rows[i]["HAB_NAME"].ToString();
                            if (code == c.ToUpper().Trim())
                            {
                                unique = true;
                                break;
                            }

                        }
                    }


                    if ((unique == false))
                    {
                        string IPAddress = (string)(Session["IPAddress"]);

                        if (!string.IsNullOrEmpty((string)(Session["username"])))
                        {
                            RevenueDistrictsBAL.RevenueDistricts.InsertForesthab(ddl_district.SelectedValue, mandal, village, ddl_Village.SelectedItem.Text, HAB.Text.Trim(), "", IPAddress, (string)(Session["username"]));
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Habitation Added Successfully')", true);
                            BindHabitations();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else if (unique == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Habitation and Revenue Village Name Must be Unique')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {


                string id = GridView1.DataKeys[e.RowIndex].Values["Id"].ToString();

                TextBox HAB = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_divisioncode");
                //TextBox REVN = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_division");
                string code = HAB.Text.ToUpper();
                //string name = REVN.Text.Trim().ToUpper();
                string district = ddl_district.SelectedValue;
                string mandal = ddl_mandal.SelectedValue;
                string village = ddl_Village.SelectedValue;

                DataSet dt = ProjectRofrBAL.GetMasterDetails.UniqueHabitation(id, district, mandal, village);

                string n = string.Empty;
                string c = string.Empty;
                bool unique = false;
                //bool revunique = false;
                if (dt.Tables[1].Rows.Count > 0)
                {
                    //for (int i = 0; i <= dt.Tables[1].Rows.Count - 1; i++)
                    //{
                    //    n = dt.Tables[1].Rows[i]["REV_VILLAGE_NAME"].ToString();

                    //    if (name == n.ToUpper().Trim())
                    //    {
                    //        revunique = true;
                    //        break;
                    //    }


                    //}

                    for (int i = 0; i <= dt.Tables[1].Rows.Count - 1; i++)
                    {
                        c = dt.Tables[1].Rows[i]["HAB_NAME"].ToString();
                        if (code == c.ToUpper().Trim())
                        {
                            unique = true;
                            break;
                        }

                    }
                }
                if (HAB.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter Values')", true);
                }
                else
                {

                    if ((unique == false))
                    {
                        string IPAddress = (string)(Session["IPAddress"]);



                        if (!string.IsNullOrEmpty((string)(Session["username"])))
                        {
                            RevenueDistrictsBAL.RevenueDistricts.UpdateForesthab(id, ddl_district.SelectedValue, mandal, village, HAB.Text.Trim(), "", IPAddress, (string)(Session["username"]));
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Habitation Update Successfully')", true);
                            BindHabitations();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else if (unique == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Habitation Must be Unique')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlhab_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string district = ddl_district.SelectedValue;
                string mandal = ddl_mandal.SelectedValue;
                string village = ddl_Village.SelectedValue;
                string habitation = ddl_Hab.SelectedValue;
                DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetHabitationsforest(district, mandal, village, habitation);
                if (dt.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView2.Visible = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.Visible = false;
                    GridView2.Visible = true;
                    DataTable DTR = new DataTable();
                    DTR.Columns.Add("Sno");
                    DTR.Columns.Add("HAB_NAME");
                    DataRow dr = DTR.NewRow();
                    DTR.Rows.Add(dr);
                    GridView2.DataSource = DTR;
                    GridView2.DataBind();
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
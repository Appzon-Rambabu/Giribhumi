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
    public partial class CurdForestBeat : System.Web.UI.Page
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
                    ddl_FD.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_FR.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
        }

        private void BindDistrict()
        {
            try
            {

                DataTable dtDistricts = RevenueDistrictsBAL.RevenueDistricts.GetCurdForestDivisionMasterAnalysis((string)(Session["username"]), "Division", "", "");
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
                ddl_mandal.DataValueField = "LGD_MANDAL_CODE";
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

        private void BindDivisions(DataTable dtdivisions)
        {
            try
            {
                ddl_FD.DataSource = dtdivisions;
                ddl_FD.DataTextField = "FOREST_DIVISION_NAME";
                ddl_FD.DataValueField = "FOREST_DIVISION_CODE";
                ddl_FD.DataBind();
                ddl_FD.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindRanges(DataTable dtdivisions)
        {
            try
            {
                ddl_FR.DataSource = dtdivisions;
                ddl_FR.DataTextField = "FOREST_RANGE_NAME";
                ddl_FR.DataValueField = "FOREST_RANGE_CODE";
                ddl_FR.DataBind();
                ddl_FR.Items.Insert(0, new ListItem("Select", "0"));
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
                    string district = ddl_district.SelectedValue;
                    ddl_mandal.ClearSelection();
                    ddl_Village.ClearSelection();
                    ddl_FD.ClearSelection();
                    ddl_FR.ClearSelection();
                    GridView1.Visible = false;
                    GridView2.Visible = false;

                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetRevenuemandalMasterDetails(district, "Beat");
                    if (dt.Rows.Count > 0)
                    {
                        BindMandal(dt);
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
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    ddl_Village.ClearSelection();
                    ddl_FD.ClearSelection();
                    ddl_FR.ClearSelection();
                    GridView1.Visible = false;
                    GridView2.Visible = false;

                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetVillageMasterDetails(district, mandal, "Beat");
                    if (dt.Rows.Count > 0)
                    {
                        BindVillage(dt);
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
                    ddl_FD.ClearSelection();
                    ddl_FR.ClearSelection();
                    GridView1.Visible = false;
                    GridView2.Visible = false;

                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetFillterDivisionsDetails(district, mandal, village, "Beat");
                    if (dt.Rows.Count > 0)
                    {
                        BindDivisions(dt);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Divisions')", true);
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

        protected void ddlFD_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_FD.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    string division = ddl_FD.SelectedValue;
                    ddl_FR.ClearSelection();
                    GridView1.Visible = false;
                    GridView2.Visible = false;

                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetFillterRangeDetails(district, mandal, village, division, "Beat");
                    if (dt.Rows.Count > 0)
                    {
                        BindRanges(dt);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Ranges')", true);
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

        protected void ddlFR_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_FR.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    string division = ddl_FD.SelectedValue;
                    string range = ddl_FR.SelectedValue;
                    GridView1.Visible = false;

                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetFillterBeatDetails(district, mandal, village, division, range, "Beat");
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView2.Visible = false;
                        GridView1.DataSource = dt;

                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Beats')", true);
                        GridView1.Visible = false;
                        DataTable DTR = new DataTable();
                        DTR.Columns.Add("FOREST_BEAT_CODE");
                        DTR.Columns.Add("FOREST_BEAT_NAME");
                        DataRow dr = DTR.NewRow();
                        DTR.Rows.Add(dr);
                        GridView2.Visible = true;
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

        private void BindBeats()
        {
            try
            {

                if (ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_Village.SelectedItem.Text != "Select" && ddl_FD.SelectedItem.Text != "Select" && ddl_FR.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    string division = ddl_FD.SelectedValue;
                    string range = ddl_FR.SelectedValue;


                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetFillterBeatDetails(district, mandal, village, division, range, "Beat");

                    if (dt.Rows.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView2.Visible = false;
                        GridView1.DataSource = dt;

                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                        GridView1.Visible = false;
                        DataTable DTR = new DataTable();
                        DTR.Columns.Add("FOREST_BEAT_CODE");
                        DTR.Columns.Add("FOREST_BEAT_NAME");
                        DataRow dr = DTR.NewRow();
                        DTR.Rows.Add(dr);
                        GridView2.Visible = true;
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
        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                BindBeats();
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

                TextBox FBC = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_divisioncode");
                TextBox FBN = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_division");
                string code = FBC.Text.ToUpper();
                string name = FBN.Text.Trim().ToUpper();
                string district = ddl_district.SelectedValue;
                string mandal = ddl_mandal.SelectedValue;
                string village = ddl_Village.SelectedValue;
                string division = ddl_FD.SelectedValue;
                string range = ddl_FR.SelectedValue;


                DataSet dt = ProjectRofrBAL.GetMasterDetails.GetupperdivisionsMasterDetails(district, id, "Beat", mandal, village, division, range);
                //dt = dt.AsEnumerable()
                //                      .Where(r => r.Field<int>("Id") != Convert.ToInt32(id))
                //                      .CopyToDataTable();
                string n = string.Empty;
                string c = string.Empty;
                bool unique = false;
                if (dt.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i <= dt.Tables[1].Rows.Count - 1; i++)
                    {
                        n = dt.Tables[1].Rows[i]["FOREST_BEAT_NAME"].ToString();
                        c = dt.Tables[1].Rows[i]["FOREST_BEAT_CODE"].ToString();
                        if (name == n.ToUpper().Trim())
                        {
                            unique = true;
                            break;
                        }
                        if (code == c.ToUpper().Trim())
                        {
                            unique = true;
                            break;
                        }

                    }
                }
                if (FBC.Text == "" || FBN.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Enter Values')", true);
                }
                else
                {

                    if (unique == false)
                    {
                        string IPAddress = (string)(Session["IPAddress"]);


                        if (!string.IsNullOrEmpty((string)(Session["username"])))
                        {
                            ProjectRofrBAL.GetMasterDetails.UpdateForestBeat(id, ddl_district.SelectedValue, mandal, village, division, range, FBC.Text.Trim(), FBN.Text.Trim(), IPAddress, (string)(Session["username"]));
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Beat Update Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else if (unique == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Beat Code and Forest Beat Name Must be Unique')", true);
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
                BindBeats();
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
                string division = ddl_FD.SelectedValue;
                string range = ddl_FR.SelectedValue;
                ProjectRofrBAL.GetMasterDetails.DeleteForestBeat(id, district, mandal, village, division, range);
                BindBeats();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Beat Delete Successfully')", true);
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
                    string stor_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FOREST_BEAT_CODE"));
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
                    TextBox FBC = new TextBox();
                    TextBox FBN = new TextBox();
                    if (GridView1.Visible != false)
                    {
                        FBC = (TextBox)GridView1.FooterRow.FindControl("instorid");
                        FBN = (TextBox)GridView1.FooterRow.FindControl("inname");
                    }
                    if (FBC.Text.Trim() == "" && FBN.Text.Trim() == "")
                    {
                        FBC = (TextBox)GridView2.FooterRow.FindControl("instorid");
                        FBN = (TextBox)GridView2.FooterRow.FindControl("inname");
                    }
                    string code = FBC.Text.ToUpper();
                    string name = FBN.Text.Trim().ToUpper();
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string village = ddl_Village.SelectedValue;
                    string division = ddl_FD.SelectedValue;
                    string range = ddl_FR.SelectedValue;


                    DataSet dt = ProjectRofrBAL.GetMasterDetails.GetupperdivisionsMasterDetails(district, "", "Beat", mandal, village, division, range);
                    string n = string.Empty;
                    string c = string.Empty;
                    bool unique = false;
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Tables[0].Rows.Count - 1; i++)
                        {
                            n = dt.Tables[0].Rows[i]["FOREST_BEAT_NAME"].ToString();
                            c = dt.Tables[0].Rows[i]["FOREST_BEAT_CODE"].ToString();
                            if (name == n.ToUpper().Trim())
                            {
                                unique = true;
                                break;
                            }
                            if (code == c.ToUpper().Trim())
                            {
                                unique = true;
                                break;
                            }

                        }
                    }


                    if (unique == false)
                    {
                        string hostName = Dns.GetHostName();
                        string IPAddress = (string)(Session["IPAddress"]);

                        if (!string.IsNullOrEmpty((string)(Session["username"])))
                        {
                            ProjectRofrBAL.GetMasterDetails.InsertForestBeat(ddl_district.SelectedValue, mandal, village, division, range, FBC.Text.Trim(), FBN.Text.Trim(), IPAddress, (string)(Session["username"]));
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Beat Added Successfully')", true);
                            BindBeats();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else if (unique == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Beat Code and Forest Beat Name Must be Unique')", true);
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
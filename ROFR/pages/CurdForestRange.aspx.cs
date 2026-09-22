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

namespace ROFR.pages
{
    public partial class CurdForestRange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    BindDistrict();
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_FD.Items.Insert(0, new ListItem("Select", "0"));

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
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_FD.Items.Insert(0, new ListItem("Select", "0"));
        }
        private void BindDistrict()
        {
            try
            {
                string sessionstring = (string)(Session["username"]);
                if ((string)(Session["username"]) == "master_admin")
                {
                    sessionstring = "admin";
                }
                else
                {
                    sessionstring = (string)(Session["username"]);
                }

                DataTable dtDistricts = RevenueDistrictsBAL.RevenueDistricts.GetCurdForestDivisionMasterAnalysis(sessionstring, "Division", "", "");
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
                    GridView1.Visible = false;
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

        protected void ddldistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    ddl_mandal.ClearSelection();
                    ddl_FD.ClearSelection();
                    GridView1.Visible = false;
                    GridView2.Visible = false;

                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetRevenuemandalMasterDetails(district, "Range");
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
                System.Threading.Thread.Sleep(5000);
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    ddl_FD.ClearSelection();
                    GridView1.Visible = false;
                    GridView2.Visible = false;

                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetFillterDivisionsDetails(district, mandal, "", "Range");
                    if (dt.Rows.Count > 0)
                    {
                        BindDivisions(dt);
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


        protected void ddlFD_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                if (ddl_FD.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string division = ddl_FD.SelectedValue;
                    GridView1.Visible = false;


                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetFillterRangeDetails(district, mandal, "", division, "Range");
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView2.Visible = false;
                        GridView1.DataSource = dt;

                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Ranges')", true);
                        GridView1.Visible = false;
                        DataTable DTR = new DataTable();
                        DTR.Columns.Add("FOREST_RANGE_CODE");
                        DTR.Columns.Add("FOREST_RANGE_NAME");
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



        private void BindRanges()
        {
            try
            {

                if (ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select" && ddl_FD.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;
                    string division = ddl_FD.SelectedValue;



                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetFillterRangeDetails(district, mandal, "", division, "Range");

                    if (dt.Rows.Count > 0)
                    {
                        GridView1.Visible = true;
                        GridView1.DataSource = dt;
                        GridView2.Visible = false;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                        GridView1.Visible = false;
                        DataTable DTR = new DataTable();
                        DTR.Columns.Add("FOREST_RANGE_CODE");
                        DTR.Columns.Add("FOREST_RANGE_NAME");
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
                System.Threading.Thread.Sleep(5000);
                GridView1.EditIndex = e.NewEditIndex;
                BindRanges();
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

                System.Threading.Thread.Sleep(5000);
                string id = GridView1.DataKeys[e.RowIndex].Values["Id"].ToString();

                TextBox FRC = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_divisioncode");
                TextBox FRN = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_division");
                string code = FRC.Text.ToUpper();
                string name = FRN.Text.Trim().ToUpper();
                string district = ddl_district.SelectedValue;
                string mandal = ddl_mandal.SelectedValue;
                string division = ddl_FD.SelectedValue;


                DataSet dt = ProjectRofrBAL.GetMasterDetails.GetupperdivisionsMasterDetails(district, id, "Range", mandal, "", division, "");
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
                        n = dt.Tables[1].Rows[i]["FOREST_RANGE_NAME"].ToString();
                        c = dt.Tables[1].Rows[i]["FOREST_RANGE_CODE"].ToString();
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
                if (FRC.Text == "" || FRN.Text == "")
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
                            ProjectRofrBAL.GetMasterDetails.UpdateForestRange(id, ddl_district.SelectedValue, mandal, division, FRC.Text.Trim(), FRN.Text.Trim(), IPAddress, (string)(Session["username"]));
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Range Update Successfully')", true);
                            BindRanges();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else if (unique == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Range Code and Forest Range Name Must be Unique')", true);
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
                System.Threading.Thread.Sleep(5000);
                GridView1.EditIndex = -1;
                BindRanges();
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
                System.Threading.Thread.Sleep(5000);
                string id = GridView1.DataKeys[e.RowIndex].Values["Id"].ToString();
                string district = ddl_district.SelectedValue;
                string mandal = ddl_mandal.SelectedValue;

                string division = ddl_FD.SelectedValue;

                ProjectRofrBAL.GetMasterDetails.DeleteForestRange(id, district, mandal, division);
                BindRanges();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Range Delete Successfully')", true);
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
                System.Threading.Thread.Sleep(5000);
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string stor_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FOREST_RANGE_CODE"));
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
                System.Threading.Thread.Sleep(5000);
                if (e.CommandName.Equals("AddNew"))
                {
                    TextBox FRC = new TextBox();
                    TextBox FRN = new TextBox();
                    if (GridView1.Visible != false)
                    {
                        FRC = (TextBox)GridView1.FooterRow.FindControl("instorid");
                        FRN = (TextBox)GridView1.FooterRow.FindControl("inname");
                    }
                    if (FRC.Text.Trim() == "" && FRN.Text.Trim() == "")
                    {
                        FRC = (TextBox)GridView2.FooterRow.FindControl("instorid");
                        FRN = (TextBox)GridView2.FooterRow.FindControl("inname");
                    }
                    string code = FRC.Text.ToUpper();
                    string name = FRN.Text.Trim().ToUpper();
                    string district = ddl_district.SelectedValue;
                    string mandal = ddl_mandal.SelectedValue;

                    string division = ddl_FD.SelectedValue;



                    DataSet dt = ProjectRofrBAL.GetMasterDetails.GetupperdivisionsMasterDetails(district, "", "Range", mandal, "", division, "");
                    string n = string.Empty;
                    string c = string.Empty;
                    bool unique = false;
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Tables[0].Rows.Count - 1; i++)
                        {
                            n = dt.Tables[0].Rows[i]["FOREST_RANGE_NAME"].ToString();
                            c = dt.Tables[0].Rows[i]["FOREST_RANGE_CODE"].ToString();
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
                        string IPAddress = (string)(Session["IPAddress"]);

                        if (!string.IsNullOrEmpty((string)(Session["username"])))
                        {
                            string sessionstring = (string)(Session["username"]);
                            if ((string)(Session["username"]) == "master_admin")
                            {
                                sessionstring = "admin";
                            }
                            else
                            {
                                sessionstring = (string)(Session["username"]);
                            }
                            ProjectRofrBAL.GetMasterDetails.InsertForestRange(ddl_district.SelectedValue, mandal, division, FRC.Text.Trim(), FRN.Text.Trim(), IPAddress, sessionstring);
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Range Added Successfully')", true);
                            BindRanges();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else if (unique == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Range Code and Forest Range Name Must be Unique')", true);
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
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
using System.Net;
namespace ROFR.test
{
    public partial class CurdForestDivision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    BindDistrict();
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


        private void BindDivisions()
        {
            try
            {

                if (ddl_district.SelectedItem.Text != "Select")
                {
                    string district = ddl_district.SelectedValue;


                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestMasterDetails(district);

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
                        DTR.Columns.Add("FOREST_DIVISION_CODE");
                        DTR.Columns.Add("FOREST_DIVISION_NAME");
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

        protected void ddldistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddl_district.SelectedItem.Text != "Select")
                {
                    GridView1.DataSource = null;
                    string district = ddl_district.SelectedValue;


                    DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestMasterDetails(district);

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
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
                        DataTable DTR = new DataTable();
                        DTR.Columns.Add("FOREST_DIVISION_CODE");
                        DTR.Columns.Add("FOREST_DIVISION_NAME");
                        DataRow dr = DTR.NewRow();
                        DTR.Rows.Add(dr);
                        GridView2.Visible = true;
                        GridView2.DataSource = DTR;
                        GridView2.DataBind();
                    }
                }
                else
                {
                    GridView1.Visible = false;
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
                BindDivisions();
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

                TextBox FDC = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_divisioncode");
                TextBox FDN = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_division");
                string code = FDC.Text.ToUpper();
                string name = FDN.Text.Trim().ToUpper();
                string district = ddl_district.SelectedValue;


                DataSet dt = ProjectRofrBAL.GetMasterDetails.GetupperdivisionsMasterDetails(district, id, "Division", "", "", "", "");
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
                        n = dt.Tables[1].Rows[i]["FOREST_DIVISION_NAME"].ToString();
                        c = dt.Tables[1].Rows[i]["FOREST_DIVISION_CODE"].ToString();
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
                if (FDC.Text == "" || FDN.Text == "")
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
                            ProjectRofrBAL.GetMasterDetails.UpdateForestDivision(id, ddl_district.SelectedValue, FDC.Text.Trim(), FDN.Text.Trim(), IPAddress, (string)(Session["username"]));
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Division Update Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else if (unique == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Division Code and Forest Division Name Must be Unique')", true);
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
                BindDivisions();
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
                ProjectRofrBAL.GetMasterDetails.DeleteForestDivision(id, ddl_district.SelectedValue);
                BindDivisions();
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Division Delete Successfully')", true);
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
                    string stor_id = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "FOREST_DIVISION_CODE"));
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
                    TextBox FDC = new TextBox();
                    TextBox FDN = new TextBox();
                    if (GridView1.Visible != false)
                    {
                        FDC = (TextBox)GridView1.FooterRow.FindControl("instorid");
                        FDN = (TextBox)GridView1.FooterRow.FindControl("inname");
                    }
                    if (FDC.Text.Trim() == "" && FDN.Text.Trim() == "")
                    {
                        FDC = (TextBox)GridView2.FooterRow.FindControl("instorid");
                        FDN = (TextBox)GridView2.FooterRow.FindControl("inname");
                    }
                    string code = FDC.Text.ToUpper();
                    string name = FDN.Text.Trim().ToUpper();
                    string district = ddl_district.SelectedValue;


                    DataSet dt = ProjectRofrBAL.GetMasterDetails.GetupperdivisionsMasterDetails(district, "", "Division", "", "", "", "");
                    string n = string.Empty;
                    string c = string.Empty;
                    bool unique = false;
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= dt.Tables[0].Rows.Count - 1; i++)
                        {
                            n = dt.Tables[0].Rows[i]["FOREST_DIVISION_NAME"].ToString();
                            c = dt.Tables[0].Rows[i]["FOREST_DIVISION_CODE"].ToString();
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
                            ProjectRofrBAL.GetMasterDetails.InsertForestDivision(ddl_district.SelectedValue, FDC.Text.Trim(), FDN.Text.Trim(), IPAddress, (string)(Session["username"]));
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Division Added Successfully')", true);
                            BindDivisions();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                        }
                    }
                    else if (unique == true)
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Forest Division Code and Forest Division Name Must be Unique')", true);
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
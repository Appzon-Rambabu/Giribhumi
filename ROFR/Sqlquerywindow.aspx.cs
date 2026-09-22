using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;

namespace ROFR
{
    public partial class Sqlquerywindow : System.Web.UI.Page
    {
        string validation = "false";
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            validation = "false";
            lblreason.Visible = false;
        }

        protected void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                if (validation == "false")
                {
                    string data = Request["txtquery"];
                    if (data.ToUpper().Contains("TRUNCATE") != true && data.ToUpper().Contains("DROP") != true && data.ToUpper().Contains("INSERT") != true && data.ToUpper().Contains("UPDATE") != true && data.ToUpper().Contains("DELETE") != true)
                    {
                        string sqlQuery = data.Trim();
                        DataTable dtResultQuery = ProjectRofrBAL.GetMasterDetails.ExceuteQuery(sqlQuery);
                        lblreason.Visible = false;
                        if (dtResultQuery.Rows.Count > 0)
                        {
                            dt = dtResultQuery;
                            dgvresult.DataSource = null;
                            dgvresult.DataBind();
                            dgvresult.DataSource = dtResultQuery;
                            dgvresult.DataBind();
                        }
                        else
                        {
                            dgvresult.DataSource = null;
                            dgvresult.DataBind();

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Restricted keywords found. Query will not be executed !')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                dgvresult.DataSource = null;
                dgvresult.DataBind();
                string errortext = ex.Message;
                lblreason.Visible = true;
                lblreason.Text = errortext;

                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void ValidateForm()
        {
            try
            {
                string data = Request["txtquery"];
                if (data.Trim().Length == 0)
                {
                    validation = "true";
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please write the sql query !')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string data = Request["txtquery"];
                DataTable dt = ProjectRofrBAL.GetMasterDetails.ExceuteQuery(data);
                if (dt.Rows.Count > 0)
                {
                    string filenamef = "DatefromQuerywindow";


                    string filename = filenamef + ".xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();

                    //Get the HTML for the control.
                    dgGrid.RenderControl(hw);
                    //Write the HTML back to the browser.
                    //Response.ContentType = application/vnd.ms-excel;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
                    this.EnableViewState = false;
                    Response.Write(tw.ToString());
                    Response.End();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found !')", true);
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
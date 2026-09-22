using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;

namespace ROFR.pages
{
    public partial class PSS_DETAILS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                  //  BindItda();
                    //  BindData();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        //private void BindItda()
        //{
        //    try

        //    {


        //        DataTable dtItda = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);

        //        if (dtItda.Rows.Count > 0)
        //        {
        //            ddl_Itda.DataSource = dtItda;
        //            ddl_Itda.DataTextField = "ITDA_NAME";
        //            ddl_Itda.DataValueField = "ITDA_CODE";
        //            ddl_Itda.DataBind();
        //            ddl_Itda.Items.Insert(0, new ListItem("Select", "0"));
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
        //protected void ddl_Itda_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    try
        //    {


        //        if (ddl_Itda.SelectedItem.Text != "Select")
        //        {
        //            BindData(ddl_Itda.SelectedItem.Text);
        //        }
        //        else
        //        {


        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }

        //}
        protected void BindData()
        {
            try
            {
                DataTable dt = new DataTable();

                DataTable adt = ProjectRofrBAL.GetMasterDetails.GetAdharDetails(null, (string)(Session["userprevilages"]), (string)(Session["username"]));
                if (adt.Rows.Count > 0)
                {
                    for (int i = 0; i < adt.Rows.Count; i++)
                    {

                         dt = Landsettlementpattas.GetPssData(adt.Rows[i]["Aadhaar_NO"].ToString(), "");
                    }
                    Session["Data"] = dt;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                BindData();
                DataTable dt = (DataTable)(Session["Data"]);



                if (dt.Rows.Count > 0)
                {
                    string filename = "Adhar_Details.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();

                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();





                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;

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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
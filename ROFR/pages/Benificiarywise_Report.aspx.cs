using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.IO;
using System.Drawing;

namespace ROFR.pages
{
    public partial class Benificiarywise_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               

                if (!IsPostBack)
                {
                    ddl_Itda.Items.FindByValue("3").Selected = true;
                    div_mandal.Visible = false;
                DataTable dt = new DataTable();
                    if (ddl_Itda.SelectedValue == "1")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Benificiary", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                        BindData(dt);
                        
                    }

                    if (ddl_Itda.SelectedValue == "2")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASE1", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                        BindData(dt);
                    }
                    if (ddl_Itda.SelectedValue == "3")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASE2", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                        BindData(dt);
                    }
                    if (ddl_Itda.SelectedValue == "4")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASESBOTH", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                        BindPhase(dt);
                    }
                  
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void BindData(DataTable dt)
        {
            try
            {

                if (dt.Rows.Count > 0)
                {
                    div_mandal.Visible = false;
                    div_village.Visible = false;
                    div_rejected.Visible = false;
                    div_dist.Visible = true;
                    Grid1.Visible = true;
                    Grid2.Visible = false;
                    GridV3.Visible = false;
                    Repeater1.Visible = false;
                    btn_notupload.Visible = false;
                    btn_back_dist.Visible = false;
                    Grid1.DataSource = dt;

                    Grid1.DataBind();
                    int totalFARMERS = dt.Select().Sum(p => Convert.ToInt32(p["NO_OF_FARMERS"]));
                   (Grid1.Controls[Grid1.Controls.Count - 1].Controls[0].FindControl("lblNOOFFARMERS") as Label).Text = totalFARMERS.ToString();
                    int totalPLOTS = dt.Select().Sum(p => Convert.ToInt32(p["NO_OF_PLOTS"]));
                    (Grid1.Controls[Grid1.Controls.Count - 1].Controls[0].FindControl("lblNOOFPLOTS") as Label).Text = totalPLOTS.ToString();
                    decimal totalEXTENT = dt.Select().Sum(p => Convert.ToDecimal(p["TOTAL_EXTENT"])); 
                    (Grid1.Controls[Grid1.Controls.Count - 1].Controls[0].FindControl("lblTOTALEXTENT") as Label).Text = totalEXTENT.ToString();
                    Session["districtexcel"] = "Benficiary";
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
        protected void BindPhase(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    div_village.Visible = false;
                    div_rejected.Visible = false;
                    div_mandal.Visible = true;
                    Grid1.Visible = false;
                    Grid2.Visible = true;
                    GridV3.Visible = false;
                    Repeater1.Visible = false;
                    btn_notupload.Visible = false;
                    btn_back_dist.Visible = false;
                    Grid2.DataSource = dt;

                    Grid2.DataBind();
                    int totalfarmers = dt.Select().Sum(p => Convert.ToInt32(p["PHASE_I_BEN_IN_PHASE_II"]));
                    (Grid2.Controls[Grid2.Controls.Count - 1].Controls[0].FindControl("lblPHASEIBENINPHASEII") as Label).Text = totalfarmers.ToString();
                    decimal totalplots = dt.Select().Sum(p => Convert.ToDecimal(p["PHASE_I_EXTENT"]));
                    (Grid2.Controls[Grid2.Controls.Count - 1].Controls[0].FindControl("lblPHASEIEXTENT") as Label).Text = totalplots.ToString();
                    decimal totalextent = dt.Select().Sum(p => Convert.ToDecimal(p["PHASE_II_EXTENT"]));
                    (Grid2.Controls[Grid2.Controls.Count - 1].Controls[0].FindControl("lblPHASEIIEXTENT") as Label).Text = totalextent.ToString();

                    Session["districtexcel"] = "Phase";


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
        protected void ddl_Itda_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                
                DataTable dt = new DataTable();
                if (ddl_Itda.SelectedValue == "1")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Benificiary", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    BindData(dt);
                    
                }

                if (ddl_Itda.SelectedValue == "2")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASE1", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    BindData(dt);
                }
                if (ddl_Itda.SelectedValue == "3")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASE2", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    BindData(dt);
                }
                if (ddl_Itda.SelectedValue == "4")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASESBOTH", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    BindPhase(dt);
                }
               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
               
                DataTable dt = new DataTable();
                if (ddl_Itda.SelectedValue == "1")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Benificiary", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    BindData(dt);
                }

                if (ddl_Itda.SelectedValue == "2")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASE1", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    BindData(dt);
                }
                if (ddl_Itda.SelectedValue == "3")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASE2", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    BindData(dt);
                }
                if (ddl_Itda.SelectedValue == "4")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("PHASESBOTH", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    BindPhase(dt);
                }

                if ((string)Session["districtexcel"] == "Benficiary")
                {
                    if (dt.Rows.Count > 0)
                    {


                        string Filename = "Benificiarywise Land Reports.xls";
                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                        DataGrid dgGrid = new DataGrid();
                        dgGrid.DataSource = dt;
                        dgGrid.DataBind();
                        dgGrid.RenderControl(hw);
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                        this.EnableViewState = false;
                        Response.Write(tw.ToString());
                        Response.End();
                        

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found!')", true);
                    }
                }
                if ((string)Session["districtexcel"] == "Phase")
                {
                    
                    if (dt.Rows.Count > 0)
                    {


                        string Filename = "Benificiarywise Land Reports.xls";
                        System.IO.StringWriter tw = new System.IO.StringWriter();
                        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                        DataGrid dgGrid = new DataGrid();
                        dgGrid.DataSource = dt;
                        dgGrid.DataBind();
                        dgGrid.RenderControl(hw);
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                        this.EnableViewState = false;
                        Response.Write(tw.ToString());
                        Response.End();
                        

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
        protected void OnDataBound(object sender, EventArgs e)
        {
            
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();

            if (ddl_Itda.SelectedValue == "1")
            { 
            cell = new TableHeaderCell();

            cell.Text = "Total Beneficiaries & Total Extent";
            cell.ColumnSpan = 4;
            cell.Attributes.Add("style", "text-align:center !important;");

            row.Controls.Add(cell);


            row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            }
            if (ddl_Itda.SelectedValue == "2")
            {
                cell = new TableHeaderCell();

                cell.Text = "Phase-I Beneficiaries & Extent";
                cell.ColumnSpan = 4;
                cell.Attributes.Add("style", "text-align:center !important;");

                row.Controls.Add(cell);


                row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            }
            if (ddl_Itda.SelectedValue == "3")
            {
                cell = new TableHeaderCell();

                cell.Text = "Phase-II Beneficiaries & Extent";
                cell.ColumnSpan = 4;
                cell.Attributes.Add("style", "text-align:center !important;");

                row.Controls.Add(cell);


                row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            }
            
        }
        protected void OnDataBoundMandal(object sender, EventArgs e)
        {
            
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();


            if (ddl_Itda.SelectedValue == "4")
            {
                cell = new TableHeaderCell();

                cell.Text = "Phase-I Beneficiaries in Phase-II";
                cell.ColumnSpan = 5;
                cell.Attributes.Add("style", "text-align:center !important;");

                row.Controls.Add(cell);


                row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            }
          
        }
        protected void grid1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            
            if (e.Item.ItemType == ListItemType.Header)
            {
                
                Label lbl_mdlp = e.Item.FindControl("lbl_dlp") as Label;
                
                if (ddl_Itda.SelectedValue == "1")
                {
                    lbl_mdlp.Text = "Total Beneficiaries & Total Extent";
                }
                if (ddl_Itda.SelectedValue == "2")
                {
                    lbl_mdlp.Text = "Phase-I Beneficiaries & Extent";
                }
                if (ddl_Itda.SelectedValue == "3")
                {
                    lbl_mdlp.Text = "Phase-II Beneficiaries & Extent";
                }
               
            }
        }

        protected void grid2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Header)
            {
               
                Label lbl_mdlp = e.Item.FindControl("lbl_dlpp") as Label;
               
                
                if (ddl_Itda.SelectedValue == "4")
                {
                    lbl_mdlp.Text = "Phase - I Beneficiaries in Phase - II";
                }
            }
        }
        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itda = e.Item.FindControl("lbl_itda") as Label;
                Label lbl_mdlp = e.Item.FindControl("lbl_mdlp") as Label;
                lbl_itda.Text = "ITDA: " + (string)Session["Itda"];
                if (ddl_Itda.SelectedValue == "1")
                {
                    lbl_mdlp.Text = "Total Beneficiaries & Total Extent";
                }
                if (ddl_Itda.SelectedValue == "2")
                {
                    lbl_mdlp.Text = "Phase-I Beneficiaries & Extent";
                }
                if (ddl_Itda.SelectedValue == "3")
                {
                    lbl_mdlp.Text = "Phase-II Beneficiaries & Extent";
                }
                
            }
        }
        protected void rpt1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lbl_itda = e.Item.FindControl("lbl_itdaa") as Label;
                Label lbl_mdlp = e.Item.FindControl("lbl_mdlpp") as Label;
                lbl_itda.Text = "ITDA: " + (string)Session["Itda"];
               
                if (ddl_Itda.SelectedValue == "4")
                {
                    lbl_mdlp.Text = "Phase - I Beneficiaries in Phase - II";
                }
            }
        }
        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {
                
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                DataTable dt = new DataTable();
                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);
                Session["Itda"] = start.Trim();
                Session["District"] = dist.Trim();
                Session["end"] = end.Trim();
                if((string)Session["end"]== "BEN")
                {
                    if (ddl_Itda.SelectedValue == "1")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandalben", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    }

                    if (ddl_Itda.SelectedValue == "2")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandalphase1", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    }
                    if (ddl_Itda.SelectedValue == "3")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandalphase2", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    }
                   

                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = false;
                        div_village.Visible = true;
                        div_rejected.Visible = false;
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        Grid1.Visible = false;
                        Grid2.Visible = false;
                        Repeater1.Visible = false;
                        GridV3.Visible = true;
                        GridV3.DataSource = dt;

                        GridV3.DataBind();
                        int totalfarmers = dt.Select().Sum(p => Convert.ToInt32(p["NO_OF_FARMERS"]));
                        (GridV3.Controls[GridV3.Controls.Count - 1].Controls[0].FindControl("lblNOOFFARMERS_M") as Label).Text = totalfarmers.ToString();
                        int totalplots = dt.Select().Sum(p => Convert.ToInt32(p["NO_OF_PLOTS"]));
                        (GridV3.Controls[GridV3.Controls.Count - 1].Controls[0].FindControl("lblNOOFPLOTS_M") as Label).Text = totalplots.ToString();
                        decimal totalextent = dt.Select().Sum(p => Convert.ToDecimal(p["TOTAL_EXTENT"]));
                        (GridV3.Controls[GridV3.Controls.Count - 1].Controls[0].FindControl("lblTOTALEXTENT_M") as Label).Text = totalextent.ToString();


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                if ((string)Session["end"] == "PBOTH")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandalbothphase", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);

                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = false;
                        div_village.Visible = false;
                        div_rejected.Visible = true;
                      btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                      btn_notupload.Visible = true;
                        Grid1.Visible = false;
                        Grid2.Visible = false;
                        GridV3.Visible = false;
                        Repeater1.Visible = true;
                        Repeater1.DataSource = dt;

                        Repeater1.DataBind();

                        int totalfarmers = dt.Select().Sum(p => Convert.ToInt32(p["PHASE_I_BEN_IN_PHASE_II"]));
                        (Repeater1.Controls[Repeater1.Controls.Count - 1].Controls[0].FindControl("PHASEIBENINPHASEII_M") as Label).Text = totalfarmers.ToString();
                        decimal totalplots = dt.Select().Sum(p => Convert.ToDecimal(p["PHASE_I_EXTENT"]));
                        (Repeater1.Controls[Repeater1.Controls.Count - 1].Controls[0].FindControl("PHASEIEXTENT_M") as Label).Text = totalplots.ToString();
                        decimal totalextent = dt.Select().Sum(p => Convert.ToDecimal(p["PHASE_II_EXTENT"]));
                        (Repeater1.Controls[Repeater1.Controls.Count - 1].Controls[0].FindControl("PHASEIIEXTENT_M") as Label).Text = totalextent.ToString();

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

        protected void Get_back_dist(object sender, EventArgs e)
        {
            if (ddl_Itda.SelectedValue == "1" || ddl_Itda.SelectedValue == "2" || ddl_Itda.SelectedValue == "3")
            {
                div_dist.Visible = true;
                div_mandal.Visible = false;
                div_village.Visible = false;
                div_rejected.Visible = false;
                btn_back_dist.Visible = false;

                btn_upload.Visible = true;
                btn_notupload.Visible = false;

                Grid1.Visible = true;
            }
           
         
            if (ddl_Itda.SelectedValue == "4" )
            {
                div_dist.Visible = false;
                div_mandal.Visible = true;
                btn_back_dist.Visible = false;
                div_village.Visible = false;
                div_rejected.Visible = false;
                btn_upload.Visible = true;
                btn_notupload.Visible = false;
                Grid2.Visible = true;
            }
        }

        protected void btn_notupload_Click(object sender, EventArgs e)
        {

            try
            {
                
                DataTable dt = new DataTable();
                if ((string)Session["end"] == "BEN")
                {
                    if (ddl_Itda.SelectedValue == "1")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandalben", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    }

                    if (ddl_Itda.SelectedValue == "2")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandalphase1", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    }
                    if (ddl_Itda.SelectedValue == "3")
                    {
                        dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandalphase2", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    }


                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = false;
                        div_village.Visible = true;
                        div_rejected.Visible = false;
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        Grid1.Visible = false;
                        Grid2.Visible = false;
                        Repeater1.Visible = false;
                        GridV3.Visible = true;
                        GridV3.DataSource = dt;

                        GridV3.DataBind();



                        string Filename = "Mandalwise Benificiarywise Land Reports.xls";
                        Response.ClearContent();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ClearHeaders();
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                        StringWriter str = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(str);
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                       
                        GridV3.RenderControl(htw);
                        Response.Write(str.ToString());
                        Response.Flush();
                        Response.Close();
                        Response.End();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                if ((string)Session["end"] == "PBOTH")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Status_Report("Mandalbothphase", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);

                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = false;
                        div_village.Visible = false;
                        div_rejected.Visible = true;
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        Grid1.Visible = false;
                        Grid2.Visible = false;
                        GridV3.Visible = false;
                        Repeater1.Visible = true;
                        Repeater1.DataSource = dt;

                        Repeater1.DataBind();


                        string Filename = "Mandalwise Benificiarywise Land Reports.xls";
                        Response.ClearContent();
                        Response.Clear();
                        Response.Buffer = true;
                        Response.ClearHeaders();
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", "attachment;Filename=" + Filename);
                        StringWriter str = new StringWriter();
                        HtmlTextWriter htw = new HtmlTextWriter(str);
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        
                        Repeater1.RenderControl(htw);
                        Response.Write(str.ToString());
                        Response.Flush();
                        Response.Close();
                        Response.End();

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
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
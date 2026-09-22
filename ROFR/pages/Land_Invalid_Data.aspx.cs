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
    public partial class Land_Invalid_Data : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btn_upload);
                scriptManager.RegisterPostBackControl(this.btn_notupload);

                if (!IsPostBack)
                {

                    BindData();

                    div_mandal.Visible = false;
                }
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

                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Invalid_Report("District", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);


                if (dt.Rows.Count > 0)
                {

                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno"] = i + 1;
                    }
                    btn_notupload.Visible = false;
                    GridView1.DataSource = dt;

                    GridView1.DataBind();
                    Session["districtexcel"] = dt;
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= 7; j++)
                        {
                            string value = dt.Rows[i][j].ToString();
                            if (i != dt.Rows.Count - 1)
                            {
                                if ((j == 2 && value == "0") || (j == 3 && value == "0") || (j == 4 && value == "0") || (j == 5 && value == "0") || (j == 6 && value == "0") || (j == 7 && value == "0"))
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;

                                }
                            }
                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 1)
                                {
                                 
                                    string IL = "lbl";
                                    IL = IL + j;
                                  
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 2||j==3|| j == 4|| j == 5|| j == 6 || j == 7)
                                {

                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 3)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 4)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 5)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                            }

                        }
                    }


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




        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');
                DataTable dt = new DataTable();
                string start = s.Substring(0, range);
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);
                Session["Itda"] = start.Trim();
                Session["District"] = dist.Trim();
                Session["end"] = end.Trim();
                if(end== "Duplicate")
                {

                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Invalid_Report("Duplicate", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    Session["filename"] = "Duplicate Aadhaars";
                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = true;
                        div_lbl.Visible = true;
                        itda.Visible = true;
                        district.Visible = true;
                      
                        lbl_itda.Text = (string)(Session["Itda"]);
                        lbl_dist.Text = (string)(Session["District"]);
                        status.Visible = true;
                        lbl_status.Text = "Duplicate Aadhaars";
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView2.Visible = true;
                        GridView5.Visible = false;
                        GridView2.DataSource = dt;

                        GridView2.DataBind();
                        Session["Duplicate"] = dt;



                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
              if (end == "Invalid")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Invalid_Report("Invalid", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    Session["filename"] = "Invalid Aadhaars";
                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = true;
                        div_lbl.Visible = true;
                        itda.Visible = true;
                        district.Visible = true;
                        lbl_itda.Text = (string)(Session["Itda"]);
                        lbl_dist.Text = (string)(Session["District"]);
                        status.Visible = true;
                        lbl_status.Text = "Invalid Aadhaars";
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView2.Visible = true;
                        GridView2.DataSource = dt;

                        GridView2.DataBind();
                        Session["Invalid"] = dt;



                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
             if(end == "Father")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Invalid_Report("Father", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    Session["filename"] = "Father Name Null";
                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = true;
                        div_lbl.Visible = true;
                        itda.Visible = true;
                        district.Visible = true;
                        lbl_itda.Text = (string)(Session["Itda"]);
                        lbl_dist.Text = (string)(Session["District"]);
                        status.Visible = true;
                        lbl_status.Text = "Father Name Null";
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView2.Visible = true;
                        GridView5.Visible = false;
                        GridView2.DataSource = dt;

                        GridView2.DataBind();
                        Session["Father"] = dt;



                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                if (end == "Location")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Invalid_Report("Location", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    Session["filename"] = "Location Details Null (Mandal/Gp/Village)";
                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = true;
                        div_lbl.Visible = true;
                        itda.Visible = true;
                        district.Visible = true;
                        lbl_itda.Text = (string)(Session["Itda"]);
                        lbl_dist.Text = (string)(Session["District"]);
                        status.Visible = true;
                        lbl_status.Text = "Location Details Null (Mandal/Gp/Village)";
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        GridView2.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = false;
                        GridView3.Visible = true;
                        GridView3.DataSource = dt;

                        GridView3.DataBind();
                        Session["Location"] = dt;



                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                if (end == "Land")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Invalid_Report("Land", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    Session["filename"] = "Land details-Invalid/Null";
                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = true;
                        div_lbl.Visible = true;
                        itda.Visible = true;
                        district.Visible = true;
                        lbl_itda.Text = (string)(Session["Itda"]);
                        lbl_dist.Text = (string)(Session["District"]);
                        status.Visible = true;
                        lbl_status.Text = "Land details-Invalid/Null";
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = true;
                        GridView5.Visible = false;
                        GridView4.DataSource = dt;

                        GridView4.DataBind();
                        Session["Land"] = dt;



                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                if (end == ">10")
                {
                    dt = ProjectRofrBAL.GetMasterDetails.Get_Land_Invalid_Report(">10", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);
                    Session["filename"] = "Extent >10 Acrs";
                    if (dt.Rows.Count > 0)
                    {
                        div_dist.Visible = false;
                        div_mandal.Visible = true;
                        div_lbl.Visible = true;
                        itda.Visible = true;
                        district.Visible = true;
                        lbl_itda.Text = (string)(Session["Itda"]);
                        lbl_dist.Text = (string)(Session["District"]);
                        status.Visible = true;
                        lbl_status.Text = "Extent >10 Acrs";
                        btn_back_dist.Visible = true;
                        btn_upload.Visible = false;
                        btn_notupload.Visible = true;
                        GridView2.Visible = false;
                        GridView3.Visible = false;
                        GridView4.Visible = false;
                        GridView5.Visible = true;
                        GridView5.DataSource = dt;

                        GridView5.DataBind();
                        Session[">10"] = dt;



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
            div_lbl.Visible = false;
            div_dist.Visible = true;
            div_mandal.Visible = false;
            btn_back_dist.Visible = false;
           
            btn_upload.Visible = true;
            btn_notupload.Visible = false;
           
        }
       

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
                dt = (DataTable)(Session["districtexcel"]);

                if (dt.Rows.Count > 0)
                {


                    string filename = "Land_Invalid_Data_Report.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_notupload_Click(object sender, EventArgs e)
        {
            try
            {


                DataTable dt = new DataTable();
               
                if ((string)Session["end"] == "Duplicate")
                {
                    dt = (DataTable)(Session["Duplicate"]);
                
                }
                if ((string)Session["end"] == "Invalid")
                {
                  
                    dt = (DataTable)(Session["Invalid"]);

                }
                   
                if ((string)Session["end"] == "Father")
                {
                    dt = (DataTable)(Session["Father"]);
                  
                }
                if ((string)Session["end"] == "Location")
                {
                    dt = (DataTable)(Session["Location"]);
                  
                }
                if ((string)Session["end"] == "Land")
                {
                    dt = (DataTable)(Session["Land"]);
                 
                    }
                if ((string)Session["end"] == ">10")
                {
                    dt = (DataTable)(Session[">10"]);

                }
                string filename = (string)(Session["filename"]) +".xls";

                if (dt.Rows.Count > 0)
                {
                    
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


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
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found!')", true);
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
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
    public partial class MandalWise_BeneficiaryMaster_Abstract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if ((string)(Session["CurrentPage"]) == "MandalWise_BeneficiaryMaster_Abstract.aspx")
                    {
                        string Itda = (string)(Session["Itda"]);
                        string dist = (string)(Session["District"]);
                        lbl_itda.Text = Itda;
                        lbl_dist.Text = dist;
                        if (dist!= "" & Itda!="")
                        {
                            BindData(Itda,dist);
                        }
                    }
                    else
                    {
                        if ((string)(Session["District"]) != "" && (string)(Session["Itda"])!="")
                        {
                            string Itda = (string)(Session["Itda"]);
                            string dist = (string)(Session["District"]);
                          
                            lbl_itda.Text = Itda;
                            lbl_dist.Text = dist;
                            if (dist != "" & Itda != "")
                            {
                                BindData(Itda,dist);
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void BindData(string Itda,string dist)
        {
            try
            {

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetDistWiseBeneficiaryMasterCount("Mandal", Itda, dist, "", "", (string)(Session["username"]), (string)Session["userprevilages"]);

                if (dt.Rows.Count > 0)
                {
                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno"] = i + 1;
                    }


                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= 9; j++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 0)
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
                                //else
                                //{
                                //    if (j != 0)
                                //    {
                                //        string IL = "lbl";
                                //        IL = IL + j;
                                //        Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                //        lbl.Visible = true;
                                //        lbl.ForeColor = System.Drawing.Color.Black;
                                //    }
                                //}
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


        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {

                string Itda = (string)(Session["Itda"]);
                string dist = (string)(Session["District"]);
                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetDistWiseBeneficiaryMasterCount("Mandal", Itda, dist, "", "", (string)(Session["username"]), (string)Session["userprevilages"]);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr2 = dt.NewRow();
                    foreach (DataRow dr in dt.Rows)
                    {


                        dr2["Mandal"] = "Note: Invalid Aadhar Number includes Death,Migrated,No Aadhar";
                    }

                    dt.Rows.Add(dr2);

                    dt.Columns["Mandal"].ColumnName = "Mandal";
                dt.Columns["Total_Beneficiaries"].ColumnName = "Farmers as per Giribhumi ";

                dt.Columns["Total_Received"].ColumnName = "No of Farmers Having Aadhar Numbers";
                    dt.Columns["Adhharnotavaliable"].ColumnName = "No of Farmers Not Having  Aadhar Numbers";
                    dt.Columns["Adhharisvalid"].ColumnName = "No of Farmers Having Valid Aadhar Numbers";
                dt.Columns["Adhharnoinvalid"].ColumnName = "No of Farmers Having Invalid Aadhar Numbers";
              
                dt.Columns["Bankavaliable"].ColumnName = "No of Farmers Having Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["Banknotavaliable"].ColumnName = "No of Farmers Not Having Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["Bankinvalid"].ColumnName = "No of Farmers Having Invalid Bank Details (Bank A/c + IFSC Code)";
                dt.Columns["FullBankDetails"].ColumnName = "No of Farmers Having Full Details( Bank A/c + IFSC Code + Aadhar No)";

                
                    string filename = "MandalWise_Farmers.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


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

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);

                Session["CurrentPage"] = "MandalWise_BeneficiaryMaster_Abstract";

                if (start != "Total:")
                {
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["Mandal"] = start.Trim();
                            Response.Redirect("VillageWise_BeneficiaryMaster_Abstract.aspx");
                        }

                    }
                }




            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }


        protected void Back_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("DistrictWise_BeneficiaryMaster_Abstract.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        }
}
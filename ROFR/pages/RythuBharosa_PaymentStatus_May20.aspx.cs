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
    public partial class RythuBharosa_PaymentStatus_May20 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

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
               
                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetRythuBharosaStatus_May20("District", "", "", "", "", (string)(Session["username"]), (string)Session["userprevilages"]);


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
                        for (int j = 0; j <= 5; j++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 1)
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
                                if (j == 2)
                                {
                                   
                                    string IL = "lbl";
                                    IL = IL + j;
                                   
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                   
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
                string mdl = s.Substring(s.LastIndexOf(',') + 1);
                var drange = mdl.IndexOf('-');
                string dist = mdl.Substring(0, drange);
                string end = s.Substring(s.LastIndexOf('-') + 1);
                Session["Itda"] = start.Trim();
                Session["District"] = dist.Trim();


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetRythuBharosaStatus_May20("Mandal", (string)(Session["Itda"]), (string)(Session["District"]), "", "", (string)(Session["username"]), (string)Session["userprevilages"]);


                if (dt.Rows.Count > 0)
                {

                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno1", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno1"] = i + 1;
                    }
                    div_dist.Visible = false;
                    div_mandal.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    btn_back_dist.Visible = true;
                    GridView2.DataSource = dt;

                    GridView2.DataBind();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= 4; j++)
                        {
                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 0)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView2.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 1)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 2)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 3)
                                {

                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView2.Rows[i].FindControl(IL) as Label;

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

        protected void Mandal_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

               
                Session["Mandal"] = s.Trim();
              


                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetRythuBharosaStatus_May20("Village", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), "", (string)(Session["username"]), (string)Session["userprevilages"]);


                if (dt.Rows.Count > 0)
                {

                    //newly adding for serialNumber
                    dt.Columns.Add("itda_srno2", typeof(int));
                    for (int i = 0; i < dt.Rows.Count - 1; i++)
                    {
                        dt.Rows[i]["itda_srno2"] = i + 1;
                    }
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
                    btn_back_dist.Visible = false;
                    btn_back_mandal.Visible = true;
                    GridView3.DataSource = dt;

                    GridView3.DataBind();

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {

                            string value = dt.Rows[i][j].ToString();
                            if (i != dt.Rows.Count - 1)
                            {
                                if ((j == 1 && value == "0") || (j == 2 && value == "0") || (j == 3 && value == "0"))
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView3.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;

                                }
                            }
                            if (i == dt.Rows.Count - 1)
                            {

                                if (j == 0)
                                {
                                    string IL = "lbl";
                                    IL = IL + j;

                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;

                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;

                                  
                                }
                                if (j == 1)
                                {

                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView3.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 2)
                                {

                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView3.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
                                    lbl.ForeColor = System.Drawing.Color.DarkBlue;
                                }
                                if (j == 3)
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView3.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = false;
                                    Label lbl = GridView3.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = true;
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
        protected void Village_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');

                string start = s.Substring(0, range);

                string end = s.Substring(s.LastIndexOf(',') + 1);

                Session["Village"] = start.Trim();



                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetRythuBharosaStatus_May20("Psuccess", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);


                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = false;
                    div_success.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    village.Visible = true;
                    status.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
                    lbl_village.Text = (string)(Session["Village"]);
                    lbl_status.Text = end.Trim();
                    btn_back_dist.Visible = false;
                    btn_back_mandal.Visible = false;
                    btn_back_village.Visible = true;
                    GridView4.DataSource = dt;

                    GridView4.DataBind();

                 


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
        protected void Rejected_onclick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable dt=new DataTable();
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');

                string start = s.Substring(0, range);

                string end = s.Substring(s.LastIndexOf(',') + 1);

                Session["Village"] = start.Trim();

                if (end == "PENDING")
                {
                  dt = ProjectRofrBAL.GetMasterDetails.GetRythuBharosaStatus_May20("Pending", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);
                }
                if (end == "REJECTED")
                {
                     dt = ProjectRofrBAL.GetMasterDetails.GetRythuBharosaStatus_May20("Prejected", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);
                }

                if (dt.Rows.Count > 0)
                {
                    div_dist.Visible = false;
                    div_mandal.Visible = false;
                    div_village.Visible = false;
                    div_success.Visible = false;
                    div_rejected.Visible = true;
                    div_lbl.Visible = true;
                    itda.Visible = true;
                    district.Visible = true;
                    mandal.Visible = true;
                    village.Visible = true;
                    status.Visible = true;
                    lbl_itda.Text = (string)(Session["Itda"]);
                    lbl_dist.Text = (string)(Session["District"]);
                    lbl_mandal.Text = (string)(Session["Mandal"]);
                    lbl_village.Text = (string)(Session["Village"]);
                    lbl_status.Text = end.Trim();
                    btn_back_dist.Visible = false;
                    btn_back_mandal.Visible = false;
                    btn_back_village.Visible = true;
                    GridView5.DataSource = dt;

                    GridView5.DataBind();




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
        protected void Get_back_dist(object sender, EventArgs e)
        {
           
            div_lbl.Visible = false;
            div_dist.Visible = true;
            div_mandal.Visible = false;
            btn_back_dist.Visible = false;
            btn_back_mandal.Visible = false;
            
        }
        protected void Get_back_mandal(object sender, EventArgs e)
        {
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = true;
            div_village.Visible = false;
            btn_back_dist.Visible = true;
            btn_back_mandal.Visible = false;
            
        }
        protected void Get_back_village(object sender, EventArgs e)
        {
            div_lbl.Visible = true;
            itda.Visible = true;
            district.Visible = true;
            mandal.Visible = true;
            village.Visible = false;
            status.Visible = false;
            div_dist.Visible = false;
            div_mandal.Visible = false;
            div_village.Visible = true;
            div_success.Visible = false;
            div_rejected.Visible = false;
            btn_back_dist.Visible = false;
            btn_back_mandal.Visible = true;
            btn_back_village.Visible = false;
            
        }
    }
}
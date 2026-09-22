using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.Data.SqlClient;
namespace ROFR.pages
{
    public partial class Revenuewise_Loan_reports : System.Web.UI.Page
    {
        Loan_details loan = new Loan_details();
        public string type = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_bank.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {

                    BindBank();
                    ddl_bank.Items.Insert(0, new ListItem("Select", "0"));
                    div_dist.Visible = false;
                    div_division.Visible = false;
                    div_range.Visible = false;
                    div_beat.Visible = false;
                    //div_block.Visible = false;
                    div_entered.Visible = false;
                    div_approved.Visible = false;
                    div_released.Visible = false;
                    div_lbl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void BindBank()
        {
            try
            {

                loan.username = (string)(Session["username"]);
                loan.userprev = (string)Session["userprevilages"];
                loan.type = "bank";
                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Loan_Report(loan);


                if (dt.Rows.Count > 0)
                {


                    ddl_bank.DataSource = dt;
                    ddl_bank.DataTextField = "BANKNAME";
                    ddl_bank.DataValueField = "BANKNAME";
                    ddl_bank.DataBind();


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

        protected void Getdata_Click(object sender, EventArgs e)
        {

            div_dist.Visible = true;
            div_division.Visible = false;
            div_range.Visible = false;
            div_beat.Visible = false;
          
            div_entered.Visible = false;
            div_approved.Visible = false;
            div_released.Visible = false;
            lbl_dist.Visible = false;
            lbl_divn.Visible = false;
            lbl_rg.Visible = false;
            lbl_bt.Visible = false;
            lbl_bl.Visible = false;
            btn_back_div.Visible = false;
            btn_back_range.Visible = false;
            btn_back_beat.Visible = false;
          
            btn_back_entered.Visible = false;


            type = "ritda";
            loan.type = type;
            loan.bank_name = ddl_bank.SelectedItem.Text;
            loan.username = (string)(Session["username"]);
            loan.userprev = (string)Session["userprevilages"];

            DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Loan_Report(loan);

            BindData(dt, type);

        }
        protected void Getlink_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;
                var range = s.IndexOf(',');

                string start = s.Substring(0, range);

                type = s.Substring(s.LastIndexOf(',') + 1);
                loan.type = type;
                loan.bank_name = ddl_bank.SelectedItem.Text;

                loan.username = (string)(Session["username"]);
                loan.userprev = (string)Session["userprevilages"];
                if (type == "rdist")
                {
                    div_lbl.Visible = true;
                    lbl_dist.Visible = true;
                    div_dist.Visible = false;
                    div_division.Visible = true;
                    div_range.Visible = false;
                    div_beat.Visible = false;
                    // div_block.Visible = false;
                    div_entered.Visible = false;
                    div_approved.Visible = false;
                    div_released.Visible = false;
                    btn_back_div.Visible = true;
                    btn_back_range.Visible = false;
                    btn_back_beat.Visible = false;
                   
                    Session["District"] = start;
                    lbl_district.Text = (string)(Session["District"]);
                    loan.dist = (string)(Session["District"]);
                }
                else if (type == "rmandal")
                {
                    div_lbl.Visible = true;
                    lbl_dist.Visible = true;
                    lbl_divn.Visible = true;
                    div_dist.Visible = false;
                    div_division.Visible = false;
                    div_range.Visible = true;
                    div_beat.Visible = false;
                    //  div_block.Visible = false;
                    div_entered.Visible = false;
                    div_approved.Visible = false;
                    div_released.Visible = false;
                    btn_back_range.Visible = true;
                    btn_back_div.Visible = false;
                    btn_back_beat.Visible = false;
                   
                    Session["Division"] = start;
                    lbl_district.Text = (string)(Session["District"]);
                    lbl_div.Text = (string)(Session["Division"]);
                    loan.dist = (string)(Session["District"]);

                    loan.division = (string)(Session["Division"]);
                }
                else if (type == "rvillage")
                {
                    div_lbl.Visible = true;
                    lbl_dist.Visible = true;
                    lbl_divn.Visible = true;
                    lbl_rg.Visible = true;
                    div_dist.Visible = false;
                    div_division.Visible = false;
                    div_range.Visible = false;
                    div_beat.Visible = true;
                    // div_block.Visible = false;
                    div_entered.Visible = false;
                    div_approved.Visible = false;
                    div_released.Visible = false;
                    btn_back_beat.Visible = true;
                    btn_back_range.Visible = false;
                    btn_back_div.Visible = false;
                   
                    Session["Range"] = start;
                    lbl_district.Text = (string)(Session["District"]);
                    lbl_div.Text = (string)(Session["Division"]);
                    lbl_range.Text = (string)(Session["Range"]);
                    loan.dist = (string)(Session["District"]);
                    loan.division = (string)(Session["Division"]);
                    loan.range = (string)(Session["Range"]);
                }

                else if (type == "RENTERED" || type == "RAPPROVED" || type == "RRELEASED")
                {
                    div_lbl.Visible = true;
                    lbl_dist.Visible = true;
                    lbl_divn.Visible = true;
                    lbl_rg.Visible = true;
                    lbl_bt.Visible = true;
                    div_dist.Visible = false;
                    div_division.Visible = false;
                    div_range.Visible = false;
                    div_beat.Visible = false;
                    // div_block.Visible = true;
                    div_entered.Visible = false;
                    div_approved.Visible = false;
                    div_released.Visible = false;
                                      btn_back_range.Visible = false;
                    btn_back_beat.Visible = false;
                    btn_back_div.Visible = false;
                  btn_back_entered.Visible =true;
                    Session["Beat"] = start;
                    lbl_district.Text = (string)(Session["District"]);
                    lbl_div.Text = (string)(Session["Division"]);
                    lbl_range.Text = (string)(Session["Range"]);
                    lbl_beat.Text = (string)(Session["Beat"]);
                    loan.dist = (string)(Session["District"]);
                    loan.division = (string)(Session["Division"]);
                    loan.range = (string)(Session["Range"]);
                    loan.beat = (string)(Session["Beat"]);
                }
                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Loan_Report(loan);

                BindData(dt, type);


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void BindData(DataTable dt, string type)
        {
            try
            {


                if (dt.Rows.Count > 0)
                {
                    if (type == "ritda")
                    {
                        GridView1.DataSource = dt;

                        GridView1.DataBind();
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt.Columns.Count - 1; j++)
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

                                }

                            }
                        }

                    }
                    else if (type == "rdist")
                    {
                        GridView2.DataSource = dt;

                        GridView2.DataBind();
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt.Columns.Count - 1; j++)
                            {
                                if (i == dt.Rows.Count - 1)
                                {

                                    if (j == 0)
                                    {
                                        string IB = "LinkDButton";
                                        IB = IB + j;
                                        string IL = "lbld";
                                        IL = IL + j;
                                        LinkButton ibutton = GridView2.Rows[i].FindControl(IB) as LinkButton;
                                        ibutton.Visible = false;
                                        Label lbl = GridView2.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = true;

                                    }

                                }

                            }
                        }

                    }
                    else if (type == "rmandal")
                    {
                        GridView3.DataSource = dt;

                        GridView3.DataBind();
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j <= dt.Columns.Count - 1; j++)
                            {
                                if (i == dt.Rows.Count - 1)
                                {

                                    if (j == 0)
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

                            }
                        }

                    }
                    else if (type == "rvillage")
                    {
                        GridView4.DataSource = dt;

                        GridView4.DataBind();
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
                                        LinkButton ibutton = GridView4.Rows[i].FindControl(IB) as LinkButton;
                                        ibutton.Visible = false;
                                        Label lbl = GridView4.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = true;

                                    }
                                }
                                    if (i == dt.Rows.Count - 1)
                                {

                                    if (j == 1 || j == 2 || j == 3)
                                    {
                                        string IB = "LinkButton";
                                        IB = IB + j;
                                        string IL = "lbl";
                                        IL = IL + j;
                                        LinkButton ibutton = GridView4.Rows[i].FindControl(IB) as LinkButton;
                                        ibutton.Visible = false;
                                        Label lbl = GridView4.Rows[i].FindControl(IL) as Label;
                                        lbl.Visible = true;

                                    }

                                }

                            }
                        }

                    }

                    else if (type == "RENTERED")
                    {
                      
                        div_entered.Visible = true;
                        div_approved.Visible = false;
                        div_released.Visible = false;
                        GridView6.DataSource = dt;

                        GridView6.DataBind();

                    }
                    else if (type == "RAPPROVED")
                    {
                     
                        div_entered.Visible = false;
                        div_approved.Visible = true;
                        div_released.Visible = false;
                        GridView7.DataSource = dt;

                        GridView7.DataBind();

                    }
                    else if (type == "RRELEASED")
                    {
                      
                        div_entered.Visible = false;
                        div_approved.Visible = false;
                        div_released.Visible = true;
                        GridView8.DataSource = dt;

                        GridView8.DataBind();

                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);

                    if (type == "ritda")
                    {
                        div_lbl.Visible = false;
                        div_dist.Visible = false;
                        div_division.Visible = false;
                        div_range.Visible = false;
                        div_beat.Visible = false;
                        
                        div_entered.Visible = false;
                        div_approved.Visible = false;
                        div_released.Visible = false;
                        lbl_dist.Visible = false;
                        lbl_divn.Visible = false;
                        lbl_rg.Visible = false;
                        lbl_bt.Visible = false;
                        lbl_bl.Visible = false;
                    }
                    if (type == "rdist")
                    {
                        lbl_dist.Visible = false;
                        div_division.Visible = false;
                        div_dist.Visible = true;

                        div_range.Visible = false;
                        div_beat.Visible = false;
                       
                        div_entered.Visible = false;
                        div_approved.Visible = false;
                        div_released.Visible = false;
                        btn_back_div.Visible = false;

                    }
                    if (type == "rmandal")
                    {
                        div_range.Visible = false;
                        lbl_divn.Visible = false;
                        btn_back_div.Visible = true;
                        btn_back_range.Visible = false;

                        div_dist.Visible = false;
                        div_division.Visible = true;
                        div_range.Visible = false;
                        div_beat.Visible = false;
                       
                        div_entered.Visible = false;
                        div_approved.Visible = false;
                        div_released.Visible = false;
                    }
                    if (type == "rvillage")
                    {
                        div_beat.Visible = false;
                        lbl_rg.Visible = false;
                        btn_back_range.Visible = true;
                        btn_back_beat.Visible = false;
                        div_dist.Visible = false;
                        div_division.Visible = false;
                        div_range.Visible = true;
                        div_beat.Visible = false;
                        
                        div_entered.Visible = false;
                        div_approved.Visible = false;
                        div_released.Visible = false;
                    }
                   
                    if (type == "RENTERED" || type == "RAPPROVED"|| type == "RRELEASED")
                    {
                        div_entered.Visible = false;
                        btn_back_beat.Visible = true;
                        btn_back_entered.Visible = false;
                        lbl_bt.Visible = false;
                        div_dist.Visible = false;
                        div_division.Visible = false;
                        div_range.Visible = false;
                        div_beat.Visible = true;
                    
                        
                        div_approved.Visible = false;
                        div_released.Visible = false;
                    }

                 



                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Get_back_div(object sender, EventArgs e)
        {

            div_dist.Visible = true;
            div_division.Visible = false;
            div_range.Visible = false;
            div_beat.Visible = false;
            //div_block.Visible = false;
            div_entered.Visible = false;
            div_approved.Visible = false;
            div_released.Visible = false;
            div_lbl.Visible = false;
            btn_back_div.Visible = false;

        }
        protected void Get_back_range(object sender, EventArgs e)
        {

            div_lbl.Visible = true;
            lbl_dist.Visible = true;
            lbl_divn.Visible = false;
            div_dist.Visible = false;
            div_division.Visible = true;
            div_range.Visible = false;
            div_beat.Visible = false;
            // div_block.Visible = false;
            div_entered.Visible = false;
            div_approved.Visible = false;
            div_released.Visible = false;
            btn_back_div.Visible = true;
            btn_back_range.Visible = false;
            btn_back_beat.Visible = false;
           


        }
        protected void Get_back_beat(object sender, EventArgs e)
        {

            div_lbl.Visible = true;
            lbl_dist.Visible = true;
            lbl_divn.Visible = true;
            lbl_rg.Visible = false;
            div_dist.Visible = false;
            div_division.Visible = false;
            div_range.Visible = true;
            div_beat.Visible = false;
            //div_block.Visible = false;
            div_entered.Visible = false;
            div_approved.Visible = false;
            div_released.Visible = false;
            btn_back_range.Visible = true;
            btn_back_div.Visible = false;
            btn_back_beat.Visible = false;
       

        }
     
        protected void Get_back_entered(object sender, EventArgs e)
        {

            div_lbl.Visible = true;
            lbl_dist.Visible = true;
            lbl_divn.Visible = true;
            lbl_rg.Visible = true;
            lbl_bt.Visible = false;
          
            div_dist.Visible = false;
            div_division.Visible = false;
            div_range.Visible = false;
            div_beat.Visible = true;
           
            div_entered.Visible = false;
            div_approved.Visible = false;
            div_released.Visible = false;
            btn_back_beat.Visible = true;
            btn_back_range.Visible = false;
            btn_back_div.Visible = false;
          
            btn_back_entered.Visible = false;


        }
        protected void ddlbank_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try


            {
                div_lbl.Visible = false;
                lbl_dist.Visible = false;
                lbl_divn.Visible = false;
                lbl_rg.Visible = false;
                lbl_bt.Visible = false;
                lbl_bl.Visible = false;
                div_dist.Visible = false;
                div_division.Visible = false;
                div_range.Visible = false;
                div_beat.Visible = false;
               
                div_entered.Visible = false;
                div_approved.Visible = false;
                div_released.Visible = false;
              
                btn_back_range.Visible = false;
                btn_back_beat.Visible = false;
                btn_back_div.Visible = false;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
    }
}
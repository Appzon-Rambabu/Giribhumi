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
    public partial class Bankwise_Loan_Reports : System.Web.UI.Page
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

           
            loan.bank_name = ddl_bank.SelectedItem.Text;
            div_entered.Visible = true;
            loan.username = (string)(Session["username"]);
            loan.userprev = (string)Session["userprevilages"];
            if (rbtn_status.SelectedItem.Text == "All")
            {
                loan.type = "All";
                div_entered.Visible = false;
                div_all.Visible = true;
                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Loan_Report(loan);

                //BindData(dt, type);
                if (dt.Rows.Count > 0)
                {
                    GridView3.DataSource = dt;

                    GridView3.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found!')", true);
                }
            }
            else
            {
                if (rbtn_status.SelectedItem.Text == "Entered")
                {
                    type = "bentered";
                    loan.type = type;

                }
                else if (rbtn_status.SelectedItem.Text == "Approved")
                {
                    type = "bapproved";
                    loan.type = type;

                }
                else if (rbtn_status.SelectedItem.Text == "Released")
                {
                    type = "breleased";
                    loan.type = type;

                }
                else if (rbtn_status.SelectedItem.Text == "Not Released")
                {
                    type = "bnotreleased";
                    loan.type = type;

                }

                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Loan_Report(loan);

                //BindData(dt, type);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found!')", true);
                }
            }
        }
        protected void Getlink_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)sender;
                string start = btn.CommandArgument;
                //var range = s.IndexOf(',');

                //string start = s.Substring(0, range);

                //type = s.Substring(s.LastIndexOf(',') + 1);
              
                loan.bank_name = ddl_bank.SelectedItem.Text;
                loan.branch_name = start;

                Session["Branch"] = start;
                loan.username = (string)(Session["username"]);
                loan.userprev = (string)Session["userprevilages"];
               
             

              //BindData(dt, type);

                if (rbtn_status.SelectedItem.Text == "Entered")
                {
                    loan.type = "branch_entered";
                }
              else  if (rbtn_status.SelectedItem.Text == "Approved")
                {
                    loan.type = "branch_approved";
                }
                else if (rbtn_status.SelectedItem.Text == "Released")
                {
                    loan.type = "branch_released";
                }
                else if (rbtn_status.SelectedItem.Text == "Not Released")
                {
                    loan.type = "branch_notreleased";
                }
               
                DataTable dt = ProjectRofrBAL.GetMasterDetails.Get_Loan_Report(loan);
                if (dt.Rows.Count > 0)
                {
                    div_entered.Visible = false;
                    div_branch_entered.Visible = true;
                    btn_back_entered.Visible = true;
                    lbl_branch.Text = (string)(Session["Branch"]);
                    lblbanch.Visible = true;
                    GridView2.DataSource = dt;

                    GridView2.DataBind();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found!')", true);
                }
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
                    if (type == "bentered")
                    {
                        GridView1.DataSource = dt;

                        GridView1.DataBind();
                        //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        //{
                        //    for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        //    {
                        //        if (i == dt.Rows.Count - 1)
                        //        {

                        //            if (j == 1)
                        //            {
                        //                string IB = "LinkButton";
                        //                IB = IB + j;
                        //                string IL = "lbl";
                        //                IL = IL + j;
                        //                LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                        //                ibutton.Visible = false;
                        //                Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                        //                lbl.Visible = true;

                        //            }

                        //        }

                        //    }
                        //}

                    }
                    else if (type == "branch_entered")
                    {
                        div_entered.Visible = false;
                        div_branch_entered.Visible = true;
                        btn_back_entered.Visible = true;
                        lbl_branch.Text = (string)(Session["Branch"]);
                        lblbanch.Visible = true;
                       
                        GridView2.DataSource = dt;

                        GridView2.DataBind();
                     

                    }
                   else if (type == "bapproved")
                    {
                        GridView3.DataSource = dt;

                        GridView3.DataBind();
                     

                    }

                    else if (type == "branch_entered")
                    {
                       


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

        protected void Get_back_entered(object sender, EventArgs e)
        {

            div_entered.Visible = true;
            div_branch_entered.Visible = false;
            lblbanch.Visible = false;
            btn_back_entered.Visible = false;
        }
     

        protected void ddlbank_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try


            {
              
                lblbanch.Visible = false;
               
                div_entered.Visible = false;
                div_branch_entered.Visible = false;
                div_all.Visible = false;
                btn_back_entered.Visible = false;
                
              
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void rbtn_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_entered.Visible = false;
            div_branch_entered.Visible = false;
           
            lblbanch.Visible = false;
            btn_back_entered.Visible = false;
            div_all.Visible = false;
           

        }
    }
}
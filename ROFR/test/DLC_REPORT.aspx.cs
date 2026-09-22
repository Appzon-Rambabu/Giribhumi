using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data.SqlClient;
using System.Data;

namespace ROFR.test
{
    public partial class DLC_REPORT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    BindItda();
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));

                    panel1.Visible = false;

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        private void BindItda()
        {
            try
            {
                DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdadetails((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_NAME";
                    ddl_ITda.DataBind();
                    ddl_ITda.Items.Insert(0, new ListItem("Select", "0"));
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
        private void BindDistrict(DataTable dt)
        {
            try
            {
                DataTable dtDistricts = dt;
                ddl_district.DataSource = dtDistricts;
                ddl_district.DataTextField = "DISTRICT_NAME";
                ddl_district.DataValueField = "DISTRICT_CODE";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_mandal.DataValueField = "MANDAL_CODE";
                ddl_mandal.DataBind();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindVillage(DataTable dtVillages)
        {
            try
            {
                ddl_village.DataSource = dtVillages;
                ddl_village.DataTextField = "VILLAGE_NAME";
                ddl_village.DataValueField = "VILLAGE_CODE";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlitda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                   


                    DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


                            if (dtMandal.Rows.Count > 0)
                            {
                                BindMandal(dtMandal);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                            }
                        }
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
        protected void ddldistrict_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_district.SelectedItem.Text != "Select")
                {


                    DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }


                }
                else
                {
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
           


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
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueVillages", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


                    if (dtVillages.Rows.Count > 0)
                    {
                        BindVillage(dtVillages);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    ddl_village.ClearSelection();

                  

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }


        protected void ddlvillage_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ddl_district.SelectedItem.Text != "Select" && ddl_mandal.SelectedItem.Text != "Select")
                {
                             
                                BindData(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text);
                }
                            else
                            {

                               
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                            }

                        
                  
                 

 
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void BindData(string ITDA,string district,string mandal,string village)
        {
            try
            {

                         

                DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetDLCcount(ITDA, district, mandal, village);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();
                    panel1.Visible = true;

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dt.Columns.Count - 1; j++)
                        {
                            string value = dt.Rows[i][j].ToString();

                            if (i != (dt.Rows.Count))
                            {
                                if ((value == "0" && j>9))
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
                                else if ((value != "0" && j >9))
                                {
                                    string IB = "LinkButton";
                                    IB = IB + j;
                                    string IL = "lbl";
                                    IL = IL + j;
                                    LinkButton ibutton = GridView1.Rows[i].FindControl(IB) as LinkButton;
                                    ibutton.Visible = true;
                                    Label lbl = GridView1.Rows[i].FindControl(IL) as Label;
                                    lbl.Visible = false;
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

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;



                var range = s.IndexOf('-');

                string start = s.Substring(0, range);
                string d = s.Substring(s.LastIndexOf('-') + 1);
                var Hab = d.IndexOf(',');
                string Habitation = d.Substring(0, Hab);
                string end = s.Substring(s.LastIndexOf(',') + 1);

             
               
               if (end == "9")
                {

                    DataTable dt = MastersDataAnalysisBAL.MastersDataAnalysis.GetDlcBeneficiaryDetails(ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text,Habitation);
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtDlcdetails = new DataTable();
                        Session["dtDlcdetails"] = dt;
                        Session["CurrentDlcreportPage"] = "DLC_REPORT.aspx";
                        {
                            Response.Redirect("~//test//Dlc_BeneficiaryDetails.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found')", true);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;

namespace ROFR.test
{
    public partial class Adangal : System.Web.UI.Page
    {
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            if ((string)(Session["username"]) != null)
            {
                this.MasterPageFile = "~/Masters/Giribhumi_Master.Master";
            }
            else
            {

                this.MasterPageFile = "~/Masters/Giribhumi_Master.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "Captcha();", true);
                if (!IsPostBack)
                {
                    BindItda();

                    ddl_dist.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));




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
                DataTable dtItda = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Itda", "", "", "", "", "", "", "", (string)Session["userprevilages"]);
                // DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdaMaster((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_itda.DataSource = dtItda;
                    ddl_itda.DataTextField = "ITDA_NAME";
                    ddl_itda.DataValueField = "ITDA_CODE";
                    ddl_itda.DataBind();
                    ddl_itda.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_dist.DataSource = dtDistricts;
                ddl_dist.DataTextField = "DISTRICT_NAME";
                ddl_dist.DataValueField = "LGD_DISTRICT_CODE";
                ddl_dist.DataBind();
                ddl_dist.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_mandal.DataValueField = "LGD_MANDAL_CODE";
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
                ddl_village.DataValueField = "LGD_VILLAGE_CODE";
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
                GridView1.Visible = false;
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));


                if (ddl_itda.SelectedItem.Text != "Select")
                {
                    ddl_dist.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();


                    DataTable dtdistrict = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "District", ddl_itda.SelectedValue, "", "", "", "", "", "", (string)Session["userprevilages"]);
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_dist.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", ddl_itda.SelectedValue, ddl_dist.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);
                            // DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


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
                GridView1.Visible = false;
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_dist.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Mandal", ddl_itda.SelectedValue, ddl_dist.SelectedValue, "", "", "", "", "", (string)Session["userprevilages"]);

                    // DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


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
                GridView1.Visible = false;
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetRofrMasters1((string)(Session["username"]), "Village", ddl_itda.SelectedValue, ddl_dist.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                    // DataTable dtVillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueVillages", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


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

                GridView1.Visible = false;
                if (ddl_village.SelectedItem.Text != "Select")
                {

                    if (rbtn_list.SelectedValue == "D")
                    {
                        DataTable dtpattadar = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "pattadar", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                        // DataTable dtVillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueVillages", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


                        if (dtpattadar.Rows.Count > 0)
                        {
                            BindPattadar(dtpattadar);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        }
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


        protected void rbtn_list_SelectedIndexChanged1(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            string strAnswer = String.Empty;
            foreach (ListItem item in rbtn_list.Items)
            {
                if (item.Selected)
                {
                    strAnswer = item.Text;
                }
            }

            txt_rbtn.Text = strAnswer;
            if (rbtn_list.SelectedItem.Value == "A" || rbtn_list.SelectedItem.Value == "B" || rbtn_list.SelectedItem.Value == "C")
            {
                txt_rbtn_list.Visible = true;
                ddl_pattadhar.Visible = false;

            }
            //else  if (rbtn_list.SelectedItem.Value == "A")
            //  {
            //      txt_rbtn_list.Visible = true;
            //      ddl_pattadhar.Visible = false;

            //  }
            else if (rbtn_list.SelectedItem.Value == "D")
            {
                txt_rbtn_list.Visible = false;
                ddl_pattadhar.Visible = true;
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
            }
        }

        private void BindPattadar(DataTable dtpattadar)
        {
            try
            {
                ddl_pattadhar.DataSource = dtpattadar;
                ddl_pattadhar.DataTextField = "Rofr_Pattadaar";
                ddl_pattadhar.DataValueField = "Rofr_Pattadaar";
                ddl_pattadhar.DataBind();
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.Visible = true;

                if (rbtn_list.SelectedValue == "A")
                {
                    //DataTable dt = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "cno", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", txt_rbtn_list.Text, "", (string)Session["userprevilages"]);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    GridView1.DataSource = dt;
                    //    GridView1.DataBind();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);
                    //}

                    Session["Itda"] = ddl_itda.SelectedItem.Text;
                    Session["District"] = ddl_dist.SelectedItem.Text;
                    Session["Mandal"] = ddl_mandal.SelectedItem.Text;
                    Session["Village"] = ddl_village.SelectedItem.Text;
                    Session["cmno"] = txt_rbtn_list.Text;
                    Session["CurrentPage"] = "Adangal_Details.aspx";

                    
                               
                                // Response.Redirect("DetailsView_1B.aspx");
                                string url = "../test/Adangal_Details.aspx";
                                string u = "window.open('" + url + "', 'popup_window', 'width=800,height=550,resizable=yes');";
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", u, true);



                }

                else if (rbtn_list.SelectedValue == "B")
                {

                }

                else if (rbtn_list.SelectedValue == "C")
                {
                    DataTable dt = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "adhar", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", txt_rbtn_list.Text, (string)Session["userprevilages"]);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);
                    }
                }

                else if (rbtn_list.SelectedValue == "D")
                {
                    DataTable dt = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "pname", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, ddl_pattadhar.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);
                    }
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

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                Session["Itda"] = ddl_itda.SelectedItem.Text;
                Session["District"] = ddl_dist.SelectedItem.Text;
                Session["Mandal"] = ddl_mandal.SelectedItem.Text;
                Session["Village"] = ddl_village.SelectedItem.Text;
                Session["cmno"] = start ;
                Session["CurrentPage"] = "Adangal_Details.aspx";

                if (start != "Total:")
                {
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["cmno"] = start.Trim();
                            // Response.Redirect("DetailsView_1B.aspx");
                            string url = "../test/Adangal_Details.aspx";
                            string u = "window.open('" + url + "', 'popup_window', 'width=800,height=550,resizable=yes');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", u, true);

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
        protected void link_onclick1(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                Session["Itda"] = ddl_itda.SelectedItem.Text;
                Session["District"] = ddl_dist.SelectedItem.Text;
                Session["Mandal"] = ddl_mandal.SelectedItem.Text;
                Session["Village"] = ddl_village.SelectedItem.Text;
                Session["bid"] = start;
                Session["CurrentPage"] = "Adangal_Details.aspx";

                if (start != "Total:")
                {
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["cmno"] = start.Trim();
                            // Response.Redirect("DetailsView_1B.aspx");
                            string url = "../test/Adangal_Details.aspx";
                            string u = "window.open('" + url + "', 'popup_window', 'width=800,height=550,resizable=yes');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", u, true);

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
    }
}
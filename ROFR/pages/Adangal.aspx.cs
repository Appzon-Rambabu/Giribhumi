using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ROFR.helper;
using System.Text;
using System.Web.Helpers;

namespace ROFR.pages
{
    public partial class Adangal : System.Web.UI.Page
    {
        char a, b, c, d, e;
        string ct;
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            //if ((string)(Session["username"]) != null)
            //{
            //    this.MasterPageFile = "~/Masters/ROFR_MASTER.Master";
            //}
            //else
            //{

            //    this.MasterPageFile = "~/Masters/ROFR_MASTER.Master";
            //}
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_dist.Items.Insert(0, new ListItem("Select", "0"));
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_village.Items.Insert(0, new ListItem("Select", "0"));
          
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
                    Get_Captcha();



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
                DataTable dtItda = Landsettlementpattas.GetadangalRofrMasters1("", "Itda", "", "", "", "", "", "");
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
                System.Threading.Thread.Sleep(5000);

                GridView1.Visible = false;
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

                ddl_pattadhar.Items.Clear();
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_itda.SelectedItem.Text != "Select")
                {
                    System.Threading.Thread.Sleep(5000);
                    ddl_dist.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                    DataTable dtdistrict = Landsettlementpattas.GetadangalRofrMasters1((string)(Session["username"]), "District", ddl_itda.SelectedValue, "", "", "", "", (string)Session["userprevilages"]);
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                      //  System.Threading.Thread.Sleep(5000);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_dist.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetadangalRofrMasters1((string)(Session["username"]), "Mandal", ddl_itda.SelectedValue, ddl_dist.SelectedValue, "", "", "", (string)Session["userprevilages"]);
                            // DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


                            if (dtMandal.Rows.Count > 0)
                            {
                                BindMandal(dtMandal);
                             //   System.Threading.Thread.Sleep(5000);
                            }
                            else
                            {

                                ddl_dist.Items.Clear();
                                ddl_dist.Items.Insert(0, new ListItem("Select", "0"));

                                ddl_village.Items.Clear();
                                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                                ddl_mandal.Items.Clear();
                                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                                ddl_pattadhar.Items.Clear();
                                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));

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

                ddl_pattadhar.Items.Clear();
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_dist.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = Landsettlementpattas.GetadangalRofrMasters1((string)(Session["username"]), "Mandal", ddl_itda.SelectedValue, ddl_dist.SelectedValue, "", "", "", (string)Session["userprevilages"]);

                    // DataTable dtMandal = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueMandals", ddl_district.SelectedValue, ddl_ITda.SelectedItem.Text, " ");


                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                    }
                    else
                    {

                        ddl_village.Items.Clear();
                        ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Clear();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_pattadhar.Items.Clear();
                        ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));

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

                ddl_pattadhar.Items.Clear();
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));

                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetadangalRofrMasters1((string)(Session["username"]), "Village", ddl_itda.SelectedValue, ddl_dist.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);
                    // DataTable dtVillages = RevenueDistrictsBAL.RevenueDistricts.Getcheckergridmasters((string)(Session["username"]), "RevenueVillages", ddl_district.SelectedValue, ddl_mandal.SelectedValue, " ");


                    if (dtVillages.Rows.Count > 0)
                    {
                        BindVillage(dtVillages);
                    }
                    else
                    {
                        ddl_village.Items.Clear();
                        ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_pattadhar.Items.Clear();
                        ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));

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
            txt_rbtn_list.Text = "";
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
                

                DataTable dtpattadar = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "pattadar", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                if (dtpattadar.Rows.Count > 0)
                {
                    txt_rbtn_list.Visible = true;
                    ddl_pattadhar.Visible = false;
                    
                    ddl_itda.SelectedIndex = -1;
                    ddl_dist.SelectedIndex = -1;
                    ddl_mandal.SelectedIndex = -1;
                    ddl_village.SelectedIndex = -1;
                    ddl_pattadhar.SelectedIndex = -1;
                    txt_rbtn_list.Text = string.Empty;
                    

                    BindPattadar(dtpattadar);
                }
                else
                {
                    txt_rbtn_list.Visible = true;
                    ddl_pattadhar.Visible = false;
                    
                    ddl_itda.SelectedIndex = -1;
                    ddl_dist.SelectedIndex = -1;
                    ddl_mandal.SelectedIndex = -1;
                    ddl_village.SelectedIndex = -1;
                    ddl_pattadhar.SelectedIndex = -1;
                   
                    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                }
                

            }
            //else  if (rbtn_list.SelectedItem.Value == "A")
            //  {
            //      txt_rbtn_list.Visible = true;
            //      ddl_pattadhar.Visible = false;

            //  }
            else if (rbtn_list.SelectedItem.Value == "D")
            {

                DataTable dtpattadar = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "pattadar", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                if (dtpattadar.Rows.Count > 0)
                {
                    txt_rbtn_list.Visible = false;
                    ddl_pattadhar.Visible = true;
                    //new
                   
                    BindPattadar(dtpattadar);

                    ddl_itda.SelectedIndex = -1;
                    ddl_dist.SelectedIndex = -1;
                    ddl_mandal.SelectedIndex = -1;
                    ddl_village.SelectedIndex = -1;
                    ddl_pattadhar.SelectedIndex = -1;
                    
                }
                else
                {
                    txt_rbtn_list.Visible = false;
                   
                    ddl_pattadhar.Visible = true;
                    ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_itda.SelectedIndex = -1;
                    ddl_dist.SelectedIndex = -1;
                    ddl_mandal.SelectedIndex = -1;
                    ddl_village.SelectedIndex = -1;
                    ddl_pattadhar.SelectedIndex = -1;
                    // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                }
                //txt_rbtn_list.Visible = false;
                //ddl_pattadhar.Visible = true;
                //ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
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
               // AntiForgery.Validate();
                string captcha = txtInput.Value;
                string captcha1 = (string)Session["CaptchaCode"];
                if (captcha != null && captcha != "")
                {
                    //string string1 = captcha.Replace(" ", "");
                    //string string2 = captcha1.Replace(" ", "");
                    if (captcha == (string)Session["CaptchaCode"])
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
                            if (txt_rbtn_list.Text != "") {
                            Session["Itda"] = ddl_itda.SelectedItem.Text;
                            Session["District"] = ddl_dist.SelectedItem.Text;
                            Session["Mandal"] = ddl_mandal.SelectedItem.Text;
                            Session["Village"] = ddl_village.SelectedItem.Text;
                            Session["cmno"] = txt_rbtn_list.Text;
                            Session["CurrentPage"] = "Adangal_Details.aspx";



                            // Response.Redirect("DetailsView_1B.aspx");
                            string url = "../pages/Adangal_Details.aspx";
                            string u = "window.open('" + url + "', 'popup_window', 'width=800,height=550,resizable=yes');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", u, true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Compartment Number!')", true);
                            }


                        }

                        else if (rbtn_list.SelectedValue == "B")
                        {

                        }

                        else if (rbtn_list.SelectedValue == "C")
                        {
                            if (txt_rbtn_list.Text != "")
                            {
                                string aano = Request.Form[HiddenField1.UniqueID];
                                DataTable dt = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "adhar", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", aano, (string)Session["userprevilages"]);
                                if (dt.Rows.Count > 0)
                                {
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                    System.Threading.Thread.Sleep(5000);
                                    ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(5000);
                                    ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);
                                }
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(5000);
                                ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Aadhar Number !')", true);
                            }
                        }

                        else if (rbtn_list.SelectedValue == "D")
                        {
                            if (ddl_pattadhar.SelectedItem.Text != "Select")
                            {
                                DataTable dt = Landsettlementpattas.Get1bdetails((string)(Session["username"]), "pname", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, ddl_pattadhar.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);
                                if (dt.Rows.Count > 0)
                                {
                                    GridView1.DataSource = dt;
                                    GridView1.DataBind();
                                    System.Threading.Thread.Sleep(5000);
                                    ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                                }
                                else
                                {
                                    System.Threading.Thread.Sleep(5000);
                                    ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);
                                }
                            }
                            else
                            {
                                System.Threading.Thread.Sleep(5000);
                                ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Pattadar Name!')", true);
                            }
                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(5000);
                        ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Enter Valid Captcha')", true);
                        txtInput.Value = "";
                    }
                }
                else
                    {
                    System.Threading.Thread.Sleep(5000);
                    ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Captcha')", true);
                    }
                    }
            catch (Exception ex)
            {
                System.Threading.Thread.Sleep(5000);
                ScriptManager.RegisterStartupScript(this, GetType(), "hideLoader", "hideLoader();", true);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void link_onclick(object sender, EventArgs e)
        {
            try
            {
              //  AntiForgery.Validate();

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
                            string url = "../pages/Adangal_Details.aspx";
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
               // AntiForgery.Validate();
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

       

        protected void Submit_Click(object sender, EventArgs e)
        {
          //  AntiForgery.Validate();
            Get_Captcha();
            txtInput.Value = "";
        }
        private void Get_Captcha()
        {
            try
            {

                Image2.ImageUrl = "~/pages/Captcha.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
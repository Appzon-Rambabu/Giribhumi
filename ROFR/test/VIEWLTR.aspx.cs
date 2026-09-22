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
    public partial class VIEWLTR : System.Web.UI.Page
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
                    ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                    Repeater1.Visible = false;

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


                DataTable dtItda = Landsettlementpattas.GetMasters((string)(Session["username"]), "Itda", "", "", "", "","", (string)Session["userprevilages"]);

                if (dtItda.Rows.Count > 0)
                {
                    ddl_Itda.DataSource = dtItda;
                    ddl_Itda.DataTextField = "ITDA_NAME";
                    ddl_Itda.DataValueField = "ITDA_NAME";
                    ddl_Itda.DataBind();
                    ddl_Itda.Items.Insert(0, new ListItem("Select", "0"));
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
                ddl_district.DataTextField = "DISTRICT";
                ddl_district.DataValueField = "DISTRICT";
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
                ddl_mandal.DataValueField = "MANDAL_NAME";
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
                ddl_village.DataValueField = "VILLAGE_NAME";
                ddl_village.DataBind();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindHab(DataTable dthab)
        {
            try
            {
                ddl_hab.DataSource = dthab;
                ddl_hab.DataTextField = "HABITATION";
                ddl_hab.DataValueField = "HABITATION";
                ddl_hab.DataBind();
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));

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
                ddl_mandal.Items.Clear();
               ddl_village.Items.Clear();
               ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                Repeater1.Visible = false;
                if (ddl_Itda.SelectedItem.Text != "Select")
                {
                  
                    DataTable dtdistrict = Landsettlementpattas.GetMasters((string)(Session["username"]), "District", ddl_Itda.SelectedItem.Text, "", "", "","", (string)Session["userprevilages"]);
                    if (dtdistrict.Rows.Count > 0)
                    {
                       
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            
                            
                            ddl_district.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetMasters((string)(Session["username"]), "Mandal", ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, "", "","", (string)Session["userprevilages"]);
                         
                            if (dtMandal.Rows.Count > 0)
                            {
                              
                                BindMandal(dtMandal);
                                ddl_village.ClearSelection();
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

        protected void ddl_district_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddl_mandal.Items.Clear();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                Repeater1.Visible = false;
                if (ddl_district.SelectedItem.Text != "Select")
                {


                    DataTable dtMandal = Landsettlementpattas.GetMasters((string)(Session["username"]), "Mandal", ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, "", "","", (string)Session["userprevilages"]);


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
                ddl_village.Items.Clear();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_hab.Items.Clear();
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                Repeater1.Visible = false;
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                  
                    DataTable dtVillages = Landsettlementpattas.GetMasters((string)(Session["username"]), "Village", ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, "","", (string)Session["userprevilages"]);


                    if (dtVillages.Rows.Count > 0)
                    {
                        BindVillage(dtVillages);
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

       

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
        protected void Linkview_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton btn = (LinkButton)(sender);
                //string s = btn.CommandArgument;

                //var range = s.IndexOf('-');

                //string Id = s.Substring(0, range);
                //string rsno= s.Substring(s.LastIndexOf('-') + 1);


                string Id = btn.CommandArgument;
                Session["ltId"] = Id;
                // Session["rsno"] = rsno;
                Session["CurrentPage"] = "VIEWLTR.aspx";
                Response.Redirect("~//test//LAND_TRANSFER_REGULATION.aspx");

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
                ddl_hab.Items.Clear();
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                Repeater1.Visible = false;
                if ( ddl_village.SelectedItem.Text != "Select")

                {

                    DataTable dthab = Landsettlementpattas.GetMasters((string)(Session["username"]),"Habitation", ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", (string)Session["userprevilages"]);
                    
                    if (dthab.Rows.Count > 0)
                    {
                        BindHab(dthab);
                    }
                    else
                    {
                        Repeater1.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);


                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Village !')", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddl_hab_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ddl_hab.SelectedItem.Text!="Select")

                {
                    Repeater1.Visible = true;

                    DataTable dt = Landsettlementpattas.GetLtrData(ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text,ddl_hab.SelectedItem.Text);
                    if (dt.Rows.Count > 0)
                    {
                        Repeater1.DataSource = dt;

                        Repeater1.DataBind();
                    }
                    else
                    {
                        Repeater1.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);


                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Village !')", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlrecords_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //public void BindCount(string district, bool FLAG,string VALUE, string Itda, string mandal)
        //{
        //    try
        //    {
        //        string recordvalue = string.Empty;

        //        Repeater1.DataSource = null;

        //        Repeater1.DataBind();


        //        DataTable dt = Landsettlementpattas.GetCropLoanDataCount(district, Itda, mandal);

        //        if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
        //        {
        //            if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
        //            {
        //                select_records.Visible = true;
        //                ListItemCollection list = new ListItemCollection();
        //                int rowscount = Convert.ToInt32(dt.Rows[0]["count"].ToString());
        //                string k = string.Empty;
        //                for (int i = 1; i <= rowscount; i++)
        //                {
        //                    if (rowscount <= 100)
        //                    {
        //                        int j = i + (rowscount - 1);
        //                        k = i + "-" + j;
        //                        list.Add(new ListItem(k));
        //                        i = j;
        //                    }
        //                    else
        //                    {
        //                        int remainingrows = rowscount - i;
        //                        if (remainingrows > 100)
        //                        {
        //                            int j = i + 99;
        //                            k = i + "-" + j;
        //                            if (FLAG == false)
        //                            {
        //                                if (VALUE == k)
        //                                {
        //                                    recordvalue = k;
        //                                }
        //                            }
        //                            list.Add(new ListItem(k));
        //                            i = j;
        //                        }
        //                        else
        //                        {
        //                            int j = (i) + remainingrows;
        //                            k = i + "-" + j;
        //                            list.Add(new ListItem(k));
        //                            i = j;
        //                            break;
        //                        }
        //                    }
        //                }
        //                ddl_records.DataSource = list;
        //                ddl_records.DataBind();
        //                if (FLAG == true)
        //                {
        //                    ddl_records.Items.Insert(0, new ListItem("Select", "0"));
        //                }
        //                else
        //                {
        //                    ddl_records.Items.Insert(0, new ListItem("Select", "0"));
        //                    if (recordvalue != string.Empty)
        //                    {
        //                        ddl_records.SelectedValue = recordvalue;
        //                    }
        //                    else
        //                    {
        //                        ddl_records.SelectedValue = k;
        //                    }

        //                }

        //            }
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('No Data Found')", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }

        //}
    }
}
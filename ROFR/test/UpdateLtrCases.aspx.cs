using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;

namespace ROFR.test
{
    public partial class UpdateLtrCases : System.Web.UI.Page
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

                    gvCases.Visible = true;


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
                ddl_hab.Items.Clear();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                gvCases.Visible = false;
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
                                gvCases.Visible = false;
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
                
                ddl_village.Items.Clear();
                
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                ddl_hab.Items.Clear();
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                gvCases.Visible = false;
                if (ddl_district.SelectedItem.Text != "Select")
                {


                    DataTable dtMandal = Landsettlementpattas.GetMasters((string)(Session["username"]), "Mandal",ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, "", "","", (string)Session["userprevilages"]);


                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                        gvCases.Visible = false;
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
                    ddl_hab.ClearSelection();


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
                gvCases.Visible = false;
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetMasters((string)(Session["username"]), "Village", ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, "","", (string)Session["userprevilages"]);


                    if (dtVillages.Rows.Count > 0)
                    {
                        BindVillage(dtVillages);
                        gvCases.Visible = false;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        ddl_village.ClearSelection();
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
                ddl_hab.Items.Clear();
                ddl_hab.Items.Insert(0, new ListItem("Select", "0"));
                gvCases.Visible = false;
                if (ddl_village.SelectedItem.Text != "Select")

                {

                    DataTable dthab = Landsettlementpattas.GetMasters((string)(Session["username"]), "Habitation", ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", (string)Session["userprevilages"]);

                    if (dthab.Rows.Count > 0)
                    {
                        BindHab(dthab);
                    }
                    else
                    {
                        gvCases.Visible = false;
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

        protected void gvCases_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCases.EditIndex = -1;
            BindData();
        }

        protected void EditCases(object sender, GridViewEditEventArgs e)
        {
            gvCases.EditIndex = e.NewEditIndex;
            //GridViewRow row = gvCases.SelectedRow;
            //row.Cells[0].Focus();
            BindData();
            gvCases.Rows[e.NewEditIndex].FindControl("txtrefno").Focus();
           
        }

        protected void UpdateCases(object sender, GridViewUpdateEventArgs e)
        {
            try
            { 
            string casestatus = (gvCases.Rows[e.RowIndex].FindControl("ddlstatus") as DropDownList).SelectedItem.Text;
            string LtrId = gvCases.DataKeys[e.RowIndex].Value.ToString();
            string refno = (gvCases.Rows[e.RowIndex].FindControl("txtrefno") as TextBox).Text;
            string caselevel = (gvCases.Rows[e.RowIndex].FindControl("txtclevel") as Label).Text;
                if (!string.IsNullOrEmpty(caselevel) )
                {
                    if(!string.IsNullOrEmpty(refno))
                    { 
                    DataTable dt = Landsettlementpattas.UpdateCase(LtrId, refno, casestatus, caselevel);
                    if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString() == "Success")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Case Status Updated Successfully !')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Case Status Updation Failed !')", true);
                    }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter reference number!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter case level !')", true);
                }
                gvCases.EditIndex = -1;
                BindData();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        private void BindData()
        {
            DataTable dt = Landsettlementpattas.UpadteLtrstatus(ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text,ddl_hab.SelectedItem.Text);

            if(dt.Rows.Count>0)
            {
                gvCases.DataSource = dt;

                gvCases.DataBind();
            }
            else
            {
                gvCases.Visible = false;
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);

            }
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
          
        }

        protected void ddl_hab_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    if (ddl_village.SelectedItem.Text != "Select")
                    {

                        gvCases.Visible = true;
                        //string status = "0";
                        DataTable dt = Landsettlementpattas.UpadteLtrstatus(ddl_Itda.SelectedItem.Text, ddl_district.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text,ddl_hab.SelectedItem.Text);
                        if (dt.Rows.Count > 0)
                        {
                            gvCases.DataSource = dt;

                            gvCases.DataBind();
                        }
                        else
                        {
                            gvCases.Visible = false;
                            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Available !')", true);


                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Village !')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Mandal !')", true);

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
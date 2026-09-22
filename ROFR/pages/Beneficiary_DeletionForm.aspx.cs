using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.NetworkInformation;
using ROFR.helper;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.Helpers;

namespace ROFR.pages
{
    public partial class Beneficiary_DeletionForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtSearch.Attributes.Add("onkeyup", "setTimeout('__doPostBack(\'" + txtSearch.ClientID.Replace("_", "$") + "\',\'\')', 0);");

            try
            {

                if (!IsPostBack)
                {

                    BindItda();

                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    div_dup.Visible = true;
                    del_ben.Visible = false;
                    del_land.Visible = false;
                    del_noland.Visible = false;
                    lnk_dupl.BackColor = System.Drawing.Color.Blue;
                    lnk_dupl.ForeColor = System.Drawing.Color.White;
                    lnk_ben.BackColor = System.Drawing.Color.White;
                    lnk_ben.ForeColor = System.Drawing.Color.Black;
                    lnk_land.BackColor = System.Drawing.Color.White;
                    lnk_land.ForeColor = System.Drawing.Color.Black;
                    lnk_noland.BackColor = System.Drawing.Color.White;
                    lnk_noland.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
        }
        private void BindItda()
        {
            try
            {

                DataTable dtItda = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);
                // DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdaMaster((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA_NAME";
                    ddl_ITda.DataValueField = "ITDA_CODE";
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
                ddl_district.DataValueField = "LGD_DISTRICT_CODE";
                ddl_district.DataBind();
                ddl_district.Items.Insert(0, new ListItem("Select", "0"));
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

                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();



                    DataTable dtdistrict = Landsettlementpattas.GetMastersUpdate((string)(Session["username"]), "District", ddl_ITda.SelectedValue, "", "", "", "", (string)Session["userprevilages"]);
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);

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
                if (ddl_district.SelectedItem.Text != "Select")
                {
                    BindGrid();


                }
                else
                {
                    GridView1.Visible = false;

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }


        protected void BindGrid()
        {
            try
            {
                DataTable dt = Landsettlementpattas.Beneficiary_Deletion_Form_Getdata((string)(Session["username"]), "Details", ddl_ITda.SelectedValue, ddl_district.SelectedItem.Text, (string)Session["userprevilages"], ddl_ITda.SelectedItem.Text, txtSearch.Text.ToString());



                if (dt.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["Data"] = dt;
                }
                else
                {
                    GridView1.Visible = false;

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void Ben_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            GridView3.Visible = false;
            GridView4.Visible = false;
            Session["DelData"] = "Beneficiary";
            del_ben12.Visible = false;
            noadhar.Visible = false;
            div_dup.Visible = false;
            del_ben.Visible = true;
            del_land.Visible = false;
            del_noland.Visible = true;
            lnk_dupl.BackColor = System.Drawing.Color.White;
            lnk_dupl.ForeColor = System.Drawing.Color.Black;
            lnk_ben.BackColor = System.Drawing.Color.Blue;
            lnk_ben.ForeColor = System.Drawing.Color.White;
            lnk_land.BackColor = System.Drawing.Color.White;
            lnk_land.ForeColor = System.Drawing.Color.Black;
            lnk_noland.BackColor = System.Drawing.Color.White;
            lnk_noland.ForeColor = System.Drawing.Color.Black;
           

            BindMandal();
            //BindBen();
        }
        protected void Dupl_Click(object sender, EventArgs e)
        {
            div_dup.Visible = true;
            del_ben.Visible = false;
            del_land.Visible = false;
            del_noland.Visible = false;
            lnk_dupl.BackColor = System.Drawing.Color.Blue;
            lnk_dupl.ForeColor = System.Drawing.Color.White;
            lnk_ben.BackColor = System.Drawing.Color.White;
            lnk_ben.ForeColor = System.Drawing.Color.Black;
            lnk_land.BackColor = System.Drawing.Color.White;
            lnk_land.ForeColor = System.Drawing.Color.Black;
            lnk_noland.BackColor = System.Drawing.Color.White;
            lnk_noland.ForeColor = System.Drawing.Color.Black;
        }
        private void BindMandal()
        {
             
            try
            {
                if((string)(Session["username"])=="ROFR_TEST" || (string)(Session["username"])=="admin")
                {
                    
                        DataTable dt = Landsettlementpattas.Beneficiary_Deletion_rofrtest((string)(Session["username"]), "1");
                    if (dt.Rows.Count > 0)
                    {
                        ddl_mandal.DataSource = dt;
                        ddl_mandal.DataTextField = "MANDAL";
                        ddl_mandal.DataValueField = "Mandal_Code";
                        ddl_mandal.DataBind();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(1, new ListItem("All", "All"));
                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Mandals Available!')", true);
                        ddl_mandal.Items.Clear();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));

                    }
                }
                else
                {
                    DataTable dt = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "Mandal", "", "", (string)Session["userprevilages"], "", "");
                    if (dt.Rows.Count > 0)
                    {
                        ddl_mandal.DataSource = dt;
                        ddl_mandal.DataTextField = "MANDAL";
                        ddl_mandal.DataValueField = "Mandal_Code";
                        ddl_mandal.DataBind();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(1, new ListItem("All", "All"));
                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Mandals Available!')", true);
                        ddl_mandal.Items.Clear();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));

                    }
                }
                
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void deletenolandBindMandal()
        {
            try
            {

                if((string)(Session["username"])=="ROFR_TEST"|| (string)(Session["username"])=="admin")
                {
                    DataTable dt = Landsettlementpattas.Beneficiary_Deletion_rofrtest((string)(Session["username"]), "7");
                    if (dt.Rows.Count > 0)
                    {
                        ddl_mandal.DataSource = dt;
                        ddl_mandal.DataTextField = "MANDAL";
                        ddl_mandal.DataValueField = "Mandal_Code";
                        ddl_mandal.DataBind();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(1, new ListItem("All", "All"));
                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Mandals Available with NoLand Records!')", true);
                        ddl_mandal.Items.Clear();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));

                    }
                }
                else
                {
                    DataTable dt = Landsettlementpattas.deletenoBeneficiary_Deletion((string)(Session["username"]), "Mandal", "", "", (string)Session["userprevilages"], "", "");
                    if (dt.Rows.Count > 0)
                    {
                        ddl_mandal.DataSource = dt;
                        ddl_mandal.DataTextField = "MANDAL";
                        ddl_mandal.DataValueField = "Mandal_Code";
                        ddl_mandal.DataBind();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(1, new ListItem("All", "All"));
                    }
                    else
                    {

                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Mandals Available with NoLand Records!')", true);
                        ddl_mandal.Items.Clear();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));

                    }
                }
               
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private void BindDELETNOLANDMandal()
        {
            try
            {
                if ((string)(Session["username"]) == "ROFR_TEST" || (string)(Session["username"]) == "admin")
                {
                    DataTable dt = Landsettlementpattas.Beneficiary_Deletion_rofrtest((string)(Session["username"]), "4");
                    if (dt.Rows.Count > 0)
                    {
                        ddl_mandal.DataSource = dt;
                        ddl_mandal.DataTextField = "MANDAL";
                        ddl_mandal.DataValueField = "Mandal_Code";
                        ddl_mandal.DataBind();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(1, new ListItem("All", "All"));
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Mandals Available with NoLand Records!')", true);
                        ddl_mandal.Items.Clear();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));

                    }
                }
                else
                {
                    DataTable dt = Landsettlementpattas.DELETELONADBeneficiary_Deletion((string)(Session["username"]), "Mandal", "", "", (string)Session["userprevilages"], "", "");
                    if (dt.Rows.Count > 0)
                    {
                        ddl_mandal.DataSource = dt;
                        ddl_mandal.DataTextField = "MANDAL";
                        ddl_mandal.DataValueField = "Mandal_Code";
                        ddl_mandal.DataBind();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_mandal.Items.Insert(1, new ListItem("All", "All"));
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Mandals Available with NoLand Records!')", true);
                        ddl_mandal.Items.Clear();
                        ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));

                    }
                }
                  
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void BindBen()
        {
            

            try
            {
                if((string)(Session["username"])=="ROFR_TEST"|| (string)(Session["username"]) == "admin")
                {
                    DataTable dt1 = Landsettlementpattas.Beneficiary_Deletion_rofrDisplay((string)(Session["username"]), "2", ddl_mandal.SelectedItem.Text);

                    if (dt1.Rows.Count > 0)
                    {
                        GridView2.Visible = true;
                        GridView2.DataSource = dt1;
                        GridView2.DataBind();
                        del_ben12.Visible = true;
                        //Session["Data"] = dt;

                    }
                    else
                    {
                        GridView2.Visible = false;
                        del_ben12.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    DataTable dt1 = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "Benificiary", "", "", (string)Session["userprevilages"], "", ddl_mandal.SelectedItem.Text);

                    if (dt1.Rows.Count > 0)
                    {
                        GridView2.Visible = true;
                        GridView2.DataSource = dt1;
                        GridView2.DataBind();
                        del_ben12.Visible = true;
                        //Session["Data"] = dt;

                    }
                    else
                    {
                        GridView2.Visible = false;
                        del_ben12.Visible = false;
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
        protected void Land_Click(object sender, EventArgs e)
        {
            GridView2.Visible = false;
            GridView4.Visible = false;
            TextBox2.Text = "";
            Session["DelData"] = "land";
            del_ben12.Visible = false;
            noadhar.Visible = false;
            div_dup.Visible = false;
            del_ben.Visible = false;
            del_land.Visible = true;
            del_noland.Visible = true;
            lnk_dupl.BackColor = System.Drawing.Color.White;
            lnk_dupl.ForeColor = System.Drawing.Color.Black;

            lnk_ben.BackColor = System.Drawing.Color.White;
            lnk_ben.ForeColor = System.Drawing.Color.Black;

            lnk_land.BackColor = System.Drawing.Color.Blue;
            lnk_land.ForeColor = System.Drawing.Color.White;

            lnk_noland.BackColor = System.Drawing.Color.White;
            lnk_noland.ForeColor = System.Drawing.Color.Black;
            BindDELETNOLANDMandal();
            // LandBen();
        }
        protected void LandBen()
        {
            DataTable dt = new DataTable();
            try
            {
                if ((string)(Session["username"]) == "ROFR_TEST" || (string)(Session["username"]) == "admin")
                {
                    dt = Landsettlementpattas.Beneficiary_Deletion_rofrDisplay((string)(Session["username"]), "5", ddl_mandal.SelectedItem.Text);
                    if (dt.Rows.Count > 0)
                    {
                        GridView3.Visible = true;
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        noadhar.Visible = true;

                        //Session["Data"] = dt;
                    }
                    else
                    {
                        GridView3.Visible = false;
                        noadhar.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    dt = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "Land", "", "", (string)Session["userprevilages"], "", ddl_mandal.SelectedItem.Text);


                    if (dt.Rows.Count > 0)
                    {
                        GridView3.Visible = true;
                        GridView3.DataSource = dt;
                        GridView3.DataBind();
                        noadhar.Visible = true;

                        //Session["Data"] = dt;
                    }
                    else
                    {
                        GridView3.Visible = false;
                        noadhar.Visible = false;
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

        protected void NoLand_Click(object sender, EventArgs e)
        {
            GridView3.Visible = false;
            GridView2.Visible = false;
            Session["DelData"] = "noland";
            div_dup.Visible = false;
            del_ben.Visible = false;
            del_land.Visible = false;
            del_noland.Visible = true;
            lnk_dupl.BackColor = System.Drawing.Color.White;
            lnk_dupl.ForeColor = System.Drawing.Color.Black;

            lnk_ben.BackColor = System.Drawing.Color.White;
            lnk_ben.ForeColor = System.Drawing.Color.Black;

            lnk_land.BackColor = System.Drawing.Color.White;
            lnk_land.ForeColor = System.Drawing.Color.Black;

            lnk_noland.BackColor = System.Drawing.Color.Blue;
            lnk_noland.ForeColor = System.Drawing.Color.White;
            deletenolandBindMandal();


        }
        protected void NL_Click(object sender, EventArgs e)
        {

            if (ddl_mandal.SelectedItem.Value.ToString() == "0")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Mandal Name !')", true);
                return;
            }

            string delvartpe = Session["DelData"].ToString();

            if (delvartpe == "noland")
            {
                NoLandBen();
            }
            if (delvartpe == "land")
            {
                LandBen();
            }
            if (delvartpe == "Beneficiary")
            {
                BindBen();
            }
        }
        protected void NoLandBen()
        {

            try
            {
                if((string)(Session["username"])=="ROFR_TEST"|| (string)(Session["username"])=="admin")
                {
                    DataTable dt = Landsettlementpattas.Beneficiary_Deletion_rofrDisplay((string)(Session["username"]), "8" , ddl_mandal.SelectedItem.Text);
                    if (dt.Rows.Count > 0)
                    {
                        GridView4.Visible = true;
                        GridView4.DataSource = dt;
                        GridView4.DataBind();

                        //Session["Data"] = dt;
                    }
                    else
                    {
                        GridView4.Visible = false;

                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    }
                }
                else
                {
                    DataTable dt = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "NoLand", "", "", (string)Session["userprevilages"], "", ddl_mandal.SelectedItem.Text);
                    if (dt.Rows.Count > 0)
                    {
                        GridView4.Visible = true;
                        GridView4.DataSource = dt;
                        GridView4.DataBind();

                        //Session["Data"] = dt;
                    }
                    else
                    {
                        GridView4.Visible = false;

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
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                foreach (GridViewRow item in GridView1.Rows)
                {


                    CheckBox btn = (CheckBox)item.FindControl("CheckBox1");
                    if (btn.Checked == true)
                    {
                        Label bid = item.FindControl("bid") as Label;
                        Label hab = item.FindControl("hab") as Label;
                        Label farmer = item.FindControl("farmer") as Label;
                        Label father = item.FindControl("fname") as Label;
                        Label subcaste = item.FindControl("subcaste") as Label;
                        Label adhar = item.FindControl("Aadhaar") as Label;
                        txt_bid.Text = bid.Text;
                        txt_hab.Text = hab.Text;
                        txt_farmer.Text = farmer.Text;
                        txt_fname.Text = father.Text;
                        txt_subcaste.Text = subcaste.Text;
                        txt_adhar.Text = adhar.Text;

                        string script = "window.onload = function() { openModal(); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "openModal", script, true);

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                foreach (GridViewRow item in GridView3.Rows)
                {


                    CheckBox btn = (CheckBox)item.FindControl("CheckBox3");
                    if (btn.Checked == true)
                    {
                        Label id = item.FindControl("id") as Label;
                        Label bid = item.FindControl("bid") as Label;
                        //Label hab = item.FindControl("hab") as Label;
                        Label farmer = item.FindControl("farmer") as Label;
                        //Label father = item.FindControl("fname") as Label;
                        //Label subcaste = item.FindControl("subcaste") as Label;
                        //Label adhar = item.FindControl("Aadhaar") as Label;




                        txt_id.Text = id.Text;
                        txt_fid.Text = bid.Text;
                        //txt_hab.Text = hab.Text;
                        txt_fn.Text = farmer.Text;
                        //txt_fname.Text = father.Text;
                        //txt_subcaste.Text = subcaste.Text;
                        //txt_adhar.Text = adhar.Text;

                        string script = "window.onload = function() { openland(); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "openland", script, true);

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                //DataTable gridview2dt = new DataTable();
                AntiForgery.Validate();
                //gridview2dt.Columns.AddRange(new DataColumn[2] { new DataColumn("BeneficiaryId"), new DataColumn("FarmerName") });
                foreach (GridViewRow item in GridView2.Rows)
                {
                    CheckBox btn = (CheckBox)item.FindControl("CheckBox2");
                    if (btn.Checked == true)
                    {
                        Label bid = item.FindControl("bid") as Label;
                        Label farmer = item.FindControl("farmer") as Label;
                        txt_ben_id.Text = bid.Text;
                        txt_fmr.Text = farmer.Text;
                        string script = "window.onload = function() { openBen(); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "openBen", script, true);

                    }

                }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                foreach (GridViewRow item in GridView4.Rows)
                {
                    CheckBox btn = (CheckBox)item.FindControl("CheckBox4");
                    if (btn.Checked == true)
                    {
                        Label bid = item.FindControl("bid") as Label;
                        //Label hab = item.FindControl("hab") as Label;
                        Label farmer = item.FindControl("farmer") as Label;
                        //Label father = item.FindControl("fname") as Label;
                        //Label subcaste = item.FindControl("subcaste") as Label;
                        //Label adhar = item.FindControl("Aadhaar") as Label;
                        txt_nid.Text = bid.Text;
                        //txt_hab.Text = hab.Text;
                        txt_fnm.Text = farmer.Text;
                        //txt_fname.Text = father.Text;
                        //txt_subcaste.Text = subcaste.Text;
                        //txt_adhar.Text = adhar.Text;

                        string script = "window.onload = function() { opennoland(); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "opennoland", script, true);

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void btn_click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                string script = "window.onload = function() { openModal(); };";
                ClientScript.RegisterStartupScript(this.GetType(), "openModal", script, true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void mbtn_click(object sender, EventArgs e)
        {
            Labeldup.Text = txt_bid.Text;
            string script = "window.onload = function() { opendupyesland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "opendupyesland", script, true);
        }

        //protected void benyorn_click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string script = "window.onload = function() { Benyorn(); };";
        //        ClientScript.RegisterStartupScript(this.GetType(), "Benyorn", script, true);

        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}
        
        protected void benbtn_click(object sender, EventArgs e)
        {
            lblyesid.Text = txt_ben_id.Text;
            string script = "window.onload = function() { openyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openyesnoBen", script, true);
        }
        protected void landbtn_click(object sender, EventArgs e)
        {
            Label17.Text = txt_id.Text;
            string script = "window.onload = function() { lanopenyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "lanopenyesnoBen", script, true);
        }
        protected void nolandbtn_click(object sender, EventArgs e)
        {
            Label20.Text = txt_nid.Text;
            string script = "window.onload = function() { opennoyesland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "opennoyesland", script, true);
        }

        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        protected void Close_Click(object sender, ImageClickEventArgs e)
        {
            AntiForgery.Validate();
            foreach (GridViewRow item in GridView1.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox1");



                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }


        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //DataTable dtbeneficiareies = new DataTable();
                //dtbeneficiareies = Landsettlementpattas.Beneficiary_Deletion_Form_Getdata((string)(Session["username"]), "Details", ddl_ITda.SelectedValue, ddl_district.SelectedItem.Text, (string)Session["userprevilages"], ddl_ITda.SelectedItem.Text);

                //if (dtbeneficiareies.Rows.Count > 0)
                //{
                //    DataView DV = dtbeneficiareies.AsDataView();
                //    DV.RowFilter = string.Format("AADHAAR_NO LIKE '%{0}%' ", txtSearch.Text);

                //    GridView1.DataSource = DV;
                //    GridView1.DataBind();
                //}
                GridView1.Visible = false;
                if (ddl_district.SelectedItem.Text != "Select")
                {


                    if (txtSearch.Text.ToString() != "")
                    {
                        BindGrid();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Enter Aadhar No')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Select District.. ')", true);
                    GridView1.Visible = false;

                }


            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindBen();
        }
        protected void Searchid_Click(object sender, EventArgs e)
        {
            string txtbx = TextBox1.Text;
            if (TextBox1.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Aadhar number !')", true);
                return;
            }
            else if(txtbx.Length < 12 || txtbx.Length>12)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Valid Aadhar number !')", true);
                return;
            }

            else
            {

                try
                {
                    DataTable dt1 = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "Benificiary", "", "", (string)Session["userprevilages"], "", ddl_mandal.SelectedItem.Text);

                    DataTable table = new DataTable();

                    if (dt1.Rows.Count > 0)
                    {
                       
                        foreach (DataRow row in dt1.Rows)
                        {
                            string aadhar1 = row["AADHAAR_NO1"].ToString();
                            if (TextBox1.Text == aadhar1)
                            {

                                if (table.Rows.Count == 0)
                                {
                                    table.Columns.Add("benficiary_id", typeof(UInt64));
                                    table.Columns.Add("ITDA_NAME", typeof(string));
                                    table.Columns.Add("DISTRICT", typeof(string));
                                    table.Columns.Add("Mandal", typeof(string));
                                    table.Columns.Add("Village", typeof(string));
                                    table.Columns.Add("Habitation", typeof(string));
                                    table.Columns.Add("ROFR_PATTADAAR", typeof(string));
                                    table.Columns.Add("Father_Name", typeof(string));
                                    table.Columns.Add("AADHAAR_NO", typeof(string));
                                    table.Columns.Add("Sub_Caste", typeof(string));
                                    table.Columns.Add("BankAccountNo", typeof(string));
                                    table.Columns.Add("IfscCode", typeof(string));
                                    table.Columns.Add("BankName", typeof(string));
                                    table.Rows.Add(row["benficiary_id"], row["ITDA_NAME"], row["DISTRICT"], row["Mandal"],
                                    row["Village"],row["Habitation"], row["ROFR_PATTADAAR"], row["Father_Name"],
                                    row["AADHAAR_NO"],row["Sub_Caste"], row["BankAccountNo"], row["IfscCode"], row["BankName"]);
                                }
                                else
                                {
                                table.Rows.Add(row["benficiary_id"], row["ITDA_NAME"], row["DISTRICT"], row["Mandal"],
                                row["Village"],row["Habitation"], row["ROFR_PATTADAAR"], row["Father_Name"], row["AADHAAR_NO"],
                                row["Sub_Caste"], row["BankAccountNo"], row["IfscCode"], row["BankName"]);

                                }
                                }
                            
                            else
                            {
                            }
                        }
                        if (table.Rows.Count > 0)
                        {
                            GridView2.Visible = true;
                            del_ben12.Visible = true;
                            GridView2.DataSource = table;
                            GridView2.DataBind();
                        }
                        else {
                             GridView2.Visible = false;
                             del_ben12.Visible = false;
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
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            AntiForgery.Validate();
            foreach (GridViewRow item in GridView2.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox2");



                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            AntiForgery.Validate();
            foreach (GridViewRow item in GridView3.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox3");



                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            AntiForgery.Validate();
            foreach (GridViewRow item in GridView4.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox4");



                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }

        protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView4.PageIndex = e.NewPageIndex;
            NoLandBen();


        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            LandBen();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itdid = (GridView2.SelectedRow.FindControl("bid") as Label).Text;
            string Farmername = (GridView2.SelectedRow.FindControl("farmer") as Label).Text;
            txt_ben_id.Text = itdid.ToString();
            txt_fmr.Text = Farmername.ToString();
            string script = "window.onload = function() { openBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openBen", script, true);
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();


                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                addbeneficiaryobj.id = txt_ben_id.Text;
                addbeneficiaryobj.Aadhaar_NO = txt_ben_reason.Text;




                addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                addbeneficiaryobj.UserName = (string)(Session["username"]);

                if((string)(Session["username"])=="ROFR_TEST"|| (string)(Session["username"])=="admin")
                {
                    if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                    {
                        if (!string.IsNullOrEmpty(txt_ben_id.Text))
                        {
                            if (txt_ben_reason.Text != "" && txt_ben_reason.Text != null)
                            {

                                DataTable dt = Landsettlementpattas.Beneficiary_Deletion_rofrtestsubmit((string)(Session["username"]), addbeneficiaryobj.Aadhaar_NO, addbeneficiaryobj.id, "3","");



                                if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficary Details Deleted Successfully !')", true);
                                    BindBen();
                                    TextBox1.Text = "";
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deletion Failed !')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter reason !')", true);
                            }

                            //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                            //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                          
                        }
                        else
                        {
                            foreach (GridViewRow item in GridView2.Rows)
                            {
                                CheckBox btn = (CheckBox)item.FindControl("CheckBox2");

                                //LinkButton btn = (LinkButton)(sender);

                                if (btn.Checked == true)
                                {
                                    btn.Checked = false;
                                }
                            }

                        }


                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                    {
                        if (!string.IsNullOrEmpty(txt_ben_id.Text))
                        {
                            if (txt_ben_reason.Text != "" && txt_ben_reason.Text != null)
                            {

                                DataTable dt = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "Ben_del", "", "", (string)Session["userprevilages"], addbeneficiaryobj.id, addbeneficiaryobj.Aadhaar_NO);



                                if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Beneficary Details Deleted Successfully !')", true);
                                    BindBen();
                                    TextBox1.Text = "";
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deletion Failed !')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter reason !')", true);
                            }

                            //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                            //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                            BindBen();
                        }
                        else
                        {
                            foreach (GridViewRow item in GridView2.Rows)
                            {
                                CheckBox btn = (CheckBox)item.FindControl("CheckBox2");

                                //LinkButton btn = (LinkButton)(sender);

                                if (btn.Checked == true)
                                {
                                    btn.Checked = false;
                                }
                            }

                        }


                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                }


                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void no_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { openyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openyesnoBen", script, false);

            string script1 = "window.onload = function() { openBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openBen", script1, false);

            AntiForgery.Validate();
            foreach (GridViewRow item in GridView2.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox2");
                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {

            string script = "window.onload = function() { openyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openyesnoBen", script, false);

            string script1 = "window.onload = function() { openBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openBen", script1, true);
        }

        protected void Butn1_Click(object sender, EventArgs e)
        {

            try
            {
                AntiForgery.Validate();


                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                addbeneficiaryobj.id = txt_bid.Text;
                addbeneficiaryobj.Aadhaar_NO = txt_adhar.Text;

                if (txt_fname.Text != "" && txt_fname.Text != null)
                {
                    addbeneficiaryobj.fathername = txt_fname.Text;
                }
                else
                {
                    addbeneficiaryobj.fathername = null;
                }
                if (txt_subcaste.Text != "" && txt_subcaste.Text != null)
                {
                    addbeneficiaryobj.sub_caste = txt_subcaste.Text;
                }
                else
                {
                    addbeneficiaryobj.sub_caste = null;
                }



                addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                addbeneficiaryobj.UserName = (string)(Session["username"]);


                if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                {
                    if (!string.IsNullOrEmpty(txt_bid.Text))
                    {
                        if (txt_reason.Text != "" && txt_reason.Text != null)
                        {


                            DataTable dt = Landsettlementpattas.Beneficiary_Deletion_Form_Deletedata(addbeneficiaryobj, (string)(Session["username"]), txt_reason.Text);
                            if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Duplication Farmer Details Deleted Successfully !')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deletion Failed !')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter reason !')", true);
                        }

                        //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                        //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                        BindGrid();
                    }
                    else
                    {
                        foreach (GridViewRow item in GridView1.Rows)
                        {
                            CheckBox btn = (CheckBox)item.FindControl("CheckBox1");

                            //LinkButton btn = (LinkButton)(sender);

                            if (btn.Checked == true)
                            {
                                btn.Checked = false;
                            }
                        }

                    }


                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void Butn2_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { dupopenyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "dupopenyesnoBen", script, false);

            string script1 = "window.onload = function() { openModal(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openModal", script1, false);

            AntiForgery.Validate();
            foreach (GridViewRow item in GridView1.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox1");
                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }




        protected void ImageButton25_Click(object sender, ImageClickEventArgs e)
        {
            string script = "window.onload = function() { dupopenyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "dupopenyesnoBen", script, false);

            string script1 = "window.onload = function() { openModal(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openModal", script1, true);
        }






        protected void delland_Click(object sender, ImageClickEventArgs e)
        {
            string script = "window.onload = function() { lanopenyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "lanopenyesnoBen", script, false);

            string script1 = "window.onload = function() { openland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openland", script1, true);
        }

        protected void nolandbtn_Click1(object sender, ImageClickEventArgs e)
        {
           
        }

       
        protected void Button2_Click(object sender, EventArgs e)
        {
            string txtbx = TextBox2.Text;

            if (TextBox2.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Aadhar number !')", true);
                return;
            }

            else if (txtbx.Length<12|| txtbx.Length>12)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter valid Aadhar number !')", true);
                return;
            }
            else
            {

                DataTable dt = new DataTable();
                try
                {
                    dt = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "Land", "", "", (string)Session["userprevilages"], "", ddl_mandal.SelectedItem.Text);

                    DataTable table = new DataTable();

                    foreach (DataRow row in dt.Rows)
                    {
                        if (TextBox2.Text == row["AADHAAR_NO2"].ToString())
                        {
                            if (table.Rows.Count == 0)
                            {
                                table.Columns.Add("ID", typeof(UInt64));
                                table.Columns.Add("benficiary_id2", typeof(UInt64));
                                table.Columns.Add("ITDA_NAME", typeof(string));
                                table.Columns.Add("DISTRICT", typeof(string));
                                table.Columns.Add("Mandal", typeof(string));
                                table.Columns.Add("Village", typeof(string));
                                table.Columns.Add("Habitation", typeof(string));
                                table.Columns.Add("ROFR_PATTADAAR", typeof(string));
                                table.Columns.Add("Father_Name", typeof(string));
                                table.Columns.Add("AADHAAR_NO", typeof(string));
                                table.Columns.Add("Compartment_No", typeof(string));
                                table.Columns.Add("ROFR_PATTANO", typeof(string));
                                table.Columns.Add("ExtentPlotArea", typeof(string));
                                table.Rows.Add(row["ID"], row["benficiary_id2"], row["ITDA_NAME"], row["DISTRICT"], row["Mandal"], row["Village"],
                                row["Habitation"], row["ROFR_PATTADAAR"], row["Father_Name"], row["AADHAAR_NO"],
                                row["Compartment_No"], row["ROFR_PATTANO"], row["ExtentPlotArea"]);

                            }
                            else {
                                table.Rows.Add(row["ID"], row["benficiary_id2"], row["ITDA_NAME"], row["DISTRICT"], row["Mandal"], row["Village"],
                            row["Habitation"], row["ROFR_PATTADAAR"], row["Father_Name"], row["AADHAAR_NO"],
                            row["Compartment_No"], row["ROFR_PATTANO"], row["ExtentPlotArea"]);

                            }
                            // return;
                        }
                        else
                        {
                            //GridView3.Visible = false;
                            //noadhar.Visible = false;
                            //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        }
                    }
                    if (table.Rows.Count > 0)
                    {
                        GridView3.Visible = true;
                        GridView3.DataSource = table;
                        noadhar.Visible = true;
                        GridView3.DataBind();
                        return;
                    }
                    else {
                        GridView3.Visible = false;
                        noadhar.Visible = false;
                        return;
                    }
                }

                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                    ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
                }

            }
        }

        protected void landyes_Click1(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();


                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                addbeneficiaryobj.id = txt_id.Text;
                addbeneficiaryobj.Benificiary_id = txt_fid.Text;


                addbeneficiaryobj.Aadhaar_NO = txt_land_reason.Text;




                addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                addbeneficiaryobj.UserName = (string)(Session["username"]);

                if((string)(Session["username"])=="ROFR_TEST"|| (string)(Session["username"])=="admin")
                {
                    if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                    {
                        if (!string.IsNullOrEmpty(txt_id.Text))
                        {
                            if (txt_land_reason.Text != "" && txt_land_reason.Text != null)
                            {

                                DataTable dt = Landsettlementpattas.Beneficiary_Deletion_rofrtestsubmit((string)(Session["username"]), addbeneficiaryobj.Aadhaar_NO, addbeneficiaryobj.Benificiary_id, "6", addbeneficiaryobj.id);


                                if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                                {
                                    string s = dt.Rows[0]["STATUS"].ToString();
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Farmer Land Details Deleted Successfully !')", true);
                                    LandBen();
                                    TextBox2.Text = "";
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deletion Failed !')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter reason !')", true);
                            }

                            //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                            //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                            LandBen();
                        }
                        else
                        {
                            foreach (GridViewRow item in GridView3.Rows)
                            {
                                CheckBox btn = (CheckBox)item.FindControl("CheckBox3");

                                //LinkButton btn = (LinkButton)(sender);

                                if (btn.Checked == true)
                                {
                                    btn.Checked = false;
                                }
                            }

                        }


                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                    {
                        if (!string.IsNullOrEmpty(txt_id.Text))
                        {
                            if (txt_land_reason.Text != "" && txt_land_reason.Text != null)
                            {

                                DataTable dt = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "Land_del", addbeneficiaryobj.id, "", (string)Session["userprevilages"], addbeneficiaryobj.Benificiary_id, addbeneficiaryobj.Aadhaar_NO);


                                if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Farmer Land Details Deleted Successfully !')", true);
                                    LandBen();
                                    TextBox2.Text = "";
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deletion Failed !')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter reason !')", true);
                            }

                            //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                            //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                            
                        }
                        else
                        {
                            foreach (GridViewRow item in GridView3.Rows)
                            {
                                CheckBox btn = (CheckBox)item.FindControl("CheckBox3");

                                //LinkButton btn = (LinkButton)(sender);

                                if (btn.Checked == true)
                                {
                                    btn.Checked = false;
                                }
                            }

                        }


                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                }
                

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void landno_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { lanopenyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "lanopenyesnoBen", script, false);

            string script1 = "window.onload = function() { openland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openland", script1, false);

            AntiForgery.Validate();
            foreach (GridViewRow item in GridView3.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox3");
                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }

        }

        protected void landclose_Click(object sender, ImageClickEventArgs e)
        {

            string script = "window.onload = function() { lanopenyesnoBen(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "lanopenyesnoBen", script, false);

            string script1 = "window.onload = function() { openland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openland", script1, true);
        }

        protected void nolandyesbtn_Click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();


                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                addbeneficiaryobj.id = txt_nid.Text;
                addbeneficiaryobj.Aadhaar_NO = txt_noland_reason.Text;
                addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                addbeneficiaryobj.UserName = (string)(Session["username"]);

                if((string)(Session["username"])=="ROFR_TEST"|| (string)(Session["username"])=="admin")
                {
                    if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                    {
                        if (!string.IsNullOrEmpty(txt_nid.Text))
                        {
                            if (txt_noland_reason.Text != "" && txt_noland_reason.Text != null)
                            {

                                DataTable dt = Landsettlementpattas.Beneficiary_Deletion_rofrtestsubmit((string)(Session["username"]), addbeneficiaryobj.Aadhaar_NO, addbeneficiaryobj.id, "9","");


                                if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' NoLand Farmer Details Deleted Successfully !')", true);
                                    NoLandBen();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deletion Failed !')", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter reason !')", true);
                            }

                            //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                            //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                            NoLandBen();
                        }
                        else
                        {
                            foreach (GridViewRow item in GridView4.Rows)
                            {
                                CheckBox btn = (CheckBox)item.FindControl("CheckBox4");

                                //LinkButton btn = (LinkButton)(sender);

                                if (btn.Checked == true)
                                {
                                    btn.Checked = false;
                                }
                            }

                        }


                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                    {
                        if (!string.IsNullOrEmpty(txt_nid.Text))
                        {
                            if (txt_noland_reason.Text != "" && txt_noland_reason.Text != null)
                            {

                                DataTable dt = Landsettlementpattas.Beneficiary_Deletion((string)(Session["username"]), "NoLand_del", "", "", (string)Session["userprevilages"], addbeneficiaryobj.id, addbeneficiaryobj.Aadhaar_NO);


                                if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' NoLand Farmer Details Deleted Successfully !')", true);
                                    NoLandBen();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deletion Failed !')", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter reason !')", true);
                            }

                            //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                            //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                            
                        }
                        else
                        {
                            foreach (GridViewRow item in GridView4.Rows)
                            {
                                CheckBox btn = (CheckBox)item.FindControl("CheckBox4");

                                //LinkButton btn = (LinkButton)(sender);

                                if (btn.Checked == true)
                                {
                                    btn.Checked = false;
                                }
                            }

                        }


                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        protected void nolandnobutn_Click(object sender, EventArgs e)
        {

            string script = "window.onload = function() { opennoyesland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "opennoyesland", script, false);

            string script1 = "window.onload = function() { opennoland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "opennoland", script1, false);

            AntiForgery.Validate();
            foreach (GridViewRow item in GridView4.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox4");
                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }
        }

        protected void nolandclose_Click(object sender, ImageClickEventArgs e)
        {
            string script = "window.onload = function() { opennoyesland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "opennoyesland", script, false);

            string script1 = "window.onload = function() { opennoland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "opennoland", script1, true);
        }

        protected void deldup_Click(object sender, ImageClickEventArgs e)
        {
            string script = "window.onload = function() { opendupyesland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "opendupyesland", script, false);

            string script1 = "window.onload = function() { openModal(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openModal", script1, true);
        }

        protected void dupdelyes_Click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();


                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                addbeneficiaryobj.id = txt_bid.Text;
                addbeneficiaryobj.Aadhaar_NO = txt_adhar.Text;

                if (txt_fname.Text != "" && txt_fname.Text != null)
                {
                    addbeneficiaryobj.fathername = txt_fname.Text;
                }
                else
                {
                    addbeneficiaryobj.fathername = null;
                }
                if (txt_subcaste.Text != "" && txt_subcaste.Text != null)
                {
                    addbeneficiaryobj.sub_caste = txt_subcaste.Text;
                }
                else
                {
                    addbeneficiaryobj.sub_caste = null;
                }



                addbeneficiaryobj.Ipaddress = (string)(Session["IPAddress"]);
                addbeneficiaryobj.UserName = (string)(Session["username"]);


                if (!string.IsNullOrEmpty(addbeneficiaryobj.UserName))
                {
                    if (!string.IsNullOrEmpty(txt_bid.Text))
                    {
                        if (txt_reason.Text != "" && txt_reason.Text != null)
                        {


                            DataTable dt = Landsettlementpattas.Beneficiary_Deletion_Form_Deletedata(addbeneficiaryobj, (string)(Session["username"]), txt_reason.Text);
                            if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Duplication Farmer Details Deleted Successfully !')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Deletion Failed !')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please enter reason !')", true);
                        }

                        //string scpt = "window.onload = function() { alert('Farmer Details Updated Successfully'); };";
                        //ClientScript.RegisterStartupScript( this.GetType(), "alertmessage", scpt, true);
                        BindGrid();
                    }
                    else
                    {
                        foreach (GridViewRow item in GridView1.Rows)
                        {
                            CheckBox btn = (CheckBox)item.FindControl("CheckBox1");

                            //LinkButton btn = (LinkButton)(sender);

                            if (btn.Checked == true)
                            {
                                btn.Checked = false;
                            }
                        }

                    }


                }

                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void dupdelno_Click(object sender, EventArgs e)
        {
            string script = "window.onload = function() { opendupyesland(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "opendupyesland", script, false);

            string script1 = "window.onload = function() { openModal(); };";
            ClientScript.RegisterStartupScript(this.GetType(), "openModal", script1, false);

            AntiForgery.Validate();
            foreach (GridViewRow item in GridView1.Rows)
            {
                CheckBox btn = (CheckBox)item.FindControl("CheckBox1");
                if (btn.Checked == true)
                {
                    btn.Checked = false;
                }
            }

        }
        

        protected void ddl_mandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            TextBox1.Text = "";
            del_ben12.Visible = false;
            noadhar.Visible = false;
            GridView3.Visible = false;
            GridView2.Visible = false;
        }
        //protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //    if (e.CommandName == "Delete")
        //    {
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = GridView2.Rows[rowIndex];
        //        string itdid = (row.FindControl("bid") as Label).Text;
        //        string Farmername = (row.FindControl("farmer") as Label).Text;
        //        txt_ben_id.Text = itdid.ToString();
        //        txt_fmr.Text = Farmername.ToString();
        //        string script = "window.onload = function() { openBen(); };";
        //        ClientScript.RegisterStartupScript(this.GetType(), "openBen", script, true);


        //    }

        //}
        //    //protected void deleteben_Click(object sender, EventArgs e)
        //{
        //    List<string> grid2List = new List<string>();
        //    int grid2count = gvSelected.Rows.Count;

        //    if (grid2count < 0 || grid2count == 0)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        foreach (GridViewRow item in gvSelected.Rows)
        //        {

        //            Label bid = item.FindControl("bensid") as Label;
        //            grid2List.Add(bid.Text);
        //        }

        //    }
        //    string fruits = string.Join(",", grid2List);
        //    string script = "window.onload = function() { openBen(); };";
        //    ClientScript.RegisterStartupScript(this.GetType(), "openBen", script, true);
        //}





        //protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string itdid = (GridView2.SelectedRow.FindControl("bid") as Label).Text;
        //    string Farmername = (GridView2.SelectedRow.FindControl("farmer") as Label).Text;
        //    txt_ben_id.Text = itdid.ToString();
        //    txt_fmr.Text = Farmername.ToString();
        //    ClientScript.RegisterStartupScript(this.GetType(), "openBen", "openBen", true);
        //}

    }
}
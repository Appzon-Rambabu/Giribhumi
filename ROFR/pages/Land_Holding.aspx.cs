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
using System.Configuration;
namespace ROFR.pages
{
    public partial class Land_Holding : System.Web.UI.Page
    {
        HealthConnection hc = new HealthConnection();
        addbeneficiary_details obj = new addbeneficiary_details();
        DataSet rdt = new DataSet();
        DataTable rd = new DataTable();
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_district.Items.Insert(0, new ListItem("Select", "0"));
            ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
            ddl_village.Items.Insert(0, new ListItem("Select", "0"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    System.Threading.Thread.Sleep(5000);
                    BindItda();
                    ddl_district.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_status.Items.FindByValue("NOLAND").Selected = true;
                   // BindGrid();
                    rpt1.Visible = false;
                    rpt2.Visible = false;
                    // ddl_status.Items.Insert(0, new ListItem("Select", "0"));
                    btn_excel.Visible = false;


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


                obj.Type = "1";
                DataTable dtItda = hc.RB_STATUS_SP(obj);

                if (dtItda.Rows.Count > 0)
                {
                    System.Threading.Thread.Sleep(5000);
                    ddl_ITda.DataSource = dtItda;
                    ddl_ITda.DataTextField = "ITDA";
                    ddl_ITda.DataValueField = "ITDA";
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
                ddl_district.DataTextField = "DIST_NAME_EN";
                ddl_district.DataValueField = "DIST_NAME_EN";
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
                ddl_mandal.DataTextField = "OFFICE_NAME_EN";
                ddl_mandal.DataValueField = "OFFICE_NAME_EN";
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
                ddl_village.DataTextField = "SECRETARIAT_NAME";
                ddl_village.DataValueField = "SECRETARIAT_NAME";
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
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                GridView1.Visible = true;
                rpt1.Visible = false;
                rpt2.Visible = false;
                btn_excel.Visible = false;
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    ddl_district.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();

                    obj.Type = "2";
                    obj.Itda = ddl_ITda.SelectedItem.Text;
                    DataTable dtdistrict = hc.RB_STATUS_SP(obj);


                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        BindGrid();
                        //if (dtdistrict.Rows.Count <= 1)
                        //{
                        //    ddl_district.SelectedIndex = 1;
                        //    obj.Type = "3";
                        //    obj.Itda = ddl_ITda.SelectedItem.Text;
                        //    obj.District = ddl_district.SelectedItem.Text;
                        //    DataTable dtMandal = hc.RB_STATUS_SP(obj);

                        //    if (dtMandal.Rows.Count > 0)
                        //    {
                        //        BindMandal(dtMandal);
                        //    }
                        //    else
                        //    {
                        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                        //    }
                        //}
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
                System.Threading.Thread.Sleep(5000);
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                GridView1.Visible = true;
                rpt1.Visible = false;
                rpt2.Visible = false;
                btn_excel.Visible = false;
                if (ddl_district.SelectedItem.Text != "Select")
                {

                    obj.Type = "3";
                    obj.Itda = ddl_ITda.SelectedItem.Text;
                    obj.District = ddl_district.SelectedItem.Text;
                    DataTable dtMandal = hc.RB_STATUS_SP(obj);
                    if (dtMandal.Rows.Count > 0)
                    {
                        BindMandal(dtMandal);
                        BindGrid();
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
                System.Threading.Thread.Sleep(5000);
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                GridView1.Visible = true;
                rpt1.Visible = false;
                rpt2.Visible = false;
                btn_excel.Visible = false;
                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    obj.Type = "4";
                    obj.Itda = ddl_ITda.SelectedItem.Text;
                    obj.District = ddl_district.SelectedItem.Text;
                    obj.Mandal = ddl_mandal.SelectedItem.Text;
                    DataTable dtVillages = hc.RB_STATUS_SP(obj);


                    if (dtVillages.Rows.Count > 0)
                    {
                        BindVillage(dtVillages);
                        BindGrid();
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
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = true;
                btn_excel.Visible = true;
                if (ddl_village.SelectedItem.Text != "Select")


                {

                    BindGrid();
                    if (ddl_status.SelectedValue == "NOLAND" || ddl_status.SelectedValue == "LESSTHAN1 ACRE" || ddl_status.SelectedValue == "LESSTHAN" || ddl_status.SelectedValue == "SUBMERGED")
                    {
                        rpt1.Visible = true;
                        rpt2.Visible = false;


                        // BindLand();
                        rpt1.DataSource = this.GetMergedData(this.GetData());
                        rpt1.DataBind();
                        foreach (RepeaterItem item in rpt1.Items)
                        {
                            Label cmt = (Label)item.FindControl("lbl_cmts");
                            LinkButton lbtn = (LinkButton)item.FindControl("LinkButton2");

                            if (cmt.Text == "" || cmt.Text == null)
                            {
                                lbtn.Enabled = true;
                            }
                            else
                            {
                                lbtn.Enabled = false;
                                lbtn.Text = "Updated";
                                lbtn.ForeColor = System.Drawing.Color.Green;
                                lbtn.BackColor = System.Drawing.Color.LightGray;


                            }
                        }
                    }
                    else
                    {
                        rpt1.Visible = false;
                        rpt2.Visible = true;


                        // BindLand();
                        rpt2.DataSource = this.GetMergedData(this.GetData());
                        rpt2.DataBind();
                    }
                }
                else
                {



                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void ddlstatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = true;
                btn_excel.Visible = true;
                if (ddl_status.SelectedItem.Text != "Select")
                {
                    if (ddl_status.SelectedValue == "NOLAND" || ddl_status.SelectedValue == "LESSTHAN1 ACRE" || ddl_status.SelectedValue == "LESSTHAN" || ddl_status.SelectedValue == "SUBMERGED")
                    {
                        rpt1.Visible = true;
                        rpt2.Visible = false;


                        // BindLand();
                        rpt1.DataSource = this.GetMergedData(this.GetData());
                        rpt1.DataBind();
                        foreach (RepeaterItem item in rpt1.Items)
                        {
                            Label cmt = (Label)item.FindControl("lbl_cmts");
                            LinkButton lbtn = (LinkButton)item.FindControl("LinkButton2");

                            if (cmt.Text == "" || cmt.Text == null)
                            {
                                lbtn.Enabled = true;
                            }
                            else
                            {
                                lbtn.Enabled = false;
                                lbtn.Text = "Updated";
                                lbtn.ForeColor = System.Drawing.Color.Green;
                                lbtn.BackColor = System.Drawing.Color.LightGray;


                            }
                        }
                    }
                    else
                    {
                        rpt1.Visible = false;
                        rpt2.Visible = true;


                        // BindLand();
                        rpt2.DataSource = this.GetMergedData(this.GetData());
                        rpt2.DataBind();
                    }
                }
                else
                {



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


                System.Threading.Thread.Sleep(5000);
                obj.Type = "3.2LACS REPORT";
                if (ddl_ITda.SelectedValue != "0")
                {
                    obj.Itda = ddl_ITda.SelectedItem.Text;
                    if (ddl_district.SelectedValue != "0")
                    {
                        obj.District = ddl_district.SelectedItem.Text;
                        if (ddl_mandal.SelectedValue != "0")
                        {
                            obj.Mandal = ddl_mandal.SelectedItem.Text;
                            if (ddl_village.SelectedValue != "0")
                            {
                                obj.Village = ddl_village.SelectedItem.Text;
                            }
                        }
                    }


                }
                DataTable dt = hc.RB_STATUS_SP(obj);
                Session["Gdata"] = dt;
                if (dt.Rows.Count > 0)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

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

        protected void BindLand()
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                obj.Type = "5";
                obj.Itda = ddl_ITda.SelectedItem.Text;
                obj.District = ddl_district.SelectedItem.Text;
                obj.Mandal = ddl_mandal.SelectedItem.Text;
                obj.Village = ddl_village.SelectedItem.Text;
                obj.REMARKS = ddl_status.SelectedItem.Text;
                DataTable dt = hc.RB_STATUS_SP(obj);
                if (dt.Rows.Count > 0)
                {
                    //GridView2.Visible = true;
                    //GridView2.DataSource = dt;
                    //GridView2.DataBind();

                }
                else
                {
                    //GridView2.Visible = false;

                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        private List<Product> GetMergedData(List<Product> allProducts)
        {
            System.Threading.Thread.Sleep(5000);
            List<Product> mergedProducts = new List<Product>();

            var groupingsByName =
                allProducts
                .GroupBy(product => product.EXISTING_RC_NUMBER);

            foreach (var groupingByName in groupingsByName)
            {
                Product firstProduct = groupingByName.First();
                firstProduct.CountOfProductsWithThisItemName = groupingByName.Count();
                firstProduct.IsFirstRowWithThisItemName = true;
                mergedProducts.Add(firstProduct);

                mergedProducts.AddRange(groupingByName.Skip(1));
            }

            return mergedProducts;
        }

        private List<Product> GetData()
        {
            System.Threading.Thread.Sleep(5000);
            obj.Type = "5";
            obj.Itda = ddl_ITda.SelectedItem.Text;
            obj.District = ddl_district.SelectedItem.Text;
            obj.Mandal = ddl_mandal.SelectedItem.Text;
            obj.Village = ddl_village.SelectedItem.Text;
            obj.REMARKS = ddl_status.SelectedValue;
            DataTable dt = hc.RB_STATUS_SP(obj);
            Session["Data"] = dt;

            //new Product("Orange", DateTime.Parse("01/01/2015"), 50),
            //new Product("Orange", DateTime.Parse("02/01/2015"), 51),
            //new Product("Orange", DateTime.Parse("03/01/2015"), 55),
            //new Product("Apple", DateTime.Parse("01/01/2015"), 95),
            //new Product("Apple", DateTime.Parse("03/01/2015"), 98),
            //new Product("Banana", DateTime.Parse("01/01/2015"), 48),
            //   var prd = new List<Product>();

            List<Product> data = new List<Product>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows.Count > 0)

                {

                    if (ddl_status.SelectedValue == "NOLAND" || ddl_status.SelectedValue == "LESSTHAN1 ACRE" || ddl_status.SelectedValue == "LESSTHAN" || ddl_status.SelectedValue == "SUBMERGED")
                    {
                        Product p = new Product();
                        //new Product(dt.Rows[i]["EXISTING_RC_NUMBER"].ToString(), dt.Rows[i]["UID_NO"].ToString(), dt.Rows[i]["MEMBER_NAME_EN"].ToString(), dt.Rows[i]["WEBLAND_SURVEYNO_DYNAMIC"].ToString(), dt.Rows[i]["FINAL_WEBLAND_EXTENT"].ToString(), dt.Rows[i]["ROFR_SURVEYNO_DYNAMIC"].ToString(), dt.Rows[i]["ROFR_DYNAMIC"].ToString(), dt.Rows[i]["DKT_EXTENT"].ToString(), dt.Rows[i]["LAND_HOLDING_REMARKS"].ToString());
                        p.UPDATED_SURVEY = dt.Rows[i]["UPDATED_SURVEY"].ToString();
                        p.UPDATED_PATTANO = dt.Rows[i]["UPDATED_PATTANO"].ToString();
                        p.REASON_LANDHOLDINGREMARKS = dt.Rows[i]["REASON_LANDHOLDINGREMARKS"].ToString();

                        p.EXTENT_SURVEY = dt.Rows[i]["EXTENT_SURVEY"].ToString();
                        p.RN = dt.Rows[i]["RN"].ToString();
                        p.EXISTING_RC_NUMBER = dt.Rows[i]["EXISTING_RC_NUMBER"].ToString();
                        p.UID_NO = dt.Rows[i]["UID_NO"].ToString();
                        p.UNIQUE_NUM = dt.Rows[i]["UNIQUE_NUM"].ToString();
                        p.MEMBER_NAME_EN = dt.Rows[i]["MEMBER_NAME_EN"].ToString();
                        p.WEBLAND_SURVEYNO_DYNAMIC = dt.Rows[i]["WEBLAND_SURVEYNO_DYNAMIC"].ToString();
                        p.FINAL_WEBLAND_EXTENT = dt.Rows[i]["FINAL_WEBLAND_EXTENT"].ToString();
                        p.ROFR_SURVEYNO_DYNAMIC = dt.Rows[i]["ROFR_SURVEYNO_DYNAMIC"].ToString();
                        p.ROFR_DYNAMIC = dt.Rows[i]["ROFR_DYNAMIC"].ToString();
                        p.DKT_EXTENT = dt.Rows[i]["DKT_EXTENT"].ToString();
                        p.LAND_HOLDING_REMARKS = dt.Rows[i]["LAND_HOLDING_REMARKS"].ToString();

                        p.LAND_HOLDING_REMARKS_2021 = dt.Rows[i]["LAND_HOLDING_REMARKS_2021"].ToString();
                        p.REASON_LANDHOLDINGREMARKS_2021 = dt.Rows[i]["REASON_LANDHOLDINGREMARKS_2021"].ToString();

                        data.Add(p);
                    }
                    else
                    {
                        Product p = new Product();
                        //new Product(dt.Rows[i]["EXISTING_RC_NUMBER"].ToString(), dt.Rows[i]["UID_NO"].ToString(), dt.Rows[i]["MEMBER_NAME_EN"].ToString(), dt.Rows[i]["WEBLAND_SURVEYNO_DYNAMIC"].ToString(), dt.Rows[i]["FINAL_WEBLAND_EXTENT"].ToString(), dt.Rows[i]["ROFR_SURVEYNO_DYNAMIC"].ToString(), dt.Rows[i]["ROFR_DYNAMIC"].ToString(), dt.Rows[i]["DKT_EXTENT"].ToString(), dt.Rows[i]["LAND_HOLDING_REMARKS"].ToString());

                        p.RN = dt.Rows[i]["RN"].ToString();
                        p.EXISTING_RC_NUMBER = dt.Rows[i]["EXISTING_RC_NUMBER"].ToString();
                        p.UID_NO = dt.Rows[i]["UID_NO"].ToString();
                        p.MEMBER_NAME_EN = dt.Rows[i]["MEMBER_NAME_EN"].ToString();
                        p.WEBLAND_SURVEYNO_DYNAMIC = dt.Rows[i]["WEBLAND_SURVEYNO_DYNAMIC"].ToString();
                        p.FINAL_WEBLAND_EXTENT = dt.Rows[i]["FINAL_WEBLAND_EXTENT"].ToString();
                        p.ROFR_SURVEYNO_DYNAMIC = dt.Rows[i]["ROFR_SURVEYNO_DYNAMIC"].ToString();
                        p.ROFR_DYNAMIC = dt.Rows[i]["ROFR_DYNAMIC"].ToString();
                        p.DKT_EXTENT = dt.Rows[i]["DKT_EXTENT"].ToString();
                        p.LAND_HOLDING_REMARKS = dt.Rows[i]["LAND_HOLDING_REMARKS"].ToString();


                        data.Add(p);
                    }
                }
            }

            return data;

        }

        protected void ExportToExcel(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();
                DataTable gdt = (DataTable)Session["Data"];
                if (ddl_status.SelectedValue == "NOLAND" || ddl_status.SelectedValue == "LESSTHAN1 ACRE" || ddl_status.SelectedValue == "LESSTHAN" || ddl_status.SelectedValue == "SUBMERGED")
             { 
                dt = gdt.DefaultView.ToTable(false, "EXISTING_RC_NUMBER", "UID_NO", "MEMBER_NAME_EN", "WEBLAND_SURVEYNO_DYNAMIC", "FINAL_WEBLAND_EXTENT", "ROFR_SURVEYNO_DYNAMIC", "ROFR_DYNAMIC", "DKT_EXTENT", "LAND_HOLDING_REMARKS", "UPDATED_SURVEY", "UPDATED_PATTANO", "EXTENT_SURVEY", "REASON_LANDHOLDINGREMARKS", "REASON_LANDHOLDINGREMARKS_2021", "LAND_HOLDING_REMARKS_2021");
                dt.Columns["EXISTING_RC_NUMBER"].ColumnName = "Ration Card No";
                dt.Columns["UID_NO"].ColumnName = "Aadhaar Number";
                dt.Columns["MEMBER_NAME_EN"].ColumnName = "Family Member Name";
                dt.Columns["WEBLAND_SURVEYNO_DYNAMIC"].ColumnName = "WebLand Survey No.";
                dt.Columns["FINAL_WEBLAND_EXTENT"].ColumnName = "WebLand Extent";
                dt.Columns["ROFR_SURVEYNO_DYNAMIC"].ColumnName = "ROFR Compartment No.";
                dt.Columns["ROFR_DYNAMIC"].ColumnName = "ROFR Extent";
                dt.Columns["DKT_EXTENT"].ColumnName = "DKT Land";
                dt.Columns["LAND_HOLDING_REMARKS"].ColumnName = "TWD Comments";
                    dt.Columns["UPDATED_SURVEY"].ColumnName = "Updated Survey/ Compartment No.";
                    dt.Columns["UPDATED_PATTANO"].ColumnName = "Updated Katha/ Patta No.";
                    dt.Columns["EXTENT_SURVEY"].ColumnName = "Updated Extent";

                    dt.Columns["REASON_LANDHOLDINGREMARKS"].ColumnName = "Updated Reason";
                 
                    dt.Columns["REASON_LANDHOLDINGREMARKS_2021"].ColumnName = "Updated Reason 2021";
                    dt.Columns["LAND_HOLDING_REMARKS_2021"].ColumnName = "TWD Comments 2021";

                }
                else
                {
                    dt = gdt.DefaultView.ToTable(false, "EXISTING_RC_NUMBER", "UID_NO", "MEMBER_NAME_EN", "WEBLAND_SURVEYNO_DYNAMIC", "FINAL_WEBLAND_EXTENT", "ROFR_SURVEYNO_DYNAMIC", "ROFR_DYNAMIC", "DKT_EXTENT", "LAND_HOLDING_REMARKS");
                    dt.Columns["EXISTING_RC_NUMBER"].ColumnName = "Ration Card No";
                    dt.Columns["UID_NO"].ColumnName = "Aadhaar Number";
                    dt.Columns["MEMBER_NAME_EN"].ColumnName = "Family Member Name";
                    dt.Columns["WEBLAND_SURVEYNO_DYNAMIC"].ColumnName = "WebLand Survey No.";
                    dt.Columns["FINAL_WEBLAND_EXTENT"].ColumnName = "WebLand Extent";
                    dt.Columns["ROFR_SURVEYNO_DYNAMIC"].ColumnName = "ROFR Compartment No.";
                    dt.Columns["ROFR_DYNAMIC"].ColumnName = "ROFR Extent";
                    dt.Columns["DKT_EXTENT"].ColumnName = "DKT Land";
                    dt.Columns["LAND_HOLDING_REMARKS"].ColumnName = "TWD Comments";
                }
                if (dt.Rows.Count > 0)
                {


                    string filename = "Familywise Land Holding Details" + DateTime.Now + ".xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();
                    dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


                    //Get the HTML for the control.
                    dgGrid.GridLines = GridLines.Both;
                    dgGrid.HeaderStyle.Font.Bold = true;
                    dgGrid.RenderControl(hw);
                   // Write the HTML back to the browser.
                    //Response.ContentType = application / vnd.ms - excel;
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

        protected void GridToExcel(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable gdt = (DataTable)Session["Gdata"];
                gdt.Columns["itda"].ColumnName = "ITDA";
                gdt.Columns["TOTAL"].ColumnName = "Total No.of Families";
                gdt.Columns["SUBMERED"].ColumnName = "Sub-merged/Migrated/In-Eligible Families";
                gdt.Columns["LANDALLOTMENT_FAMILIES"].ColumnName = "Families For Land Allotment";
                gdt.Columns["LESSTHAN1_ACRE"].ColumnName = "Families with < 1Acres";
                gdt.Columns["LESSTHAN"].ColumnName = "Families between 1and 2Acres";
                gdt.Columns["GRAEATERTHAN_FAMILIES"].ColumnName = "Families with > 2Acres";
                gdt.Columns["NOLAND_FAMILIES"].ColumnName = "Families with No Land";
              
                              if (gdt.Rows.Count > 0)
                {


                    string filename = "Familywise Land Holding Details Abstract" + DateTime.Now + ".xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = gdt;
                    dgGrid.DataBind();
                    //dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


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
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' No Data Found!')", true);
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
                AntiForgery.Validate();
                LinkButton btn = (LinkButton)sender;

                   // LinkButton btn = (LinkButton)item.FindControl("LinkButton2");



                    string s = btn.CommandArgument;

                    var range = s.IndexOf(',');

                    string start = s.Substring(0, range);
                    string end = s.Substring(s.LastIndexOf(',') + 1);
                    Txt_ration_no.Text = start.Trim();
                    rd = (DataTable)Session["Data"];
                    DataTable rds = rd.Copy();
                    // DataSet rdt = new DataSet();
                    div_uid.Visible = false;
                div_rn.Visible = false;
                    ddl_cmts.Enabled = true;
                    GridView1.Visible = true;
                add_status.Text = "";
                ddl_cmts.ClearSelection();
                ddl_reason.ClearSelection();
                    rdt.Tables.Add(rds);
                    rdt.Tables[0].DefaultView.RowFilter = "EXISTING_RC_NUMBER = '" + start + "'";
                    DataTable dt = (rdt.Tables[0].DefaultView).ToTable();
                    if (dt.Rows.Count > 0)
                    {
                        ddl_uid.DataSource = dt;
                        ddl_uid.DataTextField = "UNIQUE_NUM";
                        ddl_uid.DataValueField = "UNIQUE_NUM";
                        ddl_uid.DataBind();
                        ddl_uid.Items.Insert(0, new ListItem("Select", "0"));
                    }
                    string script = "window.onload = function() { openModal(); };";
                    ClientScript.RegisterStartupScript(this.GetType(), "openModal", script, true);
               // }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void mbtn_click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                AntiForgery.Validate();
                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();

                addbeneficiaryobj.District = Txt_ration_no.Text;
                addbeneficiaryobj.Aadhaar_NO = ddl_uid.SelectedItem.Text;
                addbeneficiaryobj.Compartment_No = txt_cmpno.Text;
                addbeneficiaryobj.ROFR_PATTANO = txt_pattano.Text;
                addbeneficiaryobj.EXTENT = txt_extent.Text;
                addbeneficiaryobj.REMARKS = ddl_cmts.SelectedItem.Text;
                addbeneficiaryobj.Type = "UPDATION-L";
                if (!string.IsNullOrEmpty(addbeneficiaryobj.District))
                {
                    if (ddl_cmts.SelectedItem.Text != "Select")
                    {
                      

                            if (ddl_cmts.SelectedValue == "1" || ddl_cmts.SelectedValue == "2" || ddl_cmts.SelectedValue == "3" || ddl_cmts.SelectedValue == "4" || ddl_cmts.SelectedValue == "8" || ddl_cmts.SelectedValue == "9" || ddl_cmts.SelectedValue == "11")
                        {

                            DataTable dt = hc.RB_STATUS_SP(addbeneficiaryobj);
                            if (dt.Rows.Count > 0 && dt.Rows[0]["'DATAUPDATEDSUCCEESFULLY'"].ToString() == "DATA UPDATED SUCCEESFULLY")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updated Successfully!')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updation Failed!')", true);
                            }

                        }
                        if ( ddl_cmts.SelectedValue == "5" || ddl_cmts.SelectedValue == "7")
                        {
                            if (!string.IsNullOrEmpty(txt_cmp_hide.Text))
                            {
                                DataTable dt = hc.RB_STATUS_SP(addbeneficiaryobj);
                                if (dt.Rows.Count > 0 && dt.Rows[0]["'DATAUPDATEDSUCCEESFULLY'"].ToString() == "DATA UPDATED SUCCEESFULLY")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updated Successfully!')", true);
                                    add_status.Text = "";
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updation Failed!')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript: alert('Alteast one Survey or Compartment details have to added...Please add land details on clicking Add button and the give Submit button!');", true);
                                
                            }
                            

                        }
                        if (ddl_cmts.SelectedValue == "6")
                        {
                            DataTable dt = hc.RB_STATUS_SP(addbeneficiaryobj);
                            if (dt.Rows.Count > 0 && dt.Rows[0]["'DATAUPDATEDSUCCEESFULLY'"].ToString() == "DATA UPDATED SUCCEESFULLY")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updated Successfully!')", true);
                                Response.Redirect("Add_Beneficiary_Master.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updation Failed!')", true);
                            }
                          
                        }
                        if (ddl_cmts.SelectedValue == "10")
                        {
                            if (ddl_reason.SelectedItem.Text != "Select")
                            {

                                addbeneficiaryobj.Mandal = ddl_reason.SelectedItem.Text;
                            DataTable dt = hc.RB_STATUS_SP(addbeneficiaryobj);
                            if (dt.Rows.Count > 0 && dt.Rows[0]["'DATAUPDATEDSUCCEESFULLY'"].ToString() == "DATA UPDATED SUCCEESFULLY")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updated Successfully!')", true);
                                
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Updation Failed!')", true);
                            }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Select Reason!')", true);
                            }
                        }

                        rpt1.DataSource = this.GetMergedData(this.GetData());
                        rpt1.DataBind();
                        foreach (RepeaterItem item in rpt1.Items)
                        {
                            Label cmt = (Label)item.FindControl("lbl_cmts");
                            LinkButton lbtn = (LinkButton)item.FindControl("LinkButton2");

                            if (cmt.Text == "" || cmt.Text == null)
                            {
                                lbtn.Enabled = true;
                            }
                            else
                            {
                                lbtn.Enabled = false;
                                lbtn.Text = "Updated";
                                lbtn.ForeColor = System.Drawing.Color.Green;
                                lbtn.BackColor = System.Drawing.Color.LightGray;


                            }
                        }
                       

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript: alert(' Please Select Comments!');", true);
                       
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Ration card Number cannot be empty!'); ", true);
                 
                }

                string script = "window.onload = function() { toggleModal(); };";
                ClientScript.RegisterStartupScript(this.GetType(), "toggleModal", script, true);



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void add_click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                AntiForgery.Validate();
                addbeneficiary_details addbeneficiaryobj = new addbeneficiary_details();
                addbeneficiaryobj.id = Txt_ration_no.Text;
                if (ddl_uid.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.Aadhaar_NO = ddl_uid.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.Aadhaar_NO = null;
                }
                addbeneficiaryobj.Compartment_No = txt_cmpno.Text;
                addbeneficiaryobj.ROFR_PATTANO = txt_pattano.Text;
                addbeneficiaryobj.EXTENT = txt_extent.Text;
                if (ddl_cmts.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.REMARKS = ddl_cmts.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.REMARKS = null;
                }
                if (ddl_land_type.SelectedItem.Text != "Select")
                {
                    addbeneficiaryobj.TYPE_CODE = ddl_land_type.SelectedItem.Text;
                }
                else
                {
                    addbeneficiaryobj.TYPE_CODE = null;
                }
                addbeneficiaryobj.Type = "1";
                if (!string.IsNullOrEmpty(addbeneficiaryobj.id))
                {
                    if (!string.IsNullOrEmpty(addbeneficiaryobj.REMARKS))
                    {
                        if (!string.IsNullOrEmpty(addbeneficiaryobj.Aadhaar_NO))
                        {
                            if (!string.IsNullOrEmpty(addbeneficiaryobj.TYPE_CODE))
                            {
                                if (!string.IsNullOrEmpty(addbeneficiaryobj.Compartment_No))
                                {
                                    if (!string.IsNullOrEmpty(addbeneficiaryobj.ROFR_PATTANO))
                                    {
                                        if (!string.IsNullOrEmpty(addbeneficiaryobj.EXTENT))
                                        {
                                           
                                                DataTable dt = hc.RB_STATUS_INSERT_SP(addbeneficiaryobj);

                                                if (dt.Rows.Count > 0 && dt.Rows[0]["STATUS"].ToString() == "1")
                                                {
                                                    add_status.Visible = true;
                                                    add_status.Text = "Added Successfully";
                                                    ddl_cmts.Enabled = false;
                                                    txt_cmp_hide.Text = addbeneficiaryobj.Compartment_No;
                                                txt_pattano.Text = "";
                                                txt_cmpno.Text = "";
                                                txt_extent.Text = "";
                                                ddl_uid.ClearSelection();
                                                if(ddl_cmts.SelectedValue=="7")
                                                {
                                                    ddl_land_type.ClearSelection();
                                                }
                                                }
                                                else
                                                {
                                                    add_status.Visible = true;
                                                    add_status.Text = "Failed";
                                                }
                                           
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Enter Extent!')", true);
                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Enter Patta Number!')", true);
                                    }
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Enter Compartment Number!')", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Select Land Type!')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Select Aadhar Number!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Please Select Comments!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Ration card Number cannot be empty!')", true);
                }

                string script = "window.onload = function() { toggleModal(); };";
                ClientScript.RegisterStartupScript(this.GetType(), "toggleModal", script, true);




            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddl_cmts_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                System.Threading.Thread.Sleep(5000);
                if (ddl_cmts.SelectedItem.Text != "Select")


                {
                    ddl_land_type.ClearSelection();
                    if (ddl_cmts.SelectedValue == "1" || ddl_cmts.SelectedValue == "2" || ddl_cmts.SelectedValue == "3" || ddl_cmts.SelectedValue == "4" || ddl_cmts.SelectedValue == "6" || ddl_cmts.SelectedValue == "8" || ddl_cmts.SelectedValue == "9" || ddl_cmts.SelectedValue == "11")
                    {
                        div_uid.Visible = false;

                        div_rn.Visible = false;
                    }
                    if (ddl_cmts.SelectedValue == "10")
                    {
                        div_uid.Visible = false;
                        div_rn.Visible = true;
                        ddl_reason.ClearSelection();
                    }
                    if (ddl_cmts.SelectedValue == "5")
                    {
                        div_rn.Visible = false;
                        div_uid.Visible = true;
                        ddl_land_type.Items.Clear();
                        ddl_land_type.Items.Insert(0, new ListItem("WebLand", "0"));

                        txt_extent.Text = "";
                        txt_pattano.Text = "";
                        txt_cmpno.Text = "";
                        txt_cmp_hide.Text = "";
                        ddl_uid.ClearSelection();
                    }
                    if ( ddl_cmts.SelectedValue == "7")
                    {
                        div_rn.Visible = false;
                        div_uid.Visible = true;
                        txt_extent.Text = "";
                        txt_pattano.Text = "";
                        txt_cmpno.Text = "";
                        txt_cmp_hide.Text = "";
                        ddl_uid.ClearSelection();
                        ddl_land_type.Items.Clear();
                        ddl_land_type.Items.Insert(0, new ListItem("Select", "0"));
                        ddl_land_type.Items.Insert(1, new ListItem("WebLand", "1"));
                        ddl_land_type.Items.Insert(2, new ListItem("ROFR", "2"));

                    }

                }
                else
                {

                    div_uid.Visible = false;
                    div_rn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void ddl_uid_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);

                add_status.Visible = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void ddl_type_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                System.Threading.Thread.Sleep(5000);
                add_status.Visible = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void Close_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                AntiForgery.Validate();
                        if (ddl_cmts.SelectedValue == "5" || ddl_cmts.SelectedValue == "7")
                        {
                            if (add_status.Text== "Added Successfully")
                            {


                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please click on Submit button to submit comments and then click close !')", true);
                                string script = "window.onload = function() { closeModal(); };";
                                ClientScript.RegisterStartupScript(this.GetType(), "closeModal", script, true);


                            }
                            if(add_status.Text=="")
                    {
                        string script = "window.onload = function() { HideModal(); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "HideModal", script, true);
                    }
                    if (add_status.Text == "Failed")
                    {
                        string script = "window.onload = function() { HideModal(); };";
                        ClientScript.RegisterStartupScript(this.GetType(), "HideModal", script, true);
                    }
                }
                        else
                        {
                            string script = "window.onload = function() { HideModal(); };";
                            ClientScript.RegisterStartupScript(this.GetType(), "HideModal", script, true);

                        }



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void OnDataBoundGrid(object sender, EventArgs e)
        {

            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
            TableHeaderCell cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);
            cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();
            cell.Text = "";
            row.Controls.Add(cell);

            cell = new TableHeaderCell();

            cell.Text = "Land Holding Details";
            cell.ColumnSpan = 4;
            cell.Attributes.Add("style", "text-align:center !important;");

            row.Controls.Add(cell);



            //row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
            GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
        }
    }
    public class Product
    {
        public string REASON_LANDHOLDINGREMARKS { get; set; }
        public string SURVEY_COMPARTMENT_NO { get; set; }
        public string KHATHA_PATTA_NO { get; set; }
        public string UPDATED_SURVEY { get; set; }
        public string UPDATED_PATTANO { get; set; }
        public string EXTENT_SURVEY { get; set; }
        public string RN { get; set; }
        public string EXISTING_RC_NUMBER { get; set; }

        public string UID_NO { get; set; }
        public string UNIQUE_NUM { get; set; }
        public string MEMBER_NAME_EN { get; set; }
        public string WEBLAND_SURVEYNO_DYNAMIC { get; set; }
        public string FINAL_WEBLAND_EXTENT { get; set; }
        public string ROFR_SURVEYNO_DYNAMIC { get; set; }
        public string ROFR_DYNAMIC { get; set; }
        public string DKT_EXTENT { get; set; }
        public string LAND_HOLDING_REMARKS { get; set; }

        public string LAND_HOLDING_REMARKS_2021 { get; set; }
        public string REASON_LANDHOLDINGREMARKS_2021 { get; set; }
        public int CountOfProductsWithThisItemName { get; set; }
        public bool IsFirstRowWithThisItemName { get; set; }

        //public Product(string EXISTING_RC_NUMBER1, string UID_NO1, string MEMBER_NAME_EN1, string WEBLAND_SURVEYNO_DYNAMIC1, string FINAL_WEBLAND_EXTENT1, string ROFR_SURVEYNO_DYNAMIC1, string ROFR_DYNAMIC1, string DKT_EXTENT1, string LAND_HOLDING_REMARKS1)
        //{
        //    this.EXISTING_RC_NUMBER = EXISTING_RC_NUMBER1;
        //    this.UID_NO = UID_NO1;
        //    this.MEMBER_NAME_EN = MEMBER_NAME_EN1;
        //    this.WEBLAND_SURVEYNO_DYNAMIC = WEBLAND_SURVEYNO_DYNAMIC1;
        //    this.FINAL_WEBLAND_EXTENT = FINAL_WEBLAND_EXTENT1;
        //    this.ROFR_SURVEYNO_DYNAMIC = ROFR_SURVEYNO_DYNAMIC1;
        //    this.ROFR_DYNAMIC = ROFR_DYNAMIC1;
        //    this.DKT_EXTENT = DKT_EXTENT1;
        //    this.LAND_HOLDING_REMARKS = LAND_HOLDING_REMARKS1;
        //}

    }
}
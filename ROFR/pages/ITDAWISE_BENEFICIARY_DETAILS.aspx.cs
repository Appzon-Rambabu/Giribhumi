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
    public partial class ITDAWISE_BENEFICIARY_DETAILS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    BindItda();

                    select_records.Visible = false;
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


                DataTable dtItda = Landsettlementpattas.GetRofrMasters((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);

                if (dtItda.Rows.Count > 0)
                {
                    ddl_Itda.DataSource = dtItda;
                    ddl_Itda.DataTextField = "ITDA_NAME";
                    ddl_Itda.DataValueField = "ITDA_CODE";
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
        protected void ddl_Itda_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                System.Threading.Thread.Sleep(5000);
                ddl_records.Items.Clear();
                GridView1.DataSource = null;
                GridView1.DataBind();

                if (ddl_Itda.SelectedItem.Text != "Select")
                {

                    GridView1.DataSource = null;

                    GridView1.DataBind();

                    
                    select_records.Visible = false;
                    BindCount(ddl_Itda.SelectedItem.Text,true,"");
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

        public void BindCount(string Itda, bool FLAG, string VALUE)
        {
            try
            {
                string recordvalue = string.Empty;

                GridView1.DataSource = null;

                GridView1.DataBind();


                DataTable dt = Landsettlementpattas.GetItdabeneficiarycount(Itda);

                if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["count"].ToString()) > 0)
                    {
                        select_records.Visible = true;
                        ListItemCollection list = new ListItemCollection();
                        int rowscount = Convert.ToInt32(dt.Rows[0]["count"].ToString());
                        string k = string.Empty;
                        for (int i = 1; i <= rowscount; i++)
                        {
                            if (rowscount <= 100)
                            {
                                int j = i + (rowscount - 1);
                                k = i + "-" + j;
                                list.Add(new ListItem(k));
                                i = j;
                            }
                            else
                            {
                                int remainingrows = rowscount - i;
                                if (remainingrows > 100)
                                {
                                    int j = i + 99;
                                    k = i + "-" + j;
                                    if (FLAG == false)
                                    {
                                        if (VALUE == k)
                                        {
                                            recordvalue = k;
                                        }
                                    }
                                    list.Add(new ListItem(k));
                                    i = j;
                                }
                                else
                                {
                                    int j = (i) + remainingrows;
                                    k = i + "-" + j;
                                    list.Add(new ListItem(k));
                                    i = j;
                                    break;
                                }
                            }
                        }
                        ddl_records.DataSource = list;
                        ddl_records.DataBind();
                        if (FLAG == true)
                        {
                            ddl_records.Items.Insert(0, new ListItem("Select", "0"));
                        }
                        else
                        {
                            ddl_records.Items.Insert(0, new ListItem("Select", "0"));
                            if (recordvalue != string.Empty)
                            {
                                ddl_records.SelectedValue = recordvalue;
                            }
                            else
                            {
                                ddl_records.SelectedValue = k;
                            }

                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('No Data Found')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        public DataTable searchBindData(string Itda)
        {
            DataTable dt = new DataTable();
            try
            {
                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);

                GridView1.DataSource = null;

                GridView1.DataBind();

                 dt = Landsettlementpattas.GetItdaBeneficiaryData(ddl_Itda.SelectedItem.Text, start, end);


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
            return dt;
        }
        protected void txtSearch_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable dt = new DataTable();
               
                dt= searchBindData(ddl_Itda.SelectedItem.Text);
                if (dt.Rows.Count > 0)
                {
                    DataView DV = dt.AsDataView();
                    DV.RowFilter = string.Format("ROFR_PATTADAAR LIKE '%{0}%'", txtSearch.Text);
                    
                    GridView1.DataSource = DV;

                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Excel_Click(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                DataTable dt = Landsettlementpattas.GetItdawiseBeneficiary(ddl_Itda.SelectedItem.Text);

               
                dt.Columns["Id"].ColumnName = "ID";
               
                dt.Columns["ITDA_NAME"].ColumnName = "ITDA NAME";
                dt.Columns["District"].ColumnName = "DISTRICT";
                dt.Columns["Mandal"].ColumnName = "MANDAL";
                dt.Columns["Gram_Panchayat"].ColumnName = "GRAM PANCHAYAT";
                dt.Columns["REV_Village"].ColumnName = "REVENUE VILLAGE";
                dt.Columns["Village"].ColumnName = "VILLAGE";
                dt.Columns["Habitation"].ColumnName = "HABITATION";
                dt.Columns["Forest_Division"].ColumnName = "FOREST DIVISION";
                dt.Columns["Forest_Range"].ColumnName = "FOREST RANGE";
                dt.Columns["Forest_Beat"].ColumnName = "FOREST BEAT";
                dt.Columns["Forest_Block"].ColumnName = "FOREST BLOCK";
                dt.Columns["Compartment_No"].ColumnName = "COMPARTMENT NO";
                dt.Columns["Plot_No"].ColumnName = "PLOT NO";
                dt.Columns["ExtentPlotArea"].ColumnName = "EXTENT PLOT AREA";
                dt.Columns["ROFR_PATTANO"].ColumnName = "ROFR PATTA NO";
                dt.Columns["ROFR_PATTADAAR"].ColumnName = "ROFR PATTADAAR";
                dt.Columns["CULTIVATOR_NAME"].ColumnName = "CULTIVATOR NAME";
                dt.Columns["FATHER_NAME"].ColumnName = "FATHER NAME";
                dt.Columns["SUB_CASTE"].ColumnName = "SUB CASTE";
                dt.Columns["Aadhaar_NO"].ColumnName = "AADHAR NO";
                dt.Columns["Uncultivable_Land"].ColumnName = "UNCULTIVABLE LAND";
                dt.Columns["Cultivable_Land"].ColumnName = "CULTIVABLE LAND";
                dt.Columns["PATTA_INAMGOVT"].ColumnName = "PATTA INAM/GOVT";
                dt.Columns["DRYID_ONECROP_TWO_CROP"].ColumnName = "DRYID ONECROP/TWOCROP";
                dt.Columns["WATER_SOURCE"].ColumnName = "WATER SOURCE";
                dt.Columns["EXTENT_IRRIGATED"].ColumnName = "EXTENT IRRIGATED";
                dt.Columns["EXTENT_UNDER_CULTIVATOR"].ColumnName = "EXTENT UNDER CULTIVATOR";
                dt.Columns["Land_Classification_Name"].ColumnName = "LAND CLASSIFICATION";
                dt.Columns["HOLDING_NATURE"].ColumnName = "HOLDING NATURE";
                dt.Columns["EXTENT"].ColumnName = "EXTENT";
                dt.Columns["NET_SOWN_AREA"].ColumnName = "NET SOWN AREA";
                dt.Columns["MONTH_OF_CULTIVATION"].ColumnName = "MONTH OF CULTIVATION";
                dt.Columns["CROP"].ColumnName = "CROP";
                dt.Columns["TOTAL"].ColumnName = "EXTENT TOTAL";
                dt.Columns["FIRST_CROP"].ColumnName = "FIRST CROP";
                dt.Columns["SECOND_THIRD_CROP"].ColumnName = "SECOND/THIRD CROP";
                dt.Columns["CROP_YIELD"].ColumnName = "CROP YIELD";
                dt.Columns["REMARKS"].ColumnName = "REMARKS";
                dt.Columns["BankAccountNo"].ColumnName = "BANK ACCOUNT NO.";
                dt.Columns["IfscCode"].ColumnName = "IFSC CODE";
                dt.Columns["BankName"].ColumnName = "BANK NAME";
                dt.Columns["SINGLE"].ColumnName = "EXTENT SINGLE";
                dt.Columns["MIXED"].ColumnName = "EXTENT MIXED";
                if (dt.Rows.Count > 0)
                {
                    string filename = "ITDAWISE_BENEFICIARY_LAND_DETAILS.xls";
                    System.IO.StringWriter tw = new System.IO.StringWriter();
                    System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                    DataGrid dgGrid = new DataGrid();
                    dgGrid.DataSource = dt;
                    dgGrid.DataBind();

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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void ddlrecords_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread.Sleep(5000);
                if (ddl_Itda.SelectedItem.Text != "Select")
                {
                    if (ddl_records.SelectedValue != "0")
                    {
                        BindData(ddl_Itda.SelectedItem.Text);
                        

                    }
                    else
                    {
                        GridView1.DataSource = null;

                        GridView1.DataBind();

                       
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void BindData(string Itda)
        {
            try
            {
                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);

                GridView1.DataSource = null;

                GridView1.DataBind();
                DataTable dt = Landsettlementpattas.GetItdaBeneficiaryData(ddl_Itda.SelectedItem.Text,start,end);



                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;

                    GridView1.DataBind();

                 

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
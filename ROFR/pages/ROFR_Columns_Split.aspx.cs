using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ROFR.helper;
namespace ROFR.pages
{
    public partial class ROFR_Columns_Split : System.Web.UI.Page
    {
        string COMPARTMENT_NO;
        string PLOT_NO;
        string AADHAAR_NO;
        string ROFR_PATTA_NO;
        protected void Page_Init(object sender, EventArgs e)
        {
            ddl_records.Items.Insert(0, new ListItem("Select", "0"));
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddl_records.Items.Insert(0, new ListItem("Select", "0"));
                    BindCount();
                    //Repeater1.Visible = false;
                    Repeater2.Visible = false;

                    div_lbltxt.Visible = false;
                    if ((string)(Session["CurrentPage"]) == "ROFR_BEATWISE_REPORT.aspx")
                    {
                        Select_Records.Visible = true;
                    }
                    else if ((string)(Session["CurrentPage"]) == "Mee_Giri_Bhoomi.aspx")
                    {
                        div_lbltxt.Visible = true;
                        Select_Records.Visible = false;
                        BindGrid();
                    }
                    else if ((string)(Session["CurrentPage"]) == "Data_Analysis.aspx")
                    {
                        div_lbltxt.Visible = false;
                        Select_Records.Visible = false;
                        DataTable dt = (DataTable)Session["dtTest"];
                        DataTable dtcount = (DataTable)Session["dtTest1"];
                        string count = dtcount.Rows[0]["cnt"].ToString();
                        Bindcountanalysis(count);
                        Binddataanalysis(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void Bindcountanalysis(string count)
        {
            try
            {

                ListItemCollection list = new ListItemCollection();
                int rowscount = Convert.ToInt32(count);
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Binddataanalysis(DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();
                    Repeater2.DataSource = dt;

                    Repeater2.DataBind();
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
        protected void BindData()
        {
            try
            {
                string FD = (string)(Session["Division"]);
                string FR = (string)(Session["Range"]);
                string FB = (string)(Session["Beat"]);
                txt_FD.Text = (string)(Session["FD"]);
                txt_FR.Text = (string)(Session["FR"]);
                txt_FB.Text = (string)(Session["FB"]);

                string a = ddl_records.SelectedItem.Text;
                var range = a.IndexOf('-');

                string start = a.Substring(0, range);
                string end = a.Substring(a.LastIndexOf('-') + 1);

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiariesDetails(FD, FR, FB, start, end, (string)(Session["username"]));

                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();
                    Repeater2.DataSource = dt;

                    Repeater2.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    if ((string)(Session["CurrentPage"]) == "ROFR_BEATWISE_REPORT.aspx")
                    {
                        Response.Redirect("ROFR_BEATWISE_REPORT.aspx");
                    }
                    else if ((string)(Session["CurrentPage"]) == "Mee_Giri_Bhoomi.aspx")
                    {
                        Response.Redirect("Mee_Giri_Bhoomi.aspx");
                    }
                    else if ((string)(Session["CurrentPage"]) == "Data_Analysis.aspx")
                    {
                        Response.Redirect("Data_Analysis.aspx");
                    }
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
                string FD = (string)(Session["Division"]);
                string FR = (string)(Session["Range"]);
                string FB = (string)(Session["Beat"]);
                txt_FD.Text = (string)(Session["FD"]);
                txt_FR.Text = (string)(Session["FR"]);
                txt_FB.Text = (string)(Session["FB"]);


                if ((string)(Session["OptionLabeltest"]) == "Compartment Number")
                {
                    COMPARTMENT_NO = ((string)(Session["OptiontestValue"]));
                }


                if ((string)(Session["OptionLabeltest"]) == "Plot No.")
                {
                    PLOT_NO = ((string)(Session["OptiontestValue"]));
                }


                if ((string)(Session["OptionLabeltest"]) == "Aadhar Number")
                {
                    AADHAAR_NO = ((string)(Session["OptiontestValue"]));
                }


                if ((string)(Session["OptionLabeltest"]) == "Pattadhar Number")
                {
                    ROFR_PATTA_NO = ((string)(Session["OptiontestValue"]));
                }

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetMeeBeneficiariesDetails(FD, FR, FB, COMPARTMENT_NO, PLOT_NO, AADHAAR_NO, ROFR_PATTA_NO, (string)(Session["username"]));
                if (dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;

                    Repeater1.DataBind();
                    Repeater2.DataSource = dt;

                    Repeater2.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('No Data Found !')", true);
                    if ((string)(Session["CurrentPage"]) == "ROFR_BEATWISE_REPORT.aspx")
                    {
                        Response.Redirect("ROFR_BEATWISE_REPORT.aspx");
                    }
                    else if ((string)(Session["CurrentPage"]) == "Mee_Giri_Bhoomi.aspx")
                    {
                        Response.Redirect("Mee_Giri_Bhoomi.aspx");
                    }
                    else if ((string)(Session["CurrentPage"]) == "Data_Analysis.aspx")
                    {
                        Response.Redirect("Data_Analysis.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        public void BindCount()
        {
            try
            {
                string FD = (string)(Session["FD"]);
                string FR = (string)(Session["FR"]);
                string FB = (string)(Session["FB"]);

                DataTable dt = ProjectRofrBAL.GetMasterDetails.GetForestBeneficiariesRecordsCount(FD, FR, FB, (string)(Session["username"]));
                if (dt.Rows.Count > 0)
                {
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
        protected void ddlrecords_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindData();

                div_lbltxt.Visible = false;
                Repeater1.Visible = false;
                Repeater2.Visible = false;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void Giribhoomi1report(object sender, EventArgs e)
        {
            try
            {

                if ((string)(Session["CurrentPage"]) == "ROFR_BEATWISE_REPORT.aspx")
                {
                    BindData();

                    div_lbltxt.Visible = true;
                    Repeater1.Visible = true;
                    Repeater2.Visible = false;
                }
                else if ((string)(Session["CurrentPage"]) == "Mee_Giri_Bhoomi.aspx")
                {
                    BindGrid();
                    div_lbltxt.Visible = true;
                    Repeater1.Visible = true;
                    Repeater2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }
        protected void Giribhoomi2report(object sender, EventArgs e)
        {
            try
            {

                if ((string)(Session["CurrentPage"]) == "ROFR_BEATWISE_REPORT.aspx")
                {
                    BindData();

                    div_lbltxt.Visible = true;
                    Repeater1.Visible = false;
                    Repeater2.Visible = true;
                }
                else if ((string)(Session["CurrentPage"]) == "Mee_Giri_Bhoomi.aspx")
                {
                    BindGrid();
                    div_lbltxt.Visible = true;
                    Repeater1.Visible = false;
                    Repeater2.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }


        }

        protected void lbtn_part1_Click(object sender, EventArgs e)
        {
            try
            {

                if ((string)(Session["CurrentPage"]) == "ROFR_BEATWISE_REPORT.aspx")
                {
                    BindData();

                    div_lbltxt.Visible = true;
                    Repeater1.Visible = true;
                    Repeater2.Visible = false;
                }
                else if ((string)(Session["CurrentPage"]) == "Mee_Giri_Bhoomi.aspx")
                {
                    BindGrid();
                    div_lbltxt.Visible = true;
                    Repeater1.Visible = true;
                    Repeater2.Visible = false;
                }
                else if ((string)(Session["CurrentPage"]) == "Data_Analysis.aspx")
                {
                    div_lbltxt.Visible = false;
                    Repeater1.Visible = true;
                    Repeater2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        protected void lbtn_part2_Click(object sender, EventArgs e)
        {
            try
            {

                if ((string)(Session["CurrentPage"]) == "ROFR_BEATWISE_REPORT.aspx")
                {
                    BindData();

                    div_lbltxt.Visible = true;
                    Repeater1.Visible = false;
                    Repeater2.Visible = true;
                }
                else if ((string)(Session["CurrentPage"]) == "Mee_Giri_Bhoomi.aspx")
                {
                    BindGrid();
                    div_lbltxt.Visible = true;
                    Repeater1.Visible = false;
                    Repeater2.Visible = true;
                }
                else if ((string)(Session["CurrentPage"]) == "Data_Analysis.aspx")
                {
                    div_lbltxt.Visible = false;
                    Repeater1.Visible = false;
                    Repeater2.Visible = true;
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
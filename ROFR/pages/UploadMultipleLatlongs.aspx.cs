using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net;
using ROFR.helper;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Web.Helpers;

namespace ROFR.pages
{
    public partial class UploadMultipleLatlongs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindItda();
                    uploadfile.Visible = false;
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
            ddl_ITda.Items.Insert(0, new ListItem("Select", "0"));
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



        protected void ddlitda_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                if (ddl_ITda.SelectedItem.Text != "Select")
                {
                    uploadfile.Visible = true;
                }
                else
                {
                    uploadfile.Visible = false;
                }

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
                AntiForgery.Validate();
                if ((string)(Session["latlongId"]) != "")
                {
                    string filePath = FileUpload1.PostedFile.FileName; // getting the file path of uploaded file

                    string filename1 = Path.GetFileName(filePath);     // getting the file name of uploaded file

                    filename1 = (string)(Session["latlongId"]) + filename1;
                    string ext = Path.GetExtension(filename1);
                    // getting the file extension of uploaded file
                    if (filename1 != "")//&& ddl_ITda.SelectedItem.Text != "" && ddl_district.SelectedItem.Text != ""
                    {
                        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];



                        string FilePath = HttpContext.Current.Server.MapPath(FolderPath + filename1);

                        FileUpload1.SaveAs(FilePath);
                        string type = String.Empty;
                        String strConnection = "";

                        import(FilePath, ext);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' please select file and Itda and District !')", true);
                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Session Closed please Login Again!')", true);

                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void btnmap_Click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                Session["BeneficaryMapid"] = (string)(Session["latlongId"]);
                string url = "../pages/BeneficaryLandView.aspx";
                string s = "window.open('" + url + "', 'popup_window', 'width=500,height=500,resizable=yes');";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }


        protected void import(string FilePath, string Extension)
        {
            try
            {
                AntiForgery.Validate();
                string conStr = "";

                switch (Extension)

                {

                    case ".xls": //Excel 97-03

                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                                 .ConnectionString;

                        break;

                    case ".xlsx": //Excel 07

                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                                  .ConnectionString;

                        break;

                }

                conStr = String.Format(conStr, FilePath, "Yes");

                OleDbConnection connExcel = new OleDbConnection(conStr);

                OleDbCommand cmdExcel = new OleDbCommand();

                OleDbDataAdapter oda = new OleDbDataAdapter();

                DataTable dt = new DataTable();

                cmdExcel.Connection = connExcel;



                //Get the name of First Sheet

                connExcel.Open();

                DataTable dtExcelSchema;

                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                connExcel.Close();



                //Read Data from First Sheet

                connExcel.Open();

                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                oda.SelectCommand = cmdExcel;

                oda.Fill(dt);

                connExcel.Close();

                BeneficiaryDetails BeneficiaryDetailsobj = new BeneficiaryDetails();
                DataTable dtUpdateDetails = new DataTable();
                dtUpdateDetails.Columns.Add("Option1");
                dtUpdateDetails.Columns.Add("Option2");
                dtUpdateDetails.Columns.Add("Option3");
                dtUpdateDetails.Columns.Add("Option4");
                dtUpdateDetails.Columns.Add("Option5");

                foreach (DataRow drow in dt.Rows)
                {

                    System.Data.DataRow dr = dtUpdateDetails.NewRow();
                    if ((drow["ID"].ToString().Trim()) != "")
                    {
                        if ((drow["LATITUDE"].ToString().Trim()) != "")
                        {
                            if ((drow["LONGITUDE"].ToString().Trim()) != "")
                            {
                                dr["Option1"] = Convert.ToInt32(drow["ID"].ToString().Trim());
                                dr["Option2"] = drow["LATITUDE"].ToString().Trim();
                                dr["Option3"] = drow["LONGITUDE"].ToString().Trim();
                                dr["Option4"] = drow["NAME"].ToString().Trim();
                                dtUpdateDetails.Rows.Add(dr);
                            }
                        }
                    }
                }

                BeneficiaryDetailsobj.UpdateForestMasterDetails = dtUpdateDetails;
                if (dtUpdateDetails.Rows.Count > 0)
                {
                    if (dtUpdateDetails.Rows.Count >= 4)
                    {
                        MastersDataAnalysisBAL.MastersDataAnalysis.INSERTMultiplelatlongsdata(ddl_ITda.SelectedValue, BeneficiaryDetailsobj);
                        // ProjectRofrBAL.GetMasterDetails.importUpdateValidateBeneficiaryDetails(BeneficiaryDetailsobj, (string)(Session["username"]), ddl_ITda.SelectedItem.Text, ddl_district.SelectedValue, radioid.SelectedValue);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('LatLongs Inserted Successfully !')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Your Upload Excel Rejected !')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Your Upload Excel Rejected !')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
    }
}
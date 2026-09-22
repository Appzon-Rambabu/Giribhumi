using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Dynamic;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Text;
using System.Web.Helpers;

namespace ROFR.pages
{
    public partial class Epassbook : System.Web.UI.Page
    {
        char a, b, c, d, e;
        string ct;
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            if ((string)(Session["username"]) != null )
            {
                this.MasterPageFile = "~/Masters/ROFR_MASTER.Master";
            }
            else
            {

                this.MasterPageFile = "~/Masters/ROFR_MASTER.Master";
            }
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
                
                if (!IsPostBack)
                {
                    BindItda();

                    ddl_dist.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                    ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                    Get_Captcha();
                    GridView1.Visible = false;

                   

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
                DataTable dtItda = Landsettlementpattas.GetRofrMasters3((string)(Session["username"]), "Itda", "", "", "", "", "", (string)Session["userprevilages"]);
                // DataTable dtItda = RevenueDistrictsBAL.RevenueDistricts.GetItdaMaster((string)(Session["username"]), "Itda", "", "");
                if (dtItda.Rows.Count > 0)
                {
                    

                    ddl_itda.DataSource = dtItda;
                    ddl_itda.DataTextField = "ITDA_NAME";
                    ddl_itda.DataValueField = "ITDA_CODE";
                    ddl_itda.DataBind();
                    ddl_dist.ClearSelection();
                    ddl_pattadhar.ClearSelection();
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

                ddl_dist.Items.Clear();
                ddl_dist.Items.Insert(0, new ListItem("Select", "0"));
                ddl_mandal.Items.Clear();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));

                ddl_village.Items.Clear();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
               
                ddl_pattadhar.Items.Clear();
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                txt_rbtn_list.Text = "";
                if (ddl_itda.SelectedItem.Text != "Select")
                {
                    ddl_dist.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();


                    DataTable dtdistrict = Landsettlementpattas.GetRofrMasters3((string)(Session["username"]), "District", ddl_itda.SelectedValue, "", "", "", "", (string)Session["userprevilages"]);
                    //DataTable dtdistrict = MastersDataAnalysisBAL.MastersDataAnalysis.GetbenitdaDetails(ddl_ITda.SelectedItem.Text, (string)(Session["username"]));
                    if (dtdistrict.Rows.Count > 0)
                    {
                        BindDistrict(dtdistrict);
                        if (dtdistrict.Rows.Count <= 1)
                        {
                            ddl_dist.SelectedIndex = 1;
                            DataTable dtMandal = Landsettlementpattas.GetRofrMasters3((string)(Session["username"]), "Mandal", ddl_itda.SelectedValue, ddl_dist.SelectedValue, "", "", "", (string)Session["userprevilages"]);
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
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = false;
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                if (ddl_dist.SelectedItem.Text != "Select")
                {
                    DataTable dtMandal = Landsettlementpattas.GetRofrMasters3((string)(Session["username"]), "Mandal", ddl_itda.SelectedValue, ddl_dist.SelectedValue, "", "", "", (string)Session["userprevilages"]);

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
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = false;

               

                if (ddl_mandal.SelectedItem.Text != "Select")
                {
                    ddl_village.ClearSelection();
                    DataTable dtVillages = Landsettlementpattas.GetRofrMasters3((string)(Session["username"]), "Village", ddl_itda.SelectedValue, ddl_dist.SelectedValue, ddl_mandal.SelectedItem.Text, "", "", (string)Session["userprevilages"]);
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
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = false;

                if (ddl_village.SelectedItem.Text != "Select")
                {

                    if (rbtn_list.SelectedValue == "D")
                    {
                        DataTable dtpattadar = Landsettlementpattas.Get1bdetails1((string)(Session["username"]), "pattadar", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
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
            string strAnswer = String.Empty;
            GridView1.Visible = false;
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
                //clear values
                ddl_itda.SelectedIndex = -1;
                ddl_dist.SelectedIndex = -1;
                ddl_mandal.SelectedIndex = -1;
                ddl_village.SelectedIndex = -1;
                txt_rbtn_list.Text = string.Empty;
                




            }
           
            else if (rbtn_list.SelectedItem.Value == "D")
            {
                txt_rbtn_list.Visible = false;
                ddl_pattadhar.Visible = true;
                ddl_pattadhar.Items.Insert(0, new ListItem("Select", "0"));
                //clear values
                ddl_itda.SelectedIndex = -1;
                ddl_dist.SelectedIndex = -1;
                ddl_mandal.SelectedIndex = -1;
                ddl_village.SelectedIndex = -1;
                ddl_pattadhar.SelectedIndex = -1;
                txtInput.Value = string.Empty;

                



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
        protected void btn_crystalpdf_Click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                HttpContext context = HttpContext.Current;
                string filename = string.Empty;
                string path = string.Empty;
                DataSet ds = Landsettlementpattas.BeneficiaryePassbook("", (string)(Session["userprevilages"]), (string)(Session["username"]));
                ds.Tables[0].Columns.Add("Image", typeof(byte[]));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    filename = ds.Tables[0].Rows[0]["Image1"].ToString();
                    path = ds.Tables[0].Rows[0]["Imagepath"].ToString();
                    DisplayImages(ds.Tables[0].Rows[0], "Image", (path + filename));
                }
                //else
                //{
                //    DisplayImages(ds.Tables[0].Rows[0], "Image", "DefaultPicturePath");
                //}
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/BeneficiaryPassbook.rpt"));
                crystalReport.Database.Tables["DataTable1"].SetDataSource(ds.Tables[0]);
                crystalReport.Database.Tables[1].SetDataSource(ds.Tables[1]);
               // CrystalReportViewer1.ReportSource = crystalReport;
                //CrystalReportViewer1.RefreshReport();
                string cfilename = "Report.pdf";

                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "EPASSBOOK");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void DisplayImages(DataRow row, string img, string ImagePath)

        {

            FileStream stream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);

            byte[] ImgData = new byte[stream.Length];

            stream.Read(ImgData, 0, Convert.ToInt32(stream.Length));

            stream.Close();

            row[img] = ImgData;

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                AntiForgery.Validate();
                string captcha = txtInput.Value;
                string captcha1 = (string)Session["CaptchaCode"];
                if (captcha != null && captcha != "")
                {
                    //string string1 = captcha.Replace(" ", "");
                    //string string2 = captcha1.Replace(" ", "");
                    if (captcha == (string)Session["CaptchaCode"])
                    {

                        System.Threading.Thread.Sleep(5000);
                        GridView1.Visible = true;
                        if (rbtn_list.SelectedValue == "C")
                        {
                            

                            if ( txt_rbtn_list.Text != "")
                            {
                                
                                //ddl_dist.Items.Clear();
                                //ddl_dist.Items.Insert(0, new ListItem("Select", "0"));
                                //ddl_mandal.Items.Clear();
                                //ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));

                                
                                DataTable dt = Landsettlementpattas.Epassbook((string)(Session["username"]), "adhar", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", txt_rbtn_list.Text, (string)Session["userprevilages"]);

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
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Aadhar Number!')", true);
                            }
                        }

                        else if (rbtn_list.SelectedValue == "D")
                        {

                            
                            if ( ddl_pattadhar.SelectedItem.Text != "Select")
                            {
                               
                                DataTable dt = Landsettlementpattas.Epassbook((string)(Session["username"]), "pname", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, ddl_pattadhar.SelectedItem.Text, "", "", "", (string)Session["userprevilages"]);
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
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Pattadhar Name!')", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Enter Valid Captcha')", true);
                        txtInput.Value = "";
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter Captcha')", true);
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
                AntiForgery.Validate();
                LinkButton btn = (LinkButton)sender;
                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                Session["Itda"] = ddl_itda.SelectedItem.Text;
                Session["District"] = ddl_dist.SelectedItem.Text;
                Session["Mandal"] = ddl_mandal.SelectedItem.Text;
                Session["Village"] = ddl_village.SelectedItem.Text;
                    if (start != " ")
                    {
                        if (end == "1")
                        {
                            Session["bid"] = start.Trim();
                            // Response.Redirect("DetailsView_1B.aspx");
                            string url = "../pages/View_Epassbook.aspx";
                            string u = "window.open('" + url + "', 'popup_window', 'width=800,height=550,resizable=yes');";
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "script", u, true);

                        }

                    }
                




            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        //private string GetRandomText()

        //{

        //    StringBuilder randomText = new StringBuilder();

        //    string alphabets = "012345679";

        //    Random r = new Random();

        //    for (int j = 0; j < 5; j++)

        //    {
        //        //randomText.Append(alphabets[r.Next(alphabets.Length)]);

        //        a = (alphabets[r.Next(alphabets.Length)]);
        //        b = (alphabets[r.Next(alphabets.Length)]);
        //        c = (alphabets[r.Next(alphabets.Length)]);
        //        d = (alphabets[r.Next(alphabets.Length)]);
        //        e = (alphabets[r.Next(alphabets.Length)]);

        //    }

        //    randomText.Append(a + " " + b + " " + " " + c + " " + d + " " + e);

        //    Session["CaptchaCode"] = randomText.ToString();

        //    return Session["CaptchaCode"] as String;

        //}

        protected void Submit_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(5000);
            AntiForgery.Validate();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Web.Helpers;

namespace ROFR.pages
{
    public partial class Update_FarmerImage : System.Web.UI.Page
    {
        char a, b, c, d, e;
        string ct;
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
                    //ct = GetRandomText();

                    //mainCaptcha.InnerHtml = ct;
                    Get_Captcha();
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        FileUpload imageupload = (FileUpload)row.FindControl("FileUpload1");
                        imageupload.Attributes.Add("onchange", "return show('" + imageupload.ClientID + "');");
                    }
                       


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
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = false;
                ddl_dist.Items.Clear();
                ddl_dist.Items.Insert(0, new ListItem("Select", "0"));
                ddl_mandal.Items.Clear();
                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();
                ddl_village.Items.Insert(0, new ListItem("Select", "0"));

              
               // Get_Captcha();
                if (ddl_itda.SelectedItem.Text != "Select")
                {
                    ddl_dist.ClearSelection();
                    ddl_mandal.ClearSelection();
                    ddl_village.ClearSelection();
                    txtInput.Value = "";

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
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = false;
                ddl_mandal.Items.Clear();

                ddl_mandal.Items.Insert(0, new ListItem("Select", "0"));
                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                txtInput.Value = "";
               // Get_Captcha();
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
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = false;

                ddl_village.Items.Clear();

                ddl_village.Items.Insert(0, new ListItem("Select", "0"));
                txtInput.Value = "";
                //Get_Captcha();
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
                System.Threading.Thread.Sleep(5000);
                GridView1.Visible = false;
                txtInput.Value = "";
                //Get_Captcha();

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
                string captcha = txtInput.Value;
                // string captcha1 = mainCaptcha.InnerHtml;
                string captcha1= (string)Session["CaptchaCode"];
                if (captcha != null && captcha != "")
                {
                    //string string1 = captcha.Replace(" ", "");
                    //string string2 = captcha1.Replace(" ", "");
                    if (captcha == (string)Session["CaptchaCode"])
                    {
                        GridView1.Visible = true;

                        BinGrid();
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
                string Imagepath = string.Empty;
                string Imagename = string.Empty;
                string filepath = string.Empty;
                string location = string.Empty;
                LinkButton btn = (LinkButton)sender;
        

                string s = btn.CommandArgument;

                var range = s.IndexOf(',');

                string start = s.Substring(0, range);
                string end = s.Substring(s.LastIndexOf(',') + 1);
                foreach (GridViewRow row in GridView1.Rows)
                {
                    FileUpload imageupload= (FileUpload)row.FindControl("FileUpload1");
                    
                    string farmerid = (row.FindControl("lbl1") as Label).Text;

                    if (farmerid.ToString() == start.ToString())
                    {
                        int length = imageupload.PostedFile.ContentLength;
                        string cl = imageupload.PostedFile.ContentType;
                        Byte[] bytes = new byte[] { };
                        byte[] imgbyte = new byte[] { };
                        imgbyte = new byte[length];
                        int count = imageupload.FileName.Split('.').Length - 1;
                        HttpPostedFile image = imageupload.PostedFile;

                        image.InputStream.Read(imgbyte, 0, length);
                        string imagename = imageupload.PostedFile.FileName;

                        // FileUpload.PostedFile.SaveAs("~//Beneficiary Images" + "//" + imagename);
                        string imagefloder = ddl_itda.SelectedItem.Text + ddl_dist.SelectedValue;

                        //HttpPostedFile image1 = Request.Files["FileUpload"];

                        if (image != null && image.ContentLength > 0)
                        {
                            if (image.ContentLength <= 2000000)
                            {
                                string extension = System.IO.Path.GetExtension(imageupload.FileName);
                                if (count > 1)
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please select Valid Image!')", true);
                                }
                                else
                                {

                                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".JPG" || extension == ".JPEG" || extension == ".png" || extension == ".PNG")
                                    {
                                        try
                                        {
                                            if (cl == "image/png" || cl == "image/jpeg")
                                            {
                                                
                                              string  locpath = @"F:\tribal\BeneficairyImages\";
                                                string sc = @"\";
                                                location =(locpath + DateTime.Now.ToString("dd-MM-yyyy") + sc + imagefloder + sc + start + sc);

                                                if (!Directory.Exists(location))
                                                {
                                                    Directory.CreateDirectory(location);

                                                }
                                                string imagesavefilename = image.FileName;
                                                filepath = location + Path.GetFileName(image.FileName);
                                                image.SaveAs(filepath);
                                                Imagepath = location;
                                                imagename = image.FileName;
                                                DataTable dt = Landsettlementpattas.UploadImage((string)(Session["username"]),"upload", imagename, Imagepath, start, "", "", "", "", "", (string)Session["userprevilages"]);
                                                if (dt.Rows.Count > 0 && dt.Rows[0]["status"].ToString() == "Success")
                                                {

                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Farmer Image Updated Successfully')", true);
                                                    //btn.Enabled = false;

                                                }
                                                else
                                                {
                                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Farmer Image Updation Failed')", true);
                                                }

                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert(' Selected file is not a Image.. Please select Image')", true); return;
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Image Location Created Error !')", true);
                                            ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);

                                        }
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Only jpeg or png formats are allowed for images !')", true); return;
                                    }
                                }
                            }

                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('File size exceeds 2 MB')", true); return;
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "javascript:alert('Please Select Image')", true); return;
                        }
                    }
                    

                }

                BinGrid();
               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }

        }

        private void BinGrid()
        {
            try
            {
                string filename = string.Empty;
                string path = string.Empty;
                string apath = string.Empty;
                GridView1.Visible = true;
                DataTable dt = Landsettlementpattas.UploadImage((string)(Session["username"]), "details", ddl_itda.SelectedItem.Text, ddl_dist.SelectedItem.Text, ddl_mandal.SelectedItem.Text, ddl_village.SelectedItem.Text, "", "", "", "", (string)Session["userprevilages"]);
                dt.Columns.Add("Image", typeof(byte[]));
                dt.Columns.Add("AImage", typeof(byte[]));
                for (int i = 0; i < dt.Rows.Count ; i++)
                {
                    if (dt.Rows.Count > 0 )

                  {
                        if (dt.Rows[i]["Image1"].ToString() != "NA" && dt.Rows[i]["Imagepath"].ToString() != "NA")
                                 {
                            filename = dt.Rows[i]["Image1"].ToString();
                            path = dt.Rows[i]["Imagepath"].ToString();
                            //string sc = @"\";
                            DisplayImages(dt.Rows[i], "Image", (path + filename));
                        }
                        else
                        {

                            string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");

                            DisplayImages(dt.Rows[i], "Image", (imgpath));

                        }
                        if (dt.Rows[i]["AADHAAR_SERVICE_IMAGE"].ToString() != "NA")
                        {
                           
                            apath = dt.Rows[i]["AADHAAR_SERVICE_IMAGE"].ToString();



                            DisplayImages(dt.Rows[i], "AImage", (apath));


                        }
                        else
                        {

                            string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");

                            DisplayImages(dt.Rows[i], "AImage", (imgpath));

                        }
                    }
                }
                DataTable ds = dt;

                
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                FileUpload imageupload = (FileUpload)row.FindControl("FileUpload1");
                imageupload.Attributes.Add("onchange", "return show('" + imageupload.ClientID + "');");
            }

        }
        protected void GridView1_RowEditing(object sender, GridViewUpdateEventArgs e)
        {
            //gvwID.EditIndex = e.NewEditIndex;
            //BindGrid();
            foreach (GridViewRow row in GridView1.Rows)
            {
                FileUpload imageupload = (FileUpload)row.FindControl("FileUpload1");
                imageupload.Attributes.Add("onchange", "return show('" + imageupload.ClientID + "');");
            }
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


        protected void Submit_Click(object sender, EventArgs e)
        {
            AntiForgery.Validate();
            //ct = GetRandomText();

            // mainCaptcha.InnerHtml = ct;
            Get_Captcha();
            txtInput.Value = "";
        }
    }
}
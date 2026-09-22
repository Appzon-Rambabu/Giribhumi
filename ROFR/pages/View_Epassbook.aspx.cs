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
using System.Web.Helpers;

namespace ROFR.pages
{
    public partial class View_Epassbook : System.Web.UI.Page
    {
        protected void Page_PreInit(Object sender, EventArgs e)
        {
            if ((string)(Session["username"]) != null)
            {
                this.MasterPageFile = "~/Masters/ROFR_MASTER.Master";
            }
            else
            {

                this.MasterPageFile = "~/Masters/ROFR_MASTER.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (!IsPostBack)
                {
                    //  BindData();

                    ViewData();

                    if ((string)(Session["username"]) != null)
                    {
                        btn_passbook.Visible = true;
                    }
                    else
                    {

                        btn_passbook.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void ViewData()
        {
            try
            {

                HttpContext context = HttpContext.Current;
                string filename = string.Empty;
                string path = string.Empty;
                string imgBase64String = string.Empty;
                DataSet ds = Landsettlementpattas.ViewPassbook((string)(Session["bid"]), (string)(Session["userprevilages"]), (string)(Session["username"]));
                ds.Tables[0].Columns.Add("Image", typeof(byte[]));
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows.Count > 0)

                    {
                        if (ds.Tables[0].Rows[i]["Image1"].ToString() != "NA" && ds.Tables[0].Rows[i]["Imagepath"].ToString() != "NA")
                        {
                            filename = ds.Tables[0].Rows[i]["Image1"].ToString();
                            path = ds.Tables[0].Rows[i]["Imagepath"].ToString();
                            imgBase64String = GetBase64StringForImage(path + filename);
                            
                        }
                        else
                        {

                            string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");

                            imgBase64String = GetBase64StringForImage(imgpath);
                        }
                    }
                }
                DataTable dt = ds.Tables[0];
                DataTable dt1 = ds.Tables[1];
                if (dt.Rows.Count>0)
                {
                    txt_bid.Text = dt.Rows[0]["benficiary_id"].ToString();
                    txt_name.Text = dt.Rows[0]["ROFR_PATTADAAR"].ToString();
                    txt_fname.Text = dt.Rows[0]["Father_Name"].ToString();
                    txt_subcaste.Text = dt.Rows[0]["Sub_Caste"].ToString();
                    txt_aadhar.Text = dt.Rows[0]["Aadhaar_NO"].ToString();
                    txt_bankname.Text = dt.Rows[0]["BankName"].ToString();
                    txt_baccount.Text = dt.Rows[0]["BankAccountNo"].ToString();
                    txt_ifsc.Text = dt.Rows[0]["IfscCode"].ToString();
                    txt_itda.Text = dt.Rows[0]["ITDA_NAME"].ToString();
                    txt_district.Text = dt.Rows[0]["District"].ToString();
                    txt_mandal.Text = dt.Rows[0]["MANDAL"].ToString();
                    txt_village.Text = dt.Rows[0]["Village"].ToString();
                    txt_hab.Text = dt.Rows[0]["Habitation"].ToString();
                    txt_rvillage.Text = dt.Rows[0]["REV_VILLAGE"].ToString();
                    txt_division.Text = dt.Rows[0]["Forest_DIVISION"].ToString();
                    txt_range.Text = dt.Rows[0]["Forest_Range"].ToString();
                    txt_beat.Text = dt.Rows[0]["Forest_Beat"].ToString();
                    txt_block.Text = dt.Rows[0]["Forest_Block"].ToString();
                    txt_extentarea.Text = dt.Rows[0]["ExtentPlotArea"].ToString();
                    txt_hnature.Text = dt.Rows[0]["HOLDING_NATURE"].ToString();
                    txt_lclass.Text = dt.Rows[0]["Land_Classification_Name"].ToString();
                    txt_inam.Text = dt.Rows[0]["PATTA_INAMGOVT"].ToString();
                    Image1.ImageUrl = "data:image/jpeg;base64," + imgBase64String;

                }
                if(dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }
        private void BindData()
        {
            try
            {

                HttpContext context = HttpContext.Current;
                string filename = string.Empty;
                string path = string.Empty;
               
                DataSet ds = Landsettlementpattas.EPassbook((string)(Session["bid"]), (string)(Session["userprevilages"]), (string)(Session["username"]));
                ds.Tables[0].Columns.Add("Image", typeof(byte[]));

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows.Count > 0)

                    {
                        if (ds.Tables[0].Rows[i]["Image1"].ToString() != "NA" && ds.Tables[0].Rows[i]["Imagepath"].ToString() != "NA")
                        {
                            filename = ds.Tables[0].Rows[i]["Image1"].ToString();
                            path = ds.Tables[0].Rows[i]["Imagepath"].ToString();
                            DisplayImages(ds.Tables[0].Rows[i], "Image", (path + filename));
                        }
                        else
                        {

                            string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");
                            DisplayImages(ds.Tables[0].Rows[i], "Image", (imgpath));


                        }
                    }
                }
                //if (ds.Tables[0].Rows[0]["Image1"].ToString() != "NA" && ds.Tables[0].Rows[0]["Imagepath"].ToString() != "NA")
                //{
                //    filename = ds.Tables[0].Rows[0]["Image1"].ToString();
                //    path = ds.Tables[0].Rows[0]["Imagepath"].ToString();


                //    DisplayImages(ds.Tables[0].Rows[0], "Image", (path + filename));
                //}
                //else
                //{

                //    string imgpath = HttpContext.Current.Server.MapPath("~/imagesnew/unimg.png");

                //    DisplayImages(ds.Tables[0].Rows[0], "Image", (imgpath));

                //}
                ReportDocument crystalReport = new ReportDocument();
                crystalReport.Load(Server.MapPath("~/BeneficiaryPassbook.rpt"));
                crystalReport.Database.Tables["DataTable1"].SetDataSource(ds.Tables[0]);
                crystalReport.Database.Tables[1].SetDataSource(ds.Tables[1]);
                CrystalReportViewer1.ReportSource = crystalReport;
                CrystalReportViewer1.DataBind();
                string cfilename ="Report.pdf";
           
           crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, ds.Tables[0].Rows[0]["ROFR_PATTADAAR"].ToString());

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

        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                AntiForgery.Validate();
                BindData();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

    }
}
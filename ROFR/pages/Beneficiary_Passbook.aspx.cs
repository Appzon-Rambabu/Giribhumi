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
namespace ROFR.pages
{
    public partial class Beneficiary_Passbook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataTable dt = Landsettlementpattas.ViewBeneficiaryPlots(txt_adhar.Text, (string)(Session["userprevilages"]), (string)(Session["username"]));
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
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

        protected void btn_rdlcpdf_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Landsettlementpattas.BeneficiaryPassbook(txt_adhar.Text, (string)(Session["userprevilages"]), (string)(Session["username"]));
               // DataSet dsa;
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Beneficiary.rdlc");
                //Beneficiary ds = GetData();
                ReportDataSource datasource = new ReportDataSource("Beneficiary", dt);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);


                Warning[] warnings;
                string[] streamIds;
                string contentType;
                string encoding;
                string extension;

                //Export the RDLC Report to Byte Array.
                byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);

                //Download the RDLC Report in Word, Excel, PDF and Image formats.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC.pdf");
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();

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
                HttpContext context=HttpContext.Current;
                string filename = string.Empty;
                string path = string.Empty;
                DataSet ds = Landsettlementpattas.BeneficiaryePassbook(txt_adhar.Text, (string)(Session["userprevilages"]), (string)(Session["username"]));
                ds.Tables[0].Columns.Add("Image", typeof(byte[]));
                if (ds.Tables[0].Rows.Count>0)
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
                CrystalReportViewer1.ReportSource = crystalReport;

                string cfilename = "Report.pdf";

                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "REPORT");
              
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
    private Beneficiary GetData()
        {
            dynamic objdata = new ExpandoObject();
            DataTable dt = Landsettlementpattas.BeneficiaryPassbook(txt_adhar.Text, (string)(Session["userprevilages"]), (string)(Session["username"]));
            if (dt != null && dt.Rows.Count > 0)
            {
               
                objdata.data = dt;

               
            }
            return objdata;
        }


    }
}
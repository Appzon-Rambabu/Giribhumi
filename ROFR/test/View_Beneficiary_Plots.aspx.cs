using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ROFR.helper;
using System.Data;
using System.IO;
using System.Text;
//using iTextSharp.text;
//using iTextSharp.text.pdf;
//using iTextSharp.text.html.simpleparser;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using System.Configuration;

namespace ROFR.test
{
    public partial class View_Beneficiary_Plots : System.Web.UI.Page
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

        protected void BindGrid()
        {
            DataTable dt = Landsettlementpattas.ViewBeneficiaryPlots(txt_adhar.Text, (string)(Session["userprevilages"]), (string)(Session["username"]));
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
        //protected void btn_pdf_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        //Response.ClearContent();
        //        //Response.ContentType = "application/pdf";
        //        //Response.AddHeader("content-disposition", "attachment;filename=MyPdfFile.pdf");
        //        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //        //StringWriter strWrite = new StringWriter();
        //        //HtmlTextWriter htmWrite = new HtmlTextWriter(strWrite);
        //        //HtmlForm frm = new HtmlForm();
        //        //GridView1.Parent.Controls.Add(frm);
        //        ////frm.Attributes["runat"] = "server";
        //        //frm.Controls.Add(GridView1);
        //        //frm.RenderControl(htmWrite);
        //        //StringReader sr = new StringReader(strWrite.ToString());
        //        //Document pdfDoc = new Document(PageSize.A4, 8f, 8f, 8f, 2f);
        //        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //        //pdfDoc.Open();
        //        //htmlparser.Parse(sr);
        //        //pdfDoc.Close();
        //        //Response.Write(pdfDoc);
        //        //Response.Flush();
        //        //Response.End();


        //        //-----------------------
        //        DataTable dt = Landsettlementpattas.ViewBeneficiaryPlots(txt_adhar.Text, (string)(Session["userprevilages"]), (string)(Session["username"]));
        //        using (StringWriter sw = new StringWriter())
        //        {
        //            using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //            {
        //                //To Export all pages
        //                // GridView1.AllowPaging = false;

        //                DataGrid dgGrid = new DataGrid();
        //                dgGrid.DataSource = dt;
        //                dgGrid.DataBind();
        //                dgGrid.HeaderStyle.BackColor = System.Drawing.Color.CornflowerBlue;


        //                //Get the HTML for the control.
        //                dgGrid.RenderControl(hw);


        //                StringReader sr = new StringReader(sw.ToString());
        //                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        //                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //                pdfDoc.Open();
        //                htmlparser.Parse(sr);
        //                pdfDoc.Close();

        //                Response.ContentType = "application/pdf";
        //                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //                Response.Write(pdfDoc);
        //                Response.End();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}

        //protected void btn_pdf1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable dt = Landsettlementpattas.ViewBeneficiaryPlots(txt_adhar.Text, (string)(Session["userprevilages"]), (string)(Session["username"]));
        //        DataRow dr;
        //        //  DataRow dr = GetData("SELECT * FROM Employees where EmployeeId = " + ddlEmployees.SelectedItem.Value).Rows[0]; ;
        //        Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
        //        Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
        //        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
        //        {
        //            PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
        //            Phrase phrase = null;
        //            PdfPCell cell = null;
        //            PdfPTable table = null;
        //            BaseColor color = null;

        //            document.Open();

        //            //Header Table
        //            table = new PdfPTable(2);
        //            table.TotalWidth = 500f;
        //            table.LockedWidth = true;
        //            table.SetWidths(new float[] { 0.3f, 0.7f });

        //            //Company Logo
        //            //cell = ImageCell("~/imagesnew/jcm.jpeg", 30f, PdfPCell.ALIGN_CENTER);
        //            //table.AddCell(cell);

        //            //Company Name and Address
        //            //phrase = new Phrase();
        //            //phrase.Add(new Chunk("Microsoft Northwind Traders Company\n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.RED)));
        //            //phrase.Add(new Chunk("107, Park site,\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
        //            //phrase.Add(new Chunk("Salt Lake Road,\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
        //            //phrase.Add(new Chunk("Seattle, USA", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
        //            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        //            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
        //            table.AddCell(cell);

        //            //Separater Line
        //            color = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
        //            //DrawLine(writer, 25f, document.Top - 79f, document.PageSize.Width - 25f, document.Top - 79f, color);
        //            //DrawLine(writer, 25f, document.Top - 80f, document.PageSize.Width - 25f, document.Top - 80f, color);
        //            document.Add(table);

        //            table = new PdfPTable(2);
        //            table.HorizontalAlignment = Element.ALIGN_LEFT;
        //            table.SetWidths(new float[] { 0.3f, 1f });
        //            table.SpacingBefore = 20f;

        //            //Employee Details
        //            cell = PhraseCell(new Phrase("Beneficiary Plot", FontFactory.GetFont("Arial", 12, Font.UNDERLINE, BaseColor.BLACK)), PdfPCell.ALIGN_CENTER);
        //            cell.Colspan = 2;
        //            table.AddCell(cell);
        //            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //            cell.Colspan = 2;
        //            cell.PaddingBottom = 30f;
        //            table.AddCell(cell);

        //            //Photo
        //            cell = ImageCell(string.Format("~/imagesnew/jcm.jpeg", dt.Rows[0]["Id"].ToString()), 25f, PdfPCell.ALIGN_CENTER);
        //            table.AddCell(cell);

        //            //Name
        //            phrase = new Phrase();
        //            phrase.Add(new Chunk(dt.Rows[0]["ROFR_PATTADAAR"].ToString() + " " + dt.Rows[0]["Village"].ToString() + " " + dt.Rows[0]["Id"].ToString() + "\n", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
        //            phrase.Add(new Chunk("(" + dt.Rows[0]["ROFR_PATTADAAR"].ToString() + ")", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)));
        //            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
        //            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
        //            table.AddCell(cell);
        //            document.Add(table);

        //            //DrawLine(writer, 160f, 80f, 160f, 690f, BaseColor.BLACK);
        //            //DrawLine(writer, 115f, document.Top - 200f, document.PageSize.Width - 100f, document.Top - 200f, BaseColor.BLACK);

        //            table = new PdfPTable(2);
        //            table.SetWidths(new float[] { 0.5f, 2f });
        //            table.TotalWidth = 340f;
        //            table.LockedWidth = true;
        //            table.SpacingBefore = 20f;
        //            table.HorizontalAlignment = Element.ALIGN_RIGHT;

        //            //Employee Id
        //            table.AddCell(PhraseCell(new Phrase("Beneficiary Id:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //            table.AddCell(PhraseCell(new Phrase("000" + dt.Rows[0]["Id"].ToString(), FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //            cell.Colspan = 2;
        //            cell.PaddingBottom = 10f;
        //            table.AddCell(cell);


        //            //Address
        //            table.AddCell(PhraseCell(new Phrase("Address:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //            phrase = new Phrase(new Chunk("KRISHNA DIST" + "\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
        //            phrase.Add(new Chunk("VIJAYAWADA" + "\n", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
        //            phrase.Add(new Chunk("XXX" + " " + "INDIA" + " " + "521137", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)));
        //            table.AddCell(PhraseCell(phrase, PdfPCell.ALIGN_LEFT));
        //            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //            cell.Colspan = 2;
        //            cell.PaddingBottom = 10f;
        //            table.AddCell(cell);

        //            //Date of Birth
        //            table.AddCell(PhraseCell(new Phrase("Date of Birth:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //            table.AddCell(PhraseCell(new Phrase("23-10-2019", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //            cell.Colspan = 2;
        //            cell.PaddingBottom = 10f;
        //            table.AddCell(cell);

        //            //Phone
        //            table.AddCell(PhraseCell(new Phrase("Phone Number:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //            table.AddCell(PhraseCell(new Phrase("1234567" + " Ext: " + "90", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //            cell = PhraseCell(new Phrase(), PdfPCell.ALIGN_CENTER);
        //            cell.Colspan = 2;
        //            cell.PaddingBottom = 10f;
        //            table.AddCell(cell);

        //            //Addtional Information
        //            table.AddCell(PhraseCell(new Phrase("Addtional Information:", FontFactory.GetFont("Arial", 8, Font.BOLD, BaseColor.BLACK)), PdfPCell.ALIGN_LEFT));
        //            table.AddCell(PhraseCell(new Phrase("NOTE", FontFactory.GetFont("Arial", 8, Font.NORMAL, BaseColor.BLACK)), PdfPCell.ALIGN_JUSTIFIED));
        //            document.Add(table);
        //            document.Close();
        //            byte[] bytes = memoryStream.ToArray();
        //            memoryStream.Close();
        //            Response.Clear();
        //            Response.ContentType = "application/pdf";
        //            Response.AddHeader("Content-Disposition", "attachment; filename=Beneficiary.pdf");
        //            Response.ContentType = "application/pdf";
        //            Response.Buffer = true;
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.BinaryWrite(bytes);
        //            Response.End();
        //            Response.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Error !')", true);
        //        ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, (string)(Session["username"]), HttpContext.Current.Request.UserHostAddress);
        //    }
        //}

        //private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        //{
        //    PdfContentByte contentByte = writer.DirectContent;
        //    contentByte.SetColorStroke(color);
        //    contentByte.MoveTo(x1, y1);
        //    contentByte.LineTo(x2, y2);
        //    contentByte.Stroke();
        //}
        //private static PdfPCell PhraseCell(Phrase phrase, int align)
        //{
        //    PdfPCell cell = new PdfPCell(phrase);
        //    cell.BorderColor = BaseColor.WHITE;
        //    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
        //    cell.HorizontalAlignment = align;
        //    cell.PaddingBottom = 2f;
        //    cell.PaddingTop = 0f;
        //    return cell;
        //}
        //private static PdfPCell ImageCell(string path, float scale, int align)
        //{
        //    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
        //    image.ScalePercent(scale);
        //    PdfPCell cell = new PdfPCell(image);
        //    cell.BorderColor = BaseColor.WHITE;
        //    // cell.VerticalAlignment = BaseColor.ALIGN_TOP;
        //    cell.HorizontalAlignment = align;
        //    cell.PaddingBottom = 0f;
        //    cell.PaddingTop = 0f;
        //    return cell;
        //}
    }
}
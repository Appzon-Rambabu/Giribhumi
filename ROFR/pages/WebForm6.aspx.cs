using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Data;
using ROFR.helper;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System.Text;

namespace ROFR.pages
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    Label myLabel = this.FindControl("Label1") as Label;
                    myLabel.Text = (string)(Session["Itda"]);
                    Label myLabel1 = this.FindControl("Label3") as Label;
                    myLabel1.Text = (string)(Session["District"]);
                    Label myLabel2 = this.FindControl("Label5") as Label;
                    myLabel2.Text = (string)(Session["Mandal"]);
                    Label myLabel3 = this.FindControl("Label7") as Label;
                    myLabel3.Text = (string)(Session["Village"]);
                     DataTable dtpdf = new DataTable();
                    dtpdf = ProjectRofrBAL.GetMasterDetails.Get_Land_Images_Report("pdfIHaving", (string)(Session["Itda"]), (string)(Session["District"]), (string)(Session["Mandal"]), (string)(Session["Village"]), (string)(Session["username"]), (string)Session["userprevilages"]);

                    StringBuilder sb = new StringBuilder();

                    sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;margin-left: 100px;margin - right: auto; '>");

                    //Adding HeaderRow.
                    sb.Append("<tr>");
                    sb.Append("<th>S.No</th>");
                    sb.Append("<th>Id</th>");
                    sb.Append("<th>Benficiary Id</th>");
                    sb.Append("<th>Rofr Pattadaar</th>");
                    sb.Append("<th>Father Name</th>");

                    sb.Append("<th>Compartment No.</th>");
                    sb.Append("<th>ROFR Pattano.</th>");
                    sb.Append("<th>Plot No.</th>");
                    sb.Append("<th>Extent Plot Area</th>");
                    sb.Append("<th>Aadhaar No.</th>");
                    sb.Append("<th>Land Image1</th>");
                    sb.Append("<th>Land Image2</th>");
                    sb.Append("</tr>");

                    for (int i = 0; i <= (dtpdf.Rows.Count-1); i++)
                    {
                        var k = i ;
                        k = k + 1;
                       // var f = '<img src=' + "Land Images/Image1/04-10-2020_150504452_218884_150504452_218884_1.jpg" + ' alt="" style="width:50px; height:50px;">';
                        var tblRow = "<tr><td>" + k + "</td><td style='color:#003399;'>" + dtpdf.Rows[i]["ID"].ToString() + "</td><td style='color:#003399;'>" + dtpdf.Rows[i]["benficiary_id2"].ToString() + "</td><td style='color:#003399;'>" + dtpdf.Rows[i]["ROFR_PATTADAAR"].ToString() + "</td><td>" + dtpdf.Rows[i]["Father_Name"].ToString() + "</td><td>" + dtpdf.Rows[i]["Compartment_No"].ToString()  + "</td><td>" + dtpdf.Rows[i]["ROFR_PATTANO"].ToString() + "</td><td>" + dtpdf.Rows[i]["Plot_No"].ToString() + "</td><td>" + dtpdf.Rows[i]["ExtentPlotArea"].ToString() + "</td><td>" + dtpdf.Rows[i]["Aadhaar_NO"].ToString() + "</td><td><img src=" + dtpdf.Rows[i]["limg1"].ToString() + " alt='' style='width:50px; height:50px;'></td><td><img src=" + dtpdf.Rows[i]["limg2"].ToString() + " alt='' style='width:50px; height:50px;'></td></tr>";
                        sb.Append(tblRow);

                    }

                  
                    //Table end.
                    sb.Append("</table>");
                    ltTable.Text = sb.ToString();
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